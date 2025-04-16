using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageServiceTryIt
{
    public partial class imageProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            DefaultPage.ImageVerifierService.ServiceClient fromService = new DefaultPage.ImageVerifierService.ServiceClient();
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