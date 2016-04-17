<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegIscrDonatori.aspx.cs" Inherits="pa_taverne.RegIscrDonatori" %>
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
                        <td align="center" class="TestoP"><b>REGOLAMENTO GRUPPO DONATORI</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        <b>PUBBLICA  ASSISTENZA  DI  TAVERNE D’ARBIA</b><br />
                        Via A. degli Aldobrandeschi, 28 – Taverne A.<br />
                        Tel. 0577 365000   Fax 0577 365097<br />
                        e-mail <a href="mailto:pa.taverne@tin.it">pa.taverne@tin.it</a>  -  www.pa-taverne.it<br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:justify;" class="TestoP">
                        Oggetto: <u>Regolamento per l’iscrizione e comportamento del donatore di sangue.</u><br />
                        L’iscrizione al gruppo donatori di sangue è imprescindibile dall’essere soci dell’Associazione e, viceversa,  il socio dimissionario dall’Associazione perde automaticamente anche l’appartenenza al gruppo donatori.
                            <br />
                                                        Il socio donatore, oltre che godere dei vantaggi riservati ai soci, ha diritto ad ulteriori riconoscimenti a partire dalla gratuità della tessera sociale, a quella di donatore e da altre iniziative che il consiglio intraprende dedicate ai donatori.
                            <br />
                                                        Il socio, donatore o no, ha l’obbligo di comunicare tempestivamente all’Associazione ogni variazione sia di domicilio che di recapito telefonico.
                            <br />
                                                        I requisiti minimi per l’iscrizione a donatore sono: età maggiore di 18 anni e minore di 65 anni, peso corporeo di almeno 50 Kg, pressione arteriosa non troppo bassa e neanche alta, in generale se si ha buona salute.
                            <br />
                                                        Il socio donatore, per la sua attività donataria, è supportato dall’Associazione in relazione alle informazioni preliminari, alla registrazione dell’avvenuta donazione, alla consegna gratuita dei referti, sia manualmente che per posta, susseguenti agli esami eseguiti per legge.
                            <br />
                                                        Il socio donatore, in occasione della donazione di sangue, piastrine, plasma ecc, ha l’obbligo di dichiarare, sia verbalmente che con la presentazione della propria tessera personale, che la donazione deve essere imputata alla nostra Associazione.
                            <br />
                                                        Il socio donatore, che per i più svariati motivi, non può effettuare donazioni per almeno sei mesi deve avvertire l’Associazione affinché possa adempiere agli obblighi che ha verso il Centro Emotrasfusionale.
                            <br />
                                                        Il socio donatore o qualsiasi altra persona può donare il sangue più di una volta all’anno, in linea di massima ogni sei mesi, ma almeno una volta.
                            <br />
                                                        Il donatore, di solito, non viene chiamato per effettuare donazioni quindi spontaneamente può presentarsi al Centro Trasfusionale delle Scotte quando vuole. 
Eccezionalmente, in caso di carenza di sangue segnalata dal C.E.T., i donatori saranno chiamati telefonicamente o a mezzo e-mail affinché possano effettuare la donazione al più presto.<br />
                            <br />
                            <u>Esclusione dal gruppo donatori:</u> a) il donatore che non effettua donazioni da oltre un anno senza che abbia comunicato all’Associazione il motivo o che dopo essere stato contattato non effettua comunque la donazione,   b)  l’effettuazione di donazioni per altra Associazione,  c)  per dimissioni volontarie,  per motivi di salute, per raggiunto limite di età,  d)  per dimissioni da socio dell’Associazione.
                            <br /><br />
                            Per informazioni più dettagliate rivolgersi in Associazione oppure inviare un messaggio in posta elettronica.
                        </td>
                    </tr>
                    <tr>
                        <td align="center"class="TestoP">
                            Il Consiglio
                        </td>
                    </tr>
                    <tr>
                        <td align="left"class="TestoP">
                            Taverne A. 12/09/2007
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
