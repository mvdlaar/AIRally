using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace AIRally.Model.Tiles
{
    public abstract class Tile
    {
        protected Tile(Board board, int x, int y)
        {
            X = x;
            Y = y;
            Board = board;
        }

        public Board Board { get; }
        public int X { get; }
        public int Y { get; }

        public static Tile MakeTile(Board board, string tileString, int x, int y)
        {
            Tile result;

            // the first character is the Concrete Tile
            switch (tileString[0])
            {
                case 'F':
                    result = new Floor(board, x, y);
                    break;

                case 'P':
                    result = new Pit(board, x, y);
                    break;

                default:
                    return null;
            }

            //All following characters are Decorator Tiles
            var i = 1;
            while (i < tileString.Length)
            {
                int number;
                var turnString = "12345";
                switch (tileString[i])
                {
                    case 'C': // Conveyor Belt
                        result = new ConveyorBelt(board, result, TileDirectionUtil.Get(tileString[++i]),
                            TurnDirectionUtil.Get(tileString[++i]), x, y);
                        break;

                    case 'E': // Express Conveyor Belt
                        result = new ExpressConveyorBelt(board, result, TileDirectionUtil.Get(tileString[++i]),
                            TurnDirectionUtil.Get(tileString[++i]), x, y);
                        break;

                    case 'F': // Flag
                        number = Convert.ToInt32(tileString[++i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new Flag(board, result, number, x, y);
                        }
                        break;

                    case 'G': // Gear
                        result = new Gear(board, result, TurnDirectionUtil.Get(tileString[++i]), x, y);
                        break;

                    case 'L': // Laser
                        number = Convert.ToInt32(tileString[++i].ToString());
                        if (number >= 1 && number <= 3)
                        {
                            result = new Laser(board, result, number, x, y);
                        }
                        break;

                    case 'P': // Pusher
                        var turns = new bool[5];
                        var direction = TileDirectionUtil.Get(tileString[++i]);
                        while (i < tileString.Length - 1 && turnString.Contains(tileString[i + 1].ToString()))
                        {
                            turns[Convert.ToInt32(tileString[++i].ToString()) - 1] = true;
                        }
                        result = new Pusher(board, result, direction, turns, x, y);
                        break;

                    case 'R': // Repair
                        result = new Repair(board, result, x, y);
                        break;

                    case 'S': // Spawnpoint
                        number = Convert.ToInt32(tileString[++i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new SpawnPoint(board, result, number, x, y);
                        }
                        break;

                    case 'W': // Wall
                        result = new Wall(board, result, TileDirectionUtil.Get(tileString[++i]), x, y);
                        break;
                }
                i++;
            }
            return result;
        }

        public virtual int HasFlag()
        {
            return 0;
        }

        public virtual AI HasAI()
        {
            return Board.aiRally.AIs[X, Y];
        }

        public virtual int HasLasers()
        {
            return 0;
        }

        public virtual Pusher HasPusher()
        {
            return null;
        }

        public virtual bool HasRepair()
        {
            return false;
        }

        public virtual int HasSpawnPoint()
        {
            return 0;
        }

        public virtual bool HasWall(TileDirection direction)
        {
            return false;
        }

        public virtual TurnDirection HasGear()
        {
            return TurnDirection.None;
        }

        public virtual TileDirection[] HasWalls()
        {
            return new TileDirection[0];
        }

        public virtual bool IsPit()
        {
            return false;
        }

        public abstract Image Paint();

        public abstract override string ToString();

        protected Image PaintMe(string resourceName)
        {
            Image result = null;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF." + resourceName + ".EMF");
            if (myStream != null)
            {
                result = new Bitmap(myStream);
                myStream.Dispose();
            }
            return result;
        }

        public virtual void ActivateExpressConveyorBelt(AI ai)
        {
            // Do nothing
        }

        public virtual void ActivateConveyorBelt(AI ai)
        {
            // Do nothing
        }

        public virtual void ActivatePusher(AI ai, int turn)
        {
            // Do nothing
        }

        public virtual void ActivateGear(AI ai)
        {
            // Do nothing
        }
    }
}