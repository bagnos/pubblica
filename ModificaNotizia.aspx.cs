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
    public partial class ModificaNotizia : Pagebasic
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
                        if (Request.QueryString["notizia"] != null)
                        {
                            ComboTipi();
                            PopolaCampi(Request.QueryString["notizia"].ToString());
                        }
                        else
                        {
                            lblErr.Text = "ERRORE: Mancano dei parametri nella chiamata della pagina";
                        }
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

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            Response.Redirect("ElencoNewsAdmin.ASPX");
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

        public void PopolaCampi(string Notizia)
        {
            DataTable dtNotizia = new DataTable();

            try
            {
                dtNotizia = objQry.DettaglioNotizia(Notizia);
                if (dtNotizia.Rows.Count > 0)
                {

                    // Tipo notizia
                    for (int i = 0; i < cmbTipo.Items.Count; i++)
                    {
                        if (cmbTipo.Items[i].Value == dtNotizia.Rows[0]["ID_TIPO"].ToString())
                        {
                            cmbTipo.Items[i].Selected = true;
                        }
                    }

                    // Data Evento
                    int giorno = Convert.ToInt32(dtNotizia.Rows[0]["GIORNO_EVN"].ToString());
                    int mese = Convert.ToInt32(dtNotizia.Rows[0]["MESE_EVN"].ToString());
                    int anno = Convert.ToInt32(dtNotizia.Rows[0]["ANNO_EVN"].ToString());

                    calEvento.SelectedDate = new DateTime(anno, mese, giorno);
                    calEvento.VisibleDate = new DateTime(anno, mese, giorno);

                    //Foto

                    if (dtNotizia.Rows[0]["TX_NOMEFILE"].ToString() != string.Empty)
                    {
                        lblFoto.Text = "<img width=\"100px\" src=\"public/img/" + dtNotizia.Rows[0]["TX_NOMEFILE"].ToString() + "\" alt=\"" + txDescFoto.Text + "\" />";
                        upFoto.Visible = false;
                        txDescFoto.Visible = false;
                        btnAddFoto.Visible = false;
                        lblDescFoto.Visible = false;
                        btnEliFoto.Visible = true;
                        id_foto = dtNotizia.Rows[0]["ID_FOTO"].ToString();
                        nomefoto = dtNotizia.Rows[0]["TX_NOMEFILE"].ToString();
                    }
                    else
                    {
                        lblFoto.Text = string.Empty;
                        upFoto.Visible = true;
                        txDescFoto.Visible = true;
                        btnAddFoto.Visible = true;
                        lblDescFoto.Visible = true;
                        btnEliFoto.Visible = false;
                        txDescFoto.Text = string.Empty;
                        id_foto = string.Empty;
                        nomefoto = string.Empty;
                    }

                    //Titolo
                    txTitolo.Text = dtNotizia.Rows[0]["DS_TITOLO"].ToString();

                    //Sottotitolo
                    txSottotitolo.Text = dtNotizia.Rows[0]["DS_SOTTOTITOLO"].ToString().Replace("<br />", "\r\n").Replace("&nbsp;&nbsp;", "  ");

                    //Testo
                    //txTesto.Text = dtNotizia.Rows[0]["DS_DESCRIZIONE"].ToString().Replace("<br />", "\r\n").Replace("&nbsp;&nbsp;", "  ");
                    FreeTextBox1.Text = dtNotizia.Rows[0]["DS_DESCRIZIONE"].ToString();

                    //Combo Home
                    for (int i = 0; i < cmbHome.Items.Count; i++)
                    {
                        if (cmbHome.Items[i].Value == dtNotizia.Rows[0]["FL_HOME"].ToString())
                        {
                            cmbHome.Items[i].Selected = true;
                        }
                    }

                    //Allegato
                    if (dtNotizia.Rows[0]["FILEALLEGATO"].ToString() != string.Empty)
                    {
                        if (dtNotizia.Rows[0]["DESCALLEGATO"].ToString() != string.Empty)
                        {
                            lblAllegati.Text = "<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString() + "','','')\"><img src=\"Immagini/graffetta.gif\" alt=\"\" />" + dtNotizia.Rows[0]["DESCALLEGATO"].ToString() + "</a>";
                        }
                        else
                        {
                            lblAllegati.Text = "<a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Allegati/" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString() + "','','')\"><img src=\"Immagini/graffetta.gif\" alt=\"\" />" + dtNotizia.Rows[0]["FILEALLEGATO"].ToString() + "</a>";
                        }
                        upAllegato.Visible = false;
                        txDescAllegato.Visible = false;
                        btnAddAllegato.Visible = false;
                        lblDescAllegato.Visible = false;
                        btnEliAllegato.Visible = true;
                        nomeallegato = dtNotizia.Rows[0]["FILEALLEGATO"].ToString();
                        descallegato = dtNotizia.Rows[0]["DESCALLEGATO"].ToString();
                    }
                    else
                    {
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


                }
                else
                {
                    lblErr.Text = "Notizia non presente in archivio";
                    btnSalva.Enabled = false;
                }
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
                            id_news = Request.QueryString["notizia"].ToString();
                        }
                        catch (Exception Ex1)
                        {
                            Err = Ex1.Message;
                        }
                        if (Err == string.Empty)
                        {
                            try
                            {
                                if (id_news != string.Empty && nomeallegato != string.Empty)
                                {
                                    objQry.AggiornaAllegato(id_news, nomeallegato, descallegato);
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
                                        objQry.AggiornaFoto(id_news, id_foto);
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
                                            string dtevento = calEvento.SelectedDate.Year.ToString() + "/" + calEvento.SelectedDate.Month.ToString() + "/" + calEvento.SelectedDate.Day.ToString();

                                            objQry.ModificaNotizia(id_news, dtevento, cmbTipo.SelectedValue, txTitolo.Text.Trim(), txSottotitolo.Text.Trim(), FreeTextBox1.Text.Trim(), cmbHome.SelectedValue);
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
