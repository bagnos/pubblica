using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class _Default : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ElencoNews();
            }
            catch (Exception Ex)
            {
                lnblNews.Text = Ex.Message;
            }
        }

        public void ElencoNews()
        {
            DataTable dtNews = new DataTable();
            int numnews;

            try
            {
                dtNews = objQry.NotizieHome();
                if (dtNews.Rows.Count > 0)
                {
                    if (dtNews.Rows.Count < 10)
                    {
                        numnews = dtNews.Rows.Count;
                    }
                    else
                    {
                        numnews = 10;
                    }
                    lnblNews.Text = "<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"450px\">";
                    for (int i = 0; i < numnews; i++)
                    {
                        lnblNews.Text = lnblNews.Text + "<tr>";
                        lnblNews.Text = lnblNews.Text + "<td class=\"TestoP\" align=\"center\">";
                        lnblNews.Text = lnblNews.Text + "<b>" + dtNews.Rows[i]["GIORNO_EVN"].ToString() + "-" + dtNews.Rows[i]["MESE_EVN"].ToString() + "-" + dtNews.Rows[i]["ANNO_EVN"].ToString() + "</b>";
                        lnblNews.Text = lnblNews.Text + "</td>";
                        lnblNews.Text = lnblNews.Text + "<td class=\"TestoP\" style=\"cursor:pointer;\" align=\"left\" onclick=\"javascript:location.href='DettaglioNotizia.aspx?notizia=" + dtNews.Rows[i]["ID_NOTIZIA"].ToString() + "'\">";
                        lnblNews.Text = lnblNews.Text + "<i>" + dtNews.Rows[i]["DS_TIPO"].ToString() + "</i>";
                        lnblNews.Text = lnblNews.Text + "</td>";
                        lnblNews.Text = lnblNews.Text + "</tr>";
                        lnblNews.Text = lnblNews.Text + "<tr>";
                        lnblNews.Text = lnblNews.Text + "<td align=\"center\">";
                        if (Convert.ToInt32(dtNews.Rows[i]["DIFF"].ToString()) <= 10)
                        {
                            lnblNews.Text = lnblNews.Text + "<img src=\"Immagini/NEW.gif\" alt=\"\"  /><br />";
                        }
                        if (dtNews.Rows[i]["TX_NOMEFILE"].ToString().Trim() != string.Empty)
                        {
                            lnblNews.Text = lnblNews.Text + "<img width=\"100px\" src=\"public/img/" + dtNews.Rows[i]["TX_NOMEFILE"].ToString().Trim() + "\" alt=\"" + dtNews.Rows[i]["TX_DESCFOTO"].ToString().Trim() + "\" />";
                        }
                        else
                        {
                            lnblNews.Text = lnblNews.Text + "<img width=\"100px\" src=\"Immagini/logo_pa.jpg\" />";
                        }
                        lnblNews.Text = lnblNews.Text + "</td>";
                        lnblNews.Text = lnblNews.Text + "<td class=\"TestoP\" align=\"left\" valign=\"middle\">";
                        lnblNews.Text = lnblNews.Text + "<b class=\"TestoP\"><u>" + dtNews.Rows[i]["DS_TITOLO"].ToString().Trim().ToUpper() + "</u></b>";
                        lnblNews.Text = lnblNews.Text + "<br /><br />";
                        lnblNews.Text = lnblNews.Text + "<b class=\"TestoP\">" + dtNews.Rows[i]["DS_SOTTOTITOLO"].ToString().Trim() + "</b>";
                        lnblNews.Text = lnblNews.Text + "<br /><br />";
                        lnblNews.Text = lnblNews.Text + objUti.PrimeParole(dtNews.Rows[i]["DS_DESCRIZIONE"].ToString().Trim(), 30);
                        lnblNews.Text = lnblNews.Text + "<br /><br />";
                        lnblNews.Text = lnblNews.Text + "<a style=\"cursor:pointer;\" align=\"center\" onclick=\"javascript:location.href='DettaglioNotizia.aspx?notizia=" + dtNews.Rows[i]["ID_NOTIZIA"].ToString() + "'\"><u>Leggi la notizia</u></a>";
                        if (dtNews.Rows[i]["FILEALLEGATO"].ToString().Trim() != string.Empty)
                        {
                            lnblNews.Text = lnblNews.Text + "&nbsp;&nbsp;&nbsp;&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNews.Rows[i]["FILEALLEGATO"].ToString().Trim() + "','','')\"><u>Scarica l'allegato</u></a>";
                        }
                        lnblNews.Text = lnblNews.Text + "</td>";
                        lnblNews.Text = lnblNews.Text + "</tr>";
                        lnblNews.Text = lnblNews.Text + "<tr>";
                        lnblNews.Text = lnblNews.Text + "<td colspan=\"2\" class=\"TDNews\">&nbsp;</td>";
                        lnblNews.Text = lnblNews.Text + "</tr>";
                    }
                    lnblNews.Text = lnblNews.Text + "</table>";
                }
                else
                {
                    lnblNews.Text = "Non ci sono news";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
