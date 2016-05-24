using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace pa_taverne
{
    public class QueryScambio
    {
        AccessoDatiScambio objAccS = new AccessoDatiScambio();
        AccessoDati objAcc = new AccessoDatiLnx();

        public QueryScambio()
        {
        }

        public DataTable Consiglio()
        {
            string SQL;

            SQL = "SELECT N_socio ";
            SQL = SQL + ", 1 AS ID_STRUTTURA ";
            SQL = SQL + ", IIF(Titolo='Presidente',1,IIF(Titolo='Vice Presidente',2,3)) AS ID_CARICA ";
            SQL = SQL + ", VOTI AS NUM_VOTI ";
            SQL = SQL + ", Responsabilità AS TX_RESPONSABILITA ";
            SQL = SQL + "FROM Consiglio ";
            SQL = SQL + "WHERE FineMand>=Now() ";
            SQL = SQL + "and Cod_vol='7' ";

            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Revisori()
        {
            string SQL;

            SQL = "SELECT N_socio ";
            SQL = SQL + ", 3 AS ID_STRUTTURA ";
            SQL = SQL + ", IIF(Titolo='Presidente',1,2) AS ID_CARICA ";
            SQL = SQL + ", VOTI AS NUM_VOTI ";
            SQL = SQL + ", Responsabilità AS TX_RESPONSABILITA ";
            SQL = SQL + "FROM Consiglio ";
            SQL = SQL + "WHERE FineMand>=Now() ";
            SQL = SQL + "and Cod_vol='9' ";

            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Probiviri()
        {
            string SQL;

            SQL = "SELECT N_socio ";
            SQL = SQL + ", 2 AS ID_STRUTTURA ";
            SQL = SQL + ", IIF(Titolo='Presidente',1,2) AS ID_CARICA ";
            SQL = SQL + ", VOTI AS NUM_VOTI ";
            SQL = SQL + ", Responsabilità AS TX_RESPONSABILITA ";
            SQL = SQL + "FROM Consiglio ";
            SQL = SQL + "WHERE FineMand>=Now() ";
            SQL = SQL + "and Cod_vol='8' ";

            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Donatori()
        {
            string SQL;

            SQL = "SELECT Donatori.NSocio ";
            SQL = SQL + ", Donatori.Matricola ";
            SQL = SQL + ", Donatori.COD_DON ";
            SQL = SQL + ", Donatori.GruppoSanguigno ";
            SQL = SQL + ", Donatori.RH ";
            SQL = SQL + ", Donatori.FENOTIPO ";
            SQL = SQL + ", YEAR(Donatori.DataInizioDon) &'/'& MONTH(Donatori.DataInizioDon) &'/'& DAY(Donatori.DataInizioDon) AS dtInizioDon ";
            SQL = SQL + ", IIF(Donatori.DataFineDon IS NOT NULL,YEAR(Donatori.DataFineDon) &'/'& MONTH(Donatori.DataFineDon) &'/'& DAY(Donatori.DataFineDon),NULL) AS dtFineDon ";
            SQL = SQL + "FROM Donatori ";


            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Donazioni()
        {
            string SQL;

            SQL = "SELECT Donazioni.NSocio ";
            SQL = SQL + ", YEAR(Donazioni.DataDonazione) &'/'& MONTH(Donazioni.DataDonazione) &'/'& DAY(Donazioni.DataDonazione) AS DTDONAZIONE ";
            SQL = SQL + ", Donazioni.TipoDonazione ";
            SQL = SQL + "FROM Donazioni ";
            

            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Quote()
        {
            string SQL;

            SQL = "SELECT Quote.NSocio ";
            SQL = SQL + ", YEAR(Quote.DataPagamento) &'/'& MONTH(Quote.DataPagamento) &'/'& DAY(Quote.DataPagamento) as DTPAGAMENTO ";
            SQL = SQL + ", Quote.LuogoPagamento ";
            SQL = SQL + ", Quote.QuotaRisc ";
            SQL = SQL + "FROM Quote ";



            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Soci()
        {
            string SQL;

            SQL = "SELECT Soci.NSocio ";
            SQL = SQL + ", Soci.NumFamiglia ";
            SQL = SQL + ", Soci.Nome ";
            SQL = SQL + ", Soci.Cognome ";
            SQL = SQL + ", YEAR(Soci.DataNascita) &'/'& MONTH(Soci.DataNascita) &'/'& DAY(Soci.DataNascita) as DTNascita ";
            SQL = SQL + ", Soci.LuogoNascita ";
            SQL = SQL + ", Soci.Indirizzo ";
            SQL = SQL + ", Soci.Frazione ";
            SQL = SQL + ", Soci.Comune ";
            SQL = SQL + ", Soci.Telefono ";
            SQL = SQL + ", Soci.Cellulare ";
            SQL = SQL + ", Soci.CodFiscale ";
            SQL = SQL + ", YEAR(Soci.DataIscrizione) &'/'& MONTH(Soci.DataIscrizione) &'/'& DAY(Soci.DataIscrizione) as DTIscrizione ";
            SQL = SQL + ", IIF(Soci.DataFineIscrizione IS NOT NULL,YEAR(Soci.DataFineIscrizione) &'/'& MONTH(Soci.DataFineIscrizione) &'/'& DAY(Soci.DataFineIscrizione),NULL) as DTFineIscrizione ";
            SQL = SQL + ", Soci.MotivoFine ";
            SQL = SQL + ", Soci.NumVolontario ";
            SQL = SQL + ", Soci.COD_SAN ";
            SQL = SQL + ", Soci.MED_CUR ";
            SQL = SQL + ", Soci.ONOR ";
            SQL = SQL + "FROM Soci ";



            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable TabDimissioni()
        {
            string SQL;

            SQL = "SELECT TabDimissioni.CodDim ";
            SQL = SQL + ", TabDimissioni.Desc_Dimissione ";
            SQL = SQL + "FROM TabDimissioni ";




            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable TessereAnpas()
        {
            string SQL;

            SQL = "SELECT TessereAnpas.NSocio ";
            SQL = SQL + ", TessereAnpas.NumTesseraAtt ";
            SQL = SQL + ", TessereAnpas.Anno ";
            SQL = SQL + ", TessereAnpas.NumTesseraPrec ";
            SQL = SQL + "FROM TessereAnpas ";
            
            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable TipiPag()
        {
            string SQL;

            SQL = "SELECT TipiPag.Cod_pag ";
            SQL = SQL + ", TipiPag.Codpag ";
            SQL = SQL + ", TipiPag.Desc_pag ";
            SQL = SQL + ", YEAR(TipiPag.Data_ini) &'/'& MONTH(TipiPag.Data_ini) &'/'& DAY(TipiPag.Data_ini) AS DTINIZ ";
            SQL = SQL + ", IIF(TipiPag.Data_fine IS NOT NULL,YEAR(TipiPag.Data_fine) &'/'& MONTH(TipiPag.Data_fine) &'/'& DAY(TipiPag.Data_fine),NULL) AS DTFINE ";
            SQL = SQL + "FROM TipiPag ";


            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable TipoVolontariato()
        {
            string SQL;

            SQL = "SELECT TipoVolontariato.CodVol ";
            SQL = SQL + ", TipoVolontariato.TipoVol ";
            SQL = SQL + "FROM TipoVolontariato ";
                        
            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable VolAttivita()
        {
            string SQL;

            SQL = "SELECT VolAttività.NVolInt ";
            SQL = SQL + ", YEAR(VolAttività.DataInizioVolAtt) &'/'& MONTH(VolAttività.DataInizioVolAtt) &'/'& DAY(VolAttività.DataInizioVolAtt) AS DTInizioVolAtt ";
            SQL = SQL + ", IIF(VolAttività.DataFineVolAtt IS NOT NULL,YEAR(VolAttività.DataFineVolAtt) &'/'& MONTH(VolAttività.DataFineVolAtt) &'/'& DAY(VolAttività.DataFineVolAtt),NULL) AS DTFineVolAtt ";
            SQL = SQL + ", VolAttività.CodVol ";
            SQL = SQL + "FROM VolAttività ";


            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Volontari()
        {
            string SQL;

            SQL = "SELECT Volontari.VolNsocio ";
            SQL = SQL + ", Volontari.NumVolontario ";
            SQL = SQL + ", YEAR(Volontari.DataInizioVol) &'/'& MONTH(Volontari.DataInizioVol) &'/'& DAY(Volontari.DataInizioVol) as DTInizioVol ";
            SQL = SQL + ", IIF(Volontari.DataFineVol IS NOT NULL,YEAR(Volontari.DataFineVol) &'/'& MONTH(Volontari.DataFineVol) &'/'& DAY(Volontari.DataFineVol),NULL) AS DTFineVol ";
            SQL = SQL + ", Volontari.N_Vol_Anpas ";
            SQL = SQL + ", Volontari.Vescluso ";
            SQL = SQL + "FROM Volontari ";



            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Referenti()
        {
            string SQL;

            SQL = "SELECT ULT_PAG ";
            SQL = SQL + ", N_FAMI ";
            SQL = SQL + ", N_SOCIO ";
            SQL = SQL + ", IMP_FAM ";
            SQL = SQL + ", S_Mail ";
            SQL = SQL + ", DATA_FINE ";
            SQL = SQL + ", DESCR_PAG ";
            


            SQL = SQL + "FROM Referenti ";
            try
            {
                return objAccS.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void InsConsiglio(string ID_SOCIO, string ID_STRUTTURA, string ID_CARICA, string NUM_VOTI
            , string TX_RESPONSABILITA)
        {
            string SQL;

            SQL = "INSERT INTO APP_CONSIGLIO ";
            SQL = SQL + "SELECT " + ID_SOCIO + " AS ID_SOCIO ";
            SQL = SQL + ", " + ID_STRUTTURA + " AS ID_STRUTTURA ";
            SQL = SQL + ", " + ID_CARICA + " AS ID_CARICA ";
            SQL = SQL + ", " + NUM_VOTI + " AS NUM_VOTI ";
            SQL = SQL + ", '" + TX_RESPONSABILITA.Replace("'","`") + "' AS TX_RESPONSABILITA ";
            SQL = SQL + "FROM DUAL ";

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsDonatori(string NSocio, string Matricola, string COD_DON, string GruppoSanguigno
            , string RH, string FENOTIPO, string DataInizioDon, string DataFineDon)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_Donatori ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (Matricola.Trim() != string.Empty)
                {
                    SQL = SQL + ", " + Matricola + " AS Matricola ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Matricola ";
                }
                SQL = SQL + ", '" + COD_DON.Replace("'","`") + "' AS COD_DON ";
                SQL = SQL + ", '" + GruppoSanguigno.Replace("'", "`") + "' AS GruppoSanguigno ";
                SQL = SQL + ", '" + RH.Replace("'", "`") + "' AS RH ";
                SQL = SQL + ", '" + FENOTIPO.Replace("'", "`") + "' AS FENOTIPO ";
                if (DataInizioDon.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataInizioDon.Replace("-", "/") + "# AS DataInizioDon ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioDon ";
                }
                if (DataFineDon.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataFineDon.Replace("-", "/") + "# AS DataFineDon ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineDon ";
                }
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_Donatori ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (Matricola.Trim() != string.Empty)
                {
                    SQL = SQL + ", " + Matricola + " AS Matricola ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Matricola ";
                }
                SQL = SQL + ", '" + COD_DON.Replace("'", "`") + "' AS COD_DON ";
                SQL = SQL + ", '" + GruppoSanguigno.Replace("'", "`") + "' AS GruppoSanguigno ";
                SQL = SQL + ", '" + RH.Replace("'", "`") + "' AS RH ";
                SQL = SQL + ", '" + FENOTIPO.Replace("'", "`") + "' AS FENOTIPO ";
                if (DataInizioDon.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataInizioDon + "') AS DataInizioDon ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioDon ";
                }
                if (DataFineDon.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataFineDon + "') AS DataFineDon ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineDon ";
                }
                SQL = SQL + "FROM DUAL ";            
            }


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsDonazioni(string NSocio, string DataDonazione, string TipoDonazione)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_Donazioni ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (DataDonazione.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataDonazione.Replace("-", "/") + "# AS DataDonazione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataDonazione ";
                }
                SQL = SQL + ", " + TipoDonazione + "  AS TipoDonazione ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_Donazioni ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (DataDonazione.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataDonazione + "') AS DataDonazione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataDonazione ";
                }
                SQL = SQL + ", " + TipoDonazione + "  AS TipoDonazione ";
                SQL = SQL + "FROM DUAL ";
            }


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsQuote(string NSocio, string DataPagamento, string LuogoPagamento, string QuotaRisc)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_Quote ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (DataPagamento.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataPagamento.Replace("-", "/") + "# AS DataPagamento ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataPagamento ";
                }
                SQL = SQL + ", '" + LuogoPagamento.Replace("'", "`") + "'  AS LuogoPagamento ";
                SQL = SQL + ", " + QuotaRisc.Replace(",", ".") + "  AS QuotaRisc ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_Quote ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                if (DataPagamento.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataPagamento + "') AS DataPagamento ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataPagamento ";
                }
                SQL = SQL + ", '" + LuogoPagamento.Replace("'","`") + "'  AS LuogoPagamento ";
                SQL = SQL + ", " + QuotaRisc.Replace(",",".") + "  AS QuotaRisc ";
                SQL = SQL + "FROM DUAL ";
            }


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsSoci(string NSocio, string NumFamiglia, string Nome, string Cognome, string DataNascita
            , string LuogoNascita, string Indirizzo, string Frazione, string Comune, string Telefono, string Cellulare
            , string CodFiscale, string DataIscrizione, string DataFineIscrizione, string MotivoFine
            , string NumVolontario, string COD_SAN, string MED_CUR,String onor)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_Soci ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                SQL = SQL + ", " + NumFamiglia + "  AS NumFamiglia ";
                SQL = SQL + ", '" + Nome.Replace("'", "`") + "'  AS Nome ";
                SQL = SQL + ", '" + Cognome.Replace("'", "`") + "'  AS Cognome ";
                if (DataNascita.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataNascita.Replace("-", "/") + "# AS DataNascita ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataNascita ";
                }
                SQL = SQL + ", '" + LuogoNascita.Replace("'", "`") + "'  AS LuogoNascita ";
                SQL = SQL + ", '" + Indirizzo.Replace("'", "`") + "'  AS Indirizzo ";
                SQL = SQL + ", '" + Indirizzo.Replace("'", "`") + "'  AS LuogoNascita ";
                if (DataIscrizione.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataIscrizione.Replace("-", "/") + "# AS DataIscrizione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataIscrizione ";
                }
                if (DataFineIscrizione.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataFineIscrizione.Replace("-", "/") + "# AS DataFineIscrizione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineIscrizione ";
                }
                SQL = SQL + ", '" + MotivoFine.Replace("'", "`") + "'  AS MotivoFine ";
                SQL = SQL + ", " + NumVolontario + "  AS NumVolontario ";
                SQL = SQL + ", '" + COD_SAN.Replace("'", "`") + "'  AS COD_SAN ";
                SQL = SQL + ", '" + MED_CUR.Replace("'", "`") + "'  AS MED_CUR ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_Soci ";
                SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
                SQL = SQL + ", " + NumFamiglia + "  AS NumFamiglia ";
                SQL = SQL + ", '" + Nome.Replace("'", "`") + "'  AS Nome ";
                SQL = SQL + ", '" + Cognome.Replace("'", "`") + "'  AS Cognome ";
                if (DataNascita.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataNascita + "') AS DataNascita ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataNascita ";
                }
                SQL = SQL + ", '" + LuogoNascita.Replace("'", "`") + "'  AS LuogoNascita ";
                SQL = SQL + ", '" + Indirizzo.Replace("'", "`") + "'  AS Indirizzo ";
                SQL = SQL + ", '" + Frazione.Replace("'", "`") + "'  AS Frazione ";
                SQL = SQL + ", '" + Comune.Replace("'", "`") + "'  AS Comune ";
                SQL = SQL + ", '" + Telefono.Replace("'", "`") + "'  AS Telefono ";
                SQL = SQL + ", '" + Cellulare.Replace("'", "`") + "'  AS Cellulare ";
                SQL = SQL + ", '" + CodFiscale.Replace("'", "`") + "'  AS CodFiscale ";
                if (DataIscrizione.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataIscrizione + "') AS DataIscrizione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataIscrizione ";
                }
                if (DataFineIscrizione.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataFineIscrizione + "') AS DataFineIscrizione ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineIscrizione ";
                }
                SQL = SQL + ", '" + MotivoFine.Replace("'", "`") + "'  AS MotivoFine ";
                SQL = SQL + ", " + NumVolontario + "  AS NumVolontario ";
                SQL = SQL + ", '" + COD_SAN.Replace("'", "`") + "'  AS COD_SAN ";
                SQL = SQL + ", '" + MED_CUR.Replace("'", "`") + "'  AS MED_CUR ";
                SQL = SQL + ", '" + onor.Replace("'", "`") + "'  AS ONOR ";
                SQL = SQL + "FROM DUAL ";
            }


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsTabDimissioni(string CodDim, string Desc_Dimissione)
        {
            string SQL;


            SQL = "INSERT INTO APP_TabDimissioni ";
            SQL = SQL + "SELECT '" + CodDim.Replace("'", "`") + "' AS CodDim ";
            SQL = SQL + ", '" + Desc_Dimissione.Replace("'", "`") + "'  AS LuogoPagamento ";
            SQL = SQL + "FROM DUAL ";
            


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsTessereAnpas(string NSocio, string NumTesseraAtt, string Anno, string NumTesseraPrec)
        {
            string SQL;


            SQL = "INSERT INTO APP_TessereAnpas ";
            SQL = SQL + "SELECT " + NSocio + " AS NSocio ";
            SQL = SQL + ", " + NumTesseraAtt + "  AS NumTesseraAtt ";
            SQL = SQL + ", " + Anno + "  AS Anno ";
            if (NumTesseraPrec.Trim() != string.Empty)
            {
                SQL = SQL + ", " + NumTesseraPrec + "  AS NumTesseraPrec ";
            }
            else
            {
                SQL = SQL + ", NULL  AS NumTesseraPrec ";
            }
            SQL = SQL + "FROM DUAL ";



            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsTipiPag(string Cod_pag, string Codpag, string Desc_pag, string Data_ini, string Data_fine)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_TipiPag ";
                SQL = SQL + "SELECT " + Cod_pag + " AS Cod_pag ";
                SQL = SQL + ", '" + Codpag.Replace("'", "`") + "'  AS Codpag ";
                SQL = SQL + ", '" + Desc_pag.Replace("'", "`") + "'  AS Desc_pag ";
                if (Data_ini.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + Data_ini.Replace("-", "/") + "# AS Data_ini ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Data_ini ";
                }
                if (Data_fine.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + Data_fine.Replace("-", "/") + "# AS Data_fine ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Data_fine ";
                }
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_TipiPag ";
                SQL = SQL + "SELECT " + Cod_pag + " AS Cod_pag ";
                SQL = SQL + ", '" + Codpag.Replace("'", "`") + "'  AS Codpag ";
                SQL = SQL + ", '" + Desc_pag.Replace("'", "`") + "'  AS Desc_pag ";
                if (Data_ini.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + Data_ini + "') AS Data_ini ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Data_ini ";
                }
                if (Data_fine.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + Data_fine + "') AS Data_fine ";
                }
                else
                {
                    SQL = SQL + ", NULL AS Data_fine ";
                }
                SQL = SQL + "FROM DUAL ";
            }



            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsTipoVolontariato(string CodVol, string TipoVol)
        {
            string SQL;


            SQL = "INSERT INTO APP_TipoVolontariato ";
            SQL = SQL + "SELECT " + CodVol + " AS CodVol ";
            SQL = SQL + ", '" + TipoVol.Replace("'", "`") + "'  AS TipoVol ";
            SQL = SQL + "FROM DUAL ";



            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsVolAttivita(string NVolInt, string DataInizioVolAtt, string DataFineVolAtt, string CodVol)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_VolAttivita ";
                SQL = SQL + "SELECT " + NVolInt + " AS NVolInt ";
                if (DataInizioVolAtt.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataInizioVolAtt.Replace("-", "/") + "# AS DataInizioVolAtt ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioVolAtt ";
                }
                if (DataFineVolAtt.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataFineVolAtt.Replace("-", "/") + "# AS DataFineVolAtt ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineVolAtt ";
                }
                SQL = SQL + ", " + CodVol + "  AS CodVol ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_VolAttivita ";
                SQL = SQL + "SELECT " + NVolInt + " AS NVolInt ";
                if (DataInizioVolAtt.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataInizioVolAtt + "') AS DataInizioVolAtt ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioVolAtt ";
                }
                if (DataFineVolAtt.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataFineVolAtt + "') AS DataFineVolAtt ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineVolAtt ";
                }
                SQL = SQL + ", " + CodVol + "  AS CodVol ";
                SQL = SQL + "FROM DUAL ";
            }



            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsVolontari(string VolNsocio, string NumVolontario, string DataInizioVol, string DataFineVol
            , string N_Vol_Anpas, string Vescluso)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO APP_Volontari ";
                SQL = SQL + "SELECT " + VolNsocio + " AS VolNsocio ";
                SQL = SQL + ", " + NumVolontario + " AS NumVolontario ";
                if (DataInizioVol.Trim() != string.Empty)
                {
                    SQL = SQL + ", #" + DataInizioVol.Replace("-", "/") + "# AS DataInizioVol ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioVol ";
                }
                if (DataFineVol.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataFineVol.Replace("-", "/") + "') AS DataFineVol ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineVol ";
                }
                SQL = SQL + ", " + N_Vol_Anpas + " AS N_Vol_Anpas ";
                SQL = SQL + ", '" + Vescluso + "' AS Vescluso ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO APP_Volontari ";
                SQL = SQL + "SELECT " + VolNsocio + " AS VolNsocio ";
                SQL = SQL + ", " + NumVolontario + " AS NumVolontario ";
                if (DataInizioVol.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataInizioVol + "') AS DataInizioVol ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataInizioVol ";
                }
                if (DataFineVol.Trim() != string.Empty)
                {
                    SQL = SQL + ", DATE('" + DataFineVol + "') AS DataFineVol ";
                }
                else
                {
                    SQL = SQL + ", NULL AS DataFineVol ";
                }
                if (N_Vol_Anpas.Trim() != string.Empty)
                {
                    SQL = SQL + ", " + N_Vol_Anpas + " AS N_Vol_Anpas ";
                }
                else
                {
                    SQL = SQL + ", NULL AS N_Vol_Anpas ";
                }
                SQL = SQL + ", '" + Vescluso + "' AS Vescluso ";
                SQL = SQL + "FROM DUAL ";
            }


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InsReferenti(string nFam, string nSocio, string sMail, string dataFine)
        {
            string SQL;

            
            
                SQL = "INSERT INTO APP_Volontari ";
                SQL = SQL + "SELECT " + nFam + " AS N_FAMI ";
                SQL = SQL + ", " + nSocio + " AS N_SOCIO ";
                SQL = SQL + ", " + sMail + " AS S_MAIL ";
                if (dataFine!=null && dataFine.Trim()!=string.Empty)
                    SQL = SQL + ", DATE('" + dataFine + "') AS DATA_FINE ";
                


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void SvuotaDB()
        {
            string SQL1;
            string SQL2;
            string SQL3;
            string SQL4;
            string SQL5;
            string SQL6;
            string SQL7;
            string SQL8;
            string SQL9;
            string SQL10;
            string SQL11;
            string SQL12;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL1 = "DELETE * FROM E_CONSIGLIO";
                SQL2 = "DELETE * FROM E_Donatori";
                SQL3 = "DELETE * FROM E_Donazioni";
                SQL4 = "DELETE * FROM E_Quote";
                SQL5 = "DELETE * FROM E_Soci where NSocio<>0";
                SQL6 = "DELETE * FROM D_TabDimissioni";
                SQL7 = "DELETE * FROM E_TessereAnpas";
                SQL8 = "DELETE * FROM D_TipiPag";
                SQL9 = "DELETE * FROM E_TipoVolontariato";
                SQL10 = "DELETE * FROM E_VolAttivita";
                SQL11 = "DELETE * FROM E_Volontari";
                SQL12 = "DELETE * FROM E_Referenti";
            }
            else
            {
                SQL1 = "DELETE FROM E_CONSIGLIO";
                SQL2 = "DELETE FROM E_Donatori";
                SQL3 = "DELETE FROM E_Donazioni";
                SQL4 = "DELETE FROM E_Quote";
                SQL5 = "DELETE FROM E_Soci where NSocio<>0";
                SQL6 = "DELETE FROM D_TabDimissioni";
                SQL7 = "DELETE FROM E_TessereAnpas";
                SQL8 = "DELETE FROM D_TipiPag";
                SQL9 = "DELETE FROM D_TipoVolontariato";
                SQL10 = "DELETE FROM E_VolAttivita";
                SQL11 = "DELETE FROM E_Volontari";
                SQL12 = "DELETE FROM E_Referenti";
            }

            try
            {
                objAcc.Esegui(SQL1);
                objAcc.Esegui(SQL2);
                objAcc.Esegui(SQL3);
                objAcc.Esegui(SQL4);
                objAcc.Esegui(SQL5);
                objAcc.Esegui(SQL6);
                objAcc.Esegui(SQL7);
                objAcc.Esegui(SQL8);
                objAcc.Esegui(SQL9);
                objAcc.Esegui(SQL10);
                objAcc.Esegui(SQL11);
                objAcc.Esegui(SQL12);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }


        }

        public void SvuotaDBApp()
        {
            string SQL1;
            string SQL2;
            string SQL3;
            string SQL4;
            string SQL5;
            string SQL6;
            string SQL7;
            string SQL8;
            string SQL9;
            string SQL10;
            string SQL11;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL1 = "DELETE * FROM APP_CONSIGLIO";
                SQL2 = "DELETE * FROM APP_Donatori";
                SQL3 = "DELETE * FROM APP_Donazioni";
                SQL4 = "DELETE * FROM APP_Quote";
                SQL5 = "DELETE * FROM APP_Soci where NSocio<>0";
                SQL6 = "DELETE * FROM APP_TabDimissioni";
                SQL7 = "DELETE * FROM APP_TessereAnpas";
                SQL8 = "DELETE * FROM APP_TipiPag";
                SQL9 = "DELETE * FROM APP_TipoVolontariato";
                SQL10 = "DELETE * FROM APP_VolAttivita";
                SQL11 = "DELETE * FROM APP_Volontari";
            }
            else
            {
                SQL1 = "DELETE FROM APP_CONSIGLIO";
                SQL2 = "DELETE FROM APP_Donatori";
                SQL3 = "DELETE FROM APP_Donazioni";
                SQL4 = "DELETE FROM APP_Quote";
                SQL5 = "DELETE FROM APP_Soci where NSocio<>0";
                SQL6 = "DELETE FROM APP_TabDimissioni";
                SQL7 = "DELETE FROM APP_TessereAnpas";
                SQL8 = "DELETE FROM APP_TipiPag";
                SQL9 = "DELETE FROM APP_TipoVolontariato";
                SQL10 = "DELETE FROM APP_VolAttivita";
                SQL11 = "DELETE FROM APP_Volontari";
            }

            try
            {
                objAcc.Esegui(SQL1);
                objAcc.Esegui(SQL2);
                objAcc.Esegui(SQL3);
                objAcc.Esegui(SQL4);
                objAcc.Esegui(SQL5);
                objAcc.Esegui(SQL6);
                objAcc.Esegui(SQL7);
                objAcc.Esegui(SQL8);
                objAcc.Esegui(SQL9);
                objAcc.Esegui(SQL10);
                objAcc.Esegui(SQL11);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }


        }

        public void CompletaCopia()
        {
            string SQL1;
            string SQL2;
            string SQL3;
            string SQL4;
            string SQL5;
            string SQL6;
            string SQL7;
            string SQL8;
            string SQL9;
            string SQL10;
            string SQL11;
            string SQL12;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL1 = "INSERT INTO E_CONSIGLIO SELECT * FROM E_CONSIGLIO";
                SQL2 = "INSERT INTO E_Donatori SELECT * FROM E_Donatori";
                SQL3 = "INSERT INTO E_Donazioni SELECT * FROM E_Donazioni";
                SQL4 = "INSERT INTO E_Quote SELECT * FROM E_Quote";
                SQL5 = "INSERT INTO E_Soci SELECT * FROM E_Soci";
                SQL6 = "INSERT INTO D_TabDimissioni SELECT * FROM D_TabDimissioni";
                SQL7 = "INSERT INTO E_TessereAnpas SELECT * FROM E_TessereAnpas";
                SQL8 = "INSERT INTO D_TipiPag SELECT * FROM D_TipiPag";
                SQL9 = "INSERT INTO E_TipoVolontariato SELECT * FROM E_TipoVolontariato";
                SQL10 = "INSERT INTO E_VolAttivita SELECT * FROM E_VolAttivita";
                SQL11 = "INSERT INTO E_Volontari SELECT * FROM E_Volontari";
                SQL12 = "INSERT INTO E_Referenti SELECT * FROM E_Referenti";
            }
            else
            {
                SQL1 = "INSERT INTO E_CONSIGLIO SELECT * FROM APP_CONSIGLIO";
                SQL2 = "INSERT INTO E_Donatori SELECT * FROM APP_Donatori";
                SQL3 = "INSERT INTO E_Donazioni SELECT * FROM APP_Donazioni";
                SQL4 = "INSERT INTO E_Quote SELECT * FROM APP_Quote";
                SQL5 = "INSERT INTO E_Soci SELECT * FROM APP_Soci";
                SQL6 = "INSERT INTO D_TabDimissioni SELECT * FROM APP_TabDimissioni";
                SQL7 = "INSERT INTO E_TessereAnpas SELECT * FROM APP_TessereAnpas";
                SQL8 = "INSERT INTO D_TipiPag SELECT * FROM APP_TipiPag";
                SQL9 = "INSERT INTO D_TipoVolontariato SELECT * FROM APP_TipoVolontariato";
                SQL10 = "INSERT INTO E_VolAttivita SELECT * FROM APP_VolAttivita";
                SQL11 = "INSERT INTO E_Volontari SELECT * FROM APP_Volontari";
                SQL12 = "INSERT INTO E_Referenti SELECT * FROM APP_Referenti";
            }

            try
            {
                objAcc.Esegui(SQL1);
                objAcc.Esegui(SQL2);
                objAcc.Esegui(SQL3);
                objAcc.Esegui(SQL4);
                objAcc.Esegui(SQL5);
                objAcc.Esegui(SQL6);
                objAcc.Esegui(SQL7);
                objAcc.Esegui(SQL8);
                objAcc.Esegui(SQL9);
                objAcc.Esegui(SQL10);
                objAcc.Esegui(SQL11);
                objAcc.Esegui(SQL12);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }


        }
    }
}
