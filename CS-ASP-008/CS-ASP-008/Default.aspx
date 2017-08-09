<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_008.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="OKButton" runat="server" OnClick="OKButton_Click" Text="OK" />
        </div>
        <p>
            &nbsp;</p>
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
