using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NReco.VideoConverter;

namespace cs_proj05_dicom2mov
{
    class conv
    {

        static conv()
        {

        }

        public static Boolean convert()
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
            ffMpeg.ConvertMedia(@"C:\Users\sleepingkirby\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\jpegs\akfg%05d.png", "image2", @"C:\Users\sleepingkirby\Documents\philips-15.5\cs_proj05_dicom2mov\appdata\mov\test.mp4", "mp4", outS);
            return false;
        }
    }
}
