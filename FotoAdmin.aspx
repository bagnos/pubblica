<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FotoAdmin.aspx.cs" Inherits="pa_taverne.FotoAdmin" %>
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
        function Elimina(foto,album) { 
        
            if(confirm("Vuoi Eliminare la foto selezionata?"))
            {
                location.href = 'FotoAdmin.aspx?act=E&foto=' + foto + '&album=' + album;
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
                        &nbsp;
                            <br />
                            <asp:Label ID="lblTitolo" runat="server" CssClass="TestoM" Font-Bold="True"></asp:Label>
                            <br />
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td align="right" valign="middle" width="45%">
                            <asp:ImageButton ID="btnAdd" runat="server" AlternateText="Aggiungi" 
                                ImageUrl="Immagini/nuovo.png" onclick="btnAdd_Click" ToolTip="Aggiungi" />
                                    </td>
                                    <td align="left" class="TestoP" valign="middle">
                                        &nbsp;Nuova Foto&nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <br />
                                <asp:GridView ID="dgAlbum" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="3" CssClass="TabellaGenerica" 
                                onrowdatabound="dgAlbum_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ID_FOTO" HeaderText="ID">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TX_NOMEFILE" HeaderText="FOTO" />
                                        <asp:BoundField DataField="TX_TITOLO" HeaderText="TITOLO" />
                                        <asp:BoundField DataField="NM_ORDINE" HeaderText="ORDINE" />
                                        <asp:BoundField />
                                    </Columns>
                                    <HeaderStyle CssClass="TrHeader" />
                                </asp:GridView>
                            <br />
                            <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="bntIndietro" runat="server" CssClass="Bottoni" 
                                onclick="bntIndietro_Click" Text="Indietro" />
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
