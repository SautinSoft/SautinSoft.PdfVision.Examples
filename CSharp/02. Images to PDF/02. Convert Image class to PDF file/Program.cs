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
            ConvertSystemDrawingToPdf();
        }
        public static void ConvertSystemDrawingToPdf()
        {
            System.Drawing.Image image = Image.FromFile(@"..\..\..\image-jpeg.jpg");
            string outFile = new FileInfo(@"Result.pdf").FullName;

            PdfVision v = new PdfVision();
            ImageToPdfOptions options = new ImageToPdfOptions();
            options.PageSetup.PaperType = PaperType.Auto;


            byte[] imgBytes = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgBytes = ms.ToArray();
            }

            try
            {
                v.ConvertImageToPdf(imgBytes, outFile, options);
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
