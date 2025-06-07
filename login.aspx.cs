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
                if (Request.Form["userName"] != "" && Request.Form["password"] != "")
                {
                    User user = GetRow(Request.Form["userName"], Request.Form["password"]);
                    System.Diagnostics.Debug.WriteLine("test 2");
                    if (user.username == "אורח")
                    {
                        Response.Redirect("loginerror.aspx");
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
                else { Session["login"] = false; Response.Redirect("loginerror.aspx"); }
            }
        }

        public static User GetRow(string userName, string password)
        {
            SqlConnection con = new SqlConnection(Helper.conString);

            string SQL = $"SELECT username, admin FROM " + Helper.tblName +
                    $" WHERE username='{userName}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.username = reader.GetString(0);
            }
            else
            {
                user.username = "אורח";
            }
            reader.Close();
            con.Close();
            return user;
        }
    }
}