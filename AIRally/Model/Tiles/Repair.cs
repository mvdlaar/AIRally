using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Repair: TileDecorator
    {
        public Repair(Tile baseTile) : base(baseTile)
        {
            
        }

        public override string ToString()
        {
            return baseTile.ToString() + "R";
        }

        public override Image Draw()
        {
            return DrawOn("Repair");
        }
    }
}
