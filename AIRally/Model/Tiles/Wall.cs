using System.Drawing;
using System.IO;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public class Wall : TileDecorator
    {
        public WallDirection Direction { get; }

        public Wall(Tile baseTile, WallDirection direction): base(baseTile)
        {
            this.Direction = direction;
        }

        public override string ToString()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return baseTile.ToString() + "WT";
                    break;
                case WallDirection.Right:
                    return baseTile.ToString() + "WR";
                    break;
                case WallDirection.Bottom:
                    return baseTile.ToString() + "WB";
                    break;
                case WallDirection.Left:
                    return baseTile.ToString() + "WL";
                    break;
                default:
                    return baseTile.ToString();
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
            return baseTile.Draw();
        }
    }
}
