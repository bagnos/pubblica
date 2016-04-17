using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class NuovoLink : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() == "0")
                {
                    Response.Redirect("Noabilitato.aspx");
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
                pnlLink.Visible = false;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (txDescrizione.Text.Trim() != string.Empty && txDescrizione.Text.Trim() != string.Empty)
                {
                    objQry.InserisciLink(txDescrizione.Text.Trim().Replace("'", "`"), "http://" + txUrl.Text.Trim().Replace("http://", string.Empty));
                    Response.Redirect("ElencoLink.aspx");
                }
                else
                {
                    lblErr.Text = "ATTENZIONE!! I campi Descrizione ed Indirizzo sono entrambi obbligatori";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }
    }
}
