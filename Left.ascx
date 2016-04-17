<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="pa_taverne.Left" %>
<style type="text/css">

/*Modify attributes of #contentwrapper below as desired*/
#contentwrapper{
width: 90%;
height: 200px;
border: 1px solid black;
background-color: #99CBFF;
padding: 5px;
}

.billcontent{
width: 100%;
display:block;
}

</style>

<script type="text/javascript">

    /***********************************************
    * DHTML Billboard script- © Dynamic Drive (www.dynamicdrive.com)
    * This notice must stay intact for use
    * Visit http://www.dynamicdrive.com/ for full source code
    ***********************************************/

    //List of transitional effects to be randomly applied to billboard:
    var billboardeffects = ["GradientWipe(GradientSize=1.0 Duration=0.7)", "Inset", "Iris", "Pixelate(MaxSquare=5 enabled=false)", "RadialWipe", "RandomBars", "Slide(slideStyle='push')", "Spiral", "Stretch", "Strips", "Wheel", "ZigZag"]

    //var billboardeffects=["Iris"] //Uncomment this line and input one of the effects above (ie: "Iris") for single effect.

    var tickspeed = 3500 //ticker speed in miliseconds (2000=2 seconds)
    var effectduration = 500 //Transitional effect duration in miliseconds
    var hidecontent_from_legacy = 1 //Should content be hidden in legacy browsers- IE4/NS4 (0=no, 1=yes).

    var filterid = Math.floor(Math.random() * billboardeffects.length)

    document.write('<style type="text/css">\n')
    if (document.getElementById)
        document.write('.billcontent{display:none;\n' + 'filter:progid:DXImageTransform.Microsoft.' + billboardeffects[filterid] + '}\n')
    else if (hidecontent_from_legacy)
        document.write('#contentwrapper{display:none;}')
    document.write('</style>\n')

    var selectedDiv = 0
    var totalDivs = 0

    function contractboard() {
        var inc = 0
        while (document.getElementById("billboard" + inc)) {
            document.getElementById("billboard" + inc).style.display = "none"
            inc++
        }
    }

    function expandboard() {
        var selectedDivObj = document.getElementById("billboard" + selectedDiv)
        contractboard()
        if (selectedDivObj.filters) {
            if (billboardeffects.length > 1) {
                filterid = Math.floor(Math.random() * billboardeffects.length)
                selectedDivObj.style.filter = "progid:DXImageTransform.Microsoft." + billboardeffects[filterid]
            }
            selectedDivObj.filters[0].duration = effectduration / 1000
            selectedDivObj.filters[0].Apply()
        }
        selectedDivObj.style.display = "block"
        if (selectedDivObj.filters)
            selectedDivObj.filters[0].Play()
        selectedDiv = (selectedDiv < totalDivs - 1) ? selectedDiv + 1 : 0
        setTimeout("expandboard()", tickspeed)
    }

    function startbill() {
        while (document.getElementById("billboard" + totalDivs) != null)
            totalDivs++
        if (document.getElementById("billboard0").filters)
            tickspeed += effectduration
        expandboard()
    }

    if (window.addEventListener)
        window.addEventListener("load", startbill, false)
    else if (window.attachEvent)
        window.attachEvent("onload", startbill)
    else if (document.getElementById)
        window.onload = startbill

