namespace AIRally.Model.Decks
{
    public enum ProgramCardAction
    {
        Move1,
        Move2,
        Move3,
        BackUp,
        RotateRight,
        RotateLeft,
        UTurn,
        None
    };

    public class ProgramCardActionUtil
    {
        public static char ToChar(ProgramCardAction pca)
        {
            switch (pca)
            {
                case ProgramCardAction.Move1:
                    return '1';

                case ProgramCardAction.Move2:
                    return '2';

                case ProgramCardAction.Move3:
                    return '3';

                case ProgramCardAction.BackUp:
                    return 'B';

                case ProgramCardAction.RotateRight:
                    return 'R';

                case ProgramCardAction.RotateLeft:
                    return 'L';

                case ProgramCardAction.UTurn:
                    return 'U';
            }
            return 'N';
        }

        public static ProgramCardAction Get(char pca)
        {
            switch (pca)
            {
                case '1':
                    return ProgramCardAction.Move1;

                case '2':
                    return ProgramCardAction.Move2;

                case '3':
                    return ProgramCardAction.Move3;

                case 'B':
                    return ProgramCardAction.BackUp;

                case 'R':
                    return ProgramCardAction.RotateRight;

                case 'L':
                    return ProgramCardAction.RotateLeft;

                case 'U':
                    return ProgramCardAction.UTurn;
            }
            return ProgramCardAction.None;
        }

    }
}