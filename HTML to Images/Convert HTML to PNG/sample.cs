using System;
using System.IO;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert HTML to PNG.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            // Set "Edge mode" to support all modern CSS.
            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            string inpFile = @"https://nationalzoo.si.edu";
            FileInfo outFile = new FileInfo("Result.png");

            int ret = v.ConvertHtmlFileToImageFile(inpFile, outFile.FullName, SautinSoft.PdfVision.eImageFormat.Png);

            // 0 - converting successfully
            // 1 - can't open input file, check the input path
            // 2 - can't create output file, check the output path
            // 3 - converting failed
            if (ret == 0)
            {
                // Open the produced PNG image in a default Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
