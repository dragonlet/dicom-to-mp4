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

        // extract jpg from a .dcm file
        public static void dcm_to_jpg(string dcmFile, string jpgFile)
        {
            var image = new DicomImage(dcmFile);
            image.RenderImage().Save(jpgFile);
        }

        // converts all dcm files in a directory to jpg,
        public static void all_dcm_to_jpg(string dcmDir, string jpgTempDir)
        {
            string[] files = sys.getFiles(dcmDir);
            string filename;

            foreach(string dcm in files) {

                if (dcm.EndsWith(".dcm")) { // did not like finding OSX hidden file .DS_Store!
                    filename = Path.GetFileNameWithoutExtension(dcm);
                    dcm_to_jpg(dcm, jpgTempDir + filename + ".jpg");
                }
                
            }
        }

        public static Boolean jpg_to_mp4(string jpgTempDir, string outFile)
        {
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            var outS = new NReco.VideoConverter.ConvertSettings();
            outS.VideoFrameCount=30;
            outS.VideoFrameSize="640x480";
            /* Got NReco to work a few notes:
             * 1) %05d is the bash syntax for a number that's padded with 0's for 5 digits. i.e. 00349
             * 2) ffmpeg only looks for stills with the file number of 0~4. ie. imagename000.png. If it doesn't find it, it gives "file not found" error.
             * 3) NReco can be found in the folder.
             * conv.convert(); in program to call.
             */

            // just need to generalize the pathnames
            ffMpeg.ConvertMedia(@"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\jpegs\akfg%05d.png", "image2", @"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\mov\test.mp4", "mp4", outS);
            return false;
        }

        // overall conversion process
        public static void convert()
        {
            // 'should' work, if extra path info is added to the dicomsPath..would be parameter passed in to convert()
            // commented out to play with test pngs and video creation
            //all_dcm_to_jpg(sys.dicomsPath, sys.stillsPath);
            jpg_to_mp4(sys.stillsPath, sys.outPath);
        }
    }
}
