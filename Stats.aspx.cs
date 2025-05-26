using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(Helper.conString);

            // בניית פקודת SQL
            string SQL = $"SELECT username, admin FROM " + Helper.tblName +
                    $" WHERE username='{Session["globalusername"]}' AND admin=1";
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // שימוש בנתונים שהתקבלו
            User user = new User();
            if (!reader.HasRows)
            {
                reader.Close();
                con.Close();
                Response.Redirect("error.aspx");
            }
            int val = 0;
            int online = 0;
            online += (int)Application["online"];
            val += (int)Application["counter"];
            counter.InnerHtml = val.ToString();
            onlinec.InnerHtml = online.ToString();
            counterloggedin.InnerHtml = Application["loggedin"].ToString();
        }
    }
}