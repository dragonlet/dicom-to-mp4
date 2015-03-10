using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dicom.Imaging;
using NReco.VideoConverter;

namespace cs_proj05_dicom2mov
{
    class conv
    {

        // extract one jpg from one .dcm file
        public static void dcm_to_jpg(string dcmFile, string jpgFile)
        {
            var image = new DicomImage(dcmFile);
            image.RenderImage().Save(jpgFile);
        }

        // converts all dcm files in a directory to jpg
        public static void all_dcm_to_jpg(string dcmDir, string jpgTempDir)
        {
            string[] files = sys.getFiles(dcmDir + @"DICOM\");
            string filename;

            foreach(string dcm in files) {

                filename = Path.GetFileNameWithoutExtension(dcm);

                // first to check if files end with .dcm
                // but apparently Philips doesn't use file extensions for their DICOM files?
                // instead, each file starts with IM_ 
                // (should probably make "IM_" prefix a defined const somewhere)
                if (dcm.EndsWith(".dcm") || filename.StartsWith("IM_")) {
                    dcm_to_jpg(dcmDir + @"DICOM\" + dcm, jpgTempDir + filename + ".png");
                }
                
            }
        }

        // convert directory of jpg images to mp4
        public static Boolean jpg_to_mp4(string jpgTempDir, string outFile)
        {
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            var outS = new NReco.VideoConverter.ConvertSettings();
            //outS.VideoFrameCount=30;
            outS.CustomInputArgs = "-framerate 4";
            //outS.CustomOutputArgs = "-framerate 2";
            outS.VideoFrameSize=sys.convsettings["size"];
            //outS.VideoFrameRate = 10;
            /* Got NReco to work a few notes:
             * 1) %05d is the bash syntax for a number that's padded with 0's for 5 digits. i.e. 00349
             * 2) ffmpeg only looks for stills with the file number of 0~4. ie. imagename000.png. If it doesn't find it, it gives "file not found" error.
             * 3) NReco can be found in the folder.
             * conv.convert(); in program to call.
             */

            // just need to make this less hardcoded
            ffMpeg.ConvertMedia(jpgTempDir + @"IM_%04d.png", "image2", outFile + @"."+sys.convsettings["format"], sys.convsettings["format"], outS);
                              //@"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\jpegs\akfg%05d.png", "image2", @"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\mov\test.mp4", "mp4", outS);
            return false;
        }

        // conversion routine for one dicom dataset (one scan, one directory)
        // dicomScan should be a subdirectory in the sys.dicomsPath indicating 
        // a specific scan or dataset
        public static void convert(string dicomScan)
        {

            // add \ at end of scan name
            if (!dicomScan.EndsWith(@"\"))
            {
                dicomScan += @"\";
            }

            // check and create temp directory 
            string tempScanDirectory = sys.stillsPath + dicomScan;
            if (!Directory.Exists(tempScanDirectory))
            {
                Directory.CreateDirectory(tempScanDirectory);
            }

            // uses all defined paths + name of the dicom directory
            all_dcm_to_jpg(sys.dicomsPath + dicomScan, tempScanDirectory);
            jpg_to_mp4(tempScanDirectory, sys.outPath + dicomScan.Replace(@"\",""));

            // cleanup temp files
            //Directory.Delete(tempScanDirectory, true);
        }


    }
}
