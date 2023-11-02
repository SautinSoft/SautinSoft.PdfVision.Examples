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
            ConvertMultipleHtmlToPdfFile();
        }
        public static void ConvertMultipleHtmlToPdfFile()
        {
            string[] inpFiles = new string[]
            {
                Path.GetFullPath(@"..\..\..\1.html"),
                Path.GetFullPath(@"..\..\..\2.html")
            };
            string outFile = new FileInfo("Result.pdf").FullName;

            PdfVision v = new PdfVision();
            
            HtmlToPdfOptions options = new HtmlToPdfOptions()
            {
                PageSetup = new PageSetup()
                {
                    PaperType = PaperType.Letter,
                    Orientation = Orientation.Portrait,
                    PageMargins = new PageMargins()
                    {
                        Left = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Top = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Right = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter),
                        Bottom = LengthUnitConverter.ToPoint(5, LengthUnit.Millimeter)
                    }
                },
                PrintBackground = true,
               	Scale = 1,
				//Set a custom directory where will be placed portable Chromium browser. 
				//Default value depends of platform (win-x64, win-86, linux-x64 or osx-x64). 
				ChromiumBaseDirectory = Path.GetFullPath(@"..\..\..\..\..\..\Chromium\")
            };

            try
            {
                List<byte[]> pdfCollection = new List<byte[]>();
                foreach (string inpFile in inpFiles)
                {
                    Console.WriteLine($"Converting {Path.GetFileName(inpFile)} ...");
                    byte[] pdfData = v.ConvertHtmlToPdf(inpFile, options);
                    pdfCollection.Add(pdfData);
                }

                // Merge PDFs into single PDF document.
                byte[] singlePdfData = v.MergePdf(pdfCollection);
                File.WriteAllBytes(outFile, singlePdfData);

                // Open the result for demonstration purposes.
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
