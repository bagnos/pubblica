<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfiloLnx.aspx.cs" Inherits="pa_taverne.ProfiloLnx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>

    <link href="Stili.css?050516" rel="Stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
</head>
<body class="body-iframe">

    <div id="area-riservate" class="">

        <form id="form1" runat="server" class="form-horizontal">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <div style="border-radius: 5px; box-shadow: 0 5px 15px 2px rgba(150,150, 150, 0.4); padding: 20px; margin: 20px">
                <div class="row">
                    <!--
                    <div class="col-sm-11">
                        <h3 class="text-center" style="color: #2e5894; font-size: 2.5em;">AREA RISERVATA</h3>
                    </div>
                    -->



                    <!-- Trigger the modal with a button -->
                    <div class="col-sm-1 text-left">
                        <button type="button" id="showQuote" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModal">Quote Sociali</button>
                     </div>
                    <div class="col-sm-1 col-sm-offset-10 text-right">
                        <button runat="server" id="Button1" type="button" class="btn btn-default btn-md" onserverclick="btnLogout_Click">
                            <span class=" glyphicon glyphicon-off" aria-hidden="true"></span> Esci</button>
                    </div>

                </div>

                <div style="margin-top: 10px">
                    <asp:Panel ID="pnlMessaggiError" runat="server" Visible="false">
                        <div class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <strong>Attenzione! </strong>
                            <asp:Label ID="lblErr" runat="server" Font-Bold="True"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlMessaggiSuccess" runat="server" Visible="false">
                        <div class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <strong>Ben Fatto! </strong>
                            <asp:Label ID="lblEsitoPositivo" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    
                       
                    
                </div>



                <asp:Panel ID="pnlCaricamento" runat="server">
                    <div class="panel panel-primary ">
                        <div class="panel-heading">
                            <h4 class="panel-title">AMMINISTRAZIONE</h4>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <a target="_blank" href="http://lnx.pa-taverne.it/wp-admin">Amministra Sito</a>
                                </div>
                            </div>
                            <div class="row margin10">

                                <div class="col-sm-6">
                                    <div class="panel panel-default ">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">Carica Dati</h4>
                                        </div>
                                        <div class="panel-body">
                                            <table cellpadding="3" id="tblCaricamento" class="table" cellspacing="0" width="100%">

                                                <tr>
                                                    <td style="border: none" align="center">Il file da caricare si deve chiamare DatiXsito.mdb<br />
                                                        <br />
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#EE0000"></asp:Label>
                                                        <asp:Panel ID="pnlUpload" runat="server">
                                                            <asp:FileUpload ID="flDati" runat="server" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnSalva" runat="server" CssClass="btn btn-primary"
                                                                OnClick="btnSalva_Click" Text="Aggiorna i Dati" />
                                                        </asp:Panel>
                                                        <br />
                                                        <asp:Label ID="lblLog" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>


                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="panel panel-default ">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">Pagamenti Online</h4>
                                        </div>
                                        <div class="panel-body">

                                            <asp:Panel ID="pnlPagamentiOnline" runat="server">

                                                <asp:Button CssClass="btn btn-primary" ID="btnPagamentiOnline" OnClick="btnPagamentiOnline_click"
                                                    Text="Visualizza"
                                                    runat="server" />


                                                <asp:GridView ID="dgPagamentiOnline" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="Dati non presenti" AutoGenerateColumns="False"
                                                    CellPadding="1" CssClass="table table-bordered margin10" AllowPaging="True"
                                                    OnPageIndexChanging="grdData_PageIndexChanging" PageSize="5">
                                                    <Columns>

                                                        <asp:BoundField DataField="nsocio" HeaderText="Nr." />
                                                        <asp:BoundField DataField="numFamiglia" HeaderText="Famiglia" />
                                                        
                                                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                                                        <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="data" HeaderText="Data">
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataFormatString="{0:c} &euro;" DataField="importo" HeaderText="Quota" />
                                                    </Columns>
                                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" CssClass="cssPager"
                                                        HorizontalAlign="Center"></PagerStyle>
                                                </asp:GridView>

                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">DATI PERSONALI</h4>
                    </div>
                    <div class="panel-body">
                         <div class="alert alert-info alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>                        
                            <span>In caso di dati non corretti per anagrafica ed importi da pagare è possibile contattare la Pubblica Assistenza ai seguenti recapiti: </br> Tel. 0577 365000 Fax. 0577 365097 E-Mail pa.taverne@tin.it</span>
                        </div>

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
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblNumeroSocio">Numero Socio:</label>
                                <asp:Label ID="lblNumeroSocio" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblNumeroSocio">Numero Famiglia:</label>
                                <asp:Label ID="lnlNrFamiglia" runat="server"></asp:Label>
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
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblMedico">Referente Famiglia:</label>
                                <asp:Label ID="lblReferente" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="lblMedico">Mail Referente:</label>
                                <asp:Label ID="lblMailReferente" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="table-responsive">

                            <asp:GridView ID="dgFamiglia" runat="server" AutoGenerateColumns="False"
                                CellPadding="1" CssClass="table table-bordered"
                                OnRowDataBound="dgFamiglia_RowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="nsocio" HeaderText="Nr.Socio" />
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
                                    <asp:BoundField DataFormatString="{0:c} &euro;" DataField="quota" HeaderText="Quota" />
                                    <asp:BoundField DataFormatString="{0:c} &euro;" DataField="quotaRisc" HeaderText="Pagato" />


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
                        <h4 class="panel-title">PAGAMENTI PERSONALI</h4>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Label ID="lblSocioQuote" runat="server"
                                    Font-Bold="True"></asp:Label>
                            </div>

                        </div>


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
                        <asp:Panel ID="frmPayPal" Visible="false" runat="server" CssClass="margin20">
                            <h2 class="panel-title margin10">PAGAMENTO ONLINE TESSERE FAMIGLIA</h2>
                            <!--
                            <div class="row">
                                <div class="table-responsive margin10 col-sm-6">
                                    <asp:GridView ID="dgDaPagare" runat="server" AutoGenerateColumns="False" Caption="Tessere da Pagare"
                                        CellPadding="1" CssClass="table table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="NomeCognome" HeaderText="Socio">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataFormatString="{0:c} &euro;" DataField="quota" HeaderText="Quota"></asp:BoundField>

                                        </Columns>
                                        <HeaderStyle CssClass="" />
                                    </asp:GridView>
                                </div>
                            </div>
                            -->
                            <div class="row">
                                <div class="col-sm-4 col-md-2">
                                    <label for="txtAnno" class="control-label">Anno Tessera</label>
                                    <asp:TextBox ReadOnly="true" ID="txtAnno" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4 col-md-3">

                                    <label for="txtImporto" class="control-label">Importo Famiglia da Pagare (&euro;)</label>
                                    <asp:TextBox ID="txtImporto" MaxLength="16" ReadOnly="true" CssClass="form-control col-md-4 col-sm-6 col-xs-12 " runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <asp:ImageButton OnClick="pagaClick" CssClass="margin10" ID="payPalCheckout" runat="server" ImageUrl="https://www.paypal.com/it_IT/i/btn/btn_xpressCheckout.gif" BorderStyle="None" />

                        </asp:Panel>


                        <div class="table-responsive margin10">
                            <asp:GridView ID="dgQuote" runat="server" AutoGenerateColumns="False" Caption="Ultimi Pagamenti"
                                CellPadding="1" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="DTPAG" HeaderText="Data Pagamento">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LuogoPagamento" HeaderText="Luogo Pagamento">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataFormatString="{0:c} &euro;" DataField="QUOTA" HeaderText="Quota versata"></asp:BoundField>

                                </Columns>
                                <HeaderStyle CssClass="" />
                            </asp:GridView>
                        </div>

                        

                        <!-- Modal -->
                        <div id="myModal" class="modal fade" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">QUOTE SOCIALI ANNO IN CORSO</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="table-responsive margin20">
                                            <table class="table table-bordered" cellpadding="5" cellspacing="0">
                                               
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
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Chiudi</button>
                                    </div>
                                </div>

                            </div>
                        </div>



                    </div>
                </div>



            </div>

            <div class="loading" id="loading" align="center">

                <img src="./images/loading.gif" alt="" />
            </div>
        </form>
        <div class="modal" id="modal" style="display: none"></div>
        <div id="footerHidden" style="display: none"></div>
    </div>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script type="text/javascript">
        /*
        $(window).load(function () {
        
            $(".se-pre-con").fadeOut("slow");;
        });
        $('#form1').submit(function () {
            $(".se-pre-con").fadeOut("slow");;
        });*/
        $(window).load(function () {
            $('#btnSalva').click(function () {
                $('#btnSalva').after('<div class="margin10"><img class="loading-ajax" src="/images/loader.gif" alt="Loading" /><div>')


            });
            $('#btnPagamentiOnline').click(function () {
                $('#btnPagamentiOnline').after('<div class="margin10"><img class="loading-ajax" src="/images/loader.gif" alt="Loading" /><div>')
            });
            $('#payPalCheckout').click(function () {
                $('#payPalCheckout').after('<div class="margin10"><img class="loading-ajax" src="/images/loader.gif" alt="Loading" /><div>')
            });
            $('#showQuote').click(function () {
                var position = $("#showQuote").position().top + 20;
                $('#myModal').css({ 'top': position + 'px' });
            });
            var positionY = $("#footerHidden").position().top + 100;
            
            window.parent.postMessage(positionY, '*');
            

        });
    </script>

</body>
</html>
