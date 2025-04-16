using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DefaultPage.Account
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                    //STORE ENCRYPTED PW IN pwEncrypt


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

            //if username and/or pw is empty
            if(userpwtxtCheck == false)
            {
                userErrorLabel.Text = "Please input a username and/or password.";
                
            }

            // if captcha/username or pw is empty, display all error messages.
            if(captchaCheck == false)
            {

                if(userpwtxtCheck == false)
                {
                    userErrorLabel.Text = "Please input a username and/or password.";
                    captchaErrorLabel.Text = "Please enter the text above into the following textbox.";
                }
                else
                {
                    captchaErrorLabel.Text = "Please enter the text above into the following textbox.";
                }
            }


            /* ADD A NEW USER TO OUR XML DOCUMENT 
            * (insert here because if Username is found we return, so this code will be 
            * unreachable at that time, so do not have to worry about adding duplicates)
            */
            XmlElement myNewMember = myDoc.CreateElement("Member", myDoc.NamespaceURI);
            myDoc.AppendChild(myNewMember);

            // add Username
            XmlElement newUser = myDoc.CreateElement("Username", myDoc.NamespaceURI);
            myNewMember.AppendChild(newUser);
            newUser.InnerText = user;

            // add password
            XmlElement userPwd = myDoc.CreateElement("Password", myDoc.NamespaceURI);
            myNewMember.AppendChild(userPwd);
            userPwd.InnerText = pwEnrypt;


            myDoc.Save(filePath);



            
            

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
    }
}