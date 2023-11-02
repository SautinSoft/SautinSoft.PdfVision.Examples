using ASP.GetScreenShot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SautinSoft.PdfVision;

namespace ASP.GetScreenShot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            ConverterOptions opt = new ConverterOptions()
            {
                HtmlAddress = "https://sautinsoft.com/",
                FullPage = true,
                ImageFormat = ScreenshotType.Png,
                ViewPortWidth = 1920,
                ViewPortHeight = 1080
            };
            return View("Index", opt);
        }

        [HttpPost]
        public ViewResult GetScreenshot(ConverterOptions co)
        {
            PdfVision v = new PdfVision();

            ScreenshotOptions so = new ScreenshotOptions();
            so.ViewPortOptions.Width = co.ViewPortWidth;
            so.ViewPortOptions.Height = co.ViewPortHeight;
            so.FullPage = co.FullPage;
            so.Type = co.ImageFormat;

            byte[] image = v.GetScreenshot(co.HtmlAddress, so);

            ImageBase64 model = new ImageBase64()
            {
                Data = Convert.ToBase64String(image),
                Format = (so.Type == ScreenshotType.Png) ? "png" : "jpg"
            };
            return View("ShowResult", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}