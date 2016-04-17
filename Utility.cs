using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.Net;
//using System.Web.Mail;
using System.Configuration;
using System.Text.RegularExpressions;


namespace pa_taverne
{
    public class Utility
    {
        public Utility()
        { 
            
        }

        public bool ControllaIntero(string numero)
        {
            try
            {
                Convert.ToInt32(numero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public void InvioMailContatti(string Nome, string Indirizzo, string Citta, string CAP, string Telefono
        //    , string Fax, string mail, string Messaggio)
        //{
        //    MailMessage message = new MailMessage();
        //    string Testo;
        //    try
        //    {
                                
        //        message.From = mail;
        //        message.To = ConfigurationManager.AppSettings["MailContatti"];

        //        //Imposto oggetto
        //        message.Subject = "Contatti da sito";
        //        //Imposto contenuto
        //        Testo = "Salve sono " + Nome + ",<br /> residente in " + Indirizzo + ", " + Citta + " - " + CAP + ". Il mio numero di telefono è " + Telefono + "e il numero di fax è " + Fax + ".<br /> Ho scritto per comunicarvi il seguente messaggio: <br />" + Messaggio + "";
        //        message.Body = Testo;
                                
        //        //Imposto il Server Smtp

        //        //SmtpClient SmtpMail = new SmtpClient();
        //        //SmtpMail.Send(oMsg);
        //        SmtpMail.Send(message);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        public void InvioMailContatti(string Nome, string Indirizzo, string Citta, string CAP, string Telefono
            , string mail, string Messaggio)
        {
            MailMessage message = new MailMessage();
            string Testo;
            try
            {

                message.From = new MailAddress(mail);
                message.To.Add(ConfigurationManager.AppSettings["MailContatti"]);

                //Imposto oggetto
                message.Subject = "Contatti da sito";
                //Imposto contenuto
                Testo = "Salve sono " + Nome + ",<br /> residente in " + Indirizzo + ", " + Citta + " - " + CAP + ". Il mio numero di telefono è " + Telefono + ".<br /> Ho scritto per comunicarvi il seguente messaggio: <br />" + Messaggio.Replace("\r\n", "<br/>") + "";
                message.Body = Testo;
                message.IsBodyHtml = true;

                //Imposto il Server Smtp
                SmtpClient oSmtp = new SmtpClient("smtp.pa-taverne.it");
                oSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                NetworkCredential oCredential = new NetworkCredential("info@pa-taverne.it", "info");
                oSmtp.UseDefaultCredentials = false;
                oSmtp.Credentials = oCredential;

                oSmtp.Send(message);
                
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InvioMail(string destinatario, string Oggetto, string Testo)
        {
            MailMessage message = new MailMessage();

            try
            {

                message.From = new MailAddress(ConfigurationManager.AppSettings["MailContatti"]);
                message.To.Add(destinatario);

                //Imposto oggetto
                message.Subject = Oggetto;
                //Imposto contenuto
                message.Body = Testo;
                message.IsBodyHtml = true;

                //Imposto il Server Smtp
                SmtpClient oSmtp = new SmtpClient("smtp.pa-taverne.it");
                oSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                NetworkCredential oCredential = new NetworkCredential("info@pa-taverne.it", "info");
                oSmtp.UseDefaultCredentials = false;
                oSmtp.Credentials = oCredential;

                oSmtp.Send(message);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InvioMailMultiplo(DataTable dtDestinatari, string Oggetto, string Testo)
        {
            MailMessage message = new MailMessage();

            try
            {
                if (dtDestinatari.Rows.Count > 0)
                {
                    message.From = new MailAddress(ConfigurationManager.AppSettings["MailContatti"]);
                    message.To.Add(ConfigurationManager.AppSettings["MailContatti"]);
                    //message.To.Add("supermoccolo@yahoo.it");
                    for (int i = 0; i < dtDestinatari.Rows.Count; i++)
                    {
                        message.Bcc.Add(dtDestinatari.Rows[i]["TX_EMAIL"].ToString());
                    }
                    

                    //Imposto oggetto
                    message.Subject = Oggetto;
                    //Imposto contenuto
                    message.Body = Testo;
                    message.IsBodyHtml = true;

                    //Imposto il Server Smtp
                    SmtpClient oSmtp = new SmtpClient("smtp.pa-taverne.it");
                    oSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    NetworkCredential oCredential = new NetworkCredential("info@pa-taverne.it", "info");
                    oSmtp.UseDefaultCredentials = false;
                    oSmtp.Credentials = oCredential;

                    oSmtp.Send(message);
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string PrimeParole(string testo, int numparole)
        {
            string[] righe;
            string[] parole;
            string testoapp = string.Empty;
            string testotrunc = string.Empty;
            //int app;
            //long app1;

            try
            {
                righe = Regex.Split(testo, "<br>");
                if (righe.Length > 4)
                {
                    testo = righe[0] + "<br>" + righe[1] + "<br>" + righe[3] + "<br>" + righe[4];
                }

                parole = testo.Replace("&nbsp;", " ").Split(' ');

                if (parole.Length <= numparole)
                {
                    return testo;
                }
                else
                {
                    for (int i = 0; i < numparole; i++)
                    {
                        testotrunc = testotrunc + " " + parole[i];
                        //app1 = Math.DivRem(i, 8,out app);
                        //if (app == 0 && i!=0)
                        //{
                        //    testotrunc = testotrunc + "<br />";
                        //}
                    }
                    testotrunc = testotrunc + " [...]";
                    return testotrunc;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

    
}
