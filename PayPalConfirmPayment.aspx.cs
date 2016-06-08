using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa_taverne
{
    public partial class PayPalConfirmPayment : System.Web.UI.Page
    {
        
        
        String token = null;
        //String amtSocio=null;
        String payerId = null;
        String nSocio = null;
        String paymentAmt = null;
        Query query = new Query();
        DataTable dtFamiglia;
        protected void Page_Load(object sender, EventArgs e)
        {
            token = Request.QueryString["token"];
            //amtSocio = HttpContext.Current.Session["amt_socio"].ToString();
            payerId=Request.QueryString["PayerID"];
            paymentAmt = Session["payment_amt"].ToString();
            nSocio = Session["idsocio"].ToString();
            dtFamiglia = (DataTable)Session["famiglia"];
            payNow();            
        }

        protected void payNow()
        {
            String retMsg = "";
            NVPCodec nvpCodec = null;
            NVPAPICaller test = new NVPAPICaller();
            String nrFamiglia = dtFamiglia.Rows[0]["NumFamiglia"].ToString();
            bool esito=test.ConfirmPayment(paymentAmt, token, payerId, ref nvpCodec, ref retMsg);
            if (esito)
            {
                query.inserisciPagamentoOnline(nSocio, paymentAmt, nrFamiglia);
                /*
                if (amtSocio != "0")
                {
                    query.incassoTesseraSocio(nSocio, amtSocio);
                    query.inserisciPagamentoOnline(nSocio, amtSocio);
                }
                for (int i = 0; i <= dtFamiglia.Rows.Count - 1; i++)
                {
                    if (dtFamiglia.Rows[i]["quotaRisc"].ToString() == "0")
                    {
                        query.incassoTesseraSocio(dtFamiglia.Rows[i]["nsocio"].ToString(), dtFamiglia.Rows[i]["quota"].ToString());
                        query.inserisciPagamentoOnline(dtFamiglia.Rows[i]["nsocio"].ToString(), dtFamiglia.Rows[i]["quota"].ToString());
                    }
                }*/

                try
                {
                    Utility ut = new Utility();
                    ut.invioMailIncassoOnline(nSocio);

                }
                catch (Exception e)
                { 
                    //Response.Redirect("ProfiloLnx.aspx?esitoPagamento=Pagamento effettuato con successo ma comunicate alla Pubblica di Taverne il pagamento effettuato online&esito=ok&eccezione="+e.Message);
                    //return;
                    
                }
                Response.Redirect("ProfiloLnx.aspx?esitoPagamento=Pagamento effettuato con successo, i pagamenti saranno contabilizzati al perfezionamento delle operazioni bancarie.&esito=ok");
            }
            else {
                Response.Redirect("ProfiloLnx.aspx?esitoPagamento="+ retMsg+ "&esito=ko");
            }
        }

        
    }
}