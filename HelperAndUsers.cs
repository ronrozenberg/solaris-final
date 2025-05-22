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
            username = "";
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
        public const string DBName = "Database1.mdf";   //Name of the MSSQL Database.
        public const string tblName = "UserDatabase";      // Name of the user Table in the Database
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
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            object scalar = cmd.ExecuteScalar();
            con.Close();

            return scalar;
        }

        public static int ExecuteNonQuery(string SQL)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();

            // return the number of rows affected
            return n;
        }

        public static void Delete(int[] IdToDelete)
        // The Array "IdToDelete" contain the id of the users to delete. 
        // Delets all the users in the array "IdToDelete".
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // טעינת הנתונים
            string SQL = "SELECT * FROM " + tblName;
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tblName);

            // מחיקת שורות שנבחרו מתוך הדאטה סט
            for (int i = 0; i < IdToDelete.Length; i++)
            {
                DataRow[] dr = ds.Tables[tblName].Select($"Id = {IdToDelete[i]}");
                dr[0].Delete();
            }

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetDeleteCommand();
            adapter.Update(ds, tblName);
        }

        public static void Update(User user)
        // The Method recieve a user objects. Find the user in the DataBase acording to his Id and update all the other properties in DB.
        {
            // HttpRequest Request
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where Id={user.Id}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            //  טעינת הנתונים לתוך DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            // בניית השורה להוספה
            DataRow dr = ds.Tables[tblName].Rows[0];
            dr["fname"] = user.fname;
            dr["lname"] = user.lname;
            dr["username"] = user.username;
            dr["password"] = user.password;
            dr["date"] = user.date;
            dr["city"] = user.city;

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds, tblName);

        }

        public static void Insert(User user)
        // The Method recieve a user objects and insert it to the Database as new row. 
        // The Method does't check if the user is already taken.
        {
            //HttpRequest Request
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת סכימת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tblName);

            // בניית השורה להוספה
            DataRow dr = ds.Tables[tblName].NewRow();
            dr["fname"] = user.fname;
            dr["lname"] = user.lname;
            dr["username"] = user.username;
            dr["password"] = user.password;
            dr["date"] = user.date;
            dr["city"] = user.city;
            ds.Tables[tblName].Rows.Add(dr);

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetInsertCommand();
            adapter.Update(ds, tblName);
        }

        public static User GetRow(string username, string password)
        // The Method check if there is a user with username and Password. 
        // If true the Method return a user with the first Name and admin property.
        // If not the Method return a user with first name "Visitor" and admin = false

        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQL = $"SELECT fname, admin FROM " + tblName +
                    $" WHERE username='{username}' AND password = '{password}'";
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
                user.username = "Visitor";
                user.admin = false;
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

        public static DataTable FilterTable(DataTable dt, string column, string criteria)
        {
            dt.DefaultView.RowFilter = column + "=" + criteria;
            return dt.DefaultView.ToTable();
        }
    }
    }