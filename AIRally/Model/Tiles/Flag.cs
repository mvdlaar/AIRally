using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Flag : TileDecorator
    {
        public Flag(Board board, Tile baseTile, int number, int x, int y) : base(board, baseTile, x, y)
        {
            Number = number;
        }

        public int Number { get; }

        public override int HasFlag()
        {
            return Number;
        }

        public override bool HasRepair()
        {
            return true;
        }

        public override Image Paint()
        {
            return PaintOn("Flag" + Number);
        }

        public override string ToString()
        {
            return BaseTile + "F" + Number;
        }
    }
}