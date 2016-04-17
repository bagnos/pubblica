<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ambulatori.aspx.cs" Inherits="pa_taverne.Ambulatori" %>
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
                        <td align="center" class="TestoP"><b>AMBULATORI</b></td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                        Qui sotto sono riportati gli orari di tutti gli ambulatori, con orari, medici responsabili e numeri di telefono di riferimento.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TestoP">
                            <img src="Immagini/OrariAmb.jpg?v=1" alt="" /><br /><br />
                            <%--<table class="TabellaGenerica" cellpadding="3" cellspacing="0">
                                <tr class="TrHeader">
                                    <td align="center" class="TestoP"><b>GIORNO</b></td>
                                    <td align="center" class="TestoP"><b>ORARIO</b></td>
                                    <td align="center" class="TestoP"><b>AMB.</b></td>
                                    <td align="center" class="TestoP"><b>MEDICO<BR />TECNICO</b></td>
                                    <td align="center" class="TestoP"><b>SPECIALISTICA</b></td>
                                    <td align="center" class="TestoP"><b>TELEFONO</b></td>
                                    <td align="center" class="TestoP"><b>NOTE</b></td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom" rowspan="3" valign="middle"><b>LUNEDI'</b></td>
                                    <td align="center" class="TdBordoDxBottom">16.00-17.30</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">Audibel</td>
                                    <td align="center" class="TdBordoDxBottom">App. acustici</td>
                                    <td align="center" class="TdBordoDxBottom">0577286314</td>
                                    <td align="center" class="TdBordoBottom">Secondo lunedì del mese</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom">16.00-18.00</td>
                                    <td align="center" class="TdBordoDxBottom">43</td>
                                    <td align="center" class="TdBordoDxBottom">A.S.L. 7</td>
                                    <td align="center" class="TdBordoDxBottom">Prenotazione prelievi</td>
                                    <td align="center" class="TdBordoDxBottom">0577365000</td>
                                    <td align="center" class="TdBordoBottom">Ritiro ricette</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom">19.00-20.00</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">Dr. Lenzi G.</td>
                                    <td align="center" class="TdBordoDxBottom">Medicina di base</td>
                                    <td align="center" class="TdBordoDxBottom">0577221376<br />335399462</td>
                                    <td align="center" class="TdBordoBottom">Per visite domiciliari chiamare dalle ore 08.00 alle ore 09.00</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom" rowspan="2" valign="middle"><b>MARTEDI'</b></td>
                                    <td align="center" class="TdBordoDxBottom">07.00-08.30</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">A.S.L. 7</td>
                                    <td align="center" class="TdBordoDxBottom">Prelievi</td>
                                    <td align="center" class="TdBordoDxBottom">0577365000</td>
                                    <td align="center" class="TdBordoBottom">&nbsp;</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom">18.00-19.15</td>
                                    <td align="center" class="TdBordoDxBottom">43</td>
                                    <td align="center" class="TdBordoDxBottom">A.S.L. 7</td>
                                    <td align="center" class="TdBordoDxBottom">Consegna referti esami</td>
                                    <td align="center" class="TdBordoDxBottom">0577365000</td>
                                    <td align="center" class="TdBordoBottom">Salvo diversa indicazione</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom" rowspan="2" valign="middle"><b>MERCOLEDI'</b></td>
                                    <td align="center" class="TdBordoDxBottom">08.30-09.30</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">Dr. Crescenzi Concetta</td>
                                    <td align="center" class="TdBordoDxBottom">Fisioterapia</td>
                                    <td align="center" class="TdBordoDxBottom">3477008335</td>
                                    <td align="center" class="TdBordoBottom">Appuntamento</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom">09.00-11.00</td>
                                    <td align="center" class="TdBordoDxBottom">43</td>
                                    <td align="center" class="TdBordoDxBottom">A.S.L. 7</td>
                                    <td align="center" class="TdBordoDxBottom">Consegna referti esami</td>
                                    <td align="center" class="TdBordoDxBottom">0577365000</td>
                                    <td align="center" class="TdBordoBottom">Salvo diversa indicazione</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom" valign="middle"><b>GIOVEDI'</b></td>
                                    <td align="center" class="TdBordoDxBottom">11.00-13.00</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">Dr. Lenzi G.</td>
                                    <td align="center" class="TdBordoDxBottom">Medicina di base</td>
                                    <td align="center" class="TdBordoDxBottom">0577221376<br />335399462</td>
                                    <td align="center" class="TdBordoBottom">Per visite domiciliari chiamare dalle ore 08.00 alle ore 09.00</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDx" rowspan="3" valign="middle"><b>VENERDI'</b></td>
                                    <td align="center" class="TdBordoDxBottom">09.00-11.00</td>
                                    <td align="center" class="TdBordoDxBottom">44</td>
                                    <td align="center" class="TdBordoDxBottom">Dr. Megale</td>
                                    <td align="center" class="TdBordoDxBottom">Reumatologia</td>
                                    <td align="center" class="TdBordoDxBottom">0577391035<br />330880380</td>
                                    <td align="center" class="TdBordoBottom">Appuntamento</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDxBottom">16.00-18.00</td>
                                    <td align="center" class="TdBordoDxBottom">43</td>
                                    <td align="center" class="TdBordoDxBottom">A.S.L. 7</td>
                                    <td align="center" class="TdBordoDxBottom">Prenotazione prelievi</td>
                                    <td align="center" class="TdBordoDxBottom">0577365000</td>
                                    <td align="center" class="TdBordoBottom">Ritiro ricette</td>
                                </tr>
                                <tr class="TestoP">
                                    <td align="center" class="TdBordoDx">16.00-18.00</td>
                                    <td align="center" class="TdBordoDx">Arbia e Pancole</td>
                                    <td align="center" class="TdBordoDx">Associazione</td>
                                    <td align="center" class="TdBordoDx">Prenotazione prelievi</td>
                                    <td align="center" class="TdBordoDx">Pancole<br />0577369292</td>
                                    <td align="center" >Ritiro ricette</td>
                                </tr>
                            </table>--%>
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