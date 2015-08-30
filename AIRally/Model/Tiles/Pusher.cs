using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AIRally.Model.Tiles
{
    public class Pusher : TileDecorator
    {
        public List<int> Turns { get; }

        public Pusher(Tile baseTile, List<int> turns) : base(baseTile)
        {
            this.Turns = turns;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(baseTile);
            result.Append('P');
            foreach (int turn in Turns)
            {
                result.Append(turn);
            }
            return result.ToString();
        }

        public override Image Draw()
        {
            return baseTile.Draw();
        }
    }
}
