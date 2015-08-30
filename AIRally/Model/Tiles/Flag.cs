using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Flag : TileDecorator
    {
        public int Number { get; }

        public Flag(Tile baseTile, int number): base(baseTile)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return baseTile + "F" + Number;
        }

        public override Image Draw()
        {
            return DrawOn("Flag" + Number);
        }
    }
}
