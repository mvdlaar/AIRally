using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Repair: TileDecorator
    {
        public Repair(Tile baseTile, int x, int y) : base(baseTile, x, y)
        {
            
        }

        public override string ToString()
        {
            return BaseTile + "R";
        }

        public override Image Draw()
        {
            return DrawOn("Repair");
        }

        public override bool HasRepair()
        {
            return true;
        }
    }
}
