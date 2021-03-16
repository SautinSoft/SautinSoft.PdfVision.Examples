using System;
using System.IO;

namespace Sample
{
    class Test
    {

        static void Main(string[] args)
        {
            // Convert ASPX page to PDF file.	 
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            // Set "Edge mode" to support all modern CSS.
            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // Specify some options.
            v.PageStyle.PageSize.Letter();
            v.PageStyle.PageOrientation.Landscape();
            v.PageStyle.PageNumbers.PageNumbersInBottom = "Page {page} of {numpages}";
            v.PageStyle.PageNumbers.Aligment.Right();
            v.PageStyle.PageNumbers.FontSize = 16;
            v.PageStyle.PageNumbers.FontColor.SetRGB(30, 30, 30);
            v.PageStyle.PageNumbers.MarginFromStart.Mm(20);

            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            // Convert ASPX page to PDF file.
            string inpUrl = @"https://www.sautinsoft.net/default.aspx";
            FileInfo outFile = new FileInfo("Result.pdf");
            
            int ret = v.ConvertHtmlFileToPDFFile(inpUrl, outFile.FullName);

            // 0 - converting successfully.
            // 1 - can't open input file, check the input path.
            // 2 - can't create output file, check the output path.
            // 3 - converting failed.
            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
