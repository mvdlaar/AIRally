using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Pit : Tile
    {
        public Pit(Board board, int x, int y) : base(board, x, y)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public override Image Paint()
        {
            return PaintMe("PitGeneric");
        }

        public override bool IsPit()
        {
            return true;
        }
    }
}