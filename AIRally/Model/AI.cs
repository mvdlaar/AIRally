using AIInterface;
using AIRally.Model.Decks;
using AIRally.Model.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace AIRally.Model
{
    public class AI
    {
        public AI(int number, Board board, string name, string location)
        {
            Number = number;
            Name = name;
            this.location = location;
            this.board = board;
            ProgramCards = new List<ProgramCard>();
            Direction = TileDirection.Left;
            Registers = new Registers();
            Type AIType = LoadAI();
            if (AIType != null)
            {
                PlugInAI = (IAI)Activator.CreateInstance(AIType);
                Loaded = true;
            }
        }

        public int Damage { get; private set; }
        public bool Dead { get; private set; }
        public TileDirection Direction { get; set; }
        public int LastFlag { get; private set; }
        public bool Loaded { get; }
        public string Name { get; }
        public int Number { get; }
        public IAI PlugInAI { get; }
        public List<ProgramCard> ProgramCards { get; }

        /// <summary>
        ///     Registers index runs from 1 through 5
        /// </summary>
        public Registers Registers { get; }

        //private Registers registers;
        public int X { get; set; }

        public int Y { get; set; }

        public Bitmap Paint()
        {
            Bitmap result = null;
            if (!Dead)
            {
                var myAssembly = Assembly.GetExecutingAssembly();
                var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF.Droid" + Number + ".EMF");
                if (myStream != null)
                {
                    result = new Bitmap(myStream);
                    myStream.Dispose();
                }
            }
            return result;
        }

        public void Turn(TurnDirection turn)
        {
            switch (turn)
            {
                case TurnDirection.Left:
                    Direction = TileDirectionUtil.TurnLeft(Direction);
                    break;

                case TurnDirection.Right:
                    Direction = TileDirectionUtil.TurnRight(Direction);
                    break;
            }
        }

        internal void AskAction(Board board)
        {
            var cardOrder = PlugInAI.PlayCards(board.ToString(), GetProgramCards());
            var i = 0;
            while (i < 5 && i < cardOrder.Length)
            {
                Registers[i] = ProgramCards[cardOrder[i]];
                i++;
            }
        }

        internal void CleanUp()
        {
            if (board[X, Y].HasRepair())
            {
                Repair();
            }
            if (Dead && (lives > 0))
            {
                Dead = false;
                var xy = NearestAvailable(archiveX, archiveY);
                X = xy.X;
                Y = xy.Y;
                Damage = 2;
                Direction = TileDirection.Left;
            }
            Registers.Wipe();
            ProgramCards.Clear();
        }

        internal void Die()
        {
            Dead = true;
            lives--;
        }

        internal void GetDamage()
        {
            if (!Dead)
            {
                if (Damage < 9)
                {
                    Damage++;
                }
            }
            else
            {
                Die();
            }
        }

        internal void SetArchive()
        {
            archiveX = X;
            archiveY = Y;
        }

        internal void SetLastFlag(int flag)
        {
            LastFlag = flag;
        }

        private readonly Board board;
        private int archiveX;
        private int archiveY;
        private int lives = 3;
        private string location;

        private string[] GetProgramCards()
        {
            string[] result = new string[ProgramCards.Count];
            var i = 0;
            while (i < result.Length)
            {
                result[i] = ProgramCards[i].ToString();
                i++;
            }
            return result;
        }

        private Type LoadAI()
        {
            Type result = null;

            try
            {
                Assembly ass = null;
                ass = Assembly.LoadFile(location);
                if (ass != null)
                {
                    Type[] types = ass.GetTypes();
                    var i = 0;
                    while (i < types.Length && !types[i].GetInterfaces().Contains(typeof(IAI)))
                    {
                        i++;
                    }
                    if (types[i].GetInterfaces().Contains(typeof(IAI)))
                    {
                        result = types[i];
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        private Point NearestAvailable(int startX, int startY)
        {
            var x = startX;
            var y = startY;
            if (board[x, y].HasAI() != null || board[x, y].IsPit())
            {
                var step = 1;

                while (board[x, y].HasAI() != null || board[x, y].IsPit())
                {
                    if (startX - step > 0)
                    {
                        x = startX - step;
                    }
                    else
                    {
                        x = startX;
                    }
                    while (x <= startX + step && x < board.Width && (board[x, y].HasAI() != null || board[x, y].IsPit()))
                    {
                        if (startY - step > 0)
                        {
                            y = startY - step;
                        }
                        else
                        {
                            y = startY;
                        }
                        while (y <= startY + step && y < board.Height && (board[x, y].HasAI() != null || board[x, y].IsPit()))
                        {
                            y += step;
                        }
                        x += step;
                    }
                    step++;
                }
            }

            return new Point(x, y);
        }

        private void Repair()
        {
            if (Damage > 0)
            {
                Damage--;
            }
        }
    }
}