using System.Data.SQLite;
using API.Models.Interface;
using System;
namespace API.Models
{
    public class EditClock : IEditClock
    {
        public void UpdateClock(int id, DateTime timein, DateTime timeout)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"UPDATE clocks SET timeout = @timeout, timeworked = @timeworked WHERE id = @id";
            //cmd.Parameters.AddWithValue("@timein", timein);
            timeout = DateTime.Now;
            // System.Console.WriteLine(id);
            // System.Console.WriteLine(timein);
            //System.Console.WriteLine(timeout);
            TimeSpan timeDiff = timeout.Subtract(timein);
            double timeDif = timeDiff.Hours;
            //System.Console.WriteLine(timeDif);
            cmd.Parameters.AddWithValue("@timeout", timeout);
            cmd.Parameters.AddWithValue("@timeworked", timeDif);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();


            //System.Console.WriteLine("I made it here! ID is " + id + " and value is " + value);
        }
    }
}