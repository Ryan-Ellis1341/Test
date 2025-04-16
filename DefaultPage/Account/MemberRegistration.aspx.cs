/*
 * Description: In our MemberRegistration Page, prospective members are able to register for our services. The only 
 *              requirements to sign up is to create a Username and Password that does not alreayd exist. Only by
 *              registering will a member be able to access our services.
 *              An image verifier is used on this registration page only in order to confirm the user is not a bot. 
 *              The member registration controller is responsible maintaining/updating/searching our Members.xml
 *              file so that only authenticated members can access this page. Additionally, that use of a DLL library
 *              (Encrypt_Decrypt_Lib) helps to provide more security by storing our new members passwords (and staff)
 *              in an encrypted format within our .xml files.
 */


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
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            captchaImage.ImageUrl = "~/imageProcess1.aspx";
        }


        /*
         *  Register new account button
         *  
         *  Need to search xml doc to see if username exists already, 
         *  if not then add the new account information to our XML doc (Members.xml)
         *  
         *  Also, on click it checks to see if our user string matches the captcha
         * 
         */
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool captchaCheck = true;
            bool userpwtxtCheck = true;
            
            string user = "";
            string password = "";
            string pwEnrypt = "";

            XmlDocument myDoc = new XmlDocument();      // used to help check our Members.xml doc


            if (Session["generatedString"].Equals(txtCaptcha.Text))
            {
                captchaErrorLabel.Text = "";
            }
            else
            {
                captchaErrorLabel.Text = "Incorrect. Please try again.";
                return;
            }


            // file path to our Members.xml document
            string filePath = HttpRuntime.AppDomainAppPath + @"\Account\App_Data\Members.xml";

            // if the text boxes that hold our username and password are not empty, move on.
            if (txtPassword.Text.ToString() != String.Empty && txtUsername.Text.ToString() != String.Empty)
            {
                //if the captcha is not empty, then continue to move forward, else set captchaCheck = false;
                if (txtCaptcha.Text.ToString() != String.Empty)
                {
                    // assign the username and password to our variables for XML search/check
                    user = txtUsername.Text;
                    password = txtPassword.Text;

                    //IMPLEMENT ENCRYPTION/DECRYPTION

                    //STORE ENCRYPTED PW IN pwEncrypt using Encrypt_Decrypt_Lib
                    pwEnrypt = Encrypt_Decrypt.Encrypt(password);


                    // 
                    myDoc.Load(filePath);       // load Members.xml into myDoc

                    XmlElement rootElement = myDoc.DocumentElement;   //open file

                    foreach (XmlNode node in rootElement.ChildNodes)
                    {
                        // in our xml doc, any child node entitled Username that has its innertext 
                        // equal to the username trying to be registered, error message will be displayed
                        if (node["Username"].InnerText == user)
                        {
                            userErrorLabel.Text = String.Format("Account with username {0} already exists.", user);
                            userErrorLabel.Visible = true;
                            return;
                        }

                    }

                    //userErrorLabel.Visible = false;
                }
                else
                {
                    captchaCheck = false;
                }
            } 
            
            else 
            {
                userpwtxtCheck = false;
            }

            //if username and/or pw is empty and return to avoid nullreference error acception
            if(userpwtxtCheck == false) {
                userErrorLabel.Text = "Please input a username and/or password.";
                return;
            }

            

                /* ADD A NEW USER TO OUR XML DOCUMENT 
                * (insert here because if Username is found we return, so this code will be 
                * unreachable at that time, so do not have to worry about adding duplicates)
                */
            XmlElement myNewMember = myDoc.CreateElement("Member", myDoc.NamespaceURI);
            myDoc.DocumentElement.AppendChild(myNewMember);

            // add Username
            XmlElement newUser = myDoc.CreateElement("Username", myDoc.NamespaceURI);
            myNewMember.AppendChild(newUser);
            newUser.InnerText = user;

            // add password
            XmlElement userPwd = myDoc.CreateElement("Password", myDoc.NamespaceURI);
            myNewMember.AppendChild(userPwd);
            userPwd.InnerText = pwEnrypt;


            myDoc.Save(filePath);

            userErrorLabel.Text = "SAVE SUCCESS";
            Session["MemberName"] = user;
            Session["MemberID"] = 1;
            Response.Redirect("MemberPage.aspx");
        }


        /*
         *  Back Home Button Click Event Handler
         * 
         *  Take our user back to the home page
         */
        protected void btnHome_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Default.aspx");

        }


        /*
         *  Member Registration Login Button Event Handler
         *  
         *  Copy of our Member Login Button Event Handler
         */
        protected void loginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin.aspx"); //existing member must have come here by mistake
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

            foreach (XmlNode node in rootElement.ChildNodes)
            {

                // if username and pw match, create login cookie and redirect to MemberPage
                // else, diplay invalid credentials 
                if (node["Username"].InnerText == user)
                {
                    // compare encrypted passwords to see if they are the same,
                    // cannot get my decryption to work (Encrypt_Decrypt.Decrypt(node["Password"].InnerText))
                    if (node["Password"].InnerText == pwdEncrypt)
                    {
                        userErrorLabel.Visible = false;
                        //createLoginCookie();
                        Response.Redirect("MemberPage.aspx");
                        return;
                    }
                    // Username exists but pw doesnt match
                    else
                    {
                        userErrorLabel.Text = "*Invalid Credentials";
                        userErrorLabel.Visible = true;
                        return;
                    }
                }
            }

            userErrorLabel.Text = "*Invalid Credentials";
            userErrorLabel.Visible = true;
            return;

        }

        /*
         * User Control For Image Verifier - Created by Jessica Wood & Gabriel Anderson
         */
        protected void btnReCaptcha_Click(object sender, EventArgs e)
        {

            CaptchaReference.ServiceClient fromService = new CaptchaReference.ServiceClient();
            string userLength = "5";
            Session["userLength"] = userLength;
            string myStr = fromService.GetVerifierString(userLength);
            Session["generatedString"] = myStr;
            captchaImage.Visible = true;
        }
    }
}