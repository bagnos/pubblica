<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuoteSociali.aspx.cs" Inherits="pa_taverne.QuoteSociali" %>
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
                        <td align="center" class="TestoP"><b>QUOTE SOCIALI</b></td>
                    </tr>
                    <tr>
                        <td class="TestoM" align="center" >
                        <br /><br />
                        <table class="TabellaGenerica" cellpadding="5" cellspacing="0">
                            <tr class="TrHeader">
                              <td class="TestoP">Descrizione</td>
                              <td class="TestoP">Quota</td>
                            </tr>
                            <tr class="TestoP">
                              <td class="TdBordoDxBottom">Fino a 10 anni</td>
                              <td class="TdBordoBottom">Gratuita</td>
                            </tr>
                            <tr class="TestoP">
                              <td class="TdBordoDxBottom">Da 11 a 18 anni</td>
                              <td class="TdBordoBottom">5 &euro;</td>
                            </tr>
                            <tr class="TestoP">
                              <td class="TdBordoDxBottom">Oltre i 18 anni</td>
                              <td class="TdBordoBottom">10 &euro;</td>
                            </tr>
                            <tr class="TestoP">
                              <td class="TdBordoDxBottom">Donatori</td>
                              <td class="TdBordoBottom">Gratuita</td>
                            </tr>
                            <tr class="TestoP">
                              <td class="TdBordoDx">Volontari</td>
                              <td>Gratuita</td>
                            </tr>
                          </table>

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
