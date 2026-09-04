<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="sal_wage_report_individual.aspx.vb" Inherits="WebAppHRMS.salary_report_sal_wage_report_individual_047da15c1418" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script type="text/javascript">
function startTime()
{
var today=new Date();
var h=today.getHours();
var m=today.getMinutes();
var s=today.getSeconds();
 var dat;
 
            if(h > 12)
            {dat = "PM";}
            else if(h < 12)
            {dat = "AM";}
            else if(h==12 && m>0)
            {dat = "PM";}
            if (h == 0) { h = 12;}
            if (h > 12) {h = h - 12;}
            
// add a zero in front of numbers<10
m=checkTime(m);
s=checkTime(s);
document.getElementById('txt').innerHTML="TIME : "+ h+":"+m+":"+s + " " +dat;
t=setTimeout('startTime()',500);
}

function checkTime(i)
{
if (i<10)
  {
  i="0" + i;
  }
return i;
}
</script>
    <title>Untitled Page</title>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="54px" Width="581px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px">
        </asp:Panel>
        &nbsp;</div>
    </form>
</body>
</html>
