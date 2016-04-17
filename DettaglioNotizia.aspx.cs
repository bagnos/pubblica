using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class DettaglioNotizia : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["notizia"].ToString() != null && Request.QueryString["notizia"].ToString() != string.Empty)
                {
                    PopolaNews(Request.QueryString["notizia"].ToString());
                }
                else
                {
                    lblErr.Text = "ERRORE: <br /><br />" + "Mancano dei parametri nella chiamata della pagina";
                    pnlNews.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE: <br /><br />" + Ex.Message;
                pnlNews.Visible = false;
            }
        }

        public void PopolaNews(string id_news)
        {
            DataTable dtNotizia = new DataTable();

            try
            {
                dtNotizia = objQry.DettaglioNotizia(id_news);
                if (dtNotizia.Rows.Count > 0)
                {
                    lblTitolo.Text = "<b>" + dtNotizia.Rows[0]["DS_TITOLO"].ToString() + "</b>";
                    lblTipo.Text = dtNotizia.Rows[0]["DS_TIPO"].ToString();
                    lblDataEvento.Text = dtNotizia.Rows[0]["GIORNO_EVN"].ToString() + "-" + dtNotizia.Rows[0]["MESE_EVN"].ToString() + "-" + dtNotizia.Rows[0]["ANNO_EVN"].ToString();
                    if (dtNotizia.Rows[0]["TX_NOMEFILE"].ToString().Trim() != string.Empty)
                    {
                        lblImg.Text = "<img width=\"250px\" src=\"public/img/" + dtNotizia.Rows[0]["TX_NOMEFILE"].ToString().Trim() + "\" alt=\"" + dtNotizia.Rows[0]["TX_DESCFOTO"].ToString().Trim() + "\" />";
                    }
                    else
                    {
                        lblImg.Text = "<img width=\"250px\" src=\"Immagini/logo_pa.jpg\" />";
                    }
                    lblSottotitolo.Text = "<b>" + dtNotizia.Rows[0]["DS_SOTTOTITOLO"].ToString() + "</b>";
                    lblTesto.Text = lblTesto.Text + dtNotizia.Rows[0]["DS_DESCRIZIONE"].ToString();
                    if (dtNotizia.Rows[0]["FILEALLEGATO"].ToString().Trim() != string.Empty)
                    {
                        if (dtNotizia.Rows[0]["DESCALLEGATO"].ToString() != string.Empty)
                        {
                            lblAllegato.Text = lblAllegato.Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString().Trim() + "','','')\"><img src=\"Immagini/blocconote.png\" alt=\"\" />&nbsp;&nbsp;" + dtNotizia.Rows[0]["DESCALLEGATO"].ToString().Trim() + "</a>";
                        }
                        else
                        {
                            lblAllegato.Text = lblAllegato.Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString().Trim() + "','','')\"><img src=\"Immagini/blocconote.png\" alt=\"\" />&nbsp;&nbsp;" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString().Trim() + "</a>";
                        }
                        
                    }
                }
                else
                {
                    lblErr.Text = "ERRORE: <br /><br />" + "Notizia non trovata";
                    pnlNews.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
