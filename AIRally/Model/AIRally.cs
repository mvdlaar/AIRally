using AIRally.Model.Boards;
using AIRally.Model.Decks;
using System.Drawing;
using System.Linq;

namespace AIRally.Model
{
    public class AIRally
    {
        private const int MaxCards = 9;
        private readonly ProgramDeck programDeck;

        public AIRally(string boardLocation)
        {
            Board = new Board(this, boardLocation);
            programDeck = new ProgramDeck();
            AIs = new AIList();
        }

        public AIList AIs { get; }
        public Board Board { get; }

        public void AddAI(string name, string location)
        {
            AIs.Add(Board, name, location);
        }

        public void ClearAIs()
        {
            AIs.Clear();
        }

        public Image PaintBoard(int width, int height)
        {
            return Board.Paint(width, height);
        }

        public void PlayTurn()
        {
            // Deal Program Cards
            DealCards();

            // Program Registers
            // Announce Power Down for NEXT turn
            AskBotActions();

            // Complete each register in order:
            // Execute Program Cards
            // Complete board movements
            // Resolve interactions
            // Touch Flag and Repair sites
            CompleteRegisters();

            // Clean up
            Cleanup();
        }

        private void AskBotActions()
        {
            foreach (var ai in AIs)
            {
                ai.SelectCards();
            }
        }

        private void BoardElementsMove()
        {
        }

        private void Cleanup()
        {
        }

        private void CompleteRegisters()
        {
            var i = 1;

            while (i <= 5)
            {
                ExecuteRegisters(i);
                BoardElementsMove();
                LasersFire();
                TouchCheckPoints();
                i++;
            }
        }

        private void DealCards()
        {
            programDeck.Shuffle();
            for (var i = MaxCards - 1; i >= 0; i--)
            {
                foreach (var ai in AIs)
                {
                    if (ai.Damage <= i)
                    {
                        ai.ProgramCards.Add(programDeck.Deal());
                    }
                }
            }
        }

        private void ExecuteRegisters(int register)
        {
            var list = AIs.OrderByDescending(x => x.ProgramCards[register].Priority).ToList();
            foreach (var ai in list)
            {
                Board.ExecuteProgramCard(ai, ai.ProgramCards[register]);
            }
        }

        private void LasersFire()
        {
        }

        private void TouchCheckPoints()
        {
        }
    }
}