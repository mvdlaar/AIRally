using AIRally.Model.Boards;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Gear : TileDecorator
    {
        public Gear(Board board, Tile baseTile, TurnDirection direction, int x, int y) : base(board, baseTile, x, y)
        {
            Turn = direction;
        }

        public TurnDirection Turn { get; }

        public override Image Paint()
        {
            switch (Turn)
            {
                case TurnDirection.Right:
                    return PaintOn("GearRight");

                case TurnDirection.Left:
                    return PaintOn("GearLeft");
            }
            return BaseTile.Paint();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("G");
        }

        private string Postfix(string prefix)
        {
            var result = new StringBuilder(prefix);
            result.Append(GetTurnDirectionChar(Turn));
            return result.ToString();
        }
    }
}