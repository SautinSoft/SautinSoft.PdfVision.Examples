using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SautinSoft.PdfVision v  = new SautinSoft.PdfVision();

        // Set "Edge mode" to support all modern CSS.
        SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

		// Specify top and bottom page margins
        v.PageStyle.PageMarginTop.Mm(5f);
        v.PageStyle.PageMarginBottom.Mm(5f);

        v.PageStyle.PageSize.A4();

        // Be sure that your HTML string has full paths to images and *.css
        // Correct: <img src="http://www.mysite.com/image1.jpg">
        // Incorrect: <img src="../images/image1.jpg">

        string html = ReadFileString(Path.Combine(Server.MapPath(""), "test.htm"));

        byte[] pdfBytes = null;

        // convert html string to pdf stream
        pdfBytes = v.ConvertHtmlStringToPDFStream(html);
        
        // show PDF
        if (pdfBytes != null)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/PDF";
            //Response.AddHeader("content-disposition", "attachment; filename=Result.pdf");
            Response.AddHeader("content-disposition", "inline; filename=Result.pdf");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();
        }        
    }
    public static string ReadFileString(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            return reader.ReadToEnd();
        }
    }
}
