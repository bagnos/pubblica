using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace pa_taverne
{
    public partial class FotoAdmin : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string foto = string.Empty;
            string azione = string.Empty;

            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["album"] != null)
                    {
                        if (Request.QueryString["act"] != null && Request.QueryString["foto"] != null)
                        {
                            foto = Request.QueryString["foto"].ToString();
                            azione = Request.QueryString["act"].ToString();

                            if (azione == "E" && foto != string.Empty)
                            {
                                EliminaFoto(foto);
                            }
                        }
                        PopolaAlbum(Request.QueryString["album"].ToString());
                    }
                    else
                    {
                        lblErr.Text = "ATTENZIONE!! Mancano dei parametri nella chiamata della pagina";
                        dgAlbum.Visible = false;
                        btnAdd.Visible = false;
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

        public void EliminaFoto(string foto)
        {
            string nomefile = string.Empty;
            string filePath = string.Empty;
            string ordine;

            try
            {
                ordine = objQry.Ordine(foto);
                filePath = ConfigurationManager.AppSettings["PathGallery"] + objQry.Nomefile(foto);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                objQry.EliminaFotoGallery(foto);
                objQry.SpostaPerElimin(Request.QueryString["album"].ToString(), ordine);
                Response.Redirect("FotoAdmin.aspx?album=" + Request.QueryString["album"].ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void PopolaAlbum(string album)
        {
            DataTable dtAlbum = new DataTable();

            try
            {
                dtAlbum = objQry.ElencoFoto(album);
                if (dtAlbum.Rows.Count > 0)
                {
                    dgAlbum.DataSource = dtAlbum;
                    dgAlbum.DataBind();
                }
                else
                {
                    lblErr.Text = "Nessuna foto presente";
                }
                lblTitolo.Text = "ELENCO FOTO - " + objQry.NomeAlbum(album).ToUpper();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        protected void bntIndietro_Click(object sender, EventArgs e)
        {
            string tipo = string.Empty;

            try
            {
                tipo = objQry.TipoAlbum(Request.QueryString["album"].ToString());
            }
            catch
            {
                tipo = string.Empty;
            }
            finally
            {
                if (tipo != string.Empty)
                {
                    Response.Redirect("AlbumAdmin.aspx?tipo=" + tipo);
                }
                else
                {
                    Response.Redirect("TipiAlbumAdmin.aspx");
                }
            }
        }

        protected void dgAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = "<img src=\"public/foto/" + e.Row.Cells[1].Text.Trim() + "\" alt=\"\" title=\"\" width=\"100px\" />";
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='ModificaFoto.aspx?foto=" + e.Row.Cells[0].Text + "&album=" + Request.QueryString["album"].ToString() + "'\"><img src=\"Immagini/modifica.png\" alt=\"Modifica\" title=\"Modifica\" />";
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + "&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:Elimina('" + e.Row.Cells[0].Text + "','" + Request.QueryString["album"].ToString() + "')\"><img src=\"Immagini/cancella.png\" alt=\"Cancella\" title=\"Cancella\" /></a>";
                

            }
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("NuovaFoto.aspx?album=" + Request.QueryString["album"].ToString());
        }
    }
}
