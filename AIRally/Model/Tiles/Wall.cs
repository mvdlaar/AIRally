using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Wall : TileDecorator
    {
        public Wall(Board board, Tile baseTile, TileDirection direction, int x, int y) : base(board, baseTile, x, y)
        {
            Direction = direction;
        }

        public TileDirection Direction { get; }

        public override bool HasWall(TileDirection direction)
        {
            return BaseTile.HasWall(direction) || Direction == direction;
        }

        public override TileDirection[] HasWalls()
        {
            var old = base.HasWalls();
            var result = new TileDirection[old.Length + 1];
            for (var i = 0; i < old.Length; i++)
            {
                result[i] = old[i];
            }
            result[result.Length - 1] = Direction;
            return result;
        }

        public override Image Paint()
        {
            switch (Direction)
            {
                case TileDirection.Up:
                    return PaintOn("WallUp");

                case TileDirection.Down:
                    return PaintOn("WallDown");

                case TileDirection.Left:
                    return PaintOn("WallLeft");

                case TileDirection.Right:
                    return PaintOn("WallRight");
            }
            return BaseTile.Paint();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("W");
        }

        private string Postfix(string prefix)
        {
            var result = new StringBuilder(prefix);
            result.Append(GetWallDirectionChar(Direction));
            return result.ToString();
        }
    }
}