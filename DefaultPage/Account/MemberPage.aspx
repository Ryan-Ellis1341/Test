<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="DefaultPage.Account.MemberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:maroon">
    <form id="MemberPageForm" runat="server">
        <div>

            <span id="WelcomeMemberLabel" style="font-size:x-large; font-weight:bold;">&nbsp;<div>  
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Member Page"></asp:Label>
                    <br />
                    <asp:Label ID="Label12" runat="server" ForeColor="White" Text="This page is for members only. Only authenticated members can access this page and the services provided."></asp:Label>
                    <br /> 
        </div>

                <style type="text/css">
                    .inlineBlock {display: inline-block;
                        margin-left: 0px;
                        margin-right: 114px;
                    }
                    .auto-style1 {
                        height: 1134px;
                        width: 595px;
                    }
                </style>
                <div style="width: 324px">
</div><div style="margin-left: auto; margin-right: auto; text-align: center; background-color: #FFC72A;" class="auto-style1">
         <br />
         <asp:Panel ID="treeViewWeather" runat="server" Height="399px" background-color="#FFC72A" Width="593px">Get Weather Data<br /> <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Enter a Location:"></asp:Label><br /><asp:Label ID="Label4" runat="server" Font-Overline="False" Font-Size="Small" Text="Latitude:     "></asp:Label><asp:TextBox ID="txtLatitude" runat="server" Width="128px"></asp:TextBox><br /><asp:Label ID="Label5" runat="server" Font-Size="Small" Text="Longitude: "></asp:Label><asp:TextBox ID="txtLongitude" runat="server" Width="128px"></asp:TextBox><br /><asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Select a Month: "></asp:Label> <asp:DropDownList ID="MonthList" runat="server">
                 <asp:ListItem>January</asp:ListItem><asp:ListItem>February</asp:ListItem><asp:ListItem>March</asp:ListItem><asp:ListItem>April</asp:ListItem><asp:ListItem>May</asp:ListItem><asp:ListItem>June</asp:ListItem><asp:ListItem>July</asp:ListItem><asp:ListItem>August</asp:ListItem><asp:ListItem>September</asp:ListItem><asp:ListItem>October</asp:ListItem><asp:ListItem>November</asp:ListItem><asp:ListItem>December</asp:ListItem></asp:DropDownList><br /><asp:Button ID="weatherBtn" runat="server" OnClick="weatherBtn_Click1" Text="Get Data" BackColor="#8C1D40" Font-Bold="True" ForeColor="White" />
             <br />
             <asp:Label ID="yearLabel" runat="server" Font-Size="Medium"></asp:Label><br /><asp:Label ID="monthLabel" runat="server" Font-Size="Medium"></asp:Label><br /><asp:Label ID="tempLabel" runat="server" Font-Size="Medium"></asp:Label><br /><asp:Label ID="precLabel" runat="server" Font-Size="Medium"></asp:Label><br /><asp:Label ID="sunLabel" runat="server" Font-Size="Medium"></asp:Label><span id="WelcomeMemberLabel0" style="font-size:x-large; font-weight:bold;">
             <br />
             <br />
             <asp:Panel ID="treeviewServices2" runat="server" background-color="#FFC72A" CssClass="inlineBlock" Height="385px" Width="600px">
                 <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Insert Zip to get coordinates"></asp:Label>
                 <asp:TextBox ID="TextBox1" runat="server" Width="128px"></asp:TextBox>
                 <asp:Label ID="ZipError" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="#CC3300"></asp:Label>
                 <br />
                 <asp:Button ID="Convert_Zip_Btn" runat="server" BackColor="#8C1D40" Font-Bold="True" ForeColor="White" OnClick="Convert_Zip_Btn_Click" Text="Convert Zip" Width="104px" />
                 <br />
                 <br />
                 <asp:Label ID="LatLabel" runat="server" Font-Size="Medium" Text="Latitude: "></asp:Label>
                 <asp:Label ID="LatitudeResult" runat="server" Font-Size="Medium"></asp:Label>
                 <br />
                 <asp:Label ID="LongLabel" runat="server" Font-Size="Medium" Text="Longitude: "></asp:Label>
                 <asp:Label ID="LongitudeResult" runat="server" Font-Size="Medium"></asp:Label>
                 <br />
                 <br />
                 <asp:Label ID="Label8" runat="server" Text="Get Earthquake Index"></asp:Label>
                 <br />
                 <br />
                 <!-- Earthquake Index -->
                 <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Date Range:"></asp:Label>
                 <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ToolTip="Date range ends on today's date.">
                     <asp:ListItem Value="10">10 years</asp:ListItem>
                     <asp:ListItem Value="25">25 years</asp:ListItem>
                     <asp:ListItem Value="50">50 years</asp:ListItem>
                     <asp:ListItem Value="100">100 years</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Label ID="Label10" runat="server" Font-Size="Small" Text="Radius"></asp:Label>
                 <asp:DropDownList ID="DropDownList_Radius" runat="server" OnSelectedIndexChanged="DropDownList_Radius_SelectedIndexChanged">
                     <asp:ListItem Value="10">10 miles</asp:ListItem>
                     <asp:ListItem Value="25">25 miles</asp:ListItem>
                     <asp:ListItem Value="50">50 miles</asp:ListItem>
                     <asp:ListItem Value="100">100 miles</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Label ID="Label11" runat="server" Font-Size="Small" Text="Magnitude:"></asp:Label>
                 <asp:DropDownList ID="DropDownList_Magnitude" runat="server" OnSelectedIndexChanged="DropDownList_Magnitude_SelectedIndexChanged">
                     <asp:ListItem>2.5</asp:ListItem>
                     <asp:ListItem>3.0</asp:ListItem>
                     <asp:ListItem>3.5</asp:ListItem>
                     <asp:ListItem>4.0</asp:ListItem>
                     <asp:ListItem>4.5</asp:ListItem>
                     <asp:ListItem>5.0</asp:ListItem>
                     <asp:ListItem>5.5</asp:ListItem>
                     <asp:ListItem>6.0</asp:ListItem>
                 </asp:DropDownList>
                 <br />
                 <asp:Button ID="Earthquake_Index_Btn" runat="server" BackColor="#8C1D40" ForeColor="White" OnClick="Earthquake_Index_Btn_Click" Text="Earthquake Index" Width="168px" />
                 <br />
                 <asp:Label ID="EQLabel" runat="server" Font-Size="Medium" Text="The Earth Quake Index is:"></asp:Label>
                 <asp:Label ID="Index_Label" runat="server" Font-Size="Medium"></asp:Label>
                 <br />
                 <span id="WelcomeMemberLabel3" style="font-size:x-large; font-weight:bold;"><span id="WelcomeMemberLabel4" style="font-size:x-large; font-weight:bold;">
                 <section style="margin-left: auto; margin-right: auto; text-align: center; height: 75px;">
                     &nbsp;Wind Danger Level <span id="WelcomeMemberLabel1" style="font-size:x-large; font-weight:bold;"><span id="WelcomeMemberLabel2" style="font-size:x-large; font-weight:bold;">
                     <asp:Panel ID="treeviewServices3" runat="server" background-color="#FFC72A" CssClass="inlineBlock" Height="385px" Width="600px">
                         <br />
                         <!-- Earthquake Index -->
                         <asp:Label ID="Label16" runat="server" Font-Size="Small" Text="Speed in Miles per Hour:"></asp:Label>
                         <span id="WelcomeMemberLabel5" style="font-size:x-large; font-weight:bold;"><span id="WelcomeMemberLabel6" style="font-size:x-large; font-weight:bold;">
                         <asp:TextBox ID="TextBox2" runat="server" Width="128px"></asp:TextBox>
                         </span></span>
                         <br />
                         <asp:Button ID="Wind_Button" runat="server" BackColor="#8C1D40" ForeColor="White" OnClick="Wind_Button_Click" Text="Get Wind Warning Level" Width="240px" Height="35px" />
                         <br />
                         <asp:Label ID="EQLabel0" runat="server" Font-Size="Medium" Text="The Wind Danger Level Is:"></asp:Label>
                         <asp:Label ID="Index_Label0" runat="server" Font-Size="Medium"></asp:Label>
                         <br />
                         <section style="margin-left: auto; margin-right: auto; text-align: center; height: 75px;">
                             <asp:Button ID="backBtn0" runat="server" BackColor="#8C1D40" Font-Bold="True" ForeColor="White" Height="35px" OnClick="backBtn_Click" Text="Back" Width="75px" />
                             &nbsp;
                             <asp:Button ID="logoutBtn0" runat="server" BackColor="#8C1D40" Font-Bold="True" ForeColor="White" Height="35px" OnClick="logoutBtn_Click" Text="Logout" Width="75px" />
                         </section>
                     </asp:Panel>
                     </span></span>
                 </section>
                 </span></span>
                 
             </asp:Panel>
             </span></asp:Panel><><br />

            </span>

            

        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
