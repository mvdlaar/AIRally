using AIRally.Model.Decks;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace AIRally.Model
{
    public class AI
    {
        private bool isVirtual = false;
        private int lives = 3;
        private string location;

        public AI(int number)
        {
            Number = number;
            ProgramCards = new List<ProgramCard>();
            Direction = TileDirection.Left;
            Registers = new Registers();
        }

        public int Damage { get; } = 0;
        public bool Dead { get; private set; }
        public TileDirection Direction { get; set; }
        public string Name { get; }
        public int Number { get; }
        public List<ProgramCard> ProgramCards { get; }
        //private Registers registers;

        /// <summary>
        ///     Registers index runs from 1 through 5
        /// </summary>
        public Registers Registers { get; }

        public int X { get; set; }
        public int Y { get; set; }

        public Bitmap Paint()
        {
            Bitmap result = null;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF.Droid" + Number + ".EMF");
            if (myStream != null)
            {
                result = new Bitmap(myStream);
                myStream.Dispose();
            }
            return result;
        }

        internal void Die()
        {
            Dead = true;
        }

        internal void SelectCards()
        {
            for (var i = 0; i < 5; i++)
            {
                Registers[i] = ProgramCards[i];
            }
        }
    }
}