using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["login"] == false)
            {
                Response.Redirect("Home.aspx");
            }
            if (Session["globalusername"].ToString() != "Ron")
            {
                tohide1.Style.Add("display", "none");
                tohide2.Style.Add("display", "none");
                tohide3.Style.Add("display", "none");
                tohide4.Style.Add("display", "none");
            }
            usernamegreeting.InnerHtml = "שלום " + Session["globalusername"];
        }
    }
}