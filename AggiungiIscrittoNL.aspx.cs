using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class AggiungiIscrittoNL : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllaLogin();
            if (Session["fladmin"].ToString() == "0")
            {
                Response.Redirect("Noabilitato.aspx");
            }
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
                                objQry.IscrizioneNewsletterAdmin(id, txNome.Text, txAnno.Text, txComune.Text, txCAP.Text, txemail.Text);
                            }
                            catch (Exception Ex)
                            {
                                Err = true;
                                lblErr.Text = "ERRORE!!! " + Ex.Message;
                                pnlIscrizione.Visible = false;
                                btnNuovoins.Visible = true;
                            }
                            
                            if (!Err)
                            {
                                lblErr.Text = "UTENTE AGGIUNTO CORRETTAMENTE";
                                pnlIscrizione.Visible = false;
                                btnNuovoins.Visible = true;
                            }
                            
                        }
                        else
                        {
                            lblErr.Text = "ATTENZIONE!!! L'indirizzo e-mail indicato è già in uso";
                            pnlIscrizione.Visible = false;
                            btnNuovoins.Visible = true;
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

        protected void btnNuovoins_Click(object sender, EventArgs e)
        {
            Response.Redirect("AggiungiIscrittoNL.aspx");
        }
    }
}
