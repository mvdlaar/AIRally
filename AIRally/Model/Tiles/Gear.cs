using System.Collections;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public class Gear: TileDecorator
    {
        public TurnDirection Direction { get; }

        public Gear(Tile baseTile, TurnDirection direction, int x, int y) : base(baseTile, x, y)
        {
            this.Direction = direction;
        }

        public override string ToString()
        {
            if (Direction == TurnDirection.Right)
            {
                return BaseTile + "GR";
            }
            else
            {
                return BaseTile + "GL";
            }
        }

        public override Image Draw()
        {
            switch (Direction)
            {
                case TurnDirection.Right:
                    return DrawOn("GearRight");
                    break;
                case TurnDirection.Left:
                    return DrawOn("GearLeft");
                    break;
            }
            return BaseTile.Draw();
        }
        public override int HasSpawnPoint()
        {
            return BaseTile.HasSpawnPoint();
        }

        public override bool HasRepair()
        {
            return BaseTile.HasRepair();
        }
    }
}
