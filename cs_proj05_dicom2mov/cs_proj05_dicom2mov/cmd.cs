using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (i==0 && name.Length >0 && tempstr.LastIndexOf('-') >= 0)
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

    }
}
