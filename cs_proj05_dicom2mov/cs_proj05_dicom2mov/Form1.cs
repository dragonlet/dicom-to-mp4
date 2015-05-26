using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace cs_proj05_dicom2mov
{
    public partial class Form1 : Form
    {

        public Form1(int x = 900, int y = 510)
        {
            InitializeComponent();
            this.Size = new Size(x, y);
            initDicomList();
            initMovList();
            initDriveList();
            initProfileList();
        }

        private void initDicomList()
        {
            string[] dcmList = gui.getDicomFiles(sys.dicomsPath);
            if (dcmList.Length > 0)
            {
                foreach (string file in dcmList)
                {
                    dcm temp = new dcm(sys.dicomsPath + file);
                    if (temp.frameNum > 1)
                        selectListDicom.Items.Add(temp);
                }
            }
            else
            {
                selectListDicom.Items.Add("No .dcm files found.");
                selectListDicom.SelectionMode = SelectionMode.None;
            }
        }

        private void initMovList()
        {
            checklistMovieFiles.Items.Clear();
            string[] movList = gui.getMovFiles(sys.outPath);
            if (movList.Length > 0)
            {
                foreach (string file in movList)
                {
                    checklistMovieFiles.Items.Add(file);
                }
                checklistMovieFiles.SelectionMode = SelectionMode.One;
            }
            else
            {
                checklistMovieFiles.Items.Add("No valid movie files found.");
                checklistMovieFiles.SelectionMode = SelectionMode.None;
            }
        }

        private void initProfileList()
        {
            string[] presetspre = sys.getFiles(sys.presetPath);
            string[] presets=new string[presetspre.Length];
            int i = 0;
            while (i < presetspre.Length)
            {
                // removes the .txt to make it better sight-wise.
                presets[i] = presetspre[i].Replace(".txt", ""); 
                i++;
            }

            dropdownProfiles.DataSource = presets;
        }

        private void initDriveList()
        {
            DriveList.Items.Clear();

            DriveInfo[] ListDrives = DriveInfo.GetDrives();

            foreach (DriveInfo Drive in ListDrives)
            {
                if (Drive.DriveType == DriveType.Removable)
                {
                    DriveList.Items.Add(Drive.ToString());
                }
            }
        }

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            // first check movie file is selected
            if (checklistMovieFiles.SelectedItem == null)
            {
                popup.msg("Select a file to be moved.");
                return;
            }

            // next check if drive is selected to move the file to
            if (DriveList.SelectedItem == null)
            {
                popup.msg("No drive selected for file move.");
                return;
            }

            if (!Directory.Exists(DriveList.SelectedItem.ToString() + "dicom2mov"))
                Directory.CreateDirectory(DriveList.SelectedItem.ToString() + "dicom2mov");

            foreach(object movfile in checklistMovieFiles.CheckedItems) {
                sys.copyFiles(sys.outPath + movfile.ToString(), DriveList.SelectedItem.ToString() + @"dicom2mov\" + movfile.ToString());
                
            }
            
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            // make sure they selected a file for conversion
            if (selectListDicom.SelectedItem == null)
            {
                popup.msg("Select a file to be converted.");
                return;
            }


            if (selectListDicom.CheckedItems == null || selectListDicom.CheckedItems.Count<=0)
            {
                popup.msg("No dicom files selected.");
                return;
            }

            string presetfile = sys.presetPath + dropdownProfiles.SelectedValue;
            IDictionary<string, string> presetsettings = sys.getPresets(presetfile+".txt");
            buttonConvert.Text = "Converting";
            buttonConvert.Enabled = false;
            Console.WriteLine(presetsettings.ToString());

            ProgressWindow form2 = new ProgressWindow(selectListDicom.CheckedItems);
            this.Enabled = false;
            foreach (object item in selectListDicom.CheckedItems)
            {
                
                string toPass = item.ToString();    
                form2.textbox(toPass.Substring(toPass.LastIndexOf('|') + 1)); //filename
                form2.progressbar(0);

                form2.Show();
                Application.DoEvents();

                dcm temp = new dcm(sys.dicomsPath + toPass.Substring(toPass.LastIndexOf('|') + 1));
                
                gui.convert(toPass.Substring(toPass.LastIndexOf('|') +1), form2, temp.frameRate);

                
            }
            form2.setProgress(100);
            form2.textbox("Done");
            form2.progtext("Done");
            form2.Update();
            Application.DoEvents();
            Thread.Sleep(2000);
            form2.Close();
            this.Enabled = true;
            this.Focus();
            buttonConvert.Text = "Convert";
            buttonConvert.Enabled = true;
            

            initMovList(); //update mov list
        }

        protected void selectListDicom_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            string selected = selectListDicom.SelectedItem.ToString();
            dcm item = new dcm(sys.dicomsPath + selected.Substring(selected.LastIndexOf('|') + 1));

            Details.Text = item.patientName + Environment.NewLine + convToDate(item.dateOfScan) + Environment.NewLine + convToTime(item.timeOfScan) + Environment.NewLine  + item.frameNum;
                
        }
        private string convToTime(string input)
        {
            if (input == null)
                return "";
            DateTime myDate = DateTime.ParseExact(input, "HHmmss", null);
            return myDate.Hour + ":" + myDate.Minute + ":" + myDate.Second;
        }
        private string convToDate(string input)
        {
            if (input == null)
                return "";
            DateTime myDate = DateTime.ParseExact(input, "yyyyMMdd", null);
            return myDate.Month + "/" +  myDate.Day + "/" + myDate.Year;
        }

        private void populateDrives_Click(object sender, EventArgs e)
        {
            initDriveList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // increase font by
            const int MODIFIER = 2;

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(c.Font.FontFamily, c.Font.Size + MODIFIER, c.Font.Style);
            }
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // decrease font by
            const int MODIFIER = -2;
 
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(c.Font.FontFamily, c.Font.Size + MODIFIER, c.Font.Style);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (checklistMovieFiles.CheckedItems == null || checklistMovieFiles.CheckedItems.Count <= 0)
            {
                popup.msg("No files selected for Deletion");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the checked files?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (object item in checklistMovieFiles.CheckedItems)
                {
                    sys.deleteFiles(sys.outPath + item);
                }
                initMovList();
            }
        }
    }
}