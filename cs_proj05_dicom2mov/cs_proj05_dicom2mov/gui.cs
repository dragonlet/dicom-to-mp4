using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace cs_proj05_dicom2mov
{
    class gui
    {
        public static string[] getDicomFiles(string path)
        {
            string[] dcmFiles = sys.getFiles(path);
            return dcmFiles;
        }

        public static string[] getMovFiles(string path)
        {
            string[] dcmFiles = sys.getFiles(path);
            return dcmFiles;
        }

        // gui.convert() should deal with looping through multiple dicom datasets
        // each directory of .dcm files should be a different session or different scan
        public static bool convert(string filename)
        {
            conv.convert(filename);
            return true;
        }
        public static bool convert(string filename, ProgressWindow progform)
        {
            conv.convert(filename, progform);
            return true;
        }
    }
}
