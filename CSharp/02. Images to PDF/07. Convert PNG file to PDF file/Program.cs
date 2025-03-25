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
            ConvertPngToPdf();
        }
        public static void ConvertPngToPdf()
        {
            string inpFile = Path.GetFullPath(@"..\..\..\image-png.png");
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.A3;
            options.PageSetup.Orientation = Orientation.Landscape;
            options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Right = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Bottom = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);

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
