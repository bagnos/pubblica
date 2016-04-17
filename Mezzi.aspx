<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mezzi.aspx.cs" Inherits="pa_taverne.Mezzi" %>
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
                        <td align="center" class="TestoP"><b>I MEZZI DELLA PUBBLICA ASSISTENZA</b></td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <br />
                            <table width="100%" cellpadding="4" cellspacing="0" border="0">
                                <tr>
                                    <td align="center" class="TestoP" valign="top">
                                        <b>MEZZI DI SOCCORSO</b><br />
                                        <img alt="" style="cursor:pointer;" src="Immagini/Mezzi/trasp_eme.jpg" width="300px" onclick="javascript:location.href='MezziSoccorso.aspx'"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" valign="top">
                                        <b>MEZZI DI TRASPORTO SOCIO-SANITARIO</b><br />
                                        <img alt="" style="cursor:pointer;" src="Immagini/Mezzi/trasp_sociosan.jpg" width="300px" onclick="javascript:location.href='MezziSocioSanitari.aspx'"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="TestoP" valign="top">
                                        <b>MEZZI DELLA PROTEZIONE CIVILE</b><br />
                                        <img alt="" style="cursor:pointer;" src="Immagini/Mezzi/prot_civ2.jpg" width="300px" onclick="javascript:location.href='MezziProtCivile.aspx'"/>
                                    </td>
                                </tr>
                            </table>
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
