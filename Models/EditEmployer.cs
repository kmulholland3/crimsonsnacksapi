using System.Data.SQLite;
using API.Models.Interface;
using MySql.Data.MySqlClient;
namespace API.Models {
    public class EditEmployer : IEditEmployer {
        public void UpdateEmployer (int id, string username, string password)         {

            DBConnect db = new DBConnect ();
            bool isOpen = db.OpenConnection ();

            if (isOpen) {
                MySqlConnection conn = db.GetConn ();
                MySqlCommand cmd = new MySqlCommand ();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE employers SET username = @username, password = @password WHERE employerid = @id";            
                cmd.Parameters.AddWithValue ("@username", username);
                cmd.Parameters.AddWithValue ("@password", password);            
                cmd.Parameters.AddWithValue ("@id", id);            
                cmd.Prepare ();            
                cmd.ExecuteNonQuery ();

                db.CloseConnection ();
            }
            //             string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            //             using var con = new SQLiteConnection(cs);
            //             con.Open();

            //             using var cmd = new SQLiteCommand(con);

            //             cmd.CommandText = @"UPDATE employers SET username = @username, password = @password WHERE employerid = @id";
            //             cmd.Parameters.AddWithValue("@username", username);
            //             cmd.Parameters.AddWithValue("@password", password);
            //             cmd.Parameters.AddWithValue("@id", id);
            //             cmd.Prepare();
            //             cmd.ExecuteNonQuery();

            //System.Console.WriteLine("I made it here! ID is " + id + " and value is " + value);
                    
        }
    }
}