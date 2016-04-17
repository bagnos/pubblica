<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="pa_taverne.Right" %>
<asp:Label ID="lblErr" runat="server" CssClass="TestoP" Font-Bold="True" 
    ForeColor="#CC0000"></asp:Label>
<table cellpadding="3" enableviewstate="false" class="TabellaGenerica" cellspacing="0" width="100%" runat="server" >        
    <tr class="TrHeader">
        <td class="TestoP" align="center"><b>AREA RISERVATA</b></td>
    </tr>
    <tr>
        <td>
            
            <asp:Panel ID="pnlLogin" runat="server" Width="100%">
                <table cellpadding="3" cellspacing="0" border="0" width="100%">
                    <tr>
        <td class="TestoP" align="center">
            <asp:Label ID="lblUtente" runat="server" ForeColor="White"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TestoP" align="center">
        <asp:Menu ID="mnuSocio" runat="server" BackColor="White" DynamicHorizontalOffset="2" 
    Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" 
    StaticSubMenuIndent="10px" Width="95%" style="text-align: center">
    <StaticSelectedStyle BackColor="#0000AA" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
    <DynamicMenuStyle BackColor="#F7F6F3" />
    <DynamicSelectedStyle BackColor="#0000CC" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#0000AA" ForeColor="White" />
    <Items>
        <asp:MenuItem NavigateUrl="Profilo.aspx" Text="Consulta i tuoi dati" 
            Value="Consulta i tuoi dati">
        </asp:MenuItem>
        <asp:MenuItem NavigateUrl="QuoteSociali.aspx" Text="Quote Sociali" 
            Value="Quote Sociali">
        </asp:MenuItem>
    </Items>
</asp:Menu>
        </td>
    </tr>
    <tr>
        <td class="TestoP" align="center">
            <asp:Label ID="lblDati" runat="server" Text="Consulta i tuoi dati associativi"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TestoP" align="center">
            
            <asp:Button ID="btnLogin" runat="server" CssClass="Bottoni" onclick="btnLogin_Click" Text="ENTRA" />
            <asp:Button ID="btnLogout" runat="server" CssClass="Bottoni" Text="ESCI" 
                onclick="btnLogout_Click" />
            
        </td>
    </tr>
                </table>
            </asp:Panel>
            
        </td>
    </tr>
    
</table>
<br />
<a onclick="javascript:location.href='Cinquepermille.aspx'" style="cursor:pointer;"><img src="Immagini/5xMille-10.jpg" width="200px" alt="" /></a>
<br />
<img src="Immagini/Donatori_Imm2.png" width="200px" alt="" />
<p>
<asp:Label ID="lblLink" CssClass="TestoP" runat="server"></asp:Label>
</p>



