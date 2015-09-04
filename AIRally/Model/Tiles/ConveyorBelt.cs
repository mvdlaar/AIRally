using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ConveyorBelt : TileDecorator
    {
        public ConveyorDirection Direction { get; }
        public TurnDirection Turn { get; }

        public ConveyorBelt(Board board, Tile baseTile, ConveyorDirection direction, TurnDirection turn, int x, int y) : base(board, baseTile, x, y)
        {
            this.Direction = direction;
            this.Turn = turn;
        }

        private string Postfix(string prefix)
        {
            StringBuilder result = new StringBuilder(prefix);
            result.Append(GetConveyorDirectionChar(Direction));
            result.Append(GetTurnDirectionChar(Turn));
            return result.ToString();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("C");
        }

        public override Image Paint()
        {
            if (Direction != ConveyorDirection.None)
            {
                return PaintOn(Postfix("CBelt"));
            }
            else
            {
                return BaseTile.Paint();
            }
        }
    }
}