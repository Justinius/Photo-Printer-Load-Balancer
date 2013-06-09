namespace PrinterID
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.prntrListBox = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSrcDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetSrc = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCncl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enumerate Printers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prntrListBox
            // 
            this.prntrListBox.CheckOnClick = true;
            this.prntrListBox.FormattingEnabled = true;
            this.prntrListBox.Location = new System.Drawing.Point(12, 51);
            this.prntrListBox.Name = "prntrListBox";
            this.prntrListBox.Size = new System.Drawing.Size(495, 259);
            this.prntrListBox.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Set Printer Properties";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSrcDir
            // 
            this.txtSrcDir.Location = new System.Drawing.Point(12, 345);
            this.txtSrcDir.Name = "txtSrcDir";
            this.txtSrcDir.Size = new System.Drawing.Size(403, 20);
            this.txtSrcDir.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source Directory";
            // 
            // btnSetSrc
            // 
            this.btnSetSrc.Location = new System.Drawing.Point(431, 340);
            this.btnSetSrc.Name = "btnSetSrc";
            this.btnSetSrc.Size = new System.Drawing.Size(77, 29);
            this.btnSetSrc.TabIndex = 7;
            this.btnSetSrc.Text = "Set Src Dir";
            this.btnSetSrc.UseVisualStyleBackColor = true;
            this.btnSetSrc.Click += new System.EventHandler(this.btnSetSrc_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(364, 34);
            this.button3.TabIndex = 8;
            this.button3.Text = "Monitor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCncl
            // 
            this.btnCncl.Location = new System.Drawing.Point(406, 385);
            this.btnCncl.Name = "btnCncl";
            this.btnCncl.Size = new System.Drawing.Size(101, 34);
            this.btnCncl.TabIndex = 9;
            this.btnCncl.Text = "End";
            this.btnCncl.UseVisualStyleBackColor = true;
            this.btnCncl.Click += new System.EventHandler(this.btnCncl_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 427);
            this.Controls.Add(this.btnCncl);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSetSrc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSrcDir);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.prntrListBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox prntrListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSrcDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetSrc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCncl;
    }
}

