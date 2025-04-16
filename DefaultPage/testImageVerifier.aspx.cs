using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefaultPage
{
    public partial class testImageVerifier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageProcess1.aspx";
        }

        protected void btnSumit_Click(object sender, EventArgs e)
        {
            if (Session["generatedString"].Equals(TextBox1.Text)) {
                Label1.Text = "Congratulation. The code you entered is correct!";
            } else {
                Label1.Text = "Im sorry, the string doesn't match. Try again!";
            }
        }

        protected void btnShowImage_Click(object sender, EventArgs e)
        {
            CaptchaReference.ServiceClient fromService = new CaptchaReference.ServiceClient();
            string userLength = "5";
            Session["userLength"] = userLength;
            string myStr = fromService.GetVerifierString(userLength);
            Session["generatedString"] = myStr;
            btnShowImage.Text = "Show Me Another Image String";
            Image1.Visible = true;
        }
    }
}