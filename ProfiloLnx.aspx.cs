using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

namespace pa_taverne
{
    public partial class ProfiloLnx : Page
    {
        public string id_famiglia = string.Empty;
        public Utility objUti = new Utility();
        private DataTable dtPagamenti;
        private DataTable dtFamiglia;
        private DataTable dtPagamentiDaFare;
        private int daDareSocio;
        private int quotaSocioLogin;
        private int totaleFamigliaRiscosso;
        private int totaleFamigliaDaPagare;
        private int totaleFamigliaQuota;

        public Query objQry = new Query(new AccessoDatiLnx());
        QueryScambio objQrySC = new QueryScambio();


        private void ControllaLogin()
        {
            if (Session.Count == 0)
            {
                Session.Add("idsocio", string.Empty);
                Session.Add("fladmin", string.Empty);
                Session.Add("txutente", string.Empty);
            }

            if (Session["idsocio"].ToString() == string.Empty)
            {
                Response.Redirect("LoginLnx.aspx");
            }
            lblNumeroSocio.Text = Session["idsocio"].ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["idsocio"] = string.Empty;
            Session["fladmin"] = string.Empty;
            Session["txutente"] = string.Empty;
            Response.Redirect("LoginLnx.aspx");
        }

        protected void btnPagamentiOnline_click(object sender, EventArgs e)
        {
            try
            {
                int anno = DateTime.Now.Year;
                Query q = new Query();
                DataTable dt = q.ricercaPagamentiOnline(anno);
                dgPagamentiOnline.DataSource = dt;
                dgPagamentiOnline.DataBind();
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message;
            }
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgPagamentiOnline.PageIndex = e.NewPageIndex;
            btnPagamentiOnline_click(null,null);
        }

        private void scriviAlert(String testo, bool ko)
        {
            if (ko)
            {
                lblErr.Text = testo;
                pnlMessaggiError.Visible = true;
                pnlMessaggiSuccess.Visible = false;
            }
            else
            {
                lblEsitoPositivo.Text = testo;
                pnlMessaggiError.Visible = false;
                pnlMessaggiSuccess.Visible = true;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["esitoPagamento"] != null)
                {
                    if (Request.QueryString["esito"] == "ko")
                    {

                        scriviAlert(Request.QueryString["esitoPagamento"], true);
                    }
                    else
                    {
                        scriviAlert(Request.QueryString["esitoPagamento"], false);

                    }
                }

                pnlCaricamento.Visible = true;
                pnlPagamentiOnline.Visible = true;
                if (Session["fladmin"] != null && Session["fladmin"].ToString() == "0")
                {
                    pnlCaricamento.Visible = false;
                    pnlPagamentiOnline.Visible = false;

                }

                ControllaLogin();

                DatiPersonali();
                DatiFamiglia(id_famiglia);


                Volontariato();
                DatiDonatore();
                FlagUltima();
                Donazioni();

                lblDaVersare.Text = "Ti ricordiamo che la tua quota annuale ammonta a " + quotaSocioLogin + " €";

                Pagamenti();
                if (totaleFamigliaDaPagare == 0)
                {
                    //verifichiamo la quuota annuale
                    lblVersato.Visible = false;
                }
                else
                {
                    frmPayPal.Visible = true;
                    txtAnno.Text = DateTime.Now.Year.ToString();
                    txtImporto.Text = totaleFamigliaDaPagare.ToString();
                    if (daDareSocio != 0)
                    {

                        lblVersato.Text = "Ricorda che devi ancora versare la quota associativa relativa all'anno in corso.<br />Provvedi quanto prima!";
                    }

                }
               
            }
            catch (Exception Ex)
            {
                scriviAlert(Ex.Message, true);
            }
        }

