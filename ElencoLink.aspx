<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElencoLink.aspx.cs" Inherits="pa_taverne.ElencoLink" %>
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
        function Elimina(id) { 
        
            if(confirm("Vuoi Eliminare il Link?"))
            {
                location.href = 'ElencoLink.aspx?act=E&id=' + id;
            }
        }
        function Su(id) {

            location.href = 'ElencoLink.aspx?act=S&id=' + id;
        }
        function Giu(id) {

            location.href = 'ElencoLink.aspx?act=G&id=' + id;
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
                        <td align="center" class="TestoP"><b>ELENCO LINK</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <br />
                        <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            <br />
                            <asp:GridView ID="dgLink" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" CssClass="TabellaGenerica" 
                                onrowdatabound="dgLink_RowDataBound" AllowPaging="True" 
                                onpageindexchanging="dgLink_PageIndexChanging" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="ID_LINK" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TX_DESCRIZIONE" HeaderText="DESCRIZIONE" />
                                    <asp:BoundField DataField="TX_LINK" DataFormatString="{0:dd/MM/yy}" 
                                        HeaderText="INDIRIZZO" />
                                    <asp:BoundField HeaderText="AZIONI" >
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