using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace pa_taverne
{
    public partial class IscrizioneNewsletter : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIscrivi_Click(object sender, EventArgs e)
        {
            bool Err = false;
            string id = string.Empty;
            string cod_Attivazione = string.Empty;
            string Testo = string.Empty;
            DataTable dtIscritto = new DataTable();

            try
            {
                if (txNome.Text.Trim() != string.Empty && txemail.Text.Trim() != string.Empty)
                {
                    try
                    {
                        dtIscritto = objQry.DatiIscrittoDaMail(txemail.Text.Trim());
                        if (dtIscritto.Rows.Count == 0)
                        {
                            try
                            {
                                id = objQry.ProxIDNewsLetter();
                                cod_Attivazione = objQry.IscrizioneNewsletter(id, txNome.Text, txAnno.Text, txComune.Text, txCAP.Text, txemail.Text);
                            }
                            catch (Exception Ex)
                            {
                                Err = true;
                                lblErr.Text = "ERRORE!!! " + Ex.Message;
                                pnlIscrizione.Visible = false;
                            }
                            if (!Err)
                            {
                                try
                                {
                                    Testo = "Ciao " + txNome.Text + "<br /><br />";
                                    Testo = Testo + "Di seguito troverai il link per attivarti al servizio \"Diventa Nostro Amico\"<br /><br />";
                                    Testo = Testo + "<a href=\"http://www.pa-taverne.it/ConfermaIscrizione.aspx?id=" + id + "&nr=" + cod_Attivazione + "\" >http://www.pa-taverne.it/ConfermaIscrizione.aspx?id=" + id + "&nr=" + cod_Attivazione + "</a>";
                                    objUti.InvioMail(txemail.Text.Trim(), "Attivazione Diventa Nostro Amico", Testo);
                                }
                                catch (Exception Ex)
                                {
                                    Err = true;
                                    lblErr.Text = "ERRORE!!! " + Ex.Message;
                                    pnlIscrizione.Visible = false;
                                }
                                if (!Err)
                                {
                                    lblErr.Text = "ISCRIZIONE AVVENUTA CON SUCCESSO<br /><br />";
                                    lblErr.Text = lblErr.Text + "riceverai una e-mail all'indirizzo che ci hai indicato nella quale troverai un link per confermare la tua iscrizione al servizio di ricezione news <br /><br />";
                                    pnlIscrizione.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            lblErr.Text = "ATTENZIONE!!! L'indirizzo e-mail indicato è già in uso";
                        }
                    }
                    catch (Exception Ex)
                    {
                        lblErr.Text = Ex.Message;
                    }
                }
                else
                {
                    lblErr.Text = "Attenzione non hai compilato tutti i campi obbligatori!!";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            bool Err = false;
            DataTable dtIscritto = new DataTable();
            string Testo;

            try
            {
                if (txemail_disatt.Text.Trim() != string.Empty)
                {
                    try
                    {
                        dtIscritto = objQry.DatiIscrittoDaMail(txemail_disatt.Text.Trim());
                        if (dtIscritto.Rows.Count != 0)
                        {
                            try
                            {
                                Testo = "Ciao " + dtIscritto.Rows[0]["TX_NOME"].ToString() + "<br /><br />";
                                Testo = Testo + "Di seguito troverai il link per disattivare il servizio \"Diventa Nostro Amico\"<br /><br />";
                                Testo = Testo + "<a href=\"http://www.pa-taverne.it/DisattivaNL.aspx?id=" + dtIscritto.Rows[0]["ID_ISCRITTO"].ToString() + "&nr=" + dtIscritto.Rows[0]["NR_DISATTIVAZIONE"].ToString() + "\" >http://www.pa-taverne.it/DisattivaNL.aspx?id=" + dtIscritto.Rows[0]["ID_ISCRITTO"].ToString() + "&nr=" + dtIscritto.Rows[0]["NR_DISATTIVAZIONE"].ToString() + "</a>";

                                objUti.InvioMail(txemail_disatt.Text.Trim(), "Disattivazione servizio Diventa Nostro Amico", Testo);
                            }
                            catch (Exception Ex)
                            {
                                Err = true;
                                lblErr1.Text = "ERRORE!!! " + Ex.Message;
                            }
                            if (!Err)
                            {
                                lblErr.Text = "MAIL INVIATA!!<br /><br />";
                                lblErr.Text = lblErr.Text + "riceverai una e-mail all'indirizzo che ci hai indicato nella quale troverai un link per disattivare il servizio <br /><br />";
                                pnlIscrizione.Visible = false;
                            }
                        }
                        else
                        {
                            lblErr1.Text = "ATTENZIONE!!! L'indirizzo e-mail indicato non è presente in archivio";
                        }
                    }
                    catch (Exception Ex)
                    {
                        lblErr1.Text = Ex.Message;
                    }
                }
                else
                {
                    lblErr1.Text = "Attenzione non hai inserito l'indirizzo di posta elettronica che vuoi disattivare!!";
                }
            }
            catch (Exception Ex)
            {
                lblErr1.Text = Ex.Message;
            }
        }
    }
}
