using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Dicom.Imaging;
using NReco.VideoConverter;

namespace cs_proj05_dicom2mov
{
    public partial class ProgressWindow : Form
    {
        BackgroundWorker bgWorker;
        public ProgressWindow(CheckedListBox.CheckedItemCollection list)
        {
            InitializeComponent();
            
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(job);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(done);
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            //popupcancel.Enabled = true;

            // Kickoff the worker thread to begin it's DoWork function.
            //bgWorker.RunWorkerAsync(list);
            
        }

        public string textbox(string str){

            popuplabel.Text=str;
            return str;
        }

        public int progBarVal()
        {

            return progressBar1.Value;
        }

        public string progtext(string str)
        {

            popupprogtext.Text = str;
            return str;
        }

        public void progressbar(int i)
        {

            progressBar1.Increment(i);
        }

        public void setProgress(int i)
        {

            progressBar1.Value=i;
        }
        public void progBarMax()
        {

            progressBar1.Value = 1;
            progressBar1.Maximum = 1;
        }

        public void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            /*
             * why am I decrementing the maximum rather than filling the value? Apparently because this is how the progress bar works
             * correctly in WinXP+
             * http://stackoverflow.com/questions/977278/how-can-i-make-the-progress-bar-update-fast-enough
             */
            //progressBar1.Value = e.ProgressPercentage;
            progressBar1.Maximum = 100;
            progressBar1.Value = e.ProgressPercentage;
            
            popuplabel.Text = e.ProgressPercentage.ToString() + "%";
           

        }
        public void done(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                popuplabel.Text = "Task Cancelled.";
                Application.DoEvents();
                Thread.Sleep(1000);
                this.Close();
                
            }
            else if (e.Error != null)
            {
                popuplabel.Text = "Error while performing background operation.";
                
            }
            else
            {
                // Everything completed normally.
                popuplabel.Text = "Task Completed...";
                
            }
            progressBar1.Update();
            //Change the status of the buttons on the UI accordingly
            //popupcancel.Enabled = false;

            if (progressBar1.Value == progressBar1.Value)
            {
                progressBar1.Update();
                Application.DoEvents();
                Thread.Sleep(1000);
                this.Close();
            }
        }

        void job(object sender, DoWorkEventArgs e)
        {
            // The sender is the BackgroundWorker object we need it to
            // report progress and check for cancellation.
            //NOTE : Never play with the UI thread here...
            CheckedListBox.CheckedItemCollection checklist = (CheckedListBox.CheckedItemCollection) e.Argument;
            foreach(object file in checklist )
            {


                string toPass = file.ToString();
                
                string dicomScan = toPass.Substring(toPass.LastIndexOf('|') + 1);

                string tempScanDirectory = sys.stillsPath + dicomScan + @"\";
                if (!Directory.Exists(tempScanDirectory))
                {
                    Directory.CreateDirectory(tempScanDirectory);
                }

                string pngTempDir=tempScanDirectory;
                
               
                var image = new DicomImage(sys.dicomsPath + dicomScan);
                int frames = image.NumberOfFrames;

                // number format, making sure its prefixed with appropriate number of zeros
                // currently guarantees a four digit number 
                // (dont think ive see dicom files with thousands of frames?)
                string fmt = "0000";

                for (int i = 0; i < frames; i++)
                {
                    // render each frame as a jpg
                    image.RenderImage(i).Save(pngTempDir + i.ToString(fmt) + ".png");
                    
                    bgWorker.ReportProgress((int)i*50/frames);
                }

                int fps = 4;
                string outFile = sys.outPath + dicomScan.Replace(@"\", "");
                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                var outS = new NReco.VideoConverter.ConvertSettings();
                outS.CustomInputArgs = "-framerate " + fps;
                outS.VideoFrameSize = sys.convsettings["size"];

                ffMpeg.ConvertProgress += (o, args) => {
                    bgWorker.ReportProgress((int)(args.Processed.Seconds / (args.TotalDuration.Seconds *100)));
                };


                // just need to make this less hardcoded
                ffMpeg.ConvertMedia(pngTempDir + @"%04d.png", "image2", outFile + @"." + sys.convsettings["format"], sys.convsettings["format"], outS);
                
                


                if (bgWorker.CancellationPending)
                {
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    bgWorker.ReportProgress(0);
                    return;
                }
            }

            //Report 100% completion on operation completed
            bgWorker.ReportProgress(100);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {

                // Notify the worker thread that a cancel has been requested.

                // The cancel will not actually happen until the thread in the

                // DoWork checks the m_oWorker.CancellationPending flag. 

                bgWorker.CancelAsync();
            }
        }
        private void closeform(string str, int time = 10000)
        {
            popuplabel.Text = str;
            Thread.Sleep(time);
            this.Close();

        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {

        }

        /*
        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            //Change the status of the buttons on the UI accordingly
            //The start button is disabled as soon as the background operation is started
            //The Cancel button is enabled so that the user can stop the operation 
            //at any point of time during the execution
            //btnStartAsyncOperation.Enabled = false;
            popupcancel.Enabled = true;

            // Kickoff the worker thread to begin it's DoWork function.
            bgWorker.RunWorkerAsync();
        }
        */

    }
    
}
