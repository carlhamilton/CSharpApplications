<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_006.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #FF0000;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Head Line 1</h1>
            <br />
            <h2>Head Line 2</h2>
            <br />
            <h3>Head Line 3</h3>
            <h4>
                <br />
                Head LIne 4</h4>
            <br />
            <h5>Head Line 5</h5>
            <br />
            <h6>Head LIne 6</h6>
        </div>
        <p class="auto-style1">
            This is some text that I want to <span class="auto-style2"><a href="http://www.devu.com">apply</a></span> a style to.</p>
        <p class="auto-style1">
            we add another
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.microsoft.com" Target="_blank">link to open</asp:HyperLink>
        </p>
        <p class="auto-style1">
            &nbsp;</p>
        <asp:Image ID="Image1" runat="server" Height="462px" ImageUrl="~/lucy &amp; I.jpg" Width="640px" />
        <br />
        <br />
        <table class="auto-style3">
            <tr>
                <td>Player</td>
                <td>Year</td>
                <td>Home Runs</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <p>
                        Sammy Sosa</p>
                </td>
                <td class="auto-style4">2005</td>
                <td class="auto-style4">100</td>
            </tr>
            <tr>
                <td>
                    <p>
                        Mark MacGuire</p>
                </td>
                <td>2005</td>
                <td>102</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
