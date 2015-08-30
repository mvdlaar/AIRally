using System.Collections;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Gear: TileDecorator
    {
        public GearDirection Direction { get; }

        public Gear(Tile baseTile, GearDirection direction): base(baseTile)
        {
            this.Direction = direction;
        }

        public override string ToString()
        {
            if (Direction == GearDirection.Right)
            {
                return baseTile + "GR";
            }
            else
            {
                return baseTile + "GL";
            }
        }

        public override Image Draw()
        {
            switch (Direction)
            {
                case GearDirection.Right:
                    return DrawOn("GearRight");
                    break;
                case GearDirection.Left:
                    return DrawOn("GearLeft");
                    break;
            }
            return baseTile.Draw();
        }
    }
}
