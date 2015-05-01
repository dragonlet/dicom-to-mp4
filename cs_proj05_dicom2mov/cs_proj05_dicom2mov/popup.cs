using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cs_proj05_dicom2mov
{
    class popup
    {
        public static string msg(string showStr, string rtrnStr="")
        {
            MessageBox.Show(showStr);
            return rtrnStr;
        }

    }
}
