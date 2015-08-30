using System.Drawing;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public class Pit: Tile
    {
        public override string ToString()
        {
            return "P";
        }

        public override Image Draw()
        {
            Image result = null;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF.PitGeneric.EMF");
            if (myStream != null)
            {
                result = new Bitmap(myStream);
                myStream.Dispose();
            }
            return result;
        }
    }
}
