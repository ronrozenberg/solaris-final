using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = GetRow((string)Session["globalusername"]);
            if (user.admin == false)
            {
                tohide1.Style.Add("display", "none");
                tohide2.Style.Add("display", "none");
                tohide3.Style.Add("display", "none");
                tohide4.Style.Add("display", "none");
            }
            if (Session["globalusername"].ToString() == "אורח")
            {
                logout.Style.Add("display", "none");
            }
            usernamegreeting.InnerHtml = "שלום " + Session["globalusername"];
        }

    

    public static User GetRow(string userName)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(Helper.conString);

            // בניית פקודת SQL
            string SQL = $"SELECT username, admin FROM " + Helper.tblName +
                    $" WHERE username='{userName}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // שימוש בנתונים שהתקבלו
            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.username = reader.GetString(0);
                user.admin = reader.GetBoolean(1);
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