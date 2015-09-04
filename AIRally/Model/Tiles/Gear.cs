using AIRally.Model.Boards;
using System.Collections;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Gear : TileDecorator
    {
        public TurnDirection Turn { get; }

        public Gear(Board board, Tile baseTile, TurnDirection direction, int x, int y) : base(board, baseTile, x, y)
        {
            Turn = direction;
        }

        private string Postfix(string prefix)
        {
            StringBuilder result = new StringBuilder(prefix);
            result.Append(GetTurnDirectionChar(Turn));
            return result.ToString();
        }

        public override string ToString()
        {
            return BaseTile + Postfix("G");
        }

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
    }
}