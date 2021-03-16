using System;
using System.IO;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            // Console - Convert HTML file to one-page PDF file.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            // Set "Edge mode" to support all modern CSS.
            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            v.PageStyle.PageOrientation.Portrait();

            string inpFile = @"https://nationalzoo.si.edu";
            FileInfo outFile = new FileInfo("Result.pdf");

            byte[] image = v.ConvertHtmlFileToImageStream(inpFile, SautinSoft.PdfVision.eImageFormat.Png);
            int ret = -1;

            if (image != null)
            {
                v.PageStyle.PageSize.Auto();
                ret = v.ConvertImageStreamToPDFFile(image, outFile.FullName);
            }

            // 0 - converting successfully
            // 1 - can't open input file, check the input path
            // 2 - can't create output file, check the output path
            // 3 - converting failed
            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
