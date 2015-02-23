using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_proj05_dicom2mov
{
    class gui
    {
        public static string[] getDicomFiles(string path)
        {
            string[] dcmFiles;
            int counter = 0;
            string[] files = sys.getFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".dcm"))
                    counter++;
            }
            if (counter != 0)
            {
                dcmFiles = new string[counter];
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].EndsWith(".dcm"))
                        dcmFiles[i] = files[i];
                }
            }
            else
                dcmFiles = new string[0];

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

        public static bool convert(string[] files)
        {
            //Pending discussion on presets and conv.convert being set up.
            return false;
        }
    }
}
