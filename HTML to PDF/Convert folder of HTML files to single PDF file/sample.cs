using System;
using System.IO;
using System.Collections.Generic;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert folder of HTML files to single PDF file.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            // Set "Edge mode" to support all modern CSS.
            SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

            v.PageStyle.PageOrientation.Portrait();
            v.PageStyle.PageSize.Letter();
            v.PageStyle.PageMarginLeft.Mm(20);
            v.PageStyle.PageMarginBottom.Mm(20);
            v.PageStyle.PageMarginTop.Mm(15);

            string directoryWithHTMLs = Path.GetFullPath(@"..\..\");
            FileInfo singlePdf = new FileInfo(@"Result.pdf");

            // Convert each HTML file from directory to a PDF file.
            string[] htmlFiles = Directory.GetFiles(directoryWithHTMLs, "*.htm*");
            List<byte[]> pdfInventory = new List<byte[]>();

            foreach (string htmlFile in htmlFiles)
            {
                pdfInventory.Add(v.ConvertHtmlFileToPDFStream(htmlFile));
            }

            // Merge all PDFs into a single PDF file.
            try
            {
                File.WriteAllBytes(singlePdf.FullName, v.MergePDFStreamArrayToPDFStream(pdfInventory));
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(singlePdf.FullName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