        public void DatiPersonali()
        {
            DataTable dtDatiSocio = new DataTable();

            try
            {
                dtDatiSocio = objQry.DatiPersonali(Session["idsocio"].ToString());
                if (dtDatiSocio.Rows.Count > 0)
                {
                    lblNome.Text = dtDatiSocio.Rows[0]["Nome"].ToString();
                    lblCognome.Text = dtDatiSocio.Rows[0]["Cognome"].ToString();
                    lblSocioQuote.Text = lblNome.Text + " " + lblCognome.Text;
                    lblNascita.Text = dtDatiSocio.Rows[0]["LuogoNascita"].ToString() + " " + dtDatiSocio.Rows[0]["DTNASC"].ToString();
                    lblIndirizzo.Text = dtDatiSocio.Rows[0]["Indirizzo"].ToString() + " " + dtDatiSocio.Rows[0]["Frazione"].ToString() + " " + dtDatiSocio.Rows[0]["Comune"].ToString();
                    lblIscrizione.Text = dtDatiSocio.Rows[0]["DTISCR"].ToString(); ;
                    if (dtDatiSocio.Rows[0]["DataFineIscrizione"].ToString().Trim() != string.Empty)
                    {
                        lblFineIscrizione.Text = "al <b>" + dtDatiSocio.Rows[0]["DataFineIscrizione"].ToString() + "</b>";
                    }
                    else
                    {
                        lblFineIscrizione.Visible = false;
                    }
                    lblTelefono.Text = dtDatiSocio.Rows[0]["Telefono"].ToString();
                    lblCellulare.Text = dtDatiSocio.Rows[0]["Cellulare"].ToString();
                    id_famiglia = dtDatiSocio.Rows[0]["NumFamiglia"].ToString();
                    lblCodSan.Text = dtDatiSocio.Rows[0]["COD_SAN"].ToString();
                    lblAnpas.Text = dtDatiSocio.Rows[0]["NumTesseraAtt"].ToString();
                    lblMedico.Text = dtDatiSocio.Rows[0]["MED_CUR"].ToString();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DatiFamiglia(string id_famiglia)
        {
            dtFamiglia = new DataTable();

            try
            {
                dtFamiglia = objQry.DatiFamiglia(id_famiglia, Session["idsocio"].ToString());
                dtFamiglia.Columns.Add(new DataColumn("quotaRisc"));
                dtFamiglia.Columns.Add(new DataColumn("quota"));
                dtPagamentiDaFare = dtFamiglia.Clone();
                int quotaSocio;
                int quotaBase;
                totaleFamigliaDaPagare = 0;
                if (dtFamiglia.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtFamiglia.Rows.Count - 1; i++)
                    {
                        dtFamiglia.Rows[i]["quota"] = objQry.Quota(dtFamiglia.Rows[i]["NSocio"].ToString());
                        dtFamiglia.Rows[i]["quotaRisc"] = objQry.Pagato(dtFamiglia.Rows[i]["NSocio"].ToString()) == true ? dtFamiglia.Rows[i]["quota"].ToString() : "0";
                        Int32.TryParse(dtFamiglia.Rows[i]["quota"].ToString(), out quotaBase);
                        Int32.TryParse(dtFamiglia.Rows[i]["quotaRisc"].ToString(), out quotaSocio);
                        if (dtFamiglia.Rows[i]["FL_FINEISCR"].ToString() != "1")
                        {
                            totaleFamigliaDaPagare+= quotaBase;
                            if (quotaSocio == 0 && quotaBase != 0 && dtFamiglia.Rows[i]["FL_FINEISCR"].ToString() != "1")
                            {
                                dtPagamentiDaFare.ImportRow(dtFamiglia.Rows[i]);
                            }
                            totaleFamigliaRiscosso += quotaSocio;
                        }
                        
                        
                    }
                   
                    Int32.TryParse(objQry.Quota(Session["idsocio"].ToString()), out quotaSocio);
                    quotaSocioLogin = quotaSocio;
                    totaleFamigliaDaPagare += quotaSocioLogin;
                    daDareSocio = objQry.Pagato(Session["idsocio"].ToString()) == true ? 0 : quotaSocio;
                    if (daDareSocio == 0)
                    {
                        totaleFamigliaRiscosso += quotaSocio;
                    }
                    else
                    {
                        DataRow rowSocio = dtPagamentiDaFare.NewRow();
                        rowSocio["quota"] = quotaSocio;
                        rowSocio["NomeCognome"] = lblSocioQuote.Text;
                        rowSocio["nsocio"] = Session["idsocio"].ToString();
                        dtPagamentiDaFare.Rows.Add(rowSocio);
                        
                    }
                    if (dtPagamentiDaFare.Rows.Count!=0)
                    {
                        dgDaPagare.DataSource = dtPagamentiDaFare;
                        dgDaPagare.DataBind();
                    }

                    dgFamiglia.DataSource = dtFamiglia;
                    dgFamiglia.DataBind();
                    DataTable dtReferente = new DataTable();
                    dtReferente = objQry.DatiReferente(id_famiglia);

                    lblReferente.Text = dtReferente.Rows[0]["NomeCognome"].ToString();
                    lblMailReferente.Text = dtReferente.Rows[0]["S_Mail"].ToString();

                   
                    //Int32.TryParse(dtReferente.Rows[0]["impFamiglia"].ToString(), out totaleFamigliaQuota);
                    totaleFamigliaDaPagare = totaleFamigliaRiscosso - totaleFamigliaRiscosso;
                    txtImporto.Text = totaleFamigliaDaPagare.ToString();
                }
                else
                {
                    lblFamiglia1.Visible = false;
                    dgFamiglia.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Volontariato()
        {
            DataTable dtVolontariato = new DataTable();

            try
            {
                dtVolontariato = objQry.DatiVolontario(Session["idsocio"].ToString());
                if (dtVolontariato.Rows.Count > 0)
                {
                    lblVolint.Text = dtVolontariato.Rows[0]["NVolInt"].ToString();
                    lblVolAnpas.Text = dtVolontariato.Rows[0]["N_Vol_Anpas"].ToString();
                    dgVolontariato.DataSource = dtVolontariato;
                    dgVolontariato.DataBind();
                }
                else
                {
                    pnlVolontariato.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void DatiDonatore()
        {
            DataTable dtDonatore = new DataTable();

            try
            {
                dtDonatore = objQry.DatiDonatore(Session["idsocio"].ToString());
                if (dtDonatore.Rows.Count > 0)
                {
                    dgDatiDonatore.DataSource = dtDonatore;
                    dgDatiDonatore.DataBind();
                }
                else
                {
                    pnlDonatore.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void FlagUltima()
        {
            try
            {
                if (objQry.FlagUltima(365, Session["idsocio"].ToString()))
                {
                    lblUltima.Text = "E' trascorso più di un anno dalla tua ultima donazione.<br />Attendiamo il tuo prezioso contributo quanto prima!";
                }
                else
                {
                    lblUltima.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Donazioni()
        {
            DataTable dtDonazioni = new DataTable();

            try
            {
                dtDonazioni = objQry.DonazioniSocio(Session["idsocio"].ToString());
                if (dtDonazioni.Rows.Count > 0)
                {
                    dgDonazioni.DataSource = dtDonazioni;
                    dgDonazioni.DataBind();
                }
                else
                {
                    dgDonazioni.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Pagamenti()
        {
            dtPagamenti = new DataTable();

            try
            {
                dtPagamenti = objQry.PagamentiEffettuati(Session["idsocio"].ToString());
                if (dtPagamenti.Rows.Count > 0)
                {

                    dgQuote.DataSource = dtPagamenti;
                    dgQuote.DataBind();
                }
                else
                {
                    dgQuote.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void dgFamiglia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[7].Text == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
            e.Row.Cells[7].Visible = false;
        }

        public void pagaClick(object sender, EventArgs e)
        {
            HttpContext.Current.Session["payment_amt"] = txtImporto.Text + ".00";
            HttpContext.Current.Session["anno"] = txtAnno.Text;
            HttpContext.Current.Session["amt_socio"] = daDareSocio;
            HttpContext.Current.Session["nome"] = lblNome.Text + " " + lblCognome.Text;
            HttpContext.Current.Session["famiglia"] = dtFamiglia;
            Response.Redirect("expresscheckout.aspx");
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            DataTable dtConsiglio = new DataTable();
            DataTable dtRevisori = new DataTable();
            DataTable dtProbiviri = new DataTable();
            DataTable dtDonatori = new DataTable();
            DataTable dtDonazioni = new DataTable();
            DataTable dtQuote = new DataTable();
            DataTable dtSoci = new DataTable();
            DataTable dtTabDimissioni = new DataTable();
            DataTable dtTessereAnpas = new DataTable();
            DataTable dtTipiPag = new DataTable();
            DataTable dtTipoVolontariato = new DataTable();
            DataTable dtVolAttivita = new DataTable();
            DataTable dtVolontari = new DataTable();
            DataTable dtReferenti = new DataTable();

            DataTable dtErroriLettura = new DataTable();

            try
            {
                string filePath = ConfigurationManager.AppSettings["PathDati"];

                if (flDati.HasFile)
                {
                    if (flDati.FileName == "DatiXsito.mdb")
                    {
                        filePath += flDati.FileName;

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        flDati.SaveAs(filePath);
                        pnlUpload.Visible = false;

                        dtErroriLettura.Columns.Add("TABELLA");
                        dtErroriLettura.Columns.Add("ERRORE");

                        #region LETTURA
                        try
                        {
                            dtConsiglio = objQrySC.Consiglio();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Consiglio", Ex.Message);
                        }
                        try
                        {
                            dtRevisori = objQrySC.Revisori();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Revisori", Ex.Message);
                        }
                        try
                        {
                            dtProbiviri = objQrySC.Probiviri();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Probiviri", Ex.Message);
                        }
                        try
                        {
                            dtDonatori = objQrySC.Donatori();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Donatori", Ex.Message);
                        }
                        try
                        {
                            dtDonazioni = objQrySC.Donazioni();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Donazioni", Ex.Message);
                        }
                        try
                        {
                            dtQuote = objQrySC.Quote();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Quote", Ex.Message);
                        }
                        try
                        {
                            dtSoci = objQrySC.Soci();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Soci", Ex.Message);
                        }
                        try
                        {
                            dtTabDimissioni = objQrySC.TabDimissioni();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("TabDimissioni", Ex.Message);
                        }
                        try
                        {
                            dtTessereAnpas = objQrySC.TessereAnpas();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("TessereAnpas", Ex.Message);
                        }
                        try
                        {
                            dtTipiPag = objQrySC.TipiPag();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("TipiPag", Ex.Message);
                        }
                        try
                        {
                            dtTipoVolontariato = objQrySC.TipoVolontariato();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("TipoVolontariato", Ex.Message);
                        }
                        try
                        {
                            dtVolAttivita = objQrySC.VolAttivita();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("VolAttività", Ex.Message);
                        }
                        try
                        {
                            dtVolontari = objQrySC.Volontari();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Volontari", Ex.Message);
                        }
                        try
                        {
                            dtReferenti = objQrySC.Referenti();
                        }
                        catch (Exception Ex)
                        {
                            dtErroriLettura.Rows.Add("Referenti", Ex.Message);
                        }
                        #endregion

                        if (dtErroriLettura.Rows.Count == 0)
                        {
                            lblLog.Text = LoadDadi();
                        }
                        else
                        {
                            String testoErr = "";
                            testoErr = testoErr + "ATTENZIONE!! si sono verificati degli errori nella lettura delle seguenti tabelle: <br /><br />";
                            for (int i = 0; i < dtErroriLettura.Rows.Count; i++)
                            {
                                testoErr = testoErr + dtErroriLettura.Rows[i]["TABELLA"].ToString() + " - " + dtErroriLettura.Rows[i]["ERRORE"].ToString();
                            }
                            testoErr = testoErr + "<br /><br />controllare il file e riprovare il caricamento";
                            scriviAlert(testoErr, true);
                        }
                    }
                    else
                    {
                        String testoErr = "Attenzione il nome del file è diverso da quello richiesto!!";
                        scriviAlert(testoErr, true);
                    }
                }

            }
            catch (Exception Ex)
            {

                scriviAlert(Ex.Message, true);
            }
            finally
            {
                pnlUpload.Visible = true;
            }
        }

        public string LoadDadi()
        {
            string log = string.Empty;
            bool err = false;
            string Path = string.Empty;
            string PathCompleto = string.Empty;

            DataTable dtConsiglio = new DataTable();
            DataTable dtRevisori = new DataTable();
            DataTable dtProbiviri = new DataTable();
            DataTable dtDonatori = new DataTable();
            DataTable dtDonazioni = new DataTable();
            DataTable dtQuote = new DataTable();
            DataTable dtSoci = new DataTable();
            DataTable dtTabDimissioni = new DataTable();
            DataTable dtTessereAnpas = new DataTable();
            DataTable dtTipiPag = new DataTable();
            DataTable dtTipoVolontariato = new DataTable();
            DataTable dtVolAttivita = new DataTable();
            DataTable dtVolontari = new DataTable();
            DataTable dtReferenti = new DataTable();

            DataTable dtErroriLettura = new DataTable();

            StreamWriter sw;
            string riga = string.Empty;


            try
            {
                dtErroriLettura.Columns.Add("TABELLA");
                dtErroriLettura.Columns.Add("ERRORE");

                #region LETTURA

                try
                {
                    dtConsiglio = objQrySC.Consiglio();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Consiglio", Ex.Message);
                }
                try
                {
                    dtRevisori = objQrySC.Revisori();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Revisori", Ex.Message);
                }
                try
                {
                    dtProbiviri = objQrySC.Probiviri();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Probiviri", Ex.Message);
                }
                try
                {
                    dtDonatori = objQrySC.Donatori();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Donatori", Ex.Message);
                }
                try
                {
                    dtDonazioni = objQrySC.Donazioni();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Donazioni", Ex.Message);
                }
                try
                {
                    dtQuote = objQrySC.Quote();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Quote", Ex.Message);
                }
                try
                {
                    dtSoci = objQrySC.Soci();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Soci", Ex.Message);
                }
                try
                {
                    dtTabDimissioni = objQrySC.TabDimissioni();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("TabDimissioni", Ex.Message);
                }
                try
                {
                    dtTessereAnpas = objQrySC.TessereAnpas();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("TessereAnpas", Ex.Message);
                }
                try
                {
                    dtTipiPag = objQrySC.TipiPag();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("TipiPag", Ex.Message);
                }
                try
                {
                    dtTipoVolontariato = objQrySC.TipoVolontariato();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("TipoVolontariato", Ex.Message);
                }
                try
                {
                    dtVolAttivita = objQrySC.VolAttivita();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("VolAttività", Ex.Message);
                }
                try
                {
                    dtVolontari = objQrySC.Volontari();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Volontari", Ex.Message);
                }
                try
                {
                    dtReferenti = objQrySC.Referenti();
                }
                catch (Exception Ex)
                {
                    dtErroriLettura.Rows.Add("Referenti", Ex.Message);
                }

                #endregion

                if (dtErroriLettura.Rows.Count == 0)
                {
                    Path = @"d:\\inetpub\\webs\\pa-taverneit\\public\\dati\\";
                    //Path = @"c:\\sito\\";
                   
                    #region CREAFILES

                    // Consiglio
                    try
                    {
                        PathCompleto = Path + "E_Consiglio.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtConsiglio.Rows.Count; i++)
                            {
                                riga = dtConsiglio.Rows[i]["N_socio"].ToString() + ";";
                                riga = riga + dtConsiglio.Rows[i]["ID_STRUTTURA"].ToString() + ";";
                                riga = riga + dtConsiglio.Rows[i]["ID_CARICA"].ToString() + ";";
                                riga = riga + dtConsiglio.Rows[i]["NUM_VOTI"].ToString() + ";";
                                riga = riga + dtConsiglio.Rows[i]["TX_RESPONSABILITA"].ToString();
                                sw.WriteLine(riga);
                            }
                            for (int i = 0; i < dtRevisori.Rows.Count; i++)
                            {
                                riga = dtRevisori.Rows[i]["N_socio"].ToString() + ";";
                                riga = riga + dtRevisori.Rows[i]["ID_STRUTTURA"].ToString() + ";";
                                riga = riga + dtRevisori.Rows[i]["ID_CARICA"].ToString() + ";";
                                riga = riga + dtRevisori.Rows[i]["NUM_VOTI"].ToString() + ";";
                                riga = riga + dtRevisori.Rows[i]["TX_RESPONSABILITA"].ToString();
                                sw.WriteLine(riga);
                            }
                            for (int i = 0; i < dtProbiviri.Rows.Count; i++)
                            {
                                riga = dtProbiviri.Rows[i]["N_socio"].ToString() + ";";
                                riga = riga + dtProbiviri.Rows[i]["ID_STRUTTURA"].ToString() + ";";
                                riga = riga + dtProbiviri.Rows[i]["ID_CARICA"].ToString() + ";";
                                riga = riga + dtProbiviri.Rows[i]["NUM_VOTI"].ToString() + ";";
                                riga = riga + dtProbiviri.Rows[i]["TX_RESPONSABILITA"].ToString();
                                sw.WriteLine(riga);
                            }
                            sw.Close();
                            log = log + "File Consiglio creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Consiglio.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Consiglio: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //Donatori
                    try
                    {
                        PathCompleto = Path + "E_Donatori.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtDonatori.Rows.Count; i++)
                            {
                                riga = dtDonatori.Rows[i]["NSocio"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["Matricola"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["COD_DON"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["GruppoSanguigno"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["RH"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["FENOTIPO"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["dtInizioDon"].ToString() + ";";
                                riga = riga + dtDonatori.Rows[i]["dtFineDon"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File Donatori creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Donatori.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Donatori: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }


                    //Donazioni
                    try
                    {
                        PathCompleto = Path + "E_Donazioni.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtDonazioni.Rows.Count; i++)
                            {
                                riga = dtDonazioni.Rows[i]["NSocio"].ToString() + ";";
                                riga = riga + dtDonazioni.Rows[i]["DTDONAZIONE"].ToString() + ";";
                                riga = riga + dtDonazioni.Rows[i]["TipoDonazione"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File Donazioni creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Donazioni.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Donazioni: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //Quote
                    try
                    {
                        PathCompleto = Path + "E_Quote.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtQuote.Rows.Count; i++)
                            {
                                riga = dtQuote.Rows[i]["NSocio"].ToString() + ";";
                                riga = riga + dtQuote.Rows[i]["DTPAGAMENTO"].ToString() + ";";
                                riga = riga + dtQuote.Rows[i]["LuogoPagamento"].ToString() + ";";
                                riga = riga + dtQuote.Rows[i]["QuotaRisc"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File Quote creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Quote.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Quote: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //Soci
                    try
                    {
                        PathCompleto = Path + "E_Soci.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtSoci.Rows.Count; i++)
                            {
                                riga = dtSoci.Rows[i]["NSocio"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["NumFamiglia"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Nome"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Cognome"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["DTNascita"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["LuogoNascita"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Indirizzo"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Frazione"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Comune"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Telefono"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["Cellulare"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["CodFiscale"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["DTIscrizione"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["DTFineIscrizione"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["MotivoFine"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["NumVolontario"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["COD_SAN"].ToString() + ";";
                                riga = riga + dtSoci.Rows[i]["MED_CUR"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File Soci creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Soci.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Soci: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //TabDimissioni
                    /*
                    try
                    {
                        PathCompleto = Path + "D_TabDimissioni.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtTabDimissioni.Rows.Count; i++)
                            {
                                riga = dtTabDimissioni.Rows[i]["CodDim"].ToString() + ";";
                                riga = riga + dtTabDimissioni.Rows[i]["Desc_Dimissione"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File TabDimissioni creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_TabDimissioni.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File TabDimissioni: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }*/

                    //TessereAnpas
                    try
                    {
                        PathCompleto = Path + "E_TessereAnpas.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtTessereAnpas.Rows.Count; i++)
                            {
                                riga = dtTessereAnpas.Rows[i]["NSocio"].ToString() + ";";
                                riga = riga + dtTessereAnpas.Rows[i]["NumTesseraAtt"].ToString() + ";";
                                riga = riga + dtTessereAnpas.Rows[i]["Anno"].ToString() + ";";
                                riga = riga + dtTessereAnpas.Rows[i]["NumTesseraPrec"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File TessereAnpas creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_TessereAnpas.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File TessereAnpas: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //TipiPag
                    try
                    {
                        PathCompleto = Path + "D_TipiPag.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtTipiPag.Rows.Count; i++)
                            {
                                riga = dtTipiPag.Rows[i]["Cod_pag"].ToString() + ";";
                                riga = riga + dtTipiPag.Rows[i]["Codpag"].ToString() + ";";
                                riga = riga + dtTipiPag.Rows[i]["Desc_pag"].ToString() + ";";
                                riga = riga + dtTipiPag.Rows[i]["DTINIZ"].ToString() + ";";
                                riga = riga + dtTipiPag.Rows[i]["DTFINE"].ToString() + ";";
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File TipiPag creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_TipiPag.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File TipiPag: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //TipoVolontariato
                    try
                    {
                        PathCompleto = Path + "E_TipoVolontariato.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtTipoVolontariato.Rows.Count; i++)
                            {
                                riga = dtTipoVolontariato.Rows[i]["CodVol"].ToString() + ";";
                                riga = riga + dtTipoVolontariato.Rows[i]["TipoVol"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File TipoVolontariato creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_TipoVolontariato.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File TipoVolontariato: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //VolAttivita
                    try
                    {
                        PathCompleto = Path + "E_VolAttivita.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtVolAttivita.Rows.Count; i++)
                            {
                                riga = dtVolAttivita.Rows[i]["NVolInt"].ToString() + ";";
                                riga = riga + dtVolAttivita.Rows[i]["DTInizioVolAtt"].ToString() + ";";
                                riga = riga + dtVolAttivita.Rows[i]["DTFineVolAtt"].ToString() + ";";
                                riga = riga + dtVolAttivita.Rows[i]["CodVol"].ToString() + ";";
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File VolAttivita creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_VolAttivita.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File VolAttivita: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //Volontari
                    try
                    {
                        PathCompleto = Path + "E_Volontari.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtVolontari.Rows.Count; i++)
                            {
                                riga = dtVolontari.Rows[i]["VolNsocio"].ToString() + ";";
                                riga = riga + dtVolontari.Rows[i]["NumVolontario"].ToString() + ";";
                                riga = riga + dtVolontari.Rows[i]["DTInizioVol"].ToString() + ";";
                                riga = riga + dtVolontari.Rows[i]["DTFineVol"].ToString() + ";";
                                riga = riga + dtVolontari.Rows[i]["N_Vol_Anpas"].ToString() + ";";
                                riga = riga + dtVolontari.Rows[i]["Vescluso"].ToString();
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File Volontari creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Volontari.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File Volontari: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }

                    //Referenti
                    try
                    {
                        PathCompleto = Path + "E_Referenti.txt";
                        if (System.IO.File.Exists(PathCompleto))
                        {
                            sw = new StreamWriter(PathCompleto);
                            sw.Write(string.Empty);


                            for (int i = 0; i < dtReferenti.Rows.Count; i++)
                            {
                                riga = dtReferenti.Rows[i]["N_FAMI"].ToString() + ";";
                                riga = riga + dtReferenti.Rows[i]["N_SOCIO"].ToString() + ";";
                                riga = riga + dtReferenti.Rows[i]["IMP_FAM"].ToString() + ";";
                                riga = riga + dtReferenti.Rows[i]["S_Mail"].ToString() + ";";
                                if (dtReferenti.Rows[i]["DATA_FINE"] != null && dtReferenti.Rows[i]["DATA_FINE"].ToString().Length > 8)
                                {
                                    riga = riga + dtReferenti.Rows[i]["DATA_FINE"].ToString().Substring(0, 8);
                                }
                                else
                                {
                                    riga = riga + dtReferenti.Rows[i]["DATA_FINE"].ToString();
                                }
                                sw.WriteLine(riga);
                            }

                            sw.Close();
                            log = log + "File E_Referenti creato correttamente <BR /><BR />";
                        }
                        else
                        {
                            log = log + "Il File E_Referenti.txt non esiste <BR /><BR />";
                            err = true;
                        }
                    }
                    catch (Exception Ex)
                    {
                        log = log + "File E_Referenti: " + Ex.Message + " <BR /><BR />";
                        err = true;
                    }


                    #endregion

                    #region CANCELLAZIONE

                    if (!err)
                    {
                        try
                        {
                            objQrySC.SvuotaDBApp();
                        }
                        catch (Exception Ex)
                        {
                            log = "ERRORE NELLO SVUOTAMENTO DEL DB <BR /><BR />";
                            log = log + Ex.Message;
                            log = log + "<BR /><BR />alcune tabelle potrebbero essere comunque vuote, ripetere la procedura";
                            err = true;
                        }
                    }
                    #endregion

                    #region CARICA FILES
                    if (!err)
                    {
                        //Consiglio
                        try
                        {
                            PathCompleto = Path + "E_Consiglio.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_CONSIGLIO");
                                log = log + "File Consiglio caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Consiglio.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Consiglio: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //Donatori
                        try
                        {
                            PathCompleto = Path + "E_Donatori.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Donatori");
                                log = log + "File Donatori caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Donatori.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Donatori: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //Donazioni
                        try
                        {
                            PathCompleto = Path + "E_Donazioni.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Donazioni");
                                log = log + "File Donazioni caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Donazioni.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Donazioni: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //Quote
                        try
                        {
                            PathCompleto = Path + "E_Quote.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Quote");
                                log = log + "File Quote caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Quote.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Quote: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //Soci
                        try
                        {
                            PathCompleto = Path + "E_Soci.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Soci");
                                log = log + "File Soci caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Soci.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Soci: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //TabDimissioni
                        /*
                        try
                        {
                            PathCompleto = Path + "D_TabDimissioni.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_TabDimissioni");
                                log = log + "File TabDimissioni caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File D_TabDimissioni.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File TabDimissioni: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }*/

                        //TessereAnpas
                        try
                        {
                            PathCompleto = Path + "E_TessereAnpas.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_TessereAnpas");
                                log = log + "File TessereAnpas caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_TessereAnpas.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File TessereAnpas: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //TipiPag
                        try
                        {
                            PathCompleto = Path + "D_TipiPag.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_TipiPag");
                                log = log + "File TipiPag caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File D_TipiPag.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File TipiPag: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //TipoVolontariato
                        try
                        {
                            PathCompleto = Path + "E_TipoVolontariato.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_TipoVolontariato");
                                log = log + "File TipoVolontariato caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_TipoVolontariato.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File TipoVolontariato: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //VolAttivita
                        try
                        {
                            PathCompleto = Path + "E_VolAttivita.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_VolAttivita");
                                log = log + "File VolAttivita caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_VolAttivita.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File VolAttivita: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //Volontari
                        try
                        {
                            PathCompleto = Path + "E_Volontari.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Volontari");
                                log = log + "File Volontari caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Volontari.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Volontari: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }

                        //referenti
                        try
                        {
                            PathCompleto = Path + "E_Referenti.txt";
                            if (System.IO.File.Exists(PathCompleto))
                            {
                                objQry.CaricaDati(PathCompleto, "APP_Referenti");
                                log = log + "File Referenti caricato correttamente <BR /><BR />";
                            }
                            else
                            {
                                log = log + "Il File E_Referenti.txt non esiste <BR /><BR />";
                                err = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            log = log + "File Referenti: " + Ex.Message + " <BR /><BR />";
                            err = true;
                        }


                    }
                    #endregion

                    #region COMPLETA COPIA
                    if (!err)
                    {
                        try
                        {
                            objQrySC.SvuotaDB();
                            objQrySC.CompletaCopia();
                        }
                        catch (Exception Ex)
                        {
                            log = "ERRORE NELLA COPIA FINALE DEI DATI: " + Ex.Message;
                        }
                        if (!err)
                        {
                            log = "CARICAMENTO AVVENUTO CON SUCCESSO";
                        }
                    }
                    #endregion

                }
                else
                {
                    log = log + "ATTENZIONE!! si sono verificati degli errori nella lettura delle seguenti tabelle: <br /><br />";
                    for (int i = 0; i < dtErroriLettura.Rows.Count; i++)
                    {
                        log = log + dtErroriLettura.Rows[i]["TABELLA"].ToString() + " - " + dtErroriLettura.Rows[i]["ERRORE"].ToString();
                    }
                    log = log + "<br /><br />controllare il file e riprovare il caricamento";
                }
                return log;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }
    }




}

