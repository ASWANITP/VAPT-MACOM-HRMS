<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_above_10_select.aspx.vb" Inherits="WebAppHRMS.leave_above_10_select_821ce8f49183" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('Txt');

function Cmd_Exit_onclick() {
 window.open('../../../home.aspx','_self');
}

function checknumber(t)
{
  var a=document.getElementById(cont_name[0]+t).value;
  if(isNaN(a)) 
  {
    alert('pls enter correct value in number format!!');
    document.getElementById(cont_name[0]+t).value="";
    document.getElementById(cont_name[0]+t).focus;
    return false;
   }
}

function checkperm()
{
 if(document.getElementById(cont_name[0]+"Chk_Perm").checked==true)
 {
 document.getElementById(cont_name[0]+"Chk_Out").checked=false;
 document.getElementById(cont_name[0]+"Chk_All").checked=false;
 document.getElementById(cont_name[0]+"Hid_Status").value=1;
 }
 if(document.getElementById(cont_name[0]+"Chk_Perm").checked==false)
 {
  document.getElementById(cont_name[0]+"Hid_Status").value=0;
 }
}
function checkOut()
{
 if(document.getElementById(cont_name[0]+"Chk_Out").checked==true)
 {
 document.getElementById(cont_name[0]+"Chk_Perm").checked=false;
 document.getElementById(cont_name[0]+"Chk_All").checked=false;
 document.getElementById(cont_name[0]+"Hid_Status").value=2;
 }
 if(document.getElementById(cont_name[0]+"Chk_Out").checked==false)
 {
  document.getElementById(cont_name[0]+"Hid_Status").value=0;
 }
}
function checkAll()
{
 if(document.getElementById(cont_name[0]+"Chk_All").checked==true)
 {
 document.getElementById(cont_name[0]+"Chk_Perm").checked=false;
 document.getElementById(cont_name[0]+"Chk_Out").checked=false;
 document.getElementById(cont_name[0]+"Hid_Status").value=0;
 }
 if(document.getElementById(cont_name[0]+"Chk_All").checked==false)
 {
  document.getElementById(cont_name[0]+"Hid_Status").value=0;
 }
}
function init() {
document.getElementById(cont_name[0]+"Chk_All").checked=true;
document.getElementById(cont_name[0]+"Hid_Status").value=0;
document.getElementById(cont_name[0]+"Chk_Perm").checked=false;
 document.getElementById(cont_name[0]+"Chk_Out").checked=false;
document.getElementById(cont_name[0]+"Txt_LeaveNo").value="";

document.getElementById(cont_name[0]+"Check_Designation").checked=false;
document.getElementById(cont_name[0]+"Cmb_Designation").disabled=true;
document.getElementById(cont_name[0]+"Hid_Designation").value=0;

document.getElementById(cont_name[0]+"Check_Post").checked=false;
document.getElementById(cont_name[0]+"Cmb_Post").disabled=true;
document.getElementById(cont_name[0]+"Hid_Post").value=0;
}
window.onload = init; 

//function date(a)
//{
//  alert('Please select date from Calendar by clicking on the Date Box.\nYou Cannot enter date by Typing !!');
//  document.getElementById(cont_name[0]+a).value="";
//  return false;
//}

function checkdesig()
{
 if(document.getElementById(cont_name[0]+"Check_Designation").checked==true)
 {
 document.getElementById(cont_name[0]+"Check_Post").checked=false;
 document.getElementById(cont_name[0]+"Hid_Post").value=0;
 document.getElementById(cont_name[0]+"Cmb_Post").disabled=true;
 document.getElementById(cont_name[0]+"Cmb_Designation").disabled=false; 
 document.getElementById(cont_name[0]+"Hid_Designation").value=document.getElementById(cont_name[0]+"Cmb_Designation").value;
 }
 if(document.getElementById(cont_name[0]+"Check_Designation").checked==false)
 {
  document.getElementById(cont_name[0]+"Cmb_Designation").disabled=true;
  document.getElementById(cont_name[0]+"Hid_Designation").value=0;
 }
}

