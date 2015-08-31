using System.Drawing;

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
            return DrawMe("PitGeneric");
        }

        public override bool IsPit()
        {
            return true;
        }
    }
}
