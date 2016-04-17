using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ModificaLink : Pagebasic
    {
        public static string id;
        DataTable dtDatiLink = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        id = Request.QueryString["id"].ToString();
                        if (!IsPostBack)
                        {
                            dtDatiLink = objQry.Link_Datilink(id);
                            if (dtDatiLink.Rows.Count > 0)
                            {
                                txDescrizione.Text = dtDatiLink.Rows[0]["TX_DESCRIZIONE"].ToString();
                                txUrl.Text = dtDatiLink.Rows[0]["TX_LINK"].ToString().Replace("http://", string.Empty);
                            }
                            else
                            {
                                lblErr.Text = "SI E' VERIFICATO UN ERRORE NEL RICHIAMARE LA PAGINA< br/>TORNA INDIETRO E RIPROVA";
                                pnlLink.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        lblErr.Text = "SI E' VERIFICATO UN ERRORE NEL RICHIAMARE LA PAGINA< br/>TORNA INDIETRO E RIPROVA";
                        pnlLink.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Noabilitato.aspx");
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (txDescrizione.Text.Trim() != string.Empty && txDescrizione.Text.Trim() != string.Empty)
                {
                    objQry.Link_ModificaLink(txDescrizione.Text.Trim().Replace("'", "`"), "http://" + txUrl.Text.Trim().Replace("http://", string.Empty), id);
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
