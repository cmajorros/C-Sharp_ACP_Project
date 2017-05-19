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
            server = "173.230.154.176";
            database = "devacce_testing2";
            uid = "devacce_testdev2";
            password = "bcKz6XXbBjQqULC2";
            string connectionString;
            connectionString = "PORT=3307;SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

            public void Insertdata( string insertcommand )
            {
                connection.Open();

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = insertcommand;
                sql.Connection = connection;
                sql.ExecuteNonQuery();
                connection.Close();

 
            }

            public void Updatedata(string updatecommand)
            {
                connection.Open();
                MySqlCommand sql = new MySqlCommand(updatecommand,connection);
                sql.ExecuteNonQuery();
                connection.Close();
                
            }

            public void Deletedata(string deletecommand)
            {
                connection.Open();
             
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = deletecommand;
                sql.Connection = connection;
                sql.ExecuteNonQuery();
                connection.Close();
            }
        
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





