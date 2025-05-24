using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using solaris_final;

public partial class solaris_final_EditUser3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userToUpdate"] == null)
            {
                Response.Redirect("error.aspx");
                return;
            }

            int Id = (int)Session["userToUpdate"];
            string SQLStr = $"SELECT * FROM UserDatabase WHERE Id={Id}";
            var ds = Helper.RetrieveTable(SQLStr);
            var dt = ds.Tables[Helper.tblName];
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                fname.Value = dr["fname"].ToString();
                lname.Value = dr["lname"].ToString();
                username.Value = dr["username"].ToString();
                password.Value = dr["password"].ToString();
                if (dr["date"] != DBNull.Value)
                {
                    date.Value = ((DateTime)dr["date"]).ToString("yyyy-MM-dd");
                }
                city.Value = dr["city"].ToString();
            }
        }
    }

    public void UpdateUser(object sender, EventArgs e)
    {
        if (Session["userToUpdate"] == null)
        {
            Response.Redirect("error.aspx");
            return;
        }

        int Id = (int)Session["userToUpdate"];
        string SQLStr = $"UPDATE UserDatabase SET " +
                        $"fname=N'{fname.Value}', " +
                        $"lname=N'{lname.Value}', " +
                        $"username=N'{username.Value}', " +
                        $"password=N'{password.Value}', " +
                        $"date='{date.Value}', " +
                        $"city=N'{city.Value}' " +
                        $"WHERE Id={Id}";

        Helper.ExecuteNonQuery(SQLStr);

        Response.Redirect("DeleteUpdate.aspx");
    }
}
