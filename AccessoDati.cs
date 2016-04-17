using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;


namespace pa_taverne
{
    public class AccessoDati
    {
        private OleDbConnection Cnn;
        private OdbcConnection CnnMysql;
        private string StrConnect;

        public  AccessoDati()
        {
            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                StrConnect = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + ConfigurationManager.AppSettings["DBpath"];
            }
            else
            {
                //StrConnect = "Server=62.149.150.71;Database=Sql178902_2;Uid=Sql178902;Pwd=2af698be;";
                //StrConnect = "Provider=MySQLProv; Data Source=62.149.150.71; User ID =Sql178902; Password=2af698be; Initial Catalog=Sql178902_2;";
                StrConnect = "Driver={MySQL ODBC 3.51 Driver};Server=62.149.150.71;Database=Sql178902_2;User=Sql178902; Password=2af698be;Option=3;";
            }
        }

        public virtual DataTable getDT(string SQL)
        {
            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                Cnn = new OleDbConnection(StrConnect);
            }
            else
            {
                CnnMysql = new OdbcConnection(StrConnect);
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter da;
            OdbcDataAdapter daMysql;

            try
            {
                if (ConfigurationManager.AppSettings["DB"] == "Access")
                {
                    Cnn.Open();
                }
                else
                {
                    CnnMysql.Open();
                }
                try
                {
                    if (ConfigurationManager.AppSettings["DB"] == "Access")
                    {
                        da = new OleDbDataAdapter(SQL, Cnn);
                        da.Fill(dt);
                        return dt;
                    }
                    else
                    {
                        daMysql = new OdbcDataAdapter(SQL, CnnMysql);
                        daMysql.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception Ex1)
                {
                    throw Ex1;
                }
                finally
                {
                    try
                    {
                        if (ConfigurationManager.AppSettings["DB"] == "Access")
                        {
                            Cnn.Close();
                            Cnn.Dispose();
                        }
                        else
                        {
                            CnnMysql.Close();
                            CnnMysql.Dispose();
                        }
                    }
                    catch (Exception Ex2)
                    {
                        throw Ex2;
                    }
                }
            }
            catch (Exception Ex3)
            {
                throw Ex3;
            }
        }

        public virtual int Esegui(string SQL)
        {
            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                Cnn = new OleDbConnection(StrConnect);
            }
            else
            {
                CnnMysql = new OdbcConnection(StrConnect);
            }
            OleDbCommand cmd;
            OdbcCommand cmdMysql;

            try
            {
                if (ConfigurationManager.AppSettings["DB"] == "Access")
                {
                    Cnn.Open();
                }
                else
                {
                    CnnMysql.Open();
                }
                try
                {
                    if (ConfigurationManager.AppSettings["DB"] == "Access")
                    {
                        cmd = new OleDbCommand(SQL, Cnn);
                        return cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmdMysql = new OdbcCommand(SQL, CnnMysql);
                        return cmdMysql.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex1)
                {
                    throw Ex1;
                }
                finally
                {
                    try
                    {
                        if (ConfigurationManager.AppSettings["DB"] == "Access")
                        {
                            Cnn.Close();
                            Cnn.Dispose();
                        }
                        else
                        {
                            CnnMysql.Close();
                            CnnMysql.Dispose();
                        }
                    }
                    catch (Exception Ex2)
                    {
                        throw Ex2;
                    }
                }
            }
            catch (Exception Ex3)
            {
                throw Ex3;
            }
        }

    }
}
