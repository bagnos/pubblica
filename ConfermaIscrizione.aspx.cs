using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa_taverne
{
    public partial class ConfermaIscrizione : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_iscritto = string.Empty;
            string nr_attivazione = string.Empty;
            bool Err = false;
            int ctrl = 0;

            try
            {
                id_iscritto = Request.QueryString["id"].ToString().Trim();
                nr_attivazione = Request.QueryString["nr"].ToString().Trim();
            }
            catch
            {
                Err = true;
                lblErr.Text = "ERRORE!!! <br /><br /> I link di attivazione al servizio non è corretto";
            }
            if (!Err)
            {
                try
                {
                    if (id_iscritto != string.Empty && nr_attivazione != string.Empty)
                    {
                        ctrl = objQry.AttivaIscritto(id_iscritto, nr_attivazione);
                        if (ctrl > 0)
                        {
                            lblErr.Text = "ATTIVAZIONE AVVENUTA CON SUCCESSO <br /><br />Da oggi potrai ricevere ogni novità sul tuo indirizzo di posta elettronica";
                        }
                        else
                        {
                            lblErr.Text = "ERRORE!!! <br /><br /> I link di attivazione al servizio non è corretto";
                        }
                    }
                    else
                    {
                        lblErr.Text = "ERRORE!!! <br /><br /> I link di attivazione al servizio non è corretto";
                    }
                }
                catch(Exception Ex)
                {
                    lblErr.Text = "ERRORE!!! " + Ex.Message;
                }
            }
        }
    }
}
