using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // בדיקה אם קיים שם משתמש
                string SQL = $"SELECT COUNT (admin) FROM " + Helper.tblName +
                    $" WHERE userName='{Request.Form["username"]}'";

                int count = (int)Helper.GetScalar(SQL);
                if (count > 0)
                {
                    usernameError.InnerHtml = "User Name is taken";
                }
                else
                {       // בניית השורה להוספה
                    SQL = $"INSERT INTO UserDatabase (fname, lname, city, date, email, username, password, phone, gender, question1, answer1, question2, answer2, admin) " +
                        $"VALUES ('{Request.Form["firstName"]}', '{Request.Form["lastName"]}', " +
                        $"'{Request.Form["city"]}', '{Request.Form["birthDate"]}', " +
                        $"'{Request.Form["email"]}', '{Request.Form["username"]}', " +
                        $"'{Request.Form["password"]}', '{Request.Form["phone"]}', " +
                        $"'{Request.Form["gender"]}', '{Request.Form["question1"]}', " +
                        $"'{Request.Form["answer1"]}', '{Request.Form["question2"]}', " +
                        $"'{Request.Form["answer2"]}', 0);";
                    Helper.ExecuteNonQuery(SQL);
                    Response.Redirect("home.aspx");
                }
            }
        }
    }
}