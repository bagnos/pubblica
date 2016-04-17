using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Donatori : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TabellaDonatori();
            }
            catch (Exception Ex)
            {
                lblAggregati.Text = Ex.Message;
            }
            try
            {
                lblMedia.Text = objQry.EtaMediaDonatori();
            }
            catch (Exception Ex)
            {
                lblMedia.Text = Ex.Message;
            }
            try
            {
                TabellaDonazioni();
            }
            catch (Exception Ex)
            {
                lblDonazioni.Text = Ex.Message;
            }
        }

        public void TabellaDonatori()
        {
            DataTable dtAggregati = new DataTable();

            try
            {
                dtAggregati = objQry.AggregatiDonatori();

                DataView dvAggr = new DataView(dtAggregati);
                dvAggr.RowFilter = "TIPOAGG=1";
                dvAggr.Sort = "GRUPPO";
                DataView dvTot = new DataView(dtAggregati);
                dvTot.RowFilter = "TIPOAGG=2";

                if (dvAggr.Count > 0)
                {
                    lblAggregati.Text = "<table cellpadding=\"3\" class=\"TabellaGenerica\" cellspacing=\"0\" >";
                    lblAggregati.Text = lblAggregati.Text + "<tr class=\"TrHeader\">";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\"><b>GR. SANG.</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\"><b>RH</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\"><b>TOT.</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\"><b>DONNE</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoBottom\"><b>UOMINI</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "</tr>";

                    for (int i = 0; i < dvAggr.Count; i++)
                    {
                        lblAggregati.Text = lblAggregati.Text + "<tr>";
                        lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["GRUPPO"].ToString() + "</td>";
                        lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["RH"].ToString() + "</td>";
                        lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["num"].ToString() + "</td>";
                        lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["DONNE"].ToString() + "</td>";
                        lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoBottom\" align=\"center\">" + dvAggr[i]["UOMINI"].ToString() + "</td>";
                        lblAggregati.Text = lblAggregati.Text + "</tr>";
                    }

                    lblAggregati.Text = lblAggregati.Text + "<tr>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDx\" colspan=\"2\" align=\"center\" ><b>" + dvTot[0]["GRUPPO"].ToString() + "</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDx\" align=\"center\" ><b>" + dvTot[0]["num"].ToString() + "</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td class=\"TdBordoDx\" align=\"center\" ><b>" + dvTot[0]["DONNE"].ToString() + "</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "<td align=\"center\"><b>" + dvTot[0]["UOMINI"].ToString() + "</b></td>";
                    lblAggregati.Text = lblAggregati.Text + "</tr>";

                    lblAggregati.Text = lblAggregati.Text + "</table>";
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void TabellaDonazioni()
        {
            DataTable dtAggregati = new DataTable();

            try
            {
                dtAggregati = objQry.DonazioniUltimiAnni();

                DataView dvAggr = new DataView(dtAggregati);
                dvAggr.RowFilter = "TIPOAGG=1";
                dvAggr.Sort = "GRUPPO";
                DataView dvTot = new DataView(dtAggregati);
                dvTot.RowFilter = "TIPOAGG=2";

                if (dvAggr.Count > 0)
                {
                    lblDonazioni.Text = "<table cellpadding=\"3\" class=\"TabellaGenerica\" cellspacing=\"0\" >";
                    lblDonazioni.Text = lblDonazioni.Text + "<tr class=\"TrHeader\">";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\"><b>GR. SANG.</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\"><b>RH</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\"><b>" + (DateTime.Now.Year - 1).ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\"><b>" + (DateTime.Now.Year - 2).ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoBottom\"><b>" + (DateTime.Now.Year - 3).ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "</tr>";

                    for (int i = 0; i < dvAggr.Count; i++)
                    {
                        lblDonazioni.Text = lblDonazioni.Text + "<tr>";
                        lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["GRUPPO"].ToString() + "</td>";
                        lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["RH"].ToString() + "</td>";
                        lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["_" + (DateTime.Now.Year - 1).ToString()].ToString() + "</td>";
                        lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDxBottom\" align=\"center\">" + dvAggr[i]["_" + (DateTime.Now.Year - 2).ToString()].ToString() + "</td>";
                        lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoBottom\" align=\"center\">" + dvAggr[i]["_" + (DateTime.Now.Year - 3).ToString()].ToString() + "</td>";
                        lblDonazioni.Text = lblDonazioni.Text + "</tr>";
                    }

                    lblDonazioni.Text = lblDonazioni.Text + "<tr>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDx\" colspan=\"2\" align=\"center\" ><b>" + dvTot[0]["GRUPPO"].ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDx\" align=\"center\" ><b>" + dvTot[0]["_" + (DateTime.Now.Year - 1).ToString()].ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td class=\"TdBordoDx\" align=\"center\" ><b>" + dvTot[0]["_" + (DateTime.Now.Year - 2).ToString()].ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "<td align=\"center\"><b>" + dvTot[0]["_" + (DateTime.Now.Year - 3).ToString()].ToString() + "</b></td>";
                    lblDonazioni.Text = lblDonazioni.Text + "</tr>";

                    lblDonazioni.Text = lblDonazioni.Text + "</table>";
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}
