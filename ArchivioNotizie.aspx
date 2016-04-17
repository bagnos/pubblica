<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchivioNotizie.aspx.cs" Inherits="pa_taverne.ArchivioNotizie" %>
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
            width: 34%;
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
                        <td align="center" class="TestoP"><b>ARCHIVIO INIZIATIVE</b></td>
                    </tr>
                    <tr>
                        <td>
                        <br />
                        <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFiltri" runat="server">
                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                <tr>
                                    <td class="TestoP" valign="top"><b>Anno:</b></td>
                                    <td class="TestoP" align="left" valign="top">
                                    <asp:DropDownList ID="cmbAnno" runat="server" Width="99px"></asp:DropDownList>
                                    </td>
                                    <td class="TestoP" valign="top"><b>Tipologia:</b></td>
                                    <td class="style1" align="left" valign="top">
                                    <asp:DropDownList ID="cmbTipo" runat="server" Width="129px"></asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    <td>
                                        <asp:ImageButton ID="btnFiltra" runat="server" AlternateText="Filtra" 
                                            ImageUrl="Immagini/filtra 26x26.png" onclick="btnFiltra_Click" 
                                            ToolTip="Filtra" />
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                <tr>
                                    <td class="TestoP" style="width:50%" valign="middle" align="left">
                                        <asp:Label ID="lblFiltro" runat="server" Visible="False"></asp:Label></td>
                                    <td class="TestoP" valign="middle" align="left">
                                        <asp:ImageButton ID="btnEliFiltro" runat="server" AlternateText="Elimina Filtro" 
                                            ImageUrl="~/Immagini/toglifilto.png" ToolTip="Elimina Filtro" 
                                            onclick="btnEliFiltro_Click" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        
                            <asp:GridView ID="dgNews" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" CssClass="TabellaGenerica" 
                                onrowdatabound="dgNews_RowDataBound" AllowPaging="True" 
                                onpageindexchanging="dgNews_PageIndexChanging" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="ID_NOTIZIA" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DT_EVENTO" DataFormatString="{0:dd/MM/yy}" 
                                        HeaderText="DATA" >
                                    <ItemStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DS_TIPO" HeaderText="TIPO" />
                                    <asp:BoundField DataField="DS_TITOLO" HeaderText="TITOLO">
                                    <ItemStyle Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField >
                                    <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="TrHeader" />
                            </asp:GridView>
                        
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