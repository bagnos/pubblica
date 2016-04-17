<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pa_taverne.Login" %>
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
                        <td align="center" class="TestoP"><b>ACCESSO AREA RISERVATA</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoG">
                        <br /><br />
                        <table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="50%">
                            <tr>
                                <td class="TestoP" align="right">
                                    Codice Fiscale:
                                </td>
                                <td class="TestoP" align="left">
                                    <asp:TextBox ID="txCF" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="right">
                                    Numero Socio:
                                </td>
                                <td class="TestoP" align="left">
                                    <asp:TextBox ID="txSocio" CssClass="TextBox" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center" colspan="2">
                                    
                                    <asp:Button ID="btnLogin" runat="server" CssClass="Bottoni" Text="Log in" 
                                        onclick="btnLogin_Click" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center" colspan="2">
                                    
                                    <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                        ForeColor="#EE0000"></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
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

