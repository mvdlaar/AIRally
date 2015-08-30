using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Flag : TileDecorator
    {
        public int Number { get; }

        public Flag(Tile baseTile, int number, int x, int y): base(baseTile, x, y)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "F" + Number;
        }

        public override Image Draw()
        {
            return DrawOn("Flag" + Number);
        }

        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasRepair()
        {
            return true;
        }
    }
}
