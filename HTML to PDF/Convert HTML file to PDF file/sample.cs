using System;
using System.IO;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert HTML file/url to PDF file.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // Specify the conversion options.
            v.PageStyle.PageSize.Auto();
            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            // Specify top and bottom page margins.
            //v.PageStyle.PageMarginTop.Mm(5f);
            //v.PageStyle.PageMarginBottom.Mm(5f);

            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            string inpUrl = @"https://nationalzoo.si.edu/";
            FileInfo outFile = new FileInfo(@"Result.pdf");

            int ret = v.ConvertHtmlFileToPDFFile(inpUrl, outFile.FullName);

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
