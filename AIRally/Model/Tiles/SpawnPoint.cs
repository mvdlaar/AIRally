using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class SpawnPoint : TileDecorator
    {
        public int Number { get; }

        public SpawnPoint(Tile baseTile, int number, int x, int y) : base(baseTile, x, y)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "S" + Number;
        }

        public override Image Draw()
        {
            return DrawOn("Spawn" + Number);
        }

        public override int HasSpawnPoint()
        {
            return Number;
        }
    }
}
