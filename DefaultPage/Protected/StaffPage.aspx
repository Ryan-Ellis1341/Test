<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="DefaultPage.Protected.StaffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 151px;
            margin-left: 6px;
        }
        .auto-style5 {
            width: 501px;
        }
        .auto-style6 {
            width: 456px;
        }
        .auto-style7 {
            height: 151px;
            width: 951px;
        }
        .auto-style8 {
            height: 106px;
        }
        .auto-style9 {
            width: 954px;
        }
        .auto-style11 {
            height: 279px;
        }
        .auto-style12 {
            width: 113%;
            height: 18px;
        }
        .auto-style13 {
            height: 37px;
        }
        .auto-style18 {
            width: 943px;
            border: 2px solid #000000;
            background-color: #F0F0F0;
        }
        .auto-style21 {
            width: 276px;
            height: 24px;
        }
        .auto-style22 {
            width: 277px;
            height: 24px;
        }
        .auto-style25 {
            width: 276px;
        }
        .auto-style26 {
            width: 277px;
        }
        .auto-style27 {
            margin-top: 0px;
        }
        .auto-style28 {
            width: 476px;
        }
        </style>
</head>
<body style="background-color:maroon">
    <form id="form1" runat="server">
        <div>
            <p>
                <span id="WelcomeMemberLabel" style="font-size:x-large; font-weight:bold;">&nbsp;<asp:Label ID="Label13" runat="server" ForeColor="White" Text="Staff Page" ></asp:Label>
            </p>
                
            <asp:Label ID="Label12" runat="server" ForeColor="White" Text="This page is for staff members only. Only authorized staff can access this page and the services provided."></asp:Label>
            <br /> 
        </div>
            </span>
            <br>
            <br>

            <!-- Below will be our buttons to access each service page -->
            
            <section style="margin-left: auto; margin-right: auto; text-align: center; height: 75px;">

                
                <asp:Panel ID="Panel1" runat="server" Height="74px" BackColor="Gold">

                    <br />

                <asp:Button ID="serviceBtn1" runat="server" Font-Bold="True" Height="35px" Text="Register New Staff" Width="207px" OnClick="serviceBtn1_Click" style="margin-left: 0px" BackColor="Maroon" ForeColor="White" />
&nbsp;
                <asp:Button ID="serviceBtn2" runat="server" Font-Bold="True" Height="35px" Text="Find Member" Width="144px" OnClick="serviceBtn2_Click" BackColor="Maroon" ForeColor="White" />
&nbsp;
                <asp:Button ID="serviceBtn3" runat="server" Font-Bold="True" Height="35px" Text="Access Member Services" Width="257px" OnClick="serviceBtn3_Click" BackColor="Maroon" ForeColor="White" />
&nbsp;
                <asp:Button ID="backBtn" runat="server" Font-Bold="True" Height="35px" OnClick="backBtn_Click" Text="Back" Width="75px" BackColor="Maroon" ForeColor="White" />
&nbsp;
                <asp:Button ID="logoutBtn" runat="server" Font-Bold="True" Height="35px" OnClick="logoutBtn_Click" Text="Logout" Width="75px" BackColor="Maroon" ForeColor="White" />

                
               </asp:Panel>

            </section>


            <!-- This Section is for when a Staff member click on "Register New Staff" -->

            <section style="margin-left: auto; margin-right: auto; text-align: center; " class="auto-style7">

                

                <asp:Panel ID="registerPanel" runat="server" Height="155px">
                    <table class="auto-style1" style="background-color:gold">
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Staff Username:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtStaffUser" runat="server" Height="24px" Width="190px"></asp:TextBox>
                                <asp:Label ID="userMissingLabel" runat="server" Font-Italic="True" Font-Size="Large" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style5">&nbsp;<asp:Label ID="firstNameLabel" runat="server" Font-Bold="True" Font-Size="Large" Text="First Name:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtFirstName" runat="server" Height="24px" Width="190px"></asp:TextBox>
                                <asp:Label ID="firstMissingLabel" runat="server" Font-Italic="True" Font-Size="Large" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Staff Password:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtStaffPassword" runat="server" Height="24px" Width="190px"></asp:TextBox>
                                <asp:Label ID="pwMissingLabel" runat="server" Font-Italic="True" Font-Size="Large" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                            </td>
                            <td class="auto-style5">&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Last Name:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtLastName" runat="server" Height="24px" Width="190px"></asp:TextBox>
                                <asp:Label ID="lastMissingLabel" runat="server" Font-Italic="True" Font-Size="Large" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Height="29px" OnClick="btnRegister_Click" Text="Register Staff" Width="131px" BackColor="Maroon" ForeColor="White" />
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="responseLabel" runat="server" Font-Italic="True" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>              
            </section>


            <!-- This Section takes care of the Search For Staff Button -->
            <section style="margin-left: auto; margin-right: auto; text-align: center; " class="auto-style8">


                <asp:Panel ID="findPanel" runat="server" Height="105px" Visible="False" BackColor="Gold">
                    <table class="auto-style9" style="background-color:gold">
                        <tr>
                            <td class="auto-style28">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" Text="Member Search (username):"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtMemberUser" runat="server" Height="24px" Width="107px"></asp:TextBox>
                                <asp:Label ID="emptyMember" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="#FF3300"></asp:Label>
                            </td>
                            <td class="auto-style28">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" Text="Staff Search (last name):"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="txtStaffSearch" runat="server" Height="24px" Width="132px"></asp:TextBox>
                                <asp:Label ID="noStaffLabel" runat="server" Font-Italic="True" Font-Size="X-Small" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <br />
                    
                    <asp:Button ID="btnSearch" runat="server" Font-Bold="True" Height="29px" Text="Search" Width="131px" OnClick="btnSearch_Click" BackColor="Maroon" ForeColor="White" /> 
                    &nbsp; 
                </asp:Panel>
            </section>

            <section style="margin-left: auto; margin-right: auto; text-align: center; " class="auto-style11">

                <asp:Panel ID="findResultsPanel" runat="server" Height="41px">
                    <table class="auto-style12" style="background-color:gold">
                        <tr>
                            <td class="auto-style13">
                                <asp:Label ID="userExistsLabel" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <section class="auto-style11" style="margin-left: auto; margin-right: auto; text-align: center; ">
                                    <asp:Panel ID="findResultsPanel2" runat="server" CssClass="auto-style27" Height="168px">
                                        <table class="auto-style18" style="background-color:gold">
                                            <tr>
                                                <td class="auto-style21">
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" Text="First Name"></asp:Label>
                                                </td>
                                                <td class="auto-style22">
                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" Text="Last Name"></asp:Label>
                                                </td>
                                                <td class="auto-style22">
                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Large" Text="Username"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">
                                                    <asp:Label ID="first6" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="last6" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="username6" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">
                                                    <asp:Label ID="first7" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="last7" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="username7" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">
                                                    <asp:Label ID="first8" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="last8" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="username8" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style25">
                                                    <asp:Label ID="first9" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="last9" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style26">
                                                    <asp:Label ID="username9" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style21">
                                                    <asp:Label ID="first10" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style22">
                                                    <asp:Label ID="last10" runat="server"></asp:Label>
                                                </td>
                                                <td class="auto-style22">
                                                    <asp:Label ID="username10" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </section>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </section>
            


        </div>
    </form>
</body>
</html>
