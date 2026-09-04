<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_code_select.aspx.vb" Inherits="WebAppHRMS.Old_New_EmpCode_emp_code_select_a34986ae4223" title="Find Regularised Employees" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('Txt');
function Cmd_Exit_onclick() {

window.open('../home.aspx','_self');

}
function date(a)
{
  alert('Please select date from Calendar by clicking on the Date Box.\nYou Cannot enter date by Typing !!');
  document.getElementById(cont_name[0]+a).value="";
  return false;
}
function checknum(a)
{
 var ecode=document.getElementById(cont_name[0]+a).value;
 if(isNaN(ecode))
 {
   document.getElementById(cont_name[0]+a).value=""
  return false;
 }
 
}
function checkCode()
{
 if(document.getElementById(cont_name[0]+"Check_EmpCode").checked==true)
 {
  document.getElementById(cont_name[0]+"Txt_EmpCode").disabled=false;
  document.getElementById(cont_name[0]+"Txt_EmpCode").style.backgroundColor = 'white';
  document.getElementById(cont_name[0]+"Txt_EmpCode").focus();
  document.getElementById(cont_name[0]+"Txt_From").disabled=true;
  document.getElementById(cont_name[0]+"Txt_To").disabled=true;
  document.getElementById(cont_name[0]+"Txt_From").style.backgroundColor ='Linen';
  document.getElementById(cont_name[0]+"Txt_To").style.backgroundColor ='Linen';
 }
 if(document.getElementById(cont_name[0]+"Check_EmpCode").checked==false)
 {
  document.getElementById(cont_name[0]+"Txt_EmpCode").disabled=true;
  document.getElementById(cont_name[0]+"Txt_EmpCode").style.backgroundColor = 'LightGoldenrodYellow';
  document.getElementById(cont_name[0]+"Txt_EmpCode").value="";
  document.getElementById(cont_name[0]+"Txt_From").disabled=false;
  document.getElementById(cont_name[0]+"Txt_To").disabled=false;
  document.getElementById(cont_name[0]+"Txt_From").style.backgroundColor ='white';
  document.getElementById(cont_name[0]+"Txt_To").style.backgroundColor ='white';
 }
}

function cliclick()
{
 if(document.getElementById(cont_name[0]+"Check_EmpCode").checked==true)
 {
  if((document.getElementById(cont_name[0]+"Txt_EmpCode").value=="")||(document.getElementById(cont_name[0]+"Txt_EmpCode").value<9999))
  {
   alert('Please Enter a valid Employee Code!!');
   document.getElementById(cont_name[0]+"Txt_EmpCode").value="";
   document.getElementById(cont_name[0]+"Txt_EmpCode").focus();
   return false;
  }
 }
 if(document.getElementById(cont_name[0]+"Check_EmpCode").checked==false)
 {
  if(document.getElementById(cont_name[0]+"Txt_From").value=="")
  {
   alert('Please Enter Regularised From Date!!');
   document.getElementById(cont_name[0]+"Txt_From").focus();
   return false;
  }
  if(document.getElementById(cont_name[0]+"Txt_To").value=="")
  {
   alert('Please Enter Regularised To Date!!');
   document.getElementById(cont_name[0]+"Txt_To").focus();
   return false;
  }
//  if((document.getElementById(cont_name[0]+"Txt_To").value)<(document.getElementById(cont_name[0]+"Txt_From").value))
//  {
//   alert('Please Enter Big Date in Second Date Box!!');
//   document.getElementById(cont_name[0]+"Txt_From").value="";
//   document.getElementById(cont_name[0]+"Txt_To").value="";
//   return false;
//  }
 }
}
function init()
{
 document.getElementById(cont_name[0]+"Check_EmpCode").checked=false;
  document.getElementById(cont_name[0]+"Txt_EmpCode").disabled=true;
 document.getElementById(cont_name[0]+"Txt_EmpCode").value="";
 document.getElementById(cont_name[0]+"Txt_EmpCode").style.backgroundColor = 'LightGoldenrodYellow';
}
window.onload=init;


// ]]>
</script>

    
    <br />
    <div style="text-align: center">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager><br />
        <table border="1">
            <tr>
                <td style="width: 137px; text-align: left">
                    <strong>
                    Regularised From:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_From" onkeyup="return date('Txt_From')" runat="server" style="cursor: hand"></asp:TextBox></td>
                <td style="width: 127px; text-align: left">
                    <strong>
                    Regularised To:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_To" onkeyup="return date('Txt_To')" runat="server" TabIndex="1" style="cursor: hand"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">
                    <asp:CheckBox ID="Check_EmpCode" onclick="checkCode()" runat="server" TabIndex="2" Text="Enter Employee Code :" style="cursor: hand" ToolTip="Tick This for Employeewise Searching!!" Font-Bold="True" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="Txt_EmpCode" onkeyup="return checknum('Txt_EmpCode')" runat="server" MaxLength="5" TabIndex="3" Width="97px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    <input id="Cmd_Exit" style="width: 78px; cursor: hand;" tabindex="4" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
                <td style="text-align: left;" colspan="2">
                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" TabIndex="5" Text="CONFIRM" style="cursor: hand" /></td>
            </tr>
        </table>
         <cc1:CalendarExtender ID="CalendarExt_From" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_From">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExt_To" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_To">
    </cc1:CalendarExtender>
    </div>
   
    <br />
    <br />
</asp:Content>

