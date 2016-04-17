<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Associazione.aspx.cs" Inherits="pa_taverne.Associazione" %>
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
                        <td align="center" class="TestoP"><b>L'ASSOCIAZIONE</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                            <br />
                            L'Associazione di Pubblica Assistenza di Taverne d'Arbia  già dal 1961 comincia a  darsi i primi documenti sociali 
                                grazie ad alcuni "pionieri" che già si interessavano di problemi  socio-sanitari della zona, in particolare 
                                da qualche anno erano impegnati nel  settore "sangue",  settore nel quale devono  ricercarsi le vere origini dell'Associazione.
                                <br />
                                Nel 1961 infatti il primo atto strutturale dell'Associazione  &ndash; lo statuto &ndash; anche se non ufficialmente registrato
                                , già dettava delle regole,  indicava gli obiettivi e le attività che il gruppo era chiamato ad assolvere.   
                                Un pensiero va senz'altro rivolto ai nostri  predecessori  dei quali si vogliono fornire i  nomi per il solo scopo di un doveroso ringraziamento: 
                                <br />
                                <br />
                                Lido Fabiani, Guido Roncucci, Otello Parenti, Rolando  Lucattelli, Nello Burroni, Fortunato Fusi, Aldo Formichi, Primo Giannetti
                                ,  Mario Cannoni, Otello Cannoni, Torello Chechi senza dimenticare il capostipite  dell'Associazione Otello Nencini che con la sua 
                                opera quotidiana ha permesso la  nascita e l'espansione dell'attività associativa. 
                                <br />
                                <br />
                                L'Associazione conta oggi circa 
                            <asp:Label ID="lblTot" runat="server" Font-Bold="True"></asp:Label>
&nbsp;soci dei quali 
                            <asp:Label ID="lblDon" runat="server" Font-Bold="True"></asp:Label>
&nbsp;donatori e 
                            <asp:Label ID="lblVol" runat="server" Font-Bold="True"></asp:Label>
&nbsp;volontari attivi. 
                                <br />
                                <br />
                                Le principali attività dell'Associazione sono rivolte a:
                                <ul>
                                <li>Assistenza  socio-sanitaria</li>
                                <li>Trasporto  socio-sanitario</li>
                                <li>Soccorso  avanzato</li>
                                <li>Trasporto  organi e sangue</li>

                                <li>Trasporto  assistito disabili</li>
                                <li>Donazioni  di sangue</li>
                                <li>Protezione  civile ambientale</li>
                                <li>Formazione  volontari</li>
                                <li>Attività  medica ambulatoriale</li>
                                <li>Attività  ricreative</li>
                                </ul>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                        
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