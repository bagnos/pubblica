using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace pa_taverne
{
    public partial class Pagebasic : System.Web.UI.Page
    {
        public Utility objUti = new Utility();

        public Query objQry = new Query();

      
        public void ControllaLogin()
        {
            if (Session.Count == 0)
            {
                Session.Add("idsocio", string.Empty);
                Session.Add("fladmin", string.Empty);
                Session.Add("txutente", string.Empty);
            }

            if (Session["idsocio"].ToString() == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
        }


    }
}
