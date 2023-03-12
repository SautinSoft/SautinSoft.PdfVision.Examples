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
            ConvertImagesToPdfInMemory();
        }
        public static void ConvertImagesToPdfInMemory()
        {
            // We'll use files here only to get input data and show the PDF result.
            // The converting process will be done completely in memory.
            string[] inpFiles = new string[]
            {
                @"..\..\..\testing\image-jpeg.jpg",
                @"..\..\..\testing\image-png.png",
                @"..\..\..\testing\image-tiff.tiff",
                @"..\..\..\testing\multipage.tiff"
            };
            string outFile = new FileInfo(@"Result.pdf").FullName;

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Letter;

            List<byte[]> imageBytesCollection = new List<byte[]>();
            foreach (string inpFile in inpFiles)
                imageBytesCollection.Add(File.ReadAllBytes(inpFile));

            try
            {
                byte[] pdfDocument = v.ConvertImageToPdf(imageBytesCollection, options);
                File.WriteAllBytes(outFile, pdfDocument);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
