using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ComunicazioneNL : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControllaLogin();
            if (Session["fladmin"].ToString() == "0")
            {
                Response.Redirect("Noabilitato.aspx");
            }
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            DataTable dtDestinatari = new DataTable();
            try
            {
                if (txOggetto.Text.Trim() != string.Empty && FreeTextBox1.Text.Trim() != string.Empty)
                {
                    dtDestinatari = objQry.ElencoIscrittiNLAttivi();
                    objUti.InvioMailMultiplo(dtDestinatari, txOggetto.Text.Trim(), FreeTextBox1.Text.Trim());
                    pnlInvio.Visible = false;
                    lblErr.Text = "COMUNICAZIONE INVIATA CORRETTAMENTE";
                    btnNuova.Visible = true;
                }
                else
                {
                    lblErr.Text = "ATTENZIONE SIA L'OGGETTO CHE IL TESTO DEL MESSAGGIO NON POSSONON ESSERE VUOTI";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE!! <br /><br /> " + Ex.Message;
            }
        }

        protected void btnNuova_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComunicazioneNL.aspx");
        }
    }
}
