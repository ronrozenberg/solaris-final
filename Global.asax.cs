using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace solaris_final
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["counter"] = 0;
            Application["loggedin"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["globalusername"] = "אורח";
            Session["globalpassword"] = "";
            Session["login"] = false;
            Session["online"] = 0;

            //3 משתמשים גלובאליים
            Session["username1"] = "Itay";
            Session["username2"] = "Moshon";
            Session["username3"] = "Ron";
            Session["password1"] = "123Mewo!";
            Session["password2"] = "KissyFace!23";
            Session["password3"] = "123Nor!";
            Session["isadmin1"] = false;
            Session["isadmin2"] = false;
            Session["isadmin3"] = true;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["online"] = (int)Session["online"] - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}