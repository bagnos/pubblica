using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Associazione : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblTot.Text = objQry.TotSoci();
                lblDon.Text = objQry.TotDonatori();
                lblVol.Text = objQry.TotVolontari();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        
    }
}
