using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace pa_taverne
{
    public class AccessoDatiLnx : AccessoDati
    {
        private MySql.Data.MySqlClient.MySqlConnection cnn;
        private OdbcConnection CnnMysql;
        private string StrConnect;
        private MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        private DataTable dt;
        private MySqlCommand cb;

        public AccessoDatiLnx()
        {

            //StrConnect = "Server=62.149.150.71;Database=Sql178902_2;Uid=Sql178902;Pwd=2af698be;";
            //StrConnect = "Provider=MySQLProv; Data Source=62.149.150.71; User ID =Sql178902; Password=2af698be; Initial Catalog=Sql178902_2;";
            //StrConnect = "Driver={MySQL ODBC 3.51 Driver};Server=62.149.150.71;Database=Sql178902_2;User=Sql178902; Password=2af698be;Option=3;";
            StrConnect = "SERVER=localhost;DATABASE=sql178902_2;User=root;Password=root;";
            //StrConnect = "SERVER=62.149.150.71;DATABASE=sql178902_2;User=Sql178902;Password=2af698be;";
            

        }

        public override DataTable getDT(string SQL)
        {

            cnn = new MySql.Data.MySqlClient.MySqlConnection();
            cnn.ConnectionString = StrConnect;
            cnn.Open();

            dt = new DataTable();
            try
            {

                adapter = new MySqlDataAdapter(SQL, cnn);
                adapter.Fill(dt);
                return dt;
            }

            finally 
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }

        public override int Esegui(string SQL)
        {
            cnn = new MySql.Data.MySqlClient.MySqlConnection();
            cnn.Open();
            try
            {
                cb = new MySqlCommand(SQL, cnn);
                return cb.ExecuteNonQuery();
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }

            }
        }

    }

}

