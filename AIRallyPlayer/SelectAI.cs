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

        public string AILocation
        {
            get { return tbLocation.Text; }
        }

        public string AIName
        {
            get { return tbName.Text; }
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

        public void Clear()
        {
            tbLocation.Text = "";
            tbName.Text = "";
        }
    }
}