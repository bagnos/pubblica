<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giornalino.aspx.cs" Inherits="pa_taverne.Giornalino" %>
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
                        <td align="center" class="TestoP"><b>GIORNALINO</b></td>
                    </tr>
                    <tr>
                        <td align="center">
                        <img alt="" src="Immagini/logo_giornalino.jpg" width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                         "PUBBLICA NOTIZIA" è il nostro periodico trimestrale e viene distribuito gratuitamente a 2700 famiglie tra Taverne, Arbia, Casetta, Pancone, Ruffolo e Siena.
E’ considerato lo strumento di comunicazione più importante, quello con cui l’Associazione riesce ad entrare nelle case per far conoscere la propria attività ed i principali accadimenti nella vita sociale della zona.    
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblGiornalino" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">Per visualizzare correttamente i file scarica l'ultima versione di Adobe Acrobat Reader da <a href="http://get.adobe.com/it/reader/" target="_blank">questo sito.</a></td>
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