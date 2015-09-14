using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AIRallyPlayer
{
    public partial class frmSelectAIs : Form
    {
        public frmSelectAIs()
        {
            InitializeComponent();
        }

        public SelectAI this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return selectAI1;

                    case 2:
                        return selectAI2;

                    case 3:
                        return selectAI3;

                    case 4:
                        return selectAI4;

                    case 5:
                        return selectAI5;

                    case 6:
                        return selectAI6;

                    case 7:
                        return selectAI7;

                    case 8:
                        return selectAI8;
                }
                return null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (!String.IsNullOrEmpty(this[i].AILocation))
                {
                    if (!File.Exists(this[i].AILocation))
                    {
                        this[i].Clear();
                    }
                }
            }
        }
    }
}