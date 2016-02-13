<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Address Lookup</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:PlaceHolder ID="phLinks" runat="server"></asp:PlaceHolder>
        <br />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="ddlNames" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlNames_SelectedIndexChanged" ViewStateMode="Enabled" Width="178px">
            <asp:ListItem>Select a letter above</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAddress" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" ForeColor="White" Text="blank   "></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
