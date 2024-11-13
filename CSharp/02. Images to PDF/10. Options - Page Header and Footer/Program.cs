using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            PageHeaderAndFooter();
        }
        public static void PageHeaderAndFooter()
        {
            string inpFile = Path.GetFullPath(@"..\..\..\image-png.png");
            string outFile = new FileInfo(@"Result.pdf").FullName;
			// Before starting, we recommend to get a free 100-day key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();

            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.A3;
            options.PageSetup.Orientation = Orientation.Landscape;
            options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(20f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Right = LengthUnitConverter.ToPoint(10f, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Bottom = LengthUnitConverter.ToPoint(30f, LengthUnit.Millimeter);

            // You can add any single-line text into top and bottom of the pages using these properties:
            options.PageNumbering.PageNumbersInTop = "This is a simple document Header!";
            options.PageNumbering.Aligment = HorizontalAlignment.Left;
            options.PageNumbering.FontFamily = PdfStandardFonts.HelveticaOblique;
            options.PageNumbering.FontSize = 28;
           

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
