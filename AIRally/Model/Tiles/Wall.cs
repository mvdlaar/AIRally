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
            this.Direction = direction;
        }

        public override string ToString()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return BaseTile + "WT";
                    break;
                case WallDirection.Right:
                    return BaseTile + "WR";
                    break;
                case WallDirection.Bottom:
                    return BaseTile + "WB";
                    break;
                case WallDirection.Left:
                    return BaseTile + "WL";
                    break;
                default:
                    return BaseTile.ToString();
                    break;
            }
        }

        public override Image Draw()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return DrawOn("WallUp");
                    break;
                case WallDirection.Bottom:
                    return DrawOn("WallDown");
                    break;
                case WallDirection.Left:
                    return DrawOn("WallLeft");
                    break;
                case WallDirection.Right:
                    return DrawOn("WallRight");
                    break;
            }
            return BaseTile.Draw();
        }

        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasRepair()
        {
            return BaseTile.HasRepair();
        }
    }
}
