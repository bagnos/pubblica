<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DettaglioNotizia.aspx.cs" Inherits="pa_taverne.DettaglioNotizia" %>
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
                    <asp:Panel ID="pnlNews" runat="server">
                        <table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="100%" >
                            <tr class="TrHeader">
                                <td align="center" class="TestoP" colspan="2"  >
                                <b><asp:Label ID="lblTipo" runat="server" ></asp:Label></b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoG" align="center" colspan="2" >
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TestoM" colspan="2">
                                    <b><asp:Label ID="lblDataEvento" runat="server"></asp:Label></b>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TestoM" colspan="2">
                                    <hr noshade size="3" style="color:Black" width="100%" align="center" />    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TestoM" colspan="2">
                                    <b><asp:Label ID="lblTitolo" runat="server"></asp:Label></b>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="left" class="TestoP" valign="top"><asp:Label ID="lblSottotitolo" runat="server" ></asp:Label></td>
                                <td align="right" class="TestoP" ><asp:Label ID="lblImg" runat="server"></asp:Label></td>
                            </tr>    
                            <tr>
                                <td align="left" class="TestoM" colspan="2">
                                    <hr noshade size="1" style="color:Black" width="100%" align="center" />    
                                </td>
                            </tr>   
                            </tr>
                            <tr>
                                <td class="TestoP" valign="top" colspan="2" style="width:95%; text-align:justify;">
                                    <asp:Label ID="lblTesto" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TestoM" colspan="2">
                                    <hr noshade size="1" style="color:Black" width="100%" align="center" />    
                                </td>
                            </tr> 
                            <tr>
                                <td align="left" bgcolor="#FFFFCC" class="TestoP" 
                                    valign="top" colspan="2">
                                    <b>ALLEGATO: </b>
                                    <asp:Label ID="lblAllegato" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                        ForeColor="#EE0000"></asp:Label>
                    <br />
                    <br />
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
