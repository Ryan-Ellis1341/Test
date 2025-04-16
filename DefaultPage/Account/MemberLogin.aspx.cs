

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Encrypt_Decrypt_Lib;

namespace DefaultPage.Account
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if(!(myCookies == null || myCookies["Username"] == ""))
            {
                txtUsername.Text = myCookies["Username"];
                txtPassword.Text = myCookies["Password"];
            }
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
            pwdEncrypt = Encrypt_Decrypt.Encrypt(password); 



            /* Create XmlDocument and load the Members.xml data into it */
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filePath);

            XmlElement rootElement = myDoc.DocumentElement;     // open file

            foreach(XmlNode node in rootElement.ChildNodes)
            {

                // if username and pw match, create login cookie and redirect to MemberPage
                // else, diplay invalid credentials 
                if(node["Username"].InnerText == user)
                {
                    // compare encrypted passwords to see if they are the same,
                    // cannot get my decryption to work (Encrypt_Decrypt.Decrypt(node["Password"].InnerText))
                    if(node["Password"].InnerText == pwdEncrypt)
                    {
                        errorLabel.Visible = false;

                        HttpCookie myCookies = new HttpCookie("myCookieId");
                        myCookies["Username"] = user;
                        myCookies["Password"] = password;
                        Response.Cookies.Add(myCookies);

                        Session["MemberName"] = user;
                        Session["MemberID"] = 1;
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