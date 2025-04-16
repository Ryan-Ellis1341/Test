<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DefaultPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div style="margin-left: auto; margin-right: auto; text-align: center;" class="jumbotron" >
        <h1>CSE 445 Assignment 5/6 Group 13</h1>
        <p>Ryan Ellis, Andrew Ayerh, David Brimhall</p>
        <p class="lead">We should add something new here. Perhaps just our own description.</p>
        
    </div>

    <body style="background-color:navy">



     
        <div style="margin-left: auto; margin-right: auto; text-align: center; height: 143px; width: 833px; background-color: #FFC72A;">

            <asp:Panel ID="Panel1" runat="server" Height="151px" background-color="#FFC72A">
                <table class="nav-justified" style="height: 170px; width: 832px; position: relative; z-index: auto; background-color: #FFC72A; left: 0px; top: -22px;" contenteditable="false">
                    <tr>
                        <td style="width: auto">
                            <asp:Button ID="mLoginBtn" RunAt="server" Font-Bold="True" OnClick="mLoginBtn_Click" Text="Member Login" BackColor="#06038D" ForeColor="White" />
                        </td>
                        <td style="width: auto">
                            <asp:Button ID="sLoginBtn" RunAt="server" Font-Bold="True" OnClick="sLoginBtn_Click" Text="Staff Login" BackColor="#06038D" ForeColor="White" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: auto">
                            <asp:Button ID="mHomePageBtn" RunAt="server" Font-Bold="True" OnClick="mHomePageBtn_Click" Text="Member Home Page" Width="175px" BackColor="#06038D" ForeColor="White" />
                        </td>
                        <td style="width:auto">
                            <asp:Button ID="sHomePageBtn" RunAt="server" Font-Bold="True" OnClick="sHomePageBtn_Click" Text="Staff Home Page" Width="175px" BackColor="#06038D" ForeColor="White" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </div>

        <div style="margin-left: auto; margin-right: auto; text-align: center;  height: 116px; width: 833px; background-color: #FFC72A;">                     
            
            <asp:Panel ID="Panel2" runat="server" BackColor="#FFC72A" Height="117px">
                <br />
                <table class="nav-justified" style="height: 53px">
                    <tr>
                        <td>
                            <asp:Button ID="btnServDirectory" runat="server" BackColor="#06038D" BorderColor="Silver" Font-Bold="True" Font-Size="Large" ForeColor="White" OnClick="btnServDirectory_Click" Text="Service Directory" Width="251px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>                     
            
        </div>


        <div style="margin-left: auto; margin-right: auto; text-align: center; height: 390px; width: 833px;">

            <asp:Panel ID="serviceDirectoryPanel" runat="server" BackColor="#FFC72A" Height="386px">
                

            </asp:Panel>

        </div>

    </body>

</asp:Content>
