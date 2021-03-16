using System;
using System.IO;
using System.Drawing;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert Image class to PDF file			
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            //specify converting options
            v.PageStyle.PageSize.Auto();

            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            // Create object of Image class from file
            System.Drawing.Image image = Image.FromFile(@"..\..\image-jpeg.jpg");
            FileInfo outFile = new FileInfo(@"Result.pdf");

            byte[] imgBytes = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgBytes = ms.ToArray();
            }

            // Convert image stream to PDF file
            int ret = v.ConvertImageStreamToPDFFile(imgBytes, outFile.FullName);
            if (ret == 0)
            {
             // Open the resulting PDF document in a default PDF Viewer.
             System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
