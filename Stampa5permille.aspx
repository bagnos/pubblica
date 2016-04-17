<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stampa5permille.aspx.cs" Inherits="pa_taverne.Stampa5permille" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Stampa() {
            if (!window.print) {
                alert("Browser non supportato!")
                return
            }
            window.print() 
        }
    </script>
</head>
<body onload="javascript:Stampa();">
    <form id="form1" runat="server">
    <div>
    <img src="Immagini/5xmille20100.png" alt=""/>
    </div>
    </form>
</body>
</html>
