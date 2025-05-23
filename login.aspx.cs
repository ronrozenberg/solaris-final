using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static User GetRow(string userName, string password)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(Helper.conString);

            // בניית פקודת SQL
            string SQL = $"SELECT userName, admin FROM " + Helper.tblName +
                    $" WHERE userName='{userName}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // שימוש בנתונים שהתקבלו
            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                userName = reader.GetString(0);
            }
            else
            {
                userName = "אורח";
            }
            reader.Close();
            con.Close();
            return user;
        }

        protected void btnClick(object sender, EventArgs e)
        {
            if (usernameError.InnerHtml == "" && passwordError.InnerHtml == "" && userName.Value != "" && password.Value != "")
            {
                User user = GetRow(userName.Value, password.Value);

                if (user.username == "אורח")
                {
                    Session["login"] = false;
                }
                else
                {
                    Session["login"] = true;
                    //Response.Redirect("/Pages/Main.aspx");
                }
                Session["globalusername"] = userName.Value;
                Session["globalpassword"] = password.Value;
                Session["login"] = true;
                Response.Redirect("Home.aspx");
            }
            else { Session["login"] = false; }
        }
    }
}