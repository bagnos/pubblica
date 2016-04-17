using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ElencoAlbum : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idtipo"].ToString() != null && Request.QueryString["idtipo"].ToString() != string.Empty)
                {
                    PopolaAlbum(Request.QueryString["idtipo"].ToString());
                }
                else
                {
                    lblErr.Text = "ERRORE: <br /><br />" + "Mancano dei parametri nella chiamata della pagina";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void PopolaAlbum(string tipo)
        {
            DataTable dtAlbum = new DataTable();
            string txtipo = string.Empty;
            try
            {
                txtipo = objQry.NomeTipo(tipo);
                if (txtipo != string.Empty)
                {
                    lblTipoAlbum.Text = txtipo;
                    dtAlbum = objQry.ElencoAlbum(tipo);
                    if (dtAlbum.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtAlbum.Rows.Count; i++)
                        {
                            lblAlmum.Text = lblAlmum.Text + "<table style=\"background-color:#E4E5E0\" border=\"0\" cellpadding=\"6\" cellspacing=\"0\" width=\"85%\" >";
                            lblAlmum.Text = lblAlmum.Text + "<tr style=\"cursor:pointer;\" onclick=\"javascript:location.href='Album.aspx?idalbum=" + dtAlbum.Rows[i]["ID_ALBUM"].ToString() + "'\">";
                            lblAlmum.Text = lblAlmum.Text + "<td style=\"width:180px;\" align=\"left\">";
                            lblAlmum.Text = lblAlmum.Text + "<img width=\"150px\" src=\"public/Foto/" + dtAlbum.Rows[i]["TX_NOMEFILE"].ToString() + "\" alt=\"" + dtAlbum.Rows[i]["TX_TITOLO"].ToString().Trim() + "\" />";
                            lblAlmum.Text = lblAlmum.Text + "</td>";
                            lblAlmum.Text = lblAlmum.Text + "<td align=\"left\"><b>";
                            lblAlmum.Text = lblAlmum.Text + dtAlbum.Rows[i]["TX_ALBUM"].ToString();
                            lblAlmum.Text = lblAlmum.Text + "</b></td>";
                            lblAlmum.Text = lblAlmum.Text + "</tr></table><br />";
                        }
                    }
                    else
                    {
                        lblErr.Text = "Non ci sono ancora album nell'archivio \"" + txtipo + "\"";
                    }
                }
                else
                {
                    lblErr.Text = "L'album non è presente in archivio!!!";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
