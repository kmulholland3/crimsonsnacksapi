using System.Data.SQLite;
using API.Models.Interface;
namespace API.Models
{
    public class DeleteClock : IDelete
    {
        public void Remove(int id){
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM clocks WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}