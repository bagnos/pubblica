using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class Right : System.Web.UI.UserControl
    {
        Query objQ = new Query();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                PopolaLink();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void ControllaLogin()
        {
            if (Session.Count==0)
            {
                btnLogout.Visible = false;
                mnuSocio.Visible = false;
                lblUtente.Visible = false;
                lblUtente.Text = string.Empty;
                btnLogin.Visible = true;
                lblDati.Visible = true;
                pnlLogin.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                mnuSocio.BackColor = System.Drawing.Color.FromName("#FFFFFF");
            }
            else
            {
                if (Session["idsocio"].ToString() != string.Empty)
                {
                    btnLogout.Visible = true;
                    mnuSocio.Visible = true;
                    lblUtente.Visible = true;
                    lblUtente.Text = "<b>" + Session["txutente"].ToString() + "</b>";
                    btnLogin.Visible = false;
                    lblDati.Visible = false;
                    pnlLogin.BackColor = System.Drawing.Color.FromName("#8F8F8F");
                    mnuSocio.BackColor = System.Drawing.Color.FromName("#8F8F8F");
                }
                else
                {
                    btnLogout.Visible = false;
                    mnuSocio.Visible = false;
                    lblUtente.Visible = false;
                    lblUtente.Text = string.Empty;
                    btnLogin.Visible = true;
                    lblDati.Visible = true;
                    pnlLogin.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                    mnuSocio.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                }
            }
        }

        public void PopolaLink()
        {
            DataTable dtLink = new DataTable();

            try
            {
                dtLink = objQ.Link();
                if (dtLink.Rows.Count > 0)
                {
                    lblLink.Text = "<table cellpadding=\"3\" class=\"TabellaGenerica\" cellspacing=\"0\" width=\"100%\" >";
                    lblLink.Text = lblLink.Text + "<tr class=\"TrHeader\">";
                    lblLink.Text = lblLink.Text + "<td class=\"TestoP\" align=\"center\"><b>LINK UTILI</b></td>";
                    lblLink.Text = lblLink.Text + "</tr>";
                    for (int i = 0; i < dtLink.Rows.Count; i++)
                    {
                        lblLink.Text = lblLink.Text + "<tr>";
                        lblLink.Text = lblLink.Text + "<td align=\"center\">";
                        lblLink.Text = lblLink.Text + "<a target=\"blank\" href=\"" + dtLink.Rows[i]["TX_LINK"].ToString() + "\">" + dtLink.Rows[i]["TX_DESCRIZIONE"].ToString() + "</a>";
                        lblLink.Text = lblLink.Text + "</td>";
                        lblLink.Text = lblLink.Text + "</tr>";
                    }
                    lblLink.Text = lblLink.Text + "</table>";
                }
                else
                {
                    lblLink.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["idsocio"] = string.Empty;
            Session["fladmin"] = string.Empty;
            Session["txutente"] = string.Empty;
            Response.Redirect("Home.aspx");
        }

        
    }
}