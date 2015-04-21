using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace cs_proj05_dicom2mov
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {


            if (args.Length >= 1)
            {
                var cmdParams = cmd.paramParse(args); 
                //Dictionary<string, List<string>>. Call via hash of array.
                //i.e. cs_proj05_dicom2mov.exe -name1 val1 val2 --name2 val3 val4 val5
                // cmdParams["name1"][0] == val1
                // cmdParams["name2"][2] == val5
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
