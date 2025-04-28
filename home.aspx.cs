using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int visit = (int)Application["counter"];
            Application["counter"] = visit + 1;
            Session["online"] = (int)Session["online"] + 1;
            if ((bool)Session["login"] == true)
            {
                int loggedin = (int)Application["loggedin"] + 1;
                Application["loggedin"] = loggedin;
            }
        }
    }
}