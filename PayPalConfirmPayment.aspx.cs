using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pa_taverne
{
    public partial class PayPalConfirmPayment : System.Web.UI.Page
    {
        
        
        String token = null;
        String paymentAmt=null;
        String payerId = null;
        String nSocio = null;
        Query query = new Query();
        protected void Page_Load(object sender, EventArgs e)
        {
            token = Request.QueryString["token"];
            paymentAmt = HttpContext.Current.Session["payment_amt"].ToString();
            payerId=Request.QueryString["PayerID"];
            nSocio = Session["idsocio"].ToString();
            payNow();            
        }

        protected void payNow()
        {
            String retMsg = "";
            NVPCodec nvpCodec = null;
            NVPAPICaller test = new NVPAPICaller();
            bool esito=test.ConfirmPayment(paymentAmt, token, payerId, ref nvpCodec, ref retMsg);
            if (esito)
            {                
                query.incassoTesseraSocio(nSocio, paymentAmt);
                try
                {
                    Utility ut = new Utility();
                    ut.invioMailIncassoOnline(nSocio);

                }
                catch (Exception e)
                { 
                    Response.Redirect("ProfiloLnx.aspx?esitoPagamento=Pagamento effettuato con successo ma comunicate alla Pubblica di Taverne il pagamento effettuato online&esito=ok&eccezione="+e.Message);
                    return;
                }
                Response.Redirect("ProfiloLnx.aspx?esitoPagamento=Pagamento effettuato con successo&esito=ok");
            }
            else {
                Response.Redirect("ProfiloLnx.aspx?esitoPagamento="+ retMsg+ "&esito=ko");
            }
        }

        
    }
}