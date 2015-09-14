using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class ExpressConveyorBelt : TileDecorator
    {
        public ExpressConveyorBelt(Board board, Tile baseTile, TileDirection direction, TurnDirection turn, int x,
            int y) : base(board, baseTile, x, y)
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
            result.Append(TileDirectionUtil.GetChar(Direction));
            result.Append(TurnDirectionUtil.GetChar(Turn));
            return result.ToString();
        }

        public override void ActivateExpressConveyorBelt(AI ai)
        {
            Board.MoveAIOnce(ai, Direction);
        }

        public override void ActivateConveyorBelt(AI ai)
        {
            Board.MoveAIOnce(ai, Direction);
        }
    }
}