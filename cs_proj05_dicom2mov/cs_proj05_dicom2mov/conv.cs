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

        // extract all frames from a .dcm file
        public static void dcm_to_png(string dcmFile, string pngTempDir)
        {
            var image = new DicomImage(dcmFile);
            int frames = image.NumberOfFrames;

            // number format, making sure its prefixed with appropriate number of zeros
            // currently guarantees a four digit number 
            // (dont think ive see dicom files with thousands of frames?)
            string fmt = "0000";

            for (int i = 0; i < frames; i++)
            {
                // render each frame as a jpg
                image.RenderImage(i).Save(pngTempDir + i.ToString(fmt) + ".png");
            }
        }

        // convert directory of png images to video
        public static Boolean png_to_mp4(string pngTempDir, string outFile, string fps="4")
        {
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            var outS = new NReco.VideoConverter.ConvertSettings();
            outS.CustomInputArgs = "-framerate " + fps;
            outS.VideoFrameSize=sys.convsettings["size"];
            //outS.VideoFrameRate = 10;
            /* Got NReco to work a few notes:
             * 1) %05d is the bash syntax for a number that's padded with 0's for 5 digits. i.e. 00349
             * 2) ffmpeg only looks for stills with the file number of 0~4. ie. imagename000.png. If it doesn't find it, it gives "file not found" error.
             * 3) NReco can be found in the folder.
             * conv.convert(); in program to call.
             */

            // just need to make this less hardcoded
            ffMpeg.ConvertMedia(pngTempDir + @"%04d.png", "image2", outFile + @"."+sys.convsettings["format"], sys.convsettings["format"], outS);
                              //@"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\jpegs\akfg%05d.png", "image2", @"C:\Users\ajw\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\mov\test.mp4", "mp4", outS);
            return false;
        }

        // conversion routine: one dcm = one scan
        public static void convert(string dicomScan)
        {
            // dicomScan will either be the dicomObj passed in or will grab info from global

            // check and create temp directory 
            string tempScanDirectory = sys.stillsPath + dicomScan + @"\";
            if (!Directory.Exists(tempScanDirectory))
            {
                Directory.CreateDirectory(tempScanDirectory);
            }

            // uses all defined paths + name of the dicom directory
            dcm_to_png(sys.dicomsPath + dicomScan, tempScanDirectory);
            png_to_mp4(tempScanDirectory, sys.outPath + dicomScan.Replace(@"\",""));

            // cleanup temp files
            //Directory.Delete(tempScanDirectory, true);
        }
    }
}
