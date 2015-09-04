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
        public int Height { get; }
        public int Width { get; }

        public string Name { get; }
        public List<Tile> Tiles { get; }
        public List<Tile> SpawnPoints { get; }

        internal AIRally aiRally;

        public Tile this[int row, int column]
        {
            get { return Tiles[Width * row + column]; }
        }

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

            for (int row = 0; row < Height; row++)
            {
                var tileRow = lines[row + 1].Split(';');
                for (int column = 0; column < Width; column++)
                {
                    currTile = Tile.MakeTile(this, tileRow[column], column, row);
                    Tiles.Add(currTile);
                    if (currTile.HasSpawnPoint() != 0)
                    {
                        SpawnPoints.Add(currTile);
                    }
                }
            }
            SpawnPoints = SpawnPoints.OrderBy(o => o.HasSpawnPoint()).ToList();
        }

        private static string StripFileName(string filename)
        {
            var FolderParts = filename.Split('\\');
            var FileParts = FolderParts[FolderParts.Length - 1].Split('.');
            return FileParts[0];
        }

        public Board(AIRally airally, string filename) : this(airally, StripFileName(filename), new StreamReader(filename).ReadToEnd())
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Height);
            result.Append('x');
            result.Append(Width);
            int column = 0;
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

        public Image Paint(int width, int height)
        {
            int tileHeight = height / Height;
            int tileWidth = width / Width;
            Image img;

            Image imgBoard = new Bitmap(width, height);
            var g = Graphics.FromImage(imgBoard);
            g.Clear(SystemColors.AppWorkspace);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingMode = CompositingMode.SourceCopy;

            for (var row = 0; row < Height; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    img = this[row, column].Paint();
                    if (img != null)
                    {
                        g.DrawImage(img, column * tileWidth, row * tileHeight, tileWidth, tileHeight);
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
                    g.DrawImage(img, ai.X * tileWidth, ai.Y * tileHeight, tileWidth, tileHeight);
                    img.Dispose();
                }
            }
            g.Dispose();
            return imgBoard;
        }
    }
}