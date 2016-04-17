using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Album : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idalbum"].ToString() != null && Request.QueryString["idalbum"].ToString() != string.Empty)
                {
                    PopolaAlbum(Request.QueryString["idalbum"].ToString());
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

        public void PopolaAlbum(string album)
        {
            DataTable dtAlbum = new DataTable();
            string txalbum = string.Empty;
            string idtipo = string.Empty;
            int j = 0;
            try
            {
                txalbum = objQry.NomeAlbum(album).ToUpper();
                idtipo = objQry.TipoAlbum(album);
                if (txalbum != string.Empty)
                {
                    lblAlbum.Text = txalbum;
                    lblFoto.Text = lblFoto.Text + "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" >";
                    lblFoto.Text = lblFoto.Text + "<tr>";
                    lblFoto.Text = lblFoto.Text + "<td align=\"left\">";
                    lblFoto.Text = lblFoto.Text + "<a style=\"cursor:pointer;color:#0000EE;\" onclick=\"javascript:location.href='ElencoAlbum.aspx?idtipo=" + idtipo + "'\">Torna all'elenco degli Album</a>";
                    lblFoto.Text = lblFoto.Text + "</td>";
                    lblFoto.Text = lblFoto.Text + "</tr></table><br />";
                    dtAlbum = objQry.ElencoFoto(album);
                    if (dtAlbum.Rows.Count > 0)
                    {
                        lblFoto.Text = lblFoto.Text + "<table style=\"background-color:#E4E5E0\" border=\"0\" cellpadding=\"6\" cellspacing=\"0\" width=\"100%\" >";
                        lblFoto.Text = lblFoto.Text + "<tr>";
                        for (int i = 0; i < dtAlbum.Rows.Count; i++)
                        {
                            lblFoto.Text = lblFoto.Text + "<td align=\"center\">";
                            lblFoto.Text = lblFoto.Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='Foto.aspx?idfoto=" + dtAlbum.Rows[i]["ID_FOTO"].ToString() + "'\"><img width=\"150px\" src=\"public/Foto/" + dtAlbum.Rows[i]["TX_NOMEFILE"].ToString() + "\" alt=\"" + dtAlbum.Rows[i]["TX_TITOLO"].ToString() + "\" title=\"" + dtAlbum.Rows[i]["TX_TITOLO"].ToString() + "\"/>";
                            lblFoto.Text = lblFoto.Text + "</td>";

                            Math.DivRem(i + 1, 3, out j);
                            if (j == 0)
                            {
                                lblFoto.Text = lblFoto.Text + "</tr><tr>";
                            }
                        }
                        lblFoto.Text = lblFoto.Text + "</tr>";
                        lblFoto.Text = lblFoto.Text + "</table>";
                    }
                    else
                    {
                        lblErr.Text = "Non ci sono ancora foto nell'album \"" + txalbum + "\"";
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
