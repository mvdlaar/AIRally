using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class SpawnPoint : TileDecorator
    {
        public SpawnPoint(Board board, Tile baseTile, int number, int x, int y) : base(board, baseTile, x, y)
        {
            Number = number;
        }

        public int Number { get; }

        public override int HasSpawnPoint()
        {
            return Number;
        }

        public override Image Paint()
        {
            return PaintOn("Spawn" + Number);
        }

        public override string ToString()
        {
            return BaseTile + "S" + Number;
        }
    }
}