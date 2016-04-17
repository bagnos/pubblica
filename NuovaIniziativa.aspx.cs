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
    public partial class NuovaIniziativa : Pagebasic
    {
        public static string id_foto;
        public static string nomefoto;
        public static string nomeallegato;
        public static string descallegato;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() != "0")
                {
                    if (!IsPostBack)
                    {
                        ComboTipi();
                        id_foto = string.Empty;
                        nomefoto = string.Empty;
                        nomeallegato = string.Empty;
                        descallegato = string.Empty;
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

        public void ComboTipi()
        {
            DataTable dtTipi = new DataTable();

            try
            {
                dtTipi = objQry.TipiIniziative();
                cmbTipo.DataSource = dtTipi;
                cmbTipo.DataValueField = "ID_TIPO";
                cmbTipo.DataTextField = "DS_TIPO";
                cmbTipo.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnAddFoto_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["PathFoto"];
                string Err = string.Empty;

                if (upFoto.HasFile)
                {
                    if (!upFoto.FileName.Contains("'"))
                    {
                        try
                        {
                            filePath += upFoto.FileName;

                            if (System.IO.File.Exists(filePath))
                            {
                                Err = "File già presente in archivio!!";
                            }
                            else
                            {
                                upFoto.SaveAs(filePath);
                            }
                        }
                        catch (Exception Ex1)
                        {
                            Err = "ERRORE nel caricamento della foto <br /><br /> " + Ex1.Message;
                        }
                        if (Err == string.Empty)
                        {
                            try
                            {
                                id_foto = objQry.ProxIDFoto();
                                nomefoto = upFoto.FileName;
                                objQry.InserisciFoto(id_foto, upFoto.FileName, txDescFoto.Text);
                            }
                            catch (Exception Ex2)
                            {
                                Err = "ERRORE nel salvataggio della foto <br /><br /> " + Ex2.Message;
                            }
                            if (Err == string.Empty)
                            {
                                try
                                {
                                    lblFoto.Text = "<img width=\"100px\" src=\"public/img/" + upFoto.FileName + "\" alt=\"" + txDescFoto.Text + "\" />";
                                    upFoto.Visible = false;
                                    txDescFoto.Visible = false;
                                    btnAddFoto.Visible = false;
                                    lblDescFoto.Visible = false;
                                    btnEliFoto.Visible = true;

                                }
                                catch (Exception Ex3)
                                {
                                    lblErr.Text = Ex3.Message;
                                }
                            }
                            else
                            {
                                lblErr.Text = Err;
                            }
                        }
                        else
                        {
                            lblErr.Text = Err;
                        }
                    }
                    else
                    {
                        lblErr.Text = "ATTENZIONE!! Il nome della foto non deve contenere apostrofi";
                    }
                    
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnEliFoto_Click(object sender, EventArgs e)
        {
            
            try
            {
                string filePath = ConfigurationManager.AppSettings["PathFoto"];
                filePath += nomefoto;
                System.IO.File.Delete(filePath);
                objQry.EliminaFoto(id_foto);
                lblFoto.Text = string.Empty;
                upFoto.Visible = true;
                txDescFoto.Visible = true;
                btnAddFoto.Visible = true;
                lblDescFoto.Visible = true;
                btnEliFoto.Visible = false;
                txDescFoto.Text = string.Empty;
                nomefoto = string.Empty;
                id_foto = string.Empty;
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }

        }

        protected void btnAddAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["PathAllegati"];
                string Err = string.Empty;

                if (upAllegato.HasFile)
                {
                    if (!upAllegato.FileName.Contains("'"))
                    {
                        try
                        {
                            filePath += upAllegato.FileName;

                            if (System.IO.File.Exists(filePath))
                            {
                                Err = "File già presente in archivio!!";
                            }
                            else
                            {
                                upAllegato.SaveAs(filePath);
                            }
                        }
                        catch (Exception Ex1)
                        {
                            Err = "ERRORE nel caricamento dell'allegato <br /><br /> " + Ex1.Message;
                        }
                        if (Err == string.Empty)
                        {
                            try
                            {
                                nomeallegato = upAllegato.FileName;
                                if (txDescAllegato.Text.Trim() != string.Empty)
                                {
                                    descallegato = txDescAllegato.Text;
                                }
                                else
                                {
                                    descallegato = upAllegato.FileName;
                                }
                                lblAllegati.Text = "<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + nomeallegato + "','','')\"><img src=\"Immagini/graffetta.gif\" alt=\"\" />" + descallegato + "</a>";
                                upAllegato.Visible = false;
                                txDescAllegato.Visible = false;
                                btnAddAllegato.Visible = false;
                                lblDescAllegato.Visible = false;
                                btnEliAllegato.Visible = true;

                            }
                            catch (Exception Ex3)
                            {
                                lblErr.Text = Ex3.Message;
                            }
                        }
                        else
                        {
                            lblErr.Text = Err;
                        }
                    }
                    else
                    {
                        lblErr.Text = "ATTENZIONE!! Il nome dell'allegato non deve contenere apostrofi";
                    }

                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnEliAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["PathAllegati"];
                filePath += nomeallegato;
                System.IO.File.Delete(filePath);
                lblAllegati.Text = string.Empty;
                upAllegato.Visible = true;
                txDescAllegato.Visible = true;
                btnAddAllegato.Visible = true;
                lblDescAllegato.Visible = true;
                btnEliAllegato.Visible = false;
                txDescAllegato.Text = string.Empty;
                nomeallegato = string.Empty;
                descallegato = string.Empty;
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            string id_news = string.Empty;
            string Err = string.Empty;

            try
            {
                if (calEvento.SelectedDate == null)
                {
                    lblErr.Text = "Non è stata selezionata la data dell'attività";
                }
                else
                {
                    if (txTitolo.Text.Trim() == string.Empty || txSottotitolo.Text.Trim() == string.Empty || FreeTextBox1.Text.Trim() == string.Empty)
                    {
                        lblErr.Text = "ATTENZIONE!! Uno o più campi obblicatori non sono stati inseriti.";
                    }
                    else
                    {
                        try
                        {
                            id_news = objQry.ProxIDNews();
                        }
                        catch(Exception Ex1)
                        {
                            Err = Ex1.Message;
                        }
                        if (Err == string.Empty)
                        {
                            try
                            {
                                if (id_news != string.Empty && nomeallegato != string.Empty)
                                {
                                    objQry.InserisciAllegato(id_news, nomeallegato, descallegato);
                                }
                            }
                            catch (Exception Ex2)
                            {
                                Err = Ex2.Message;
                            }
                            if (Err == string.Empty)
                            {
                                try
                                {
                                    if (id_news != string.Empty && id_foto != string.Empty)
                                    {
                                        objQry.CollegaFoto(id_news, id_foto);
                                    }
                                }
                                catch (Exception Ex2)
                                {
                                    Err = Ex2.Message;
                                }
                                if (Err == string.Empty)
                                {
                                    try
                                    {
                                        if (id_news != string.Empty)
                                        {
                                            string data = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                                            string dtevento = calEvento.SelectedDate.Year.ToString() + "/" + calEvento.SelectedDate.Month.ToString() + "/" + calEvento.SelectedDate.Day.ToString();
                                            objQry.InserisciNotizia(id_news, data, dtevento, cmbTipo.SelectedValue, txTitolo.Text.Trim(), txSottotitolo.Text.Trim(), FreeTextBox1.Text.Trim(), cmbHome.SelectedValue);
                                        }
                                    }
                                    catch (Exception Ex3)
                                    {
                                        Err = Ex3.Message;
                                    }
                                    if (Err == string.Empty)
                                    {
                                        Response.Redirect("ElencoNewsAdmin.aspx");
                                    }
                                    else
                                    {
                                        lblErr.Text = "ERRORE: " + Err;
                                        objQry.EliminaAllegato(id_news);
                                        if (id_foto != string.Empty)
                                        {
                                            objQry.ScollegaFoto(id_news, id_foto);
                                        }
                                    }
                                }
                                else
                                {
                                    lblErr.Text = "ERRORE: " + Err;
                                    objQry.EliminaAllegato(id_news);
                                }
                            }
                            else
                            {
                                lblErr.Text = "ERRORE: " + Err;
                            }
                        }
                        else
                        {
                            lblErr.Text = "ERRORE: " + Err;
                        }
                    }
                }   
            }
            catch (Exception Ex)
            {
                lblErr.Text = "ERRORE: " + Ex.Message;
            }

        }
    }
}
