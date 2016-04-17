using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class TipiAlbumAdmin : Pagebasic
    {

        HiddenField hiTipo = new HiddenField();
        TextBox txNome = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            string tipo = string.Empty;
            string azione = string.Empty;

            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["act"] != null && Request.QueryString["tipo"] != null)
                    {
                        tipo = Request.QueryString["tipo"].ToString();
                        azione = Request.QueryString["act"].ToString();

                        if (azione == "E" && tipo != string.Empty)
                        {
                            EliminaTipo(tipo);
                        }
                    }
                    PopolaTipi();                    
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

        public void PopolaTipi()
        {
            DataTable dtTipi = new DataTable();

            try
            {
                dtTipi = objQry.TipiAlbumAdmin();
                if (dtTipi.Rows.Count > 0)
                {
                    dgTipi.DataSource = dtTipi;
                    dgTipi.DataBind();
                }
                else
                {
                    lblErr.Text = "Nessuna tipologia presente";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void dgTipi_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string tipo = string.Empty;
            string azione = string.Empty;
            ImageButton btnRinomina = new ImageButton();
            ImageButton btnAnnulla = new ImageButton();
            
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.QueryString["act"] != null && Request.QueryString["tipo"] != null)
                {
                    tipo = Request.QueryString["tipo"].ToString();
                    azione = Request.QueryString["act"].ToString();
                }
                                
                if (azione == "R" && tipo == e.Row.Cells[0].Text)
                {
                    btnRinomina.ImageUrl = "Immagini/salva.png";
                    btnRinomina.Click += new ImageClickEventHandler(btnRinomina_Click);
                    btnAnnulla.ImageUrl = "Immagini/annulla.png";
                    btnAnnulla.Click += new ImageClickEventHandler(btnAnnulla_Click);
                    hiTipo.Value = e.Row.Cells[0].Text;
                    e.Row.Cells[3].Controls.Add(btnRinomina);
                    e.Row.Cells[3].Controls.Add(btnAnnulla);
                    e.Row.Cells[3].Controls.Add(hiTipo);
                    txNome.CssClass = "TextBox";
                    txNome.Text = e.Row.Cells[1].Text;
                    e.Row.Cells[1].Text = string.Empty;
                    e.Row.Cells[1].Controls.Add(txNome);
                    e.Row.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
                    txNome.Focus();
                }
                else
                {
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='TipiAlbumAdmin.aspx?act=R&tipo=" + e.Row.Cells[0].Text + "'\"><img src=\"Immagini/modifica.png\" alt=\"Rinomina\" title=\"Rinomina\" /></a>";
                    if (e.Row.Cells[2].Text.Trim() == "0")
                    {
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text + "&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:Elimina('" + e.Row.Cells[0].Text + "')\"><img src=\"Immagini/cancella.png\" alt=\"Cancella\" title=\"Cancella\" /></a>";
                    }
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "&nbsp;<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='AlbumAdmin.aspx?tipo=" + e.Row.Cells[0].Text + "'\"><img src=\"Immagini/dettaglio.png\" alt=\"Elenco Album\" title=\"Elenco Album\" /></a>";
                }
                
            }
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            string id_tipo = string.Empty;

            try
            {
                if (txTipologia.Text.Trim() != string.Empty)
                {
                    id_tipo = objQry.ProxIDTipoAlbum();
                    if (id_tipo != string.Empty)
                    {
                        objQry.InserisciTipoAlbum(id_tipo, txTipologia.Text.Trim());
                        lblErr.Text = string.Empty;
                        PopolaTipi();
                        txTipologia.Text = string.Empty;
                    }
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE NELL INSERIMENTO:<br /><br />" + Ex.Message;
            }
        }

        protected void btnRinomina_Click(object sender, ImageClickEventArgs e)
        {
            string id_tipo = string.Empty;
            //TextBox tx;

            try
            {
                id_tipo = hiTipo.Value;
                if (id_tipo != string.Empty)
                {
                    if (txNome.Text.Trim() != string.Empty)
                    {
                        objQry.RinominaTipoAlbum(id_tipo, txNome.Text);
                    }
                }
                Response.Redirect("TipiAlbumAdmin.aspx");
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE NELLA RINOMINA:<br /><br />" + Ex.Message;
            }
        }

        protected void btnAnnulla_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TipiAlbumAdmin.aspx");
        }

        public void EliminaTipo(string tipo)
        {
            DataTable dtAlbum = new DataTable();
            DataView dvAlbum;

            try
            {
                dtAlbum = objQry.TipiAlbumAdmin();
                dvAlbum = new DataView(dtAlbum);
                dvAlbum.RowFilter = "ID_TIPO_ALBUM=" + tipo;
                if (dvAlbum.Count > 0)
                {
                    if (dvAlbum[0]["N_ALBUM"].ToString() == "0")
                    {
                        objQry.EliminaTipoAlbum(tipo);
                        Response.Redirect("TipiAlbumAdmin.aspx");
                    }
                    else
                    {
                        lblErr.Text = "Impossibile eliminate la tipologia selezionata perchè contiene degli album";
                    }
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


    }
}
