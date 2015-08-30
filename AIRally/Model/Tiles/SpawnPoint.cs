using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class SpawnPoint : TileDecorator
    {
        public int Number { get; }

        public SpawnPoint(Tile baseTile, int number): base(baseTile)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return baseTile + "S" + Number;
        }

        public override Image Draw()
        {
            return DrawOn("Spawn" + Number);
        }
    }
}
