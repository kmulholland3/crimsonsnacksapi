using System.Data.SQLite;
using API.Models.Interface;
namespace API.Models
{
    public class SaveEmployer : IInsertEmployer
    {
        public void InsertEmployer(Employers value)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO employers(username, password) VALUES(@username, @password)";
            cmd.Parameters.AddWithValue("@username", value.UserName);
            cmd.Parameters.AddWithValue("@password", value.Password);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}