using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace AIRally.Model.Tiles
{
    public abstract class Tile
    {
        public abstract override string ToString();

        public abstract Image Draw();

        public int X { get; }
        public int Y { get; }

        protected Tile(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        protected Image DrawMe(string resourceName)
        {
            Image result = null;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myStream = myAssembly.GetManifestResourceStream("AIRally.EMF."+ resourceName +".EMF");
            if (myStream != null)
            {
                result = new Bitmap(myStream);
                myStream.Dispose();
            }
            return result;
        }

        public static Tile MakeTile(string tileString, int x, int y)
        {
            Tile result;

            // the first character is the Concrete Tile
            switch (tileString[0])
            {
                case 'F':
                    result = new Floor(x, y);
                    break;
                case 'P':
                    result = new Pit(x, y);
                    break;
                default:
                    return null;
                    break;
            }
            
            //All following characters are Decorator Tiles
            var i = 1;
            while (i < tileString.Length)
            {
                int number;
                string turnString = "12345";
                ConveyorDirection conveyorDirection;
                switch (tileString[i])
                {
                    case 'C': // Conveyor Belt
                        i++;
                        switch (tileString[i])
                        {
                            case 'L':
                                conveyorDirection = ConveyorDirection.Left;
                                break;
                            case 'D':
                                conveyorDirection = ConveyorDirection.Down;
                                break;
                            case 'R':
                                conveyorDirection = ConveyorDirection.Right;
                                break;
                            default:
                                conveyorDirection = ConveyorDirection.Up;
                                break;
                        }
                        i++;
                        switch (tileString[i])
                        {
                            case 'N':
                                result = new ConveyorBelt(result, conveyorDirection, TurnDirection.None, x, y);
                                break;
                            case 'L':
                                result = new ConveyorBelt(result, conveyorDirection, TurnDirection.Left, x, y);
                                break;
                            case 'R':
                                result = new ConveyorBelt(result, conveyorDirection, TurnDirection.Right, x, y);
                                break;
                            case 'B':
                                result = new ConveyorBelt(result, conveyorDirection, TurnDirection.Both, x, y);
                                break;
                        }
                        break;
                    case 'E': // Express Conveyor Belt
                        i++;
                        switch (tileString[i])
                        {
                            case 'L':
                                conveyorDirection = ConveyorDirection.Left;
                                break;
                            case 'D':
                                conveyorDirection = ConveyorDirection.Down;
                                break;
                            case 'R':
                                conveyorDirection = ConveyorDirection.Right;
                                break;
                            default:
                                conveyorDirection = ConveyorDirection.Up;
                                break;
                        }
                        i++;
                        switch (tileString[i])
                        {
                            case 'N':
                                result = new ExpressConveyorBelt(result, conveyorDirection, TurnDirection.None, x, y);
                                break;
                            case 'L':
                                result = new ExpressConveyorBelt(result, conveyorDirection, TurnDirection.Left, x, y);
                                break;
                            case 'R':
                                result = new ExpressConveyorBelt(result, conveyorDirection, TurnDirection.Right, x, y);
                                break;
                            case 'B':
                                result = new ExpressConveyorBelt(result, conveyorDirection, TurnDirection.Both, x, y);
                                break;
                        }
                        break;
                    case 'F': // Flag
                        i++;
                        number = Convert.ToInt32(tileString[i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new Flag(result, number, x, y);
                        }
                        break;
                    case 'G': // Gear
                        i++;
                        result = tileString[i] == 'R' ? new Gear(result, TurnDirection.Right, x, y) : new Gear(result, TurnDirection.Left, x, y);
                        break;
                    case 'L': // Laser
                        i++;
                        number = Convert.ToInt32(tileString[i].ToString());
                        if (number >= 1 && number <= 3)
                        {
                            result = new Laser(result, number, x, y);
                        }
                        break;
                    case 'P': // Pusher
                        List<int> turns = new List<int>();
                        while (i < tileString.Length - 1 && turnString.Contains(tileString[i + 1].ToString()))
                        {
                            i++;
                            turns.Add(Convert.ToInt32(tileString[i].ToString()));
                        }
                        result = new Pusher(result, turns, x, y);
                        break;
                    case 'R': // Repair
                        result = new Repair(result, x, y);
                        break;
                    case 'S': // Spawnpoint
                        i++;
                        number = Convert.ToInt32(tileString[i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new SpawnPoint(result, number, x, y);
                        }
                        break;
                    case 'W': // Wall
                        i++;
                        switch (tileString[i])
                        {
                            case 'T':
                                result = new Wall(result, WallDirection.Top, x, y);
                                break;
                            case 'L':
                                result = new Wall(result, WallDirection.Left, x, y);
                                break;
                            case 'B':
                                result = new Wall(result, WallDirection.Bottom, x, y);
                                break;
                            case 'R':
                                result = new Wall(result, WallDirection.Right, x, y);
                                break;
                        }
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
    }
}
