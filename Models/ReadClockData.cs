using System.Collections.Generic;
using System.Data.SQLite;
using API.Models.Interface;
namespace API.Models
{
    public class ReadClockData : IGetAllClocks, IGetClock

    {
        public List<Clocks> GetAllClocks()
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            
            string stm = "SELECT * FROM clocks ORDER BY id";
            using var cmd = new SQLiteCommand(stm,con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            List<Clocks> allClocks = new List<Clocks>();
            while(rdr.Read()){
                allClocks.Add(new Clocks(){TimeID = rdr.GetInt32(0), TimeIn = rdr.GetDateTime(1), TimeOut = rdr.GetDateTime(2), TimeWorked = rdr.GetDouble(3), EmpID = rdr.GetInt32(4), RoleID = rdr.GetInt32(5)});
            }

            return allClocks;
        }

        public Clocks GetClock(int id)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM clocks WHERE id = @id";
            using var cmd = new SQLiteCommand(stm,con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Clocks(){TimeID = rdr.GetInt32(0), TimeIn = rdr.GetDateTime(1), TimeOut = rdr.GetDateTime(2), TimeWorked = rdr.GetDouble(3), EmpID = rdr.GetInt32(4), RoleID = rdr.GetInt32(5)};
        }
    }
}