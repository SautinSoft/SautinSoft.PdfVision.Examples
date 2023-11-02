<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="wwwroot/lib/bootstrap/dist/css/bootstrap.min.css" />
    <title>PDF Vision .Net</title>
</head>
<body style="font-size: 12pt">
    <div class="panel m-5">
        <form id="form1" runat="server">
            <div class="form-control m-3">
                <label>Select any image file:</label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div class="form-control m-3">
                <label>Another image:</label>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </div>
            <div class="form-control m-3">
                <label>Another image:</label>
                <asp:FileUpload ID="FileUpload3" runat="server" />
            </div>
            <div class="form-control m-3">
                <label>Another image:</label>
                <asp:FileUpload ID="FileUpload4" runat="server" />
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert to PDF" CssClass="btn btn-primary m-3" />
        </form>
    </div>
</body>
</html>
