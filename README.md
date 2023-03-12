![Nuget](https://img.shields.io/nuget/v/SautinSoft.PdfVision) ![Nuget](https://img.shields.io/nuget/dt/SautinSoft.PdfVision) 
# .NET SDK to convert HTML, ASPX, URL to PDF and Images to PDF

<img src="https://www.sautinsoft.com/media/github/v.png" alt="SautinSoft.PdfVision" align="left" />

[SautinSoft.PdfVision](https://sautinsoft.com/products/pdf-vision/) is .NET assembly which gives API to convert HTML to PDF; take screenshots from HTML; convert Images (TIFF, PNG, JPEG, BMP) to PDF.

## Quick links

+ [Developer Guide](https://sautinsoft.com/products/pdf-vision/examples/)
+ [API Reference](https://sautinsoft.net/help/png-bmp-jpeg-html-tiff-to-pdf-net/html/N_SautinSoft_PdfVision.htm)

## Top Features

+ [Convert HTML file to PDF file.](https://sautinsoft.com/products/pdf-vision/examples/convert-html-file-to-pdf-file-csharp-vb-net.php)
+ [Convert Web-site (URL) to PDF file.](https://sautinsoft.com/products/pdf-vision/examples/convert-web-site-url-to-pdf-file-csharp-vb-net.php)
+ [Convert Images to PDF file.](https://sautinsoft.com/products/pdf-vision/examples/convert-image-class-to-pdf-file-csharp-vb-net.php)
+ [Convert HTML file to Image file.](https://sautinsoft.com/products/pdf-vision/examples/convert-html-file-to-image-file-csharp-vb-net.php)
+ [Merge PDF files into one PDF file.](https://sautinsoft.com/products/pdf-vision/examples/merge-pdf-files-csharp-vb-net.php)

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

PdfVision v = new PdfVision();

// Unpack portable Chromium browser if necessary.
// To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
if (!ChromiumEngine.IsExist(options.ChromiumBaseDirectory))
    ChromiumEngine.Unpack(options.ChromiumBaseDirectory);

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

PdfVision v = new PdfVision();
ScreenshotOptions options = new ScreenshotOptions();

// Unpack portable Chromium browser if necessary.
// To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
if (!ChromiumEngine.IsExist(options.ChromiumBaseDirectory))
    ChromiumEngine.Unpack(options.ChromiumBaseDirectory);

v.GetScreenshot(inpFile, outFile, options);
```

## Resources

+ **Website:** [www.sautinsoft.com](http://www.sautinsoft.com)
+ **Product Home:** [PDF Vision .Net](https://sautinsoft.com/products/pdf-vision/)
+ [Download SautinSoft.PDFVision](https://sautinsoft.com/products/pdf-vision/download.php)
+ [Developer Guide](https://sautinsoft.com/products/pdf-vision/examples/)
+ [API Reference](https://sautinsoft.net/help/png-bmp-jpeg-html-tiff-to-pdf-net/html/N_SautinSoft_PdfVision.htm)
+ [Support Team](https://sautinsoft.com/support.php)
+ [License](https://sautinsoft.net/help/png-bmp-jpeg-html-tiff-to-pdf-net/html/license.htm)