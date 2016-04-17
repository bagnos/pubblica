<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MezziSocioSanitari.aspx.cs" Inherits="pa_taverne.MezziSocioSanitari" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
    <script type="text/javascript" src="js/prototype.js"></script>
    <script type="text/javascript" src="js/scriptaculous.js?load=effects,builder"></script>
    <script type="text/javascript" src="js/lightbox.js"></script>
    <link rel="stylesheet" href="lightbox.css" type="text/css" media="screen" />
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
                        <td align="center" class="TestoP" ><b>MEZZI DI TRASPORTO SOCIO SANITARI</b></td>
                    </tr>
                    <tr>
                        <td>
                        <table width="100%" cellpadding="4" cellspacing="0" border="0">
                            <tr>
                                <td class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>OPEL CORSA e OPEL MERIVA</b><br />
                                    Queste due auto sono di cilindrata 1300, sono adibite al trasporto sociale e sanitario, sono state inaugurate il 13/10/2008.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/Corsa.jpg" target="_blank" rel="lightbox[roadtrip]" title="Opel Corsa">
                                    <img width="250px" src="Immagini/Mezzi/Corsa.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/Meriva.jpg" target="_blank" rel="lightbox[roadtrip]" title="Opel Meriva">
                                    <img width="250px" src="Immagini/Mezzi/Meriva.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" style="text-align:justify;" valign="top">
                                    <b>OPEL AGILA 1200 benzina anno 2001</b><br />
                                    Autovettura , il nostro primo "muletto", attrezzata per il trasporto di sangue ed organi oltre che al trasporto sociale
                                </td>
                                <td class="TestoP" style="text-align:justify;" valign="top">
                                    <b>FIAT DUCATO 2200 JTD anno 2006</b><br />
                                    Pulmino attrezzato per trasporto disabili, può trasportare fino ad 8 (otto) persone comprese 3 carrozzine adeguatamente ancorate, dispone di pedana elettrica.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" valign="top">
                                    <a href="Immagini/Mezzi/agila.jpg" target="_blank" rel="lightbox[roadtrip]" title="OPEL AGILA 1200 benzina anno 2001">
                                    <img width="250px" src="Immagini/Mezzi/agila.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP" valign="top">
                                    <a href="Immagini/Mezzi/trasp_sociosan.jpg" target="_blank" rel="lightbox[roadtrip]" title="FIAT DUCATO 2200 JTD anno 2006">
                                    <img width="250px" src="Immagini/Mezzi/trasp_sociosan.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>FIAT DOBLO' 1900 JTD anno 2006</b><br />
                                    Autovettura, mezzo polivalente per trasporto disabili è munito di pedana per il carico di un carrozzina, è dotato di segnalatori acustici e visivi per il trasporto di organi e sangue.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/trasp_emo.jpg" target="_blank" rel="lightbox[roadtrip]" class="addToolTip" title="FIAT DOBLO' 1900 JTD anno 2006">
                                    <img width="250px" src="Immagini/Mezzi/trasp_emo.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/trasp_emo_2.jpg" target="_blank" rel="lightbox[roadtrip]" class="addToolTip" title="FIAT DOBLO' 1900 JTD anno 2006">
                                    <img width="250px" src="Immagini/Mezzi/trasp_emo_2.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" style="text-align:justify;" valign="top">
                                    <b>PEUGEOT 106 1100 benzina</b><br />
                                    Autovettura adibita al trasporto per servizi sociali e trasporto persone, auto un po' datata ma pienamente efficiente.
                                </td>
                                <td class="TestoP" style="text-align:justify;" valign="top">
                                    <b>OPEL COMBO 1700 CTDI anno 2003</b><br />
                                    Pulmino, mezzo di soccorso avanzato adibito al trasporto di persone, organi e protezione civile è dotato di faro di ricerca, gancio di traino, pedana elettrica ed attrezzature sanitarie
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" valign="top">
                                    <a href="Immagini/Mezzi/trasp_soc_carrello.jpg" target="_blank" rel="lightbox[roadtrip]" title="PEUGEOT 106 1100 benzina">
                                    <img width="250px" src="Immagini/Mezzi/trasp_soc_carrello.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP" valign="top">
                                    <a href="Immagini/Mezzi/opel_combo.jpg" target="_blank" rel="lightbox[roadtrip]" title="FIAT DUCATO 2200 JTD anno 2006">
                                    <img width="250px" src="Immagini/Mezzi/opel_combo.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center" class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>PIAGGIO PORTER</b><br />
                                    Inaugurazione 26-10-1997.<br />Primo mezzo per il trasporto socio-sanitario, munito di rampe per l'alloggiamento di una carrozzina.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2">
                                    <a href="Immagini/Mezzi/porter.jpg" target="_blank" rel="lightbox[roadtrip]" class="addToolTip" title="PIAGGIO PORTER">
                                    <img width="250px" src="Immagini/Mezzi/porter.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2">
                                <input type="button" class="Bottoni" onclick="javascript:location.href='Mezzi.aspx'" value="Indietro" />
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