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

        public Form1(int x=900, int y=510)
        {
            InitializeComponent();
            this.Size = new Size(x, y);
            initDicomList();
            initMovList();
            initProfileList();
        }

        private void initDicomList()
        {
            //At the moment this function only uses the current directory. Once we get reading in presets from the conf sorted out, 
            //replace Directory.GetCurrentDirectory() with the path variable.
            string[] dcmList = gui.getDicomFiles(Directory.GetCurrentDirectory());
            if (dcmList.Length > 0)
            {
                foreach (string file in dcmList)
                {
                    selectListDicom.Items.Add(file);
                }
            }
            else
            {
                //for now adding fake items. In the future some sort of non-checkable error message needs to be displayed.
                selectListDicom.Items.Add("fakeDicom.dcm");
            }
        }

        private void initMovList()
        {
            //This only currently checks for mp4 files, pending full list of possible extensions.
            //At the moment this function only uses the current directory. Once we get reading in presets from the conf sorted out, 
            //replace Directory.GetCurrentDirectory() with the path variable.
            string[] movList = gui.getMovFiles(Directory.GetCurrentDirectory());
            if(movList.Length > 0)
            {
                foreach (string file in movList)
                {
                    checklistMovieFiles.Items.Add(file);
                }
            }
            else
            {
                //For now, adding fake items.
                checklistMovieFiles.Items.Add("fakeMov.mp4");
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
        }
    }
}
