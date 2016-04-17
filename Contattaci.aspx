<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contattaci.aspx.cs" Inherits="pa_taverne.Contattaci" %>
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
        .style1
        {
            font-family: Tahoma;
            font-size: 10pt;
            height: 54px;
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
                        <td align="center" class="TestoP"><b>CONTATTACI</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Panel ID="pnlInvio" runat="server">
                            <table border="0" cellpadding="3" cellspacing="0">
                                <tr>
                        <td class="TestoP" align="right" valign="middle" style="width:35%;">
                            Nome e Cognome (*): </td>
                        <td class="TestoP" align="left" valign="middle" style="width:65%;">
                            <asp:TextBox ID="txNome" runat="server" CssClass="TextBox" Width="225px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                Indirizzo (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txIndirizzo" runat="server" CssClass="TextBox" Width="320px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                Città (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txCitta" runat="server" CssClass="TextBox" Width="129px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                C.A.P. (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txCap" runat="server" CssClass="TextBox" Width="81px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                Telefono (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txTelefono" runat="server" CssClass="TextBox" Width="159px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                E-Mail (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txEmail" runat="server" CssClass="TextBox" Width="234px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="right" valign="middle" style="width:35%;">
                                Messaggio (*): </td>
                            <td class="TestoP" align="left" valign="middle" style="width:65%;">
                                <asp:TextBox ID="txMessaggio" runat="server" CssClass="TextBox" Height="107px" 
                                    TextMode="MultiLine" Width="319px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="center" valign="middle" colspan="2">
                            *I campi contrassegnati con un asterisco sono obbligatori.
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" align="center" valign="middle" colspan="2">
                            
                                <asp:Button ID="btnInvia" runat="server" CssClass="Bottoni" Text="Invia" 
                                    onclick="btnInvia_Click" />
                            
                            </td>
                        </tr>
                            </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            
                                <asp:Button ID="btnNuovo" runat="server" CssClass="Bottoni" 
                                Text="Lascia un'altro messaggio" onclick="btnNuovo_Click" Visible="False" />
                            
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
