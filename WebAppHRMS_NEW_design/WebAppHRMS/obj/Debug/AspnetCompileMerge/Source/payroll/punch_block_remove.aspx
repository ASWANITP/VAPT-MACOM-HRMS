<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="punch_block_remove.aspx.vb" Inherits="WebAppHRMS.payroll_punch_block_cdf477c52226" title="Untitled Page" %>
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

function fill1()
{
var dtl;
if(document.getElementById(cont[0]+"cmb_emp").value!="-1")
 {
    dtl=document.getElementById(cont[0]+"cmb_emp").options[document.getElementById(cont[0]+"cmb_emp").selectedIndex].text.split("*");
    document.getElementById(cont[0]+"txt_name").value=dtl[0];
    document.getElementById(cont[0]+"txt_code").value=dtl[1];
    document.getElementById(cont[0]+"txt_reason").value=dtl[2];
 }
else
 {
    document.getElementById(cont[0]+"txt_name").value="";
    document.getElementById(cont[0]+"txt_code").value="";
    document.getElementById(cont[0]+"txt_reason").value="";
 }
}
function window_onload() {                
        document.getElementById(cont[0]+"Panel1").innerHTML="";         
        document.getElementById("row1").style.display = "none";}
      

function fill_tab()
{
 if(document.getElementById(cont[0]+"cmb_emp").value!="-1")
  {
   if (document.getElementById(cont[0]+"hid_details").value!="")
    {  
    dt=document.getElementById(cont[0]+"hid_details").value.split("$");
    for(i=0;i<dt.length-1;i++)
       {
            
            if(dt[i]==document.getElementById(cont[0]+"cmb_emp").options[document.getElementById(cont[0]+"cmb_emp").selectedIndex].text)
            {
                alert('Already Added!... Check Below');
                document.getElementById(cont[0]+"cmb_emp").value="-1";
                document.getElementById(cont[0]+"txt_name").value="";   
                document.getElementById(cont[0]+"txt_code").value="";   
                document.getElementById(cont[0]+"txt_reason").value="";   
                return false;
            }
       }
    } 
       if (document.getElementById(cont[0]+"hid_details").value=="")
       {  
          document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"cmb_emp").options[document.getElementById(cont[0]+"cmb_emp").selectedIndex].text+"$"
       }
     else
       {
          document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"hid_details").value+document.getElementById(cont[0]+"cmb_emp").options[document.getElementById(cont[0]+"cmb_emp").selectedIndex].text+"$"
       } 
        document.getElementById(cont[0]+"txt_name").value="";
        document.getElementById(cont[0]+"txt_code").value="";
        document.getElementById(cont[0]+"txt_reason").value="";
        document.getElementById(cont[0]+"cmb_emp").value="-1";
  }
  else
  {
    alert('Select Employee...');
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
     tab ="<table style='width:100%;' border: 1px solid black; text-align: left;' border=1><tr style='color: Blue'><td colspan=11 align=center><b>Removing&nbsp;Employees</b></td></tr>"
   tab=tab+"<tr><td><b>Employee&nbsp;Code</b></td><td><b>Employee&nbsp;Name</b></td><td><b>Reason</b></td><td><b>Delete</b></td></tr>"
   for(i=0;i<dt.length-1;i++)
       {       
              st=dt[i].split("*");     
              tab=tab+"<tr><td>"+ st[0] +"</td><td>"+ st[1] +"</td><td>"+ st[2] +"</td><td><a href=javascript:del('" + st[0] + "')>del</td></tr>"
       }    
   document.getElementById(cont[0]+"Panel1").innerHTML=tab;         
     document.getElementById("row1").style.display = "table-row";
     
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
        st=dt[i].split("*");     
          if(st[0]!=id)
            {
                 if (document.getElementById(cont[0]+"hid_details").value=="")
                    {  
                        document.getElementById(cont[0]+"hid_details").value=dt[i]+"$"
                    }
                else
                    {
                        document.getElementById(cont[0]+"hid_details").value=document.getElementById(cont[0]+"hid_details").value+dt[i]+"$"
                    }
            }
       }
  if(document.getElementById(cont[0]+"hid_details").value=="")
  {
     document.getElementById(cont[0]+"Panel1").innerHTML="";         
     document.getElementById("row1").style.display = "none";
  }   
  disp()  
}
function fill_dtl()
{
      if(document.getElementById(cont[0]+"hid_details").value=="")
        {
            alert('Select Employee And Click Add');
            return false;
        }
}
// ]]>
</script>

    <div style="text-align: center">
        &nbsp;<input id="hid_details" runat="server" style="width: 16px" type="hidden" />
        <div style="text-align: center">
            <table border="1" style="width: 696px">
                <tr>
                    <td colspan="4">
                        <strong><span style="color: #ff0000">EMPLOYEE&nbsp;PUNCH&nbsp;BLOCK REMOVAL</span></strong></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 215px">
                    Select Employee</td>
                    <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="472px" onchange="return fill1()">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 215px; text-align: center">
                        Employee&nbsp;Code</td>
                    <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_code" runat="server" ReadOnly="True" Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 215px; text-align: center">
                    Employee&nbsp;Name</td>
                    <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_name" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; width: 215px;">
                    Reason For Blocking</td>
                    <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_reason" runat="server" Width="464px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                    <input id="btn_add" type="button" value="ADD" onclick="return fill_tab()"/></td>
                </tr>
        <tr id="row1">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server"  >
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" OnClientClick="return fill_dtl()"/>
                    <input id="btn_exit" type="Button" value="EXIT" style="width: 80px" onclick="return btn_exit_onclick()" /></td>
            </tr>
            </table>
        </div>
    </div>
</asp:Content>

