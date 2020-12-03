using System.Data.SQLite;
using API.Models.Interface;
using MySql.Data.MySqlClient;
namespace API.Models {
    public class SaveAccount : IInsertAccount {
        public void InsertAccount (Accounts value) {
            DBConnect db = new DBConnect ();
            bool isOpen = db.OpenConnection ();

            if (isOpen) {
                MySqlConnection conn = db.GetConn ();
                MySqlCommand cmd = new MySqlCommand ();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO accounts(empfname, emplname, dept) VALUES(@empfname, @emplname, @dept)";
                cmd.Parameters.AddWithValue ("@empfname", value.EmpFName);
                cmd.Parameters.AddWithValue ("@emplname", value.EmpLName);
                cmd.Parameters.AddWithValue ("@dept", value.Dept);
                cmd.Prepare ();
                cmd.ExecuteNonQuery ();

                db.CloseConnection();
            }

            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            // cmd.CommandText = @"INSERT INTO accounts(empfname, emplname, dept, employerid) VALUES(@empfname, @emplname, @dept, @employerid)";
            // cmd.Parameters.AddWithValue("@empfname", value.EmpFName);
            // cmd.Parameters.AddWithValue("@emplname", value.EmpLName);
            // cmd.Parameters.AddWithValue("@dept", value.Dept);
            // cmd.Parameters.AddWithValue("@employerid", value.EmployerID);
            // cmd.Prepare();
            // cmd.ExecuteNonQuery();
        }
    }
}