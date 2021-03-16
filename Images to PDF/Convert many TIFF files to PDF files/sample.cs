using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert many TIFF files to PDF files.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            DirectoryInfo inpFolder = new DirectoryInfo(@"..\..\");
            FileInfo[] inpFiles = inpFolder.GetFiles(@"*.tif*");
            DirectoryInfo outFolder = new DirectoryInfo(Directory.GetCurrentDirectory()).CreateSubdirectory("Results");

            foreach (FileInfo inpFile in inpFiles)
            {
                string pdfFile = Path.GetFileNameWithoutExtension(inpFile.FullName) + ".pdf";
                pdfFile = Path.Combine(outFolder.FullName, pdfFile);
                v.ConvertImageFileToPDFFile(inpFile.FullName, pdfFile);
            }
            // Open the resulting folder with the PDF documents.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFolder.FullName) { UseShellExecute = true });
        }
    }
}