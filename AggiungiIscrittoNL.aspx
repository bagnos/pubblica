<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AggiungiIscrittoNL.aspx.cs" Inherits="pa_taverne.AggiungiIscrittoNL" %>
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
                        <td align="center" class="TestoP"><b>AGGIUNGI ISCRITTO AL SERVIZIO "DIVENTA NOSTRO AMICO"</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        <table width="100%" border="0" cellpadding="4" cellspacing="4">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblErr" runat="server" ForeColor="#990000" CssClass="TestoP"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnNuovoins" runat="server" CssClass="Bottoni" 
                                        onclick="btnNuovoins_Click" Text="Nuovo Inserimento" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlIscrizione" runat="server">
                                    <table width="100%" border="0" cellpadding="4" cellspacing="4">
                                        <tr>
                                <td style="width:40%;" align="right">
                                    (*) Nome Cognome:
                                </td>
                                <td style="width:60%;" align="left">
                                    <asp:TextBox ID="txNome" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:40%;" align="right">
                                    Anno di Nascita:
                                </td>
                                <td style="width:60%;" align="left">
                                    <asp:TextBox ID="txAnno" runat="server" CssClass="TextBox" Width="40%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:40%;" align="right">
                                    Comune:
                                </td>
                                <td style="width:60%;" align="left">
                                    <asp:TextBox ID="txComune" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:40%;" align="right">
                                    CAP:
                                </td>
                                <td style="width:60%;" align="left">
                                    <asp:TextBox ID="txCAP" runat="server" CssClass="TextBox" Width="40%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:40%;" align="right">
                                    (*) e-mail:
                                </td>
                                <td style="width:60%;" align="left">
                                    <asp:TextBox ID="txemail" runat="server" CssClass="TextBox" Width="40%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnIscrivi" runat="server" CssClass="Bottoni" 
                                        onclick="btnIscrivi_Click" Text="Aggiungi" />
                                </td>
                            </tr>
                            <tr>
                                <td align="justify" colspan="2">
                                    (*) Campi obbligatori
                                </td>
                            </tr>
                                    </table>
                                    </asp:Panel>
                                    
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
