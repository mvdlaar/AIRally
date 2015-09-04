using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Flag : TileDecorator
    {
        public int Number { get; }

        public Flag(Board board, Tile baseTile, int number, int x, int y) : base(board, baseTile, x, y)
        {
            Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "F" + Number;
        }

        public override Image Paint()
        {
            return PaintOn("Flag" + Number);
        }

        public override bool HasRepair()
        {
            return true;
        }
    }
}