using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solaris_final
{
    public partial class DeleteUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SQL = $"SELECT username, admin FROM {Helper.tblName} WHERE username='{Session["globalusername"]}' AND admin=1";
            DataSet adminDs = Helper.RetrieveTable(SQL);
            DataTable adminDt = adminDs.Tables[Helper.tblName];
            if (adminDt.Rows.Count == 0)
            {
                Response.Redirect("error.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string SQLStr = $"SELECT * FROM {Helper.tblName}";
                Session["ds"] = Helper.RetrieveTable(SQLStr);
                DataTable dt = ((DataSet)Session["ds"]).Tables[Helper.tblName];
                string table = BuildUsersTable(dt);
                tableDiv.InnerHtml = table;
            }
        }

        public string BuildUsersTable(DataTable dt)
        {
            string str = "<table class='usersTable' align='center'>";
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<th>" + column.ColumnName + "</th>";
            }
            str += "</tr>";

            foreach (DataRow row in dt.Rows)
            {
                str += "<tr>";
                foreach (DataColumn column in dt.Columns)
                {
                    str += "<td>" + row[column] + "</td>";
                }
                str += "</tr>";
            }

            str += "</Table>";
            return str;
        }

        public string BuildSQLStr(string str)
        {
            if (str.Length == 0)
            {
                return $"SELECT * FROM {Helper.tblName}";
            }
            string SQLStr = $"SELECT * FROM {Helper.tblName} WHERE" +
                $" firstName LIKE '%{str}%' OR" +
                $" lastName LIKE '%{str}%' ";
            return SQLStr;
        }

        public void Click_Filter(object sender, EventArgs e)
        {
            string expression;
            if (filter.Value == "")
            {
                expression = null;
            }
            else
            {
                expression = $"firstName = '{filter.Value}' OR lastName = '{filter.Value}'";
            }

            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[Helper.tblName];
            DataRow[] dr = dt.Select(expression);
            dt = dr.CopyToDataTable();
            string table = BuildUsersTable(dt);
            tableDiv.InnerHtml = table;
        }

        public void Delete(object sender, EventArgs e)
        {
            if (delete.Value == "")
                return;
            int Id = int.Parse(delete.Value);
            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[Helper.tblName];
            DataRow[] dr = dt.Select($"Id = {Id}");
            if (dr.Length > 0)
            {
                dr[0].Delete();
            }
            else
            {
                msg.InnerHtml = "Id is not valid";
                return;
            }

            string SQLStr = $"SELECT * FROM {Helper.tblName}";
            var con = new System.Data.SqlClient.SqlConnection(Helper.conString);
            var cmd = new System.Data.SqlClient.SqlCommand(SQLStr, con);
            var ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            var builder = new System.Data.SqlClient.SqlCommandBuilder(ad);
            ad.Update(ds, Helper.tblName);

            string table = BuildUsersTable(dt);
            tableDiv.InnerHtml = table;
        }

        public void Edit(object sender, EventArgs e)
        {
            if (edit.Value == "")
                return;
            int Id = int.Parse(edit.Value);
            string expression = $"Id = {Id}";
            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[Helper.tblName];
            DataRow[] dr = dt.Select(expression);
            DataRow row = dr[0];
            Session["userToUpdate"] = row;
            Response.Redirect("EditUser3.aspx");
        }

        public void Add(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        public void ChangeAdmin(object sender, EventArgs e)
        {
            if (change.Value == "")
                return;
            int Id = int.Parse(change.Value);
            string expression = $"Id = {Id}";
            DataSet ds = (DataSet)Session["ds"];
            DataTable dt = ds.Tables[Helper.tblName];
            DataRow[] dr = dt.Select(expression);
            DataRow row = dr[0];
            if ((bool)row["admin"])
            {
                row["admin"] = false;
            }
            else
            {
                row["admin"] = true;
            }

            string SQLStr = $"SELECT * FROM {Helper.tblName}";
            var con = new System.Data.SqlClient.SqlConnection(Helper.conString);
            var cmd = new System.Data.SqlClient.SqlCommand(SQLStr, con);
            var ad = new System.Data.SqlClient.SqlDataAdapter(cmd);
            var builder = new System.Data.SqlClient.SqlCommandBuilder(ad);
            ad.Update(ds, Helper.tblName);

            string table = BuildUsersTable(dt);
            tableDiv.InnerHtml = table;
        }
    }
}
