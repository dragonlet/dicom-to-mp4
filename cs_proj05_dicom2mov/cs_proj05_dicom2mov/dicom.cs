using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom;
using Dicom.Imaging;
using NReco.VideoConverter;


namespace cs_proj05_dicom2mov
{


    class dcm
    {
        /*
            dcm dcm_obj = new dcm(@"C:\Users\sleepingkirby\AppData\Roaming\dicom2mov\dicoms\IM_0016");
            Console.WriteLine(dcm_obj.patientName);
            Console.WriteLine(dcm_obj.dateOfScan);
            Console.WriteLine(dcm_obj.timeOfScan);
        */
        public string patientName;
        public string patientId;
        public string dicomFilePath;
        public string dicomFileName;
        public string dateOfScan;
        public string timeOfScan; 

        public string frameRate;
        public int frameNum;

        public string compressFormat;
        /*
ISO_10918_1 JPEG Lossy Compression
ISO_14495_1 JPEG-LS Near-lossless Compression
ISO_15444_1 JPEG 2000 Irreversible Compression
ISO_13818_2 MPEG2 Compression
ISO_14496_10 MPEG-4 AVC/H.264 Compression
         */

        public dcm(string path)
        {
            /*
            DicomFile dcm_obj = new Dicom.DicomFile();
            or DicomFile dcm_obj = DicomFile.Open(path);
            dcm_obj.Dataset.Add(DicomTag.TextString, "test");

                  string test = "hangs";
                  test = dcm_obj.Dataset.Get<string>(DicomTag.TextString);
                  Console.WriteLine("--------------------- dicom file ---------------------------");
                  Console.WriteLine(test);
              --------------------- dicom file ---------------------------
                test
      
             */

            dicomFilePath = path;
            dicomFileName = path.Substring(path.LastIndexOf('\\') + 1);

            var image = new DicomImage(path);
            frameNum = image.NumberOfFrames;

            DicomFile dcm_obj = DicomFile.Open(path);

            patientName = dcm_obj.Dataset.Get<string>(DicomTag.PatientName);
            frameRate = dcm_obj.Dataset.Get<string>(DicomTag.CineRate);
            patientId = dcm_obj.Dataset.Get<string>(DicomTag.PatientID);
            dateOfScan = dcm_obj.Dataset.Get<string>(DicomTag.InstanceCreationDate);
            timeOfScan = dcm_obj.Dataset.Get<string>(DicomTag.InstanceCreationTime);
            compressFormat = compFormat(dcm_obj.Dataset.Get<string>(DicomTag.LossyImageCompressionMethod));

        }

        string compFormat(string str)
        {
            if (str == "")
                return "";

            /*
             * ISO_10918_1 JPEG Lossy Compression
ISO_14495_1 JPEG-LS Near-lossless Compression
ISO_15444_1 JPEG 2000 Irreversible Compression
ISO_13818_2 MPEG2 Compression
ISO_14496_10 MPEG-4 AVC/H.264 Compression
             */

            switch (str)
            {
                case "ISO_10918_1":
                    return "jpeg";
                case "ISO_14495_1":
                    return "jpeg-ls";
                case "ISO_15444_1":
                    return "jpeg 2000";
                case "ISO_13818_2":
                    return "mpeg2";
                case "ISO_14496_10":
                    return "mp4 avc/h.264";
                default:
                    return "no compression";
            }

        }

        public override string ToString()
        {
            return patientName + " - " + dateOfScan + " - " + timeOfScan + " |" + dicomFileName;
        }
    }
}
