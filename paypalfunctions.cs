using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for NVPAPICaller
/// </summary>
public class NVPAPICaller
{
    //private static readonly ILog log = LogManager.GetLogger(typeof(NVPAPICaller));

    private string pendpointurl = "https://api-3t.paypal.com/nvp";
    private const string CVV2 = "CVV2";

    //Flag that determines the PayPal environment (live or sandbox)
    private const bool bSandbox = true;

    private const string SIGNATURE = "SIGNATURE";
    private const string PWD = "PWD";
    private const string ACCT = "ACCT";

    //Replace <API_USERNAME> with your API Username
    //Replace <API_PASSWORD> with your API Password
    //Replace <API_SIGNATURE> with your Signature

    public string APIUsername = "othalaBusines2_api1.othala.it";
    private string APIPassword = "1401144172";
    private string APISignature = "Arn.ArK3PQZHb0dhe4Iiiho9z4kmAZqz9IGTatMji0-4GXfaQEx4I-2S";
    private string Subject = "";
    private string BNCode = "PP-ECWizard";

    //HttpWebRequest Timeout specified in milliseconds 
    private const int Timeout = 5000;
    private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };


    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="Userid"></param>
    /// <param name="Pwd"></param>
    /// <param name="Signature"></param>
    /// <returns></returns>
    public void SetCredentials(string Userid, string Pwd, string Signature)
    {
        APIUsername = Userid;
        APIPassword = Pwd;
        APISignature = Signature;
    }

    /// <summary>
    /// ShortcutExpressCheckout: The method that calls SetExpressCheckout API
    /// </summary>
    /// <param name="amt"></param>
    /// <param ref name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool ShortcutExpressCheckout(string amt, ref string token, ref string retMsg, String anno, DataTable dtFamiglia, string nome, string socio, string amtSocio)
    {
        string host = "www.paypal.com";
        if (bSandbox)
        {
            pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
            host = "www.sandbox.paypal.com";
        }

        //String baseUrl = "http://localhost:46836";
        //String baseUrl = "http://win.pa-taverne.it";
        string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

        string returnURL = baseUrl + "/PayPalConfirmPayment.aspx";

        string cancelURL = "http://lnx.pa-taverne.it/area-riservata-2/";
        String custom = "";



        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["PAYMENTREQUEST_0_AMT"] = amt;
        encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt;
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "EUR";
        
        int j = 0;
        DataTable dtSociDaRiscuotre = new DataTable();

        for (int i = 0; i <= dtFamiglia.Rows.Count - 1; i++)
        {
            if (dtFamiglia.Rows[i]["quotaRisc"].ToString() == "0")
            {
                encoder["L_PAYMENTREQUEST_0_DESC" + j] = dtFamiglia.Rows[i]["NomeCognome"] + " Tessera  Anno " + anno;
                encoder["L_PAYMENTREQUEST_0_AMT" + j] = dtFamiglia.Rows[i]["quota"].ToString() + ".00";
                encoder["L_PAYMENTREQUEST_0_NUMER" + j] = dtFamiglia.Rows[i]["nsocio"].ToString();
                custom += " " + dtFamiglia.Rows[i]["nsocio"].ToString()+"-"+dtFamiglia.Rows[i]["quota"].ToString();
                j++;
            }
        }
        if (amtSocio != "0")
        {
            encoder["L_PAYMENTREQUEST_0_DESC" + j] = nome + " Tessera  Anno " + anno;
            encoder["L_PAYMENTREQUEST_0_AMT" + j] = amtSocio+".00";
            encoder["L_PAYMENTREQUEST_0_NUMER" + j] = socio;
            custom += " " + socio+"-"+amtSocio;
        }
        String nrFamiglia = dtFamiglia.Rows[0]["NumFamiglia"].ToString();
        encoder["PAYMENTREQUEST_0_CUSTOM"] = nrFamiglia+"-"+amt+":"+custom.Trim();


        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];

            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;

            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "esito=ko&esitoPagamento=" + decoder["L_ERRORCODE0"] + ":" + decoder["L_LONGMESSAGE0"];
            /*
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];*/

            return false;
        }
    }

    /// <summary>
    /// MarkExpressCheckout: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="amt"></param>
    /// <param ref name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool MarkExpressCheckout(string amt,
                        string shipToName, string shipToStreet, string shipToStreet2,
                        string shipToCity, string shipToState, string shipToZip,
                        string shipToCountryCode, ref string token, ref string retMsg)
    {
        string host = "www.paypal.com";
        if (bSandbox)
        {
            pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
            host = "www.sandbox.paypal.com";
        }

        string returnURL = "http://win.pa-taverne.it/PayPalConfirmPayment.aspx";
        string cancelURL = "http://win.pa-taverne.it/ProfiloLnx.aspx";

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["PAYMENTREQUEST_0_AMT"] = amt;
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "EUR";

        //Optional Shipping Address entered on the merchant site
        encoder["PAYMENTREQUEST_0_SHIPTONAME"] = shipToName;
        encoder["PAYMENTREQUEST_0_SHIPTOSTREET"] = shipToStreet;
        encoder["PAYMENTREQUEST_0_SHIPTOSTREET2"] = shipToStreet2;
        encoder["PAYMENTREQUEST_0_SHIPTOCITY"] = shipToCity;
        encoder["PAYMENTREQUEST_0_SHIPTOSTATE"] = shipToState;
        encoder["PAYMENTREQUEST_0_SHIPTOZIP"] = shipToZip;
        encoder["PAYMENTREQUEST_0_SHIPTOCOUNTRYCODE"] = shipToCountryCode;


        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];

            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;

            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }



    /// <summary>
    /// GetShippingDetails: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool GetShippingDetails(string token, ref string PayerId, ref string ShippingAddress, ref string retMsg)
    {

        if (bSandbox)
        {
            pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
        }

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "GetExpressCheckoutDetails";
        encoder["TOKEN"] = token;

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            ShippingAddress = "<table><tr>";
            ShippingAddress += "<td> First Name </td><td>" + decoder["FIRSTNAME"] + "</td></tr>";
            ShippingAddress += "<td> Last Name </td><td>" + decoder["LASTNAME"] + "</td></tr>";
            ShippingAddress += "<td colspan='2'> Shipping Address</td></tr>";
            ShippingAddress += "<td> Name </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTONAME"] + "</td></tr>";
            ShippingAddress += "<td> Street1 </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTOSTREET"] + "</td></tr>";
            ShippingAddress += "<td> Street2 </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTOSTREET2"] + "</td></tr>";
            ShippingAddress += "<td> City </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTOCITY"] + "</td></tr>";
            ShippingAddress += "<td> State </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTOSTATE"] + "</td></tr>";
            ShippingAddress += "<td> Zip </td><td>" + decoder["PAYMENTREQUEST_0_SHIPTOZIP"] + "</td>";
            ShippingAddress += "</tr>";

            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }


    /// <summary>
    /// ConfirmPayment: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool ConfirmPayment(string finalPaymentAmount, string token, string PayerId, ref NVPCodec decoder, ref string retMsg)
    {
        if (bSandbox)
        {
            pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
        }

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "DoExpressCheckoutPayment";
        encoder["TOKEN"] = token;
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYERID"] = PayerId;
        encoder["PAYMENTREQUEST_0_AMT"] = finalPaymentAmount;
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "EUR";

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }


    /// <summary>
    /// HttpCall: The main method that is used for all API calls
    /// </summary>
    /// <param name="NvpRequest"></param>
    /// <returns></returns>
    public string HttpCall(string NvpRequest) //CallNvpServer
    {
        string url = pendpointurl;

        //To Add the credentials from the profile
        string strPost = NvpRequest + "&" + buildCredentialsNVPString();
        //strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode( BNCode );
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        objRequest.Timeout = Timeout;
        objRequest.Method = "POST";
        objRequest.ContentLength = strPost.Length;

        using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
        {
            myWriter.Write(strPost);
        }



        //Retrieve the Response returned from the NVP API call to PayPal
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        string result;
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }

        //Logging the response of the transaction
        /* if (log.IsInfoEnabled)
         {
             log.Info("Result :" +
                       " Elapsed Time : " + (DateTime.Now - startDate).Milliseconds + " ms" +
                      result);
         }
         */
        return result;
    }

    /// <summary>
    /// Credentials added to the NVP string
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    private string buildCredentialsNVPString()
    {
        NVPCodec codec = new NVPCodec();

        if (!IsEmpty(APIUsername))
            codec["USER"] = APIUsername;

        if (!IsEmpty(APIPassword))
            codec[PWD] = APIPassword;

        if (!IsEmpty(APISignature))
            codec[SIGNATURE] = APISignature;

        if (!IsEmpty(Subject))
            codec["SUBJECT"] = Subject;

        codec["VERSION"] = "124";
        codec["NOSHIPPING"] = "1";
        codec["HDRIMG"] = "http://lnx.pa-taverne.it/wp/wp-content/gallery/il-logo/LogoPA.jpg";
        codec["LOGOIMG"] = "http://lnx.pa-taverne.it/wp/wp-content/gallery/il-logo/LogoPA.jpg";
        codec["BRANDNAME"] = "Pubblica Taverne Arbia Siena";

        return codec.Encode();
    }

    /// <summary>
    /// Returns if a string is empty or null
    /// </summary>
    /// <param name="s">the string</param>
    /// <returns>true if the string is not null and is not empty or just whitespace</returns>
    public static bool IsEmpty(string s)
    {
        return s == null || s.Trim() == string.Empty;
    }
}


