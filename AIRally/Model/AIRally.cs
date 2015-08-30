using System.Collections.Generic;
using AIRally.Model.Boards;

namespace AIRally.Model
{
    public class AIRally
    {
        private string boardLocation;
        public  Board Board { get; }
        private List<AI> ais;

        public AIRally(string boardLocation)
        {
            this.boardLocation = boardLocation;
            Board = new Board(boardLocation);
        }

        void Setup()
        {
            // Choose AI
                // Set Archive Marker
                // Set up Program Sheet
            // Give Life Tokens
                // Each AI gets 3 Life tokens
            // Shuffle decks
                // Shuffle Program Deck
            // Determine First Player
                // First AI on Dock 1
                // Second AI on Dock 2
                // Third AI on Dock 3
                // Fourth AI on Dock 4
                // Fifth AI on Dock 5
                // Sixth AI on Dock 6
                // Seventh AI on Dock 7
                // Eight AI on Dock 8
        }


        void PlayTurn()
        {
            // Deal Program Cards
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

        }

        private void CompleteRegisters()
        {
            int i = 1;

            while (i <= 5)
            {
                RevealProgramCards(i);
                AIMove(i);
                BoardElementsMove();
                LasersFire();
                TouchCheckPoints();
                i++;
            }
        }

        private void RevealProgramCards(int register)
        {
            
        }

        private void AIMove(int register)
        {
            
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

    }
}
