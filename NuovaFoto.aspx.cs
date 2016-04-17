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
    public partial class NuovaFoto : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (Request.QueryString["album"] != null)
                    {
                        pnlNew.Visible = true;
                        lblTitolo.Text = objQry.NomeAlbum(Request.QueryString["album"].ToString()).ToUpper() + " - NUOVA FOTO";
                        if (!IsPostBack)
                        {
                            PopolaComboOrdine(Request.QueryString["album"].ToString());
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
                for (int i = 0; i < numfoto+1; i++)
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


        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            Response.Redirect("FotoAdmin.aspx?album=" + Request.QueryString["album"].ToString());
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            string filePath = ConfigurationManager.AppSettings["PathGallery"];
            string Err = string.Empty;
            int ord_new;
            int ord_old;

            try
            {
                if (upFoto.HasFile)
                {
                    if (txTitolo.Text.Trim() != string.Empty)
                    {
                        filePath += upFoto.FileName;
                        if (!System.IO.File.Exists(filePath))
                        {
                            try
                            {
                                upFoto.SaveAs(filePath.Replace("'", "`"));
                            }
                            catch (Exception Ex)
                            {
                                Err = Ex.Message;
                            }
                            if (Err == string.Empty)
                            {
                                try
                                {
                                    ord_new = Convert.ToInt32(cmbOrdine.SelectedValue);
                                    ord_old = objQry.NumFoto(Request.QueryString["album"].ToString()) + 1;
                                    if (ord_new < ord_old)
                                    {
                                        objQry.SpostaDopo(Request.QueryString["album"].ToString(), ord_new.ToString(), ord_old.ToString());
                                    }
                                    if (ord_new > ord_old)
                                    {
                                        objQry.SpostaPrima(Request.QueryString["album"].ToString(), ord_new.ToString(), ord_old.ToString());
                                    }
                                    objQry.InserisciFotoGallery(Request.QueryString["album"].ToString(), objQry.ProxIDFotoGallery(), upFoto.FileName, txTitolo.Text, txDescrizione.Text, ord_new.ToString());
                                }
                                catch (Exception Ex)
                                {
                                    Err = Ex.Message;
                                }
                            }
                            else
                            {
                                lblErr.Text = "ERRORE NELL'UPLOAD DELLA FOTO!!<br /><br />" + Err;
                            }
                            if (Err == string.Empty)
                            {
                                Response.Redirect("FotoAdmin.aspx?album=" + Request.QueryString["album"].ToString());
                            }
                            else
                            {
                                lblErr.Text = "ERRORE NEL SALVATAGGIO DELLA FOTO!!<br /><br />" + Err;
                            }
                        }
                        else
                        {
                            lblErr.Text = "ATTENZIONE!! Esiste già una Foto con lo stesso nome in archivio!!";
                        }
                    }
                    else
                    {
                        lblErr.Text = "ATTENZIONE!! Il Titolo è obbligatorio!!";
                    }
                }
                else
                {
                    lblErr.Text = "ATTENZIONE!! Non è stato selezionato alcun file!!";                
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE!!<br /><br />" + Ex.Message;
            }
        }
    }
}
