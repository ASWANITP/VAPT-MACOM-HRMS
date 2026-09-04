<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="myreportm.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_myreportm_e8ba7a3f8193" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>my movement report</title>
    
</head>


 




<script language=javascript> 
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
  window.open("../home.aspx",'_self');
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}


//function sliding()
//{

//  
//document.getElementById("3").innerHTML=3;



//}


</script>





<body onload="startTime()" style="text-align: center">
    <form id="form1" runat="server">   
    
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>



      <table style="width:auto">

<tr>




<td style="width:201.5px; color:Red" >
PRE
</td>
<td style="width:201.5px; color:Red" >
3M
</td>
<td style="width:201.5px; color:Red">
6M

</td>

<td style="width:201.5px; color:Red">

9M
</td>


<td style="width:201.5px; color:Red">
1YR

</td>

</tr>
</table>








           
    <div style="text-align: center">
    <asp:Panel ID="Panel1"  BorderStyle="Ridge" runat="server" Width="805px">
       
       

     <cc1:SliderExtender  Maximum="4"  Length="800"  ID="se1" runat="server"
 TargetControlId="Slider1" BoundControlID="SliderValue" />
    
   
    <asp:TextBox ID="Slider1" runat="server" AutoPostBack="true" />
    
 </asp:Panel>
 
 
 
 <%-- <span style="color:red;font-weight:bold">3m
    
    
    
    &nbsp;&nbsp;6m
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;9m
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1yr
   
    
    </span>--%>

 

 
 <br />
 
 
 <div style="display:none;">
 
 
 
<asp:TextBox ID="SliderValue"  OnTextChanged="txt_CHA_TextChanged" runat="server" AutoPostBack="true" />
  </div>
   
   
    <asp:TextBox ID="TextBox1" runat="server" TextMode="Singleline" Rows="6" Width="20" />
    
    
    
    
    </div>
    <br />

    <div style="text-align: center">
        <div style="text-align: center">
            <asp:Panel ID="Panel0" runat="server" Width="90%">
       
        </asp:Panel>
        
                    <asp:Panel ID="Panel2" runat="server" Width="90%">
       
        </asp:Panel>
        
        <asp:Panel ID="Panel3" runat="server" Width="90%">
       
        </asp:Panel>
        
        <asp:Panel ID="Panel4" runat="server" Width="90%">
       
        </asp:Panel>
        
        <asp:Panel ID="Panel5" runat="server" Width="90%">
       
        </asp:Panel>
        </div>
        
            
    </div>
    </form>
    
   
</body>
</html>

