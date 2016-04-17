<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificaFoto.aspx.cs" Inherits="pa_taverne.ModificaFoto" %>
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
                        <td align="center" class="TestoP"><b>AMMINISTRAZIONE SITO - ARCHIVIO FOTOGRAFICO</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        &nbsp;
                            <br />
                            <asp:Label ID="lblTitolo" runat="server" CssClass="TestoM" Font-Bold="True"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            <asp:HiddenField ID="hiOrd_Old" runat="server" />
                            <br />
                            <asp:Panel ID="pnlNew" runat="server">
                                <table style="width:100%;" border="0" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblFoto" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <b>Ordine</b></td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbOrdine" runat="server" CssClass="TextBox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <b>Titolo</b></td>
                                        <td align="left">
                                            <asp:TextBox ID="txTitolo" runat="server" CssClass="TextBox" MaxLength="255" 
                                                Width="95%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <b>Descrizione</b></td>
                                        <td align="left">
                                            <asp:TextBox ID="txDescrizione" runat="server" CssClass="TextBox" MaxLength="2000" 
                                                Width="95%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" valign="middle" align="center">
                                            <asp:Button ID="btnSalva" runat="server" CssClass="Bottoni" Text="Salva" 
                                                onclick="btnSalva_Click" />
                                            &nbsp;<asp:Button ID="btnIndietro" runat="server" CssClass="Bottoni" 
                                                Text="Indietro" onclick="btnIndietro_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
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