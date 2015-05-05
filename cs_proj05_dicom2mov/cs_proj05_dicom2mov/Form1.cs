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
            // dropdownProfiles.DataSource = ?? (this can be any type of list, array, dict; I am just unclear on what it gets data from. Presets?)
            string[] presetspre = sys.getFiles(sys.presetPath);
            string[] presets=new string[presetspre.Length];
            int i = 0;
            while (i < presetspre.Length)
            {
                presets[i] = presetspre[i].Replace(".txt", "");//removes the .txt to make it better sight-wise.
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

            if (DriveList.SelectedItem == null)
            {
                popup.msg("No drive selected for file move");
                return;
            }
            if (!Directory.Exists(DriveList.SelectedItem.ToString() + "dicom2mov"))
                Directory.CreateDirectory(DriveList.SelectedItem.ToString() + "dicom2mov");
            sys.copyFiles(sys.outPath + checklistMovieFiles.SelectedItem.ToString(), DriveList.SelectedItem.ToString() + @"dicom2mov\" + checklistMovieFiles.SelectedItem.ToString());
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {

            
            

            //gui.convert is not made yet. Assuming it is gui.convert(path[], presets) where path[] is the array of items and presets is the profile in dropdownProfiles
            string presetfile = sys.presetPath + dropdownProfiles.SelectedValue;
            IDictionary<string, string> presetsettings = sys.getPresets(presetfile+".txt");
            buttonConvert.Text = "Converting";
            buttonConvert.Enabled = false;
            Console.WriteLine(presetsettings.ToString());
            
            //ProgressWindow form2 = new ProgressWindow(selectListDicom.CheckedItems);
            //form2.Show();
            
            foreach (object item in selectListDicom.CheckedItems)
            {

                string toPass = item.ToString();
                gui.convert(toPass.Substring(toPass.LastIndexOf('|') +1));
            }
            
            buttonConvert.Text = "Convert";
            buttonConvert.Enabled = true;
            

            initMovList(); //update mov list
            // all parameters will be set in gui.convert()
            // or does it need to happen here because of the way form list selection stuff works?
            // It needs to happen here.
        }

        protected void selectListDicom_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            string selected = selectListDicom.SelectedItem.ToString();
            dcm item = new dcm(sys.dicomsPath + selected.Substring(selected.LastIndexOf('|') + 1));

            Details.Text = item.patientName + Environment.NewLine + convToDate(item.dateOfScan) + Environment.NewLine + convToTime(item.timeOfScan);
                
        }
        private string convToTime(string input)
        {
            DateTime myDate = DateTime.ParseExact(input, "HHmmss", null);
            return myDate.Hour + ":" + myDate.Minute + ":" + myDate.Second;
        }
        private string convToDate(string input)
        {
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
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
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