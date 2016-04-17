<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cinquepermille.aspx.cs" Inherits="pa_taverne.Cinquepermille" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
    <script type="text/javascript">
        function Stampa() {
            window.open('Stampa5permille.aspx', 'Stampa', 'width=600px,height=450px,fullscreen=no,menubar=no,toolbar=no,location=no')
        }
    </script>
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
                        <td align="center" class="TestoP"><b>5 PER MILLE</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="left" valign="middle">
                            <a onclick="javascript:Stampa();" style="cursor:pointer;"><img alt="Stampa" src="Immagini/icona_stampa.gif" /> Stampa</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        <img id="Banner" src="Immagini/5xmille20100.png" alt="" width="500PX" />
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
                        &nbsp;
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