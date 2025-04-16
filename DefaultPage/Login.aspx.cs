/*
 * Description: Our Login Page is strictly for staff members in order to login using their username and password.
 *              After logging in once, the implementation of cookies/session states (implemented 
 *              by Gabriel and Jessica) makes it so that a user only needs to login once in order
 *              to gain access to the Member page, so long as they do not logout. However, this feature is optional
 *              since Staff have special priveleges, so a staff member can elect to not "stay signed in"
 *              upon leaving the Staff Page for information security purposes.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Encrypt_Decrypt_Lib;

namespace DefaultPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["SmyCookieId"];
            if (!(myCookies == null || myCookies["Username"] == ""))
            {
                UserName.Text = myCookies["SUsername"];
                Password.Text = myCookies["SPassword"];
            }
        }

        /*
         * Login Button Click
         */
        protected void LoginFunc(object sender, EventArgs e)
        {

            string filePath = HttpRuntime.AppDomainAppPath + @"\Protected\App_Data\Staff.xml";

            string user = UserName.Text;
            string password = Password.Text;

            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"\Protected\App_Data\Staff.xml");

            bool redirect = false;  // used for testing purposes only

            /* ENCRYPTION/DECRYPTION */
            string pwEncrypt = Encrypt_Decrypt.Encrypt(Password.Text);



            /* Create XmlDocument and load the Members.xml data into it */
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filePath);

            XmlElement rootElement = myDoc.DocumentElement;     // open file

            foreach (XmlNode node in rootElement.ChildNodes)
            {

                // if username and pw match, create login cookie and redirect to MemberPage
                // else, diplay invalid credentials 
                if (node["Username"].InnerText == user && node["Password"].InnerText == pwEncrypt)
                {
                    // compare encrypted passwords to see if they are the same,
                    // cannot get my decryption to work (Encrypt_Decrypt.Decrypt(node["Password"].InnerText))
                    if (node["Password"].InnerText == pwEncrypt)
                    {
                        Output.Visible = false;

                        if(Persistent.Checked)
                        {
                            Session["MemberName"] = user;
                            Session["MemberID"] = 2;

                            HttpCookie myCookies = new HttpCookie("SmyCookieId");
                            myCookies["SUsername"] = user;
                            myCookies["SPassword"] = password;
                            Response.Cookies.Add(myCookies);
                        }


                        Response.Redirect("Protected/StaffPage.aspx");
                        return;
                    }
                    // Username exists but pw doesnt match
                    else
                    {
                        Output.Text = "Invalid Password";
                        Output.Visible = true;
                        return;
                    }
                }
            }

            Output.Text = "Username does not exist";
            Output.Visible = true;
            return;

        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }
    }
}