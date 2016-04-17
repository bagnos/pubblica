using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ElencoIscrittiNL : Pagebasic
    {
        string id;
        string azione;
        int indicepagina = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllaLogin();
            if (Session["fladmin"].ToString() != "0")
            {
                if (Request.QueryString["act"] != null && Request.QueryString["id"] != null)
                {
                    id = Request.QueryString["id"].ToString();
                    azione = Request.QueryString["act"].ToString();

                    if (azione == "E" && id != string.Empty)
                    {
                        EliminaIscritto(id);
                    }
                }
                if (!IsPostBack)
                {
                    indicepagina = 0;
                    PopolaElenco();
                }
            }
            else
            {
                Response.Redirect("Noabilitato.aspx");
            }
        }

        public void EliminaIscritto(string id)
        {
            try
            {
                objQry.EliminaIscrittoAdmin(id);
                Response.Redirect("ElencoIscrittiNL.aspx");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void PopolaElenco()
        {
            DataTable dtNL = new DataTable();

            try
            {
                dtNL = objQry.ElencoIscrittiNL();
                if (dtNL.Rows.Count > 0)
                {
                    dgNL.DataSource = dtNL;
                    dgNL.PageIndex = indicepagina;
                    dgNL.DataBind();
                }
                else
                {
                    lblErr.Text = "NON CI SONO UTENTI ISCRITTI AL SERVIZIO \"DIVENTA NOSTRO AMICO\"";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void dgNL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            indicepagina = e.NewPageIndex;
            PopolaElenco();
        }

        protected void dgNL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[4].Text.Trim() == "1")
                    {
                        e.Row.Cells[4].Text = "SI";
                    }
                    else
                    {
                        e.Row.Cells[4].Text = "NO";
                    }
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:Elimina('" + e.Row.Cells[0].Text + "')\"><img src=\"Immagini/cancella.png\" alt=\"Elimina\" title=\"Elimina\" />";
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }



    }
}
