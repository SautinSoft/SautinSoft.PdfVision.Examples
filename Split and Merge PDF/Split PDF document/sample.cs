using System;
using System.IO;
using System.Collections;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Split PDF document by pages.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            string inpFile = @"..\..\simple text.pdf";
            DirectoryInfo outFolder = new DirectoryInfo(@"Pages");

            if (!outFolder.Exists)
                outFolder.Create();

            //v.Serial = "XXXXXXXXXXXXXXX";

            int ret = v.SplitPDFFileToPDFFolder(inpFile, outFolder.FullName);

            // 0 - split successfully
            // 1 - error, can't open input file
            // 2 - error, output directory doesn't exist

            if (ret == 0)
            {
                System.Console.WriteLine("Split successfully!");
				// Open the resulting folder with the PDF pages.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFolder.FullName) { UseShellExecute = true });
            }
        }
    }
}
