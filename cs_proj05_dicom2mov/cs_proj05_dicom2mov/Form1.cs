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
        }

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            //Currently opens a browse menu, and does nothing afterwards. Pending discussion.
            DialogResult result = moveToPath.ShowDialog();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            //gui.convert is not made yet. Assuming it is gui.convert(path[], presets) where path[] is the array of items and presets is the profile in dropdownProfiles
            //gui.convert(selectListDicom.SelectedItems, dropdownProfiles.SelectedIndex);

            // all parameters will be set in gui.convert()
            // or does it need to happen here because of the way form list selection stuff works?
            gui.convert();
        }
    }
}