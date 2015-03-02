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
        public static string dicomsPath;
        public static IDictionary<string, string> convsettings;

        static sys()
        {
            readProgConf();

        }

        public static IDictionary<string, string> getPresets(string fpath)
        {
            if (fpath == "")
            {
                return null;
            }

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
                popup.msg("sys.getPresets had an error trying to open "+fileloc+"\n Returned error: "+errStr.Message);
                return null;
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
                                convsettings["size"] = tempArr[1];
                                break;
                            case 1:
                                convsettings["format"] = tempArr[1];
                                break;
                            default:
                                break;
                        }

                    }
                    i++;
                }
            }
            return convsettings;
        }


        public static bool readProgConf(string filepath = "%APPDATA%\\dicom2mov\\conf.ini")
        {
            
            string[] stringTo= new string[6];
            char[] delimitChar= new char[]{'='};
            stringTo[0]="current_directory";//currenty_directory=
            stringTo[1]="preset_path";
            stringTo[2]="no_delete_path";
            stringTo[3] = "stills_path";
            stringTo[4] = "out_path";
            stringTo[5] = "dicoms_path";


            string fileloc = Environment.ExpandEnvironmentVariables(filepath);
            try
            {
                File.ReadLines(fileloc);
            }
            catch (Exception errStr)
            {
                popup.msg("sys.readProfConf had an error opening "+fileloc+". \nReturned error: "+errStr.Message);
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
                                    cwd = Environment.ExpandEnvironmentVariables(tempArr[1]);
                                    break;
                                case 1:
                                    presetPath = Environment.ExpandEnvironmentVariables(tempArr[1]);
                                    break;
                                case 2:
                                    if (tempArr[1] != "") {
                                        noDelList.Add(Environment.ExpandEnvironmentVariables(tempArr[1]));                                        
                                    }
                                    break;
                                case 3:
                                    stillsPath=Environment.ExpandEnvironmentVariables(tempArr[1]);
                                    break;
                                case 4:
                                    outPath=Environment.ExpandEnvironmentVariables(tempArr[1]);
                                    break;
                                case 5:
                                    dicomsPath = Environment.ExpandEnvironmentVariables(tempArr[1]);
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
            string dirpath = Environment.ExpandEnvironmentVariables(dir);
            if (dir=="")
            {
                //stub for getting default directory.
            }
            try
            {
                string[] testflist = Directory.GetFiles(dirpath);
            }
            catch (Exception errStr)
            {
                popup.msg("getFiles had an error getting files under: "+dirpath+"\n returned error: "+errStr.Message);
                string[] emptyArr = new string[0];
                return emptyArr;
            }
            string[] flist = Directory.GetFiles(dirpath);

            int max = flist.Length;
            int i = 0;
            
            while (i < max)
            {
                flist[i] = Path.GetFileName(flist[i]);
                i++;
            }

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

            string tof=Environment.ExpandEnvironmentVariables(to);
            string fromf=Environment.ExpandEnvironmentVariables(from);
            try
            {
                File.Copy(fromf, tof, overwrite);
            }
            catch (Exception errStr)
            {
                popup.msg("copyFile reported an error trying to copy from "+fromf+" to "+tof+"\n returned error: "+errStr.Message);
                return false;
            }
            return true;
        }


    }
}
