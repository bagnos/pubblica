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
    public partial class ModificaFoto : Pagebasic
    {
        int ord_new;
        int ord_old;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["album"] != null && Request.QueryString["foto"] != null)
                    {
                        pnlNew.Visible = true;
                        lblTitolo.Text = objQry.NomeAlbum(Request.QueryString["album"].ToString()).ToUpper() + " - MODIFICA FOTO";
                        
                        if (!IsPostBack)
                        {
                            PopolaComboOrdine(Request.QueryString["album"].ToString());
                            PopolaFoto(Request.QueryString["foto"].ToString());
                        }
                    }
                    else
                    {
                        lblErr.Text = "ATTENZIONE!! Mancano dei parametri nella chiamata della pagina";
                        pnlNew.Visible = false;
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

        public void PopolaComboOrdine(string album)
        {
            DataTable dtOrdine = new DataTable();
            int numfoto;

            try
            {
                dtOrdine.Columns.Add("ORDINE");
                numfoto = objQry.NumFoto(album);
                for (int i = 0; i < numfoto; i++)
                {
                    dtOrdine.Rows.Add((i + 1).ToString());
                }

                cmbOrdine.DataSource = dtOrdine;
                cmbOrdine.DataValueField = "ORDINE";
                cmbOrdine.DataTextField = "ORDINE";
                cmbOrdine.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        

        public void PopolaFoto(string foto)
        {
            DataTable dtFoto = new DataTable();

            try
            {
                dtFoto = objQry.Foto(foto);
                if (dtFoto.Rows.Count > 0)
                {
                    lblFoto.Text = "<img src=\"public/foto/" + dtFoto.Rows[0]["TX_NOMEFILE"].ToString() + "\" alt=\"\" title=\"\" width=\"500px\" />";
                    txTitolo.Text = dtFoto.Rows[0]["TX_TITOLO"].ToString();
                    txDescrizione.Text = dtFoto.Rows[0]["TX_DESCRIZIONE"].ToString();
                    for (int i = 0; i < cmbOrdine.Items.Count; i++)
                    {
                        if (cmbOrdine.Items[i].Value == dtFoto.Rows[0]["NM_ORDINE"].ToString())
                        {
                            cmbOrdine.Items[i].Selected = true;
                        }
                    }
                    hiOrd_Old.Value = dtFoto.Rows[0]["NM_ORDINE"].ToString();
                    
                }
                else
                {
                    lblErr.Text = "Nessuna foto presente";
                    pnlNew.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            Response.Redirect("FotoAdmin.aspx?album=" + Request.QueryString["album"].ToString());
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (txTitolo.Text.Trim() != string.Empty)
                {
                    ord_new = Convert.ToInt32(cmbOrdine.SelectedValue);
                    ord_old = Convert.ToInt32(hiOrd_Old.Value);
                    if (ord_new < ord_old)
                    {
                        objQry.SpostaDopo(Request.QueryString["album"].ToString(), ord_new.ToString(), ord_old.ToString());
                    }
                    if (ord_new > ord_old)
                    {
                        objQry.SpostaPrima(Request.QueryString["album"].ToString(), ord_new.ToString(), ord_old.ToString());
                    }
                    objQry.ModificaFoto(Request.QueryString["foto"].ToString(), txTitolo.Text, txDescrizione.Text, ord_new.ToString());
                    Response.Redirect("FotoAdmin.aspx?album=" + Request.QueryString["album"].ToString());
                }
                else
                {
                    lblErr.Text = "ATTENZIONE!! Il Titolo è obbligatorio!!";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE!!<br /><br />" + Ex.Message;
            }
        }
    }
}
