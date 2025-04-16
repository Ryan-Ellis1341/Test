using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefaultPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         *  Member Login Button Click Event Handler
         *  
         *  
         */
        protected void mLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/MemberLogin.aspx");        // re-direct to the login page for members
        }


        /*
         *  Member Home Page Button Click Event Handler
         *  
         *  Check first to see if the member is already logged in,
         *  if so, then it goes right to the Member Home Page.
         *  Otherwise, go to Member Login.
         */
        protected void mHomePageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/MemberPage.aspx");       // re-direct to the member page if already logged in
        }


        /*
         *  Staff Login Button Click Event Handler
         */
        protected void sLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");        // need to create separate login for staff

        }


        /*
         *  Staff Home Page Button Click Event Handler
         *  
         *  Check first to see if the staff is already logged in, 
         *  if so, then it goes righ to the Staff Home Page. 
         *  Otherwise, go to the Staff Login.
         */
        protected void sHomePageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffPage.aspx");        // re-direct to the staff page if already logged in
        }
    }
}