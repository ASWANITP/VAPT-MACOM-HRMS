<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="leaveless10_report.aspx.vb" Inherits="WebAppHRMS.leave_leavegreater10_report_899101409419" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<script type="text/javascript" >
function startTime()
{
var today=new Date();
var h=today.getHours();
var m=today.getMinutes();
var s=today.getSeconds();
// add a zero in front of numbers<10
if (h>12)
{
  var a="PM";
}
else
{
  a="AM";
}
h=checkhour(h)
m=checkTime(m);
s=checkTime(s);

document.getElementById('txt').innerHTML=h+":"+m+":"+s+a;
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

function checkhour(i)
{
 if(i>12)
 {
   i=i-12;
   if (i<10)
  {
  i="0" + i;
  }
 }

 return i;
}
</script>

<body onload="startTime()" style="text-align: center">


    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="112px" Width="824px">
        </asp:Panel>
        </div>
    </form>
</body>
</html>
