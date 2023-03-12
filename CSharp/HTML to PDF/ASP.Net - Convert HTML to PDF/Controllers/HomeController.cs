using ASP.NetHtmlToPdf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SautinSoft.PdfVision;
using Microsoft.Extensions.Options;

namespace ASP.NetHtmlToPdf.Controllers
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
                HtmlAddress = "https://github.com",
                PaperType = SautinSoft.PdfVision.PaperType.Letter,
                Orientation = SautinSoft.PdfVision.Orientation.Landscape
            };
            return View("Index", opt);
        }

        [HttpPost]
        public ActionResult ConvertToPdf(ConverterOptions co)
        {
            PdfVision v = new PdfVision();

            HtmlToPdfOptions ho = new HtmlToPdfOptions();
            ho.PageSetup.PaperType = co.PaperType;
            ho.PageSetup.Orientation = co.Orientation;

            // Unpack portable Chromium browser if necessary.
            // To use portable Chromium add Nuget package:  SautinSoft.PdfVision.Chromium.Windows. (Linux, MacOS).
            if (!ChromiumEngine.IsExist(ho.ChromiumBaseDirectory))
                ChromiumEngine.Unpack(ho.ChromiumBaseDirectory);


            byte[] pdf = v.ConvertHtmlToPdf(co.HtmlAddress, ho);
            return new FileContentResult(pdf, "application/pdf");
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