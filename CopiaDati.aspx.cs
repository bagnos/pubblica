using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class CopiaDati : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Flag;
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

            DataTable dtErroriLettura = new DataTable();

            QueryScambio objQrySC = new QueryScambio();

            string log = string.Empty;

            bool err = false;

            try
            {
                Flag = objQry.VerificaDati();
                if (Flag == "1")
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
                    #endregion

                    if (dtErroriLettura.Rows.Count == 0)
                    {

                        #region CANCELLAZIONE

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
                        #endregion

                        #region SCRITTURA

                        if (!err)
                        {
                            try
                            {
                                for (int i = 0; i < dtConsiglio.Rows.Count; i++)
                                {
                                    objQrySC.InsConsiglio(dtConsiglio.Rows[i]["N_socio"].ToString(),
                                        dtConsiglio.Rows[i]["ID_STRUTTURA"].ToString(),
                                        dtConsiglio.Rows[i]["ID_CARICA"].ToString(),
                                        dtConsiglio.Rows[i]["NUM_VOTI"].ToString(),
                                        dtConsiglio.Rows[i]["TX_RESPONSABILITA"].ToString());
                                }
                                log = log + "Tabella Consiglio inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Consiglio: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtRevisori.Rows.Count; i++)
                                {
                                    objQrySC.InsConsiglio(dtRevisori.Rows[i]["N_socio"].ToString(),
                                        dtRevisori.Rows[i]["ID_STRUTTURA"].ToString(),
                                        dtRevisori.Rows[i]["ID_CARICA"].ToString(),
                                        dtRevisori.Rows[i]["NUM_VOTI"].ToString(),
                                        dtRevisori.Rows[i]["TX_RESPONSABILITA"].ToString());
                                }
                                log = log + "Tabella Revisori inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Revisori: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtProbiviri.Rows.Count; i++)
                                {
                                    objQrySC.InsConsiglio(dtProbiviri.Rows[i]["N_socio"].ToString(),
                                        dtProbiviri.Rows[i]["ID_STRUTTURA"].ToString(),
                                        dtProbiviri.Rows[i]["ID_CARICA"].ToString(),
                                        dtProbiviri.Rows[i]["NUM_VOTI"].ToString(),
                                        dtProbiviri.Rows[i]["TX_RESPONSABILITA"].ToString());
                                }
                                log = log + "Tabella Probiviri inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Probiviri: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtDonatori.Rows.Count; i++)
                                {
                                    objQrySC.InsDonatori(dtDonatori.Rows[i]["NSocio"].ToString(),
                                        dtDonatori.Rows[i]["Matricola"].ToString(),
                                        dtDonatori.Rows[i]["COD_DON"].ToString(),
                                        dtDonatori.Rows[i]["GruppoSanguigno"].ToString(),
                                        dtDonatori.Rows[i]["RH"].ToString(),
                                        dtDonatori.Rows[i]["FENOTIPO"].ToString(),
                                        dtDonatori.Rows[i]["dtInizioDon"].ToString(),
                                        dtDonatori.Rows[i]["dtFineDon"].ToString());
                                }
                                log = log + "Tabella Donatori inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Donatori: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtDonazioni.Rows.Count; i++)
                                {
                                    objQrySC.InsDonazioni(dtDonazioni.Rows[i]["NSocio"].ToString(),
                                        dtDonazioni.Rows[i]["DTDONAZIONE"].ToString(),
                                        dtDonazioni.Rows[i]["TipoDonazione"].ToString());
                                }
                                log = log + "Tabella Donazioni inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Donazioni: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            //try
                            //{
                            //    for (int i = 0; i < dtQuote.Rows.Count; i++)
                            //    {
                            //        objQrySC.InsQuote(dtQuote.Rows[i]["NSocio"].ToString(),
                            //            dtQuote.Rows[i]["DTPAGAMENTO"].ToString(),
                            //            dtQuote.Rows[i]["LuogoPagamento"].ToString(),
                            //            dtQuote.Rows[i]["QuotaRisc"].ToString());
                            //    }
                            //    log = log + "Tabella Quote inserita correttamente <BR /><BR />";
                            //}
                            //catch (Exception Ex)
                            //{
                            //    log = log + "Tabella Quote: " + Ex.Message + " <BR /><BR />";
                            //    err = true;
                            //}
                            try
                            {
                                for (int i = 0; i < dtSoci.Rows.Count; i++)
                                {
                                    objQrySC.InsSoci(dtSoci.Rows[i]["NSocio"].ToString(),
                                        dtSoci.Rows[i]["NumFamiglia"].ToString(),
                                        dtSoci.Rows[i]["Nome"].ToString(),
                                        dtSoci.Rows[i]["Cognome"].ToString(),
                                        dtSoci.Rows[i]["DTNascita"].ToString(),
                                        dtSoci.Rows[i]["LuogoNascita"].ToString(),
                                        dtSoci.Rows[i]["Indirizzo"].ToString(),
                                        dtSoci.Rows[i]["Frazione"].ToString(),
                                        dtSoci.Rows[i]["Comune"].ToString(),
                                        dtSoci.Rows[i]["Telefono"].ToString(),
                                        dtSoci.Rows[i]["Cellulare"].ToString(),
                                        dtSoci.Rows[i]["CodFiscale"].ToString(),
                                        dtSoci.Rows[i]["DTIscrizione"].ToString(),
                                        dtSoci.Rows[i]["DTFineIscrizione"].ToString(),
                                        dtSoci.Rows[i]["MotivoFine"].ToString(),
                                        dtSoci.Rows[i]["NumVolontario"].ToString(),
                                        dtSoci.Rows[i]["COD_SAN"].ToString(),
                                        dtSoci.Rows[i]["MED_CUR"].ToString(),
                                        dtSoci.Rows[i]["ONOR"].ToString());
                                }
                                log = log + "Tabella Soci inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Soci: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtTabDimissioni.Rows.Count; i++)
                                {
                                    objQrySC.InsTabDimissioni(dtTabDimissioni.Rows[i]["CodDim"].ToString(),
                                        dtTabDimissioni.Rows[i]["Desc_Dimissione"].ToString());
                                }
                                log = log + "Tabella TabDimissioni inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella TabDimissioni: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtTessereAnpas.Rows.Count; i++)
                                {
                                    objQrySC.InsTessereAnpas(dtTessereAnpas.Rows[i]["NSocio"].ToString(),
                                        dtTessereAnpas.Rows[i]["NumTesseraAtt"].ToString(),
                                        dtTessereAnpas.Rows[i]["Anno"].ToString(),
                                        dtTessereAnpas.Rows[i]["NumTesseraPrec"].ToString());
                                }
                                log = log + "Tabella TessereAnpas inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella TessereAnpas: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtTipiPag.Rows.Count; i++)
                                {
                                    objQrySC.InsTipiPag(dtTipiPag.Rows[i]["Cod_pag"].ToString(),
                                        dtTipiPag.Rows[i]["Codpag"].ToString(),
                                        dtTipiPag.Rows[i]["Desc_pag"].ToString(),
                                        dtTipiPag.Rows[i]["DTINIZ"].ToString(),
                                        dtTipiPag.Rows[i]["DTFINE"].ToString());
                                }
                                log = log + "Tabella TipiPag inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella TipiPag: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtTipoVolontariato.Rows.Count; i++)
                                {
                                    objQrySC.InsTipoVolontariato(dtTipoVolontariato.Rows[i]["CodVol"].ToString(),
                                        dtTipoVolontariato.Rows[i]["TipoVol"].ToString());
                                }
                                log = log + "Tabella TipoVolontariato inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella TipoVolontariato: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtVolAttivita.Rows.Count; i++)
                                {
                                    objQrySC.InsVolAttivita(dtVolAttivita.Rows[i]["NVolInt"].ToString(),
                                        dtVolAttivita.Rows[i]["DTInizioVolAtt"].ToString(),
                                        dtVolAttivita.Rows[i]["DTFineVolAtt"].ToString(),
                                        dtVolAttivita.Rows[i]["CodVol"].ToString());
                                }
                                log = log + "Tabella VolAttività inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella VolAttività: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }
                            try
                            {
                                for (int i = 0; i < dtVolontari.Rows.Count; i++)
                                {
                                    objQrySC.InsVolontari(dtVolontari.Rows[i]["VolNsocio"].ToString(),
                                        dtVolontari.Rows[i]["NumVolontario"].ToString(),
                                        dtVolontari.Rows[i]["DTInizioVol"].ToString(),
                                        dtVolontari.Rows[i]["DTFineVol"].ToString(),
                                        dtVolontari.Rows[i]["N_Vol_Anpas"].ToString(),
                                        dtVolontari.Rows[i]["Vescluso"].ToString());
                                }
                                log = log + "Tabella Volontari inserita correttamente <BR /><BR />";
                            }
                            catch (Exception Ex)
                            {
                                log = log + "Tabella Volontari: " + Ex.Message + " <BR /><BR />";
                                err = true;
                            }

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
                                    objQry.AggiornaCopia();
                                }
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
                    objQry.InsLogCaricamento(log);
                }
            }
            catch (Exception Ex)
            {
                objQry.InsLogCaricamento("COPIA DATI IN ERRORE: " + Ex.Message);
            }
        }
    }
}
