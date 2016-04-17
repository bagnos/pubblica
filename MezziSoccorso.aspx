<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MezziSoccorso.aspx.cs" Inherits="pa_taverne.MezziSoccorso" %>
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
                        <td align="center" class="TestoP" ><b>MEZZI DI SOCCORSO</b></td>
                    </tr>
                    <tr>
                        <td>
                        <table width="100%" cellpadding="4" cellspacing="0" border="0">
                            <tr>
                                <td align="center" class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>PAPA 11 - Ambulanza UMS Mod. FIAT DUCATO 2800 JTD anno 2005</b><br />
                                    Ambulanza destinata al trasporto ordinario, ha in dotazione una particolare sedia montascale che permette ad un solo soccorritore di affrontare agevolmente le scale con un paziente seduto.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2">
                                    <a href="Immagini/Mezzi/papa11.jpg" target="_blank" rel="lightbox[roadtrip]" title="PAPA 11 - Ambulanza UMS Mod. FIAT DUCATO 2800 JTD anno 2005">
                                    <img width="250px" src="Immagini/Mezzi/papa11.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>PAPA 12 - Ambulanza UMS Mod. FIAT DUCATO 2800 JTD anno 2002</b><br />
                                    La nostra prima ambulanza per le emergenze, dotata di tutte le attrezzature per il soccorso
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/papa12.jpg" target="_blank" rel="lightbox[roadtrip]" title="PAPA 12 - Ambulanza UMS Mod. FIAT DUCATO 2800 JTD anno 2002">
                                    <img width="250px" src="Immagini/Mezzi/papa12.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/papa12_2.jpg" target="_blank" rel="lightbox[roadtrip]" title="PAPA 12 - Ambulanza UMS Mod. FIAT DUCATO 2800 JTD anno 2002">
                                    <img width="250px" src="Immagini/Mezzi/papa12_2.jpg" alt=""  />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP" colspan="2" style="text-align:justify;">
                                    <b>PAPA 59 - Ambulanza UMS Mod. OPEL MOVANO 3000 TURBOD</b><br />
                                    L'ultima nata delle nostre ambulanze UMS (Unità Mobile di Soccorso). E' stata costruita per rendere il soccorso più efficace e confortevole, è leggermente più grande rispetto alle precedenti versioni permettendo così la realizzazione di un vano sulla portiera laterale sinistra dove è stato possibile inserire tutto il materiale per il soccorso dei traumatizzati.
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/papa59.jpg" target="_blank" rel="lightbox[roadtrip]" class="addToolTip" title="PAPA 59 - Ambulanza UMS Mod. OPEL MOVANO 3000 TURBOD">
                                    <img width="250px" src="Immagini/Mezzi/papa59.jpg" alt=""  />
                                    </a>
                                </td>
                                <td align="center" class="TestoP">
                                    <a href="Immagini/Mezzi/papa59_in.jpg" target="_blank" rel="lightbox[roadtrip]" class="addToolTip" title="PAPA 59 - Ambulanza UMS Mod. OPEL MOVANO 3000 TURBOD">
                                    <img width="250px" src="Immagini/Mezzi/papa59_in.jpg" alt=""  />
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

