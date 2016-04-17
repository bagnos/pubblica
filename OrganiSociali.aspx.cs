using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class OrganiSociali : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Consiglio();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void Consiglio()
        {
            DataTable dtConsiglio = new DataTable();
            
            try
            {
                dtConsiglio = objQry.Consiglio();

                DataView dvPresCons = new DataView(dtConsiglio);
                DataView dvVice = new DataView(dtConsiglio);
                DataView dvConsiglieri = new DataView(dtConsiglio);
                DataView dvResponsabilita = new DataView(dtConsiglio);
                DataView dvRevisori = new DataView(dtConsiglio);
                DataView dvProvi = new DataView(dtConsiglio);

                dvPresCons.RowFilter = "ID_STRUTTURA=1 and ID_CARICA=1";
                dvVice.RowFilter = "ID_STRUTTURA=1 and ID_CARICA=2";
                dvConsiglieri.RowFilter = "ID_STRUTTURA=1 and ID_CARICA=3";
                dvConsiglieri.Sort = "NUM_VOTI DESC";
                dvResponsabilita.RowFilter = "ID_STRUTTURA=1 and TX_RESPONSABILITA IS NOT NULL";
                dvResponsabilita.Sort = "ID_CARICA";
                dvRevisori.RowFilter = "ID_STRUTTURA=3";
                dvRevisori.Sort = "ID_CARICA";
                dvProvi.RowFilter = "ID_STRUTTURA=2";
                dvProvi.Sort = "ID_CARICA";



                if (dvPresCons.Count > 0)
                {
                    lblPresidente.Text = dvPresCons[0]["Nome"].ToString() + " " + dvPresCons[0]["Cognome"].ToString();
                }
                if (dvVice.Count > 0)
                {
                    lblVice.Text = dvVice[0]["Nome"].ToString() + " " + dvVice[0]["Cognome"].ToString();
                }
                for (int i = 0; i < dvConsiglieri.Count; i++)
                {
                    lblConsiglio.Text = lblConsiglio.Text + dvConsiglieri[i]["Nome"].ToString() + " " + dvConsiglieri[i]["Cognome"].ToString() + "<br /><br />";
                }
                for (int i = 0; i < dvResponsabilita.Count; i++)
                {
                    lblResponsabilita.Text = lblResponsabilita.Text + "<b>" + dvResponsabilita[i]["Nome"].ToString() + " " + dvResponsabilita[i]["Cognome"].ToString() + ":</b> " + dvResponsabilita[i]["TX_RESPONSABILITA"].ToString() + "<br /><br />";
                }
                if (dvRevisori.Count > 0)
                {
                    lblRevisori.Text = "<table class=\"TabellaGenerica\" cellpadding=\"4\" cellspacing=\"1\" width=\"50%\">";
                    lblRevisori.Text = lblRevisori.Text + "<tr class=\"TrHeader\">";
                    lblRevisori.Text = lblRevisori.Text + "<td class=\"TestoP\" align=\"center\" colspan=\"2\"><b>REVISORI DEI CONTI</b></td>";
                    lblRevisori.Text = lblRevisori.Text + "</tr>";
                    lblRevisori.Text = lblRevisori.Text + "<tr class=\"TrHeaderChiara\">";
                    lblRevisori.Text = lblRevisori.Text + "<td class=\"TestoP\" align=\"left\"><b>SOCIO</b></td>";
                    lblRevisori.Text = lblRevisori.Text + "<td class=\"TestoP\" align=\"left\"><b>CARICA</b></td>";
                    lblRevisori.Text = lblRevisori.Text + "</tr>";

                    for (int i = 0; i < dvRevisori.Count; i++)
                    {
                        lblRevisori.Text = lblRevisori.Text + "<tr>";
                        lblRevisori.Text = lblRevisori.Text + "<td class=\"TestoP\" align=\"left\">" + dvRevisori[i]["Nome"].ToString() + " " + dvRevisori[i]["Cognome"].ToString() + "</td>";
                        lblRevisori.Text = lblRevisori.Text + "<td class=\"TestoP\" align=\"left\">" + dvRevisori[i]["DS_CARICA"].ToString() + "</td>";
                        lblRevisori.Text = lblRevisori.Text + "</tr>";
                    }

                    lblRevisori.Text = lblRevisori.Text + "</table>";
                }

                if (dvProvi.Count > 0)
                {
                    lblProvi.Text = "<table class=\"TabellaGenerica\" cellpadding=\"4\" cellspacing=\"1\" width=\"50%\">";
                    lblProvi.Text = lblProvi.Text + "<tr class=\"TrHeader\">";
                    lblProvi.Text = lblProvi.Text + "<td class=\"TestoP\" align=\"center\" colspan=\"2\"><b>PROBIVIRI</b></td>";
                    lblProvi.Text = lblProvi.Text + "</tr>";
                    lblProvi.Text = lblProvi.Text + "<tr class=\"TrHeaderChiara\">";
                    lblProvi.Text = lblProvi.Text + "<td class=\"TestoP\" align=\"left\"><b>SOCIO</b></td>";
                    lblProvi.Text = lblProvi.Text + "<td class=\"TestoP\" align=\"left\"><b>CARICA</b></td>";
                    lblProvi.Text = lblProvi.Text + "</tr>";

                    for (int i = 0; i < dvRevisori.Count; i++)
                    {
                        lblProvi.Text = lblProvi.Text + "<tr>";
                        lblProvi.Text = lblProvi.Text + "<td class=\"TestoP\" align=\"left\">" + dvProvi[i]["Nome"].ToString() + " " + dvProvi[i]["Cognome"].ToString() + "</td>";
                        lblProvi.Text = lblProvi.Text + "<td class=\"TestoP\" align=\"left\">" + dvProvi[i]["DS_CARICA"].ToString() + "</td>";
                        lblProvi.Text = lblProvi.Text + "</tr>";
                    }

                    lblProvi.Text = lblProvi.Text + "</table>";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
