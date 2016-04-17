using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace pa_taverne
{
    public partial class Giornalino : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ElencoGiornalini();
            }
            catch (Exception Ex)
            {
                lblGiornalino.Text = Ex.Message;
            }
        }

        public void ElencoGiornalini()
        {
            DataTable dtGiornalini = new DataTable();

            try
            {
                dtGiornalini = objQry.Giornalini();
                //lblGiornalino.Text = dtGiornalini.Rows.Count.ToString();
                if (dtGiornalini.Rows.Count > 0)
                {
                    lblGiornalino.Text = lblGiornalino.Text + "<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" >";
                    for (int i = 0; i < dtGiornalini.Rows.Count; i++)
                    {
                        lblGiornalino.Text = lblGiornalino.Text + "<tr>";
                        lblGiornalino.Text = lblGiornalino.Text + "<td width=\"30%\" align=\"right\" valign=\"middle\"><a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Giornalino/" + dtGiornalini.Rows[i]["TX_FILE"].ToString() + "','" + dtGiornalini.Rows[i]["TX_TITOLO"].ToString() + "','')\"><img alt=\"\" src=\"Immagini/reader.jpg\" width=\"40px\" /></a></td>";
                        lblGiornalino.Text = lblGiornalino.Text + "<td width=\"70%\" align=\"left\" valign=\"middle\"><a style=\"cursor:pointer;\" onclick=\"javascript:window.open('public/Giornalino/" + dtGiornalini.Rows[i]["TX_FILE"].ToString() + "','" + dtGiornalini.Rows[i]["TX_TITOLO"].ToString() + "','')\">" + dtGiornalini.Rows[i]["TX_TITOLO"].ToString() + "</a></td>";
                        lblGiornalino.Text = lblGiornalino.Text + "</tr>";
                       
                    }
                    lblGiornalino.Text = lblGiornalino.Text + "</table>";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
