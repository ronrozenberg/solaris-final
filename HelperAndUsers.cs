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
        public int userId;
        public string userName;
        public string password;
        public string firstName;
        public string lastName;
        public DateTime birthday;
        public string city;
        public bool Admin;
        public User()
        {
            userId = -1;
            userName = "";
            password = "";
            firstName = "";
            lastName = "";
            birthday = DateTime.Today;
            city = "";
            Admin = false;

        }
        public User(int userId, string uName)
        {
            this.userId = userId;
            userName = uName;
        }
    }
    public static class Helper
    {
        public const string DBName = "Database1.mdf";   //Name of the MSSQL Database.
        public const string tblName = "tblUsers";      // Name of the user Table in the Database
        public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"
                                        + DBName + ";Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|

        public static DataSet RetrieveTable(string SQLStr)
        // Gets A table from the data base acording to the SELECT Command in SQLStr;
        // Returns DataSet with the Table.
        {
            // connect to DataBase
            SqlConnection con = new SqlConnection(conString);

            // Build SQL Query
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // Build DataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            // Build DataSet to store the data
            DataSet ds = new DataSet();

            // Get Data form DataBase into the DataSet
            ad.Fill(ds, tblName);

            return ds;
        }

        public static object GetScalar(string SQL)
        {
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� ����� SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ����� �������
            con.Open();
            object scalar = cmd.ExecuteScalar();
            con.Close();

            return scalar;
        }

        public static int ExecuteNonQuery(string SQL)
        {
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� ����� SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ����� �������
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();

            // return the number of rows affected
            return n;
        }

        public static void Delete(int[] userIdToDelete)
        // The Array "userIdToDelete" contain the id of the users to delete. 
        // Delets all the users in the array "userIdToDelete".
        {
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� �������
            string SQL = "SELECT * FROM " + tblName;
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tblName);

            // ����� ����� ������ ���� ����� ��
            for (int i = 0; i < userIdToDelete.Length; i++)
            {
                DataRow[] dr = ds.Tables[tblName].Select($"userId = {userIdToDelete[i]}");
                dr[0].Delete();
            }

            // ����� ����� �� ����� �������
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetDeleteCommand();
            adapter.Update(ds, tblName);
        }

        public static void Update(User user)
        // The Method recieve a user objects. Find the user in the DataBase acording to his userId and update all the other properties in DB.
        {
            // HttpRequest Request
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� ����� SQL
            string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userid={user.userId}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            //  ����� ������� ���� DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            // ����� ����� ������
            DataRow dr = ds.Tables[tblName].Rows[0];
            dr["firstName"] = user.firstName;
            dr["lastName"] = user.lastName;
            dr["userName"] = user.userName;
            dr["password"] = user.password;
            dr["birthday"] = user.birthday;
            dr["city"] = user.city;

            // ����� ����� �� ����� �������
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds, tblName);

        }

        public static void Insert(User user)
        // The Method recieve a user objects and insert it to the Database as new row. 
        // The Method does't check if the user is already taken.
        {
            //HttpRequest Request
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� ����� SQL
            string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // ����� DataSet
            DataSet ds = new DataSet();

            // ����� ����� �������
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            // ����� ����� ������
            DataRow dr = ds.Tables[tblName].NewRow();
            dr["firstName"] = user.firstName;
            dr["lastName"] = user.lastName;
            dr["userName"] = user.userName;
            dr["password"] = user.password;
            dr["birthday"] = user.birthday;
            dr["city"] = user.city;
            ds.Tables[tblName].Rows.Add(dr);

            // ����� ����� �� ����� �������
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetInsertCommand();
            adapter.Update(ds, tblName);
        }

        public static User GetRow(string userName, string password)
        // The Method check if there is a user with userName and Password. 
        // If true the Method return a user with the first Name and Admin property.
        // If not the Method return a user with first name "Visitor" and Admin = false

        {
            // ������� ���� �������
            SqlConnection con = new SqlConnection(conString);

            // ����� ����� SQL
            string SQL = $"SELECT firstName, admin FROM " + tblName +
                    $" WHERE userName='{userName}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ����� �������
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // ����� ������� �������
            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.userName = reader.GetString(0);
                user.Admin = reader.GetBoolean(1);
            }
            else
            {
                user.userName = "Visitor";
                user.Admin = false;
            }
            reader.Close();
            con.Close();
            return user;
        }

        public static string BuildSimpleUsersTable(DataTable dt)
        // the Method Build HTML user Table using the users in the DataTable dt.
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
        // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
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
                str += "<td>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
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

        public static DataTable FilterTable(DataTable dt, string column, string criteria)
        {
            dt.DefaultView.RowFilter = column + "=" + criteria;
            return dt.DefaultView.ToTable();
        }
    }
    }