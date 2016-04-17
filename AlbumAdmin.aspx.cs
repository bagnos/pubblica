using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class AlbumAdmin : Pagebasic
    {
        HiddenField hiAlbum = new HiddenField();
        TextBox txNome = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            string album = string.Empty;
            string azione = string.Empty;

            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["tipo"] != null)
                    {
                        if (Request.QueryString["act"] != null && Request.QueryString["album"] != null)
                        {
                            album = Request.QueryString["album"].ToString();
                            azione = Request.QueryString["act"].ToString();

                            if (azione == "E" && album != string.Empty)
                            {
                                EliminaAlbum(album);
                            }
                        }
                        PopolaAlbum(Request.QueryString["tipo"].ToString());
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

        public void PopolaAlbum(string tipo)
        {
            DataTable dtAlbum = new DataTable();

            try
            {
                dtAlbum = objQry.AlbumAdmin(tipo);
                if (dtAlbum.Rows.Count > 0)
                {
                    dgAlbum.DataSource = dtAlbum;
                    dgAlbum.DataBind();
                }
                else
                {
                    lblErr.Text = "Nessun album presente";
                }
                lblTitolo.Text = "ELENCO ALBUM - " + objQry.NomeTipo(tipo).ToUpper();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void bntIndietro_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipiAlbumAdmin.aspx");
        }

        protected void dgAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string album = string.Empty;
            string azione = string.Empty;
            ImageButton btnRinomina = new ImageButton();
            ImageButton btnAnnulla = new ImageButton();



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["act"] != null && Request.QueryString["album"] != null)
                {
                    album = Request.QueryString["album"].ToString();
                    azione = Request.QueryString["act"].ToString();
                }

                if (azione == "R" && album == e.Row.Cells[0].Text)
                {
                    btnRinomina.ImageUrl = "Immagini/salva.png";
                    btnRinomina.Click += new ImageClickEventHandler(btnRinomina_Click);
                    btnAnnulla.ImageUrl = "Immagini/annulla.png";
                    btnAnnulla.Click += new ImageClickEventHandler(btnAnnulla_Click);
                    hiAlbum.Value = e.Row.Cells[0].Text;
                    e.Row.Cells[3].Controls.Add(btnRinomina);
                    e.Row.Cells[3].Controls.Add(btnAnnulla);
                    e.Row.Cells[3].Controls.Add(hiAlbum);
                    txNome.CssClass = "TextBox";
                    txNome.Text = e.Row.Cells[1].Text;
                    e.Row.Cells[1].Text = string.Empty;
                    e.Row.Cells[1].Controls.Add(txNome);
                    e.Row.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
                    txNome.Focus();
                }
                else
                {
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='AlbumAdmin.aspx?act=R&tipo=" + Request.QueryString["tipo"].ToString() + "&album=" + e.Row.Cells[0].Text + "'\"><img src=\"Immagini/modifica.png\" alt=\"Rinomina\" title=\"Rinomina\" /></a>";
                    if (e.Row.Cells[2].Text.Trim() == "0")
                    {
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text + "&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:Elimina('" + e.Row.Cells[0].Text + "','" + Request.QueryString["tipo"].ToString() + "')\"><img src=\"Immagini/cancella.png\" alt=\"Cancella\" title=\"Cancella\" /></a>";
                    }
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='FotoAdmin.aspx?album=" + e.Row.Cells[0].Text + "'\"><img src=\"Immagini/dettaglio.png\" alt=\"Visualizza Foto\" title=\"Visualizza Foto\" /></a>";
                }

            }
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void btnRinomina_Click(object sender, ImageClickEventArgs e)
        {
            string id_album = string.Empty;
            //TextBox tx;

            try
            {
                id_album = hiAlbum.Value;
                if (id_album != string.Empty)
                {
                    if (txNome.Text.Trim() != string.Empty)
                    {
                        objQry.RinominaAlbum(id_album, txNome.Text);
                    }
                }
                Response.Redirect("AlbumAdmin.aspx?tipo=" + Request.QueryString["tipo"].ToString());
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE NELLA RINOMINA:<br /><br />" + Ex.Message;
            }
        }

        protected void btnAnnulla_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AlbumAdmin.aspx?tipo=" + Request.QueryString["tipo"].ToString());
        }

        public void EliminaAlbum(string album)
        {
            DataTable dtAlbum = new DataTable();
            DataView dvAlbum;

            try
            {
                dtAlbum = objQry.AlbumAdmin(Request.QueryString["tipo"].ToString());
                dvAlbum = new DataView(dtAlbum);
                dvAlbum.RowFilter = "ID_ALBUM=" + album;
                if (dvAlbum.Count > 0)
                {
                    if (dvAlbum[0]["N_FOTO"].ToString() == "0")
                    {
                        objQry.EliminaAlbum(album);
                        Response.Redirect("AlbumAdmin.aspx?tipo=" + Request.QueryString["tipo"].ToString());
                    }
                    else
                    {
                        lblErr.Text = "Impossibile eliminate l'album selezionato perchè contiene delle foto";
                    }
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            string id_album = string.Empty;

            try
            {
                if (txAlbum.Text.Trim() != string.Empty)
                {
                    id_album = objQry.ProxIDAlbum();
                    if (id_album != string.Empty)
                    {
                        objQry.InserisciAlbum(Request.QueryString["tipo"].ToString(), id_album, txAlbum.Text.Trim());
                        lblErr.Text = string.Empty;
                        PopolaAlbum(Request.QueryString["tipo"].ToString());
                        txAlbum.Text = string.Empty;
                    }
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE NELL INSERIMENTO:<br /><br />" + Ex.Message;
            }
        }
    }
}
