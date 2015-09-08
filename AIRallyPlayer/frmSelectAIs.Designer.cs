namespace AIRallyPlayer
{
    partial class frmSelectAIs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectAI1 = new AIRallyPlayer.SelectAI();
            this.selectAI2 = new AIRallyPlayer.SelectAI();
            this.selectAI3 = new AIRallyPlayer.SelectAI();
            this.selectAI4 = new AIRallyPlayer.SelectAI();
            this.selectAI5 = new AIRallyPlayer.SelectAI();
            this.selectAI6 = new AIRallyPlayer.SelectAI();
            this.selectAI7 = new AIRallyPlayer.SelectAI();
            this.selectAI8 = new AIRallyPlayer.SelectAI();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectAI1
            // 
            this.selectAI1.Location = new System.Drawing.Point(12, 12);
            this.selectAI1.Name = "selectAI1";
            this.selectAI1.Size = new System.Drawing.Size(544, 26);
            this.selectAI1.TabIndex = 0;
            // 
            // selectAI2
            // 
            this.selectAI2.Location = new System.Drawing.Point(12, 44);
            this.selectAI2.Name = "selectAI2";
            this.selectAI2.Size = new System.Drawing.Size(544, 26);
            this.selectAI2.TabIndex = 1;
            // 
            // selectAI3
            // 
            this.selectAI3.Location = new System.Drawing.Point(12, 76);
            this.selectAI3.Name = "selectAI3";
            this.selectAI3.Size = new System.Drawing.Size(544, 26);
            this.selectAI3.TabIndex = 2;
            // 
            // selectAI4
            // 
            this.selectAI4.Location = new System.Drawing.Point(12, 108);
            this.selectAI4.Name = "selectAI4";
            this.selectAI4.Size = new System.Drawing.Size(544, 26);
            this.selectAI4.TabIndex = 3;
            // 
            // selectAI5
            // 
            this.selectAI5.Location = new System.Drawing.Point(12, 140);
            this.selectAI5.Name = "selectAI5";
            this.selectAI5.Size = new System.Drawing.Size(544, 26);
            this.selectAI5.TabIndex = 4;
            // 
            // selectAI6
            // 
            this.selectAI6.Location = new System.Drawing.Point(12, 172);
            this.selectAI6.Name = "selectAI6";
            this.selectAI6.Size = new System.Drawing.Size(544, 26);
            this.selectAI6.TabIndex = 5;
            // 
            // selectAI7
            // 
            this.selectAI7.Location = new System.Drawing.Point(12, 204);
            this.selectAI7.Name = "selectAI7";
            this.selectAI7.Size = new System.Drawing.Size(544, 26);
            this.selectAI7.TabIndex = 6;
            // 
            // selectAI8
            // 
            this.selectAI8.Location = new System.Drawing.Point(12, 236);
            this.selectAI8.Name = "selectAI8";
            this.selectAI8.Size = new System.Drawing.Size(544, 26);
            this.selectAI8.TabIndex = 7;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(385, 268);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 8;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(466, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(385, 297);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(467, 268);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 11;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            // 
            // frmSelectAIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 326);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.selectAI8);
            this.Controls.Add(this.selectAI7);
            this.Controls.Add(this.selectAI6);
            this.Controls.Add(this.selectAI5);
            this.Controls.Add(this.selectAI4);
            this.Controls.Add(this.selectAI3);
            this.Controls.Add(this.selectAI2);
            this.Controls.Add(this.selectAI1);
            this.Name = "frmSelectAIs";
            this.Text = "Select AI";
            this.ResumeLayout(false);

        }

        #endregion

        private SelectAI selectAI1;
        private SelectAI selectAI2;
        private SelectAI selectAI3;
        private SelectAI selectAI4;
        private SelectAI selectAI5;
        private SelectAI selectAI6;
        private SelectAI selectAI7;
        private SelectAI selectAI8;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRandomize;
    }
}