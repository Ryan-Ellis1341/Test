using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DefaultPage
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Session["Login"] = false;
            Application["SessionCounter"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {
            Response.Write("<hr />The Website was last visited on " + DateTime.Now.ToString());
        }

        void Application_Error(object sender, EventArgs e)
        {/*
            Response.Write("<hr />An unexpected error occured");
            if (!System.Diagnostics.EventLog.SourceExists("ASPNETApplication")) {
                System.Diagnostics.EventLog.CreateEventSource("ASPNETApplication", "Application");
            }
            System.Diagnostics.EventLog.WriteEntry("ASPNETApplication", Server.GetLastError().Message);*/
        }

        void Session_Start(object sender, EventArgs e)
        {
            Int32 count = (Int32)Application["SessionCounter"];
            count++;
            Application["SessionCounter"] = count;
        }
        void Session_End(object sender, EventArgs e)
        {
            Int32 count = (Int32)Application["SessionCounter"];
            count--;
            Application["SessionCounter"] = count;
        }
    }
}