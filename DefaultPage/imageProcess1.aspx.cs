using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.IO;

namespace DefaultPage
{
    public partial class imageProcess1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            CaptchaReference.ServiceClient fromService = new CaptchaReference.ServiceClient();
            string myStr, userLen;

            if (Session["generatedString"] == null)
            {
                if (Session["userLength"] == null)
                    userLen = "3";
                else
                    userLen = Session["userLength"].ToString();
                myStr = fromService.GetVerifierString(userLen);
                Session["generatedString"] = myStr;
            }
            else
            {
                myStr = Session["generatedString"].ToString();
            }

            Stream myStream = fromService.GetImage(myStr);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            Response.ContentType = "image/jpeg";
            myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}