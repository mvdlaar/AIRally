using System.Drawing;
using System.IO;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public class Wall : TileDecorator
    {
        public WallDirection Direction { get; }

        public Wall(Tile baseTile, WallDirection direction, int x, int y) : base(baseTile, x, y)
        {
            Direction = direction;
        }

        public override string ToString()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return BaseTile + "WT";
                case WallDirection.Right:
                    return BaseTile + "WR";
                case WallDirection.Bottom:
                    return BaseTile + "WB";
                case WallDirection.Left:
                    return BaseTile + "WL";
                default:
                    return BaseTile.ToString();
            }
        }

        public override Image Draw()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return DrawOn("WallUp");
                case WallDirection.Bottom:
                    return DrawOn("WallDown");
                case WallDirection.Left:
                    return DrawOn("WallLeft");
                case WallDirection.Right:
                    return DrawOn("WallRight");
            }
            return BaseTile.Draw();
        }

        public override WallDirection[] HasWalls()
        {
            var old = base.HasWalls();
            var result = new WallDirection[old.Length + 1];
            for (var i = 0; i < old.Length; i++)
            {
                result[i] = old[i];
            }
            result[result.Length - 1] = Direction;
            return result;
        }
    }
}
