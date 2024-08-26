using System;
using System.IO;
using SautinSoft.PdfVision;
using System.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertMultipageTiffToPdf();
        }
        public static void ConvertMultipageTiffToPdf()
        {
            string inpFile = Path.GetFullPath(@"..\..\..\multipage.tiff");
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Letter;
            options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(1, LengthUnit.Inch);

            try
            {
                v.ConvertImageToPdf(new string[] {inpFile}, outFile, options);
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
