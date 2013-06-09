using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrinterID
{
    public partial class PrintSettings : Form
    {
        public PrintSettings()
        {
            InitializeComponent();
        }

        private void PrintSettings_Load(object sender, EventArgs e)
        {
            rbLandscape.Checked = true;
            rbBW.Checked = true;
        }

        private void PrintSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check margins
            string margin = this.txtMargins.Text;
            string[] indiv_margins = margin.Split(new char[] { ',' });
            if (indiv_margins.Length != 4)
            {
                MessageBox.Show("Incorrect format for Margin properties.");
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string margin = this.txtMargins.Text;
            string[] indiv_margins = margin.Split(new char[] { ',' });
            if (indiv_margins.Length != 4)
            {
                MessageBox.Show("Incorrect format for Margin properties.");
            }
            else
                this.Close();
        }
    }
}
