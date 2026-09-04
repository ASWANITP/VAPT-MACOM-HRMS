<%@ Page Language="VB" ValidateRequest="false" enableEventValidation="false" AutoEventWireup="false" CodeBehind="TAsplitindi.aspx.vb" Inherits="WebAppHRMS.honormsandshort_honorshsur_d76245355411" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Staff Norms,Shortage and Surplus Report</title>
</head>
<script language="javascript" type="text/javascript"> 
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

function Button1_onclick() 
{
  window.open("../../home.aspx",'_self');
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}

function export() 
{
  
}
</script>

<body onload="startTime()" style="text-align: center">
    <form id="form1" runat="server">    

    <div style="text-align: center">
        <div style="text-align: center">
            <table>
                <tr>
                   
                   
                </tr>
            </table>
        </div>
        <asp:Panel ID="PanelHoNSS" runat="server" Width="90%">
        </asp:Panel>
    
    </div>
    </form>
    
   <asp:GridView ID="griv" runat="server"></asp:GridView>
   <input runat="server" type="button" value="EXPORT TO EXCEL" id="btexport" /> 
   
</body>
</html>
