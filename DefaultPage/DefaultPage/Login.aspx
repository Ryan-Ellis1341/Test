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
					<td><asp:TextBox ID="Password" TextMode="password" 
							RunAt="server" /> </td> </tr>	
			<tr>
				<td><asp:Button Text="Log In" OnClick="LoginFunc" 
						RunAt="server" /></td>
				<td><asp:CheckBox Text="Keep me signed in" ID="Persistent" 
						RunAt="server"/> </td>
        		</tr>
		</table>
	</form>
	<hr> <h3><asp:Label ID="Output" RunAt="server" /></h3>


        </div>
  
</body>
</html>


<script language="C#" runat="server">
    void LoginFunc(Object sender, EventArgs e)
    {
        if (FormsAuthentication.Authenticate(UserName.Text, Password.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);            // false indicates the checkbox was unselected 
        }
        else
            Output.Text = "Invalid login";
    }
</script>
