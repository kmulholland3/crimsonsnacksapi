using System.Data.SQLite;
using API.Models.Interface;
using MySql.Data.MySqlClient;
namespace API.Models {
    public class DeleteAccount : IDelete {
        public void Remove (int id) {
            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection (cs);
            // con.Open ();

            // using var cmd = new SQLiteCommand (con);

            // cmd.CommandText = @"DELETE FROM accounts WHERE id = @id";
            // cmd.Parameters.AddWithValue ("@id", id);
            // cmd.Prepare ();
            // cmd.ExecuteNonQuery ();
            DBConnect db = new DBConnect ();
            bool isOpen = db.OpenConnection ();

            if (isOpen) {
                MySqlConnection conn = db.GetConn ();
                MySqlCommand cmd = new MySqlCommand ();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM accounts WHERE id = @id";
                cmd.Parameters.AddWithValue ("@id", id);
                cmd.Prepare ();
                cmd.ExecuteNonQuery ();
            }
        }
    }
}