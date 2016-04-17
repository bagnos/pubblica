using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class LoginLnx : System.Web.UI.Page
    {
        public Utility objUti = new Utility();
        public Query objQry = new Query(new AccessoDatiLnx());

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtLogin = new DataTable();


            if ((txCF.Text.Trim() != string.Empty) && (txSocio.Text.Trim() != string.Empty))
            {

                try
                {
                    if (objUti.ControllaIntero(txSocio.Text.Trim()))
                    {
                        dtLogin = objQry.GetLogin(txSocio.Text.Trim(), txCF.Text.Trim());
                        if (dtLogin.Rows.Count > 0)
                        {

                            Session["idsocio"] = dtLogin.Rows[0]["NSocio"].ToString();
                            Session["fladmin"] = dtLogin.Rows[0]["LIVELLO"].ToString();
                            Session["txutente"] = dtLogin.Rows[0]["Nome"].ToString() + " " + dtLogin.Rows[0]["Cognome"].ToString().ToUpper();
                            Response.Redirect("ProfiloLnx.aspx");
                        }
                        else
                        {
                            lblErr.Text = "Utente e password errati!!";
                        }
                    }
                    else
                    {
                        lblErr.Text = "Utente e password errati!!";
                    }
                }
                catch (Exception Ex)
                {
                    lblErr.Text = Ex.Message;
                }

            }
            else
            {
                lblErr.Text = "Utente e password errati!!";
            }
        }
    }
}
