using System.Collections.Generic;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using API.Models.Interface;
namespace API.Models.Interface
{
    public class ReadAccountData: IGetAllAccounts, IGetAccount
    {
        public List<Accounts> GetAllAccounts()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM accounts ORDER BY id";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                List<Accounts> allAccounts = new List<Accounts>();
                using (var rdr = cmd.ExecuteReader()){
                    while(rdr.Read()){
                        allAccounts.Add(new Accounts(){EmpID = rdr.GetInt32(0), EmpFName = rdr.GetString(1), EmpLName = rdr.GetString(2), Dept = rdr.GetString(3), EmployerID = rdr.GetInt32(4)});
                    }
                }

                db.CloseConnection();
                return allAccounts;
            } else{
                return new List<Accounts>();
            }

            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();
            
            // string stm = "SELECT * FROM accounts ORDER BY id";
            // using var cmd = new SQLiteCommand(stm,con);

            // using SQLiteDataReader rdr = cmd.ExecuteReader();

            // List<Accounts> allAccounts = new List<Accounts>();
            // while(rdr.Read()){
            //     allAccounts.Add(new Accounts(){EmpID = rdr.GetInt32(0), EmpFName = rdr.GetString(1), EmpLName = rdr.GetString(2), Dept = rdr.GetString(3), EmployerID = rdr.GetInt32(4)});
            // }

            // return allAccounts;
        }

        public Accounts GetAccount(int id)
        {

            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM accounts WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                Accounts newAccount = new Accounts();

                using (var rdr = cmd.ExecuteReader()){
                    rdr.Read();
                    newAccount = new Accounts(){EmpID = rdr.GetInt32(0), EmpFName = rdr.GetString(1), EmpLName = rdr.GetString(2), Dept = rdr.GetString(3), EmployerID = rdr.GetInt32(4)};
                }

                db.CloseConnection();
                return newAccount;
            } else{
                return new Accounts();;
            }

            // string cs = @"URI=file:" + System.Environment.CurrentDirectory + "/crimsonsnacks.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // string stm = "SELECT * FROM accounts WHERE id = @id";
            // using var cmd = new SQLiteCommand(stm,con);
            // cmd.Parameters.AddWithValue("@id", id);
            // cmd.Prepare();
            // using SQLiteDataReader rdr = cmd.ExecuteReader();

            // rdr.Read();
            // return new Accounts(){EmpID = rdr.GetInt32(0), EmpFName = rdr.GetString(1), EmpLName = rdr.GetString(2), Dept = rdr.GetString(3), EmployerID = rdr.GetInt32(4)};
        }

        // public Accounts GetAccounts(int id)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}