using SautinSoft.PdfVision;

namespace ASP.NetHtmlToPdf.Models
{
    public class ConverterOptions
    {
        public string HtmlAddress { get; set; } = String.Empty;
        public PaperType PaperType { get; set; }
        public Orientation Orientation { get; set; }
    }
}
