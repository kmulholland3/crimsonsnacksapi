using System.Data.SQLite;
using API.Models.Interface;
using MySql.Data.MySqlClient;
namespace API.Models {
    public class EditAccount : IEditAccount {
        public void UpdateAccount (int id, string empfname, string emplname, string dept)         {
            DBConnect db = new DBConnect ();
            bool isOpen = db.OpenConnection ();

            if (isOpen) {
                MySqlConnection conn = db.GetConn ();
                MySqlCommand cmd = new MySqlCommand ();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE accounts SET empfname = @empfname, emplname = @emplname, dept=@dept WHERE id = @id";            
                cmd.Parameters.AddWithValue ("@empfname", empfname);
                cmd.Parameters.AddWithValue ("@emplname", emplname);
                cmd.Parameters.AddWithValue ("@dept", dept);            
                cmd.Parameters.AddWithValue ("@id", id);            
                cmd.Prepare ();            
                cmd.ExecuteNonQuery ();

                db.CloseConnection ();
            }

            //             string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            //             using var con = new SQLiteConnection(cs);
            //             con.Open();

            //             using var cmd = new SQLiteCommand(con);

            //             cmd.CommandText = @"UPDATE accounts SET empfname = @empfname, emplname = @emplname, dept=@dept WHERE id = @id";
            //             cmd.Parameters.AddWithValue("@empfname", empfname);
            //             cmd.Parameters.AddWithValue("@emplname", emplname);
            //             cmd.Parameters.AddWithValue("@dept", dept);
            //             cmd.Parameters.AddWithValue("@id", id);
            //             cmd.Prepare();
            //             cmd.ExecuteNonQuery();

            //System.Console.WriteLine("I made it here! ID is " + id + " and value is " + value);
                    
        }
    }
}