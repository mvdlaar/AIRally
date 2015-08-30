using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace AIRally.Model.Tiles
{
    public abstract class TileDecorator: Tile
    {
        protected Tile BaseTile = null;

        protected TileDecorator(Tile baseTile, int x, int y): base(x, y)
        {
            this.BaseTile = baseTile;
        }

        protected Image DrawOn(string resourceName)
        {
            Image imageTile = BaseTile.Draw();
            Graphics g = Graphics.FromImage(imageTile);
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("AIRally.EMF." + resourceName + ".EMF");
            if (myStream != null)
            {
                Image image = new Bitmap(myStream);
                g.DrawImage(image, new Point(0, 0));
                image.Dispose();
                myStream.Dispose();
            }
            g.Dispose();
            return imageTile;
        }
    }
}
