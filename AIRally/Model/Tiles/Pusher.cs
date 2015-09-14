using System;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Pusher : TileDecorator
    {
        public bool[] ActiveTurns { get; }
        public TileDirection Direction { get; }
    

        public Pusher(Board board, Tile baseTile, TileDirection direction, bool[] activeTurns, int x, int y) : base(board, baseTile, x, y)
        {
            if (activeTurns.Length == 5)
            {
                Direction = direction;
                ActiveTurns = activeTurns;
            }
            else
            {
                throw new Exception("Pusher initialization error; Length of ActiveTurns does not equal 5");
            }
        }

        public override Pusher HasPusher()
        {
            return this;
        }

        public override Image Paint()
        {
            return BaseTile.Paint();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(BaseTile);
            result.Append('P');
            for (var i = 0; i < 5; i++)
            {
                if (ActiveTurns[i])
                {
                    result.Append(i);
                }
            }
            return result.ToString();
        }

        public override void ActivatePusher(AI ai, int turn)
        {
            if (ActiveTurns[turn])
            {
                Board.MoveAIOnce(ai, Direction);
            }
        }
    }
}