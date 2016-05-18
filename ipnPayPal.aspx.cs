using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa_taverne
{
    public partial class ipnPayPal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Post back to either sandbox or live
            string strOriginaRequest = "";
            try
            {
                string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                // string strLive = "https://www.paypal.com/cgi-bin/webscr";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);


                Dictionary<String, String> responseMap = new Dictionary<string, string>();


                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                strOriginaRequest = strRequest;
                strRequest += "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;

                //for proxy
                //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
                //req.Proxy = proxy;

                //Send the request to PayPal and get the response

                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = streamIn.ReadToEnd();
                streamIn.Close();


                if (strResponse == "VERIFIED")
                {
                    //UPDATE YOUR DATABASE

                    //TextWriter txWriter = new StreamWriter(Server.MapPath("../uploads/") + Session["orderID"].ToString() + ".txt");
                    //txWriter.WriteLine(strResponse);
                    //txWriter.Close();


                    String[] pairs = strOriginaRequest.Split('&'); // split nvp
                    if (pairs != null)
                    {
                        foreach (String pair in pairs)
                        {
                            String[] nvp = pair.Split('='); // split key value
                            if (nvp != null && nvp.Length > 1)
                            {
                                responseMap.Add(nvp[0], Server.UrlDecode(nvp[1]));
                            }
                        }

                    }
                    String receiver_email = "othalaBusines2@othala.it";
                    String custom = responseMap["custom"];

                    

                    String[] items = custom.Split(',');
                    String famiglia = items[0];
                    String quota = items[1];
                    //String[] soci = items[1].Split(' ');
                    String nome = items[2];
                    String idSocio = items[3];
                    Query query = new Query();

                    bool errori = false;
                    String descrErrore = "";

                    //check that txn_id has not been previously processed
                    DataTable dtTxn = query.verificaTxNid(famiglia, (responseMap["txn_id"]));
                    if (dtTxn.Rows.Count > 0)
                    {
                        errori = true;
                        descrErrore = responseMap["txn_id"] + " già presente ";
                    }
                    //check the payment_status is Completed
                    if (responseMap["payment_status"] != "Completed")
                    {
                        errori = true;
                        descrErrore += responseMap["payment_status"] + " diverso da Completed";
                    }
                    //check that receiver_email is your Primary PayPal email
                    if (responseMap["receiver_email"] != receiver_email)
                    {
                        descrErrore += responseMap["receiver_email"] + " diverso da" + receiver_email;
                        errori = true;
                    }

                    //check that payment_amount/payment_currency are correct
                    if (responseMap["mc_currency"] != "EUR")
                    {
                        descrErrore += responseMap["mc_currency"] + " diverso da EUR";
                        errori = true;
                    }
                    if (responseMap["mc_gross"] != quota)
                    {
                        descrErrore += responseMap["mc_gross"] + " diverso da" + quota;
                        errori = true;
                    }
                    if (errori == false)
                    {
                        //process payment
                        query.inserisciTxNid(famiglia, responseMap["txn_id"]);
                        //String[] itemSoci;
                        query.inserisciPagamentoOnline(idSocio, quota, famiglia);
                        /*
                        foreach (String socio in soci)
                        {
                            itemSoci = socio.Split('-');
                            query.incassoTesseraSocio(itemSoci[0], itemSoci[1]);
                            query.inserisciPagamentoOnline(itemSoci[0], itemSoci[1]);
                        }*/
                        Utility ut = new Utility();
                        try
                        {
                            // ut.invioMailIncassoOnline(socio);
                        }
                        catch (Exception ex)
                        {
                            descrErrore += ex.Message;
                        }
                    }
                    else
                    {
                        
                        Utility ut = new Utility();
                        ut.InvioMail("simone.bagnolesi@gmail.com", "Errore Gestito IpnPayPal", strOriginaRequest +"-"+ descrErrore);
                        throw new Exception(descrErrore);
                    }
                }
                else if (strResponse == "INVALID")
                {
                    //UPDATE YOUR DATABASE

                    //TextWriter txWriter = new StreamWriter(Server.MapPath("../uploads/") + Session["orderID"].ToString() + ".txt");
                    //txWriter.WriteLine(strResponse);
                    ////log for manual investigation
                    //txWriter.Close();
                }
                else
                {  //UPDATE YOUR DATABASE

                    //TextWriter txWriter = new StreamWriter(Server.MapPath("../uploads/") + Session["orderID"].ToString() + ".txt");
                    //txWriter.WriteLine("Invalid");
                    ////log response/ipn data for manual investigation
                    //txWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Utility ut = new Utility();
                ut.InvioMail("simone.bagnolesi@gmail.com", "Errore IpnPayPal", strOriginaRequest+"-"+ ex.Message.ToString() + "-" + ex.StackTrace.ToString());
                throw ex;
            }
        }
    }
}
