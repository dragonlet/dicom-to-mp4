using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_proj05_dicom2mov
{
    // Temporary Presets file system
    public static class fileSystem
    {
        // filePaths is the global array of (dummy) string file paths
        public static string[] filePaths = new string[5] {"c:\\Program Files\\cs_proj05_dicom2mov\\File1", "c:\\Program Files\\cs_proj05_dicom2mov\\File2",
                                                            "c:\\Program Files\\cs_proj05_dicom2mov\\File3", "c:\\Program Files\\cs_proj05_dicom2mov\\File4", 
                                                            "c:\\Program Files\\cs_proj05_dicom2mov\\File5"};
    }
    class sys
    {
        static void Main(string[] args)
        {
            // Main contains testing calls with user input for file paths, will be provided by GUI later
            
            // Copy
            Console.WriteLine("Copy file from: ");
            string fromLoc = Console.ReadLine();
            Console.WriteLine("To: ");
            string toLoc = Console.ReadLine();
            copyFile(fromLoc, toLoc);
            displayFiles(fileSystem.filePaths);

            // Delete
            Console.WriteLine("Delete file at: ");
            string target = Console.ReadLine();
            deleteFile(target);
            displayFiles(fileSystem.filePaths);        
        }

        // Description: copy file from "from" to "to"
        // IN: from, to
        // MODIFY: array of file paths in fileSystem "filePaths"
        // OUT: none
        static void copyFile(string from, string to)
        {
            // Scan array of file paths for destination, insert new path "from" 
            for (int i = 0; i < fileSystem.filePaths.Length; i++)
            {
                if (fileSystem.filePaths[i] == to)
                    { 
                        fileSystem.filePaths[i] = from;
                        break;
                    }           
            }
            
        }
        // Description: Delete file at Path
        // IN: path
        // MODIFY: array of file paths in fileSystem "filePaths"
        // OUT: none
        static void deleteFile(string path)
        {
            // Check if file exists
            for (int i = 0; i < fileSystem.filePaths.Length; i++)
            {
                if (fileSystem.filePaths[i] == path)
                {
                    fileSystem.filePaths[i] = null;
                    return;
                }
                    
                else
                    Console.WriteLine("Error: File not found at: " + path + ".");
            }
        }
        static void displayFiles(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(i + ":" + arr[i]);
            }
        }

    }
}
