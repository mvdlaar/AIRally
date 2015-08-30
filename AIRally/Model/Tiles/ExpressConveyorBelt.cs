using System.Collections;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ExpressConveyorBelt : TileDecorator
    {
        public ConveyorDirection Direction { get; }
        public TurnDirection Turn { get; }

        public ExpressConveyorBelt(Tile baseTile, ConveyorDirection direction, TurnDirection turn, int x, int y) : base(baseTile, x, y)
        {
            this.Direction = direction;
            this.Turn = turn;
        }

        private string Postfix(string Prefix)
        {
            StringBuilder result = new StringBuilder(Prefix);
            switch (Direction)
            {
                case ConveyorDirection.Up:
                    result.Append('U');
                    break;
                case ConveyorDirection.Right:
                    result.Append('R');
                    break;
                case ConveyorDirection.Down:
                    result.Append('D');
                    break;
                case ConveyorDirection.Left:
                    result.Append('L');
                    break;
            }

            switch (Turn)
            {
                case TurnDirection.None:
                    result.Append('N');
                    break;
                case TurnDirection.Left:
                    result.Append('L');
                    break;
                case TurnDirection.Right:
                    result.Append('R');
                    break;
                case TurnDirection.Both:
                    result.Append('B');
                    break;
            }
            return result.ToString();
        }
        public override string ToString()
        {
            return BaseTile + Postfix("E");
        }

        public override Image Draw()
        {
            return DrawOn(Postfix("EBelt"));
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
