using System.Drawing;
using System.IO;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public abstract class TileDecorator: Tile
    {
        protected Tile baseTile = null;

        protected TileDecorator(Tile baseTile)
        {
            this.baseTile = baseTile;
        }

        protected Image DrawOn(string resourceName)
        {
            Image imageTile = baseTile.Draw();
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
