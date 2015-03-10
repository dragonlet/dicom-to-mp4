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
            //Won't work if DICOMDIR is not in the outer folder.
            string[] dcmDirs;
            int counter = 0;
            string[] dirs = sys.getDirs(path);

            foreach (string directory in dirs)
            {
                if (sys.getFiles(path + directory).Contains("DICOMDIR"))
                    counter++;
            }
            if (counter != 0)
            {
                dcmDirs = new string[counter];
                for (int i = 0; i < dirs.Length; i++)
                {
                    if (sys.getFiles(path + dirs[i]).Contains("DICOMDIR"))
                    {
                        counter--;
                        dcmDirs[counter] = dirs[i];
                    }
                }
            }
            else
                dcmDirs = new string[0];

            return dcmDirs;
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
            conv.convert(selectedDir);
            popup.msg("file: \""+selectedDir+"\" converted.");
            return true;
        }
    }
}
