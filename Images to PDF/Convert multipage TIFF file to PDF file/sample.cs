using System;
using System.IO;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            //Convert multipage TIFF file to PDF file
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            //specify converting options
            v.PageStyle.PageSize.Auto();

            v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            //Specify a path to a TIFF file, e.g. "d:\my Funny Picture.tiff"
            string inpFile = Path.GetFullPath(@"..\..\multipage.tiff");
            FileInfo outFile = new FileInfo(@"Result.pdf");

            //Convert image file to pdf
            int ret = v.ConvertImageFileToPDFFile(inpFile, outFile.FullName);

            //0 - converting successfully
            //1 - can't open input file, check the input path
            //2 - can't create output file, check the output path
            //3 - converting failed

            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