</script>
<table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="100%" >
    <tr class="TrHeader">
        <td class="TestoP" align="center"><b>MENU</b></td>
    </tr>
    <tr>
        <td class="TestoP" align="center">
        <asp:Menu ID="Menu1" runat="server" BackColor="White" DynamicHorizontalOffset="2" 
    Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
    StaticSubMenuIndent="10px" Width="95%" style="text-align: center">
    <StaticSelectedStyle BackColor="#0000AA" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
    <DynamicMenuStyle BackColor="#66FFFF" />
    <DynamicSelectedStyle BackColor="#0000CC" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#0000AA" ForeColor="White" />
    <Items>
        <asp:MenuItem NavigateUrl="Home.aspx" Text="Home" Value="Home">
        </asp:MenuItem>
        <asp:MenuItem NavigateUrl="Sede.aspx" Text="La Sede" Value="La Sede">
        </asp:MenuItem>
        <asp:MenuItem NavigateUrl="Associazione.aspx" Text="L'Associazione" 
            Value="L'Associazione"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="OrganiSociali.aspx" Text="Organi Sociali" 
            Value="Organi Sociali"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Volontariato.aspx" Text="Volontariato" 
            Value="Volontariato"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Mezzi.aspx" Text="Mezzi di Trasporto" 
            Value="Mezzi di Trasporto"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Prelievi.aspx" Text="Prelievi di sangue" 
            Value="Prelievi di sangue"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Ambulatori.aspx" Text="Ambulatori" 
            Value="Ambulatori"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Donatori.aspx" Text="Donatori di sangue" 
            Value="Donatori"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="ProtezioneCivile.aspx" Text="Protezione Civile" 
            Value="Protezione Civile"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="Contattaci.aspx" Text="Contattaci" 
            Value="Contattaci"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="MaterialeOrtopedico.aspx" 
            Text="Materiale Ortopedico" Value="Materiale Ortopedico"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="ArchivioNotizie.aspx" Text="Archivio Iniziative" 
            Value="Archivio Iniziative"></asp:MenuItem>
        <asp:MenuItem Text="Archivio Fotografico" Value="Archivio Fotografico">
        </asp:MenuItem>
        <asp:MenuItem Text="&lt;b style=&quot;color:#bb0000#&quot;&gt;DIVENTA NOSTRO AMICO&lt;/b&gt;" Value="Diventa nostro amico" 
            NavigateUrl="IscrizioneNewsletter.aspx">
        </asp:MenuItem>
    </Items>
</asp:Menu>
        </td>
    </tr>
   
</table>
<br />
<asp:Panel ID="pnlAdmin" runat="server" Visible="False">
    <table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="100%" >
        <tr class="TrHeader">
            <td class="TestoP" align="center">
                <b>AMMINISTRAZIONE</b></td>
        </tr>
        <tr>
            <td class="TestoP" align="center">
                <asp:Menu ID="Menu2" runat="server" BackColor="White" DynamicHorizontalOffset="2" 
    Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
    StaticSubMenuIndent="10px" Width="95%" style="text-align: center" >
                    <StaticSelectedStyle BackColor="#0000AA" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#66FFFF" />
                    <DynamicSelectedStyle BackColor="#0000CC" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#0000AA" ForeColor="White" />
                    <Items>
                        <asp:MenuItem Text="Nuova Iniziativa" Value="Nuova Iniziativa" 
                            NavigateUrl="NuovaIniziativa.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Elenco Iniziative" Value="Elenco Iniziative"
                        NavigateUrl="ElencoNewsAdmin.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="CaricaDati.aspx" Text="Carica Dati" 
                            Value="Carica Dati"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="TipiAlbumAdmin.aspx" Text="Archivio Fotografico" 
                            Value="Archivio Fotografico"></asp:MenuItem>
                        <asp:MenuItem Text="Comunicazioni" Value="Comunicazioni">
                            <asp:MenuItem Text="Nuova Comunicazione" Value="Nuova Comunicazione" 
                                NavigateUrl="ComunicazioneNL.aspx">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="ElencoIscrittiNL.aspx" Text="Elenco Iscritti" 
                                Value="Elenco Iscritti"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="AggiungiIscrittoNL.aspx" Text="Aggiungi iscritto" 
                                Value="Aggiungi iscritto"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Link" Value="Link">
                            <asp:MenuItem NavigateUrl="NuovoLink.aspx" Text="Nuovo Link" Value="Nuovo Link">
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="ElencoLink.aspx" Text="Elenco Link" 
                                Value="Elenco Link"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<div id="contentwrapper" style="width:170px">
    <asp:Label ID="lblAnteprima" runat="server" EnableViewState="False" 
        CssClass="TestoP"></asp:Label>
</div>
<br />
<br />
<asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
    ForeColor="#CC0000"></asp:Label>





