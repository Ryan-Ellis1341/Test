using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DefaultPage.Account
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Home Page Button Click Event Handler
         * 
         * Sends user back to our default page.
         */
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


        /*
         *  Member Login Button Click Event Handler - Lecture 24 Slide 43
         */
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string filePath = HttpRuntime.AppDomainAppPath + @"\Account\App_Data\Members.xml";

            string user = txtUsername.Text;
            string password = txtPassword.Text;

            string pwdEncrypt = "";

            /* IMPLEMENT OUR ENCRYPTION/DECRYPTION */



            /* Create XmlDocument and load the Members.xml data into it */
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filePath);

            XmlElement rootElement = myDoc.DocumentElement;     // open file

            foreach(XmlNode node in myDoc.ChildNodes)
            {

                // if username and pw match, create login cookie and redirect to MemberPage
                // else, diplay invalid credentials 
                if(node["Username"].InnerText == user)
                {
                    if(node["Password"].InnerText == pwdEncrypt)
                    {
                        errorLabel.Visible = false;
                        //createLoginCookie();
                        Response.Redirect("MemberPage.aspx");
                        return;
                    }
                    // Username exists but pw doesnt match
                    else
                    {
                        errorLabel.Text = "*Invalid Credentials";
                        errorLabel.Visible = true;
                        return;
                    }
                }
            }

            errorLabel.Text = "*Invalid Credentials";
            errorLabel.Visible = true;
            return;

        }
    }
}