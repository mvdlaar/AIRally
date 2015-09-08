using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ConveyorBelt : TileDecorator
    {
        public ConveyorBelt(Board board, Tile baseTile, ConveyorDirection direction, TurnDirection turn, int x, int y)
            : base(board, baseTile, x, y)
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
                return PaintOn(Postfix("CBelt"));
            }
            return BaseTile.Paint();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("C");
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