<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Reportwage_Old.aspx.vb" Inherits="WebAppHRMS.Payroll_Reportwage_Old_6a4e7bee9046" %>

<%--<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Reportwage.aspx.vb" Inherits="Reportwage_d0e8875b9046" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
  window.open("../home.aspx",'_self');
}
function demo()
{

var prtContent = document.getElementById("ej");
//////////
var WinPrint1 = window.open('', '', 'left=0,top=0,width=750,height=950,toolbar=1,scrollbars=1,status=1');
WinPrint1.document.write(prtContent.innerHTML);
WinPrint1.document.close();
WinPrint1.focus();
/////////
var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=1,status=1');
WinPrint.document.write(prtContent.innerHTML);
WinPrint.document.close();
WinPrint.focus();
WinPrint.print();
WinPrint.close();
}
function window_onload()
{
    callserver(1,1); 
}
function call_receiver(arg,context) 
{   
 document.getElementById("ej").innerHTML = arg;      
}
</script>
</head>
<body>
    <form id="form1" runat="server">
 <%--    <div style="text-align:center; ">--%>
<%--<asp:Panel HorizontalAlign ="center" ID="Panel1" runat="server">--%>
    <div id="ej" class="avoid">
    </div>
    <div style="text-align:center ;">
  
    <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/>
    
     <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
 
       </div>
       <%--</div>--%>
    </form>
</body>
</html>
