using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DefaultPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //// MODIFY  NECESSARY
            HttpCookie myCookies = Request.Cookies["staffCookies"];
            if (myCookies != null)
            {
                Session["Username"] = myCookies["Username"];
                Session["Password"] = myCookies["Password"];
            }

        }

        /*
         * Login Button Click
         */
        protected void LoginFunc(object sender, EventArgs e)
        {

            HttpCookie myCookies = new HttpCookie("staffCookie");

            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Staff.xml");

            bool redirect = false;  // used for testing purposes only

            if (File.Exists(fLocation))
            {
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                XmlNode node = xd;
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                {
                    // use hash function if the credential is hashed
                    // check if the username and password exist in the XML file;
                    if (UserName.Text == child.FirstChild.InnerText)
                    {
                        if (Password.Text == child.LastChild.InnerText)
                        {
                            Session["Username"] = UserName.Text;
                            Session["Password"] = Password.Text;
                            myCookies["Username"] = UserName.Text;
                            myCookies["Password"] = Password.Text;
                            myCookies.Expires = DateTime.Now.AddDays(30);       // cookie will expire in 30 days
                            Response.Cookies.Add(myCookies);
                            Response.Redirect("ProtectedStaffService/StaffPage.aspx");      // implement with our staff page path
                            redirect = true;        // not needed, comment out after testing
                        }
                    }
                }

                FS.Close();


            }

            if (redirect == false)
            {
                Output.Text = "Your Username and/or Password is incorrect. Please Try Again.";
            }
        }





    }
}