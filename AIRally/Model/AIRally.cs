using System.Collections.Generic;
using AIRally.Model.Boards;
using AIRally.Model.Decks;
using AIRally.Model.Tiles;

namespace AIRally.Model
{
    public class AIRally
    {
        private string boardLocation;
        public  Board Board { get; }
        private List<AI> ais;
        private ProgramDeck programDeck;

        public AIRally(string boardLocation)
        {
            this.boardLocation = boardLocation;
            Board = new Board(boardLocation);
            programDeck = new ProgramDeck();

            Setup();
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
            int i = 0;
            while (i < ais.Count)
            {
                ais[i].X = Board.SpawnPoints[i].X;
                ais[i].Y = Board.SpawnPoints[i].Y;
                i++;
            }
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
