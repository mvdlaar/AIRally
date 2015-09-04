namespace AIRallyPlayer
{
    partial class SelectAI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblNameText = new System.Windows.Forms.Label();
            this.lblAILocation = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.btnOpenAIDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(47, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(187, 20);
            this.tbName.TabIndex = 0;
            // 
            // lblNameText
            // 
            this.lblNameText.AutoSize = true;
            this.lblNameText.Location = new System.Drawing.Point(3, 6);
            this.lblNameText.Name = "lblNameText";
            this.lblNameText.Size = new System.Drawing.Size(38, 13);
            this.lblNameText.TabIndex = 1;
            this.lblNameText.Text = "Name:";
            // 
            // lblAILocation
            // 
            this.lblAILocation.AutoSize = true;
            this.lblAILocation.Location = new System.Drawing.Point(240, 6);
            this.lblAILocation.Name = "lblAILocation";
            this.lblAILocation.Size = new System.Drawing.Size(51, 13);
            this.lblAILocation.TabIndex = 3;
            this.lblAILocation.Text = "Location:";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(297, 3);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(201, 20);
            this.tbLocation.TabIndex = 4;
            // 
            // btnOpenAIDialog
            // 
            this.btnOpenAIDialog.Location = new System.Drawing.Point(504, 3);
            this.btnOpenAIDialog.Name = "btnOpenAIDialog";
            this.btnOpenAIDialog.Size = new System.Drawing.Size(26, 20);
            this.btnOpenAIDialog.TabIndex = 5;
            this.btnOpenAIDialog.Text = "...";
            this.btnOpenAIDialog.UseVisualStyleBackColor = true;
            this.btnOpenAIDialog.Click += new System.EventHandler(this.btnOpenAIDialog_Click);
            // 
            // SelectAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenAIDialog);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.lblAILocation);
            this.Controls.Add(this.lblNameText);
            this.Controls.Add(this.tbName);
            this.Name = "SelectAI";
            this.Size = new System.Drawing.Size(544, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.Label lblAILocation;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Button btnOpenAIDialog;
    }
}
