using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["globalusername"] = "אורח";
            Session["globalpassword"] = "";
            Session["login"] = false;
            Response.Redirect("Home.aspx");
        }
    }
}