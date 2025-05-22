using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class solaris_final_EditUser3: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataRow dr = (DataRow)Session["userToUpdate"];

            //  מילוי השדות בטופס
            fname.Value = dr["fname"].ToString();
            lname.Value = dr["lname"].ToString();
            username.Value = dr["username"].ToString();
            lname.Value = dr["lname"].ToString();
            password.Value = dr["password"].ToString();
            if (!dr.IsNull("date"))
            {
                date.Value = ((DateTime)(dr["date"])).ToString("yyy-MM-dd");
            }

            city.Value = dr["city"].ToString();
        }

    }

    public void UpdateUser(object sender, EventArgs e)
    {

        // התחברות למסד הנתונים
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        // בניית פקודת SQL
        DataRow row = (DataRow)Session["userToUpdate"];
        int userId = (int)row["userId"];
        string SQLStr = $"SELECT * FROM tblUsers Where userid={userId}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "users");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["users"].Rows[0];
        ds.Tables["users"].Rows[0]["fname"] = fname.Value;
        ds.Tables["users"].Rows[0]["lname"] = lname.Value;
        dr["username"] = username.Value;
        dr["password"] = password.Value;
        dr["date"] = DateTime.Parse(date.Value);
        dr["city"] = city.Value;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, "users");

        Response.Redirect("DeleteUpdate.aspx");
    }
}