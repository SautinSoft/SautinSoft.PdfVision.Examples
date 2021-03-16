using System;
using System.IO;
using System.Collections;


namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            //Convert TIFF to PDF in memory			
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            //specify converting options
            v.PageStyle.PageSize.Auto();
            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            //Specify a path to a TIFF file, e.g. "d:\my Funny Picture.tiff"
            string inpFile = Path.GetFullPath(@"..\..\image-tiff.tiff");
            FileInfo outFile = new FileInfo(@"Result.pdf");

            //1. Read bytes from TIFF file.
            byte[] imageBytes = File.ReadAllBytes(inpFile);

            //2. Convert TIFF bytes into PDF bytes in memory.
            byte[] pdfBytes = v.ConvertImageStreamToPdfStream(imageBytes);

            //3. Save PDF bytes to file
            if (pdfBytes != null)
            {
                File.WriteAllBytes(outFile.FullName, pdfBytes);
				// Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
