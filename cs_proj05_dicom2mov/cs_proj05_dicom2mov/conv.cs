using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dicom.Imaging;
using NReco.VideoConverter;
using System.Windows.Forms;
using System.Threading;

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
                // render each frame as png
                image.RenderImage(i).Save(pngTempDir + i.ToString(fmt) + ".png");
            }
        }

        // extract all frames from a .dcm file
        // overloaded for use with progress bar
        public static void dcm_to_png(string dcmFile, string pngTempDir, ProgressWindow progform)
        {
            var image = new DicomImage(dcmFile);
            int frames = image.NumberOfFrames;

            // number format, making sure its prefixed with appropriate number of zeros
            // currently guarantees a four digit number 
            // (dont think ive see dicom files with thousands of frames?)
            string fmt = "0000";
            
            for (int i = 0; i < frames; i++)
            {
                // render each frame as png
                image.RenderImage(i).Save(pngTempDir + i.ToString(fmt) + ".png");
                
                int iout = (((i+1)*100)/frames);
                
                progform.setProgress(iout);
            }
        }

        // convert directory of png images to video
        public static Boolean png_to_mp4(string pngTempDir, string outFile, string fps="4")
        {

            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            var outS = new NReco.VideoConverter.ConvertSettings();
            outS.CustomInputArgs = "-framerate " + fps;
            outS.CustomInputArgs = "-y " + outS.CustomInputArgs;
            outS.VideoFrameSize=sys.convsettings["size"];

            /* Got NReco to work a few notes:
             * 1) %05d is the bash syntax for a number that's padded with 0's for 5 digits. i.e. 00349
             * 2) ffmpeg only looks for stills with the file number of 0~4. ie. imagename000.png. If it doesn't find it, it gives "file not found" error.
             * 3) NReco can be found in the folder.
             * conv.convert(); in program to call.
             */
                        
            ffMpeg.ConvertMedia(pngTempDir + @"%04d.png", "image2", outFile + @"."+sys.convsettings["format"], sys.convsettings["format"], outS);

            return false;
        }

        // convert directory of png images to video
        // overloaded for use with progress bar
        public static void png_to_mp4(string pngTempDir, string outFile, ProgressWindow progform ,string fps = "4")
        {


            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            var outS = new NReco.VideoConverter.ConvertSettings();
            outS.CustomInputArgs = "-framerate " + fps;
            outS.CustomInputArgs = "-y " + outS.CustomInputArgs;
            outS.VideoFrameSize = sys.convsettings["size"];
            
            //outS.VideoFrameRate = 10;
            /* Got NReco to work a few notes:
             * 1) %05d is the bash syntax for a number that's padded with 0's for 5 digits. i.e. 00349
             * 2) ffmpeg only looks for stills with the file number of 0~4. ie. imagename000.png. If it doesn't find it, it gives "file not found" error.
             * 3) NReco can be found in the folder.
             * conv.convert(); in program to call.
             */

            ffMpeg.ConvertProgress += (o, args) => progHandler(o, args, progform);
            
            // actual conversion command
            ffMpeg.ConvertMedia(pngTempDir + @"%04d.png", "image2", outFile + @"." + sys.convsettings["format"], sys.convsettings["format"], outS);

            progform.setProgress(100);
            progform.Update();
        }

        // progress bar handler to update percentages 
        static void progHandler(object o, ConvertProgressEventArgs args, ProgressWindow progform)
        {
            int prog= (int) (100 * (args.Processed.TotalSeconds / args.TotalDuration.TotalSeconds));

            progform.BeginInvoke(new Action(() => {
                //you might think this is a bug. No, this is intentional. Due to the way MS implemented events and progressbar class
                //if the events and/or update goes too fast, the bar not draw the updates. Even after you've slept the process.
                // so this is set as is to make sure that the process *ends* with 100 for the end user. If you want to be a purist
                //prog is set to the proper percentage.
                // *note* --- args.Processed= 00:00:22.7500000/22.75, args.TotalDuration= 00:00:22.7500000/22.75, ((processed*100)/totalduration)=103 ---
                //--- args.Processed= 00:00:22.7500000/22.75, args.TotalDuration= 00:00:22.7500000/22.75, 100 *(processed/totalduration)=100 ---
                //because microsoft.
                progform.setProgress(100); 
                
                progform.Update();
                }));

            Console.WriteLine(String.Format("--- args.Processed= " + args.Processed + "/" + args.Processed.TotalSeconds + ", args.TotalDuration= " + args.TotalDuration + "/" + args.TotalDuration.TotalSeconds.ToString() + ", ((processed*100)/totalduraction)=" + prog + " ---"));
        }

        // conversion routine: one dcm = one scan
        public static void convert(string dicomScan, string framerate = "4")
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
            png_to_mp4(tempScanDirectory, sys.outPath + dicomScan.Replace(@"\",""), framerate.ToString());

            // cleanup temp files
            //Directory.Delete(tempScanDirectory, true);
        }

        public static void convert(string dicomScan, ProgressWindow progform, string framerate = "4")
        {
            // check and create temp directory 
            string tempScanDirectory = sys.stillsPath + dicomScan + @"\";
            if (!Directory.Exists(tempScanDirectory))
            {
                Directory.CreateDirectory(tempScanDirectory);
            }

            // uses all defined paths + name of the dicom directory
            progform.progtext("Getting DICOM stills.");
            Application.DoEvents();
            dcm_to_png(sys.dicomsPath + dicomScan, tempScanDirectory, progform);
            progform.progtext("Converting stills to movie file.");
            Application.DoEvents();
            png_to_mp4(tempScanDirectory, sys.outPath + dicomScan.Replace(@"\", ""), progform, framerate.ToString());

            // cleanup temp files
            //Directory.Delete(tempScanDirectory, true);
        }
    }
}
