using System;
using System.Data;
using System.Web;

public partial class PayPalEC : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        NVPAPICaller test = new NVPAPICaller();
        string retMsg = "";
        string token = "";
        
        if ( HttpContext.Current.Session["payment_amt"] != null)
        {
            string amt = HttpContext.Current.Session["payment_amt"].ToString();

            bool ret = test.ShortcutExpressCheckout(amt, ref token, ref retMsg, Session["anno"].ToString(), ((DataTable)Session["famiglia"]), Session["nome"].ToString(), Session["idsocio"].ToString());
            if (ret)
            {
				HttpContext.Current.Session["token"] = token;
                ClientScript.RegisterStartupScript(this.GetType(), "loadPayPal", "top.postMessage({ \"reload\": \"" + retMsg + "\" }, '*');", true);
                //Response.Redirect( retMsg );
                Response.Write("<script>top.postMessage({ \"reload\": \"" + retMsg + "\" }, '*');</script>");



            }
            else
            {
                Response.Redirect("ProfiloLnx.aspx?" + retMsg);
            }
        }
        else
        {
            Response.Redirect("ProfiloLnx.aspx?esito=ko&esitoPagamento=AmtMissing");
        }
    }
}