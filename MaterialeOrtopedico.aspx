<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialeOrtopedico.aspx.cs" Inherits="pa_taverne.MaterialeOrtopedico" %>
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
                        <td align="center" class="TestoP"><b>MATERIALE ORTOPEDICO</b></td>
                    </tr>
                    <tr>
                        <td>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="center">
                        <b>CESSIONE IN USO DEL MATERIALE ORTOPEDICO</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                        Abbiamo attivato un servizio di cessione in uso del materiale ortopedico, non solo per i nostri soci ma anche a coloro che non sono soci dell'Associazione. 
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" valign="middle"><img alt="" src="Immagini/letto_ort.jpg" /><br /><b>Letti ortopedici</b></td>
                                <td align="center" valign="middle"><img alt="" src="Immagini/girello.jpg" /><br /><b>Girelli deambulatori</b></td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle"><img alt="" src="Immagini/carrozzina.jpg" width="200px" /><br /><b>Carrozzine di diversi modelli</b></td>
                                <td align="center" valign="middle"><img alt="" src="Immagini/stampelle.jpg" width="200px" /><br /><b>Stampelle</b></td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle"><img alt="" src="Immagini/asta_flebo.jpg" width="200px" /><br /><b>Aste per flebo</b></td>
                                <td align="center" valign="middle"><img alt="" src="Immagini/aerosol.jpg" width="200px" /><br /><b>Macchina per aerosol</b></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="left">
                        <u><b>CONDIZIONI GENERALI DI CESSIONE IN USO</b></u>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                        Il materiale oggetto di cessione è di proprietà dell’Associazione e viene ceduto ai soci (salvo disponibilità anche ai non soci) dopo essere stato controllato e ritenuto idoneo all’uso per il quale è destinato.
                        <br />
                        Per la concessione in uso deve essere rilasciata sottoscritta dichiarazione di presa in carico dove risultano, oltre ai dati identificativi dell’utilizzatore e del bene oggetto di cessione, l’impegno da parte dell’utilizzatore di custodirlo, non manometterlo, utilizzarlo esclusivamente per l’uso cui è destinato e la riconsegna tempestiva dopo l’utilizzo.
                        <br />
                        La riconsegna del materiale deve essere concordata con l’Associazione, in particolare per i letti, le carrozzine ed i girelli deambulatori, per evidenti motivi di rimessaggio.
                        <br />
                        Alla riconsegna del materiale ne viene verificata l’integrità, lo stato e se risulta idoneo per un futuro riutilizzo; qualora si riscontrassero manomissioni, danneggiamenti o deterioramenti dovuti allo scorretto utilizzo del bene, verrà addebitato il valore risultante da una valutazione dell’oggetto al momento della consegna.
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" align="left">
                        <u><b>CONDIZIONI ECONOMICHE DI CESSIONE</b></u>
                        </td>
                    </tr>
                    <tr>
                        <td class="TestoP" style="text-align:justify;">
                        Al momento della consegna del materiale è richiesta una cauzione di € 30.
                        <br />
                        <b>La consegna non comprende il recapito a domicilio del materiale.</b>
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