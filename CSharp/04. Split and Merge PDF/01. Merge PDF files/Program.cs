using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MergePdfInFiles();
        }
        public static void MergePdfInFiles()
        {
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");
            PdfVision v = new PdfVision();
            string[] inpFiles = new string[] {@"..\..\..\simple text.pdf", @"..\..\..\table.pdf"};
            string outFile = new FileInfo("Result.pdf").FullName;

            // Merge PDF files into single document.
            int ret = v.MergePdf(inpFiles, outFile);

            // 0 - Merged successfully.
            // 1 - Error, can't merge PDF documents.
            // 2 - Error, can't create the output file, probably it used by another application.
            // 3 - Merging failed.
            // 4 - Merged successfully, but some files were not merged.
            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
        }
    }
}
