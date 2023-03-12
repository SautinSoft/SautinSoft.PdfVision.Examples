namespace ASP.GetScreenShot.Models
{
    public class ImageBase64
    {
        public string Data { get; set; } = String.Empty;
        // png or jpg
        public string Format { get; set; } = "png";
    }
}
