using AIRally.Model.Boards;
using System.Collections.Generic;

namespace AIRally.Model
{
    public class AIList : IEnumerable<AI>
    {
        private List<AI> aiList;

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
                int i = 0;
                while (i < aiList.Count && aiList[i].X != x && aiList[i].Y != y)
                {
                    i++;
                }
                if (i < aiList.Count)
                {
                    return this[i];
                }
                else
                {
                    return null;
                }
            }
        }

        public AI Add(Board board, string name, string location)
        {
            var ai = new AI(aiList.Count + 1);
            aiList.Add(ai);
            ai.X = board.SpawnPoints[ai.Number - 1].X;
            ai.Y = board.SpawnPoints[ai.Number - 1].Y;
            return ai;
        }

        public void Clear()
        {
            aiList.Clear();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<AI> GetEnumerator()
        {
            return aiList.GetEnumerator();
        }
    }
}