function checkpost()
{
 if(document.getElementById(cont_name[0]+"Check_Post").checked==true)
 {
 document.getElementById(cont_name[0]+"Check_Designation").checked=false;
 document.getElementById(cont_name[0]+"Cmb_Designation").disabled=true;
 document.getElementById(cont_name[0]+"Hid_Designation").value=0;
 document.getElementById(cont_name[0]+"Cmb_Post").disabled=false; 
 document.getElementById(cont_name[0]+"Hid_Post").value=document.getElementById(cont_name[0]+"Cmb_Post").value;
 }
 if(document.getElementById(cont_name[0]+"Check_Post").checked==false)
 {
  document.getElementById(cont_name[0]+"Cmb_Post").disabled=true;
  document.getElementById(cont_name[0]+"Hid_Post").value=0;
 }
}
function desigchange()
{
 document.getElementById(cont_name[0]+"Hid_Designation").value=document.getElementById(cont_name[0]+"Cmb_Designation").value;
}
function postchange()
{
 document.getElementById(cont_name[0]+"Hid_Post").value=document.getElementById(cont_name[0]+"Cmb_Post").value;
}

function cliclick()
{
  if(document.getElementById(cont_name[0]+"Txt_LeaveNo").value=="")
 {
  alert('Please Enter No of Leave Days !!');
//  document.getElementById(cont_name[0]+"Txt_EmpFrom").focus;
  return false;
 }
// if(document.getElementById(cont_name[0]+"Txt_Empto").value=="")
// {
//  alert('Please Enter Employee code To!!');
////  document.getElementById(cont_name[0]+"Txt_Empto").focus;
//  return false;
// }
// if(document.getElementById(cont_name[0]+"Txt_FromDate").value=="")
// {
//  alert('Please Enter From Date!!');
////  document.getElementById(cont_name[0]+"Txt_FromDate").focus;
//  return false;
// }
// if(document.getElementById(cont_name[0]+"Txt_ToDate").value=="")
// {
//  alert('Please Enter To Date!!');
////  document.getElementById(cont_name[0]+"Txt_ToDate").focus;
//  return false;
// }
}



// ]]>
</script>

    &nbsp;<br />
    <br />
    <br />
    <br />
    <div style="text-align: center">
        <table border="1" style="width: 393px">
            <tr>
                <td style="width: 179px; text-align: left">
                    <strong>Permanant:</strong></td>
                <td style="width: 34px; text-align: left">
                    <asp:CheckBox ID="Chk_Perm" onclick="checkperm()" runat="server" Style="cursor: hand" Width="113px" /></td>
                <td style="width: 137px; text-align: right">
                    <strong>Outsource:</strong></td>
                <td style="width: 43px; text-align: left">
                    <asp:CheckBox ID="Chk_Out" onclick="checkOut()" runat="server" Style="cursor: hand" TabIndex="1" Width="107px" /></td>
                <td style="width: 100px; text-align: right">
                    <strong>&nbsp;All:</strong></td>
                <td style="width: 44px; text-align: left">
                    <asp:CheckBox ID="Chk_All" onclick="checkAll()" runat="server" Style="cursor: hand" TabIndex="2" Width="105px" /></td>
            </tr>
            <tr>
                <td style="width: 179px; text-align: left">
                    <asp:CheckBox ID="Check_Designation" onclick="checkdesig()" runat="server" Width="109px" Text="Designation:" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="Cmb_Designation" onchange="desigchange()" runat="server" Width="190px">
                    </asp:DropDownList></td>
                <td style="width: 43px; text-align: left">
                    <asp:CheckBox ID="Check_Post" onclick="checkpost()" runat="server" Width="115px" Text="Post:" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="Cmb_Post" onchange="postchange()" runat="server" Width="176px">
                    </asp:DropDownList></td>
            </tr>
        </table>
    
    <table border="1" style="width: 622px">
        <tr>
            <td style="width: 162px; text-align: left">
                <strong>No of Leave Days:</strong></td>
            <td style="text-align: left" colspan="3">
                <asp:TextBox ID="Txt_LeaveNo" onkeyup="return checknumber('Txt_LeaveNo')" runat="server" Width="85px" MaxLength="3" TabIndex="3"></asp:TextBox><strong></strong></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; height: 28px;">
                <input id="Cmd_Exit" style="width: 78px; cursor: hand" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" tabindex="4" /></td>
            <td colspan="2" style="text-align: left; height: 28px;">
                <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Style="cursor: hand" Text="CONFIRM" TabIndex="5" /></td>
        </tr>
    </table>
        <br />
        &nbsp;
        <asp:HiddenField ID="Hid_Status" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_Designation" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_Post" runat="server" Value="0" />
        <br />
    </div>
</asp:Content>

