<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ComunicazioneNL.aspx.cs" Inherits="pa_taverne.ComunicazioneNL" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

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
                        <td align="center" class="TestoP"><b>INVIO COMUNICAZIONE AGLI ISCRITTI A "DIVENTA NOSTRO AMICO"</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <br />
                            <B>INVIA UN E-MAIL A TUTTI I CONTATTI</B><br />
                            I CAMPI OGGETTO E TESTO SONO OBBLIGATORI<br />
                            <br />
                        <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            <br />
                            <asp:Panel ID="pnlInvio" runat="server">
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td align="left">Oggetto:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txOggetto" runat="server" CssClass="TextBox" Width="395px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        Testo:</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <%--<asp:TextBox ID="txTesto" runat="server" CssClass="TextBox" Height="324px" 
                                            TextMode="MultiLine" Width="100%"></asp:TextBox>--%>
                                        <FTB:FreeTextBox id="FreeTextBox1" runat="Server" EnableHtmlMode="False" 
                                            Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnInvia" runat="server" CssClass="Bottoni" 
                                            onclick="btnInvia_Click" Text="Invia" />
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                            <br />
                                    <asp:Button ID="btnNuova" runat="server" CssClass="Bottoni" Text="Nuova Comunicazione" 
                                        onclick="btnNuova_Click" Visible="False" />
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