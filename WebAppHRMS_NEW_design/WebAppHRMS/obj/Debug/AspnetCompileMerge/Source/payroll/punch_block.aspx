<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="punch_block.aspx.vb" Inherits="WebAppHRMS.payroll_punch_block_cdf477c58722" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[

function btn_exit_onclick() {
window.open('../Home.aspx','_self');
}
var cont=loanno.split('txt');
function correct(a,e) 
{ 
    var iKeyCode = 0;     
    iKeyCode = window.event.keyCode;
    
    if (iKeyCode<=46 || iKeyCode>57)
    {   
        document.getElementById(cont[0]+a).focus();
        return false;
    }   
            
}
function correct_char(a,e) 
{ 
    var iKeyCode = 0;     
    iKeyCode = window.event.keyCode;   
    if (iKeyCode==35 || iKeyCode==36 || iKeyCode==64)
    {   
        document.getElementById(cont[0]+a).focus();
        return false;
    }   
            
}
function fill1()
{
    if(document.getElementById(cont[0]+"txt_code").value!="")
     {
        document.getElementById(cont[0]+"txt_name").value="";      
        call_server("1@"+document.getElementById(cont[0]+"txt_code").value)
    }
    else
    {
        document.getElementById(cont[0]+"txt_name").value="";   
    }
}
function window_onload() {
        document.getElementById(cont[0]+"txt_name").value="";        
        document.getElementById(cont[0]+"Panel1").innerHTML="";         
        document.getElementById("row1").style.display = "none";
}
function call_receiver(arg1)
{
var arg2;
arg2=arg1.split("@");
    if(arg2[0]==11)
    {
        if(arg2[1]==1)
        {
            alert("Invalid Employee Code");        
            return false;   
        }
        else
        {   
         if(arg2[1]==2)
            {
                alert("Already Added For Blocking...Inform IT...");                  
                return false;   
            }
         else
            {   
                document.getElementById(cont[0]+"txt_name").value=arg2[1];
            }
        }
    }
    if(arg2[0]==22)
    {
        alert(arg2[2]);   
        if(arg2[1]==1)
        {          
            window.open('../Home.aspx','_self');
        }
    }   
}
function fill_tab()
{
        if(document.getElementById(cont[0]+"txt_reason").value=="")
        {
            alert("Enter Reason");        
            return false;   
        }
        if(document.getElementById(cont[0]+"txt_code").value=="")
        {
            alert("Enter Employee Code");        
            return false;   
        }
        if(document.getElementById(cont[0]+"txt_name").value=="")
        {
            alert("Enter Employee Code");        
            return false;   
        }  
var dt;
var st;
 if (document.getElementById(cont[0]+"hid_details").value!="")
   {  
    dt=document.getElementById(cont[0]+"hid_details").value.split("$");
    for(i=0;i<dt.length-1;i++)
       {
            st=dt[i].split("#");
            if(st[0]==document.getElementById(cont[0]+"txt_code").value)
            {
                alert('Already Added!... Check Below');
                document.getElementById(cont[0]+"txt_name").value="";   
                return false;
            }
       }
   }   
   if (document.getElementById(cont[0]+"hid_details").value=="")
   {  
      document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"txt_code").value+"#"+document.getElementById(cont[0]+"txt_name").value+"$"
   }
 else
   {
      document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"hid_details").value+document.getElementById(cont[0]+"txt_code").value+"#"+document.getElementById(cont[0]+"txt_name").value+"$"
   } 
disp()
}
function disp()
{
var dt;
var st;

 if (document.getElementById(cont[0]+"hid_details").value!="")
   {  
   document.getElementById(cont[0]+"txt_reason").readOnly=true;
   dt=document.getElementById(cont[0]+"hid_details").value.split("$");
     tab = "<table style='width:100%;' border=1><tr style='color: Blue'><td colspan=3 align=center><b>Blocking&nbsp;Employees</b></td></tr>"
   tab=tab+"<tr><td><b>Employee&nbsp;Code</b></td><td><b>Employee&nbsp;Name</b></td><td><b>Delete</b></td></tr>"
   for(i=0;i<dt.length-1;i++)
       {       
              st=dt[i].split("#");     
              tab=tab+"<tr><td>"+ st[0] +"</td><td>"+ st[1] +"</td><td><a href=javascript:del('" + st[0] + "')>del</td></tr>"
       }    
   document.getElementById(cont[0]+"Panel1").innerHTML=tab;         
   document.getElementById("row1").style.display = "table-row";
   document.getElementById(cont[0]+"txt_code").value="";
   document.getElementById(cont[0]+"txt_name").value=""; 
 }
}
function del(id)
{
var dt;
var st;
    dt=document.getElementById(cont[0]+"hid_details").value.split("$");
    document.getElementById(cont[0]+"hid_details").value="";
    for(i=0;i<dt.length-1;i++)
       {
            st=dt[i].split("#");
            if(st[0]!=id)
            {
                 if (document.getElementById(cont[0]+"hid_details").value=="")
                    {  
                        document.getElementById(cont[0]+"hid_details").value=st[0]+"#"+st[1]+"$"
                    }
                else
                    {
                        document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"hid_details").value+st[0]+"#"+st[1]+"$"
                    }
            }
       }
  if(document.getElementById(cont[0]+"hid_details").value=="")
  {
     document.getElementById(cont[0]+"Panel1").innerHTML="";         
     document.getElementById("row1").style.display = "none";
     document.getElementById(cont[0]+"txt_reason").readOnly=false;
  }   
  disp()  
}
function fill_dtl()
{
      if(document.getElementById(cont[0]+"hid_details").value=="")
        {
            alert('Enter Details');
        }
      else
        {
            call_server("2@"+document.getElementById(cont[0]+"hid_details").value+"@"+document.getElementById(cont[0]+"txt_reason").value)
        }
}
// ]]>
</script>

    <div style="text-align: center">
        <input id="hid_details" runat="server" style="width: 16px" type="hidden" />
        <table border="1" style="width: 704px; font-family: 'Courier New'">
            <tr>
                <td colspan="4">
                    <strong style="color: red">EMPLOYEE&nbsp;PUNCH&nbsp;BLOCKING</strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    Enter Reason For Blocking</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_reason" runat="server" Width="424px" MaxLength="100"  onkeypress="return correct_char('txt_reason',event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    Enter&nbsp;Employee&nbsp;Code</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_code" runat="server" MaxLength="7" onkeypress="return correct('txt_code',event)" onblur="return fill1()" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    Employee&nbsp;Name</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_name" runat="server" Width="424px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btn_add" type="button" value="ADD" onclick="return fill_tab()"/></td>
            </tr>
            <tr id="row1">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" >
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4"><input id="btn_confirm" type="button" value="CONFIRM" style="width: 80px" onclick="return fill_dtl()" />
                    <input id="btn_exit" type="button" value="EXIT" style="width: 80px" onclick="return btn_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

