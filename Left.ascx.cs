using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Left : System.Web.UI.UserControl
    {
        Query objQry = new Query();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaAdmin();
                AnteprimaNews();
                ArchivioFoto();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void ControllaAdmin()
        {
            if (Session.Count == 0)
            {
                pnlAdmin.Visible = false;
            }
            else
            {
                if (Session["fladmin"].ToString() != string.Empty)
                {
                    if (Session["fladmin"].ToString() != "0")
                    {
                        pnlAdmin.Visible = true;
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                    }
                }
                else
                {
                    pnlAdmin.Visible = false;
                }
            }
        }

        public void AnteprimaNews()
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

                    for (int i = 0; i < numnews; i++)
                    {
                        lblAnteprima.Text = lblAnteprima.Text + "<div id=\"billboard" + i.ToString() + "\" class=\"billcontent\" width=\"98%\">";
                        lblAnteprima.Text = lblAnteprima.Text + "<table cellpadding=\"3\" cellspacing=\"0\" border=\"0\" width=\"98%\">";
                        lblAnteprima.Text = lblAnteprima.Text + "<tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<td align=\"center\">" + "<b>" + dtNews.Rows[i]["GIORNO_EVN"].ToString() + "-" + dtNews.Rows[i]["MESE_EVN"].ToString() + "-" + dtNews.Rows[i]["ANNO_EVN"].ToString() + "</b>" + "</td>";
                        lblAnteprima.Text = lblAnteprima.Text + "</tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<td align=\"center\" valign=\"top\"><i>" + dtNews.Rows[i]["DS_TIPO"].ToString() + "</i><br /><b>" + dtNews.Rows[i]["DS_TITOLO"].ToString().Trim().ToUpper() + "</b>";
                        lblAnteprima.Text = lblAnteprima.Text + "</tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<td align=\"center\" valign=\"middle\">";
                        if (dtNews.Rows[i]["TX_NOMEFILE"].ToString().Trim() != string.Empty)
                        {
                            lblAnteprima.Text = lblAnteprima.Text + "<img width=\"75px\" src=\"public/img/" + dtNews.Rows[i]["TX_NOMEFILE"].ToString().Trim() + "\" alt=\"" + dtNews.Rows[i]["TX_DESCFOTO"].ToString().Trim() + "\" />";
                        }
                        else
                        {
                            lblAnteprima.Text = lblAnteprima.Text + "<img width=\"75px\" src=\"Immagini/logo_pa.jpg\" />";
                        }
                        lblAnteprima.Text = lblAnteprima.Text + "</td>";
                        lblAnteprima.Text = lblAnteprima.Text + "</tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "<td align=\"center\" valign=\"middle\">";
                        lblAnteprima.Text = lblAnteprima.Text + "<a style=\"cursor:pointer;\" align=\"center\" onclick=\"javascript:location.href='DettaglioNotizia.aspx?notizia=" + dtNews.Rows[i]["ID_NOTIZIA"].ToString() + "'\"><u>Leggi la notizia</u></a>";
                        //if (dtNews.Rows[i]["FILEALLEGATO"].ToString().Trim() != string.Empty)
                        //{
                        //    lblAnteprima.Text = lblAnteprima.Text + "<br /><br /><a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNews.Rows[i]["FILEALLEGATO"].ToString().Trim() + "','','')\"><u>Scarica l'allegato</u></a>";
                        //}
                        lblAnteprima.Text = lblAnteprima.Text + "</td></tr>";
                        lblAnteprima.Text = lblAnteprima.Text + "</table>";
                        lblAnteprima.Text = lblAnteprima.Text + "</div>";

                    }
                }
                else
                {
                    lblAnteprima.Text = "Non ci sono news";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ArchivioFoto()
        {
            DataTable dtTipiAlbum = new DataTable();
            MenuItem sotto;
            try
            {
                dtTipiAlbum = objQry.TipiAlbum();
                Menu1.Items[13].ChildItems.Clear();
                for (int i = 0; i < dtTipiAlbum.Rows.Count; i++)
                {
                    sotto = new MenuItem();
                    sotto.Text = "<b>" + dtTipiAlbum.Rows[i]["TX_TIPO_ALBUM"].ToString() + "</b>";
                    sotto.NavigateUrl = "ElencoAlbum.aspx?idtipo=" + dtTipiAlbum.Rows[i]["ID_TIPO_ALBUM"].ToString();
                    Menu1.Items[13].ChildItems.Add(sotto);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}