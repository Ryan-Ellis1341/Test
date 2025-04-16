<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="DefaultPage.Account.MemberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MemberPageForm" runat="server">
        <div>

            <span id="WelcomeMemberLabel" style="font-size:x-large; font-weight:bold;">
                Member Page
                
                <div>  
                    <% Response.Write("Hello " + Context.User.Identity.Name + ", "); %> <br />
        This page is for members only. Only authenticated members can access this  
        page and the services provided.<br /> 
        </div>
            </span>
            <br>
            <br>

            <!-- Below will be our buttons to access each service page -->
            
            <section style="margin-left: auto; margin-right: auto; text-align: center; height: 75px;">

                


                <asp:Button ID="serviceBtn1" runat="server" Font-Bold="True" Height="35px" Text="Brad's Services" Width="125px" />
&nbsp;
                <asp:Button ID="serviceBtn2" runat="server" Font-Bold="True" Height="35px" Text="Gabe's Services" Width="125px" />
&nbsp;
                <asp:Button ID="serviceBtn3" runat="server" Font-Bold="True" Height="35px" Text="Jessica's Services" Width="125px" />
&nbsp;
                <asp:Button ID="backBtn" runat="server" Font-Bold="True" Height="35px" OnClick="backBtn_Click" Text="Back" Width="75px" />
&nbsp;
                <asp:Button ID="logoutBtn" runat="server" Font-Bold="True" Height="35px" OnClick="logoutBtn_Click" Text="Logout" Width="75px" />

                


            </section>

            

        </div>
    </form>
</body>
</html>
