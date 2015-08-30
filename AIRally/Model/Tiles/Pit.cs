using System.Drawing;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public class Pit: Tile
    {
        public Pit(int x, int y) : base(x, y)
        {
            
        }

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
