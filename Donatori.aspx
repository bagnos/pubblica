<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donatori.aspx.cs" Inherits="pa_taverne.Donatori" %>
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
                        <td align="center" class="TestoP" colspan="2"><b>DONATORI</b></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                        <br />
                        <img src="Immagini/donatori.jpg" alt="" /><br />
                            <br />
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="left" style="width:50%">
                        Clicca <a href="Contattaci.aspx">QUI</a> per inviarci una e-mail
                        </td>
                        <td class="TestoP" align="right" style="width:50%">
                        <a href="#scarica">Scarica la documentazione</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            <img alt="Scarica il PDF" title="Scarica il PDF" style="cursor:pointer;" src="Immagini/Agendona.jpg" onclick="javascript:location.href='Immagini/AgendaDona_sito.pdf'" width="200px" /><br />
                            <br />
                            <img src="Immagini/goccia.jpg" alt="" width="10px" /><b>...Come nasce il gruppo</b><br />
                            La nascita del Gruppo donatori di Sangue della Pubblica Assistenza di Taverne d’Arbia risale ai primi anni degli anni ’50 come sezione della Pubblica Assistenza di Siena; come succedeva allora non erano molti i documenti scritti se non qualche ricevuta di adesione e qualche richiesta di donazione:  già queste poche testimonianze unite alla memoria di alcuni “pionieri” oggi possiamo senz’altro affermare che già a metà del secolo scorso eravamo già “in campo”.
La vera svolta si ha nel 1974 quando è nata ufficialmente l’Associazione di Pubblica Assistenza di Taverne d’Arbia  con l’integrazione del gruppo donatori in precedenza costituito come sezione diventando così un corpo unico con la nuova organizzazione e quindi completamente autonomo.
                        </td>                        
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            <img src="Immagini/goccia.jpg" alt="" width="10px" /><b>…Le aspettative del gruppo</b><br />
                            La “vita” del gruppo donatori non è mai stata semplice basti pensare a quanto si è evoluta la scienza medica e chirurgica in questi anni per capire in quale stato di apprensione venivano messi i gruppi donatori, spesso senza fondi e senza altri mezzi di comunicazione se non il passa parola o recarsi di persona dal proprio associato. Oggi, sotto questi aspetti, la situazione è notevolmente migliorata, a fronte di richieste urgenti tutti i gruppi si attivano nel cercare tra i propri associati i donatori adatti per le richieste espresse, in questi casi basta telefonare ed avere immediatamente la risposta della disponibilità del donatore oppure l’inviare un messaggio tramite posta elettronica 
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            <img src="Immagini/goccia.jpg" alt="" width="10px" /><b>...Come opera il gruppo</b><br />Da gennaio 2012 anche la nostra Associazione ha la possibilità di prenotare online il giorno e l’ora nella quale un proprio associato può recarsi a Centro Trasfusionale per la donazione.
Una possibilità da non sottovalutare, la prenotazione infatti è uno strumento che torna utile a tutti gli attori del sistema: il Centro Trasfusionale ha la possibilità di organizzare la struttura secondo il numero degli accessi previsti, il donatore accede velocemente alla donazione senza dover fare estenuanti file in attesa del proprio turno.
<b>Rivolgiti in Associazione, ore 18 – 20,  e con Agendona potrai prenotare il giorno e l’ora della tua donazione.</b>
<br /><br />
                            La composizione del gruppo:<br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP" colspan="2" >
                            <asp:Label ID="lblAggregati" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            Età media dei donatori : <b><asp:Label ID="lblMedia" runat="server"></asp:Label></b>
                            <br />
                            Donazioni ultimi 3 anni: 
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center" colspan="2" >
                            <asp:Label ID="lblDonazioni" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            Come si vede da questa piccola statistica quello che più preoccupa è l’età abbastanza alta e proprio per questo la nostra maggiore attenzione è rivolta ai giovani, sul modo di spronarli, di coinvolgerli in una azione di alto valore morale e civile e farli sentire gratificati di appartenere ad gruppo che tanto sta dando per la società.
Il responsabile, grazie ad un software che permette di conoscere on line le donazioni del nostro gruppo, è in costante contatto con il C.E.T. e si incarica della consegna dei referti degli esami eseguiti per legge al donatore oltre che fornire informazioni sugli orari dei prelievi, sui questionari propedeutici al prelievo e quant’altro venga richiesto.
Nel corso del 2007 il consiglio dell’Associazione ha percepito qualche anomalia del sistema “donazione” dei propri associati, per chiarire alcuni aspetti ha elaborato un regolamento al quale i donatori dovranno uniformarsi e del quale già è stata inviata copia a ciascuno. 
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP" colspan="2" >
                            <img src="Immagini/goccia.jpg" alt="" width="10px" /><b>...Criteri di esclusione</b><br />
                            Nell’intento di fare cosa gradita ai nostri lettori inseriamo una tabella ricavata dal D.M. del 05/03/05 che illustra i principali criteri di esclusione temporanea o permanente del potenziale donatore. Questa tabella ha un carattere puramente informativo e quindi per avere informazioni ufficiali è indispensabile contattare i medici del Centro Emotrasfusionale di Siena.
                            <br />
                            <br />
                            <br />
                            Clicca <a href="Contattaci.aspx">QUI</a> per inviarci una e-mail
                            <br />
                            <br />
                            <a name="scarica">
                            <a href="public/Doc/TabEsclusioneDon.doc" >Scarica la tabella</a> oppure <a href="EsclusioneDonazioni.aspx" >visualizza la tabella on-line</a> 
                            <br /><br />
                            <a href="public/Doc/RegIscrizioneDon.doc" >Scarica il regolamento per l'iscrizione al Gruppo Donatori</a> <br />oppure <a href="RegIscrDonatori.aspx" >visualizza il regolamento on-line</a> 
                            </a>
                            <br />
                            <br />
                            <img alt="Scarica il PDF" title="Scarica il PDF" style="cursor:pointer;" src="Immagini/Agendona.jpg" onclick="javascript:location.href='Immagini/AgendaDona_sito.pdf'" width="200px" /><br />
                            <br />
                            <br />
                            <br />
&nbsp;</td>
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