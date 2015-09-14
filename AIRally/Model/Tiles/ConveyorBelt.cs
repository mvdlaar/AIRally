using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ConveyorBelt : TileDecorator
    {
        public ConveyorBelt(Board board, Tile baseTile, TileDirection direction, TurnDirection turn, int x, int y)
            : base(board, baseTile, x, y)
        {
            Direction = direction;
            Turn = turn;
        }

        public TileDirection Direction { get; }
        public TurnDirection Turn { get; }

        public override Image Paint()
        {
            if (Direction != TileDirection.None)
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
            result.Append(TileDirectionUtil.GetChar(Direction));
            result.Append(TurnDirectionUtil.GetChar(Turn));
            return result.ToString();
        }

        public override void ActivateConveyorBelt(AI ai)
        {
            Board.MoveAIOnce(ai, Direction);
        }
    }
}