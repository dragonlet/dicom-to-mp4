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
            // create the dicomObj somewhere
            // global or pass it to conv.convert() function?

            // my hard coded test cases:
            //conv.dcm_to_jpg(@"C:\Users\ajw\Documents\DICOM Samples\philips\EPIQ 1.2 Adult Echo Demo Exam wSR\DICOM\IM_0020", @"asdf");
            // make sure to put IM_0020 into your appdata\roaming\dicom2mov\dicoms folder
            //ProgressWindow form2 = new ProgressWindow();
            //form2.Show();
            conv.convert(filename);

            //popup.msg("go make the global dicomObj!\n\nfile: \""+selectedDir+"\" not converted, but IM_0020 was!");
            return true;
        }
    }
}
