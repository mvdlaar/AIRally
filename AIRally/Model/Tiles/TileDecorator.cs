using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace AIRally.Model.Tiles
{
    public abstract class TileDecorator : Tile
    {
        protected Tile BaseTile;

        protected TileDecorator(Board board, Tile baseTile, int x, int y) : base(board, x, y)
        {
            BaseTile = baseTile;
        }

        public override int HasFlag()
        {
            return BaseTile.HasFlag();
        }

        public override int HasLasers()
        {
            return BaseTile.HasLasers();
        }

        public override Pusher HasPusher()
        {
            return BaseTile.HasPusher();
        }

        public override bool HasRepair()
        {
            return BaseTile.HasRepair();
        }

        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasWall(TileDirection direction)
        {
            return BaseTile.HasWall(direction);
        }

        public override TileDirection[] HasWalls()
        {
            return BaseTile.HasWalls();
        }

        public override bool IsPit()
        {
            return BaseTile.IsPit();
        }

        protected Image PaintOn(string resourceName)
        {
            var imageTile = BaseTile.Paint();
            var image = PaintMe(resourceName);
            if (image != null)
            {
                var g = Graphics.FromImage(imageTile);
                g.DrawImage(image, new Point(0, 0));
                g.Dispose();
            }
            return imageTile;
        }

        public override TurnDirection HasGear()
        {
            return BaseTile.HasGear();
        }

        public override void ActivateExpressConveyorBelt(AI ai)
        {
            BaseTile.ActivateConveyorBelt(ai);
        }

        public override void ActivateConveyorBelt(AI ai)
        {
            BaseTile.ActivateConveyorBelt(ai);
        }

        public override void ActivatePusher(AI ai, int turn)
        {
            BaseTile.ActivatePusher(ai, turn);
        }

        public override void ActivateGear(AI ai)
        {
            BaseTile.ActivateGear(ai);
        }
    }
}