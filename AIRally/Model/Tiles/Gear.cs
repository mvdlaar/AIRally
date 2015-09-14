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
            result.Append(TurnDirectionUtil.GetChar(Turn));
            return result.ToString();
        }

        public override TurnDirection HasGear()
        {
            return Turn;
        }

        public override void ActivateGear(AI ai)
        {
            ai.Turn(Turn);
        }
    }
}