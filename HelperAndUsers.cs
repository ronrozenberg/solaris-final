using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace solaris_final
{

   public class User
    {
        public int Id;
        public int phone;
        public string username;
        public string email;
        public string password;
        public string fname;
        public string lname;
        public DateTime date;
        public string city;
        public bool admin;
        public bool gender;
        public User()
        {
            Id = -1;
            username = "אורח";
            password = "";
            fname = "";
            lname = "";
            date = DateTime.Today;
            city = "";
            admin = false;

        }
        public User(int Id, string uName)
        {
            this.Id = Id;
            username = uName;
        }
    }
    public static class Helper
    {
        public const string DBName = "Database1.mdf";
        public const string tblName = "UserDatabase";
        public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"
                                        + DBName + ";Integrated Security=True";

        public static DataSet RetrieveTable(string SQLStr)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(SQLStr, con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            ad.Fill(ds, tblName);

            return ds;
        }

        public static object GetScalar(string SQL)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            object scalar = cmd.ExecuteScalar();
            con.Close();

            return scalar;
        }

        public static int ExecuteNonQuery(string SQL)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();

            return n;
        }

        public static void Delete(int[] IdToDelete)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQL = "SELECT * FROM " + tblName;
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tblName);

            for (int i = 0; i < IdToDelete.Length; i++)
            {
                DataRow[] dr = ds.Tables[tblName].Select($"Id = {IdToDelete[i]}");
                dr[0].Delete();
            }

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetDeleteCommand();
            adapter.Update(ds, tblName);
        }

        public static void Update(User user)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where Id={user.Id}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            DataRow dr = ds.Tables[tblName].Rows[0];
            dr["fname"] = user.fname;
            dr["lname"] = user.lname;
            dr["username"] = user.username;
            dr["password"] = user.password;
            dr["date"] = user.date;
            dr["city"] = user.city;

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds, tblName);

        }

        public static void Insert(User user)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            DataRow dr = ds.Tables[tblName].NewRow();
            dr["fname"] = user.fname;
            dr["lname"] = user.lname;
            dr["username"] = user.username;
            dr["password"] = user.password;
            dr["date"] = user.date;
            dr["city"] = user.city;
            ds.Tables[tblName].Rows.Add(dr);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetInsertCommand();
            adapter.Update(ds, tblName);
        }

        public static User GetRow(string username, string password)

        {
            SqlConnection con = new SqlConnection(conString);

            string SQL = $"SELECT fname, admin FROM " + tblName +
                    $" WHERE username='{username}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.username = reader.GetString(0);
                user.admin = reader.GetBoolean(1);
            }
            else
            {
                user.username = "Visitor";
                user.admin = false;
            }
            reader.Close();
            con.Close();
            return user;
        }

        public static string BuildSimpleUsersTable(DataTable dt)
        {
            string str = "<table class='usersTable' align='center'>";
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + column.ColumnName + "</td>";
            }

            foreach (DataRow row in dt.Rows)
            {
                str += "<tr>";
                foreach (DataColumn column in dt.Columns)
                {
                    str += "<td>" + row[column] + "</td>";
                }
                str += "</tr>";
            }
            str += "</tr>";
            str += "</Table>";
            return str;
        }

        public static string BuildUsersTable(DataTable dt)
        {

            string str = "<table class='usersTable' align='center'>";
            str += "<tr>";
            str += "<td> </td>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + column.ColumnName + "</td>";
            }

            foreach (DataRow row in dt.Rows)
            {
                str += "<tr>";
                str += "<td>" + CreateRadioBtn(row["Id"].ToString()) + "</td>";
                foreach (DataColumn column in dt.Columns)
                {
                    str += "<td>" + row[column] + "</td>";
                }
                str += "</tr>";
            }
            str += "</tr>";
            str += "</Table>";
            return str;
        }

        public static string CreateRadioBtn(string id)
        {
            return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
        }

        public static DataTable SortTable(DataTable dt, string column, string dir)
        {
            dt.DefaultView.Sort = column + " " + dir;
            return dt.DefaultView.ToTable();
        }

        public static DataTable FilterTable(DataTable dt, string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return dt;

            filter = filter.Replace("'", "''");

            List<string> filters = new List<string>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(string))
                    filters.Add($"{col.ColumnName} LIKE '%{filter}%'");
                else if (col.DataType == typeof(int) && int.TryParse(filter, out int intVal))
                    filters.Add($"{col.ColumnName} = {intVal}");
                else if (col.DataType == typeof(bool) && bool.TryParse(filter, out bool boolVal))
                    filters.Add($"{col.ColumnName} = {boolVal}");
            }
            dt.DefaultView.RowFilter = string.Join(" OR ", filters);
            return dt.DefaultView.ToTable();
        }

    }
}