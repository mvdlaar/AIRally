using System;
using System.Windows.Forms;
using AIRally.Model;
using AIRally.Model.Boards;

namespace AIRallyPlayer
{
    public partial class Form1 : Form
    {
        private string boardLocation = @"D:\Projects\Zuyd\AIRally\AIRally\Boards\Checkmate.aib";
        private AIRally.Model.AIRally airally;

        public Form1()
        {
            InitializeComponent();
            airally = new AIRally.Model.AIRally(boardLocation);

            
            AI ai1 = new AI(1);
            
            RefreshBoard();
        }

        private void RefreshBoard()
        {
            DrawBoard.Draw(this.pbxBoard, airally.Board);
            this.Text = airally.Board.Name;
        }

        private void pbxBoard_SizeChanged(object sender, EventArgs e)
        {
            RefreshBoard();
        }
    }
}
