using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            //Currently only checks for mp4 files. Any other extensions need to be added once we figure out the options we are giving users.
            string[] movFiles;
            int counter = 0;
            string[] files = sys.getFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".mp4"))
                    counter++;
            }
            if (counter != 0)
            {
                movFiles = new string[counter];
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].EndsWith(".mp4"))
                        movFiles[i] = files[i];
                }
            }
            else
                movFiles = new string[0];

            return movFiles;
        }

        // gui.convert() should deal with looping through multiple dicom datasets
        // each directory of .dcm files should be a different session or different scan
        public static bool convert(string selectedDir)
        {
            // create the dicomObj somewhere
            // global or pass it to conv.convert() function?

            // my hard coded test cases:
            //conv.dcm_to_jpg(@"C:\Users\ajw\Documents\DICOM Samples\philips\EPIQ 1.2 Adult Echo Demo Exam wSR\DICOM\IM_0020", @"asdf");
            
            // make sure to put IM_0020 into your appdata\roaming\dicom2mov\dicoms folder
            conv.convert("IM_0020");

            popup.msg("go make the global dicomObj!\n\nfile: \""+selectedDir+"\" not converted, but IM_0020 was!");
            return true;
        }
    }
}
