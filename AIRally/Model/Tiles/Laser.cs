using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Laser : TileDecorator
    {
        public Laser(Tile baseTile, int x, int y) : base(baseTile, x, y)
        {
            
        }

        public override string ToString()
        {
            return BaseTile.ToString() + "L0";
        }

        public override Image Draw()
        {
            return BaseTile.Draw();
        }

        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasRepair()
        {
            return BaseTile.HasRepair();
        }
    }
}
