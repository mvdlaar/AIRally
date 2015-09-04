using AIRally.Model.Boards;
using AIRally.Model.Decks;
using System;
using System.Drawing;

namespace AIRally.Model
{
    public class AIRally
    {
        private const int nCards = 9;

        public Board Board { get; }
        public AIList AIs { get; }

        private ProgramDeck programDeck;

        public AIRally(string boardLocation)
        {
            Board = new Board(this, boardLocation);
            programDeck = new ProgramDeck();
            AIs = new AIList();
        }

        public void Setup()
        {
            // Choose AI
            // Set Archive Marker
            // Set up Program Sheet
            // Give Life Tokens
            // Each AI gets 3 Life tokens
            // Shuffle decks
            // Shuffle Program Deck
            programDeck.Shuffle();
            // Determine First Player

            // Place AIs on Board
            // Part of AddAI
        }

        public void AddAI(string name, string location)
        {
            AIs.Add(Board, name, location);
        }

        public void ClearAIs()
        {
            AIs.Clear();
        }

        private void PlayTurn()
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

        private void DealCards()
        {
            for (var i = nCards - 1; i <= 0; i--)
            {
                foreach (AI ai in AIs)
                {
                    if (ai.Damage <= i)
                    {
                        ai.ProgramCards.Add(programDeck.Deal());
                    }
                }
            }
        }

        private void AskBotActions()
        {
        }

        private void CompleteRegisters()
        {
            var i = 1;

            while (i <= 5)
            {
                AIMove(i);
                BoardElementsMove();
                LasersFire();
                TouchCheckPoints();
                i++;
            }
        }

        private void AIMove(int register)
        {
            foreach (AI ai in AIs)
            {
            }
        }

        private void BoardElementsMove()
        {
        }

        private void LasersFire()
        {
        }

        private void TouchCheckPoints()
        {
        }

        private void Cleanup()
        {
        }

        public Image PaintBoard(int width, int height)
        {
            return Board.Paint(width, height);
        }
    }
}