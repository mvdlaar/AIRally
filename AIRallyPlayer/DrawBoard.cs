using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AIRally.Model.Boards;

namespace AIRallyPlayer
{
    public class DrawBoard
    {
        public static void Draw(PictureBox pbxBoard, Board rallyBoard)
        {
            int tileHeight = pbxBoard.Height / rallyBoard.Height;
            int tileWidth = pbxBoard.Width / rallyBoard.Width;

            Image imgBoard = new Bitmap(pbxBoard.Width, pbxBoard.Height);
            Graphics g = Graphics.FromImage(imgBoard);
            g.Clear(SystemColors.AppWorkspace);
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingMode = CompositingMode.SourceCopy;

            for (int row = 0; row < rallyBoard.Height; row++)
            {
                for (int column = 0; column < rallyBoard.Width; column++)
                {
                    Image img = rallyBoard[row, column].Draw();
                    g.DrawImage(img, column*tileWidth, row*tileHeight, tileWidth, tileHeight);
                    img.Dispose();
                }
            }
            g.Dispose();
            Image disImage = pbxBoard.Image;
            pbxBoard.Image = imgBoard;
            if (disImage != null)
            {
                disImage.Dispose();
            }
        }
    }
}
