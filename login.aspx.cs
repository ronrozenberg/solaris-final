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
        private const string UsernameKey = "globalusername";
        private const string PasswordKey = "globalpassword";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnClick(object sender, EventArgs e)
        {
            if (usernameError.InnerHtml == "" && passwordError.InnerHtml == "" && username.Value != "" && password.Value != "")
            {
                Application[UsernameKey] = username.Value;
                Application[PasswordKey] = password.Value;
            }
        }
    }
}