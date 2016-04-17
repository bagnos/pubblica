<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfiloLnx.aspx.cs" Inherits="pa_taverne.ProfiloLnx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>

    <link href="Stili.css" rel="Stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />

</head>
<body>
    <div id="area-riservate" class="container">
        <form id="form1" runat="server" class="form-horizontal">

            <div style="border-radius: 5px; box-shadow: 0 5px 15px 2px rgba(150,150, 150, 0.4); padding: 20px; margin: 20px">
                <div class="row">
                    <div class="col-sm-11">
                        <h3 class="text-center" style="color: #2e5894; font-size: 2.5em;">AREA RISERVATA</h3>
                    </div>
                    <div class="col-sm-1">
                        <asp:Button ID="btnLogout" runat="server" CssClass="Bo btn btn-primary" Text="ESCI"
                            OnClick="btnLogout_Click"></asp:Button>




                    </div>
                </div>
                <div style="margin-top:10px">
                    <asp:Label ID="lblErr" runat="server" Font-Bold="True"></asp:Label>
                </div>


                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">DATI PERSONALI</h4>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-6 col-md-3">
                                <label for="lblNome">Nome:</label>
                                <asp:Label ID="lblNome" runat="server" />
                            </div>
                            <div class="col-sm-6 col-md-3">
                                <label for="lblCognome">Cognome:</label>
                                <asp:Label ID="lblCognome" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblNascita">Luogo e data di nascita:</label>
                                <asp:Label ID="lblNascita" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblIndirizzo">Indirizzo:</label>
                                <asp:Label ID="lblIndirizzo" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblIscrizione">Iscritto dal:</label>
                                <asp:Label ID="lblIscrizione" runat="server"></asp:Label>
                                &nbsp; 
                <asp:Label ID="lblFineIscrizione" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-3">
                                <label for="lblTelefono">Telefono:</label>
                                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-6 col-md-3">
                                <label for="lblCellulare">Cellulare:</label>
                                <asp:Label ID="lblCellulare" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-md-3">
                                <label for="lblCodSan">Codice Sanitario:</label>
                                <asp:Label ID="lblCodSan" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-6 col-md-3">
                                <label for="lblAnpas">Tessera Anpas:</label>
                                <asp:Label ID="lblAnpas" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblMedico">Medico Curante:</label>
                                <asp:Label ID="lblMedico" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <asp:Label ID="lblFamiglia1" runat="server"
                                Text="ALTRI COMPONENTI DELLA FAMIGLIA ISCRITTI"></asp:Label></h4>
                    </div>
                    <div class="panel-body">

                        <div class="table-responsive">
                            <asp:GridView ID="dgFamiglia" runat="server" AutoGenerateColumns="False"
                                CellPadding="1" CssClass="table table-bordered"
                                OnRowDataBound="dgFamiglia_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="NomeCognome" HeaderText="Nome">
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
                                <HeaderStyle CssClass="" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <asp:Panel ID="pnlVolontariato" runat="server">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <asp:Label ID="Label1" runat="server"
                                    Text="ATTIVITA' DI VOLONTARIATO"></asp:Label></h4>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="lblVolint">Codice interno associazione:</label>
                                    <asp:Label ID="lblVolint" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="lblVolAnpas">Codice Anpas:</label>
                                    <asp:Label ID="lblVolAnpas" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="dgVolontariato" runat="server" AutoGenerateColumns="False"
                                    CellPadding="1" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="TipoVol" HeaderText="Tipo">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTINIZ" HeaderText="Data Inizio">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DTFINE" HeaderText="Data Fine" />
                                    </Columns>
                                    <HeaderStyle CssClass="" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </asp:Panel>


                <asp:Panel ID="pnlDonatore" runat="server">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <asp:Label ID="Label2" runat="server"
                                    Text="ATTIVITA' DI DONAZIONE DEL SANGUE"></asp:Label></h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="dgDatiDonatore" runat="server" AutoGenerateColumns="False"
                                    CellPadding="1" CssClass="table table-bordered">
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
                                    <HeaderStyle CssClass="" />
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="table-responsive">
                                <asp:GridView ID="dgDonazioni" runat="server" AutoGenerateColumns="False"
                                    CellPadding="1" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="DTDON" HeaderText="Data Donazione">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DSTIPODON" HeaderText="Tipo Donazione">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="" />
                                </asp:GridView>
                            </div>
                            <br />
                            <br />
                            <asp:Label ID="lblUltima" runat="server" Font-Bold="True"></asp:Label>
                            <br />
                            <br />
                        </div>
                    </div>

                </asp:Panel>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">QUOTE VERSATE</h4>
                    </div>
                    <div class="panel-body">


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Label ID="lblQuote" runat="server" Text=""
                                    Font-Bold="True"></asp:Label>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Label ID="lblDaVersare" runat="server" Font-Bold="True"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Label ID="lblVersato" runat="server" Font-Bold="True"></asp:Label>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="dgQuote" runat="server" AutoGenerateColumns="False"
                                CellPadding="1" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="DTPAG" HeaderText="Data Pagamento">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LuogoPagamento" HeaderText="Luogo Pagamento">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QUOTA" HeaderText="Quota versata" />
                                </Columns>
                                <HeaderStyle CssClass="" />
                            </asp:GridView>
                        </div>
                        <div class="table-responsive">
                            <table class="table table-bordered" cellpadding="5" cellspacing="0">
                                <caption>QUOTE SOCIALI</caption>
                                <tr>
                                    <th class="">Descrizione</th>
                                    <th class="">Quota</th>
                                </tr>
                                <tr class="">
                                    <td class="">Fino a 10 anni</td>
                                    <td class="">Gratuita</td>
                                </tr>
                                <tr class="">
                                    <td class="">Da 11 a 18 anni</td>
                                    <td class="">5 &euro;</td>
                                </tr>
                                <tr class="">
                                    <td class="">Oltre i 18 anni</td>
                                    <td class="">10 &euro;</td>
                                </tr>
                                <tr class="">
                                    <td class="">Donatori</td>
                                    <td class="">Gratuita</td>
                                </tr>
                                <tr class="">
                                    <td class="">Volontari</td>
                                    <td>Gratuita</td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>

