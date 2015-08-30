using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AIRally.Model.Tiles;

namespace AIRally.Model.Boards
{
    public class Board 
    {
        public int Height { get; }
        public int Width { get; }

        public string Name { get; }
        public List<Tile> Tiles { get; }
        public List<Tile> SpawnPoints { get; } 
        public Tile this[int row, int column]
        {
            get { return Tiles[Width * row + column]; }
        }

        public Board(string name, string boardString)
        {
            Name = name;
            Tiles = new List<Tile>();
            SpawnPoints = new List<Tile>();

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
                    currTile = Tile.MakeTile(tileRow[column], column, row);
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

        public Board(string filename): this(StripFileName(filename), new StreamReader(filename).ReadToEnd())
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
    }
}
