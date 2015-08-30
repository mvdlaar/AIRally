using System;
using System.Collections.Generic;

namespace AIRally.Model.Decks
{
    class ProgramDeck
    {
        private readonly List<ProgramCard> programCards = new List<ProgramCard>();
        private readonly List<ProgramCard> drawpile = new List<ProgramCard>();
        private static readonly Random Rng = new Random();

        public ProgramDeck()
        {
            InitDeck();
            Shuffle();
        }

        public void InitDeck()
        {
            for (var i = 1; i <= 84; i++)
            {
                ProgramCardAction pca;
                if (i <= 6)
                {
                    pca = ProgramCardAction.UTurn;
                }
                else
                {
                    if (i <= 42)
                    {
                        if (i % 2 != 0)
                        {
                            pca = ProgramCardAction.RotateLeft;
                        }
                        else
                        {
                            pca = ProgramCardAction.RotateRight;
                        }
                    }
                    else
                    {
                        if (i <= 48)
                        {
                            pca = ProgramCardAction.BackUp;
                        }
                        else
                        {
                            if (i <= 66)
                            {
                                pca = ProgramCardAction.Move1;
                            }
                            else
                            {
                                if (i <= 78)
                                {
                                    pca = ProgramCardAction.Move2;
                                }
                                else
                                {
                                    pca = ProgramCardAction.Move3;
                                }
                            }
                        }
                    }
                }
                programCards.Add(new ProgramCard(pca, i * 10));
            }
        }

        public void Shuffle()
        {
            drawpile.Clear();

            foreach (var p in programCards)
            {
                if (!p.Blocked)
                {
                    drawpile.Add(p);
                }
            }

            var n = drawpile.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var helperCard = drawpile[k];
                drawpile[k] = drawpile[n];
                drawpile[n] = helperCard;
            }
        }
        public void BlockCard(ProgramCard blockCard)
        {
            blockCard.Blocked = true;
        }

        public void UnblockCard(ProgramCard blockCard)
        {
            blockCard.Blocked = false;
        }

        public ProgramCard Deal()
        {
            var dealCard = drawpile[0];
            drawpile.RemoveAt(0);
            return dealCard;
        }
    }
}
