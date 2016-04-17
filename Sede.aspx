<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sede.aspx.cs" Inherits="pa_taverne.Sede" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="MainTable" cellpadding="0" cellspacing="3">
            <tr>
                <td class="TdMainHeader" colspan="3" align="center"><Layout:Header ID="Header" runat="server" /></td>
            </tr>
            <tr>
                <td class="TdMainLeft" align="center" valign="top"><Layout:Left ID="Left" runat="server" /></td>
                <td class="TdMainCorpo" align="center" valign="top">
                <table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="100%" >
                    <tr class="TrHeader">
                        <td align="center" class="TestoP"><b>LA SEDE</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        <br />
                        <br />
                        Orario di apertura: <b>LUNEDI – VENERDI 09.00 - 11.00 e 15.30 - 18.00</b>
                        <br />
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                        La nostra Associazione, costituita ufficialmente nel 1974, ma già dal 1961 era 
                                    presente nel centro storico di Taverne d’Arbia, poteva contare su un’unica 
                                    stanza mal dislocata e difficilmente raggiungibile da chiunque avesse necessità 
                                    dei nostri servizi.
                        
                        <br />
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        <img src="Immagini/sede_ragazze.jpg" alt="" width="400px" />
                        <br />
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                        Nel 1995 la svolta: vengono acquisiti dei locali nella zona 
                                    nuova di Taverne, in Via A. degli Aldobrandeschi 28.                                    
                                    Nel giro di qualche anno gli attuali spazi sono diventati insufficienti 
                                    per lo sviluppo che l’Associazione ha avuto negli ultimi anni, infatti in 
                                    questo periodo sono state avviate molte attività come il trasporto 
                                    socio-sanitario, il Centro prelievi, la protezione civile, l’attività medica 
                                    ambulatoriale, le attività ricreative ecc senza contare poi sulla conduzione 
                                    istituzionale dell’Associazione con la gestione del Gruppo donatori di sangue, 
                                    della gestione dei soci, dei volontari, delle relazioni esterne, della sede 
                                    stessa.
                        
                        <br />
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        <iframe width="400" height="300" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.it/maps?f=d&amp;hl=it&amp;geocode=10504179858941631807,43.294303,11.394846%3B4461197891621960797,43.294950,11.403003%3B9492489770344671593,43.299018,11.385960&amp;saddr=via+aldobrandino+degli+aldobrandeschi+28&amp;daddr=Via+Principale%2FSS438+%4043.294303,+11.394846+to:Via+Aretina%2FSS438+%4043.294950,+11.403003+to:43.295012,11.408701+to:Strada+del+Ruffolo+%4043.299018,+11.385960&amp;mra=dpe&amp;mrcr=0&amp;mrsp=3&amp;sz=15&amp;via=1,2,3&amp;sll=43.296105,11.402822&amp;sspn=0.010557,0.019569&amp;ie=UTF8&amp;ll=43.29484,11.394947&amp;spn=0.014056,0.030041&amp;output=embed&amp;s=AARTsJqeWRIECBo-a8yBuuhJ25BIEXF_zw"></iframe><br /><small><a href="http://maps.google.it/maps?f=d&amp;hl=it&amp;geocode=10504179858941631807,43.294303,11.394846%3B4461197891621960797,43.294950,11.403003%3B9492489770344671593,43.299018,11.385960&amp;saddr=via+aldobrandino+degli+aldobrandeschi+28&amp;daddr=Via+Principale%2FSS438+%4043.294303,+11.394846+to:Via+Aretina%2FSS438+%4043.294950,+11.403003+to:43.295012,11.408701+to:Strada+del+Ruffolo+%4043.299018,+11.385960&amp;mra=dpe&amp;mrcr=0&amp;mrsp=3&amp;sz=15&amp;via=1,2,3&amp;sll=43.296105,11.402822&amp;sspn=0.010557,0.019569&amp;ie=UTF8&amp;ll=43.29484,11.394947&amp;spn=0.014056,0.030041&amp;source=embed" style="color:#0000FF;text-align:left">Visualizzazione ingrandita della mappa</a></small>
                        
                        <br />
                        <br />
                        </td>
                    </tr>
                </table>
                    
                    
                </td>
                <td class="TdMainRight" align="center" valign="top"><Layout:Right ID="Right" runat="server" /></td>
            </tr>
            <tr>
                <td class="TdMainFooter" colspan="3" align="center"><Layout:Footer ID="Footer" runat="server" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
