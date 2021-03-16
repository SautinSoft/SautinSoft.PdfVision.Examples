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
using System.Net;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        HouseDescription hd = null;

        if (id != null)
        {
            // Recreate the page state
            hd = (HouseDescription)Application[id];
            SetPageState(hd);
        }

        // First time loading. Set all to default.
        else
        {
            if (!IsPostBack)
                SetPageState(new HouseDescription());
        }
    }
    protected void GetPDF_Click(object sender, EventArgs e)
    {
        // 1. Save the current page state
        // 1.1. Create ID
        string id = Guid.NewGuid().ToString();

        // 1.2 Save the current state in the Application State.
        HouseDescription hd = GetPageState();
        Application[id] = hd;

        // 2. Create url
        string pageUrl = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
        string pageUrlWithQuerry = string.Format("{0}?id={1}", pageUrl, id);

        // 3. Get PDF
        SautinSoft.PdfVision v = new SautinSoft.PdfVision();

        // Set "Edge mode" to support all modern CSS.
        SautinSoft.PdfVision.TrySetBrowserModeEdgeInRegistry();
        byte[] pdf = v.ConvertHtmlFileToPDFStream(pageUrlWithQuerry);

        // 4. Show PDF result
        if (pdf != null)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/PDF";
            //Response.AddHeader("content-disposition", "attachment; filename=Result.pdf");
            Response.AddHeader("content-disposition", "inline; filename=Result.pdf");
            Response.BinaryWrite(pdf);
            Response.Flush();
            Response.End();
        }
    }
    protected void SetPageState(HouseDescription hd)
    {
        txtHouseSpace.Text = hd.HouseSpace.ToString();
        lstFloorsNum.SelectedValue = hd.FloorsNumber.ToString();
        chkBathroom.Checked = hd.IsBathroom;
        chkToilet.Checked = hd.IsToilet;
        chkSwimmingPool.Checked = hd.IsSwimmingPool;
    }
    protected HouseDescription GetPageState()
    {
        HouseDescription hd = new HouseDescription();

        float houseSpace = 0f;

        if (float.TryParse(txtHouseSpace.Text, out houseSpace))
            hd.HouseSpace = houseSpace;

        int floorsNum = 1;
        if (Int32.TryParse(lstFloorsNum.SelectedValue, out floorsNum))
            hd.FloorsNumber = floorsNum;

        hd.IsBathroom = chkBathroom.Checked;
        hd.IsToilet = chkToilet.Checked;
        hd.IsSwimmingPool = chkSwimmingPool.Checked;
        return hd;
    }
}
