using System;
using System.IO;
using System.Collections.Generic;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert images to PDF in memory			 			
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            // v.Serial = "XXXXXXXXXXXXXXX";

            // specify converting options
            v.PageStyle.PageSize.Auto();

            // v.PageStyle.PageMarginLeft.Inch(1);
            // v.ImageStyle.Heightmm(150);
            // v.ImageStyle.WidthInch(10);			

            // Create array containing paths to different images
            string[] imgFiles = new string[4]
            { @"..\..\image-jpeg.jpg",
              @"..\..\image-png.png",
              @"..\..\image-tiff.tiff",
              @"..\..\multipage.tiff"};

            List<byte[]> imgBytesList = new List<byte[]>();

            foreach (string imgFile in imgFiles)
                imgBytesList.Add(File.ReadAllBytes(imgFile));

            // Convert the List with image bytes to PDF bytes in memory.
            byte[] pdfBytes = v.ConvertImageStreamArrayToPDFStream(imgBytesList);
            if (pdfBytes != null)
            {
                // Save the PDF document (pdfBytes) to a file for demonstration purposes.
                FileInfo outFile = new FileInfo(@"Result.pdf");
                File.WriteAllBytes(outFile.FullName, pdfBytes);

                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
