<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NuovaIniziativa.aspx.cs" Inherits="pa_taverne.NuovaIniziativa" %>
<%@ Register Tagprefix="Layout" TagName="Header" Src="Header.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Left" Src="Left.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Right" Src="Right.ascx" %>
<%@ Register Tagprefix="Layout" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <link href="Stili.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
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
                        <td align="center" class="TestoP"><b>NUOVA INIZIATIVA</b></td>
                    </tr>
                    <tr>
                        <td class="TestoM" align="center" >
                            <br />
                            <b>NUOVA INIZIATIVA</b>
                            <br />
                            <br />
                            <asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
                                ForeColor="#EE0000"></asp:Label>
                            <br />
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        <table cellpadding="3" cellspacing="0" width="90%">
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                <b>Tipologia di iniziativa</b> 
                                    <asp:DropDownList ID="cmbTipo" runat="server" CssClass="TestoP" Width="192px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Data Evento:</b>
                                    <br />
                                    <asp:Calendar ID="calEvento" runat="server" BackColor="White" 
                                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                        ForeColor="#003399" Height="200px" Width="220px">
                                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                        <WeekendDayStyle BackColor="#CCCCFF" />
                                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                        <OtherMonthDayStyle ForeColor="#999999" />
                                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    </asp:Calendar>
                                    <br />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Foto:</b>
                                    &nbsp;<asp:FileUpload ID="upFoto" runat="server" />
                                    &nbsp;<asp:Button ID="btnAddFoto" runat="server" CssClass="Bottoni" 
                                        Text="Aggiungi Foto" onclick="btnAddFoto_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <asp:Label ID="lblDescFoto" runat="server" Font-Bold="True" 
                                        Text="Descrizione Foto:"></asp:Label>
                                    <b>
                                    <asp:TextBox ID="txDescFoto" runat="server" CssClass="TextBox" Width="273px"></asp:TextBox>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>&nbsp;</b><asp:Label ID="lblFoto" runat="server"></asp:Label>
                                    &nbsp;<asp:Button ID="btnEliFoto" runat="server" CssClass="Bottoni" 
                                        Text="Elimina Foto" onclick="btnEliFoto_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Titolo (*):</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <asp:TextBox ID="txTitolo" runat="server" CssClass="TextBox" Width="395px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Sottotitolo&nbsp; (*):</b></td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b><asp:TextBox ID="txSottotitolo" runat="server" CssClass="TextBox" 
                                        Width="395px" Height="66px" TextMode="MultiLine"></asp:TextBox>
                                    </b></td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Testo&nbsp; (*):</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>
                                    <%--<asp:TextBox ID="txTesto" runat="server" CssClass="TextBox" 
                                        Width="100%" Height="324px" TextMode="MultiLine"></asp:TextBox>--%>
                                    <FTB:FreeTextBox id="FreeTextBox1" runat="Server" EnableHtmlMode="False" 
                                            Width="100%" />
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Visualizza in Home:</b>
                                    <asp:DropDownList ID="cmbHome" runat="server">
                                        <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <b>Allegato:                                     <asp:FileUpload ID="upAllegato" runat="server" />
                                &nbsp;<asp:Button ID="btnAddAllegato" runat="server" CssClass="Bottoni" 
                                        Text="Aggiungi Allegato" onclick="btnAddAllegato_Click" />
                                    </b>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <asp:Label ID="lblDescAllegato" runat="server" Font-Bold="True" 
                                        Text="Descrizione Allegato:"></asp:Label>
                                    <b>
                                    <asp:TextBox ID="txDescAllegato" runat="server" CssClass="TextBox" 
                                        Width="273px"></asp:TextBox>
                                    </b>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="left" valign="middle">
                                    <asp:Label ID="lblAllegati" runat="server"></asp:Label>
                                    
                                    <br />
                                    <br />
                                    <asp:Button ID="btnEliAllegato" runat="server" CssClass="Bottoni" 
                                        Text="Elimina Allegato" onclick="btnEliAllegato_Click" Visible="False" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center" valign="middle">
                                    <b>&nbsp;(*) Campi obbligatori</b></td>
                            </tr>
                            <tr>
                                <td class="TestoP" align="center" valign="middle">
                                    <asp:Button ID="btnSalva" runat="server" CssClass="Bottoni" Text="Salva" 
                                        onclick="btnSalva_Click" />
                                &nbsp;<asp:Button ID="btnAnnulla" runat="server" CssClass="Bottoni" 
                                        Text="Annulla" />
                                </td>
                            </tr>
                        </table>
                            <br />
                            &nbsp;
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