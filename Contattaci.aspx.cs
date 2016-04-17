using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa_taverne
{
    public partial class Contattaci : System.Web.UI.Page
    {
        Utility objUti = new Utility();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            string Err = string.Empty;

            try
            {
                if (txNome.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo Nome e Cognome è obbligatorio <br />";
                }
                if (txIndirizzo.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo Indirizzo è obbligatorio <br />";
                }
                if (txCitta.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo Città è obbligatorio <br />";
                }
                if (txCap.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo C.A.P. è obbligatorio <br />";
                }
                if (txTelefono.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo Telefono è obbligatorio <br />";
                }
                if (txEmail.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo E-Mail è obbligatorio <br />";
                }
                if (txMessaggio.Text.Trim() == string.Empty)
                {
                    Err = Err + "- Il Campo Messaggio è obbligatorio <br />";
                }
                if (Err == string.Empty)
                {
                    try
                    {
                        objUti.InvioMailContatti(txNome.Text, txIndirizzo.Text, txCitta.Text, txCap.Text
                            , txTelefono.Text, txEmail.Text, txMessaggio.Text);
                    }
                    catch (Exception Ex)
                    {
                        Err = Ex.Message;
                    }
                    if (Err == string.Empty)
                    {
                        pnlInvio.Visible = false;
                        btnNuovo.Visible = true;
                        lblErr.Text = "Messaggio Inviato con successo";
                    }
                    else
                    {
                        lblErr.Text = "Impossibile inviare il messaggio, si è verificato il seguente errore: <br />";
                        lblErr.Text = lblErr.Text + Err;
                        pnlInvio.Visible = false;
                        btnNuovo.Visible = true;
                    }
                }
                else
                {
                    lblErr.Text = "Attenzione!! <br />";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contattaci.aspx");
        }
    }
}
