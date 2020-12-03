using System.Collections.Generic;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using API.Models.Interface;
namespace API.Models
{
    public class ReadEmployerData : IGetAllEmployers, IGetEmployer
    {
        public List<Employers> GetAllEmployers()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM employers ORDER BY employerid";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                List<Employers> allEmployers = new List<Employers>();
                using (var rdr = cmd.ExecuteReader()){
                    while(rdr.Read()){
                        allEmployers.Add(new Employers(){EmployerID = rdr.GetInt32(0), UserName = rdr.GetString(1), Password = rdr.GetString(2)});
                    }
                }

                db.CloseConnection();
                return allEmployers;
            } else{
                return new List<Employers>();
            }
            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();
            
            // string stm = "SELECT * FROM employers ORDER BY employerid";
            // using var cmd = new SQLiteCommand(stm,con);

            // using SQLiteDataReader rdr = cmd.ExecuteReader();

            // List<Employers> allEmployers = new List<Employers>();
            // while(rdr.Read()){
            //     allEmployers.Add(new Employers(){EmployerID = rdr.GetInt32(0), UserName = rdr.GetString(1), Password = rdr.GetString(2)});
            // }

            // return allEmployers;
        }

        public Employers GetEmployer(int id)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM employers WHERE employerid = @id";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                Employers newEmployer = new Employers();

                using (var rdr = cmd.ExecuteReader()){
                    rdr.Read();
                    newEmployer= new Employers(){EmployerID = rdr.GetInt32(0), UserName = rdr.GetString(1), Password = rdr.GetString(2)};
                }

                db.CloseConnection();
                return newEmployer;
            } else{
                return new Employers();
            }
            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // string stm = "SELECT * FROM employers WHERE employerid = @id";
            // using var cmd = new SQLiteCommand(stm,con);
            // cmd.Parameters.AddWithValue("@id", id);
            // cmd.Prepare();
            // using SQLiteDataReader rdr = cmd.ExecuteReader();

            // rdr.Read();
            // return new Employers(){EmployerID = rdr.GetInt32(0), UserName = rdr.GetString(1), Password = rdr.GetString(2)};
        }
    }
}