using System;
using System.Windows.Forms;

namespace AIRallyPlayer
{
    public partial class Form1 : Form
    {
        private string boardLocation;
        private AIRally.Model.AIRally airally;

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshBoard()
        {
            DrawBoard.Draw(pbxBoard, airally.Board);
            Text = airally.Board.Name;
        }

        private void pbxBoard_SizeChanged(object sender, EventArgs e)
        {
            RefreshBoard();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "AIRally Boards (*.airb)|*.airb";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                boardLocation = fd.FileName;
                airally = new AIRally.Model.AIRally(boardLocation);
                RefreshBoard();
            }
        }
    }
}
