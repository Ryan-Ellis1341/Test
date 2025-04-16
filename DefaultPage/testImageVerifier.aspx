<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testImageVerifier.aspx.cs" Inherits="DefaultPage.testImageVerifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="Image1" runat="server" Width="123px" />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSumit" runat="server" OnClick="btnSumit_Click" Text="Submit" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnShowImage" runat="server" OnClick="btnShowImage_Click" Text="Show New Image" />
        <br />
    </form>
</body>
</html>
