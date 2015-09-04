using AIRally.Model.Boards;
using System;
using System.Drawing;
using System.Reflection;

namespace AIRally.Model.Tiles
{
    public abstract class Tile
    {
        protected char GetConveyorDirectionChar(ConveyorDirection cd)
        {
            switch (cd)
            {
                case ConveyorDirection.Up:
                    return 'U';

                case ConveyorDirection.Right:
                    return 'R';

                case ConveyorDirection.Down:
                    return 'D';

                case ConveyorDirection.Left:
                    return 'L';
            }
            return 'N';
        }

        protected char GetTurnDirectionChar(TurnDirection td)
        {
            switch (td)
            {
                case TurnDirection.Left:
                    return 'L';

                case TurnDirection.Right:
                    return 'R';

                case TurnDirection.Both:
                    return 'B';
            }
            return 'N';
        }

        protected char GetWallDirectionChar(WallDirection wd)
        {
            switch (wd)
            {
                case WallDirection.Top:
                    return 'T';

                case WallDirection.Bottom:
                    return 'B';

                case WallDirection.Left:
                    return 'L';

                case WallDirection.Right:
                    return 'R';
            }
            return 'N';
        }

        public abstract override string ToString();

        public abstract Image Paint();

        public int X { get; }
        public int Y { get; }

        public Board Board { get; }

        protected Tile(Board board, int x, int y)
        {
            X = x;
            Y = y;
            Board = board;
        }

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

        private static ConveyorDirection GetConveyorDirection(char conveyorDirection)
        {
            switch (conveyorDirection)
            {
                case 'U':
                    return ConveyorDirection.Up;

                case 'L':
                    return ConveyorDirection.Left;

                case 'D':
                    return ConveyorDirection.Down;

                case 'R':
                    return ConveyorDirection.Right;

                default:
                    return ConveyorDirection.None;
            }
        }

        private static TurnDirection GetTurnDirection(char turnDirection)
        {
            switch (turnDirection)
            {
                case 'L':
                    return TurnDirection.Left;

                case 'R':
                    return TurnDirection.Right;

                case 'B':
                    return TurnDirection.Both;

                default:
                    return TurnDirection.None;
            }
        }

        private static WallDirection GetWallDirection(char wallDirection)
        {
            switch (wallDirection)
            {
                case 'T':
                    return WallDirection.Top;

                case 'L':
                    return WallDirection.Left;

                case 'B':
                    return WallDirection.Bottom;

                case 'R':
                    return WallDirection.Right;

                default:
                    return WallDirection.None;
            }
        }

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
                string turnString = "12345";
                switch (tileString[i])
                {
                    case 'C': // Conveyor Belt
                        result = new ConveyorBelt(board, result, GetConveyorDirection(tileString[++i]),
                            GetTurnDirection(tileString[++i]), x, y);
                        break;

                    case 'E': // Express Conveyor Belt
                        result = new ExpressConveyorBelt(board, result, GetConveyorDirection(tileString[++i]),
                            GetTurnDirection(tileString[++i]), x, y);
                        break;

                    case 'F': // Flag
                        number = Convert.ToInt32(tileString[++i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new Flag(board, result, number, x, y);
                        }
                        break;

                    case 'G': // Gear
                        result = new Gear(board, result, GetTurnDirection(tileString[++i]), x, y);
                        break;

                    case 'L': // Laser
                        number = Convert.ToInt32(tileString[++i].ToString());
                        if (number >= 1 && number <= 3)
                        {
                            result = new Laser(board, result, number, x, y);
                        }
                        break;

                    case 'P': // Pusher
                        var turns = new bool[5]; ;
                        while (i < tileString.Length - 1 && turnString.Contains(tileString[i + 1].ToString()))
                        {
                            turns[Convert.ToInt32(tileString[++i].ToString()) - 1] = true;
                        }
                        result = new Pusher(board, result, turns, x, y);
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
                        result = new Wall(board, result, GetWallDirection(tileString[++i]), x, y);
                        break;
                }
                i++;
            }
            return result;
        }

        public virtual int HasSpawnPoint()
        {
            return 0;
        }

        public virtual bool HasRepair()
        {
            return false;
        }

        public virtual int HasLasers()
        {
            return 0;
        }

        public virtual WallDirection[] HasWalls()
        {
            return new WallDirection[0];
        }

        public virtual bool IsPit()
        {
            return false;
        }

        public virtual bool HasPusher()
        {
            return false;
        }

        public virtual AI HasAI()
        {
            return Board.aiRally.AIs[X, Y];
        }
    }
}