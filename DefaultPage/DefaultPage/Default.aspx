<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DefaultPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-left: auto; margin-right: auto; text-align: center;" class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Description goes here</p>
        
    </div>

    <body>

        <div style="margin-left: auto; margin-right: auto; text-align: center; height: 55px;">

            <asp:Button ID="btnServDirectory" runat="server" BackColor="#CCCCCC" BorderColor="Silver" Font-Bold="True" Font-Size="Large" ForeColor="#990000" Text="Service Directory" Width="165px" />

        </div>


        <div style="margin-left: auto; margin-right: auto; text-align: center;  height: 116px;">

            &nbsp
            <table style="text-align: center; width: 814px; height: 93px;" cellpadding="8">
			<tr> 	<td>&nbsp;<asp:Button Text="Member Login" RunAt="server" ID="mLoginBtn" OnClick="mLoginBtn_Click" Font-Bold="True" />
                <br />
                </td>      	
          	    		  	<td> <asp:Button Text="Staff Login" RunAt="server" ID="sLoginBtn" OnClick="sLoginBtn_Click" Font-Bold="True" />
                                <br />
                </td> </tr>
        		<tr> 	<td><asp:Button Text="Member Home Page" RunAt="server" Width="175px" ID="mHomePageBtn" OnClick="mHomePageBtn_Click" Font-Bold="True" /></td>
					<td><asp:Button Text="Staff Home Page" RunAt="server" Width="175px" ID="sHomePageBtn" OnClick="sHomePageBtn_Click" Font-Bold="True" /> </td> </tr>	
			
		</table>
            

            
            
        </div>


        <div style="margin-left: auto; margin-right: auto; text-align: center; height: 55px;">

        </div>


        <div style="margin-left: auto; margin-right: auto; text-align: center; height: 55px;">

        </div>

    </body>

</asp:Content>
