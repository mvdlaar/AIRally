using AIRally.Model.Decks;
using System;

namespace AIRally.Model
{
    public class Registers
    {
        public Registers()
        {
            registers = new ProgramCard[5];
            for (var i = 1; i <= 5; i++)
            {
                this[i] = null;
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
                if (index >= 1 && index <= 5 && (value == null || Array.IndexOf(registers, value) == -1))
                {
                    registers[index - 1] = value;
                }
            }
        }

        public void Wipe()
        {
            for (var i = 1; i <= 5; i++)
            {
                if (this[i] != null && !this[i].Blocked)
                {
                    this[i] = null;
                }
            }
        }

        private readonly ProgramCard[] registers;
    }
}