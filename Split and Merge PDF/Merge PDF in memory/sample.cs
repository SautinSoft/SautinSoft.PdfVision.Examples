using System;
using System.IO;
using System.Collections.Generic;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {

            // Merge PDF in memory
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // merge two PDF files
            string[] inpFiles = new string[] { @"..\..\simple text.pdf", @"..\..\table.pdf" };
           
            FileInfo outFile = new FileInfo("Result.pdf");

            List<byte[]> inpFilesByte = new List<byte[]>();

            // Fill the pdfBytesList.
            foreach (string inpFile in inpFiles)
                inpFilesByte.Add(File.ReadAllBytes(inpFile));

            byte[] pdfBytes = v.MergePDFStreamArrayToPDFStream(inpFilesByte);

            if (pdfBytes != null)
            {
                File.WriteAllBytes(outFile.FullName, pdfBytes);
				// Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
