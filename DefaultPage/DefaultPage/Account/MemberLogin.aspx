<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="DefaultPage.Account.MemberLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MemberLoginForm" runat="server">
        <div>

            <span id="MemberLoginLabel" style="font-size:x-large;font-weight:bold;">
                Member Login 
            </span>

            <br>
            <br>

            <span id="errorLogin" style="color:red; font-style:italic;">&nbsp;</span><asp:Label ID="errorLabel" runat="server" Font-Italic="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
            <br />
            <br>
            

            <span id="userNameLabel">Username:</span>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br>
            <br>

            <span id="pwLabel">Password:</span>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br>
            <br>

            <asp:Button Text="Login" RunAt="server" ID="btnLogin" Font-Bold="True" OnClick="btnLogin_Click" />          
            <br>
            <br>

            <!-- REPLACE WITH CORRECT PATH TO OUR SERVER PAGE MemberRegistration -->
            New User? Please
            <a href="http://neptune.fulton.ad.asu.edu/WSRepository/FormsSecurity/Account/StudentRegister.aspx">Register Here.</a>
            <br>
            <br>
            <br>

            <asp:Button Text="Home Page" RunAt="server" ID="btnHome" Font-Bold="True" OnClick="btnHome_Click" />
            




        </div>
    </form>
</body>
</html>
