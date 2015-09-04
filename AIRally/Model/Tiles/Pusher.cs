using AIRally.Model.Boards;
using System;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Pusher : TileDecorator
    {
        public bool[] Turns;

        public Pusher(Board board, Tile baseTile, bool[] turns, int x, int y) : base(board, baseTile, x, y)
        {
            if (turns.Length == 5)
            {
                Turns = turns;
            }
            else
            {
                throw new Exception("Pusher initialization error; Turns does not equal 5");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(BaseTile);
            result.Append('P');
            for (int i = 0; i < 5; i++)
            {
                if (Turns[i])
                {
                    result.Append(i);
                }
            }
            return result.ToString();
        }

        public override Image Paint()
        {
            return BaseTile.Paint();
        }

        public override bool HasPusher()
        {
            return true;
        }
    }
}