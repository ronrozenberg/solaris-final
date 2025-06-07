using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace solaris_final
{
    public partial class recovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string username = Request.Form["username"];
                string securityQuestion = Request.Form["securityQuestion"];
                string answer = Request.Form["answer"];

                recoveryError.InnerHtml = "";
                recoverySuccess.InnerHtml = "";

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(securityQuestion) || string.IsNullOrEmpty(answer))
                {
                    recoveryError.InnerHtml = "אנא מלא את כל השדות";
                    return;
                }

                string SQL = $"SELECT password FROM {Helper.tblName} WHERE userName='{username}' AND " +
                           $"((question1=N'{securityQuestion}' AND answer1=N'{answer}') OR " +
                           $"(question2=N'{securityQuestion}' AND answer2='N{answer}'))";

                DataSet ds = Helper.RetrieveTable(SQL);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                {
                    recoveryError.InnerHtml = "שם משתמש, שאלה או תשובה שגויים";
                    return;
                }

                string password = dt.Rows[0]["password"].ToString();
                recoverySuccess.InnerHtml = $"הסיסמה שלך היא: <strong>{password}</strong><br/>" +
                                          "<a href='login.aspx' style='color: #4CAF50;'>לחץ כאן להתחברות</a>";
            }
        }
    }
}