using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_UsersTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["admin"])
        {
            //Response.Redirect("home.aspx");
        }

        if (!IsPostBack)
        {
            string SQLStr = "SELECT * FROM tblUsers";
            DataSet ds = Helper.RetrieveTable (SQLStr);
            DataTable dt = ds.Tables[0];
             //dt = SortTable(dt, "fname", "ASC");
            string table = Helper.BuildUsersTable(dt);
            tableDiv.InnerHtml = table;
        }
    }

    public string BuildSQLStr (string str)
    {
        if (str.Length==0)
        {
            return "SELECT * FROM tblUsers";
        }
        //string SQLStr = $"SELECT * FROM tblUsers WHERE fname='{str}'";
        //string SQLStr = $"SELECT * FROM tblUsers WHERE fname LIKE '%{str}%'";
        string SQLStr = $"SELECT * FROM tblUsers WHERE" +
            $" fname LIKE '%{str}%' OR" +
            $" lname LIKE '%{str}%' ";
        return SQLStr;
    }


    public void Click_Filter1 (object sender, EventArgs e)
    {
        string SQLStr = BuildSQLStr(Request.Form["filter"]);
        DataSet ds = Helper.RetrieveTable (SQLStr);
        string table = Helper.BuildUsersTable (ds.Tables[0]);
        tableDiv.InnerHtml = table;
    }

    public void Sort(object sender, EventArgs e)
    {
        Click_Filter1(sender, e);
    }

    public void Delete (object sender, EventArgs e)
    {
        int Id;
        // בניית מערך של משתמשים למחיקה
        List<int> usersList = new List<int>();

        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                Id = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                usersList.Add(Id);
            }
        }
        int[] IdToDelete = usersList.ToArray();

        Helper.Delete(IdToDelete);

        // הדפסת הטבלה המעודכנת
        DataSet ds = Helper.RetrieveTable(BuildSQLStr(""));
        string table = Helper.BuildUsersTable(ds.Tables[Helper.tblName]);
        tableDiv.InnerHtml = table;
    }

    public void Edit (object sender, EventArgs e)
    {
        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                Session["userToUpdate"] = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                Response.Redirect("EditUser3.aspx");
                
            }
            
        }
        message.InnerHtml = "No user was Selected";
    }

    public void Add(object sender, EventArgs e)
    {
        Response.Redirect("signup.aspx");
    }

    public void ChangeToadmin (object sender, EventArgs e)
    {
        Changeadmin("admin","True");
    }

    public void ChangeToUser(object sender, EventArgs e)
    {
        Changeadmin("admin","False");
    }

    public void Changeadmin (string column, string Value)
    {
        int counter = 0;
        // בניית שאילתא
        string SQL = $"UPDATE tblUsers " +
            $"SET {column} = '{Value}' " +
            $"WHERE ";
        for (int i = 1; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                if (counter > 0)
                    SQL += "OR ";
                int Id = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
                SQL += $" Id = {Id} ";
                counter++;
            }
        }
        if (counter == 0)
        {
            message.InnerHtml = "You must select Row";
            return;
        }

        // עדכון בסיס הנתונים
        message.InnerHtml = Helper.ExecuteNonQuery(SQL).ToString();

        // הדפסת הטבלה מחדש
        string SQLStr = "SELECT * FROM tblUsers";
        DataSet ds = Helper.RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[0];
        string table = Helper.BuildUsersTable(dt);
        tableDiv.InnerHtml = table;
    }

   
}