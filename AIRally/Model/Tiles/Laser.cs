using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Laser : TileDecorator
    {
        public Laser(Tile baseTile) : base(baseTile)
        {
            
        }

        public override string ToString()
        {
            return baseTile.ToString() + "L0";
        }

        public override Image Draw()
        {
            return baseTile.Draw();
        }
    }
}
