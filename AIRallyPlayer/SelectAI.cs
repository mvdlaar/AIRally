using System;
using System.Windows.Forms;

namespace AIRallyPlayer
{
    public partial class SelectAI : UserControl
    {
        public SelectAI()
        {
            InitializeComponent();
        }

        private void btnOpenAIDialog_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "AIRally AI (*.dll)|*.dll";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbLocation.Text = fd.FileName;
            }
        }

        public string AIName
        {
            get { return tbName.Text; }
        }

        public string AILocation
        {
            get { return tbLocation.Text; }
        }
    }
}