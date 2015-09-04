using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Laser : TileDecorator
    {
        public int Number { get; }

        public Laser(Board board, Tile baseTile, int number, int x, int y) : base(board, baseTile, x, y)
        {
            Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "L" + Number;
        }

        public override Image Paint()
        {
            return BaseTile.Paint();
        }

        public override int HasLasers()
        {
            return BaseTile.HasLasers() + Number;
        }
    }
}