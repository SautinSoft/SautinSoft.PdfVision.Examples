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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBoxURl.Text == "")
        {
            Result.Text = "Please type any URL before start converting!";
            return;
        }

        SautinSoft.PdfVision v = new SautinSoft.PdfVision();

        // Set "Edge mode" to support all modern CSS.
        SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();

        byte[] pdfBytes = null;

        // Specify top and bottom page margins
        v.PageStyle.PageMarginTop.Mm(5f);
        v.PageStyle.PageMarginBottom.Mm(5f);

        // convert URL to pdf stream
        pdfBytes = v.ConvertHtmlFileToPDFStream(TextBoxURl.Text);
        
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
        else
        {
            Result.Text = "Converting failed!";
        }
    }
}
