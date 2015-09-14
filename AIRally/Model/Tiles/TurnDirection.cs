namespace AIRally.Model.Tiles
{
    public enum TurnDirection
    {
        None,
        Right,
        Left,
        Both
    }

    public class TurnDirectionUtil
    {
        public static TurnDirection Get(char turnDirection)
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

        public static char GetChar(TurnDirection td)
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
    }
}