using System.Drawing;
using System.Reflection;
using System.IO;

namespace AIRally.Model.Tiles
{
    public class Floor : Tile
    {
        public override Image Draw()
        {
            Image result = null;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF.EmptyTile.EMF");
            if (myStream != null)
            {
                result = new Bitmap(myStream);
                myStream.Dispose();
            }
            return result;
        }

        public override string ToString()
        {
            return "F";
        }
    }
}
