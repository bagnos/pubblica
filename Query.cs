using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace pa_taverne
{
    public class Query
    {

        AccessoDati objAcc = null;
        public Query()
        {
            objAcc = new AccessoDatiLnx();
        }

        public Query(AccessoDati accesso)
        {
            this.objAcc = accesso;
        }

        #region QUERY NOTIZIE

        public DataTable NotizieHome()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {

                SQL = "SELECT XX.* ";
                SQL = SQL + ", YY.TX_NOMEFILE AS FILEALLEGATO ";
                SQL = SQL + ", YY.TX_DESCRIZIONE AS DESCALLEGATO ";
                SQL = SQL + "FROM ";
                SQL = SQL + "( ";
                SQL = SQL + "SELECT X.*  ";
                SQL = SQL + ", Y.ID_FOTO  ";
                SQL = SQL + ", Y.TX_NOMEFILE  ";
                SQL = SQL + ", Y.TX_DESCFOTO  ";
                SQL = SQL + "FROM  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT A.ID_NOTIZIA  ";
                SQL = SQL + ", DAY(A.DT_EVENTO) AS GIORNO_EVN ";
                SQL = SQL + ", MONTH(A.DT_EVENTO) AS MESE_EVN  ";
                SQL = SQL + ", YEAR(A.DT_EVENTO) AS ANNO_EVN  ";
                SQL = SQL + ", DATEDIFF(\"d\",A.DT_INSERIMENTO,NOW(),2) AS DIFF   ";
                SQL = SQL + ", DATEDIFF(\"d\",A.DT_EVENTO,NOW(),2) AS DIFF2   ";
                SQL = SQL + ", A.DT_INSERIMENTO  ";
                SQL = SQL + ", A.DT_EVENTO  ";
                SQL = SQL + ", A.ID_TIPO  ";
                SQL = SQL + ", B.DS_TIPO  ";
                SQL = SQL + ", A.DS_TITOLO  ";
                SQL = SQL + ", A.DS_SOTTOTITOLO  ";
                SQL = SQL + ", A.DS_DESCRIZIONE  ";
                SQL = SQL + "FROM E_NOTIZIE A   ";
                SQL = SQL + ", D_TIPONOTIZIA B  ";
                SQL = SQL + "WHERE A.ID_TIPO=B.ID_TIPO  ";
                SQL = SQL + "AND A.FL_HOME=1  ";
                SQL = SQL + "AND A.DT_FINE IS NULL  ";
                SQL = SQL + ") X  ";
                SQL = SQL + "LEFT JOIN  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT A.ID_FOTO  ";
                SQL = SQL + ", A.ID_NOTIZIA  ";
                SQL = SQL + ", B.TX_NOMEFILE  ";
                SQL = SQL + ", B.TX_DESCFOTO  ";
                SQL = SQL + "FROM R_FOTO_NOTIZIA A  ";
                SQL = SQL + ", E_FOTO B  ";
                SQL = SQL + "WHERE A.ID_FOTO=B.ID_FOTO  ";
                SQL = SQL + "AND A.FL_PRINCIPALE=1  ";
                SQL = SQL + ") Y  ";
                SQL = SQL + "ON X.ID_NOTIZIA=Y.ID_NOTIZIA ";
                SQL = SQL + ") XX ";
                SQL = SQL + "LEFT JOIN E_ALLEGATINEWS YY ";
                SQL = SQL + "ON XX.ID_NOTIZIA = YY.ID_NOTIZIA  ";
                SQL = SQL + "ORDER BY DT_EVENTO DESC ";
            }
            else
            {
                SQL = "SELECT XX.*  ";
                SQL = SQL + ", YY.TX_NOMEFILE AS FILEALLEGATO  ";
                SQL = SQL + ", YY.TX_DESCRIZIONE AS DESCALLEGATO  ";
                SQL = SQL + "FROM  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT X.*   ";
                SQL = SQL + ", Y.ID_FOTO   ";
                SQL = SQL + ", Y.TX_NOMEFILE   ";
                SQL = SQL + ", Y.TX_DESCFOTO   ";
                SQL = SQL + "FROM   ";
                SQL = SQL + "(   ";
                SQL = SQL + "SELECT A.ID_NOTIZIA   ";
                SQL = SQL + ", DAY(A.DT_EVENTO) AS GIORNO_EVN   ";
                SQL = SQL + ", MONTH(A.DT_EVENTO) AS MESE_EVN   ";
                SQL = SQL + ", YEAR(A.DT_EVENTO) AS ANNO_EVN   ";
                SQL = SQL + ", DATEDIFF(CURDATE(),A.DT_INSERIMENTO) AS DIFF    ";
                SQL = SQL + ", DATEDIFF(CURDATE(),A.DT_EVENTO) AS DIFF2    ";
                SQL = SQL + ", A.DT_INSERIMENTO   ";
                SQL = SQL + ", A.DT_EVENTO  ";
                SQL = SQL + ", A.ID_TIPO   ";
                SQL = SQL + ", B.DS_TIPO   ";
                SQL = SQL + ", A.DS_TITOLO   ";
                SQL = SQL + ", A.DS_SOTTOTITOLO   ";
                SQL = SQL + ", A.DS_DESCRIZIONE   ";
                SQL = SQL + "FROM E_NOTIZIE A    ";
                SQL = SQL + ", D_TIPONOTIZIA B   ";
                SQL = SQL + "WHERE A.ID_TIPO=B.ID_TIPO   ";
                SQL = SQL + "AND A.FL_HOME=1   ";
                SQL = SQL + "AND A.DT_FINE IS NULL ";
                SQL = SQL + ") X   ";
                SQL = SQL + "LEFT JOIN   ";
                SQL = SQL + "(   ";
                SQL = SQL + "SELECT A.ID_FOTO   ";
                SQL = SQL + ", A.ID_NOTIZIA   ";
                SQL = SQL + ", B.TX_NOMEFILE   ";
                SQL = SQL + ", B.TX_DESCFOTO   ";
                SQL = SQL + "FROM R_FOTO_NOTIZIA A   ";
                SQL = SQL + ", E_FOTO B   ";
                SQL = SQL + "WHERE A.ID_FOTO=B.ID_FOTO   ";
                SQL = SQL + "AND A.FL_PRINCIPALE=1   ";
                SQL = SQL + ") Y   ";
                SQL = SQL + "ON X.ID_NOTIZIA=Y.ID_NOTIZIA  ";
                SQL = SQL + ") XX  ";
                SQL = SQL + "LEFT JOIN E_ALLEGATINEWS YY  ";
                SQL = SQL + "ON XX.ID_NOTIZIA = YY.ID_NOTIZIA   ";
                SQL = SQL + "ORDER BY DT_EVENTO DESC ";

            }




            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable TotNotizie()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {

                SQL = "SELECT XX.* ";
                SQL = SQL + ", YY.TX_NOMEFILE AS FILEALLEGATO ";
                SQL = SQL + ", YY.TX_DESCRIZIONE AS DESCALLEGATO ";
                SQL = SQL + "FROM ";
                SQL = SQL + "( ";
                SQL = SQL + "SELECT X.*  ";
                SQL = SQL + ", Y.ID_FOTO  ";
                SQL = SQL + ", Y.TX_NOMEFILE  ";
                SQL = SQL + ", Y.TX_DESCFOTO  ";
                SQL = SQL + "FROM  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT A.ID_NOTIZIA  ";
                SQL = SQL + ", DAY(A.DT_EVENTO) AS GIORNO_EVN ";
                SQL = SQL + ", MONTH(A.DT_EVENTO) AS MESE_EVN  ";
                SQL = SQL + ", YEAR(A.DT_EVENTO) AS ANNO_EVN  ";
                SQL = SQL + ", DATEDIFF(\"d\",A.DT_EVENTO,NOW(),2) AS DIFF   ";
                SQL = SQL + ", A.DT_INSERIMENTO  ";
                SQL = SQL + ", A.DT_EVENTO  ";
                SQL = SQL + ", A.ID_TIPO  ";
                SQL = SQL + ", B.DS_TIPO  ";
                SQL = SQL + ", A.DS_TITOLO  ";
                SQL = SQL + ", A.DS_SOTTOTITOLO  ";
                SQL = SQL + ", A.DS_DESCRIZIONE  ";
                SQL = SQL + ", A.FL_HOME  ";
                SQL = SQL + "FROM E_NOTIZIE A   ";
                SQL = SQL + ", D_TIPONOTIZIA B  ";
                SQL = SQL + "WHERE A.ID_TIPO=B.ID_TIPO  ";
                SQL = SQL + "AND A.DT_FINE IS NULL  ";
                SQL = SQL + ") X  ";
                SQL = SQL + "LEFT JOIN  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT A.ID_FOTO  ";
                SQL = SQL + ", A.ID_NOTIZIA  ";
                SQL = SQL + ", B.TX_NOMEFILE  ";
                SQL = SQL + ", B.TX_DESCFOTO  ";
                SQL = SQL + "FROM R_FOTO_NOTIZIA A  ";
                SQL = SQL + ", E_FOTO B  ";
                SQL = SQL + "WHERE A.ID_FOTO=B.ID_FOTO  ";
                SQL = SQL + "AND A.FL_PRINCIPALE=1  ";
                SQL = SQL + ") Y  ";
                SQL = SQL + "ON X.ID_NOTIZIA=Y.ID_NOTIZIA ";
                SQL = SQL + ") XX ";
                SQL = SQL + "LEFT JOIN E_ALLEGATINEWS YY ";
                SQL = SQL + "ON XX.ID_NOTIZIA = YY.ID_NOTIZIA  ";
                SQL = SQL + "ORDER BY DT_EVENTO DESC ";
            }
            else
            {
                SQL = "SELECT XX.*  ";
                SQL = SQL + ", YY.TX_NOMEFILE AS FILEALLEGATO  ";
                SQL = SQL + ", YY.TX_DESCRIZIONE AS DESCALLEGATO  ";
                SQL = SQL + "FROM  ";
                SQL = SQL + "(  ";
                SQL = SQL + "SELECT X.*   ";
                SQL = SQL + ", Y.ID_FOTO   ";
                SQL = SQL + ", Y.TX_NOMEFILE   ";
                SQL = SQL + ", Y.TX_DESCFOTO   ";
                SQL = SQL + "FROM   ";
                SQL = SQL + "(   ";
                SQL = SQL + "SELECT A.ID_NOTIZIA   ";
                SQL = SQL + ", DAY(A.DT_EVENTO) AS GIORNO_EVN   ";
                SQL = SQL + ", MONTH(A.DT_EVENTO) AS MESE_EVN   ";
                SQL = SQL + ", YEAR(A.DT_EVENTO) AS ANNO_EVN   ";
                SQL = SQL + ", DATEDIFF(CURDATE(),A.DT_EVENTO) AS DIFF    ";
                SQL = SQL + ", A.DT_INSERIMENTO   ";
                SQL = SQL + ", A.DT_EVENTO  ";
                SQL = SQL + ", A.ID_TIPO   ";
                SQL = SQL + ", B.DS_TIPO   ";
                SQL = SQL + ", A.DS_TITOLO   ";
                SQL = SQL + ", A.DS_SOTTOTITOLO   ";
                SQL = SQL + ", A.DS_DESCRIZIONE   ";
                SQL = SQL + ", A.FL_HOME  ";
                SQL = SQL + "FROM E_NOTIZIE A    ";
                SQL = SQL + ", D_TIPONOTIZIA B   ";
                SQL = SQL + "WHERE A.ID_TIPO=B.ID_TIPO   ";
                SQL = SQL + "AND A.DT_FINE IS NULL ";
                SQL = SQL + ") X   ";
                SQL = SQL + "LEFT JOIN   ";
                SQL = SQL + "(   ";
                SQL = SQL + "SELECT A.ID_FOTO   ";
                SQL = SQL + ", A.ID_NOTIZIA   ";
                SQL = SQL + ", B.TX_NOMEFILE   ";
                SQL = SQL + ", B.TX_DESCFOTO   ";
                SQL = SQL + "FROM R_FOTO_NOTIZIA A   ";
                SQL = SQL + ", E_FOTO B   ";
                SQL = SQL + "WHERE A.ID_FOTO=B.ID_FOTO   ";
                SQL = SQL + "AND A.FL_PRINCIPALE=1   ";
                SQL = SQL + ") Y   ";
                SQL = SQL + "ON X.ID_NOTIZIA=Y.ID_NOTIZIA  ";
                SQL = SQL + ") XX  ";
                SQL = SQL + "LEFT JOIN E_ALLEGATINEWS YY  ";
                SQL = SQL + "ON XX.ID_NOTIZIA = YY.ID_NOTIZIA   ";
                SQL = SQL + "ORDER BY DT_EVENTO DESC ";

            }




            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DettaglioNotizia(string id_notizia)
        {
            string SQL;

            SQL = "SELECT XX.* ";
            SQL = SQL + ", Z.TX_NOMEFILE AS  FILEALLEGATO ";
            SQL = SQL + ", Z.TX_DESCRIZIONE AS  DESCALLEGATO ";
            SQL = SQL + "FROM ";
            SQL = SQL + "( ";
            SQL = SQL + "SELECT X.*  ";
            SQL = SQL + ", Y.ID_FOTO  ";
            SQL = SQL + ", Y.TX_NOMEFILE  ";
            SQL = SQL + ", Y.TX_DESCFOTO  ";
            SQL = SQL + "FROM (  ";
            SQL = SQL + "SELECT A.ID_NOTIZIA  ";
            SQL = SQL + ", DAY(A.DT_EVENTO) AS GIORNO_EVN  ";
            SQL = SQL + ", MONTH(A.DT_EVENTO) AS MESE_EVN  ";
            SQL = SQL + ", YEAR(A.DT_EVENTO) AS ANNO_EVN  ";
            SQL = SQL + ", A.DT_INSERIMENTO  ";
            SQL = SQL + ", A.DT_EVENTO  ";
            SQL = SQL + ", A.ID_TIPO  ";
            SQL = SQL + ", B.DS_TIPO  ";
            SQL = SQL + ", A.DS_TITOLO  ";
            SQL = SQL + ", A.DS_SOTTOTITOLO  ";
            SQL = SQL + ", A.DS_DESCRIZIONE  ";
            SQL = SQL + ", A.FL_HOME  ";
            SQL = SQL + "FROM E_NOTIZIE A   ";
            SQL = SQL + ", D_TIPONOTIZIA B  ";
            SQL = SQL + "WHERE A.ID_TIPO=B.ID_TIPO  ";
            SQL = SQL + "AND A.ID_NOTIZIA=" + id_notizia;
            SQL = SQL + ") X  ";
            SQL = SQL + "LEFT JOIN  ";
            SQL = SQL + "(  ";
            SQL = SQL + "SELECT A.ID_FOTO  ";
            SQL = SQL + ", A.ID_NOTIZIA  ";
            SQL = SQL + ", B.TX_NOMEFILE  ";
            SQL = SQL + ", B.TX_DESCFOTO  ";
            SQL = SQL + "FROM R_FOTO_NOTIZIA A  ";
            SQL = SQL + ", E_FOTO B  ";
            SQL = SQL + "WHERE A.ID_FOTO=B.ID_FOTO  ";
            SQL = SQL + "AND A.FL_PRINCIPALE=1  ";
            SQL = SQL + ") Y  ";
            SQL = SQL + "ON X.ID_NOTIZIA=Y.ID_NOTIZIA ";
            SQL = SQL + ") XX ";
            SQL = SQL + "LEFT JOIN ";
            SQL = SQL + "E_ALLEGATINEWS Z ";
            SQL = SQL + "ON XX.ID_NOTIZIA=Z.ID_NOTIZIA ";
            SQL = SQL + " ORDER BY DT_EVENTO DESC ";




            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable AnniNews()
        {
            string SQL;

            SQL = "SELECT * FROM (SELECT 9999 AS ANNO_EVN FROM DUAL UNION SELECT DISTINCT YEAR(DT_EVENTO) AS ANNO_EVN FROM E_NOTIZIE) A ORDER BY ANNO_EVN DESC ";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion


        public DataTable Link()
        {
            string SQL;

            SQL = "SELECT ID_LINK,TX_DESCRIZIONE,TX_LINK FROM E_LINK ";
            SQL = SQL + " ORDER BY NR_ORDINE ";



            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable Consiglio()
        {
            string SQL;

            SQL = "SELECT E_CONSIGLIO.ID_SOCIO ";
            SQL = SQL + ", E_Soci.Nome ";
            SQL = SQL + ", E_Soci.Cognome ";
            SQL = SQL + ", E_CONSIGLIO.ID_STRUTTURA ";
            SQL = SQL + ", D_STRUTTURE.DS_STRUTTURA ";
            SQL = SQL + ", E_CONSIGLIO.ID_CARICA ";
            SQL = SQL + ", D_CARICHE.DS_CARICA ";
            SQL = SQL + ", E_CONSIGLIO.NUM_VOTI ";
            SQL = SQL + ", E_CONSIGLIO.TX_RESPONSABILITA ";
            SQL = SQL + "FROM D_STRUTTURE  ";
            SQL = SQL + " INNER JOIN  ";
            SQL = SQL + " (D_CARICHE  ";
            SQL = SQL + " INNER JOIN  ";
            SQL = SQL + " (E_CONSIGLIO INNER JOIN E_Soci ON E_CONSIGLIO.ID_SOCIO = E_Soci.NSocio)  ";
            SQL = SQL + " ON (E_CONSIGLIO.ID_STRUTTURA = D_CARICHE.ID_STRUTTURA) AND (D_CARICHE.ID_CARICA = E_CONSIGLIO.ID_CARICA) ";
            SQL = SQL + " )  ";
            SQL = SQL + " ON D_STRUTTURE.ID_STRUTTURA = E_CONSIGLIO.ID_STRUTTURA ";


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable GetLogin(string tx_socio, string tx_cf)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT A.NSocio  ";
                SQL = SQL + ", A.Nome  ";
                SQL = SQL + ", A.Cognome  ";
                SQL = SQL + ", IIF(b.ID_LIVELLO IS NULL,0,b.ID_LIVELLO) AS LIVELLO  ";
                SQL = SQL + "FROM E_SOCI A LEFT JOIN E_AMMSITO B ON A.NSocio=B.ID_SOCIO  ";
                SQL = SQL + "WHERE A.NSocio=" + tx_socio.Trim() + " ";
                SQL = SQL + "AND A.CodFiscale='" + tx_cf.Trim() + "'";
            }
            else
            {
                SQL = "SELECT A.NSocio  ";
                SQL = SQL + ", A.Nome  ";
                SQL = SQL + ", A.Cognome  ";
                SQL = SQL + ", COALESCE(B.ID_LIVELLO,0) AS LIVELLO  ";
                SQL = SQL + "FROM E_Soci A LEFT JOIN E_AMMSITO B ON A.NSocio=B.ID_SOCIO  ";
                SQL = SQL + "WHERE A.NSocio=" + tx_socio.Trim() + " ";
                SQL = SQL + "AND A.CodFiscale='" + tx_cf.Trim() + "'";
            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable AggregatiDonatori()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT 1 as TIPOAGG ";
                SQL = SQL + ", GRUPPO  ";
                SQL = SQL + ", RH  ";
                SQL = SQL + ", COUNT(*) as num  ";
                SQL = SQL + ", SUM(IIF(SESSO='F',1,0)) AS DONNE  ";
                SQL = SQL + ", SUM(IIF(SESSO='M',1,0)) AS UOMINI  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT NSocio  ";
                SQL = SQL + ", IIF(GruppoSanguigno IS NULL,'NC',GruppoSanguigno) AS GRUPPO  ";
                SQL = SQL + ", IIF(RH1='+','Pos',IIF(RH1='-','Neg',RH1)) as RH  ";
                SQL = SQL + ", IIF(GIORNO =0,'N',IIF(GIORNO>31,'F','M')) AS SESSO  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT a.NSocio,A.GruppoSanguigno,IIF(A.RH IS NULL,'NC',A.RH) as RH1  ";
                SQL = SQL + ", CINT(MID(IIF(b.CodFiscale IS NULL,'0000000000000000',b.CodFiscale),10,2)) as GIORNO  ";
                SQL = SQL + "FROM E_Donatori A left join E_Soci B on a.NSocio=b.NSocio  ";
                SQL = SQL + "WHERE A.DataFineDon Is Null  ";
                SQL = SQL + ")  ";
                SQL = SQL + ")  ";
                SQL = SQL + "GROUP BY GRUPPO, RH  ";
                SQL = SQL + "order by GRUPPO  ";
                SQL = SQL + "UNION ALL  ";
                SQL = SQL + "SELECT 2 as TIPOAGG ";
                SQL = SQL + ", 'TOTALE' AS GRUPPO  ";
                SQL = SQL + ", NULL AS RH  ";
                SQL = SQL + ", COUNT(*) as num  ";
                SQL = SQL + ", SUM(IIF(SESSO='F',1,0)) AS DONNE  ";
                SQL = SQL + ", SUM(IIF(SESSO='M',1,0)) AS UOMINI  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT NSocio  ";
                SQL = SQL + ", IIF(GIORNO =0,'N',IIF(GIORNO>31,'F','M')) AS SESSO  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT a.NSocio,A.GruppoSanguigno,IIF(A.RH IS NULL,'NC',A.RH) as RH1  ";
                SQL = SQL + ", CINT(MID(IIF(b.CodFiscale IS NULL,'0000000000000000',b.CodFiscale),10,2)) as GIORNO  ";
                SQL = SQL + "FROM E_Donatori A left join E_Soci B on a.NSocio=b.NSocio  ";
                SQL = SQL + "WHERE A.DataFineDon Is Null  ";
                SQL = SQL + ")  ";
                SQL = SQL + ") ";
            }
            else
            {
                SQL = "SELECT 1 as TIPOAGG   ";
                SQL = SQL + ", GRUPPO    ";
                SQL = SQL + ", RH    ";
                SQL = SQL + ", COUNT(*) as NUM    ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='F' THEN 1 ELSE 0 END) AS DONNE    ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='M' THEN 1 ELSE 0 END) AS UOMINI    ";
                SQL = SQL + "FROM (    ";
                SQL = SQL + "SELECT NSocio    ";
                SQL = SQL + ", GRUPPO    ";
                SQL = SQL + ", CASE WHEN RH1='+' THEN 'Pos'  ";
                SQL = SQL + "       WHEN RH1='-' THEN 'Neg'  ";
                SQL = SQL + "       ELSE RH1  ";
                SQL = SQL + "  END as RH    ";
                SQL = SQL + ", CASE WHEN GIORNO =0 THEN 'N'  ";
                SQL = SQL + "       WHEN GIORNO>31 THEN 'F'  ";
                SQL = SQL + "       WHEN GIORNO>0 AND GIORNO<=31 THEN 'M'  ";
                SQL = SQL + "  END AS SESSO    ";
                SQL = SQL + "FROM (    ";
                SQL = SQL + "SELECT A.NSocio  ";
                SQL = SQL + ", CASE WHEN A.GruppoSanguigno IS NULL OR A.GruppoSanguigno='' THEN 'NC' ELSE A.GruppoSanguigno END AS GRUPPO  ";
                SQL = SQL + ", CASE WHEN A.RH IS NULL OR A.RH='' THEN 'NC' ELSE A.RH END AS RH1  ";
                SQL = SQL + ", CONVERT( SUBSTRING( CASE WHEN B.CodFiscale IS NULL OR B.CodFiscale='' THEN '0000000000000000' ELSE B.CodFiscale END , 10, 2 ) , SIGNED ) AS GIORNO  ";
                SQL = SQL + "FROM E_Donatori A  ";
                SQL = SQL + "LEFT JOIN E_Soci B ON A.NSocio = B.NSocio  ";
                SQL = SQL + "WHERE (A.DataFineDon Is Null OR A.DataFineDon = DATE('0000-00-00')) ";
                SQL = SQL + ") A ";
                SQL = SQL + ") AA ";
                SQL = SQL + "GROUP BY GRUPPO, RH    ";
                SQL = SQL + "UNION   ";
                SQL = SQL + "SELECT 2 as TIPOAGG   ";
                SQL = SQL + ", 'TOTALE' AS GRUPPO    ";
                SQL = SQL + ", NULL AS RH    ";
                SQL = SQL + ", COUNT(*) as NUM    ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='F' THEN 1 ELSE 0 END) AS DONNE    ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='M' THEN 1 ELSE 0 END) AS UOMINI   ";
                SQL = SQL + "FROM (    ";
                SQL = SQL + "SELECT NSocio    ";
                SQL = SQL + ", CASE WHEN GIORNO =0 THEN 'N'  ";
                SQL = SQL + "       WHEN GIORNO>31 THEN 'F'  ";
                SQL = SQL + "       WHEN GIORNO>0 AND GIORNO<=31 THEN 'M'  ";
                SQL = SQL + "  END AS SESSO    ";
                SQL = SQL + "FROM (    ";
                SQL = SQL + "SELECT A.NSocio  ";
                SQL = SQL + ", CASE WHEN A.GruppoSanguigno IS NULL OR A.GruppoSanguigno='' THEN 'NC' ELSE A.GruppoSanguigno END AS GRUPPO  ";
                SQL = SQL + ", CASE WHEN A.RH IS NULL OR A.RH='' THEN 'NC' ELSE A.RH END AS RH1  ";
                SQL = SQL + ", CONVERT( SUBSTRING( CASE WHEN B.CodFiscale IS NULL OR B.CodFiscale='' THEN '0000000000000000' ELSE B.CodFiscale END , 10, 2 ) , SIGNED ) AS GIORNO   ";
                SQL = SQL + "FROM E_Donatori A left join E_Soci B on A.NSocio=B.NSocio    ";
                SQL = SQL + "WHERE (A.DataFineDon Is Null OR A.DataFineDon = DATE('0000-00-00'))  ";
                SQL = SQL + ") A ";
                SQL = SQL + ") AA ";
                SQL = SQL + "GROUP BY GRUPPO, RH ";

            }

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable AggregatiVolontari()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT TipoVol ";
                SQL = SQL + ", COUNT(*) AS TOT ";
                SQL = SQL + ", SUM(IIF(SESSO='F',1,0)) AS DONNE ";
                SQL = SQL + ", SUM(IIF(SESSO='M',1,0)) AS UOMINI ";
                SQL = SQL + "FROM ( ";
                SQL = SQL + "SELECT A.NVolInt ";
                SQL = SQL + ", B.TipoVol ";
                SQL = SQL + ", IIF(C.GIORNO =0,'N',IIF(C.GIORNO>31,'F','M')) AS SESSO ";
                SQL = SQL + "FROM E_VolAttivita A ";
                SQL = SQL + ", E_TipoVolontariato B ";
                SQL = SQL + ", ( ";
                SQL = SQL + "   SELECT NumVolontario ";
                SQL = SQL + "   ,DataFineIscrizione ";
                SQL = SQL + "   ,CINT(MID(IIF(CodFiscale IS NULL,'0000000000000000',CodFiscale),10,2)) as GIORNO ";
                SQL = SQL + "   FROM E_Soci  ";
                SQL = SQL + "  ) C ";
                SQL = SQL + "WHERE A.CodVol=B.CodVol ";
                SQL = SQL + "AND A.DataFineVolAtt IS NULL ";
                SQL = SQL + "AND A.NVolInt=C.NumVolontario ";
                SQL = SQL + "AND C.DataFineIscrizione is null ";
                SQL = SQL + ") ";
                SQL = SQL + "GROUP BY TipoVol ";
            }
            else
            {
                SQL = "SELECT TipoVol  ";
                SQL = SQL + ", COUNT(*) AS TOT  ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='F' THEN 1 ELSE 0 END) AS DONNE   ";
                SQL = SQL + ", SUM(CASE WHEN SESSO='M' THEN 1 ELSE 0 END) AS UOMINI ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT A.NVolInt  ";
                SQL = SQL + ", B.TipoVol  ";
                SQL = SQL + ", CASE WHEN C.GIORNO =0 THEN 'N' ";
                SQL = SQL + "       WHEN C.GIORNO>31 THEN 'F' ";
                SQL = SQL + "       WHEN C.GIORNO>0 AND GIORNO<=31 THEN 'M' ";
                SQL = SQL + "  END AS SESSO  ";
                SQL = SQL + "FROM E_VolAttivita A  ";
                SQL = SQL + ", D_TipoVolontariato B  ";
                SQL = SQL + ", (  ";
                SQL = SQL + "   SELECT NumVolontario  ";
                SQL = SQL + "   ,DataFineIscrizione  ";
                SQL = SQL + "   ,CONVERT( SUBSTRING( CASE WHEN CodFiscale IS NULL OR CodFiscale='' THEN '0000000000000000' ELSE CodFiscale END , 10, 2 ) , SIGNED ) AS GIORNO  ";
                SQL = SQL + "   FROM E_Soci   ";
                SQL = SQL + "  ) C  ";
                SQL = SQL + "WHERE A.CodVol=B.CodVol  ";
                SQL = SQL + "AND (A.DataFineVolAtt IS NULL OR A.DataFineVolAtt=DATE('0000-00-00')) ";
                SQL = SQL + "AND A.NVolInt=C.NumVolontario  ";
                SQL = SQL + "AND (C.DataFineIscrizione is null OR C.DataFineIscrizione=DATE('0000-00-00')) ";
                SQL = SQL + ") AM ";
                SQL = SQL + "GROUP BY TipoVol ";
            }

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string EtaMediaDonatori()
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT ROUND(TOTETA/NUM,0) AS MEDIA FROM ( ";
                SQL = SQL + "SELECT COUNT(*) AS NUM,SUM(ETA) AS TOTETA FROM ( ";
                SQL = SQL + "SELECT a.Nsocio,b.DataNascita,DATEDIFF(\"yyyy\",b.DataNascita,NOW(),2) AS ETA ";
                SQL = SQL + "FROM E_Donatori A left join E_Soci B on a.NSocio=b.NSocio   ";
                SQL = SQL + "WHERE A.DataFineDon Is Null)) ";
            }
            else
            {
                SQL = "SELECT ROUND(TOTETA/NUM,0) AS MEDIA  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT COUNT(*) AS NUM ";
                SQL = SQL + ",SUM(ETA) AS TOTETA  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT A.Nsocio,B.DataNascita ";
                SQL = SQL + ",EXTRACT(YEAR FROM CURDATE())- EXTRACT(YEAR FROM B.DataNascita) AS ETA  ";
                SQL = SQL + "FROM E_Donatori A left join E_Soci B on A.NSocio=B.NSocio    ";
                SQL = SQL + "WHERE (A.DataFineDon Is Null OR A.DataFineDon=DATE('0000-00-00')) ";
                SQL = SQL + ") A ";
                SQL = SQL + ") AA ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MEDIA"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string MediaDonazioni(int num_anni)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ROUND((SUM(NUM)/" + num_anni.ToString() + "),0) AS MEDIA FROM ( ";
            SQL = SQL + "SELECT Year(DataDonazione) as ANNO ";
            SQL = SQL + ", count(*) as NUM ";
            SQL = SQL + "from E_Donazioni ";
            SQL = SQL + "WHERE Year(DataDonazione)>=(Year(Now())-" + num_anni.ToString() + ") ";
            SQL = SQL + "AND Year(DataDonazione)<Year(Now()) ";
            SQL = SQL + "group by Year(DataDonazione) ";
            SQL = SQL + ") A ";


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MEDIA"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DonazioniUltimiAnni()
        {
            string SQL;
            int numanni = 3;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT 1 AS TIPOAGG   ";
                SQL = SQL + ", GRUPPO  ";
                SQL = SQL + ", IIF(RH1='+','Pos',IIF(RH1='-','Neg',RH1)) as RH  ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-1,NUM,0)) AS  _" + (DateTime.Now.Year - 1).ToString() + "  ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-2,NUM,0)) AS  _" + (DateTime.Now.Year - 2).ToString() + " ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-3,NUM,0)) AS  _" + (DateTime.Now.Year - 3).ToString() + " ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT Year(DataDonazione) as ANNO  ";
                SQL = SQL + ", IIF(B.GruppoSanguigno IS NULL,'NC',GruppoSanguigno) AS GRUPPO   ";
                SQL = SQL + ", IIF(B.RH IS NULL,'NC',B.RH) AS RH1  ";
                SQL = SQL + ", count(*) as NUM   ";
                SQL = SQL + "from E_Donazioni A  ";
                SQL = SQL + ", E_Donatori B  ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio   ";
                SQL = SQL + "AND Year(A.DataDonazione)>=(Year(Now())-" + numanni.ToString() + ")   ";
                SQL = SQL + "AND Year(A.DataDonazione)<Year(Now())   ";
                SQL = SQL + "group by Year(A.DataDonazione),IIF(B.GruppoSanguigno IS NULL,'NC',GruppoSanguigno) , IIF(B.RH IS NULL,'NC',B.RH)  ";
                SQL = SQL + ")  ";
                SQL = SQL + "GROUP BY GRUPPO, IIF(RH1='+','Pos',IIF(RH1='-','Neg',RH1))  ";
                SQL = SQL + "UNION ALL ";
                SQL = SQL + "SELECT 2 AS TIPOAGG   ";
                SQL = SQL + ", 'TOTALE' as GRUPPO  ";
                SQL = SQL + ", NULL as RH  ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-1,NUM,0)) AS  _" + (DateTime.Now.Year - 1).ToString() + "  ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-2,NUM,0)) AS  _" + (DateTime.Now.Year - 2).ToString() + " ";
                SQL = SQL + ", SUM(IIF(ANNO=Year(Now())-3,NUM,0)) AS  _" + (DateTime.Now.Year - 3).ToString() + " ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT Year(DataDonazione) as ANNO  ";
                SQL = SQL + ", count(*) as NUM   ";
                SQL = SQL + "from E_Donazioni A  ";
                SQL = SQL + ", E_Donatori B  ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio   ";
                SQL = SQL + "AND Year(A.DataDonazione)>=(Year(Now())-" + numanni.ToString() + ")   ";
                SQL = SQL + "AND Year(A.DataDonazione)<Year(Now())   ";
                SQL = SQL + "group by Year(A.DataDonazione) ";
                SQL = SQL + ") ";
            }
            else
            {
                SQL = "SELECT 1 AS TIPOAGG    ";
                SQL = SQL + ", GRUPPO   ";
                SQL = SQL + ", CASE WHEN RH1='+' THEN 'Pos'  ";
                SQL = SQL + "       WHEN RH1='-' THEN 'Neg'  ";
                SQL = SQL + "       ELSE RH1  ";
                SQL = SQL + "  END as RH ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-1) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 1).ToString() + "  ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-2) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 2).ToString() + " ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-3) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 3).ToString() + " ";
                SQL = SQL + "FROM (   ";
                SQL = SQL + "SELECT Year(DataDonazione) as ANNO   ";
                SQL = SQL + ", CASE WHEN B.GruppoSanguigno IS NULL OR B.GruppoSanguigno='' THEN 'NC' ELSE B.GruppoSanguigno END AS GRUPPO   ";
                SQL = SQL + ", CASE WHEN B.RH IS NULL OR B.RH='' THEN 'NC' ELSE B.RH END AS RH1  ";
                SQL = SQL + ", count(*) as NUM    ";
                SQL = SQL + "from E_Donazioni A   ";
                SQL = SQL + ", E_Donatori B   ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio    ";
                SQL = SQL + "AND Year(A.DataDonazione)>=(Year(CURDATE())-" + numanni.ToString() + " )    ";
                SQL = SQL + "AND Year(A.DataDonazione)<Year(CURDATE())    ";
                SQL = SQL + "group by Year(A.DataDonazione) ";
                SQL = SQL + ",CASE WHEN B.GruppoSanguigno IS NULL OR B.GruppoSanguigno='' THEN 'NC' ELSE B.GruppoSanguigno END  ";
                SQL = SQL + ", CASE WHEN B.RH IS NULL OR B.RH='' THEN 'NC' ELSE B.RH END   ";
                SQL = SQL + ") X   ";
                SQL = SQL + "GROUP BY GRUPPO ";
                SQL = SQL + ", CASE WHEN RH1='+' THEN 'Pos'  ";
                SQL = SQL + "       WHEN RH1='-' THEN 'Neg'  ";
                SQL = SQL + "       ELSE RH1  ";
                SQL = SQL + "  END ";
                SQL = SQL + "UNION ALL  ";
                SQL = SQL + "SELECT 2 AS TIPOAGG    ";
                SQL = SQL + ", 'TOTALE' as GRUPPO   ";
                SQL = SQL + ", NULL as RH   ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-1) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 1).ToString() + "  ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-2) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 2).ToString() + " ";
                SQL = SQL + ", SUM(CASE WHEN ANNO=(Year(CURDATE())-3) THEN NUM ELSE 0 END) AS _" + (DateTime.Now.Year - 3).ToString() + " ";
                SQL = SQL + "FROM (   ";
                SQL = SQL + "SELECT Year(DataDonazione) as ANNO   ";
                SQL = SQL + ", count(*) as NUM    ";
                SQL = SQL + "from E_Donazioni A   ";
                SQL = SQL + ", E_Donatori B   ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio    ";
                SQL = SQL + "AND Year(A.DataDonazione)>=(Year(CURDATE())-" + numanni.ToString() + ")    ";
                SQL = SQL + "AND Year(A.DataDonazione)<Year(CURDATE())    ";
                SQL = SQL + "group by Year(A.DataDonazione)  ";
                SQL = SQL + ") X ";
            }




            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable Giornalini()
        {
            string SQL;

            SQL = "SELECT DT_CARICAMENTO ";
            SQL = SQL + ", NUM_ANNO ";
            SQL = SQL + ", NUM_NUMERO ";
            SQL = SQL + ", TX_TITOLO ";
            SQL = SQL + ", TX_FILE ";
            SQL = SQL + ", FL_VISIBILE ";
            SQL = SQL + "FROM E_GIORNALINO ";
            SQL = SQL + "WHERE FL_VISIBILE=1 ";
            SQL = SQL + "ORDER BY NUM_ANNO DESC,NUM_NUMERO DESC ";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string TotSoci()
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT COUNT(*) AS TOT FROM E_Soci WHERE DataFineIscrizione IS NULL";
            }
            else
            {
                SQL = "SELECT COUNT(*) AS TOT FROM E_Soci WHERE (DataFineIscrizione IS NULL OR DataFineIscrizione=DATE('0000-00-00'))";

            }
            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TOT"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public string TotDonatori()
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT COUNT(*) AS TOT FROM E_Donatori WHERE DataFineDon IS NULL";
            }
            else
            {
                SQL = "SELECT COUNT(*) AS TOT FROM E_Donatori WHERE (DataFineDon IS NULL OR DataFineDon=DATE('0000-00-00'))";
            }

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TOT"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public string TotVolontari()
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT COUNT(*) AS TOT ";
                SQL = SQL + "FROM E_Volontari A ";
                SQL = SQL + ", E_Soci B ";
                SQL = SQL + ", (SELECT DISTINCT NVolInt FROM E_VolAttivita WHERE DataFineVolAtt Is Null) C ";
                SQL = SQL + "WHERE A.VolNsocio=B.NSocio ";
                SQL = SQL + "AND A.NumVolontario=B.NumVolontario ";
                SQL = SQL + "AND A.NumVolontario=C.NVolInt  ";
                SQL = SQL + "AND A.DataFineVol IS NULL ";
                SQL = SQL + "AND B.DataFineIscrizione IS NULL ";
            }
            else
            {
                SQL = "SELECT COUNT(*) AS TOT ";
                SQL = SQL + "FROM E_Volontari A ";
                SQL = SQL + ", E_Soci B ";
                SQL = SQL + ", (SELECT DISTINCT NVolInt FROM E_VolAttivita WHERE (DataFineVolAtt Is Null OR DataFineVolAtt=DATE('0000-00-00'))) C ";
                SQL = SQL + "WHERE A.VolNsocio=B.NSocio ";
                SQL = SQL + "AND A.NumVolontario=B.NumVolontario ";
                SQL = SQL + "AND A.NumVolontario=C.NVolInt  ";
                SQL = SQL + "AND (A.DataFineVol IS NULL OR A.DataFineVol=DATE('0000-00-00')) ";
                SQL = SQL + "AND (B.DataFineIscrizione IS NULL OR B.DataFineIscrizione=DATE('0000-00-00')) ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TOT"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        #region QUERY GALLERY

        public DataTable TipiAlbum()
        {
            string SQL;

            SQL = "SELECT ID_TIPO_ALBUM ";
            SQL = SQL + ", TX_TIPO_ALBUM ";
            SQL = SQL + "FROM E_ALBUM_TIPO ";
            SQL = SQL + "ORDER BY ID_TIPO_ALBUM ";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable TipiAlbumAdmin()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT A.ID_TIPO_ALBUM  ";
                SQL = SQL + ", A.TX_TIPO_ALBUM ";
                SQL = SQL + ", IIF(B.NUM_ALBUM IS NULL,0,B.NUM_ALBUM) AS N_ALBUM ";
                SQL = SQL + "FROM E_ALBUM_TIPO A  ";
                SQL = SQL + " LEFT JOIN  ";
                SQL = SQL + " ( ";
                SQL = SQL + " SELECT ID_TIPO_ALBUM  ";
                SQL = SQL + " , COUNT(*) AS NUM_ALBUM ";
                SQL = SQL + " FROM E_ALBUM ";
                SQL = SQL + " GROUP BY ID_TIPO_ALBUM  ";
                SQL = SQL + " ) B ";
                SQL = SQL + " ON A.ID_TIPO_ALBUM=B.ID_TIPO_ALBUM ";
            }
            else
            {
                SQL = "SELECT A.ID_TIPO_ALBUM  ";
                SQL = SQL + ", A.TX_TIPO_ALBUM ";
                SQL = SQL + ", CASE WHEN B.NUM_ALBUM IS NULL THEN 0 ELSE B.NUM_ALBUM END AS N_ALBUM ";
                SQL = SQL + "FROM E_ALBUM_TIPO A  ";
                SQL = SQL + " LEFT JOIN  ";
                SQL = SQL + " ( ";
                SQL = SQL + " SELECT ID_TIPO_ALBUM  ";
                SQL = SQL + " , COUNT(*) AS NUM_ALBUM ";
                SQL = SQL + " FROM E_ALBUM ";
                SQL = SQL + " GROUP BY ID_TIPO_ALBUM  ";
                SQL = SQL + " ) B ";
                SQL = SQL + " ON A.ID_TIPO_ALBUM=B.ID_TIPO_ALBUM ";

            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable AlbumAdmin(string tipo)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT A.ID_ALBUM   ";
                SQL = SQL + ", A.TX_ALBUM  ";
                SQL = SQL + ", IIF(B.NUM_FOTO IS NULL,0,B.NUM_FOTO) AS N_FOTO ";
                SQL = SQL + "FROM E_ALBUM A   ";
                SQL = SQL + " LEFT JOIN   ";
                SQL = SQL + " (  ";
                SQL = SQL + " SELECT ID_ALBUM  ";
                SQL = SQL + " , COUNT(*) AS NUM_FOTO  ";
                SQL = SQL + " FROM E_ALBUM_FOTO  ";
                SQL = SQL + " GROUP BY ID_ALBUM    ";
                SQL = SQL + " ) B  ";
                SQL = SQL + " ON A.ID_ALBUM =B.ID_ALBUM  ";
                SQL = SQL + "WHERE A.ID_TIPO_ALBUM= " + tipo;

            }
            else
            {
                SQL = "SELECT A.ID_ALBUM   ";
                SQL = SQL + ", A.TX_ALBUM  ";
                SQL = SQL + ", CASE WHEN B.NUM_FOTO IS NULL THEN 0 ELSE B.NUM_FOTO END AS N_FOTO ";
                SQL = SQL + "FROM E_ALBUM A   ";
                SQL = SQL + " LEFT JOIN   ";
                SQL = SQL + " (  ";
                SQL = SQL + " SELECT ID_ALBUM  ";
                SQL = SQL + " , COUNT(*) AS NUM_FOTO  ";
                SQL = SQL + " FROM E_ALBUM_FOTO  ";
                SQL = SQL + " GROUP BY ID_ALBUM    ";
                SQL = SQL + " ) B  ";
                SQL = SQL + " ON A.ID_ALBUM =B.ID_ALBUM  ";
                SQL = SQL + "WHERE A.ID_TIPO_ALBUM= " + tipo;


            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string NomeTipo(string tipo)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_TIPO_ALBUM ";
            SQL = SQL + ", TX_TIPO_ALBUM ";
            SQL = SQL + "FROM E_ALBUM_TIPO ";
            SQL = SQL + "WHERE ID_TIPO_ALBUM = " + tipo;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TX_TIPO_ALBUM"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string NomeAlbum(string album)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_ALBUM ";
            SQL = SQL + ", ID_TIPO_ALBUM ";
            SQL = SQL + ", TX_ALBUM ";
            SQL = SQL + "FROM E_ALBUM ";
            SQL = SQL + "WHERE ID_ALBUM = " + album;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TX_ALBUM"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string TipoAlbum(string album)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_ALBUM ";
            SQL = SQL + ", ID_TIPO_ALBUM ";
            SQL = SQL + ", TX_ALBUM ";
            SQL = SQL + "FROM E_ALBUM ";
            SQL = SQL + "WHERE ID_ALBUM = " + album;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_TIPO_ALBUM"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Album(string foto)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_FOTO ";
            SQL = SQL + ", ID_ALBUM ";
            SQL = SQL + ", TX_NOMEFILE ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_FOTO = " + foto;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_ALBUM"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Nomefile(string foto)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_FOTO ";
            SQL = SQL + ", ID_ALBUM ";
            SQL = SQL + ", TX_NOMEFILE ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_FOTO = " + foto;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TX_NOMEFILE"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Ordine(string foto)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_FOTO ";
            SQL = SQL + ", ID_ALBUM ";
            SQL = SQL + ", NM_ORDINE ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_FOTO = " + foto;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["NM_ORDINE"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public int NumFoto(string album)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT COUNT(*) AS NUM ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_ALBUM = " + album;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["NUM"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string FotoSucc(string ordine, string album)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_FOTO AS SUCC ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE NM_ORDINE = (SELECT MIN(NM_ORDINE) FROM E_ALBUM_FOTO WHERE NM_ORDINE> " + ordine + " AND ID_ALBUM = " + album + ")";
            SQL = SQL + " AND ID_ALBUM = " + album;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["SUCC"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string FotoPrec(string ordine, string album)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_FOTO AS PREC ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE NM_ORDINE = (SELECT MAX(NM_ORDINE) FROM E_ALBUM_FOTO WHERE NM_ORDINE< " + ordine + " AND ID_ALBUM = " + album + ")";
            SQL = SQL + " AND ID_ALBUM = " + album;


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["PREC"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable ElencoAlbum(string tipo)
        {
            string SQL;

            SQL = "SELECT X.ID_ALBUM ";
            SQL = SQL + ", X.ID_TIPO_ALBUM ";
            SQL = SQL + ", X.TX_TIPO_ALBUM ";
            SQL = SQL + ", X.TX_ALBUM ";
            SQL = SQL + ", Y.ID_FOTO ";
            SQL = SQL + ", Y.TX_NOMEFILE ";
            SQL = SQL + ", Y.TX_TITOLO ";
            SQL = SQL + "FROM ( ";
            SQL = SQL + "SELECT A.ID_ALBUM ";
            SQL = SQL + ", A.ID_TIPO_ALBUM ";
            SQL = SQL + ", B.TX_TIPO_ALBUM ";
            SQL = SQL + ", A.TX_ALBUM ";
            SQL = SQL + "FROM E_ALBUM A ";
            SQL = SQL + ", E_ALBUM_TIPO B ";
            SQL = SQL + "WHERE A.ID_TIPO_ALBUM=B.ID_TIPO_ALBUM ";
            SQL = SQL + "AND A.ID_TIPO_ALBUM=" + tipo + " ";
            SQL = SQL + ") X ";
            SQL = SQL + ",( ";
            SQL = SQL + "SELECT A.ID_ALBUM ";
            SQL = SQL + ", A.ID_FOTO ";
            SQL = SQL + ", A.TX_NOMEFILE ";
            SQL = SQL + ", A.TX_TITOLO ";
            SQL = SQL + "FROM E_ALBUM_FOTO A ";
            SQL = SQL + "WHERE NM_ORDINE=1 ";
            SQL = SQL + ") Y ";
            SQL = SQL + "WHERE X.ID_ALBUM=Y.ID_ALBUM ";


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable ElencoFoto(string album)
        {
            string SQL;

            SQL = "SELECT ID_FOTO ";
            SQL = SQL + ", ID_ALBUM ";
            SQL = SQL + ", TX_NOMEFILE ";
            SQL = SQL + ", TX_TITOLO ";
            SQL = SQL + ", NM_ORDINE ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_ALBUM= " + album;
            SQL = SQL + " ORDER BY NM_ORDINE ";



            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable Foto(string foto)
        {
            string SQL;

            SQL = "SELECT ID_FOTO ";
            SQL = SQL + ", ID_ALBUM ";
            SQL = SQL + ", TX_NOMEFILE ";
            SQL = SQL + ", TX_TITOLO ";
            SQL = SQL + ", TX_DESCRIZIONE ";
            SQL = SQL + ", NM_ORDINE ";
            SQL = SQL + "FROM E_ALBUM_FOTO ";
            SQL = SQL + "WHERE ID_FOTO= " + foto;



            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string ProxIDTipoAlbum()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_TIPO_ALBUM ";
                SQL = SQL + "FROM ( SELECT MAX(ID_TIPO_ALBUM) AS ULTIMA FROM E_ALBUM_TIPO ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_TIPO_ALBUM  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_TIPO_ALBUM) AS ULTIMA FROM E_ALBUM_TIPO ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_TIPO_ALBUM"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string ProxIDAlbum()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_ALBUM ";
                SQL = SQL + "FROM ( SELECT MAX(ID_ALBUM) AS ULTIMA FROM E_ALBUM ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_ALBUM  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_ALBUM) AS ULTIMA FROM E_ALBUM ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_ALBUM"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string ProxIDFotoGallery()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_FOTO ";
                SQL = SQL + "FROM ( SELECT MAX(ID_FOTO) AS ULTIMA FROM E_ALBUM_FOTO ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_FOTO  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_FOTO) AS ULTIMA FROM E_ALBUM_FOTO ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_FOTO"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InserisciTipoAlbum(string id_tipo, string descrizione)
        {
            string SQL;

            SQL = "INSERT INTO E_ALBUM_TIPO ";
            SQL = SQL + "SELECT " + id_tipo + " AS ID_TIPO_ALBUM ";
            SQL = SQL + ",'" + descrizione.Replace("'", "`") + "' AS TX_TIPO_ALBUM ";
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

        public void incassoTesseraSocio(String idSocio, String imTessera)
        {
            string SQL;

            SQL = "INSERT INTO E_QUOTE ";
            SQL = SQL + "values (" + idSocio + ",CURRENT_DATE,'PAYPAL'," + imTessera + ")";


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void InserisciAlbum(string id_tipo, string id_album, string descrizione)
        {
            string SQL;

            SQL = "INSERT INTO E_ALBUM ";
            SQL = SQL + "SELECT " + id_album + " AS ID_ALBUM ";
            SQL = SQL + ", " + id_tipo + " AS ID_TIPO_ALBUM ";
            SQL = SQL + ",'" + descrizione.Replace("'", "`") + "' AS TX_ALBUM ";
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

        public void InserisciFotoGallery(string id_album, string id_foto, string nomefile, string titolo, string descrizione, string ordine)
        {
            string SQL;

            SQL = "INSERT INTO E_ALBUM_FOTO ";
            SQL = SQL + "SELECT " + id_foto + " AS ID_FOTO ";
            SQL = SQL + ", " + id_album + " AS ID_ALBUM ";
            SQL = SQL + ",'" + nomefile.Replace("'", "`") + "' AS TX_NOMEFILE ";
            SQL = SQL + ",'" + titolo.Replace("'", "`") + "' AS TX_TITOLO ";
            SQL = SQL + ",'" + descrizione.Replace("'", "`") + "' AS TX_DESCRIZIONE ";
            SQL = SQL + ", " + ordine + " AS NM_ORDINE ";
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

        public void EliminaTipoAlbum(string id_tipo)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_ALBUM_TIPO WHERE ID_TIPO_ALBUM=" + id_tipo;
            }
            else
            {
                SQL = "DELETE FROM E_ALBUM_TIPO WHERE ID_TIPO_ALBUM=" + id_tipo;
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

        public void EliminaAlbum(string id_album)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_ALBUM WHERE ID_ALBUM=" + id_album;
            }
            else
            {
                SQL = "DELETE FROM E_ALBUM WHERE ID_ALBUM=" + id_album;
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

        public void EliminaFotoGallery(string id_foto)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_ALBUM_FOTO WHERE ID_FOTO=" + id_foto;
            }
            else
            {
                SQL = "DELETE FROM E_ALBUM_FOTO WHERE ID_FOTO=" + id_foto;
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

        public void SpostaPerElimin(string album, string ordine)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM_FOTO SET NM_ORDINE=NM_ORDINE-1 WHERE ID_ALBUM=" + album + " AND NM_ORDINE>" + ordine;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void RinominaTipoAlbum(string id_tipo, string nome)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM_TIPO SET TX_TIPO_ALBUM='" + nome.Replace("'", "`") + "' WHERE ID_TIPO_ALBUM=" + id_tipo;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void RinominaAlbum(string id_album, string nome)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM SET TX_ALBUM='" + nome.Replace("'", "`") + "' WHERE ID_ALBUM=" + id_album;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ModificaFoto(string id_foto, string titolo, string descrizione, string ordine)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM_FOTO SET TX_TITOLO='" + titolo.Replace("'", "`") + "'";
            SQL = SQL + ", TX_DESCRIZIONE='" + descrizione.Replace("'", "`") + "' ";
            SQL = SQL + ", NM_ORDINE=" + ordine + " ";
            SQL = SQL + " WHERE ID_FOTO=" + id_foto;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void SpostaDopo(string album, string ord_new, string ord_old)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM_FOTO SET NM_ORDINE=NM_ORDINE+1 WHERE ID_ALBUM=" + album + " AND NM_ORDINE>=" + ord_new + " AND NM_ORDINE<" + ord_old;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void SpostaPrima(string album, string ord_new, string ord_old)
        {
            string SQL;

            SQL = "UPDATE E_ALBUM_FOTO SET NM_ORDINE=NM_ORDINE-1 WHERE ID_ALBUM=" + album + " AND NM_ORDINE<=" + ord_new + " AND NM_ORDINE>" + ord_old;


            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region QUERY AREA SOCIO

        public DataTable DatiPersonali(string id_socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT E_Soci.NSocio  ";
                SQL = SQL + ", E_Soci.NumFamiglia  ";
                SQL = SQL + ", E_Soci.Nome  ";
                SQL = SQL + ", E_Soci.Cognome  ";
                SQL = SQL + ", Day(E_Soci.DataNascita) &'-'& Month(E_Soci.DataNascita) &'-'& Year(E_Soci.DataNascita) AS DTNASC  ";
                SQL = SQL + ", E_Soci.LuogoNascita  ";
                SQL = SQL + ", E_Soci.Indirizzo  ";
                SQL = SQL + ", E_Soci.Frazione  ";
                SQL = SQL + ", E_Soci.Comune  ";
                SQL = SQL + ", E_Soci.Telefono  ";
                SQL = SQL + ", E_Soci.Cellulare  ";
                SQL = SQL + ", E_Soci.CodFiscale  ";
                SQL = SQL + ", Day(E_Soci.DataIscrizione) &'-'& Month(E_Soci.DataIscrizione) &'-'& Year(E_Soci.DataIscrizione) AS DTISCR  ";
                SQL = SQL + ", E_Soci.DataFineIscrizione  ";
                SQL = SQL + ", E_Soci.MotivoFine  ";
                SQL = SQL + ", E_Soci.NumVolontario  ";
                SQL = SQL + ", E_Soci.COD_SAN  ";
                SQL = SQL + ", E_Soci.MED_CUR  ";
                SQL = SQL + ", Anpas.NumTesseraAtt ";
                SQL = SQL + "FROM E_Soci  ";
                SQL = SQL + "  LEFT JOIN ";
                SQL = SQL + "  ( ";
                SQL = SQL + "  SELECT * ";
                SQL = SQL + "  FROM E_TessereAnpas ";
                SQL = SQL + "  WHERE Anno=(SELECT MAX(Anno) FROM E_TessereAnpas) ";
                SQL = SQL + "  ) Anpas ";
                SQL = SQL + "  ON E_Soci.NSocio = Anpas.NSocio ";
                SQL = SQL + " WHERE E_Soci.NSocio= " + id_socio;
            }
            else
            {
                SQL = "SELECT E_Soci.NSocio   ";
                SQL = SQL + ", E_Soci.NumFamiglia   ";
                SQL = SQL + ", E_Soci.Nome   ";
                SQL = SQL + ", E_Soci.Cognome   ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(E_Soci.DataNascita) as CHAR),CAST(Month(E_Soci.DataNascita)  as CHAR),CAST(Year(E_Soci.DataNascita) as CHAR)) AS DTNASC   ";
                SQL = SQL + ", E_Soci.LuogoNascita   ";
                SQL = SQL + ", E_Soci.Indirizzo   ";
                SQL = SQL + ", E_Soci.Frazione   ";
                SQL = SQL + ", E_Soci.Comune   ";
                SQL = SQL + ", E_Soci.Telefono   ";
                SQL = SQL + ", E_Soci.Cellulare   ";
                SQL = SQL + ", E_Soci.CodFiscale   ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(E_Soci.DataIscrizione) as CHAR),CAST(Month(E_Soci.DataIscrizione)  as CHAR),CAST(Year(E_Soci.DataIscrizione) as CHAR)) AS DTISCR   ";
                SQL = SQL + ", CASE WHEN E_Soci.DataFineIscrizione=DATE('0000-00-00') THEN NULL ELSE CONCAT_WS('-',CAST(Day(E_Soci.DataFineIscrizione) as CHAR),CAST(Month(E_Soci.DataFineIscrizione)  as CHAR),CAST(Year(E_Soci.DataFineIscrizione) as CHAR)) END AS DataFineIscrizione ";
                SQL = SQL + ", E_Soci.MotivoFine   ";
                SQL = SQL + ", E_Soci.NumVolontario   ";
                SQL = SQL + ", E_Soci.COD_SAN  ";
                SQL = SQL + ", E_Soci.MED_CUR  ";
                SQL = SQL + ", Anpas.NumTesseraAtt ";
                SQL = SQL + "FROM E_Soci ";
                SQL = SQL + "  LEFT JOIN ";
                SQL = SQL + "  ( ";
                SQL = SQL + "  SELECT * ";
                SQL = SQL + "  FROM E_TessereAnpas ";
                SQL = SQL + "  WHERE Anno=(SELECT MAX(Anno) FROM E_TessereAnpas) ";
                SQL = SQL + "  ) Anpas ";
                SQL = SQL + "  ON E_Soci.NSocio = Anpas.NSocio ";
                SQL = SQL + " WHERE E_Soci.NSocio= " + id_socio;
            }



            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DatiFamiglia(string famiglia, string socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT * ";
                SQL = SQL + "FROM ( ";
                SQL = SQL + "SELECT A.NSocio ";
                SQL = SQL + ", A.NumFamiglia ";
                SQL = SQL + ", A.Nome ";
                SQL = SQL + ", A.Cognome ";
                SQL = SQL + ", A.Nome &' '& A.Cognome as NomeCognome ";
                SQL = SQL + ", Day(A.DataNascita) & '-' & Month(A.DataNascita) & '-' & Year(A.DataNascita) AS DTNASC ";
                SQL = SQL + ", A.Indirizzo, A.Frazione ";
                SQL = SQL + ", IIf(B.DataInizioDon Is Not Null ,'Si','No') AS Donatore ";
                SQL = SQL + ", IIf(C.NVolInt Is Not Null ,'Si','No') AS Volontario ";
                SQL = SQL + ", IIf(A.DataFineIscrizione Is Not Null ,1,0) AS FL_FINEISCR ";
                SQL = SQL + "FROM (E_Soci AS A LEFT JOIN (SELECT * FROM E_Donatori WHERE DataFineDon Is Null)  AS B ON A.NSocio = B.NSocio)  ";
                SQL = SQL + "LEFT JOIN (SELECT DISTINCT NVolInt FROM E_VolAttivita WHERE DataFineVolAtt Is Null) C ON A.NumVolontario = C.NVolInt ";
                SQL = SQL + ") ";
                SQL = SQL + "WHERE NumFamiglia=" + famiglia;
                SQL = SQL + " AND NSocio<>" + socio;
            }
            else
            {
                SQL = "SELECT *";
                SQL = SQL + "FROM (   ";
                SQL = SQL + "SELECT A.NSocio   ";
                SQL = SQL + ", A.NumFamiglia   ";
                SQL = SQL + ", A.Nome   ";
                SQL = SQL + ", A.Cognome   ";
                SQL = SQL + ", CONCAT_WS(' ',A.Nome,A.Cognome) as NomeCognome   ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(A.DataNascita) as CHAR),CAST(Month(A.DataNascita)  as CHAR),CAST(Year(A.DataNascita) as CHAR)) AS DTNASC   ";
                SQL = SQL + ", A.Indirizzo, A.Frazione   ";
                SQL = SQL + ", CASE WHEN B.DataInizioDon Is Not Null AND B.DataInizioDon<>DATE('0000-00-00') THEN 'Si' ELSE 'No' END AS Donatore   ";
                SQL = SQL + ", CASE WHEN C.NVolInt Is Not Null THEN 'Si' ELSE 'No' END AS Volontario   ";
                SQL = SQL + ", CASE WHEN A.DataFineIscrizione Is Not Null AND A.DataFineIscrizione<>DATE('0000-00-00') THEN 1 ELSE 0 END AS FL_FINEISCR   ";
                SQL = SQL + "FROM E_Soci A   ";
                SQL = SQL + "LEFT JOIN (SELECT * FROM E_Donatori WHERE (DataFineDon Is Null OR DataFineDon=DATE('0000-00-00'))) B ON A.NSocio = B.NSocio    ";
                SQL = SQL + "LEFT JOIN (SELECT DISTINCT NVolInt FROM E_VolAttivita WHERE (DataFineVolAtt Is Null OR DataFineVolAtt=DATE('0000-00-00'))) C ON A.NumVolontario = C.NVolInt   ";
                SQL = SQL + ") A";
                SQL = SQL + " WHERE NumFamiglia=" + famiglia;
                SQL = SQL + " AND NSocio<>" + socio;

            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DatiReferente(String famiglia)
        {
            String SQL = "SELECT CONCAT_WS(' ',A.Nome,A.Cognome) as NomeCognome,E.S_MAIL ";
            SQL = SQL + "FROM E_Soci A, E_Referenti E   ";
            SQL = SQL + "WHERE A.NumFamiglia=" + famiglia;
            SQL = SQL + " AND A.NSocio=E.N_SOCIO";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DatiVolontario(string socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT AAA.NSocio ";
                SQL = SQL + ", AAA.NVolInt ";
                SQL = SQL + ", AAA.DataInizioVolAtt ";
                SQL = SQL + ", AAA.DTINIZ ";
                SQL = SQL + ", AAA.DTFINE ";
                SQL = SQL + ", AAA.TipoVol ";
                SQL = SQL + ", BBB.N_Vol_Anpas ";
                SQL = SQL + "FROM ( ";
                SQL = SQL + "    SELECT AA.NSocio ";
                SQL = SQL + "    , AA.NVolInt ";
                SQL = SQL + "    , AA.DataInizioVolAtt ";
                SQL = SQL + "    , AA.DTINIZ ";
                SQL = SQL + "    , AA.DTFINE ";
                SQL = SQL + "    , BB.TipoVol  ";
                SQL = SQL + "    FROM ( ";
                SQL = SQL + "        SELECT B.NSocio ";
                SQL = SQL + "        , A.NVolInt ";
                SQL = SQL + "        , A.CodVol ";
                SQL = SQL + "        , DataInizioVolAtt ";
                SQL = SQL + "        , Day(DataInizioVolAtt) &'-'& Month(DataInizioVolAtt) &'-'& Year(DataInizioVolAtt) AS DTINIZ  ";
                SQL = SQL + "        , IIF(DataFineVolAtt IS NULL, 'in corso',Day(DataFineVolAtt) &'-'& Month(DataFineVolAtt) &'-'& Year(DataFineVolAtt)) AS DTFINE  ";
                SQL = SQL + "        FROM E_VolAttivita A  ";
                SQL = SQL + "         LEFT JOIN E_Soci B  ";
                SQL = SQL + "         ON A.NVolInt=B.NumVolontario ";
                SQL = SQL + "        ) AA ";
                SQL = SQL + "        LEFT JOIN ";
                SQL = SQL + "        E_TipoVolontariato BB ";
                SQL = SQL + "        ON AA.CodVol = BB.CodVol ";
                SQL = SQL + "    ) AAA ";
                SQL = SQL + "    LEFT JOIN  ";
                SQL = SQL + "    ( ";
                SQL = SQL + "    SELECT *  ";
                SQL = SQL + "    FROM E_Volontari  ";
                SQL = SQL + "    WHERE Vescluso IS NULL ";
                SQL = SQL + "    ) BBB ";
                SQL = SQL + "    ON AAA.NSocio=BBB.VolNsocio AND AAA.NVolInt=BBB.NumVolontario ";
                SQL = SQL + "WHERE AAA.NSocio=" + socio + "  ";
                SQL = SQL + "ORDER BY AAA.DataInizioVolAtt DESC ";

            }
            else
            {
                SQL = "SELECT AAA.NSocio ";
                SQL = SQL + ", AAA.NVolInt ";
                SQL = SQL + ", AAA.DataInizioVolAtt ";
                SQL = SQL + ", AAA.DTINIZ ";
                SQL = SQL + ", AAA.DTFINE ";
                SQL = SQL + ", AAA.TipoVol ";
                SQL = SQL + ", BBB.N_Vol_Anpas ";
                SQL = SQL + "FROM ( ";
                SQL = SQL + "    SELECT AA.NSocio ";
                SQL = SQL + "    , AA.NVolInt ";
                SQL = SQL + "    , AA.DataInizioVolAtt ";
                SQL = SQL + "    , AA.DTINIZ ";
                SQL = SQL + "    , AA.DTFINE ";
                SQL = SQL + "    , BB.TipoVol  ";
                SQL = SQL + "    FROM ( ";
                SQL = SQL + "        SELECT B.NSocio ";
                SQL = SQL + "        , A.NVolInt ";
                SQL = SQL + "        , A.CodVol ";
                SQL = SQL + "        , DataInizioVolAtt ";
                SQL = SQL + "        , CONCAT_WS('-',CAST(Day(DataInizioVolAtt) as CHAR),CAST(Month(DataInizioVolAtt)  as CHAR),CAST(Year(DataInizioVolAtt) as CHAR)) AS DTINIZ  ";
                SQL = SQL + "        , CASE WHEN DataFineVolAtt IS NULL OR DataFineVolAtt=DATE('0000-00-00') THEN 'in corso'   ";
                SQL = SQL + "            ELSE CONCAT_WS('-',CAST(Day(DataFineVolAtt) as CHAR),CAST(Month(DataFineVolAtt)  as CHAR),CAST(Year(DataFineVolAtt) as CHAR))   ";
                SQL = SQL + "            END AS DTFINE   ";
                SQL = SQL + "        FROM E_VolAttivita A  ";
                SQL = SQL + "         LEFT JOIN E_Soci B  ";
                SQL = SQL + "         ON A.NVolInt=B.NumVolontario ";
                SQL = SQL + "        ) AA ";
                SQL = SQL + "        LEFT JOIN ";
                SQL = SQL + "        D_TipoVolontariato BB ";
                SQL = SQL + "        ON AA.CodVol = BB.CodVol ";
                SQL = SQL + "    ) AAA ";
                SQL = SQL + "    LEFT JOIN  ";
                SQL = SQL + "    ( ";
                SQL = SQL + "    SELECT *  ";
                SQL = SQL + "    FROM E_Volontari  ";
                SQL = SQL + "    WHERE Vescluso<>'SI' ";
                SQL = SQL + "    ) BBB ";
                SQL = SQL + "    ON AAA.NSocio=BBB.VolNsocio AND AAA.NVolInt=BBB.NumVolontario ";
                SQL = SQL + "WHERE AAA.NSocio=" + socio + "  ";
                SQL = SQL + "ORDER BY AAA.DataInizioVolAtt DESC ";

            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable DatiDonatore(string socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT E_Donatori.NSocio ";
                SQL = SQL + ", E_Donatori.Matricola ";
                SQL = SQL + ", E_Donatori.COD_DON ";
                SQL = SQL + ", E_Donatori.GruppoSanguigno ";
                SQL = SQL + ", E_Donatori.RH ";
                SQL = SQL + ", E_Donatori.FENOTIPO ";
                SQL = SQL + ", Day(DataInizioDon) &'-'& Month(DataInizioDon) &'-'& Year(DataInizioDon) AS DTINIZ ";
                SQL = SQL + ", IIF(DataFineDon IS NULL, 'in corso',Day(DataFineDon) &'-'& Month(DataFineDon) &'-'& Year(DataFineDon)) AS DTFINE ";
                SQL = SQL + "FROM E_Donatori ";
                SQL = SQL + "WHERE NSocio=" + socio;
            }
            else
            {
                SQL = "SELECT E_Donatori.NSocio  ";
                SQL = SQL + ", E_Donatori.Matricola  ";
                SQL = SQL + ", E_Donatori.COD_DON  ";
                SQL = SQL + ", E_Donatori.GruppoSanguigno  ";
                SQL = SQL + ", E_Donatori.RH  ";
                SQL = SQL + ", E_Donatori.FENOTIPO  ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(DataInizioDon) as CHAR),CAST(Month(DataInizioDon)  as CHAR),CAST(Year(DataInizioDon) as CHAR)) AS DTINIZ  ";
                SQL = SQL + ", CASE WHEN DataFineDon IS NULL OR DataFineDon=DATE('0000-00-00') THEN 'in corso' ";
                SQL = SQL + "       ELSE CONCAT_WS('-',CAST(Day(DataFineDon) as CHAR),CAST(Month(DataFineDon)  as CHAR),CAST(Year(DataFineDon) as CHAR)) ";
                SQL = SQL + "       END AS DTFINE  ";
                SQL = SQL + "FROM E_Donatori  ";
                SQL = SQL + "WHERE NSocio= " + socio;
            }


            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public bool FlagUltima(int giorni, string socio)
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(NUMGIORNI> " + giorni.ToString() + " AND DataFineDon is null,1,0) AS FLDON  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT A.NSocio ";
                SQL = SQL + ", B.DataFineDon ";
                SQL = SQL + ", DATEDIFF(\"d\",MAX(A.DataDonazione) ,NOW(),2) as NUMGIORNI  ";
                SQL = SQL + "FROM E_Donazioni A ";
                SQL = SQL + ", E_Donatori B ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio ";
                SQL = SQL + "AND A.NSocio=" + socio;
                SQL = SQL + " GROUP BY A.NSocio, B.DataFineDon ";
                SQL = SQL + " ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN NUMGIORNI>365 AND (DataFineDon is null OR DataFineDon=DATE('0000-00-00'))  THEN 1 ELSE 0 END AS FLDON   ";
                SQL = SQL + "FROM (   ";
                SQL = SQL + "SELECT A.NSocio  ";
                SQL = SQL + ", B.DataFineDon  ";
                SQL = SQL + ", DATEDIFF(CURDATE(),MAX(A.DataDonazione)) as NUMGIORNI   ";
                SQL = SQL + "FROM E_Donazioni A  ";
                SQL = SQL + ", E_Donatori B  ";
                SQL = SQL + "WHERE A.NSocio=B.NSocio  ";
                SQL = SQL + "AND A.NSocio=" + socio;
                SQL = SQL + " GROUP BY A.NSocio, B.DataFineDon  ";
                SQL = SQL + " ) A ";
            }

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["FLDON"].ToString() == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable DonazioniSocio(string socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT A.NSocio ";
                SQL = SQL + ", Day(DataDonazione) &'-'& Month(DataDonazione) &'-'& Year(DataDonazione) AS DTDON ";
                SQL = SQL + ", A.TipoDonazione ";
                SQL = SQL + ", B.DescrTipo AS DSTIPODON ";
                SQL = SQL + "FROM E_Donazioni A ";
                SQL = SQL + ", D_TipoDonazioni B ";
                SQL = SQL + "WHERE A.TipoDonazione=B.TipoDonazione ";
                SQL = SQL + "AND A.NSocio=" + socio;
                SQL = SQL + " ORDER BY A.DataDonazione DESC ";
            }
            else
            {
                SQL = "SELECT A.NSocio  ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(DataDonazione) as CHAR),CAST(Month(DataDonazione)  as CHAR),CAST(Year(DataDonazione) as CHAR)) AS DTDON  ";
                SQL = SQL + ", A.TipoDonazione  ";
                SQL = SQL + ", B.DescrTipo AS DSTIPODON  ";
                SQL = SQL + "FROM E_Donazioni A  ";
                SQL = SQL + ", D_TipoDonazioni B  ";
                SQL = SQL + "WHERE A.TipoDonazione=B.TipoDonazione  ";
                SQL = SQL + "AND A.NSocio=" + socio;
                SQL = SQL + " ORDER BY A.DataDonazione DESC ";
            }

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Quota(string socio)
        {
            string SQL;
            DataTable dt = new DataTable();
            string quota_bassa = "5";
            string quota_alta = "10";

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(Volontario=1 OR Donatore=1 OR ANNOCORR-ANNONASC<=10,0,IIF(ANNOCORR-ANNONASC>10 AND ANNOCORR-ANNONASC<=18," + quota_bassa + "," + quota_alta + ")) AS QUOTA ";
                SQL = SQL + "FROM ( ";
                SQL = SQL + "SELECT A.NSocio  ";
                SQL = SQL + ", Year(A.DataNascita) as ANNONASC ";
                SQL = SQL + ", Year(NOW()) AS ANNOCORR ";
                SQL = SQL + ", IIF(A.NumVolontario = 0,0,1) as Volontario  ";
                SQL = SQL + ", IIF(B.NSocio is null,0,1) as Donatore  ";
                SQL = SQL + "FROM E_Soci A   ";
                SQL = SQL + "LEFT JOIN   ";
                SQL = SQL + "( SELECT * FROM E_Donatori WHERE E_Donatori.DataFineDon Is Null) B  ";
                SQL = SQL + "ON A.NSocio = B.NSocio ";
                SQL = SQL + "WHERE A.NSocio=" + socio;
                SQL = SQL + ") ";
            }
            else
            {
                SQL = "SELECT CASE WHEN Volontario=1 OR Donatore=1 OR ANNOCORR-ANNONASC<=10 THEN 0 ";
                SQL = SQL + "            WHEN ANNOCORR-ANNONASC>10 AND ANNOCORR-ANNONASC<=18 THEN " + quota_bassa + "  ";
                SQL = SQL + "            ELSE " + quota_alta + " ";
                SQL = SQL + "            END AS QUOTA  ";
                SQL = SQL + "FROM (  ";
                SQL = SQL + "SELECT A.NSocio   ";
                SQL = SQL + ", Year(A.DataNascita) as ANNONASC  ";
                SQL = SQL + ", Year(NOW()) AS ANNOCORR  ";
                SQL = SQL + ", CASE WHEN A.NumVolontario = 0 THEN 0 ELSE 1 END as Volontario   ";
                SQL = SQL + ", CASE WHEN B.NSocio is null THEN 0 ELSE 1 END as Donatore   ";
                SQL = SQL + "FROM E_Soci A    ";
                SQL = SQL + "LEFT JOIN    ";
                SQL = SQL + "( SELECT * FROM E_Donatori WHERE (E_Donatori.DataFineDon Is Null OR E_Donatori.DataFineDon=DATE('0000-00-00') )) B   ";
                SQL = SQL + "ON A.NSocio = B.NSocio  ";
                SQL = SQL + "WHERE A.NSocio=" + socio;
                SQL = SQL + ") X ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["QUOTA"].ToString();
                }
                else
                {
                    return quota_alta;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool Pagato(string socio)
        {
            string SQL;
            DataTable dt = new DataTable();

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT * ";
                SQL = SQL + "FROM E_Quote ";
                SQL = SQL + "where Year(DataPagamento)=Year(Now()) ";
                SQL = SQL + "and NSocio=" + socio;
            }
            else
            {
                SQL = "SELECT coalesce(sum(QuotaRisc),0) as QuotaRisc  ";
                SQL = SQL + "FROM E_Quote  ";
                SQL = SQL + "where Year(DataPagamento)=Year(CURDATE())  ";
                SQL = SQL + "and NSocio=" + socio;
            }

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["QuotaRisc"].ToString() != "0")
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable PagamentiEffettuati(string socio)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT A.NSocio ";
                SQL = SQL + ", Day(DataPagamento) &'-'& Month(DataPagamento) &'-'& Year(DataPagamento) AS DTPAG ";
                SQL = SQL + ", A.LuogoPagamento ";
                SQL = SQL + ", A.QuotaRisc &' €' as QUOTA ";
                SQL = SQL + "FROM E_Quote AS A ";
                SQL = SQL + "WHERE A.NSocio=" + socio;
                SQL = SQL + " AND Year(DataPagamento)> " + (DateTime.Now.Year - 5).ToString();
                SQL = SQL + " ORDER BY A.DataPagamento DESC ";
            }
            else
            {
                SQL = "SELECT A.NSocio  ";
                SQL = SQL + ", CONCAT_WS('-',CAST(Day(DataPagamento) as CHAR),CAST(Month(DataPagamento)  as CHAR),CAST(Year(DataPagamento) as CHAR)) AS DTPAG  ";
                SQL = SQL + ", A.LuogoPagamento  ";
                SQL = SQL + ", CAST(A.QuotaRisc as CHAR) as QUOTA  ";
                SQL = SQL + "FROM E_Quote AS A  ";
                SQL = SQL + "WHERE A.NSocio=" + socio;
                SQL = SQL + " AND Year(DataPagamento)> " + (DateTime.Now.Year - 5).ToString();
                SQL = SQL + " ORDER BY A.DataPagamento DESC ";
            }



            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region QUERY AREA ADMIN 

        public DataTable TipiIniziative()
        {

            string SQL;

            SQL = "SELECT ID_TIPO,DS_TIPO FROM D_TIPONOTIZIA order by ID_TIPO";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable TipiIniziativeConNullo()
        {

            string SQL;

            SQL = "SELECT * FROM (SELECT 0 AS ID_TIPO,'' AS DS_TIPO FROM DUAL UNION SELECT ID_TIPO,DS_TIPO FROM D_TIPONOTIZIA) A order by ID_TIPO";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public string ProxIDNews()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_NEWS ";
                SQL = SQL + "FROM ( SELECT MAX(ID_NOTIZIA) AS ULTIMA FROM E_NOTIZIE ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_NEWS  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_NOTIZIA) AS ULTIMA FROM E_NOTIZIE ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_NEWS"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string ProxIDFoto()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_FOTO ";
                SQL = SQL + "FROM ( SELECT MAX(ID_FOTO) AS ULTIMA FROM E_FOTO ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_FOTO  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_FOTO) AS ULTIMA FROM E_FOTO ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_FOTO"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void InserisciFoto(string id_foto, string nomefoto, string descfoto)
        {
            string SQL;

            SQL = "INSERT INTO E_FOTO ";
            SQL = SQL + "SELECT " + id_foto + " AS ID_FOTO ";
            SQL = SQL + ",'" + nomefoto + "' AS TX_NOMEFILE ";
            SQL = SQL + ",'" + descfoto.Replace("'", "`") + "' AS TX_DESCFOTO  ";
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

        public void CollegaFoto(string id_news, string id_foto)
        {
            string SQL;

            SQL = "INSERT INTO R_FOTO_NOTIZIA ";
            SQL = SQL + "SELECT " + id_foto + " AS ID_FOTO ";
            SQL = SQL + "," + id_news + " AS ID_NOTIZIA ";
            SQL = SQL + ",1 AS FL_PRINCIPALE  ";
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

        public void AggiornaFoto(string id_news, string id_foto)
        {
            string SQL;
            string SQL1;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL1 = "DELETE * FROM R_FOTO_NOTIZIA WHERE ID_NOTIZIA=" + id_news;
            }
            else
            {
                SQL1 = "DELETE FROM R_FOTO_NOTIZIA WHERE ID_NOTIZIA=" + id_news;
            }

            SQL = "INSERT INTO R_FOTO_NOTIZIA ";
            SQL = SQL + "SELECT " + id_foto + " AS ID_FOTO ";
            SQL = SQL + "," + id_news + " AS ID_NOTIZIA ";
            SQL = SQL + ",1 AS FL_PRINCIPALE  ";
            SQL = SQL + "FROM DUAL ";

            try
            {
                objAcc.Esegui(SQL1);
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ScollegaFoto(string id_news, string id_foto)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM R_FOTO_NOTIZIA WHERE ID_FOTO=" + id_foto + " AND ID_NOTIZIA=" + id_news;
            }
            else
            {
                SQL = "DELETE FROM R_FOTO_NOTIZIA WHERE ID_FOTO=" + id_foto + " AND ID_NOTIZIA=" + id_news;
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

        public void InserisciAllegato(string id_news, string nomeallegato, string descallegato)
        {
            string SQL;

            SQL = "INSERT INTO E_ALLEGATINEWS ";
            SQL = SQL + "SELECT " + id_news + " AS ID_NOTIZIA ";
            SQL = SQL + ",'" + nomeallegato + "' AS TX_NOMEFILE ";
            SQL = SQL + ",'" + descallegato.Replace("'", "`") + "' AS TX_DESCRIZIONE  ";
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

        public void AggiornaAllegato(string id_news, string nomeallegato, string descallegato)
        {
            string SQL;
            string SQL1;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL1 = "DELETE * FROM E_ALLEGATINEWS WHERE ID_NOTIZIA=" + id_news;
            }
            else
            {
                SQL1 = "DELETE FROM E_ALLEGATINEWS WHERE ID_NOTIZIA=" + id_news;
            }

            SQL = "INSERT INTO E_ALLEGATINEWS ";
            SQL = SQL + "SELECT " + id_news + " AS ID_NOTIZIA ";
            SQL = SQL + ",'" + nomeallegato + "' AS TX_NOMEFILE ";
            SQL = SQL + ",'" + descallegato.Replace("'", "`") + "' AS TX_DESCRIZIONE  ";
            SQL = SQL + "FROM DUAL ";

            try
            {
                objAcc.Esegui(SQL1);
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void EliminaAllegato(string id_news)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_ALLEGATINEWS WHERE ID_NOTIZIA=" + id_news;
            }
            else
            {
                SQL = "DELETE FROM E_ALLEGATINEWS WHERE ID_NOTIZIA=" + id_news;
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

        public void EliminaFoto(string id_Foto)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_FOTO WHERE ID_FOTO=" + id_Foto;
            }
            else
            {
                SQL = "DELETE FROM E_FOTO WHERE ID_FOTO=" + id_Foto;
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

        public void InserisciNotizia(string ID_NOTIZIA, string DT_INSERIMENTO, string DT_EVENTO, string ID_TIPO
            , string DS_TITOLO, string DS_SOTTOTITOLO, string DS_DESCRIZIONE, string FL_HOME)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO E_NOTIZIE ";
                SQL = SQL + "SELECT " + ID_NOTIZIA + " AS ID_NOTIZIA ";
                SQL = SQL + ",#" + DT_INSERIMENTO + "# AS DT_INSERIMENTO ";
                SQL = SQL + ",#" + DT_EVENTO + "# AS DT_EVENTO ";
                SQL = SQL + "," + ID_TIPO + " AS ID_TIPO ";
                SQL = SQL + ",'" + DS_TITOLO.Replace("'", "`") + "' AS DS_TITOLO ";
                SQL = SQL + ",'" + DS_SOTTOTITOLO.Replace("'", "`") + "' AS DS_SOTTOTITOLO ";
                SQL = SQL + ",'" + DS_DESCRIZIONE.Replace("'", "`") + "' AS DS_DESCRIZIONE ";
                SQL = SQL + "," + FL_HOME + " AS FL_HOME ";
                SQL = SQL + ", NULL AS DT_FINE ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO E_NOTIZIE ";
                SQL = SQL + "SELECT " + ID_NOTIZIA + " AS ID_NOTIZIA ";
                SQL = SQL + ", DATE('" + DT_INSERIMENTO.Replace("/", "-") + "') AS DT_INSERIMENTO ";
                SQL = SQL + ", DATE('" + DT_EVENTO.Replace("/", "-") + "') AS DT_EVENTO ";
                SQL = SQL + ", " + ID_TIPO + " AS ID_TIPO ";
                SQL = SQL + ", '" + DS_TITOLO.Replace("'", "`") + "' AS DS_TITOLO ";
                SQL = SQL + ", '" + DS_SOTTOTITOLO.Replace("'", "`") + "' AS DS_SOTTOTITOLO ";
                SQL = SQL + ", '" + DS_DESCRIZIONE.Replace("'", "`") + "' AS DS_DESCRIZIONE ";
                SQL = SQL + ", " + FL_HOME + " AS FL_HOME ";
                SQL = SQL + ", NULL AS DT_FINE ";
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

        public void ModificaNotizia(string ID_NOTIZIA, string DT_EVENTO, string ID_TIPO
            , string DS_TITOLO, string DS_SOTTOTITOLO, string DS_DESCRIZIONE, string FL_HOME)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "UPDATE E_NOTIZIE ";
                SQL = SQL + "SET DT_EVENTO=#" + DT_EVENTO + "# ";
                SQL = SQL + ",ID_TIPO=" + ID_TIPO;
                SQL = SQL + ",DS_TITOLO='" + DS_TITOLO.Replace("'", "`") + "'";
                SQL = SQL + ",DS_SOTTOTITOLO='" + DS_SOTTOTITOLO.Replace("'", "`") + "'";
                SQL = SQL + ",DS_DESCRIZIONE='" + DS_DESCRIZIONE.Replace("'", "`").Replace("\r\n", "<br />").Replace("  ", "&nbsp;&nbsp;") + "'";
                SQL = SQL + ",FL_HOME=" + FL_HOME;
                SQL = SQL + " WHERE ID_NOTIZIA= " + ID_NOTIZIA;
            }
            else
            {
                SQL = "UPDATE E_NOTIZIE ";
                SQL = SQL + "SET DT_EVENTO = DATE('" + DT_EVENTO.Replace("/", "-") + "')";
                SQL = SQL + ",ID_TIPO=" + ID_TIPO;
                SQL = SQL + ",DS_TITOLO='" + DS_TITOLO.Replace("'", "`") + "'";
                SQL = SQL + ",DS_SOTTOTITOLO='" + DS_SOTTOTITOLO.Replace("'", "`") + "'";
                SQL = SQL + ",DS_DESCRIZIONE='" + DS_DESCRIZIONE.Replace("'", "`").Replace("\r\n", "<br />").Replace("  ", "&nbsp;&nbsp;") + "'";
                SQL = SQL + ",FL_HOME=" + FL_HOME;
                SQL = SQL + " WHERE ID_NOTIZIA= " + ID_NOTIZIA;
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

        public void EliminaNotizia(string ID_NOTIZIA)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "UPDATE E_NOTIZIE SET DT_FINE=#" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "# WHERE ID_NOTIZIA=" + ID_NOTIZIA;
            }
            else
            {
                SQL = "UPDATE E_NOTIZIE SET DT_FINE=DATE('" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "') WHERE ID_NOTIZIA=" + ID_NOTIZIA;
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

        public string VerificaDati()
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT FL_COPIA FROM E_CARICAMENTI";


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["FL_COPIA"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void AggiornaCaricamento()
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "UPDATE E_CARICAMENTI SET FL_COPIA = 0 AND DT_CARICAMENTO=#" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "#";
            }
            else
            {
                SQL = "UPDATE E_CARICAMENTI SET FL_COPIA = 0 AND DT_CARICAMENTO=DATE('" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "')";
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

        public void AggiornaCopia()
        {
            string SQL;

            SQL = "UPDATE E_CARICAMENTI SET FL_COPIA=1";

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable GetLogCaricamento()
        {
            string SQL;

            SQL = "SELECT DAY(DT_CARICAMENTO) AS GIORNO,MONTH(DT_CARICAMENTO) AS MESE,YEAR(DT_CARICAMENTO) AS ANNO,LOG_CARICAMENTO FROM E_CARICAMENTI_LOG order by DT_CARICAMENTO desc";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void InsLogCaricamento(string LOG_CARICAMENTO)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO E_CARICAMENTI_LOG ";
                SQL = SQL + "SELECT #" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "# AS DT_CARICAMENTO ";
                SQL = SQL + ",'" + LOG_CARICAMENTO.Replace("'", "`") + "' AS LOG_CARICAMENTO ";
                SQL = SQL + "FROM DUAL ";
            }
            else
            {
                SQL = "INSERT INTO E_CARICAMENTI_LOG ";
                SQL = SQL + "SELECT DATE('" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "') AS DT_CARICAMENTO ";
                SQL = SQL + ",'" + LOG_CARICAMENTO.Replace("'", "`") + "' AS LOG_CARICAMENTO ";
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

        public void CaricaDati(string file, string tabella)
        {
            string SQL;

            SQL = "LOAD DATA LOCAL INFILE '" + file + "' INTO TABLE Sql178902_2." + tabella + " FIELDS TERMINATED BY ';' ENCLOSED BY '\"\' LINES TERMINATED BY '\\n'";

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region QUERY NEWSLETTER

        public string ProxIDNewsLetter()
        {
            DataTable dt = new DataTable();
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_ISCRITTO ";
                SQL = SQL + "FROM ( SELECT MAX(ID_ISCRITTO) AS ULTIMA FROM E_NL_ISCRITTI ) A ";
            }
            else
            {
                SQL = "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_ISCRITTO  ";
                SQL = SQL + "FROM ( SELECT MAX(ID_ISCRITTO) AS ULTIMA FROM E_NL_ISCRITTI ) A ";
            }


            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_ISCRITTO"].ToString();
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string IscrizioneNewsletter(string ID, string Nome, string Anno, string Comune, string Cap, string e_mail)
        {
            string SQL;
            int NR_ATTIVAZIONE;
            int NR_DISATTIVAZIONE;
            Random rand = new Random();

            NR_ATTIVAZIONE = rand.Next(999999999);
            NR_DISATTIVAZIONE = rand.Next(999999999);

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO E_NL_ISCRITTI ";
                SQL = SQL + "SELECT " + ID + " AS ID_ISCRITTO ";
                SQL = SQL + ", '" + Nome.Replace("'", "`").Trim() + "' AS TX_NOME";
                SQL = SQL + ", '" + Anno.Replace("'", "`").Trim() + "' AS TX_ANNO";
                SQL = SQL + ", '" + Comune.Replace("'", "`").Trim() + "' AS TX_COMUNE";
                SQL = SQL + ", '" + Cap.Replace("'", "`").Trim() + "' AS TX_CAP";
                SQL = SQL + ", '" + e_mail.Replace("'", "`").Trim() + "' AS TX_EMAIL";
                SQL = SQL + ", 0 AS FL_ATTIVO";
                SQL = SQL + ", " + NR_ATTIVAZIONE.ToString() + " AS NR_ATTIVAZIONE";
                SQL = SQL + ", " + NR_DISATTIVAZIONE.ToString() + " AS NR_DISATTIVAZIONE ";
                SQL = SQL + "FROM DUAL A ";
            }
            else
            {
                SQL = "INSERT INTO E_NL_ISCRITTI ";
                SQL = SQL + "SELECT " + ID + " AS ID_ISCRITTO  ";
                SQL = SQL + ", '" + Nome.Replace("'", "`").Trim() + "' AS TX_NOME";
                SQL = SQL + ", '" + Anno.Replace("'", "`").Trim() + "' AS TX_ANNO";
                SQL = SQL + ", '" + Comune.Replace("'", "`").Trim() + "' AS TX_COMUNE";
                SQL = SQL + ", '" + Cap.Replace("'", "`").Trim() + "' AS TX_CAP";
                SQL = SQL + ", '" + e_mail.Replace("'", "`").Trim() + "' AS TX_EMAIL";
                SQL = SQL + ", 0 AS FL_ATTIVO";
                SQL = SQL + ", " + NR_ATTIVAZIONE.ToString() + " AS NR_ATTIVAZIONE";
                SQL = SQL + ", " + NR_DISATTIVAZIONE.ToString() + " AS NR_DISATTIVAZIONE ";
                SQL = SQL + "FROM DUAL ";
            }


            try
            {
                objAcc.Esegui(SQL);
                return NR_ATTIVAZIONE.ToString();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void IscrizioneNewsletterAdmin(string ID, string Nome, string Anno, string Comune, string Cap, string e_mail)
        {
            string SQL;
            int NR_ATTIVAZIONE;
            int NR_DISATTIVAZIONE;
            Random rand = new Random();

            NR_ATTIVAZIONE = rand.Next(999999999);
            NR_DISATTIVAZIONE = rand.Next(999999999);

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO E_NL_ISCRITTI ";
                SQL = SQL + "SELECT " + ID + " AS ID_ISCRITTO ";
                SQL = SQL + ", '" + Nome.Replace("'", "`").Trim() + "' AS TX_NOME";
                SQL = SQL + ", '" + Anno.Replace("'", "`").Trim() + "' AS TX_ANNO";
                SQL = SQL + ", '" + Comune.Replace("'", "`").Trim() + "' AS TX_COMUNE";
                SQL = SQL + ", '" + Cap.Replace("'", "`").Trim() + "' AS TX_CAP";
                SQL = SQL + ", '" + e_mail.Replace("'", "`").Trim() + "' AS TX_EMAIL";
                SQL = SQL + ", 1 AS FL_ATTIVO";
                SQL = SQL + ", " + NR_ATTIVAZIONE.ToString() + " AS NR_ATTIVAZIONE";
                SQL = SQL + ", " + NR_DISATTIVAZIONE.ToString() + " AS NR_DISATTIVAZIONE ";
                SQL = SQL + "FROM DUAL A ";
            }
            else
            {
                SQL = "INSERT INTO E_NL_ISCRITTI ";
                SQL = SQL + "SELECT " + ID + " AS ID_ISCRITTO  ";
                SQL = SQL + ", '" + Nome.Replace("'", "`").Trim() + "' AS TX_NOME";
                SQL = SQL + ", '" + Anno.Replace("'", "`").Trim() + "' AS TX_ANNO";
                SQL = SQL + ", '" + Comune.Replace("'", "`").Trim() + "' AS TX_COMUNE";
                SQL = SQL + ", '" + Cap.Replace("'", "`").Trim() + "' AS TX_CAP";
                SQL = SQL + ", '" + e_mail.Replace("'", "`").Trim() + "' AS TX_EMAIL";
                SQL = SQL + ", 1 AS FL_ATTIVO";
                SQL = SQL + ", " + NR_ATTIVAZIONE.ToString() + " AS NR_ATTIVAZIONE";
                SQL = SQL + ", " + NR_DISATTIVAZIONE.ToString() + " AS NR_DISATTIVAZIONE ";
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

        public int AttivaIscritto(string id, string nr)
        {
            string SQL;

            SQL = "UPDATE E_NL_ISCRITTI SET FL_ATTIVO=1 WHERE ID_ISCRITTO=" + id + " AND NR_ATTIVAZIONE=" + nr;

            try
            {
                return objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public int EliminaIscritto(string id, string nr)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_NL_ISCRITTI WHERE ID_ISCRITTO=" + id + " AND NR_DISATTIVAZIONE=" + nr;
            }
            else
            {
                SQL = "DELETE FROM E_NL_ISCRITTI WHERE ID_ISCRITTO=" + id + " AND NR_DISATTIVAZIONE=" + nr;
            }




            try
            {
                return objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public int EliminaIscrittoAdmin(string id)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_NL_ISCRITTI WHERE ID_ISCRITTO=" + id;
            }
            else
            {
                SQL = "DELETE FROM E_NL_ISCRITTI WHERE ID_ISCRITTO=" + id;
            }




            try
            {
                return objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable DatiIscrittoDaMail(string email)
        {
            string SQL;

            SQL = "SELECT * FROM E_NL_ISCRITTI WHERE TX_EMAIL='" + email.Trim() + "'";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable ElencoIscrittiNL()
        {
            string SQL;

            SQL = "SELECT * FROM E_NL_ISCRITTI";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public DataTable ElencoIscrittiNLAttivi()
        {
            string SQL;

            SQL = "SELECT * FROM E_NL_ISCRITTI WHERE FL_ATTIVO=1";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        #endregion

        #region QUERY LINK

        public void InserisciLink(string descrizione, string url)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "INSERT INTO E_LINK ";
                SQL = SQL + "SELECT IIF(ULTIMA IS NULL,1,ULTIMA+1) AS ID_LINK ";
                SQL = SQL + ",'" + descrizione + "' AS TX_DESCRIZIONE ";
                SQL = SQL + ",'" + url + "' AS TX_LINK ";
                SQL = SQL + ", NUM+1 AS NR_ORDINE ";
                SQL = SQL + "FROM ( SELECT MAX(ID_LINK) AS ULTIMA,COUNT(*) AS NUM FROM E_LINK ) A ";
            }
            else
            {
                SQL = "INSERT INTO E_LINK ";
                SQL = SQL + "SELECT CASE WHEN ULTIMA IS NULL THEN 1 ELSE ULTIMA+1 END AS ID_LINK  ";
                SQL = SQL + ",'" + descrizione + "' AS TX_DESCRIZIONE ";
                SQL = SQL + ",'" + url + "' AS TX_LINK ";
                SQL = SQL + ", NUM+1 AS NR_ORDINE ";
                SQL = SQL + "FROM ( SELECT MAX(ID_LINK) AS ULTIMA,COUNT(*) AS NUM FROM E_LINK ) A ";
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

        public void Link_ModificaLink(string descrizione, string url, string id)
        {
            string SQL;

            SQL = "UPDATE E_LINK ";
            SQL = SQL + "SET TX_DESCRIZIONE='" + descrizione + "' ";
            SQL = SQL + ", TX_LINK='" + url + "' ";
            SQL = SQL + "WHERE ID_LINK=" + id;

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable Link_Datilink(string id)
        {
            string SQL;

            SQL = "SELECT * FROM E_LINK WHERE ID_LINK=" + id;

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable ElencoLink()
        {
            string SQL;

            SQL = "SELECT * FROM E_LINK ORDER BY NR_ORDINE";

            try
            {
                return objAcc.getDT(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string OrdineLink(string id)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT NR_ORDINE FROM E_LINK WHERE ID_LINK=" + id;

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["NR_ORDINE"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Link_idprec(string ordine)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_LINK FROM E_LINK WHERE NR_ORDINE=" + ordine + "-1";

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_LINK"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string Link_idsucc(string ordine)
        {
            string SQL;
            DataTable dt = new DataTable();

            SQL = "SELECT ID_LINK FROM E_LINK WHERE NR_ORDINE=" + ordine + "+1";

            try
            {
                dt = objAcc.getDT(SQL);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ID_LINK"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Link_DiminuisciOrdine(string id)
        {
            string SQL;

            SQL = "UPDATE E_LINK SET NR_ORDINE=NR_ORDINE-1 WHERE ID_LINK=" + id;

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Link_AumentaOrdine(string id)
        {
            string SQL;

            SQL = "UPDATE E_LINK SET NR_ORDINE=NR_ORDINE+1 WHERE ID_LINK=" + id;

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Link_DiminuisciOrdineDa(string ordine)
        {
            string SQL;

            SQL = "UPDATE E_LINK SET NR_ORDINE=NR_ORDINE-1 WHERE NR_ORDINE>" + ordine;

            try
            {
                objAcc.Esegui(SQL);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void EliminaLink(string id)
        {
            string SQL;

            if (ConfigurationManager.AppSettings["DB"] == "Access")
            {
                SQL = "DELETE * FROM E_LINK WHERE ID_LINK=" + id;
            }
            else
            {
                SQL = "DELETE FROM E_LINK WHERE ID_LINK=" + id;
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

        #endregion

    }
}
