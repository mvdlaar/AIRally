using System.Collections;
using System.Collections.Generic;

namespace AIRally.Model
{
    public class AIList : IEnumerable<AI>
    {
        private readonly List<AI> aiList;

        public AIList()
        {
            aiList = new List<AI>();
        }

        public AI this[int index]
        {
            get { return aiList[index]; }
        }

        public AI this[int x, int y]
        {
            get
            {
                var i = 0;
                while (i < aiList.Count && !(aiList[i].X == x && aiList[i].Y == y))
                {
                    i++;
                }
                if (i < aiList.Count)
                {
                    return this[i];
                }
                return null;
            }
        }

        public IEnumerator<AI> GetEnumerator()
        {
            return aiList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public AI Add(Board board, string name, string location)
        {
            var ai = new AI(aiList.Count + 1, board, name, location);
            ai.X = board.SpawnPoints[ai.Number - 1].X;
            ai.Y = board.SpawnPoints[ai.Number - 1].Y;
            ai.SetArchive();
            aiList.Add(ai);
            return ai;
        }

        public void Clear()
        {
            aiList.Clear();
        }
    }
}