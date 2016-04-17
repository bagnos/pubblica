<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganiSociali.aspx.cs" Inherits="pa_taverne.OrganiSociali" %>
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
                        <td align="center" class="TestoP"><b>GLI ORGANI DELL'ASSOCIAZIONE</b></td>
                    </tr>
                    <tr>
                        <td>
                        <table border="0" cellpadding="4" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                        ForeColor="#EE0000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <img alt="" src="Immagini/organigramma.JPG" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="5" cellspacing="5" width="100%">
                                        <tr class="TrHeader">
                                            <td style="width:30%" class="TestoP" align="center"><b>Presidente</b></td>
                                            <td style="width:30%" class="TestoP" align="center"><b>Vice Presidente</b></td>
                                            <td style="width:40%" class="TestoP" align="center"><b>Consiglieri</b></td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%" class="TestoP" valign="top" align="center">
                                                <asp:Label ID="lblPresidente" runat="server"></asp:Label>
                                            </td>
                                            <td style="width:30%" class="TestoP" valign="top" align="center">
                                                <asp:Label ID="lblVice" runat="server"></asp:Label>
                                            </td>
                                            <td style="width:40%" class="TabellaGenerica" rowspan="2" valign="top" align="center">
                                                <asp:Label ID="lblConsiglio" runat="server" CssClass="TestoP"></asp:Label>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td class="TestoP" colspan="2" style="text-align:left" valign="middle">
                                                <b>Il presidente</b> ha la legale rappresentanza dell’Associazione e risponde all’assemblea sull’operato del consiglio.<br />
                                                <b>Il vice presidente</b> sostituisce il presidente nei casi di assenza o impedimento del presidente. 
                                                <b>Tutti i componenti del consiglio</b> intraprendono le azioni necessarie per il raggiungimento degli obiettivi indicati dall’assemblea.
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left">
                                    <b>Le Responsabilità dei Consiglieri</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left">
                                    
                                    <asp:Label ID="lblResponsabilita" runat="server"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center">
                                    
                                    <asp:Label ID="lblRevisori" runat="server"></asp:Label>
                                </td>
                            </tr>
<tr>
                                <td class="TestoP" align="center" style="color:#0000AA">
                                    
                                    <b>ROMOLO LENZI dal 19/11/2012 al 31/07/2014, dimesso per intervenuti incarichi pubblici</b>  
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" style="text-align:justify;">
                                Il <b>Collegio dei revisori</b> dei conti è organo di controllo interno.
Ha il compito di garantire che l'attività amministrativa sia conforme agli obiettivi stabiliti dalla legge.
                                    <br />
                                                                        Collabora con il Consiglio nello svolgimento della sua funzione di indirizzo e di controllo.
Svolge la funzione di vigilanza sulla regolarità contabile, finanziaria ed economica della gestione.
                                    <br />
                                                                        Esprime pareri obbligatori sulla proposta di bilancio di previsione e consuntivo e sui documenti allegati, nonché sulle variazioni delle voci di bilancio.<br />
                                                                        Predispone una relazione sullo schema di rendiconto della gestione.
                                    <br />
                                                                        Il collegio dei revisori partecipa alle riunioni del Consiglio (senza diritto di voto) quando all’ordine del giorno sono previsti argomenti di carattere economico, esprime pareri obbligatori sulle delibere del Consiglio quando queste interessano importanti impegni economici.
                                    <br />
                                    La durata in carica del collegio è di 3 anni e viene rinnovato insieme agli altri organi sociali.

                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center">
                                    
                                    <asp:Label ID="lblProvi" runat="server"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" style="text-align:justify;">
                                    <b>I probiviri  (collegio dei probiviri)</b> sono i cosiddetti "uomini onesti", persone che, per particolare autorità morale, sono investite di poteri giudicanti e arbitrali sull'andamento dell’associazione, sugli eventuali contrasti interni  ed assumono il compito di risolvere eventuali contrasti tra i soci o tra il consiglio direttivo ed i soci.  Il collegio si riunisce ogni qualvolta il Consiglio ne chiede il parere oppure quando è investito direttamente nelle controversie di cui sopra.
                                    <br />
                                    Il parere del collegio deve essere redatto in forma scritta e recapitato, oltre che al Consiglio, a tutti gli interessati coinvolti nella controversia non oltre 20 giorni dalla presa in carico della pratica anche nel caso in cui non si sia addivenuti ad un giudizio finale.<br />
                                Il parere del collegio dei probiviri è insindacabile.
                                    <br />
                                    La durata in carica del collegio è di 3 anni e viene rinnovato insieme agli altri organi sociali.

                                </td>
                            </tr>
                        </table>
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
