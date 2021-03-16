<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How convert ASPX page to PDF with filled forms using C#</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>How convert ASPX page to PDF with filled forms using C#</h1>
        <div>Fill some house description here:<br />
            <br />
            House space (m2):
            <asp:TextBox ID="txtHouseSpace" runat="server"></asp:TextBox>
            <br />
            <br />
            Number of floors:
            <asp:ListBox ID="lstFloorsNum" runat="server" Rows="1">
                <asp:ListItem Selected="True">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:CheckBox ID="chkBathroom" runat="server" Checked="True" Text="Bathroom" />
&nbsp;<asp:CheckBox ID="chkToilet" runat="server" Checked="True" Text="Toilet" />
&nbsp;<asp:CheckBox ID="chkSwimmingPool" runat="server" Text="Swimming pool " />
        </div>
        <br />
            <p>
                <asp:Button ID="ButtonPDF" runat="server" onclick="GetPDF_Click" 
                    Text="Print to PDF" />
            </p>
        </div>
    </form>
</body>
</html>
