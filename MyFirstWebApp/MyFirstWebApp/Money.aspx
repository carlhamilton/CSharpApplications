<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Money.aspx.cs" Inherits="MyFirstWebApp.Money" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            How old are you?&nbsp;
            <asp:TextBox ID="ageTextBox" runat="server" OnTextChanged="ageUserResult_TextChanged"></asp:TextBox>
            <br />
            <br />
            How much money do you have in your pocket?
            <asp:TextBox ID="fortuneTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="fortuneResult" runat="server" OnClick="fortuneResult_Click" Text="Click to see your fortune! " />
        </div>
        <p>
            &nbsp;</p>
        <asp:Label ID="resultLabelText" runat="server"></asp:Label>
    </form>
</body>
</html>
