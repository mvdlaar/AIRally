using AIRally.Model.Decks;
using AIRally.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AIRally.Model.Boards
{
    public class Board
    {
        internal AIRally aiRally;

        public Board(AIRally aiRally, string name, string boardString)
        {
            Name = name;
            Tiles = new List<Tile>();
            SpawnPoints = new List<Tile>();
            this.aiRally = aiRally;

            var lines = Regex.Split(boardString, "\r\n|\r|\n");

            var size = lines[0].Split('x');
            Height = Convert.ToInt32(size[0]);
            Width = Convert.ToInt32(size[1]);

            Tile currTile = null;

            for (var y = 0; y < Height; y++)
            {
                var tileRow = lines[y + 1].Split(';');
                for (var x = 0; x < Width; x++)
                {
                    currTile = Tile.MakeTile(this, tileRow[x], x, y);
                    Tiles.Add(currTile);
                    if (currTile.HasSpawnPoint() != 0)
                    {
                        SpawnPoints.Add(currTile);
                    }
                }
            }
            SpawnPoints = SpawnPoints.OrderBy(o => o.HasSpawnPoint()).ToList();
        }

        public Board(AIRally airally, string filename)
            : this(airally, StripFileName(filename), new StreamReader(filename).ReadToEnd())
        {
        }

        public int Height { get; }
        public string Name { get; }
        public List<Tile> SpawnPoints { get; }
        public List<Tile> Tiles { get; }
        public int Width { get; }

        public Tile this[int x, int y]
        {
            get { return Tiles[Width*y + x]; }
        }

        public Image Paint(int width, int height)
        {
            var tileHeight = height/Height;
            var tileWidth = width/Width;
            Image img;

            Image imgBoard = new Bitmap(width, height);
            var g = Graphics.FromImage(imgBoard);
            g.Clear(SystemColors.AppWorkspace);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingMode = CompositingMode.SourceCopy;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    img = this[x, y].Paint();
                    if (img != null)
                    {
                        g.DrawImage(img, x*tileWidth, y*tileHeight, tileWidth, tileHeight);
                        img.Dispose();
                    }
                }
            }
            g.Dispose();

            g = Graphics.FromImage(imgBoard);
            foreach (var ai in aiRally.AIs)
            {
                img = ai.Paint();

                if (img != null)
                {
                    g.DrawImage(img, ai.X*tileWidth, ai.Y*tileHeight, tileWidth, tileHeight);
                    img.Dispose();
                }
            }
            g.Dispose();
            return imgBoard;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(Height);
            result.Append('x');
            result.Append(Width);
            var column = 0;
            foreach (var tile in Tiles)
            {
                if (column == 0)
                {
                    result.AppendLine();
                }
                result.Append(tile);
                if (column >= Width - 1)
                {
                    column = 0;
                }
                else
                {
                    result.Append(';');
                    column++;
                }
            }
            return result.ToString();
        }

        internal void ExecuteProgramCard(AI ai, ProgramCard card)
        {
            switch (card.CardAction)
            {
                case ProgramCardAction.RotateLeft:
                    ai.Direction = TileDirectionUtil.TurnLeft(ai.Direction);
                    break;

                case ProgramCardAction.RotateRight:
                    ai.Direction = TileDirectionUtil.TurnRight(ai.Direction);
                    break;

                case ProgramCardAction.UTurn:
                    ai.Direction = TileDirectionUtil.Opposite(ai.Direction);
                    break;

                case ProgramCardAction.Move1:
                    MoveAIOnce(ai);
                    break;

                case ProgramCardAction.Move2:
                    MoveAIOnce(ai);
                    MoveAIOnce(ai);
                    break;

                case ProgramCardAction.Move3:
                    MoveAIOnce(ai);
                    MoveAIOnce(ai);
                    MoveAIOnce(ai);
                    break;

                case ProgramCardAction.BackUp:
                    MoveAIOnce(ai, TileDirectionUtil.Opposite(ai.Direction));
                    break;
            }
        }

        private static string StripFileName(string filename)
        {
            var folderParts = filename.Split('\\');
            var fileParts = folderParts[folderParts.Length - 1].Split('.');
            return fileParts[0];
        }

        private void MoveAIOnce(AI ai, TileDirection direction)
        {
            if (direction != TileDirection.None)
            {
                var toX = ai.X;
                var toY = ai.Y;

                switch (direction)
                {
                    case TileDirection.Up:
                        toY--;
                        break;

                    case TileDirection.Down:
                        toY++;
                        break;

                    case TileDirection.Left:
                        toX--;
                        break;

                    case TileDirection.Right:
                        toX++;
                        break;
                }

                //Check if movement is off the board
                if (toX < 0 || toY < 0 || toX >= Width || toY >= Height)
                {
                    if (!this[ai.X, ai.Y].HasWall(direction))
                    {
                        ai.Die();
                    }
                }
                else
                {
                    //Check if movement is blocked by walls
                    if (!this[ai.X, ai.Y].HasWall(ai.Direction) &&
                        !this[toX, toY].HasWall(TileDirectionUtil.Opposite(direction)))
                    {
                        //Check if movement is into a Pit
                        if (this[toX, toY].IsPit())
                        {
                            ai.X = toX;
                            ai.Y = toY;
                            ai.Die();
                        }
                        else
                        {
                            //Check if an AI is already on the new Tile
                            if (this[toX, toY].HasAI() != null)
                            {
                                //Move the AI on the new Tile (if not possible the AI stays)
                                //MoveAIOnce(this[toX, toY].HasAI(), direction);
                                //If the other AI moved, move this AI
                                if (this[toX, toY].HasAI() == null)
                                {
                                    ai.X = toX;
                                    ai.Y = toY;
                                }
                            }
                            else
                            {
                                //When there are no problems, just move the AI
                                ai.X = toX;
                                ai.Y = toY;
                            }
                        }
                    }
                }
            }
        }

        private void MoveAIOnce(AI ai)
        {
            MoveAIOnce(ai, ai.Direction);
        }
    }
}