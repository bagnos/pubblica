using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace pa_taverne
{
    public class AccessoDatiScambio
    {
        private OleDbConnection Cnn;
        private string StrConnect;

        public AccessoDatiScambio()
        {
            StrConnect = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=" + ConfigurationManager.AppSettings["PathDati"] + "DatiXsito.mdb";
        }

        public DataTable getDT(string SQL)
        {
            Cnn = new OleDbConnection(StrConnect);
            
            DataTable dt = new DataTable();
            OleDbDataAdapter da;

            try
            {
                Cnn.Open();
                
                try
                {
                    da = new OleDbDataAdapter(SQL, Cnn);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception Ex1)
                {
                    throw Ex1;
                }
                finally
                {
                    try
                    {
                        Cnn.Close();
                        Cnn.Dispose();
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

        public void Esegui(string SQL)
        {
            Cnn = new OleDbConnection(StrConnect);
            
            OleDbCommand cmd;

            try
            {
                Cnn.Open();
                
                try
                {
                    cmd = new OleDbCommand(SQL, Cnn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception Ex1)
                {
                    throw Ex1;
                }
                finally
                {
                    try
                    {
                        Cnn.Close();
                        Cnn.Dispose();
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
