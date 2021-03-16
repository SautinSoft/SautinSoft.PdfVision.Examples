using System;
using System.IO;
using System.Collections.Generic;

namespace Sample
{
    class Test
    {
        static void Main(string[] args)
        {
            // Convert a folder with images to PDF file.
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();

            //v.Serial = "XXXXXXXXXXXXXXX";

            // Set some options.
            v.PageStyle.PageSize.Auto();
            //v.PageStyle.PageMarginLeft.Inch(1);
            //v.ImageStyle.Heightmm(150);
            //v.ImageStyle.WidthInch(10);

            v.ImageStyle.JPEGQuality = 95; // 50 - 100
            v.ImageStyle.FitImageToPageSize = false;

            // Specify directory with images. Any local path, like a: "c:\images\".
            string inpFolder = Path.GetFullPath(@"..\..\");
            FileInfo outFile = new FileInfo(@"Result.pdf");

            // Convert all image files from directory to PDF file.
            // Image files: *.jpg, *.bmp, *.gif, *.tiff, *.tif, *.png, *.ico, *.emf, *.exif, *.jpeg, *.jpe, *.jfif, *.photocd, *.flashpix.
            int ret = v.ConvertImageFolderToPDFFile(inpFolder, outFile.FullName);

            // 0 - converting successfully
            // 1 - directory doesn't contain any image file
            // 2 - can't create output file, check the output path
            // 3 - converting failed

            if (ret == 0)
            {
                // Open the resulting PDF document in a default PDF Viewer.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile.FullName) { UseShellExecute = true });
            }
        }
    }
}
