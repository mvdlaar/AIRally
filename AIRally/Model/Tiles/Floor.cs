using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Floor : Tile
    {
        public Floor(int x, int y) : base(x, y)
        {
            
        }

        public override Image Draw()
        {
            return DrawMe("Floor");
        }

        public override string ToString()
        {
            return "F";
        }
    }
}
