using AIRally.Model.Decks;

namespace AIRally.Model
{
    public class Registers
    {
        private readonly ProgramCard[] registers;

        public Registers()
        {
            registers = new ProgramCard[5];
            for (var i = 0; i < registers.Length - 1; i++)
            {
                registers[i] = null;
            }
        }

        public ProgramCard this[int index]
        {
            get
            {
                if (index >= 1 && index <= 5)
                {
                    return registers[index - 1];
                }
                return null;
            }
            set
            {
                if (index >= 1 && index <= 5)
                {
                    registers[index - 1] = value;
                }
            }
        }
    }
}