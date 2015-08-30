using System.Drawing;
using System.Reflection;
using System.IO;

namespace AIRally.Model.Tiles
{
    public class Floor : Tile
    {
        public Floor(int x, int y) : base(x, y)
        {
            
        }

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

        public override int HasSpawnPoint()
        {
            return 0;
        }

        public override bool HasRepair()
        {
            return false;
        }
    }
}
