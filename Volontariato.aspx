<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Volontariato.aspx.cs" Inherits="pa_taverne.Volontariato" %>
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
                            <td align="center" class="TestoP"><b>IL VOLONTARIATO</b></td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="center">
                                <img src="Immagini/logo_pa.jpg" alt="" width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="center">
                                Guarda con attentamente il nostro nuovo logo
                                <br />
                                Puoi farlo ora e senz’altro non ti sfuggirà un particolare:<br />
                                <br />
                                <b>“ La forma del cuore ”.</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:justify;" class="TestoP">
                            <br />
                            Clicca <a href="Contattaci.aspx">QUI</a> per inviarci una e-mail
                            <br /><br />
                            Questa senza dubbio è l’icona che più di altre induce alla riflessione ed al confronto con noi stessi, farci mettere in discussione e magari valutare sul perché tanti servizi sociali e sanitari sono oggi possibili anche a livello di un ristretto comprensorio territoriale. 
                            <br /><br />
                            Il volontario quindi potrebbe essere definito come colui che, con il proprio cuore, con la propria personalità, le proprie motivazioni, il proprio tempo disponibile mette volontariamente a disposizione le proprie capacità in attività indirizzate all’aiuto del prossimo ed in forma gratuita. Il volontario appartenente ad una Associazione opera secondo i programmi che questa persegue, è tutelato da copertura assicurativa, è oggetto di formazione specifica nel settore, è dotato di una divisa che dovrà indossare per l’attività esterna, fa parte del gruppo più importante dell’Associazione, ha l’obbligo di riferire al proprio responsabile ogni evento anomalo, di formulare richieste, proposte, migliorie, disservizi e, non ultimo, il senso di responsabilità e la tutela della privacy della quale ogni cittadino ha diritto.
                            <br /><br />
                            Nella nostra Associazione il “Gruppo Volontari” è suddiviso in settori di attività e ciascun volontario può aderire ad una o più di queste secondo le proprie capacità o la propria disponibilità. Le nostre principali attività sono: trasporto sanitario, emergenza sanitaria, trasporto disabili, trasporto sociale, trasporto e servizi di varia natura ai propri associati, protezione civile ed ambientale, donazioni di sangue, formazione per soccorritori, servizio civile, attività ricreative, gestione del “centro prelievi”, gestione sede e amministrazione.
                        </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="center">
                                Il nostro Gruppo Volontari:<br />
                                <img src="Immagini/volontari.jpg" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td class="TestoP" align="center">
                            <asp:GridView ID="dgVolontari" runat="server" AutoGenerateColumns="False" 
                                CellPadding="2" CssClass="TabellaGenerica">
                                <Columns>
                                    <asp:BoundField DataField="TipoVol" HeaderText="Tipo Attività">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOT" HeaderText="N° Volontari">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DONNE" HeaderText="Donne" >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UOMINI" HeaderText="Uomini">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="TrHeader" />
                            </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:justify;" class="TestoP">
                                <br />
                                Far parte del nostro “gruppo volontari” non vuol dire essere considerato una unità ma, e qui sta il nostro segreto, l’appartenenza al gruppo vuol dire soprattutto aggregazione, comunicazione, dialogo, esperienze, riflessione e, non per ultimo, è considerata la fucina delle proposte in quanto chi davvero opera quotidianamente sul campo conosce meglio i bisogni dei cittadini.
                                <br />
                                <br />
                                La nostra Associazione è nata e cresciuta nel principio della solidarietà e dell’aiuto verso il prossimo e che per attuare i suoi propositi si è sempre rivolta al prossimo con la convinzione che non esiste cifra che possa pagare un atto compiuto ad un “amico”. Queste sono le motivazioni per le quali la “Pubblica Assistenza di Taverne d’Arbia” ha sempre creduto e continuerà ancora a credere che il volontariato sia un’enorme risorsa per il nostro futuro di cittadini.
                                <br />
                                <br />
                                </td>
                        </tr>
                        <tr>
                            <td align="center" class="TestoP">
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:justify;" class="TestoP">
                                Clicca <a href="Contattaci.aspx">QUI</a> per inviarci una e-mail</td>
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
