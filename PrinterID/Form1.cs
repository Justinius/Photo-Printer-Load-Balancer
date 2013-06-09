using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Threading;

namespace PrinterID
{   

    public partial class Form1 : Form
    {
        List<Printer> all_printers;
        List<Printer> selected_printers;
        BackgroundWorker bw = new BackgroundWorker();
        int curr_file;

        FileSystemWatcher _watchFolder = new FileSystemWatcher();
        
        public Form1()
        {
            InitializeComponent();
            all_printers = new List<Printer>();
            selected_printers = new List<Printer>();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            curr_file = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;
            
            foreach (string printer in printers)
            {
                prntrListBox.Items.Add(printer);
                all_printers.Add(new Printer() { name = printer });
            }

            button2.Enabled = true;
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int idx in prntrListBox.CheckedIndices)
            {
                selected_printers.Add(new Printer() { name = prntrListBox.Items[idx].ToString() });
            }

            PrintDocument pd = new PrintDocument();

            

            for(int i = 0; i < selected_printers.Count; i++)
            {
                pd.PrinterSettings.PrinterName = selected_printers[i].name;
                
                using (PrintSettings popUpForm = new PrintSettings())
                {
                    popUpForm.txtName.Text = selected_printers[i].name;

                    foreach (PrinterResolution res in pd.PrinterSettings.PrinterResolutions)
                        popUpForm.cbRes.Items.Add(res);
                    popUpForm.cbRes.SelectedIndex = 0;

                    foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                        popUpForm.cbPageSize.Items.Add(ps);
                    popUpForm.cbPageSize.SelectedIndex = 0;


                    Margins curr_margins = pd.DefaultPageSettings.Margins;
                    string margin = curr_margins.Top.ToString()+", "+curr_margins.Bottom.ToString()+", "+curr_margins.Left.ToString()+", "+curr_margins.Right.ToString();
                    popUpForm.txtMargins.Text = margin;

                    popUpForm.txtHMargins.Text = pd.DefaultPageSettings.HardMarginX.ToString() + ", " + pd.DefaultPageSettings.HardMarginY.ToString();

                    popUpForm.ShowDialog();

                    //read back selected things
                    margin = popUpForm.txtMargins.Text;
                    string[] indiv_margins = margin.Split(new char[]{','});
                    selected_printers[i].margin = new Margins(Convert.ToInt32(indiv_margins[0]), Convert.ToInt32(indiv_margins[1]), Convert.ToInt32(indiv_margins[2]), Convert.ToInt32(indiv_margins[3]));

                    selected_printers[i].ps = pd.PrinterSettings.PaperSizes[popUpForm.cbPageSize.SelectedIndex];
                    selected_printers[i].res = pd.PrinterSettings.PrinterResolutions[popUpForm.cbRes.SelectedIndex];
                    selected_printers[i].landscape = popUpForm.rbLandscape.Checked;
                    selected_printers[i].color = popUpForm.rbColor.Checked;
                }
            }

            
            txtSrcDir.Enabled = true;
            btnSetSrc.Enabled = true;
            button3.Enabled = true;
            btnCncl.Enabled = true;
        }

        private void btnSetSrc_Click(object sender, EventArgs e)
        {
            string folderPath = "C:";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            txtSrcDir.Text = folderPath;
        }
                
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            TaskInfo info = e.Argument as TaskInfo;
            
            // This is the path we want to monitor
            _watchFolder.Path = info.srcDir;

            // Make sure you use the OR on each Filter because we need to monitor
            // all of those activities

            _watchFolder.NotifyFilter = System.IO.NotifyFilters.DirectoryName;

            _watchFolder.NotifyFilter =
            _watchFolder.NotifyFilter | System.IO.NotifyFilters.FileName;
            _watchFolder.NotifyFilter =
            _watchFolder.NotifyFilter | System.IO.NotifyFilters.Attributes;

            // Now hook the triggers(events) to our handler (eventRaised)
            _watchFolder.Created += new FileSystemEventHandler(eventRaised);
            

            // And at last.. We connect our EventHandles to the system API (that is all
            // wrapped up in System.IO)
            _watchFolder.EnableRaisingEvents = true;

            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    _watchFolder.EnableRaisingEvents = false;
                    break;
                }
                else
                {
                    Thread.Sleep(5);
                }
            }
            
        }

        private void eventRaised(object sender, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    
                    curr_file++;
                    int curr_printer = curr_file % selected_printers.Count;
                    PrintDocument pd = new PrintDocument();
                    pd.DocumentName = e.FullPath;
                    pd.PrinterSettings.PrinterName = selected_printers[curr_printer].name;
                    pd.DefaultPageSettings.Margins = selected_printers[curr_printer].margin;
                    pd.DefaultPageSettings.PaperSize = selected_printers[curr_printer].ps;
                    pd.DefaultPageSettings.PrinterResolution = selected_printers[curr_printer].res;
                    pd.DefaultPageSettings.Landscape = selected_printers[curr_printer].landscape;
                    pd.DefaultPageSettings.Color = selected_printers[curr_printer].color;


                    pd.PrintPage += (s, f) => {
                                                Image img = Image.FromFile(pd.DocumentName);
                                                f.Graphics.DrawImage(img, 0, 0);
                                              };
                    pd.Print();
                    break;
                default: // Another action
                    break;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSetSrc.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnSetSrc.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            curr_file = 0;

            TaskInfo ti = new TaskInfo();
            ti.printers = selected_printers;
            ti.srcDir = txtSrcDir.Text;
            
            bw.RunWorkerAsync(ti);
        }

        private void btnCncl_Click_1(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            txtSrcDir.Enabled = false;
            btnSetSrc.Enabled = false;
            button3.Enabled = false;
            btnCncl.Enabled = false;
        }
    
    
    }

    public class TaskInfo
    {
        public List<Printer> printers;
        public string srcDir;
        public string dstDir;
    }

    public class Printer
    {
        public string name;
        public bool color;
        public bool landscape;
        public PrinterResolution res;
        public PaperSize ps;
        public Margins margin;
    }

    public class PrintJob
    {
        public Printer printer;
        string file_path;
    }
}
