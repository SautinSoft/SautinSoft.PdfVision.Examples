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
        Result.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SautinSoft.PdfVision v  = new SautinSoft.PdfVision();

        byte[] tiffBytes = null;
        byte[] pdfBytes = null;

        if (FileUpload1.FileBytes.Length > 0)
        {
            // get bytes from image
            tiffBytes = FileUpload1.FileBytes;
        }

        else
            Result.Text = "Please select image file at first!";

        // convert image stream to pdf stream
        pdfBytes = v.ConvertImageStreamToPdfStream(tiffBytes);
        
        // show PDF
        if (pdfBytes != null)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/PDF";
            // Response.AddHeader("content-disposition", "attachment; filename=Result.pdf");
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
