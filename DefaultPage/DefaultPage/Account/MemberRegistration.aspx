<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegistration.aspx.cs" Inherits="DefaultPage.Account.MemberRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MemberRegistrationForm" runat="server">
        <div>

            <span id="RegistrationLabel" style="font-size:x-large; font-weight:bold;">
                Register as a New Member
            </span>
            <br>
            <br>

            <span id="UsernameLabel">Username:</span>
             &nbsp;&nbsp;&nbsp;&nbsp;
             &nbsp; 
            <asp:TextBox ID="txtUsername" runat="server" Height="22px" Width="128px"></asp:TextBox>
            <br>
            <br>

            <span id="passwordLabel">Password:</span>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" Height="22px" Width="128px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="userErrorLabel" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#FF3300"></asp:Label>
            <br>
            <br>

            <!-- Below is the implementation of our UserControlImage1_captchaImg service -->
             <img id="UserControlImage1_captchaImage" src="imageVerifier.aspx?">
            <br>
            
            
            <asp:Button Text="Get New Image" RunAt="server" ID="btnReCaptcha" Font-Bold="True" />
            <br>
            
            <span id="captchaRequestLabel">Please enter the text above into the following textbox</span>
            <br>
            
            &nbsp;<asp:TextBox ID="txtCaptcha" runat="server" Height="22px" Width="128px"></asp:TextBox>
            <asp:Label ID="captchaErrorLabel" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#FF3300"></asp:Label>
            <br>
            <br> 

            
            <asp:Button Text="Register an Account" RunAt="server" ID="btnRegister" Font-Bold="True" OnClick="btnRegister_Click" />
             &nbsp;&nbsp; 

            
            <asp:Button Text="Login" RunAt="server" ID="loginButton" Font-Bold="True" />
             &nbsp;&nbsp; 

            
            <asp:Button Text="Back Home" RunAt="server" ID="btnHome" Font-Bold="True" OnClick="btnHome_Click" />
            <br />
            <br />
            <br>
             &nbsp; 
            <br>


        </div>
    </form>
</body>
</html>
