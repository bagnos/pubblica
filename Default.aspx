<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pa_taverne._Default" %>
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
                <td class="TdMainLeft" align="center" valign="top">
                    <Layout:Left ID="Left" runat="server" />
                    <%--Notizia inserita da 10 giorni lampeggio new --%>
                    <br />
                    <br />
                    &nbsp;
                    </td>
                <td class="TdMainCorpo" align="center" valign="top">
                    <div   id="container">
                    <table cellpadding="3" class="TabellaGenerica" cellspacing="0" width="100%" >
                    <tr class="TrHeader">
                        <td align="center" class="TestoP" colspan="2"><b>INIZIATIVE</b></td>
                    </tr>
                    <tr>
                        
                        <td align="center" valign="top" style="width:95%">
                           <SCRIPT language="JavaScript1.2">

                                //Manual Scroller- © Dynamic Drive 2001
                                //For full source code, visit http://www.dynamicdrive.com

                                //specify speed of scroll (greater=faster)
                                var speed=1

                                iens6=document.all||document.getElementById
                                ns4=document.layers

                                if (iens6){
                                document.write('<div id="container" style="position:relative;width:100%;height:690px;overflow:hidden;">')
                                document.write('<div id="content" style="position:absolute;width:450px;left:0px;top:0px">')
                                }
                            </script> 
                            <ilayer name="nscontainer" width="100%" height="690px" clip="0,0,155,160">
                            <layer name="nscontent" width="450px" height="690px" visibility="hidden">
                                <asp:Label ID="lnblNews" runat="server"></asp:Label>
                            </layer>
                            </ilayer>
                            
                            <script language="JavaScript1.2">
                                if (iens6){
                                document.write('</div></div>')
                                var crossobj=document.getElementById? document.getElementById("content") : document.all.content
                                var contentheight=crossobj.offsetHeight
                                }
                                else if (ns4){
                                var crossobj=document.nscontainer.document.nscontent
                                var contentheight=crossobj.clip.height
                                }

                                function movedown(){
                                if (window.moveupvar) clearTimeout(moveupvar)
                                if (iens6&&parseInt(crossobj.style.top)>=(contentheight*(-1)+100))
                                crossobj.style.top=parseInt(crossobj.style.top)-speed+"px"
                                else if (ns4&&crossobj.top>=(contentheight*(-1)+100))
                                crossobj.top-=speed
                                movedownvar=setTimeout("movedown()",20)
                                }

                                function moveup(){
                                if (window.movedownvar) clearTimeout(movedownvar)
                                if (iens6&&parseInt(crossobj.style.top)<=0)
                                crossobj.style.top=parseInt(crossobj.style.top)+speed+"px"
                                else if (ns4&&crossobj.top<=0)
                                crossobj.top+=speed
                                moveupvar=setTimeout("moveup()",20)
                                }

                                function stopscroll(){
                                if (window.moveupvar) clearTimeout(moveupvar)
                                if (window.movedownvar) clearTimeout(movedownvar)
                                }

                                function movetop(){
                                stopscroll()
                                if (iens6)
                                crossobj.style.top=0+"px"
                                else if (ns4)
                                crossobj.top=0
                                }

                                function getcontent_height(){
                                if (iens6)
                                contentheight=crossobj.offsetHeight
                                else if (ns4)
                                document.nscontainer.document.nscontent.visibility="show"
                                }
                                window.onload=getcontent_height
                            </script>
                        </td>
                        <td align="center" style="width:5%" valign="top">
                            <img src="Immagini/frecciasu.gif" style="cursor:pointer;" alt="Scorri su" title="Scorri su" onmouseover="javascript:moveup()" onmouseout="javascript:stopscroll()" /><br /><br />
                            <img src="Immagini/frecciagiu.gif" style="cursor:pointer;" alt="Scorri giù" title="Scorri giù" onmouseover="javascript:movedown()" onmouseout="javascript:stopscroll()" /><br /><br />
                            <img src="Immagini/Inizio.gif" style="cursor:pointer;" alt="Vai all'inizio" title="Vai all'inizio" onclick="javascript:movetop()" /><br />
                          
                        </td>
                    </tr>
                    </table>
                     
                    </div>
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
