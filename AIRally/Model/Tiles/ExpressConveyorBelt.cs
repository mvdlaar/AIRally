using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ExpressConveyorBelt : TileDecorator
    {
        public ExpressConveyorBelt(Board board, Tile baseTile, ConveyorDirection direction, TurnDirection turn, int x,
            int y) : base(board, baseTile, x, y)
        {
            Direction = direction;
            Turn = turn;
        }

        public ConveyorDirection Direction { get; }
        public TurnDirection Turn { get; }

        public override Image Paint()
        {
            if (Direction != ConveyorDirection.None)
            {
                return PaintOn(Postfix("EBelt"));
            }
            return BaseTile.Paint();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("E");
        }

        private string Postfix(string prefix)
        {
            var result = new StringBuilder(prefix);
            result.Append(GetConveyorDirectionChar(Direction));
            result.Append(GetTurnDirectionChar(Turn));
            return result.ToString();
        }
    }
}