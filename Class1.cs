using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace AccessoryPower_Final

{


    public class DBConnect
    {

        
    
        public MySqlConnection connection;
        public string server;
        public string database;
        public string uid;
        public string password;
        public DataTable dt = new DataTable() ;
           public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            server = "xxx.xxx.xxx.xxx";
            database = "ACP_testing";
            uid = "ACP_test";
            password = "abcdefghi";
            string connectionString;
            connectionString = "PORT=3307;SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        //for Inserting any tables
            public void Insertdata( string insertcommand )
            {
                connection.Open();

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = insertcommand;
                sql.Connection = connection;
                sql.ExecuteNonQuery();
                connection.Close();

 
            }
        //for update any table
            public void Updatedata(string updatecommand)
            {
                connection.Open();
                MySqlCommand sql = new MySqlCommand(updatecommand,connection);
                sql.ExecuteNonQuery();
                connection.Close();
                
            }
        // for delete any table

            public void Deletedata(string deletecommand)
            {
                connection.Open();
             
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = deletecommand;
                sql.Connection = connection;
                sql.ExecuteNonQuery();
                connection.Close();
            }
        // for retriving and ID from any table
            public string FindMaxID(string FindID)
            {
                              

                DataSet ds = new DataSet();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(FindID, connection);
                da.Fill(ds, "details");
                            
                DataTable dt = ds.Tables["details"];

                connection.Close();
                string LastID = "";
                LastID = (dt.Rows[0][0]).ToString();
                return LastID;
            }
        // for geting the data from database
            public DataSet SelectData(string ID)
            {
                DataSet ds = new DataSet();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(ID, connection);
                da.Fill(ds, "details");

                connection.Close();
                return ds;
            }

            public DataSet SelectAllPart(string ID)
            {
                DataSet ds = new DataSet();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(ID, connection);
                da.Fill(ds, "AllPart");

                

                connection.Close();
                return ds;
            }
            
        }

    }





