using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace pa_taverne
{
    public partial class ProfiloLnx : Page
    {
        public string id_famiglia = string.Empty;
        public Utility objUti = new Utility();

        public Query objQry = new Query(new AccessoDatiLnx());


        private void ControllaLogin()
        {
            if (Session.Count == 0)
            {
                Session.Add("idsocio", string.Empty);
                Session.Add("fladmin", string.Empty);
                Session.Add("txutente", string.Empty);
            }

            if (Session["idsocio"].ToString() == string.Empty)
            {
                Response.Redirect("LoginLnx.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["idsocio"] = string.Empty;
            Session["fladmin"] = string.Empty;
            Session["txutente"] = string.Empty;
            Response.Redirect("LoginLnx.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ControllaLogin();
                DatiPersonali();
                DatiFamiglia(id_famiglia);
                Volontariato();
                DatiDonatore();
                FlagUltima();
                Donazioni();
                lblDaVersare.Text = "Ti ricordiamo che la tua quota annuale ammonta a " + objQry.Quota(Session["idsocio"].ToString()) + " €";
                if (objQry.Pagato(Session["idsocio"].ToString()))
                {
                    lblVersato.Visible = false;
                }
                else
                {
                    lblVersato.Text = "Ricorda che devi ancora versare la quota associativa relativa all'anno in corso.<br />Provvedi quanto prima!";
                }
                Pagamenti();
            }
            catch (Exception Ex)
            {
                lblErr.Text = Ex.Message;
            }
        }

        public void DatiPersonali()
        {
            DataTable dtDatiSocio = new DataTable();

            try
            {
                dtDatiSocio = objQry.DatiPersonali(Session["idsocio"].ToString());
                if (dtDatiSocio.Rows.Count > 0)
                {
                    lblNome.Text = dtDatiSocio.Rows[0]["Nome"].ToString();
                    lblCognome.Text = dtDatiSocio.Rows[0]["Cognome"].ToString();
                    lblNascita.Text = dtDatiSocio.Rows[0]["LuogoNascita"].ToString() + " " + dtDatiSocio.Rows[0]["DTNASC"].ToString();
                    lblIndirizzo.Text = dtDatiSocio.Rows[0]["Indirizzo"].ToString() + " " + dtDatiSocio.Rows[0]["Frazione"].ToString() + " " + dtDatiSocio.Rows[0]["Comune"].ToString();
                    lblIscrizione.Text = dtDatiSocio.Rows[0]["DTISCR"].ToString();;
                    if (dtDatiSocio.Rows[0]["DataFineIscrizione"].ToString().Trim() != string.Empty)
                    {
                        lblFineIscrizione.Text = "al <b>" + dtDatiSocio.Rows[0]["DataFineIscrizione"].ToString() + "</b>";
                    }
                    else
                    {
                        lblFineIscrizione.Visible = false;
                    }
                    lblTelefono.Text = dtDatiSocio.Rows[0]["Telefono"].ToString();
                    lblCellulare.Text = dtDatiSocio.Rows[0]["Cellulare"].ToString();
                    id_famiglia = dtDatiSocio.Rows[0]["NumFamiglia"].ToString();
                    lblCodSan.Text = dtDatiSocio.Rows[0]["COD_SAN"].ToString();
                    lblAnpas.Text = dtDatiSocio.Rows[0]["NumTesseraAtt"].ToString();
                    lblMedico.Text = dtDatiSocio.Rows[0]["MED_CUR"].ToString();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DatiFamiglia(string id_famiglia)
        {
            DataTable dtFamiglia = new DataTable();

            try
            {
                dtFamiglia = objQry.DatiFamiglia(id_famiglia, Session["idsocio"].ToString());
                if (dtFamiglia.Rows.Count > 0)
                {
                    dgFamiglia.DataSource = dtFamiglia;
                    dgFamiglia.DataBind();
                }
                else
                {
                    lblFamiglia1.Visible = false;
                    dgFamiglia.Visible = false;
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        
        }

        public void Volontariato()
        {
            DataTable dtVolontariato = new DataTable();

            try
            {
                dtVolontariato = objQry.DatiVolontario(Session["idsocio"].ToString());
                if (dtVolontariato.Rows.Count > 0)
                {
                    lblVolint.Text = dtVolontariato.Rows[0]["NVolInt"].ToString();
                    lblVolAnpas.Text = dtVolontariato.Rows[0]["N_Vol_Anpas"].ToString();
                    dgVolontariato.DataSource = dtVolontariato;
                    dgVolontariato.DataBind();
                }
                else
                {
                    pnlVolontariato.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void DatiDonatore()
        {
            DataTable dtDonatore = new DataTable();

            try
            {
                dtDonatore = objQry.DatiDonatore(Session["idsocio"].ToString());
                if (dtDonatore.Rows.Count > 0)
                {                    
                    dgDatiDonatore.DataSource = dtDonatore;
                    dgDatiDonatore.DataBind();
                }
                else
                {
                    pnlDonatore.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void FlagUltima()
        {
            try
            {
                if (objQry.FlagUltima(365, Session["idsocio"].ToString()))
                {
                    lblUltima.Text = "E' trascorso più di un anno dalla tua ultima donazione.<br />Attendiamo il tuo prezioso contributo quanto prima!";
                }
                else
                {
                    lblUltima.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Donazioni()
        {
            DataTable dtDonazioni = new DataTable();

            try
            {
                dtDonazioni = objQry.DonazioniSocio(Session["idsocio"].ToString());
                if (dtDonazioni.Rows.Count > 0)
                {
                    dgDonazioni.DataSource = dtDonazioni;
                    dgDonazioni.DataBind();
                }
                else
                {
                    dgDonazioni.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Pagamenti()
        {
            DataTable dtPagamenti = new DataTable();

            try
            {
                dtPagamenti = objQry.PagamentiEffettuati(Session["idsocio"].ToString());
                if (dtPagamenti.Rows.Count > 0)
                {
                    dgQuote.DataSource = dtPagamenti;
                    dgQuote.DataBind();
                }
                else
                {
                    dgQuote.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        protected void dgFamiglia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
            e.Row.Cells[6].Visible = false;
        }



    }
}
