using System;
using System.IO;
using SautinSoft.PdfVision;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ImagePlacement();
        }
        public static void ImagePlacement()
        {
            string inpFolder = new DirectoryInfo(@"..\..\..\testing\").FullName;
            string outFile = new FileInfo(@"Horizontal.pdf").FullName;
			// Before starting, we recommend to get a free key:
            // https://sautinsoft.com/start-for-free/
            
            // Apply the key here:
			// SautinSoft.PdfVision.SetLicense("...");

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Letter;
            options.PageSetup.Orientation = Orientation.Landscape;
            options.PageSetup.PageMargins.Left = LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter);
            options.PageSetup.PageMargins.Top = LengthUnitConverter.ToPoint(20, LengthUnit.Millimeter);

            // Case 1: Place all images in horizontal order,
            // set image size 75 x 75 mm, distance 10 mm between images.
            options.PlaceImagesByHorizontal = true;
            options.Width = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter);
            options.Height = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter);
            options.DistanceBetweenImages = LengthUnitConverter.ToPoint(10, LengthUnit.Millimeter);

            try
            {
                v.ConvertImageToPdf(inpFolder, outFile, options);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadLine();
            }

            // Case 2: Place all images in vertical order,
            // set image size 75 x 75 mm, distance 10 mm between images.
            outFile = new FileInfo(@"Vertical.pdf").FullName;
            options.PageSetup.Orientation = Orientation.Portrait;
            options.PlaceImagesByHorizontal = false;
            options.Width = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter);
            options.Height = LengthUnitConverter.ToPoint(75, LengthUnit.Millimeter);
            options.DistanceBetweenImages = LengthUnitConverter.ToPoint(10, LengthUnit.Millimeter);
            
            try
            {
                v.ConvertImageToPdf(inpFolder, outFile, options);
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
