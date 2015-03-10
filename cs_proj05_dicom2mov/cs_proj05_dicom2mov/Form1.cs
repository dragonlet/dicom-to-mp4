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
            initProfileList();
        }

        private void initDicomList()
        {
            string[] dcmList = gui.getDicomFiles(sys.dicomsPath);
            if (dcmList.Length > 0)
            {
                foreach (string file in dcmList)
                {
                    selectListDicom.Items.Add(file);
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

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DriveList.SelectedItem.ToString() + "dicom2mov"))
                Directory.CreateDirectory(DriveList.SelectedItem.ToString() + "dicom2mov");
            sys.copyFiles(sys.outPath + checklistMovieFiles.SelectedItem.ToString(), DriveList.SelectedItem.ToString() + @"dicom2mov\" + checklistMovieFiles.SelectedItem.ToString());
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            //gui.convert is not made yet. Assuming it is gui.convert(path[], presets) where path[] is the array of items and presets is the profile in dropdownProfiles
            string presetfile = sys.presetPath + dropdownProfiles.SelectedValue;
            IDictionary<string, string> presetsettings = sys.getPresets(presetfile+".txt");
            foreach (object item in selectListDicom.CheckedItems)
            {
                //gui.convert(selectListDicom.SelectedItem.ToString() /*, dropdownProfiles.SelectedIndex*/);
                gui.convert(item.ToString() /*, dropdownProfiles.SelectedIndex*/);
            }
            initMovList(); //update mov list
            // all parameters will be set in gui.convert()
            // or does it need to happen here because of the way form list selection stuff works?
            // It needs to happen here.
        }

        private void populateDrives_Click(object sender, EventArgs e)
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
    }
}