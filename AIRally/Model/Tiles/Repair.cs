using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Repair : TileDecorator
    {
        public Repair(Board board, Tile baseTile, int x, int y) : base(board, baseTile, x, y)
        {
        }

        public override bool HasRepair()
        {
            return true;
        }

        public override Image Paint()
        {
            return PaintOn("Repair");
        }

        public override string ToString()
        {
            return BaseTile + "R";
        }
    }
}