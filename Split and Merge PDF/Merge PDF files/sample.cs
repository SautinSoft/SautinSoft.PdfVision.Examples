using System;
using System.IO;
using System.Collections;


namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Merge PDF files.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // Let's merge several PDF files.
            string[] inpFiles = new string[] { @"..\..\simple text.pdf", @"..\..\table.pdf" };
            FileInfo outFile = new FileInfo(@"Result.pdf");

            int ret = v.MergePDFFileArrayToPDFFile(inpFiles, outFile.FullName);

            // 0 - Merged successfully.
            // 1 - Error, can't merge PDF documents.
            // 2 - Error, can't create the output file, probably it used by another application.
            // 3 - Merging failed.
            // 4 - Merged successfully, but some files were not merged.
            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
