using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Floor : Tile
    {
        public Floor(Board board, int x, int y) : base(board, x, y)
        {
        }

        public override Image Paint()
        {
            return PaintMe("Floor");
        }

        public override string ToString()
        {
            return "F";
        }
    }
}