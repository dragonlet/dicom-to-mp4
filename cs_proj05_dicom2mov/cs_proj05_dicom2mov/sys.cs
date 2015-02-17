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
        public static List<string> noDelList= new List<string>(); //array for where deleteion cannot happen from.
        public static string stillsPath;
        public static string outPath;

        static sys()
        {
            readProgConf();
        }

        public static string getPresets(string fpath)
        {
            if (fpath == "")
            {
                return "";
            }

            string rtrnstr = "";
            string[] stringTo = new string[2];
            char[] delimitChar = new char[] { '=' };
            stringTo[0] = "size";//currenty_directory=
            stringTo[1] = "format";

            string fileloc = Environment.ExpandEnvironmentVariables(fpath);
            try
            {
                File.ReadLines(fileloc);
            }
            catch (Exception errStr)
            {
                popup.msg(errStr.Message);
                return "";
            }

            int i = 0;

            foreach (string line in File.ReadLines(fileloc))
            {
                i = 0;
                while (i < stringTo.Length)
                {

                    if (line.Contains(stringTo[i]))
                    {

                        string[] tempArr = line.Split(delimitChar);

                        switch (i)
                        {
                            case 0:
                                rtrnstr = rtrnstr + "-s " + tempArr[1] + " ";
                                break;
                            case 1:
                                rtrnstr = rtrnstr + "-f " + tempArr[1] + " ";
                                break;
                            default:
                                break;
                        }

                    }
                    i++;
                }
            }
            return rtrnstr;
        }


        public static bool readProgConf(string filepath = "%APPDATA%\\dicom2mov\\conf.ini")
        {
            
            string[] stringTo= new string[3];
            char[] delimitChar= new char[]{'='};
            stringTo[0]="current_directory";//currenty_directory=
            stringTo[1]="preset_path";
            stringTo[2]="no_delete_path";
            stringTo[3] = "stills_path";
            stringTo[4] = "out_path";
            string fileloc = Environment.ExpandEnvironmentVariables(filepath);

            try
            {
                File.ReadLines(fileloc);
            }
            catch (Exception errStr)
            {
                popup.msg(errStr.Message);
                return false;
            }

            int i=0;
            
            foreach (string line in File.ReadLines(fileloc))
            {
                i = 0;
                while(i<stringTo.Length)
                {
                    
                    if (line.Contains(stringTo[i]))
                    {
                        
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
                                case 3:
                                    stillsPath=tempArr[1];
                                    break;
                                case 4:
                                    outPath=tempArr[1];
                                    break;
                                default:
                                    break;
                            }
                    
                    }
                    i++;
                }      
            }

            return true;
        }


        public static string[] getFiles(string dir)
        {
            if (dir=="")
            {
                //stub for getting default directory.
            }
            try
            {
                string[] testflist = Directory.GetFiles(dir);
            }
            catch (Exception errStr)
            {
                popup.msg(errStr.Message);
                string[] emptyArr = new string[0];
                return emptyArr;
            }
            string[] flist = Directory.GetFiles(dir);
            return flist;
        } 

        public static bool deleteFiles(string fname)
        {

            foreach (string tmpStr in noDelList)
            {
                string evalStr = Environment.ExpandEnvironmentVariables(tmpStr);
                if (fname.Contains(evalStr))
                {
                    popup.msg("Error deleting file: " + evalStr + "\nFile is in a location that should not be deleted.");
                    return false;
                }
            }
            try
            {
                File.Delete(fname);
            }
            catch (Exception errStr)
            {
                popup.msg(errStr.Message);
                return false;
            }
            return true;
        }

        public static bool copyFiles(string from, string to, bool overwrite=true)
        {
            try
            {
                File.Copy(from, to, overwrite);
            }
            catch (Exception errStr)
            {
                popup.msg(errStr.Message);
                return false;
            }
            return true;
        }


    }
}
