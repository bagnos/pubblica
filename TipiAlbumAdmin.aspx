<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipiAlbumAdmin.aspx.cs" Inherits="pa_taverne.TipiAlbumAdmin" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript">
        function Elimina(tipo) { 
        
            if(confirm("Vuoi Eliminare la Tipologia selezionata?"))
            {
                location.href = 'TipiAlbumAdmin.aspx?act=E&tipo=' + tipo;
            }
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
                        <td align="center" class="TestoP"><b>AMMINISTRAZIONE SITO - ARCHIVIO FOTOGRAFICO</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        &nbsp;<br />
&nbsp;<asp:Label ID="lblTitolo" runat="server" CssClass="TestoM" Font-Bold="True" Text="ELENCO TIPOLOGIE"></asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="txTipologia" runat="server" CssClass="TextBox" Width="60%"></asp:TextBox>
&nbsp;
                            <asp:ImageButton ID="btnAdd" runat="server" AlternateText="Aggiungi" 
                                ImageUrl="Immagini/nuovo.png" onclick="btnAdd_Click" ToolTip="Aggiungi" />
                            <br />
                            <br />
                                <asp:GridView ID="dgTipi" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CssClass="TabellaGenerica" 
                                onrowdatabound="dgTipi_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ID_TIPO_ALBUM" HeaderText="ID">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TX_TIPO_ALBUM" HeaderText="TIPOLOGIA" />
                                        <asp:BoundField DataField="N_ALBUM" HeaderText="N° ALBUM" />
                                        <asp:BoundField />
                                    </Columns>
                                    <HeaderStyle CssClass="TrHeader" />
                                </asp:GridView>
                            <br />
                            <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
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
