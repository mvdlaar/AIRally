using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Pit : Tile
    {
        public Pit(Board board, int x, int y) : base(board, x, y)
        {
        }

        public override bool IsPit()
        {
            return true;
        }

        public override Image Paint()
        {
            return PaintMe("PitGeneric");
        }

        public override string ToString()
        {
            return "P";
        }
    }
}