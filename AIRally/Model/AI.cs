using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using AIRally.Model.Decks;

namespace AIRally.Model
{
    public class AI
    {
        private int damage = 0;
        public int Damage
        {
            get { return damage; }
        }

        public int Number { get; }

        private int lives = 3;
        public int X { get; set; }
        public int Y { get; set; }
        private List<ProgramCard> programCards;
        private ProgramCard register1;
        private ProgramCard register2;
        private ProgramCard register3;
        private ProgramCard register4;
        private ProgramCard register5;
        private bool isVirtual = false;

        public AI(int number)
        {
            Number = number;
        }

        public ProgramCard Register1
        {
            get { return register1; }
        }

        public ProgramCard Register2
        {
            get { return register2; }
        }

        public ProgramCard Register3
        {
            get { return register3; }
        }

        public ProgramCard Register4
        {
            get { return register4; }
        }

        public ProgramCard Register5
        {
            get { return register5; }
        }

        public Image Draw()
        {
            Image result = null;
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
