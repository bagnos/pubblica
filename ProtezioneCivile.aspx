<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProtezioneCivile.aspx.cs" Inherits="pa_taverne.ProtezioneCivile" %>
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
                        <td align="center" class="TestoP"><b>PROTEZIONE CIVILE AMBIENTALE</b></td>
                    </tr>
                    <tr>
                        <td align="center">
                        <br />
                        <img alt="" src="Immagini/protciv_logo.jpg" />
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                            Altro importante settore di attività che l’Associazione si è voluto dare riguarda la protezione civile a scopo ambientale, tema sul quale la nostra sensibilità di cittadini vuole farsi partecipe affinché tutti, istituzioni comprese, provvedano ad intraprendere iniziative per la tutela  dell’ambiente che ci circonda come i dissesti idrogeologici, la manutenzione del fiume Arbia e quant’altro possa arrecare danno al nostro territorio.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <b>Se sei interessato alla nostra attività <a href="Contattaci.aspx">inviaci una e-mail</a> oppure contatta telefonicamente l’Associazione.</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP"><img alt="" src="Immagini/prot_civ4.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP">
                        Nell’intento di perseguire gli obiettivi che l’Associazione si era posta già dal 2004 ha costituito un gruppo  al quale affidare le problematiche del settore: Protezione civile.
                        <br />
                        Un settore in cui la nostra Associazione mira ad investire tempo,  risorse umane ed economiche per poter intervenire in situazioni di emergenza, come nell’alluvione che ha colpito Sinalunga nel 2006 o le minacce di esondazione dei nostri torrenti e fiumi oppure, nelle ultime nevicate, lo spargimento del sale nei marciapiedi ecc., ma anche il controllo del territorio.
                        <br />
                        Il gruppo, fresco di un importante corso di preparazione e formazione durato due mesi, finanziato dal CESVOT (Centro servizi Volontariato Toscano), e realizzato con la collaborazione di esperti del settore della Provincia di Siena, pur nella sua autonomia opera costantemente in collaborazione delle istituzioni locali.
                        <br />
                        La presenza nel gruppo di alcuni volontari che hanno prestato la loro opera ad eventi drammatici come il terremoto dell’Irpinia, quello dell’Umbria, l’alluvione di Alba  rafforzano ancor di più la voglia di essere pronti per poter affrontare emergenze di quella portata.
                        <br /><br />
                        I volontari che al momento fanno parte del gruppo sono 35 tra i quali  30 uomini e 5 donne e dispongono di diverse attrezzature e di alcun mezzi:
                        <ul>
                            <li>un fuoristrada munito di verricello e gancio di traino</li>
                            <li>un’autovettura ed un pulmino per gli spostamenti</li>
                            <li>un carrello per il trasporto di materiale – tenda da 8 posti, sacchi a pelo, brandine, 2  generatori di corrente, fari alogeni per l’illuminazione del campo ecc</li>
                            <li>un carrello per il trasporto di 2 pompe idrovore ed altre ad immersione</li>
                            <li>un carrello per il trasporto di una barca con equipaggiamento di salvataggio</li>
                        </ul>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <img alt="" src="Immagini/prot_civ3.jpg" /><br /><br /><img alt="" src="Immagini/prot_civ5.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            Il gruppo, per assolvere al meglio le proprie funzioni, ha bisogno di persone volenterose che abbiano un po’ di tempo libero e un po’ di disponibilità da dedicare al settore.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <b>Se sei interessato alla nostra attività <a href="Contattaci.aspx">inviaci una e-mail</a> oppure contatta telefonicamente l’Associazione.</b>
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