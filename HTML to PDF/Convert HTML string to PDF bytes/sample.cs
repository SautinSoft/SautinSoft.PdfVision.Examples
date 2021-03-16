using System;
using System.IO;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert HTML string to PDF bytes.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // Set "Edge mode" to support all modern CSS.
            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            // Specify some converting options.
            v.PageStyle.PageSize.Auto();
            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            // Specify top and bottom page margins
            v.PageStyle.PageMarginTop.Mm(5f);
            v.PageStyle.PageMarginBottom.Mm(5f);

            string inpHtml = "<html><body><p style=\"text-align: center; font-size: 45px;\">Hello my Friend!</p></body></html>";

            // Convert HTML string to PDF bytes.
            byte[] pdfBytes = v.ConvertHtmlStringToPDFStream(inpHtml);

            // Save PDF data to a file and open it for demonstration purposes.
            if (pdfBytes != null)
            {
                FileInfo outFile = new FileInfo(@"Result.pdf");

                using (FileStream fs = new FileStream(outFile.FullName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(pdfBytes, 0, pdfBytes.Length);
                }
				// Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
