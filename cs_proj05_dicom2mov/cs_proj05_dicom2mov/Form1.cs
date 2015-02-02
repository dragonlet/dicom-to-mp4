using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*
             * foreach (string file in gui.displayDicomFiles())
             * {
             *      selectListDicom.Items.Add(file);
             * }
             */

            //for now adding fake items
            selectListDicom.Items.Add("fakeDicom.dcm");
        }

        private void initMovList()
        {
            /*
             * foreach (string file in gui.displayMovFiles())
             * {
             *      checklistMovieFiles.Items.Add(file);
             * }
             */

            //For now, adding fake items.
            checklistMovieFiles.Items.Add("fakeMov.mov");
        }

        private void initProfileList()
        {
            // dropdownProfiles.DataSource = ?? (this can be any type of list, array, dict; I am just unclear on what it gets data from. Presets?)
        }

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            // I don't know if this opens a browse type menu (which might be a good idea) or what.
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            //gui.convert is not made yet. Assuming it is gui.convert(path[], presets) where path[] is the array of items and presets is the profile in dropdownProfiles
            //gui.convert(selectListDicom.SelectedItems, dropdownProfiles.SelectedIndex);
        }
    }
}
