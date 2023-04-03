![Nuget](https://img.shields.io/nuget/v/SautinSoft.PdfVision) ![Nuget](https://img.shields.io/nuget/dt/SautinSoft.PdfVision) 
# .NET SDK to convert HTML, ASPX, URL to PDF and Images to PDF

![SautinSoft.PDFVision](https://camo.githubusercontent.com/cc2eec5de5e95c29016fc2410d99e1ca9095b35d6895b5e1e42dff7602273f53/68747470733a2f2f7777772e73617574696e736f66742e636f6d2f6d656469612f6769746875622f762e706e67)

[SautinSoft.PdfVision](https://sautinsoft.com/products/pdf-vision/) is .NET assembly (SDK) which gives API to convert HTML, ASPX to PDF and Image, JPG, Multipages TIFF to PDF.

## Quick links

+ [Developer Guide](https://sautinsoft.com/products/pdf-vision/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-vision/help/net/api-reference/html/N_SautinSoft_PdfVision.htm)

## Top Features

+ [Convert HTML file to PDF file.](https://sautinsoft.com/products/pdf-vision/help/net/developer-guide/convert-html-file-to-pdf-file-csharp-vb-net.php)
+ [Convert Web-site (URL) to PDF file.](https://sautinsoft.com/products/pdf-vision/help/net/developer-guide/convert-web-site-url-to-pdf-file-csharp-vb-net.php)
+ [Convert Images to PDF file.](https://sautinsoft.com/products/pdf-vision/help/net/developer-guide/convert-image-class-to-pdf-file-csharp-vb-net.php)
+ [Convert HTML file to Image file.](https://sautinsoft.com/products/pdf-vision/help/net/developer-guide/convert-html-file-to-image-file-csharp-vb-net.php)
+ [Merge PDF files into one PDF file.](https://sautinsoft.com/products/pdf-vision/help/net/developer-guide/merge-pdf-files-csharp-vb-net.php)

## System Requirement

* .NET Framework 4.6.1 - 4.8.1
* .NET Core 2.0 - 3.1, .NET 5, 6, 7
* .NET Standard 2.0
* Windows, Linux, macOS, Android, iOS.

## Getting Started with PDF Vision .Net

Are you ready to give PDF Vision .NET a try? Simply execute `Install-Package sautinsoft.pdfvision` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have PDF Vision .NET and want to upgrade the version, please execute `Update-Package sautinsoft.pdfvision` to get the latest version.

## Convert HTML to PDF

```csharp
string inpFile = Path.GetFullPath(@"..\..\Sample.html");
string outFile = new FileInfo("Result.pdf").FullName;

// Local chromium will be downloaded into this directory.
// This takes time only at the first startup.
string chromiumDirectory = new DirectoryInfo(@"..\..\..\..\..\..\Local Chromium\").FullName;
PdfVision v = new PdfVision();
v.ConvertHtmlToPdf(inpFile, outFile);
```
## Convert JPG to PDF

```csharp
string inpFile = Path.GetFullPath(@"..\..\image-jpeg.jpg");
string outFile = new FileInfo(@"Result.pdf").FullName;

PdfVision v = new PdfVision();
ImageToPdfOptions options = new ImageToPdfOptions();
v.ConvertImageToPdf(new string[] {inpFile}, outFile, options);
```
## Convert HTML to Image

```csharp
string inpFile = Path.GetFullPath(@"..\..\Sample.html");
string outFile = new FileInfo("Result.png").FullName;

// Local chromium will be downloaded into this directory.
// This takes time only at the first startup.
string chromiumDirectory = new DirectoryInfo(@"..\..\..\..\..\..\Local Chromium\").FullName;
PdfVision v = new PdfVision();
ScreenshotOptions options = new ScreenshotOptions();
v.GetScreenshot(inpFile, outFile, options);
```

## Resources

+ **Website:** [www.sautinsoft.com](http://www.sautinsoft.com)
+ **Product Home:** [PDF Vision .Net](https://sautinsoft.com/products/pdf-vision/)
+ [Download SautinSoft.PDFVision](http://sautinsoft.com/products/pdf-vision/download.php)
+ [Developer Guide](https://sautinsoft.com/products/pdf-vision/help/net/)
+ [API Reference](https://sautinsoft.com/products/pdf-vision/help/net/api-reference/html/N_SautinSoft_PdfVision.htm)
+ [Support Team](https://sautinsoft.com/support.php)
+ [License](https://sautinsoft.com/products/pdf-vision/help/net/getting-started/agreement.php)
