<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaricaDati.aspx.cs" Inherits="pa_taverne.CaricaDati" %>
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
                        <td align="center" class="TestoP"><b>AGGIORNAMENTO DATI</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        <br /><br /><br />Il file da caricare si deve chiamare DatiXsito.mdb<br />
                            <br />
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                            <br />
                            <br />
                            <asp:Panel ID="pnlUpload" runat="server">
                                <asp:FileUpload ID="flDati" runat="server" />
                                <br />
                                <br />
                                <asp:Button ID="btnSalva" runat="server" CssClass="Bottoni" 
                                    onclick="btnSalva_Click" Text="Aggiorna i Dati" />
                            </asp:Panel>
                            <br />
                            <asp:Label ID="lblLog" runat="server" Font-Bold="True"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
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
