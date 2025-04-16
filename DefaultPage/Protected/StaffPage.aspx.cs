/*
 * Description: The Staff Page is only accessible by authorized staff. Staff Members will have access 
 *              to Members Services in addition to having certain privelleges like "Registering New Staff" 
 *              & "Searching" for Staff Members or Members. It is in this page only where new Staff
 *              Members can be registered and saved to our Staff.xml file using their First and Last name
 *              along with their preferred username and password. A staff member will also be able to confirm
 *              the registeration by performing last name search inquiries of our staff. They can all search 
 *              to see if a particular member name exists or not. 
 */


using Encrypt_Decrypt_Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DefaultPage.Protected
{
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            registerPanel.Visible = false;
            findPanel.Visible = false;
            findResultsPanel.Visible = false;
            findResultsPanel2.Visible = false;
        }

        protected void logoutBtn_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Session["MemberID"] = 0;
            Session["MemberName"] = "";
            
            Server.Transfer("~/Default.aspx");
            
            /*
            Response.Redirect("http://webstrar13.fulton.asu.edu/page3/Default");
            */
        }

        protected void backBtn_Click(object sender, EventArgs e) {
            
            Server.Transfer("~/Default.aspx");
            
            /*
            Response.Redirect("http://webstrar13.fulton.asu.edu/page3/Default");
            */
        }


        /*
         *  Service 1 Button Allows certain staff members to register new staff
         */
        protected void serviceBtn1_Click(object sender, EventArgs e) {

            // When clicked, make our registerPanel visible
            registerPanel.Visible = true;

        }

        /*
         * Service 2 Button make search feature visible to return all staff members searched for
         * findPanel.Visible = true;
         */
        protected void serviceBtn2_Click(object sender, EventArgs e) 
        {
            if(registerPanel.Visible)
            {
                registerPanel.Visible = false;
            }

            findPanel.Visible = true;


        }





        /*
         *  service 3 button will redirect our staff to access member services
         */
        protected void serviceBtn3_Click(object sender, EventArgs e) {
            Response.Redirect("~/Account/MemberPage.aspx");
        }




        /*
         *  Register New Staff Member Button *Hidden within register panel*
         *  
         */
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            registerPanel.Visible = true;

            bool txtEmpty = false;

            string username = "";
            string password = "";
            string pwEnrypt = "";

            string first = "";
            string last = "";

            /* Set our Missing Data Asterisks visibility to false */
            userMissingLabel.Visible = false;
            pwMissingLabel.Visible = false;
            firstMissingLabel.Visible = false;
            lastMissingLabel.Visible = false;


            // set forecolor of responseLabel to Red for errors, green for success
            responseLabel.ForeColor = Color.Red;

            XmlDocument myDoc = new XmlDocument();      // used to help check our Staff.xml doc

            // file path to our Staff.xml document
            string filePath = HttpRuntime.AppDomainAppPath + @"\Protected\App_Data\Staff.xml";

            // IMPLEMENTATION BELOW

            // if the text boxes that hold our username, password, and First & Last Name are not empty, move on.
            if (txtStaffPassword.Text.ToString() != String.Empty && txtStaffUser.Text.ToString() != String.Empty && txtFirstName.Text.ToString() != String.Empty && txtLastName.Text.ToString() != String.Empty)
            {

                // assign the username and password and NAME to our variables for XML search/check
                username = txtStaffUser.Text;
                password = txtStaffPassword.Text;
                first = txtFirstName.Text;
                last = txtLastName.Text;

                //IMPLEMENT ENCRYPTION/DECRYPTION

                //STORE ENCRYPTED PW IN pwEncrypt using Encrypt_Decrypt_Lib
                pwEnrypt = Encrypt_Decrypt.Encrypt(password);

                myDoc.Load(filePath);       // load Staff.xml into myDoc

                XmlElement rootElement = myDoc.DocumentElement;   //open file

                    foreach (XmlNode node in rootElement.ChildNodes)
                    {
                        // in our xml doc, any child node entitled Username that has its innertext 
                        // equal to the username trying to be registered, error message will be displayed
                        if (node["Username"].InnerText == username)
                        {
                            responseLabel.Text = String.Format("Staff with username {0} already exists.", username);
                            responseLabel.Visible = true;
                            return;
                        }

                    }

                    //userErrorLabel.Visible = false;
            }

            else
            {
                txtEmpty = true;
            }

            //if textboxes are empty, display error and return avoid nullreference error acception
            if (txtEmpty == true)
            {
                responseLabel.Text = "Missing Information";

                // Sequence of if statements to display red asterisks next 
                // to each text box that is "Missing Information"
                if(txtStaffUser.Text.ToString() == String.Empty)
                {
                    userMissingLabel.Visible = true;
                }
                if (txtStaffPassword.Text.ToString() == String.Empty)
                {
                    pwMissingLabel.Visible = true;
                }
                if (txtFirstName.Text.ToString() == String.Empty)
                {
                    firstMissingLabel.Visible = true;
                }
                if (txtLastName.Text.ToString() == String.Empty)
                {
                    lastMissingLabel.Visible = true;
                }

                return;
            }

            /* IF THE USERNAME DOESN'T ALREADY EXIST AND NONE OF THE TEXTBOXES WERE EMPTY, CONTINUE */

            /* ADD A NEW USER TO OUR XML DOCUMENT 
            * (insert here because if Username is found we return, so this code will be 
            * unreachable at that time, so do not have to worry about adding duplicates)
            */
            XmlElement myNewMember = myDoc.CreateElement("Member", myDoc.NamespaceURI);
            myDoc.DocumentElement.AppendChild(myNewMember);

                 
            // add Last Name
            XmlElement userLast = myDoc.CreateElement("Last", myDoc.NamespaceURI);
            myNewMember.AppendChild(userLast);
            userLast.InnerText = last;   
            // add First Name
            XmlElement userFirst = myDoc.CreateElement("First", myDoc.NamespaceURI);
            myNewMember.AppendChild(userFirst);
            userFirst.InnerText = first;
             // add Username
            XmlElement newUser = myDoc.CreateElement("Username", myDoc.NamespaceURI);
            myNewMember.AppendChild(newUser);
            newUser.InnerText = username; 
            // add password
            XmlElement userPwd = myDoc.CreateElement("Password", myDoc.NamespaceURI);
            myNewMember.AppendChild(userPwd);
            userPwd.InnerText = pwEnrypt;


            myDoc.Save(filePath);
            responseLabel.ForeColor = Color.Green;  // set color to green to show SUCCESS, otherwise red
            responseLabel.Text = "SAVE SUCCESS";
            


        }


        /*
         *  Search Button is located in our findPanel. The findPanel.Visible = tue
         *  when a Staff Member clicks on Find Member. The search feature will allow for
         *  Staff to look up usernames and passwords for Members and it will also allow
         *  them to search for Staff Members by last name.
         */
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            // Set FindPanel and FindResultsPanel visiblity to true
            findPanel.Visible = true;
            findResultsPanel.Visible = true;

            // set our 3 lables to false upon button press to reset previous result
            userExistsLabel.Visible = false;
            emptyMember.Visible = false;
            noStaffLabel.Visible = false;

            // List<string> objects to store staff username, first & last name 
            // List used in case more than one staff member have the same last name
            List<string> lastNameList = new List<string>();
            List<string> firstNameList = new List<string>();
            List<string> staffNameList = new List<string>();

            string lastName;                             // used for searching staff by last name
            string userName = txtMemberUser.Text;        // used for searching member usernames

            bool userName_Exists = false;                // used for error handling 
            bool staffExists = false;                    // used for error handling
            bool txtboxesempty = false;                  // used for error handling

            // create the filePaths for each xml doc
            string filePath_Staff = HttpRuntime.AppDomainAppPath + @"\Protected\App_Data\Staff.xml";
            string filePath_Members = HttpRuntime.AppDomainAppPath + @"\Account\App_Data\Members.xml";

 
            /* Create XmlDocuments and load the Staff.xml and Members.xml data into them */
            XmlDocument myDocStaff = new XmlDocument();
            XmlDocument myDocMembers = new XmlDocument();

            XmlElement rootElement_Staff;
            XmlElement rootElement_Member;



            // As long as one of the text boxes contains text, search will work.
            if (txtMemberUser.Text.ToString() != String.Empty || txtStaffSearch.Text.ToString() != String.Empty)
            {
                // NOW CHECK EACH TXT BOX TO SEE IF BOTH ARE FILLED IN OR JUST ONE

                // Staff Search Check . . . 
                if (txtStaffSearch.Text.ToString() != String.Empty)
                {
                    lastName = txtStaffSearch.Text;

                    // IMPLEMENT STAFF SEARCH CODE
                    myDocStaff.Load(filePath_Staff);        // load Staff.xml into myDocStaff

                    rootElement_Staff = myDocStaff.DocumentElement;   //open file

                    foreach (XmlNode node in rootElement_Staff.ChildNodes)
                    {
                        // in our xml doc, any child node entitled Username that has its innertext 
                        // equal to the username trying to be registered, error message will be displayed
                        if (node["Last"].InnerText == lastName)
                        {
                            lastNameList.Add(lastName);
                            firstNameList.Add(node["First"].InnerText);
                            staffNameList.Add(node["Username"].InnerText);

                            staffExists = true;     // set staffExists Error handler to true
                        }


                    }

                }

                    if (txtMemberUser.Text.ToString() != String.Empty)
                    {
                        userName = txtMemberUser.Text;

                        // IMPLEMENT MEMBER SEARCH CODE
                        myDocMembers.Load(filePath_Members);    // load Members.xml into myDocMembers

                        rootElement_Member = myDocMembers.DocumentElement;   //open file


                        foreach (XmlNode node in rootElement_Member.ChildNodes)
                        {
                            // in our xml doc, any child node entitled Username that has its innertext 
                            // equal to the username trying to be registered, error message will be displayed
                            if (node["Username"].InnerText == userName)
                            {
                                userName_Exists = true;
                            }


                        }
                    }                
            

            }
            else
            {
                txtboxesempty = true;
            }

            // if both text boxes are empty . . . print the one error and return
            if (txtboxesempty)
            {
                userExistsLabel.ForeColor = Color.Red;
                userExistsLabel.Text = "No Search Parameters Found.";
                userExistsLabel.Visible = true;
                return;
            }            
            

            // Print contents to our GUI
            if(userName_Exists)
            {
                //Display message: We have one register member with the username . . . 
                //set visibility to true
                userExistsLabel.ForeColor = Color.Black;
                userExistsLabel.Text = string.Format("There is one registered member with the username: {0}", userName);
                userExistsLabel.Visible = true;

            }
            else
            {

                if (txtMemberUser.Text.ToString() == String.Empty)
                {
                    emptyMember.Text = "Enter Username";
                }
                else
                {
                    userExistsLabel.ForeColor = Color.Red;
                    userExistsLabel.Text = String.Format("No member with the Username: {0} exists.", userName);
                    userExistsLabel.Visible = true;
                }

            }


            int totalFinds = lastNameList.Count;
            string[] lastNameArr = new string[totalFinds];
            string[] firstName = new string[totalFinds];
            string[] staffUserName = new string[totalFinds];

            lastNameArr = lastNameList.ToArray();
            firstName = firstNameList.ToArray();
            staffUserName = staffNameList.ToArray();

            if (staffExists)
            {
                // Displays up to 5 Staff members who have the same last name
                switch(totalFinds)
                {
                    case 1:
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        break;

                    case 2:
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        first7.Text = firstName[1];
                        last7.Text = lastNameArr[1];
                        username7.Text = staffUserName[1];
                        break;

                    case 3:                       
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        first7.Text = firstName[1];
                        last7.Text = lastNameArr[1];
                        username7.Text = staffUserName[1];
                        first8.Text = firstName[2];
                        last8.Text = lastNameArr[2];
                        username8.Text = staffUserName[2];
                        break;

                    case 4:
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        first7.Text = firstName[1];
                        last7.Text = lastNameArr[1];
                        username7.Text = staffUserName[1];
                        first8.Text = firstName[2];
                        last8.Text = lastNameArr[2];
                        username8.Text = staffUserName[2];
                        first9.Text = firstName[3];
                        last9.Text = lastNameArr[3];
                        username9.Text = staffUserName[3];
                        break;

                    case 5:
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        first7.Text = firstName[1];
                        last7.Text = lastNameArr[1];
                        username7.Text = staffUserName[1];
                        first8.Text = firstName[2];
                        last8.Text = lastNameArr[2];
                        username8.Text = staffUserName[2];
                        first9.Text = firstName[3];
                        last9.Text = lastNameArr[3];
                        username9.Text = staffUserName[3];
                        first10.Text = firstName[4];
                        last10.Text = lastNameArr[4];
                        username10.Text = staffUserName[4];
                        break;

                    default:
                        first6.Text = firstName[0];
                        last6.Text = lastNameArr[0];
                        username6.Text = staffUserName[0];
                        first7.Text = firstName[1];
                        last7.Text = lastNameArr[1];
                        username7.Text = staffUserName[1];
                        first8.Text = firstName[2];
                        last8.Text = lastNameArr[2];
                        username8.Text = staffUserName[2];
                        first9.Text = firstName[3];
                        last9.Text = lastNameArr[3];
                        username9.Text = staffUserName[3];
                        first10.Text = firstName[4];
                        last10.Text = lastNameArr[4];
                        username10.Text = staffUserName[4];
                        break;

                }
                

                findResultsPanel2.Visible = true;
            }

            else
            {
                noStaffLabel.Text = "*DNE*";

                noStaffLabel.Visible = true;
                

            }
            



        }
    }
}