using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Foto : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idfoto"].ToString() != null && Request.QueryString["idfoto"].ToString() != string.Empty)
                {
                    PopolaFoto(Request.QueryString["idfoto"].ToString());
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

        public void PopolaFoto(string foto)
        {
            DataTable dtFoto = new DataTable();
            string txalbum = string.Empty;
            string idtipo = string.Empty;
            string idalbum = string.Empty;
            string indietro = string.Empty;
            string avanti = string.Empty;
            try
            {
                idalbum = objQry.Album(foto);
                if (idalbum != string.Empty)
                {
                    txalbum = objQry.NomeAlbum(idalbum).ToUpper();
                    idtipo = objQry.TipoAlbum(idalbum);
                    if (txalbum != string.Empty)
                    {
                        indietro = objQry.FotoPrec(objQry.Ordine(foto), idalbum);
                        if (indietro == string.Empty)
                        {
                            indietro = objQry.FotoPrec("1000000", idalbum);
                            if (indietro == string.Empty)
                            {
                                indietro = foto;
                            }
                        }

                        avanti = objQry.FotoSucc(objQry.Ordine(foto), idalbum);
                        if (avanti == string.Empty)
                        {
                            avanti = objQry.FotoSucc("0", idalbum);
                            if (avanti == string.Empty)
                            {
                                avanti = foto;
                            }
                        }

                        lblAlbum.Text = txalbum;
                        lblFoto.Text = lblFoto.Text + "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" >";
                        lblFoto.Text = lblFoto.Text + "<tr>";
                        lblFoto.Text = lblFoto.Text + "<td align=\"left\">";
                        lblFoto.Text = lblFoto.Text + "<a style=\"cursor:pointer;color:#0000EE;\" onclick=\"javascript:location.href='ElencoAlbum.aspx?idtipo=" + idtipo + "'\">Torna all'elenco degli Album</a>&nbsp;|&nbsp;";
                        lblFoto.Text = lblFoto.Text + "<a style=\"cursor:pointer;color:#0000EE;\" onclick=\"javascript:location.href='Album.aspx?idalbum=" + idalbum + "'\">Torna all'Album</a>";
                        lblFoto.Text = lblFoto.Text + "</td>";
                        lblFoto.Text = lblFoto.Text + "<td align=\"right\">";
                        lblFoto.Text = lblFoto.Text + "<a style=\"cursor:pointer;color:#0000EE;\" onclick=\"javascript:location.href='Foto.aspx?idfoto=" + indietro + "'\" >Indietro</a> | <a style=\"cursor:pointer;color:#0000EE;\" onclick=\"javascript:location.href='Foto.aspx?idfoto=" + avanti + "'\" >Avanti</a>";
                        lblFoto.Text = lblFoto.Text + "</td>";
                        lblFoto.Text = lblFoto.Text + "</tr></table><br />";

                        dtFoto = objQry.Foto(foto);
                        if (dtFoto.Rows.Count > 0)
                        {
                            lblFoto.Text = lblFoto.Text + "<table style=\"background-color:#E4E5E0\" border=\"0\" cellpadding=\"6\" cellspacing=\"0\" >";
                            lblFoto.Text = lblFoto.Text + "<tr>";
                            lblFoto.Text = lblFoto.Text + "<td align=\"center\" class=\"TestoP\"><b>";
                            lblFoto.Text = lblFoto.Text + dtFoto.Rows[0]["TX_TITOLO"].ToString();
                            lblFoto.Text = lblFoto.Text + "</b></td>";
                            lblFoto.Text = lblFoto.Text + "</tr>";
                            lblFoto.Text = lblFoto.Text + "<tr>";
                            lblFoto.Text = lblFoto.Text + "<td align=\"center\">";
                            lblFoto.Text = lblFoto.Text + "<img width=\"500px\" src=\"public/Foto/" + dtFoto.Rows[0]["TX_NOMEFILE"].ToString() + "\" alt=\"\" title=\"\"/>";
                            lblFoto.Text = lblFoto.Text + "</td>";
                            lblFoto.Text = lblFoto.Text + "</tr>";
                            lblFoto.Text = lblFoto.Text + "<tr>";
                            lblFoto.Text = lblFoto.Text + "<td align=\"left\" class=\"TestoP\">";
                            lblFoto.Text = lblFoto.Text + dtFoto.Rows[0]["TX_DESCRIZIONE"].ToString();
                            lblFoto.Text = lblFoto.Text + "</td>";
                            lblFoto.Text = lblFoto.Text + "</tr>";
                            lblFoto.Text = lblFoto.Text + "</table>";
                        }
                        else
                        {
                            lblErr.Text = "La foto è stata rimossa dall'album!!";
                        }

                    }
                    else
                    {
                        lblErr.Text = "L'album non è presente in archivio!!!";
                    }
                }
                else
                {
                    lblErr.Text = "La foto non è aggangiata a nessun'archivio!!!";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
