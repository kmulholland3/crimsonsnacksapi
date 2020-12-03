using System.Data.SQLite;
using API.Models.Interface;
namespace API.Models
{
    public class SaveAccount : IInsertAccount
    {
        public void InsertAccount(Accounts value)
        {
            string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO accounts(empfname, emplname, dept, employerid) VALUES(@empfname, @emplname, @dept, @employerid)";
            cmd.Parameters.AddWithValue("@empfname", value.EmpFName);
            cmd.Parameters.AddWithValue("@emplname", value.EmpLName);
            cmd.Parameters.AddWithValue("@dept", value.Dept);
            cmd.Parameters.AddWithValue("@employerid", value.EmployerID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}