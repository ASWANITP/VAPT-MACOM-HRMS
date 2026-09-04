<%--<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="emp_leave_select.aspx.vb" Inherits="Payroll_emp_leave_select" %>--%>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_leave_select_mafm.aspx.vb" Inherits="WebAppHRMS.Leave_Details_emp_leave_select_7d01b3034186" title="Empwise Leave Details" %>

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
  document.getElementById(cont_name[0]+a).focus();
  return false;
}

function cliclick()
{


  if(document.getElementById(cont_name[0]+"Txt_From").value=="")
 {
  alert('Please Enter From Date !!');
  document.getElementById(cont_name[0]+"Txt_From").focus();
  return false;
 }
 if(document.getElementById(cont_name[0]+"Txt_to").value=="")
 {
  alert('Please Enter To Date!!');
  document.getElementById(cont_name[0]+"Txt_to").focus();
  return false;
 }
//   if(document.getElementById(cont[0]+"Cmb_Leave").value=-1)
// {
//  alert('Please Select Employee !!');
//  document.getElementById(cont_name[0]+"Cmb_Leave").focus();
//  return false;
// }
}

// ]]>
</script>
<div style="text-align: center">
         <table  border="1" style="margin:0px auto;" >
            <tr>
                <td colspan="4" style="height: 41px; text-align: center; width: 780px;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                        <strong><span style="text-decoration: underline">LEAVE &nbsp;&nbsp; &nbsp;REPORT</span></strong></span></span></span><%--<asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </span></strong>
                    </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="width: 780px; height: 37px; text-align: center">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>

<%--   <div style="text-align: center">
        <br />
        <br />--%>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <tr>
        <td style="width: 122px; text-align: left">
                    <strong>
                    Select Choice :</strong></td>
         <td style="width: 100px; text-align: left">
         <asp:CheckBox ID="Ckpost" runat="server" Autopostback="true"/>PostWise</td>
         <td style="width: 100px; text-align: left">
         <asp:CheckBox ID="Ckdist" runat="server" Autopostback="true"/>BranchWise</td>
         <td>
         </td>
        </tr>
        <tr>
         <td style="width: 122px; text-align: left; height: 29px;">
             <asp:Label ID="Labpost" runat="server" Text="Select Post"></asp:Label></td>
                    <td style="width: 100px; text-align: left; height: 29px;">
                    <asp:DropDownList ID="DDLpost" Autopostback="true" runat="server" Width="208px">
                    </asp:DropDownList></td>
                      <td style="width: 200px; text-align: left; height: 29px;">
                          <asp:Label ID="Label1" runat="server" Text="Select Branch"></asp:Label></td>
                  
        <td style="width: 200px; text-align: left; height: 29px;">
                    <asp:DropDownList ID="DDLbranch"  Autopostback="true"  runat="server" Width="208px">
                    </asp:DropDownList></td>  
            
                 
                    
            </tr>
          
            <tr>
             <td style="width: 122px; text-align: left">
                    <strong>
                    Select Leave Type:</strong></td>
               
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="Cmb_Leave" runat="server" Width="144px">
                        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Casual</asp:ListItem>
                        <asp:ListItem Value="2">Sick</asp:ListItem>
                        <asp:ListItem Value="3">Earned</asp:ListItem>
                        <asp:ListItem Value="4">L.O.P</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 153px; text-align: left">
                    </td>
                <td style="width: 100px; text-align: left">
                    </td>
            </tr>
            <tr>
            
                <td style="width: 122px; text-align: left">
                    <strong>
                    From Date :</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_From" onkeyup="date('Txt_From')" runat="server" Width="127px"></asp:TextBox></td>
                <td style="width: 153px; text-align: left">
                    <strong>
                    To Date :</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_to" onkeyup="date('Txt_to')" runat="server" Width="139px"></asp:TextBox></td>
            </tr>
        </table>
        <div style="text-align: center">
            <table border="1" style="margin:0px auto;" >
                <tr>
                    <td style="width: 61px; text-align: right; height: 7px;">
                        <center><input id="Cmd_Exit" type="button" value="EXIT" style="width: 100px" onclick="return Cmd_Exit_onclick()" /></center></td>
                    <td style="width: 105px; text-align: left; height: 7px;">
                        <center><asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="100px" /></center></td>
                         <td style="width: 105px; text-align: left; height: 7px;">
                          <center><asp:Button ID="Btedit" runat="server" Text="CLEAR" Width="100px" /></center></td>
                </tr>
            </table>
           <%-- <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_Employee">
            </cc1:ListSearchExtender>--%>
        </div>
        <cc1:CalendarExtender ID="CalendarExt_From" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_From">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExt_To" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_to">
    </cc1:CalendarExtender>
    </div>
    
    <br />
    <br />
</asp:Content>

