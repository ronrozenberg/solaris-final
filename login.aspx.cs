using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnClick(object sender, EventArgs e)
        {
            if (usernameError.InnerHtml == "" && passwordError.InnerHtml == "" && username.Value != "" && password.Value != "")
            {
                Session["globalusername"] = username.Value;
                Session["globalpassword"] = password.Value;
                Session["login"] = true;
                Response.Redirect("Home.aspx");
            }
            else { Session["login"] = false; }
        }
    }
}