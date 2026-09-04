<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="earned_more_than_5.aspx.vb" Inherits="WebAppHRMS.leave_earned_more_than_5_b782aa856264" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
<!--
return window_onload()
// -->
</script>

<script language="javascript" type="text/javascript">
<!--
var cont=loanno.split("Lab")

function Button2_onclick() {
window.open('../Home.aspx','_self');
}

function window_onload() {
sub_call_server("1$")
}

function sub_call_receiver(arg1,arg2)
{
  var argg=arg1.split("@")
    
   if(argg[0]==11)
   {
   if(argg[1]==4)
   {
        document.getElementById(cont[0]+"Panel1").innerHTML="";
        alert("No Data");  
   }
   
   else
   {
   
  
      document.getElementById(cont[0]+"hid_details").value=argg[1];
      table_disp()
   }
   
   }  
   
   if(argg[0]==22)
   {
          if(argg[1]==1)
            {
            alert(argg[2])
            window.open('../Home.aspx','_self');
            }
            
        else
            {
            alert(argg[2])
            }  
          
   
   }
  // return false;
} 
 
function table_disp()
{

    
    if (document.getElementById(cont[0]+"hid_details").value=="")
        {  
            document.getElementById(cont[0]+"Panel1").innerHTML="";      
            return false;
        }
    else
        {
            arg1=document.getElementById(cont[0]+"hid_details").value
            var tab
            tab=""   
            var cnt  
            var dt   
            dt=""  
            cnt=0
            var rs=arg1.split("!")
            tab="<table align=center width=800px border=1><tr><td colspan=11 align=center style='font-size: 14pt;  font-family: Courier New'><b>Details </b></td></tr>"
            tab=tab+"<tr><td style='font-size: 14pt;  font-family: Courier New'>COUNT</td><td style='font-size: 14pt;  font-family: Courier New'>EMPLOYEE&nbsp;CODE</td><td style='font-size: 14pt;  font-family: Courier New'>EMPLOYEE&nbsp;NAME</td><td style='font-size: 14pt;  font-family: Courier New'>EARNED&nbsp;LEAVE</td><td style='font-size: 14pt;  font-family: Courier New'>EDIT</td></tr>"
                for (c=0;c<rs.length-1;c++)
                {	   
                   cnt+=1    
                   dt=rs[c].split("*") 
                    
                    tab=tab+"<tr><td style='font-size: 10pt;  font-family: Courier New'>"+ cnt +"</td><td style='font-size: 10pt;  font-family: Courier New'>"+ dt[0] +"</td><td style='font-size: 10pt;  font-family: Courier New' align='left'>"+ dt[1] +"</td><td style='font-size: 10pt;  font-family: Courier New'>"+ dt[2] +"</td><td style='font-size: 10pt;  font-family: Courier New' align='left'><input type='text' maxlength=2 style=' font-family: Courier New' size=10 style=TEXT-ALIGN:&nbsp;left onkeyup=val_text('txt_"+dt[0]+"','',"+dt[0]+") onblur=calc("+dt[0]+") id='txt_" +dt[0]+"' value="+0+"></td ></tr>"
                 }
                  tab=tab+"</table>"
                  document.getElementById(cont[0]+"panel1").innerHTML=tab
        }
        
}

function val_text(field,alerttext,no)
 {


   var value=document.getElementById(field).value
    if (value==" " || value==null || value<0 || isNaN(value))
        {
            alert('error value');
            document.getElementById(field).value=""
            return false;
        }
   
   arg1=document.getElementById(cont[0]+"hid_details").value
   var rs=arg1.split("!")
   for (i=0;i<rs.length-1;i++)
     {	
         
      var dt=rs[i].split("*")
      if (dt[0]==no)
      {
        if(Math.abs(document.getElementById(field).value)>Math.abs(dt[2])-17)
        {
        alert('Error value');
        document.getElementById(field).value=""
        return false;
        }
      }
   }
     
     
 }
 
function calc(no)
{

   arg1=document.getElementById(cont[0]+"hid_details").value
   var rs=arg1.split("!")
   var new_emp;
   var new_row;
   new_emp="";
   new_row="";
    for (i=0;i<rs.length-1;i++)
     {	
          
      var dt=rs[i].split("*")
      
      if(dt[0]==no)
       {
       
        if(document.getElementById('txt_'+no).value=="")
        {
        document.getElementById('txt_'+no).value=0;
        }
         new_row=dt[0]+"*"+dt[1]+"*"+dt[2]+"*"+document.getElementById('txt_'+no).value
         
          if (new_emp=="")
          {
          new_emp=new_row
          }
          else
          {
          new_emp=new_emp+"!"+new_row
          }                 
       }
       else
       {
          if (new_emp=="")
          {
          new_emp=rs[i]
          }
          else
          {
          new_emp=new_emp+"!"+rs[i]
          }
      }
     } 
     
 document.getElementById(cont[0]+"hid_details").value=new_emp+"!";
}

function chk_confirm()
{
if(document.getElementById(cont[0]+"hid_details").value!="")
{
arg1=document.getElementById(cont[0]+"hid_details").value
var rs=arg1.split("!")
var new_emp1
var new_row1
new_emp1=""
    for (i=0;i<rs.length-1;i++)
     {	
       
             
          var dt=rs[i].split("*")
          new_row1=dt[0]+"*"+dt[2]+"*"+dt[3]                 
          if(new_emp1=="")
          {
          new_emp1=new_row1
          
          }
          else
          {
          new_emp1=new_emp1+"!"+new_row1
          }    
          
     }  
sub_call_server("2$"+new_emp1);
}
}
// -->
</script>

    <div style="text-align: center">
      
        <table border="1" style="width: 824px">
            <tr>
                <td colspan="2">
                    <B><span style="font-size: 16pt; color:red; font-family: Courier New">
                    EARNED LEAVE</span></B></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
    <asp:Panel ID="Panel1" runat="server" Height="74px" Width="214px">
    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    <input id="Button1" type="button" value="SUBMIT" onclick="return chk_confirm()" style="font-family: 'Courier New'"/><input id="Button2" style="width: 90px; font-family: 'Courier New';" type="button" value="EXIT" language="javascript" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
                    <input id="hid_details" runat="server" style="width: 11px" type="hidden" />
</asp:Content>

