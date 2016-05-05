<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginLnx.aspx.cs" Inherits="pa_taverne.LoginLnx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pubblica Assistenza Taverne D'Arbia</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="Stili.css?050516" rel="Stylesheet" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

</head>
<body class="body-iframe">
    

    <div class="" style="margin-top: 20px">
        <div class="col-sm-6 col-sm-offset-3 col-md-5 col-md-offset-3 col-xs-12">
            <div class="panel panel-primary">
                <div class="panel-heading text-center">
                    <h4>ACCESSO</h4>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <label for="txCF" class="control-label">Codice Fiscale</label>

                            <asp:TextBox ID="txCF" MaxLength="16" CssClass="form-control " runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="txSocio" class="control-label">Numero Socio</label>

                            <asp:TextBox ID="txSocio" CssClass="form-control  col-md-4 col-sm-4 col-xs-12" runat="server" TextMode="Password"></asp:TextBox>

                        </div>

                        <asp:Button ID="btnLogin" runat="server" CssClass="margin10 btn btn-md btn-primary" Text="Login" OnClick="btnLogin_Click" />


                        <div class="form-group">

                            <asp:Label ID="lblErr" CssClass="errorMessage" runat="server" Text=""></asp:Label>

                        </div>

                        <div class="loading" id="loading" align="center">

                            <img src="./images/loading.gif" alt="" />
                        </div>
                    </form>
                    <div class="modal" id="modal" style="display: none"></div>
                </div>
            </div>
        </div>
        </div>
        <script type="text/javascript">
          /* 
            $(window).load(function () {
                // Animate loader off screen
                $(".se-pre-con").fadeOut("slow");;
            });*/
            $(document).ready(function () {
                $('#btnLogin').click(function () {
                    $('#btnLogin').after('<div class="margin10"><img class="loading-ajax" src="/images/loader.gif" alt="Loading" /><div>')


                });
            });
        </script>
</body>
</html>

