using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefaultPage.Account
{
    public partial class MemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /*
         * Allows user to logout/signout of their membership account 
         * Takes them back to default page
         */
        protected void logoutBtn_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");

        }


        /*
         * Takes a member back to our default page
         */
        protected void backBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }
    }
}