public sealed class NVPCodec : NameValueCollection
{
    private const string AMPERSAND = "&";
    private const string EQUALS = "=";
    private static readonly char[] AMPERSAND_CHAR_ARRAY = AMPERSAND.ToCharArray();
    private static readonly char[] EQUALS_CHAR_ARRAY = EQUALS.ToCharArray();

    /// <summary>
    /// Returns the built NVP string of all name/value pairs in the Hashtable
    /// </summary>
    /// <returns></returns>
    public string Encode()
    {
        StringBuilder sb = new StringBuilder();
        bool firstPair = true;
        foreach (string kv in AllKeys)
        {
            string name = HttpUtility.UrlEncode(kv);
            string value = HttpUtility.UrlEncode(this[kv]);
            if (!firstPair)
            {
                sb.Append(AMPERSAND);
            }
            sb.Append(name).Append(EQUALS).Append(value);
            firstPair = false;
        }
        return sb.ToString();
    }

    /// <summary>
    /// Decoding the string
    /// </summary>
    /// <param name="nvpstring"></param>
    public void Decode(string nvpstring)
    {
        Clear();
        foreach (string nvp in nvpstring.Split(AMPERSAND_CHAR_ARRAY))
        {
            string[] tokens = nvp.Split(EQUALS_CHAR_ARRAY);
            if (tokens.Length >= 2)
            {
                string name = HttpUtility.UrlDecode(tokens[0]);
                string value = HttpUtility.UrlDecode(tokens[1]);
                Add(name, value);
            }
        }
    }


    #region Array methods
    public void Add(string name, string value, int index)
    {
        this.Add(GetArrayName(index, name), value);
    }

    public void Remove(string arrayName, int index)
    {
        this.Remove(GetArrayName(index, arrayName));
    }

    /// <summary>
    /// 
    /// </summary>
    public string this[string name, int index]
    {
        get
        {
            return this[GetArrayName(index, name)];
        }
        set
        {
            this[GetArrayName(index, name)] = value;
        }
    }

    private static string GetArrayName(int index, string name)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("index", "index can not be negative : " + index);
        }
        return name + index;
    }
    #endregion
}