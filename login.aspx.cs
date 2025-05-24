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
            if (IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("test ");
                if (Request.Form["usernameError"] == "" && Request.Form["passwordError"] == "" && Request.Form["userName"] != "" && Request.Form["password"] != "")
                {
                    User user = GetRow(Request.Form["userName"], Request.Form["password"]);
                    System.Diagnostics.Debug.WriteLine("test 2");
                    if (user.username == "אורח")
                    {
                        Session["login"] = false;
                    }
                    else
                    {
                        Session["login"] = true;
                        Session["globalusername"] = Request.Form["userName"];
                        Session["globalpassword"] = Request.Form["password"];
                        Console.WriteLine("User logged in: " + user.username);
                        Response.Redirect("home.aspx");
                    }
                }
                else { Session["login"] = false; }
            }
        }

        public static User GetRow(string userName, string password)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(Helper.conString);

            // בניית פקודת SQL
            string SQL = $"SELECT username, admin FROM " + Helper.tblName +
                    $" WHERE username='{userName}' AND password = '{password}'";
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
    }
}