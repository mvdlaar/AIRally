using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ConveyorBelt: TileDecorator
    {
        public ConveyorDirection Direction { get; }
        public ConveyorTurn Turn { get; }

        public ConveyorBelt(Tile baseTile, ConveyorDirection direction, ConveyorTurn turn) : base(baseTile)
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
                case ConveyorTurn.None:
                    result.Append('N');
                    break;
                case ConveyorTurn.Left:
                    result.Append('L');
                    break;
                case ConveyorTurn.Right:
                    result.Append('R');
                    break;
                case ConveyorTurn.Both:
                    result.Append('B');
                    break;
            }
            return result.ToString();
        }

        public override string ToString()
        {
            return baseTile + Postfix("C");
        }

        public override Image Draw()
        {
            return DrawOn(Postfix("CBelt"));
        }
    }
}
