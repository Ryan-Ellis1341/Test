<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DefaultPage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  
        <div>

            <h1>Please Log In</h1> <hr>
	<form id="LoginForm" runat="server" >
		<table cellpadding="8">
			<tr> 	<td>User Name:</td>      	
          	    		  	<td> <asp:TextBox ID="UserName" RunAt="server" /></td> </tr>
        		<tr> 	<td> Password: </td>
					<td><asp:TextBox ID="Password" 
							RunAt="server" /> </td> </tr>	
			<tr>
				<td><asp:Button Text="Log In" OnClick="LoginFunc" 
						RunAt="server" /></td>
				<td><asp:CheckBox Text="Keep me signed in" ID="Persistent" 
						RunAt="server"/> </td>
        		</tr>
		</table>
	&nbsp;
        <asp:Button ID="backButton" runat="server" OnClick="Button1_Click" Text="Back" Width="86px" />
	</form>
	<hr> <h3><asp:Label ID="Output" RunAt="server" /></h3>


        </div>
  
</body>
</html>

