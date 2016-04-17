<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElencoIscrittiNL.aspx.cs" Inherits="pa_taverne.ElencoIscrittiNL" %>
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
        
            if(confirm("Vuoi Eliminare l'utente dal servizio?"))
            {
                location.href = 'ElencoIscrittiNL.aspx?act=E&id=' + id;
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
                        <td align="center" class="TestoP"><b>ELENCO ISCRITTI "DIVENTA NOSTRO AMICO"</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        &nbsp;
                            <br />
                        <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            <br />
                        
                            <asp:GridView ID="dgNL" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" CssClass="TabellaGenerica" 
                                onrowdatabound="dgNL_RowDataBound" AllowPaging="True" 
                                onpageindexchanging="dgNL_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ID_ISCRITTO" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TX_NOME" HeaderText="NOME" />
                                    <asp:BoundField DataField="TX_COMUNE" 
                                        HeaderText="COMUNE" />
                                    <asp:BoundField DataField="TX_EMAIL" HeaderText="EMAIL" />
                                    <asp:BoundField DataField="FL_ATTIVO" HeaderText="ATTIVO" />
                                    <asp:BoundField HeaderText="AZIONI" />
                                </Columns>
                                <HeaderStyle CssClass="TrHeader" />
                            </asp:GridView>
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
