using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cs_proj05_dicom2mov
{
    class sys
    {
        public static string[] getFiles(string dir)
        {
            if (dir=="")
            {
                //stub for getting default directory.
            }
            string[] flist = Directory.GetFiles(dir);
            return flist;
        } 
    }
}
