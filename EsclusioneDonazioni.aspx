<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EsclusioneDonazioni.aspx.cs" Inherits="pa_taverne.EsclusioneDonazioni" %>
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
                        <td align="center" class="TestoP"><b>CRITERI DI ESCLUSIONE DA DONAZIONE</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        <br />
                        Criteri di esclusione <b>permanente</b> o <b>temporanea</b>  del candidato donatore ai fini della protezione della sua salute.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        <br />
                        <b><u>ESCLUSIONE PERMANENTE</u></b>
                        <br /><br />
                        <table cellpadding="3" class="TabellaGenerica" cellspacing="0" >
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Malattie autoimmuni</b> in atto o pregresse</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Malattie del sistema nervoso centrale</b></td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Malattie cardiovascolari</b> (esclusa celiachia se in trattamento dietetico)</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Neoplasie o malattie maligne</b> (escluso se guarigione completa)</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Tendenza anomala all’emorragia </b> (coagulopatia congenita o acquisita)</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Crisi di svenimenti o convulsioni</b> (escluso se dopo 3 anni dalla fine della terapia non ci sono ricadute)</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Malattie gastrointestinali, epatiche, urogenitali, ematologiche, renali, metaboliche </b> – gravi affezioni croniche, attive o recidivanti –</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Diabete se in trattamento insulinico</b></td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Malattie infettive</b> Epatite C, Epatite B, HIV1-2, HTLVI/II, Babesiosi, Lebbra, Kala Azar (Leishmaniosi vsc.), Tripanosoma Cruzi (M. di Chagas),  Sifilide, Epatite ad eziologia indeterminata</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Encefalopatia spongiforme trasmissibile (TSE) </b>Antecedenti o familiari a rischio TSE, trapianti di cornea, dura madre o terapia con estratti di ghiandola pituitaria umana;   soggiorno nel Regno Unito dal 1980 al 1996 per almeno sei mesi;  trasfusioni allogeniche nel Regno Unito dopo il 1980</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Assunzione di farmaci</b> sostanze farmaceutiche (non prescritte) per via endovenosa, intramuscolare o tramite strumenti in grado di trasmettere gravi malattie infettive, sostanze stupefacenti, steroidi, ormoni a scopo non curativo</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Comportamento sessuale</b> persone il cui comportamento sessuale le espone ad alto rischio di contrarre gravi malattie infettive trasmissibili con il sangue</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDx" align="left" valign="top"><b>Riceventi xenotrapianti</b></td>
                                <td align="left" valign="top"><b>Alcolismo cronico</b></td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        <br />
                        <b><u>ESCLUSIONE TEMPORANEA</u></b>
                        <br />In presenza di una delle sottoelencate patologie o condizioni il donatore è dichiarato temporaneamente non idoneo alla donazione per un periodo variabile a seconda della patologia o condizione rilevata
                        <br /><br />
                        <table cellpadding="3" class="TabellaGenerica" cellspacing="0" >
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Gravidanza</b> in atto e fino ad un anno dal parto oppure sei mesi dall’interruzione </td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Infezioni </b> esclusione per almeno <b>2 settimane</b> dalla completa guarigione</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Glomerulonefrite acuta 5 anni</b> dalla completa guarigione</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Brucellosi 2 anni</b> dalla completa guarigione</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Osteomielite 2 anni</b> dalla completa guarigione</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Febbre Q  2 anni</b> dalla completa guarigione</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Tubercolosi 2 anni</b> dalla completa guarigione</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Febbre reumatica 2 anni</b> dopo la cessazione dei sintomi e in assenza di cardiopatia cronica</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Toxoplasmosi, Mononucleosi, M. di Lyme   6  mesi</b> dalla completa guarigione</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Febbre oltre i 38° C.</b>2 settimane dopo la cessazione dei sintomi</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Affezioni influenzali (anche raffreddore) 2 settimane</b> dopo la cessazione dei sintomi</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Malaria (chi ha vissuto in zona malarica nei primi 5 anni di vita o per 5 anni consecutivi)</b> sono esclusi dalla donazione per 3 anni dopo aver lasciato la zona e che siano asintomatici. Possono donare il plasma da inviare al frazionamento industriale purchè siano adottate misure che escludano l’uso clinico gli individui con pregressa malaria, visitatori asintomatici di zone endemiche e che abbiano lasciato le predette zone da almeno 6 mesi</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDx" align="left" valign="top"><b>Virus del Nilo Occidentale (WNV) 28 giorni</b>dopo aver lasciato la zona o dopo la risoluzione dei sintomi in caso di infezione</td>
                                <td align="left" valign="top"><b>Viaggi in zone endemiche per malattie tropicali 3 mesi </b> dal rientro – valutazione stato di salute del donatore dopo il rientro –</td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        <br />
                        <b><u>ESCLUSIONE TEMPORANEA PER 4 MESI</u></b>
                        <br /><br />
                        <table cellpadding="3" class="TabellaGenerica" cellspacing="0" >
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Esame endoscopico con strumenti flessibili</b></td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Spruzzo delle mucose con sangue o lesioni da ago</b></td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Trasfusioni di emocomponenti o somministrazione di emoderivati</b> valutazione da parte del medico della patologia di base</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Trapianto di tessuti o cellule di origine umana</b> valutazione da parte del medico della patologia di base</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Tatuaggi o piercing</b></td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Agopuntura (se non eseguita da professionisti con materiale usa e getta)</b></td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Persone a rischio dovuto a stretto contatto domestico con persone affette da epatite B</b></td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Rapporti sessuali occasionali a rischio di trasmissione di malattie infettive</b></td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Rapporti sessuali con persone infette o a rischio di infezione da HBV, HCV, HIV</b></td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Intervento chirurgico maggiore</b> valutazione da parte del medico della patologia di base</td>
                            </tr>
                            <tr>
                                <td class="TdBordoDxBottom" align="left" valign="top"><b>Intervento chirurgico minore 1 settimana</b> (estrazione dente, devitalizzazione ecc.)</td>
                                <td class="TdBordoBottom" align="left" valign="top"><b>Cure odontoiatriche 48 ore</b> per cure di minore entità del dentista</td>
                            </tr>
                            <tr>
                                <td class="TdBordoBottom" align="left" valign="top" colspan="2"><b>Terapie</b> sospensione per un periodo variabile a seconda del principio attivo del farmaco e della malattia oggetto di cura</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="2">
                                <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="top"><b>Vaccinazioni</b></td>
                                        <td><b>&nbsp;- Virus o batteri vivi attenuati 4 settimane</b></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top"><b>"</b></td>
                                        <td><b>&nbsp;- Virus, batteri, rickettsie inattivati/uccisi 48 ore</b> se il soggetto è asintomatico</td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top"><b>"</b></td>
                                        <td><b>&nbsp;- Virus, batteri, rickettsie inattivati/uccisi 48 ore</b> se il soggetto è asintomatico</td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top"><b>"</b></td>
                                        <td><b>&nbsp;- Tossoidi 48 ore</b> se il soggetto è asintomatico</td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top"><b>"</b></td>
                                        <td><b>&nbsp;- Rabbia 48 ore</b> se il soggetto è asintomatico e vi è stata  esposizione. Se il vaccino è stato somministrato dopo l’esposizione l’esclusione è per <b>1 anno</b></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top"><b>"</b></td>
                                        <td><b>&nbsp;- Vaccini dell’encefalite da zecche</b> nessuna esclusione se il soggetto sta bene e non vi è stata esposizione</td>
                                    </tr>
                                </table>
                                </td>
                            </tr>
                        </table>
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
