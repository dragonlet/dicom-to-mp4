using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace cs_proj05_dicom2mov
{
    class cmd
    {


        public static Dictionary<string, List<string>> paramParse(string[] args){
            Dictionary<string, List<string>> parseParam= new Dictionary<string, List<string>>();
            if (args.Length <= 0)
            {
                return parseParam;
            }

            List<string> tempList = new List<string>();
            string name="";
            int i=0;
            int max=args.Length;
            foreach (string tempstr in args){
                if (i==0 && tempstr.Length >0 && tempstr.LastIndexOf('-') >= 0)
                {
                    name=noDash(tempstr);
                }
                
                if (tempstr.LastIndexOf('-') == -1)
                {
                    tempList.Add(tempstr);


                }
                if (i==(max-1) || (tempstr.LastIndexOf('-') >= 0 && i>0))
                {
                    parseParam.Add(name, tempList);
                    tempList = new List<string>();
                    name = noDash(tempstr);
                }
                i++;
            }
            
            return parseParam;
        }

        public static string noDash(string str){
            return str.Substring(str.LastIndexOf('-') + 1); ;
        }

        public static string main(string[] args)
        {
            string rtrnstr = "";
            if (args.Length <= 0)
            {
                return "No arguements provided";
            }

            var cmdparams = paramParse(args);

            if(!cmdparams.ContainsKey("cmd")){

                return "No Command specified";
            }
            List<string> cmd = cmdparams["cmd"];

            if (cmd.Count != 1)
            {
                return "number of cmd parameters invalid";
            }

            switch (cmd[0])
            {
                case "convert":

                    if(!cmdparams.ContainsKey("files")||cmdparams["files"].Count<=0){
                        return "No filenames provided";
                        break;
                    }

                    if (!cmdparams.ContainsKey("preset") || cmdparams["preset"].Count != 1)
                    {
                        return "No presets selected";
                        break;
                    }

                    sys.getPresets(sys.presetPath + cmdparams["preset"][0]);

                    int index = 0;
                    int max=cmdparams["files"].Count;
                    Console.WriteLine("max=" + max);
                    string filename = cmdparams["files"][index];
                    Console.WriteLine(File.Exists(filename));
                    while (index < max && File.Exists(sys.dicomsPath + filename))
                    {
                        Console.WriteLine("Converting " + filename + "...");
                        conv.convert(filename);
                        Console.WriteLine("Converting " + filename + " Done!");
                        index++;
                    }
                    break;
                case "listDicoms":
                    string[] dcmFiles = sys.getFiles(sys.dicomsPath);
                    foreach (string dcmfile in dcmFiles)
                    {
                        Console.WriteLine(dcmfile);

                    }
                    break;
                case "listPresets":
                    string[] prstFiles = sys.getFiles(sys.presetPath);
                    foreach (string prst in prstFiles)
                    {
                        Console.WriteLine(prst);

                    }
                    break;
                default:
                    break;
            }


            return rtrnstr;
        }

    }
}
