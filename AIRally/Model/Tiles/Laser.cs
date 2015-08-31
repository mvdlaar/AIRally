using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Laser : TileDecorator
    {
        public int Number { get; }

        public Laser(Tile baseTile, int number, int x, int y) : base(baseTile, x, y)
        {
            Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "L" + Number;
        }

        public override Image Draw()
        {
            return BaseTile.Draw();
        }

        public override int HasLasers()
        {
            return BaseTile.HasLasers() + Number;
        }
    }
}
