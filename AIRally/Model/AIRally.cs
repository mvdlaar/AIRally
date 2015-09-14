using System;
using AIRally.Model.Decks;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace AIRally.Model
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class AIRally
    {
        private const int MaxCards = 9;
        private readonly ProgramDeck programDeck;
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
        

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

        public void PlayGame()
        {
            while (!finished)
            {
                PlayTurn();
                OnChanged(EventArgs.Empty);
                Thread.Sleep(5000);
            }
        }

        public void PlayTurn()
        {
            // Deal Program Cards
            DealCards();

            // Program Registers
            // Future: Announce Power Down for NEXT turn
            AskBotActions();

            // Complete each register in order:
            // Execute Program Cards
            // Complete board movements
            // Resolve interactions
            // Touch Flag and Repair sites
            CompleteRegisters();

            // Clean up
            Cleanup();

            // Check if any AIs still in the game
            finished = finished || AIs.Count(x=>!x.Dead) == 0;
        }

        private void AskBotActions()
        {
            foreach (var ai in AIs)
            {
                ai.AskAction(Board);
            }
        }

        private void BoardElementsMove(int turn)
        {
            // Express conveyor belts move 1 tile
            foreach (var ai in AIs)
            {
                Board[ai.X,ai.Y].ActivateExpressConveyorBelt(ai);
            }

            // Express and regular conveyor belts move 1 tile

            foreach (var ai in AIs)
            {
                Board[ai.X, ai.Y].ActivateConveyorBelt(ai);
            }

            // Pushers push if active
            foreach (var ai in AIs)
            {
                Board[ai.X, ai.Y].ActivatePusher(ai, turn);
            }
            
            // Gears move
            foreach (var ai in AIs)
            {
                Board[ai.X, ai.Y].ActivateGear(ai);
            }
        }

        private void Cleanup()
        {
            foreach (var ai in AIs)
            {
                ai.CleanUp();
            }
        }

        private void CompleteRegisters()
        {
            var i = 1;

            while (i <= 5 && winner == null)
            {
                // A. Reveal Program Cards
                // and
                // B. Robots Move
                ExecuteRegisters(i);
                // C. Board Elements Move
                BoardElementsMove(i);
                // D. Lasers Fire
                LasersFire();
                // E. Touch Checkpoints
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
                    if (!ai.Dead && ai.Damage <= i)
                    {
                        ai.ProgramCards.Add(programDeck.Deal());
                    }
                }
            }
        }

        private void ExecuteRegisters(int register)
        {
            var list = AIs.Where(x=>!x.Dead).OrderByDescending(x => x.ProgramCards[register].Priority).ToList();
            foreach (var ai in list)
            {
                if (!ai.Dead)
                {
                    Board.ExecuteProgramCard(ai, ai.ProgramCards[register]);
                }
            }
        }

        private void LasersFire()
        {
            //TODO
        }

        private void TouchCheckPoints()
        {
            foreach (var ai in AIs)
            {
                if (Board[ai.X, ai.Y].HasRepair())
                {
                    ai.SetArchive();
                }
                if (Board[ai.X, ai.Y].HasFlag() != 0)
                {
                    int flag = Board[ai.X, ai.Y].HasFlag();
                    if (flag == ai.LastFlag + 1)
                    {
                        ai.SetLastFlag(flag);
                        if (flag == Board.Flags.Count)
                        {
                            SetWinner(ai);
                        }
                    }
                }
            }
        }

        private AI winner;
        public AI Winner { get { return winner;} }

        private bool finished = false;

        private void SetWinner(AI ai)
        {
            winner = ai;
            finished = true;
        }
    }
}