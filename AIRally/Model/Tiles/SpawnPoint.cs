using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class SpawnPoint : TileDecorator
    {
        public int Number { get; }

        public SpawnPoint(Board board, Tile baseTile, int number, int x, int y) : base(board, baseTile, x, y)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return BaseTile + "S" + Number;
        }

        public override Image Paint()
        {
            return PaintOn("Spawn" + Number);
        }

        public override int HasSpawnPoint()
        {
            return Number;
        }
    }
}