using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class Stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["globalusername"] != "Ron")
            {
                Response.Redirect("error.aspx");
            }
            int val = 0;
            int online = 0;
            online += (int)Session["online"];
            val += (int)Application["counter"];
            counter.InnerHtml = val.ToString();
            onlinec.InnerHtml = online.ToString();
            counterloggedin.InnerHtml = Application["loggedin"].ToString();
        }
    }
}