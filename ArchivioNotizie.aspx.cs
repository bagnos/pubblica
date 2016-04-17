using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ArchivioNotizie : Pagebasic
    {
        int indicepagina = 0;
        public static string filtro;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    filtro = string.Empty;
                    indicepagina = 0;
                    PopolaElenco(filtro);
                    ComboTipi();
                    ComboAnni();
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void ComboTipi()
        {
            DataTable dtTipi = new DataTable();

            try
            {
                dtTipi = objQry.TipiIniziativeConNullo();
                cmbTipo.DataSource = dtTipi;
                cmbTipo.DataValueField = "ID_TIPO";
                cmbTipo.DataTextField = "DS_TIPO";
                cmbTipo.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void ComboAnni()
        {
            DataTable dtAnni = new DataTable();

            try
            {
                dtAnni = objQry.AnniNews();
                cmbAnno.DataSource = dtAnni;
                cmbAnno.DataValueField = "ANNO_EVN";
                cmbAnno.DataTextField = "ANNO_EVN";
                cmbAnno.DataBind();
                cmbAnno.Items[0].Text = "";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void PopolaElenco(string Filtro)
        {
            DataTable dtNews = new DataTable();
            DataView dvNews;

            try
            {
                dtNews = objQry.TotNotizie();
                dvNews = new DataView(dtNews);
                if (Filtro != string.Empty)
                {
                    dvNews.RowFilter = Filtro;
                }
                dgNews.DataSource = dvNews;
                dgNews.PageIndex = indicepagina;
                dgNews.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void dgNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[3].Text = objUti.PrimeParole(e.Row.Cells[3].Text, 5);
                    e.Row.Cells[4].Text = "<a style=\"cursor:pointer;\" onclick=\"javascript:location.href='DettaglioNotizia.aspx?notizia=" + e.Row.Cells[0].Text + "'\">Leggi</a>";     
                }
                if (e.Row.RowType != DataControlRowType.Pager)
                {
                    e.Row.Cells[0].Visible = false;
                }
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        protected void dgNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            indicepagina = e.NewPageIndex;
            PopolaElenco(filtro);
        }

        protected void btnFiltra_Click(object sender, ImageClickEventArgs e)
        {
            string descfiltro = "<b>FILTRO ATTIVO: </b><br /><br />";

            if (cmbAnno.SelectedIndex > 0)
            {
                filtro = "ANNO_EVN=" + cmbAnno.SelectedValue;
                descfiltro = descfiltro + "ANNO INIZIATIVA: " + cmbAnno.SelectedItem.Text;
                if (cmbTipo.SelectedIndex > 0)
                {
                    filtro = filtro + " AND ID_TIPO=" + cmbTipo.SelectedValue;
                    descfiltro = descfiltro + "<br/ ><br/ >TIPO INIZIATIVA: " + cmbTipo.SelectedItem.Text;
                }
            }
            else
            {
                if (cmbTipo.SelectedIndex > 0)
                {
                    filtro = "ID_TIPO=" + cmbTipo.SelectedValue;
                    descfiltro = descfiltro + "TIPO INIZIATIVA: " + cmbTipo.SelectedItem.Text;
                }
                else
                {
                    filtro = string.Empty;
                }
            }
            if (filtro != string.Empty)
            {
                lblFiltro.Visible = true;
                lblFiltro.Text = descfiltro;
                btnEliFiltro.Visible = true;
                pnlFiltri.Visible = false;
                PopolaElenco(filtro);
            }
        }

        protected void btnEliFiltro_Click(object sender, ImageClickEventArgs e)
        {
            filtro = string.Empty;
            lblFiltro.Visible = false;
            lblFiltro.Text = string.Empty;
            btnEliFiltro.Visible = false;
            pnlFiltri.Visible = true;
            PopolaElenco(filtro);
        }
    }
}
