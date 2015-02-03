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
        public static string cwd; //current working directory.
        public static string presetPath; //path to hold presets.
        public static List<string> noDelList; //array for where deleteion cannot happen from.

        public static bool getPresets(string fpath)
        {
            if (fpath == "")
            {
                fpath = presetPath;
            }



            return false;
        }


        public static bool readProgConf(string fileloc = "%APPDATA%\\dicom2mov\\conf.ini")
        {
            
            string[] stringTo={};
            char delimitChar='=';
            stringTo[0]="current_directory";//currenty_directory=
            stringTo[1]="preset_path";
            stringTo[2]="no_delete_path";


            int i=0;

            foreach (string line in File.ReadLines(fileloc))
            {
                if(line.Contains(stringTo[i])){
                    string[] tempArr=line.Split(delimitChar);

                    switch (i)
                    {
                        case 0:
                            cwd = tempArr[1];
                            break;
                        case 1:
                            presetPath = tempArr[1];
                            break;
                        case 2:
                            if (tempArr[1] != "") {
                                noDelList.Add(tempArr[1]);
                            }
                            break;
                        default:
                            break;
                    }

                }
                i++;
            }
            return false;
        }


        public static string[] getFiles(string dir)
        {
            if (dir=="")
            {
                //stub for getting default directory.
            }
            string[] flist = Directory.GetFiles(dir);
            return flist;
        } 

        public static bool deleteFiles(string fname)
        {
            if (noDelList.Any(fname.Contains))
            {
                return false;
            }


            File.Delete(fname);
            return true;
        }

        public static bool copyFiles(string from, string to, bool overwrite=false)
        {
            string errstr = "";
            if (!File.Exists(from))
            {
                errstr += " sys:copyFiles Error: from file \"" + from + "\" doesn't exist. ";
            }
            if (!File.Exists(to))
            {
                errstr += " sys:copyFiles Error: to file \"" + to + "\" doesn't exist. ";
            }

            if (errstr!="")
            {
                return false;
            }

            File.Copy(from, to, overwrite);

            return true;
        }


    }
}
