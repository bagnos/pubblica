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
    public partial class CaricaDati : Pagebasic
    {

        QueryScambio objQrySC = new QueryScambio();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtLog = new DataTable();

            try
            {
                ControllaLogin();
                if (Session["fladmin"].ToString() == "0")
                {
                    Response.Redirect("Noabilitato.aspx");
                }
                else
                {
                    //dtLog = objQry.GetLogCaricamento();
                    //lblLog.Text = "<b>ESITO ULTIMO AGGIORNAMENTO</b><br /><br />";
                    //if (dtLog.Rows.Count > 0)
                    //{
                    //    lblLog.Text = lblLog.Text + "DATA AGGIORNAMENTO: <b>" + dtLog.Rows[0]["GIORNO"].ToString() + "-" + dtLog.Rows[0]["MESE"].ToString() + "-" + dtLog.Rows[0]["ANNO"].ToString() + "</b><br /><br />";
                    //    lblLog.Text = lblLog.Text + dtLog.Rows[0]["LOG_CARICAMENTO"].ToString();
                    //}
                    //else
                    //{
                    //    lblLog.Text = lblLog.Text + "Ancora non sono stati effettuati aggiornamenti";
                    //}
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
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
                        catch   (Exception Ex)
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
                            lblErr.Text = lblErr.Text + "ATTENZIONE!! si sono verificati degli errori nella lettura delle seguenti tabelle: <br /><br />";
                            for (int i = 0; i < dtErroriLettura.Rows.Count; i++)
                            {
                                lblErr.Text = lblErr.Text + dtErroriLettura.Rows[i]["TABELLA"].ToString() + " - " + dtErroriLettura.Rows[i]["ERRORE"].ToString();
                            }
                            lblErr.Text = lblErr.Text + "<br /><br />controllare il file e riprovare il caricamento";
                        }
                    }
                    else
                    {
                        lblErr.Text = "Attenzione il nome del file è diverso da quello richiesto!!";
                    }
                }

            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
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
                    }

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
                                riga = riga + dtReferenti.Rows[i]["S_Mail"].ToString() + ";";
                                riga = riga + dtReferenti.Rows[i]["DATA_FINE"].ToString().Substring(0,7);
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
                        }

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
