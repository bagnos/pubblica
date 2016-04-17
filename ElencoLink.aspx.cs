using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ElencoLink : Pagebasic
    {
        string id;
        string azione;
        int indicepagina = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                            EliminaLink(id);
                            Response.Redirect("ElencoLink.aspx");
                        }

                        if (azione == "S" && id != string.Empty)
                        {
                            Su(id);
                            Response.Redirect("ElencoLink.aspx");
                        }

                        if (azione == "G" && id != string.Empty)
                        {
                            Giu(id);
                            Response.Redirect("ElencoLink.aspx");
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
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void EliminaLink(string id)
        {
            string ordine;

            try
            {
                ordine = objQry.OrdineLink(id);
                if (ordine != string.Empty)
                {
                    objQry.Link_DiminuisciOrdineDa(ordine);
                    objQry.EliminaLink(id);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Su(string id)
        {
            string ordine;
            string id_prec = string.Empty;

            try
            {
                ordine = objQry.OrdineLink(id);
                if (ordine != string.Empty)
                {
                    id_prec = objQry.Link_idprec(ordine);
                    if (id_prec != string.Empty)
                    {
                        objQry.Link_AumentaOrdine(id_prec);
                        objQry.Link_DiminuisciOrdine(id);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Giu(string id)
        {
            string ordine;
            string id_succ = string.Empty;

            try
            {
                ordine = objQry.OrdineLink(id);
                if (ordine != string.Empty)
                {
                    id_succ = objQry.Link_idsucc(ordine);
                    if (id_succ != string.Empty)
                    {
                        objQry.Link_DiminuisciOrdine(id_succ);
                        objQry.Link_AumentaOrdine(id);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void PopolaElenco()
        {
            DataTable dtLink = new DataTable();

            try
            {
                dtLink = objQry.ElencoLink();
                dgLink.DataSource = dtLink;
                dgLink.PageIndex = indicepagina;
                dgLink.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void dgLink_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            indicepagina = e.NewPageIndex;
            PopolaElenco();
        }

        protected void dgLink_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[3].Text = "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='ModificaLink.aspx?id=" + e.Row.Cells[0].Text + "'\"><img src=\"Immagini/modifica.png\" alt=\"Modifica\" title=\"Modifica\" />&nbsp;&nbsp;";
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:Elimina('" + e.Row.Cells[0].Text + "')\"><img src=\"Immagini/cancella.png\" alt=\"Elimina\" title=\"Elimina\" />&nbsp;&nbsp;";
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:Su('" + e.Row.Cells[0].Text + "')\"><img src=\"Immagini/su.png\" alt=\"Sposta in alto\" title=\"Sposta in alto\" />&nbsp;&nbsp;";
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<a style=\"cursor:pointer;\" onclick=\"javascript:Giu('" + e.Row.Cells[0].Text + "')\"><img src=\"Immagini/giu.png\" alt=\"Sposta in basso\" title=\"Sposta in basso\" />";
                }
                e.Row.Cells[0].Visible = false;
            }
            catch(Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }
    }
}
