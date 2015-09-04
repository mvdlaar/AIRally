using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Wall : TileDecorator
    {
        public WallDirection Direction { get; }

        public Wall(Board board, Tile baseTile, WallDirection direction, int x, int y) : base(board, baseTile, x, y)
        {
            Direction = direction;
        }

        private string Postfix(string prefix)
        {
            StringBuilder result = new StringBuilder(prefix);
            result.Append(GetWallDirectionChar(Direction));
            return result.ToString();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("W");
        }

        public override Image Paint()
        {
            switch (Direction)
            {
                case WallDirection.Top:
                    return PaintOn("WallUp");

                case WallDirection.Bottom:
                    return PaintOn("WallDown");

                case WallDirection.Left:
                    return PaintOn("WallLeft");

                case WallDirection.Right:
                    return PaintOn("WallRight");
            }
            return BaseTile.Paint();
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