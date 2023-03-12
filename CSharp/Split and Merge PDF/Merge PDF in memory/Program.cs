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
            MergePdfInMemory();
        }
        public static void MergePdfInMemory()
        {
            PdfVision v = new PdfVision();
            // The whole merge process will be done in memory.
            // We're using files only to get input data and show the result.
            string[] inpFiles = new string[] {@"..\..\..\simple text.pdf", @"..\..\..\table.pdf"};
            string outFile = new FileInfo("Result.pdf").FullName;

            // Get bytes from input pdf documents.
            List<byte[]> mergingPdf = new List<byte[]>();
            foreach (string inpFile in inpFiles)
                mergingPdf.Add(File.ReadAllBytes(inpFile));

            // Merge PDF documents in memory into single document.
            byte[] singlePdf = v.MergePdf(mergingPdf);

            if (singlePdf!= null)
            {
                File.WriteAllBytes(outFile, singlePdf);
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
        }
    }
}
