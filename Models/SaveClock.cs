using System;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using API.Models.Interface;
namespace API.Models {
    public class SaveClock : IInsertClock {
        public void InsertClockIn (Clocks value) {
            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            // cmd.CommandText = @"INSERT INTO clocks(timein, timeout, timeworked, empid, roleid) VALUES(@timein, @timeout, @timeworked, @empid, @roleid)";
            // DateTime clockIn = DateTime.Now;
            // System.Console.WriteLine("The emp id is " + value.EmpID);
            // System.Console.WriteLine("The time now is " + clockIn);
            // cmd.Parameters.AddWithValue("@timein", clockIn);
            // cmd.Parameters.AddWithValue("@timeout", clockIn);
            // cmd.Parameters.AddWithValue("@timeworked", 0);
            // cmd.Parameters.AddWithValue("@empid", value.EmpID);
            // cmd.Parameters.AddWithValue("@roleid", value.RoleID);
            // cmd.Prepare();
            // cmd.ExecuteNonQuery();

            // System.Console.WriteLine("The time clocked in is " + value.TimeIn);
            // System.Console.WriteLine(value.TimeID);

            DBConnect db = new DBConnect ();
            bool isOpen = db.OpenConnection ();

            if (isOpen) {
                MySqlConnection conn = db.GetConn ();
                MySqlCommand cmd = new MySqlCommand ();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO clocks(timein, timeout, timeworked, empid, roleid) VALUES(@timein, @timeout, @timeworked, @empid, @roleid)";
                DateTime clockIn = DateTime.Now;
                System.Console.WriteLine ("The emp id is " + value.EmpID);
                System.Console.WriteLine ("The time now is " + clockIn);
                cmd.Parameters.AddWithValue ("@timein", clockIn);
                cmd.Parameters.AddWithValue ("@timeout", clockIn);
                cmd.Parameters.AddWithValue ("@timeworked", 0);
                cmd.Parameters.AddWithValue ("@empid", value.EmpID);
                cmd.Parameters.AddWithValue ("@roleid", value.RoleID);
                cmd.Prepare ();
                cmd.ExecuteNonQuery ();

                db.CloseConnection ();
            }
        }

        public void InsertClockOut (Clocks value) {
            // string cs = @"URI=file:/Users/katiemulholland/source/repos/321Consulting/API/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            // cmd.CommandText = @"INSERT INTO clocks(timein, timeout, timeworked, empid, roleid) VALUES(@timein, @timeout, @timeworked, @empid, @roleid)";
            // DateTime clockOut = DateTime.Now;
            // TimeSpan timeDiff = value.TimeOut.Subtract(value.TimeIn);
            // double timeDif = timeDiff.Hours;
            // cmd.Parameters.AddWithValue("@timein", value.TimeIn);
            // cmd.Parameters.AddWithValue("@timeout", value.TimeOut);
            // cmd.Parameters.AddWithValue("@timeworked", value.TimeWorked);
            // cmd.Parameters.AddWithValue("@empid", value.EmpID);
            // cmd.Parameters.AddWithValue("@roleid", value.RoleID);
            // cmd.Prepare();
            // cmd.ExecuteNonQuery();
        }
    }
}