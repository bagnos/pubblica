<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prelievi.aspx.cs" Inherits="pa_taverne.Prelievi" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    </style>
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
                        <td align="center" class="TestoP"><b>PRELIEVI DI SANGUE</b></td>
                    </tr>
                    <tr>
                        <td style="text-align:justify" class="TestoP">
                        <br />
                        L'attività è stata istituita nel 1996 con l'intento di rendere un importante servizio alla popolazione del comprensorio di Taverne, Arbia, Pancole e Ruffolo. Intento nel quale la ASL 7, credendo nella professionalità di alcune persone, ha stipulato una convenzione gratuita con l'Associazione alla quale la ASL, una volta alla settimana, fornisce il personale infermieristico per il prelievo, mentre il personale addetto all'organizzazione (prenotazione, registrazione ricette, riscossione ticket ecc. ecc.) è individuato tra i volontari dell'Associazione. 
                        <br />
                        Sempre per essere più vicini ai nostri concittadini stiamo supportando le famiglie con un servizio di ricezione delle ricette per i prelievi domiciliari con le successive fasi di prenotazione, registrazione e, quando dovuto, la predisposizione del pagamento del ticket.
                        <br />
                        La nostra organizzazione, in particolare per i prelievi domiciliari, permette alle famiglie con persone non autosufficienti di ridurre al minimo i disagi derivanti da spostamenti per pratiche strettamente burocratiche ed allo stesso tempo avere tutte le informazioni relative ad ogni specifico caso.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="TabellaGenerica" border="0" cellpadding="3" cellspacing="2" width="100%">
                                <tr class="TrHeader">
                                    <td colspan="2" align="center" class="TestoP"><b>PRELIEVI E PRENOTAZIONI AMBULATORIALI</b></td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Giorno di prelievi ambulatoriali:</b></td>
                                    <td align="left" class="TestoP" valign="middle">Martedì  ore  07.15 – 08.15 (La prenotazione è obbligatoria)</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Quando si prenota:</b></td>
                                    <td align="left" class="TestoP" valign="middle"><ul><li>Venerdì ore 16-18</li><li>Lunedì ore 16-18 (fino ad esaurimento disponibilità)</li></ul></td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Dove si Prenota:</b></td>
                                    <td align="left" class="TestoP" valign="middle"><ul><li>Taverne: in sede</li></ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Cosa serve:</b></td>
                                    <td align="left" class="TestoP" valign="middle">La ricetta medica</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Come si prenota:</b></td>
                                    <td align="left" class="TestoP" valign="middle"><ul><li>si sceglie di accedere al prelievo in una delle due fasce orarie 7:15/7:45 oppure 7:45/8:10</li><li>obblighi amministrativi quali: registrazione esami, esenzioni, autocertificazioni, pagamento ticket ecc.</li></ul>
                                    
                                    <b>Pagamento Ticket:</b> Quando dovuto – Anticipato: contestualmente al prelievo
                                    <br />
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle"><b>Accesso preferenziale:</b></td>
                                    <td align="left" class="TestoP" valign="middle">Al momento della prenotazione indicare se esistono condizioni particolari per le quali il prelievo deve essere eseguito in condizioni diverse dal solito.</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify">
                            <br />
                            <b style="color:#EE0000;"><u>IMPORTANTE!!</u></b><br /><b>Il venerdì ed il Lunedì ore 16.00 - 19.00 e Giovedì 18.00 - 19.00, siamo disponibili a fornire informazioni riguardo la propria posizione nei confronti del ticket:</b>
                            <ul><li>esenzioni per età/reddito</li><li>esenzioni per invalidità</li><li>esenzioni per patologia</li><li>conoscere quali esami di laboratorio, diagnostici o strumentali sono esenti e per quale specifica esenzione</li><li>quali invece sono soggetti al pagamento del ticket</li><li>dove vengono eseguiti i pagamenti</li><li>quali sono i tempi medi di attesa per i referti</li></ul>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="TabellaGenerica" border="0" cellpadding="3" cellspacing="2" width="100%">
                                <tr class="TrHeader">
                                    <td colspan="2" align="center" class="TestoP"><b>CONSEGNA E REFERTI AMBULATORIALI</b></td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Consegna referti:</b>
                                    </td>
                                    <td align="left" class="TestoP" valign="middle"><ul><li>I referti non saranno più consegnati manualmente ma saranno recapitati esclusivamente tramite <b>POSTA Prioritaria</b> al domicilio dell’utente</li></ul></td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="TabellaGenerica" border="0" cellpadding="3" cellspacing="2" width="100%">
                                <tr class="TrHeader">
                                    <td colspan="2" align="center" class="TestoP"><b>PRELIEVI E PRENOTAZIONI DOMICILIARI</b></td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Giorno di prelievi domiciliari:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">Martedì ore 7:45 - 9:00 (salvo 
                                        diversa indicazione)</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Quando si prenota:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">Tutti i giorni</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Dove si Prenota:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">Taverne: in sede</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Cosa serve:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">la ricetta medica (con l'indicazione di prelievo a domicilio)</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Ricette:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                                            L<span lang="IT" style="font-size:10.0pt;font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:IT">e ricette si ricevono tutti i giorni in orario 
                                            di apertura della Sede<o:p></o:p></span></p>
                                        <p class="MsoNormal" style="mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:.5in;line-height:normal">
                                            <span lang="IT" style="font-size:10.0pt;
font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:IT">Il Venerdì ed il Lunedì dalle ore 16 alle ore 18 eventuali obblighi amministrativi quali: 
                                            registrazione esami, esenzioni, autocertificazioni, pagamento ticket ecc.<span 
                                                style="mso-spacerun:yes">&nbsp; </span><o:p></o:p></span>
                                        </p>
                                        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                                            <span lang="IT" style="font-size:10.0pt;font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:IT"><o:p>&nbsp;</o:p></span></p>
                                        <b style="mso-bidi-font-weight:normal">
                                        <span lang="IT" style="font-size:10.0pt;
line-height:115%;font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:IT;mso-fareast-language:IT;mso-bidi-language:
AR-SA">Pagamento Ticket</span></b><span lang="IT" style="font-size:10.0pt;
line-height:115%;font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;mso-ansi-language:IT;mso-fareast-language:IT;mso-bidi-language:
AR-SA">:<span style="mso-spacerun:yes">&nbsp;&nbsp; </span>Quando dovuto – Anticipato: contestualmente al prelievo</span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="TabellaGenerica" border="0" cellpadding="3" cellspacing="2" width="100%">
                                <tr class="TrHeader">
                                    <td colspan="2" align="center" class="TestoP"><b>CONSEGNA E REFERTI DOMICILIARI</b></td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" style="width:30%" valign="middle">
                                        <b>Consegna referti:</b>
                                     </td>
                                    <td align="left" class="TestoP" valign="middle">I referti non saranno più consegnati manualmente ma saranno recapitati esclusivamente tramite <b>POSTA Prioritaria</b> al domicilio dell’utente</td>
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
