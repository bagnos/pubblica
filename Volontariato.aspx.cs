using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Volontariato : Pagebasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TabellaVolontari();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void TabellaVolontari()
        {
            DataTable dtVolontari = new DataTable();

            try
            {
                dtVolontari = objQry.AggregatiVolontari();
                dgVolontari.DataSource = dtVolontari;
                dgVolontari.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
