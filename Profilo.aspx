<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profilo.aspx.cs" Inherits="pa_taverne.Profilo" %>
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
                        <td align="center" class="TestoP"><b>DATI PERSONALI DEL SOCIO</b></td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center" >
                            <br />
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                            <br />
                        <br />
                        <b>DATI PERSONALI</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoM" align="center" >
                        
                        <table class="TabellaGenerica" cellpadding="3" cellspacing="3" width="90%">
                            <tr>
                                <td class="TestoP" align="left" style="width:50%">Nome:
                                    <asp:Label ID="lblNome" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="TestoP" align="left" style="width:50%">Cognome:
                                    <asp:Label ID="lblCognome" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" colspan="2">Luogo e data di nascita: 
                                    <asp:Label ID="lblNascita" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" colspan="2">Indirizzo: 
                                    <asp:Label ID="lblIndirizzo" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" colspan="2">Iscritto dal 
                                    <asp:Label ID="lblIscrizione" runat="server" Font-Bold="True"></asp:Label>
                                &nbsp; 
                                    <asp:Label ID="lblFineIscrizione" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" style="width:50%">Telefono:
                                    <asp:Label ID="lblTelefono" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="TestoP" align="left" style="width:50%">Cellulare:
                                    <asp:Label ID="lblCellulare" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" style="width:50%">Codice Sanitario:
                                    <asp:Label ID="lblCodSan" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="TestoP" align="left" style="width:50%">Tessera Anpas:
                                    <asp:Label ID="lblAnpas" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" colspan="2">Medico Curante:
                                    <asp:Label ID="lblMedico" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblFamiglia1" runat="server" 
                                Text="ALTRI COMPONENTI DELLA FAMIGLIA ISCRITTI" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:GridView ID="dgFamiglia" runat="server" AutoGenerateColumns="False" 
                                CellPadding="1" CssClass="TabellaGenerica" 
                                onrowdatabound="dgFamiglia_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="NomeCognome" HeaderText="Nome" >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DTNASC" HeaderText="Data di Nascita">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Indirizzo" HeaderText="Indirizzo">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Frazione" HeaderText="Frazione">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Volontario" HeaderText="Volont.">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Donatore" HeaderText="Donat.">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FL_FINEISCR" HeaderText="FL_FINEISCR" />
                                </Columns>
                                <HeaderStyle CssClass="TrHeader" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Panel ID="pnlVolontariato" runat="server">
                                <asp:Label ID="lblVolontariato" runat="server" Text="ATTIVITA' DI VOLONTARIATO" 
                                Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                                Codice interno associazione:
                                <asp:Label ID="lblVolint" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                                Codice Anpas:
                                <asp:Label ID="lblVolAnpas" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                                <asp:GridView ID="dgVolontariato" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="1" CssClass="TabellaGenerica">
                                    <Columns>
                                        <asp:BoundField DataField="TipoVol" HeaderText="Tipo">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTINIZ" HeaderText="Data Inizio">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTFINE" HeaderText="Data Fine" />
                                    </Columns>
                                    <HeaderStyle CssClass="TrHeader" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Panel ID="pnlDonatore" runat="server">
                                <asp:Label ID="lblDonazioni" runat="server" 
                                Text="ATTIVITA' DI DONAZIONE DEL SANGUE" 
    Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                                <asp:GridView ID="dgDatiDonatore" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="1" CssClass="TabellaGenerica">
                                    <Columns>
                                        <asp:BoundField DataField="COD_DON" HeaderText="COD. DONATORE" />
                                        <asp:BoundField DataField="GruppoSanguigno" HeaderText="Gr.Sang.">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RH" HeaderText="RH">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FENOTIPO" HeaderText="Fenotipo">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTINIZ" HeaderText="Data Inizio Donazioni">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTFINE" HeaderText="Data Fine Donazioni">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="TrHeader" />
                                </asp:GridView>
                                <br />
                                <asp:GridView ID="dgDonazioni" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="1" CssClass="TabellaGenerica">
                                    <Columns>
                                        <asp:BoundField DataField="DTDON" HeaderText="Data Donazione">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DSTIPODON" HeaderText="Tipo Donazione">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="TrHeader" />
                                </asp:GridView>
                                <br />
                                <br />
                                <asp:Label ID="lblUltima" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblQuote" runat="server" Text="QUOTE VERSATE" 
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblDaVersare" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:Label ID="lblVersato" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                            <asp:GridView ID="dgQuote" runat="server" AutoGenerateColumns="False" 
                                CellPadding="1" CssClass="TabellaGenerica">
                                <Columns>
                                    <asp:BoundField DataField="DTPAG" HeaderText="Data Pagamento">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LuogoPagamento" HeaderText="Luogo Pagamento">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QUOTA" HeaderText="Quota versata" />
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

