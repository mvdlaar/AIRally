using AIRally.Model.Boards;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public abstract class TileDecorator : Tile
    {
        protected Tile BaseTile = null;

        protected TileDecorator(Board board, Tile baseTile, int x, int y) : base(board, x, y)
        {
            BaseTile = baseTile;
        }

        protected Image PaintOn(string resourceName)
        {
            Image imageTile = BaseTile.Paint();
            Image image = PaintMe(resourceName);
            if (image != null)
            {
                Graphics g = Graphics.FromImage(imageTile);
                g.DrawImage(image, new Point(0, 0));
                g.Dispose();
            }
            return imageTile;
        }

        public override int HasLasers()
        {
            return BaseTile.HasLasers();
        }

        public override bool IsPit()
        {
            return BaseTile.IsPit();
        }

        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasRepair()
        {
            return BaseTile.HasRepair();
        }

        public override WallDirection[] HasWalls()
        {
            return BaseTile.HasWalls();
        }

        public override bool HasPusher()
        {
            return BaseTile.HasPusher();
        }
    }
}