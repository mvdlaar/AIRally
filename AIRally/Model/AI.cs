using AIRally.Model.Decks;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace AIRally.Model
{
    public class AI
    {
        public string Name { get; }

        private string location;

        private int damage = 0;

        public int Damage
        {
            get { return damage; }
        }

        public int Number { get; }

        private int lives = 3;
        public int X { get; set; }
        public int Y { get; set; }
        public List<ProgramCard> ProgramCards { get; }

        /// <summary>
        /// Registers index runs from 1 through 5
        /// </summary>
        public Registers Registers { get; }

        private bool isVirtual = false;

        public AI(int number)
        {
            Number = number;
            ProgramCards = new List<ProgramCard>();
        }

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
    }
}