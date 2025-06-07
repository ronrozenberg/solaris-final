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
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string SQL = $"SELECT COUNT (admin) FROM " + Helper.tblName +
            $" WHERE userName='{Request.Form["username"]}'";

            int count = (int)Helper.GetScalar(SQL);
            if (count > 0)
            {
                usernameExistsError.InnerHtml = "User Name is taken";
                Response.Redirect("signuperror.aspx");
            }
            else
            {

                SQL = $"INSERT INTO UserDatabase (fname, lname, city, date, email, username, password, phone, gender, question1, answer1, question2, answer2, admin) " +
                    $"VALUES (N'{Request.Form["firstName"]}', N'{Request.Form["lastName"]}', " +
                    $"N'{Request.Form["city"]}', '{Request.Form["birthDate"]}', " +
                    $"N'{Request.Form["email"]}', N'{Request.Form["username"]}', " +
                    $"N'{Request.Form["password"]}', '{Request.Form["phone"]}', " +
                    $"'{Request.Form["gender"]}', N'{Request.Form["question1"]}', " +
                    $"N'{Request.Form["answer1"]}', N'{Request.Form["question2"]}', " +
                    $"N'{Request.Form["answer2"]}', 0);";
                Helper.ExecuteNonQuery(SQL);
            }
        }
    }
}