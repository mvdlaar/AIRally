using System;
using System.Drawing;
using System.Windows.Forms;

namespace AIRallyPlayer
{
    public partial class frmMainForm : Form
    {
        private AIRally.Model.AIRally airally;
        private string boardLocation;

        public frmMainForm()
        {
            InitializeComponent();
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

        private void pbxBoard_SizeChanged(object sender, EventArgs e)
        {
            RefreshBoard();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            airally.PlayTurn();
            RefreshBoard();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshBoard()
        {
            if (airally != null)
            {
                Image tmpImage;
                tmpImage = pbxBoard.Image;
                pbxBoard.Image = airally.PaintBoard(pbxBoard.Width, pbxBoard.Height);
                Text = airally.Board.Name;
                tmpImage?.Dispose();
            }
        }

        private void selectAIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectAIs = new frmSelectAIs();
            if (selectAIs.ShowDialog(this) == DialogResult.OK)
            {
                airally.ClearAIs();
                for (var i = 1; i <= 8; i++)
                {
                    if (!string.IsNullOrEmpty(selectAIs[i].AIName) && !string.IsNullOrEmpty(selectAIs[i].AILocation))
                    {
                        airally.AddAI(selectAIs[i].AIName, selectAIs[i].AILocation);
                    }
                }
                RefreshBoard();
            }
        }
    }
}