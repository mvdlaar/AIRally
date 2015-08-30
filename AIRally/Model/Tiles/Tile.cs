using System;
using System.Collections.Generic;
using System.Drawing;

namespace AIRally.Model.Tiles
{
    public abstract class Tile
    {
        public abstract override string ToString();

        public abstract Image Draw();

        public static Tile MakeTile(string tileString)
        {
            Tile result;

            // the first character is the concrete Tile

            switch (tileString[0])
            {
                case 'F':
                    result = new Floor();
                    break;
                case 'P':
                    result = new Pit();
                    break;
                default:
                    return null;
                    break;
            }
            
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
                                result = new ConveyorBelt(result, conveyorDirection, ConveyorTurn.None);
                                break;
                            case 'L':
                                result = new ConveyorBelt(result, conveyorDirection, ConveyorTurn.Left);
                                break;
                            case 'R':
                                result = new ConveyorBelt(result, conveyorDirection, ConveyorTurn.Right);
                                break;
                            case 'B':
                                result = new ConveyorBelt(result, conveyorDirection, ConveyorTurn.Both);
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
                                result = new ExpressConveyorBelt(result, conveyorDirection, ConveyorTurn.None);
                                break;
                            case 'L':
                                result = new ExpressConveyorBelt(result, conveyorDirection, ConveyorTurn.Left);
                                break;
                            case 'R':
                                result = new ExpressConveyorBelt(result, conveyorDirection, ConveyorTurn.Right);
                                break;
                            case 'B':
                                result = new ExpressConveyorBelt(result, conveyorDirection, ConveyorTurn.Both);
                                break;
                        }
                        break;
                    case 'F': // Flag
                        i++;
                        number = Convert.ToInt32(tileString[i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new Flag(result, number);
                        }
                        break;
                    case 'G': // Gear
                        i++;
                        result = tileString[i] == 'R' ? new Gear(result, GearDirection.Right) : new Gear(result, GearDirection.Left);
                        break;
                    case 'L': // Laser
                        i++;
                        result = new Laser(result);
                        break;
                    case 'P': // Pusher
                        List<int> turns = new List<int>();
                        while (i < tileString.Length - 1 && turnString.Contains(tileString[i + 1].ToString()))
                        {
                            i++;
                            turns.Add(Convert.ToInt32(tileString[i].ToString()));
                        }
                        result = new Pusher(result, turns);
                        break;
                    case 'R': // Repair
                        result = new Repair(result);
                        break;
                    case 'S': // Spawnpoint
                        i++;
                        number = Convert.ToInt32(tileString[i].ToString());
                        if (number >= 1 && number <= 8)
                        {
                            result = new SpawnPoint(result, number);
                        }
                        break;
                    case 'W': // Wall
                        i++;
                        switch (tileString[i])
                        {
                            case 'T':
                                result = new Wall(result, WallDirection.Top);
                                break;
                            case 'L':
                                result = new Wall(result, WallDirection.Left);
                                break;
                            case 'B':
                                result = new Wall(result, WallDirection.Bottom);
                                break;
                            case 'R':
                                result = new Wall(result, WallDirection.Right);
                                break;
                        }
                        break;
                }
                i++;
            }

            return result;
        }
    }
}
