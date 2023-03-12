using SautinSoft.PdfVision;

namespace ASP.GetScreenShot.Models
{
    public class ConverterOptions
    {
        public string HtmlAddress { get; set; } = String.Empty;
        public int ViewPortWidth { get; set; }
        public int ViewPortHeight { get; set; }

        public ScreenshotType ImageFormat { get; set; }
        public bool FullPage { get; set; }
    }
}
