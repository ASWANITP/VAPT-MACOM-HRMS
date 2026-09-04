<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="tour_branchwise_rptselect.aspx.vb" Inherits="WebAppHRMS.Tour_Report_Brwise_tour_branchwise_rptselect_afb5dbc09809" title="Employee Tour Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath ="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=sal.split('Txt');

function Button1_onclick() 
{
 window.open('../home.aspx','_self');
}
function checkdate(a)
{
 alert('Please Use Calendar !!');
 document.getElementById(cont[0]+a).value="";
 document.getElementById(cont[0]+a).focus();
 return false;
}
function check_branch_onclick() 
{
 if(document.getElementById(cont[0]+"check_branch").checked==true)
 {
  document.getElementById(cont[0]+"Cmb_Branch").disabled=true;
 }
 if(document.getElementById(cont[0]+"check_branch").checked==false)
 {
  document.getElementById(cont[0]+"Cmb_Branch").disabled=false;
 }
}
function cliclick()
{
 if(document.getElementById(cont[0]+"Txt_FromDate").value=="")
 {
  alert('Please Enter Date From Using Calendar and CONFIRM!!');
  document.getElementById(cont[0]+"Txt_FromDate").focus();
  return false;
 }
 if(document.getElementById(cont[0]+"Txt_ToDate").value=="")
 {
  alert('Please Enter Date To Using Calendar and CONFIRM!!');
  document.getElementById(cont[0]+"Txt_ToDate").focus();
  return false;
 }
}
function init()
{
 if(document.getElementById(cont[0]+"check_branch").checked==true)
 {
  document.getElementById(cont[0]+"Cmb_Branch").disabled=true;
 }
 if(document.getElementById(cont[0]+"check_branch").checked==false)
 {
  document.getElementById(cont[0]+"Cmb_Branch").disabled=false;
 }
}
window.onload=init;

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <div style="text-align: center">
            <table border="1" style="width: 310px">
                <tr>
                    <td style="width: 100px; text-align: left">
                        <table border="0" style="width: 389px">
                            <tr>
                                <td style="width: 597px; height: 21px; text-align: left">
                                    &nbsp;<strong>Select Branch&nbsp; :</strong></td>
                                <td colspan="2" style="height: 21px; text-align: left">
                    <asp:DropDownList ID="Cmb_Branch" runat="server" Width="262px">
                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 597px; height: 21px; text-align: left">
                                </td>
                                <td style="height: 21px; text-align: left">
                                    <input id="check_branch" type="Checkbox" onclick="return check_branch_onclick()" runat="server" /></td>
                                <td style="width: 100px; height: 21px; text-align: left">
                                    <asp:Label ID="Label1" runat="server" Text="Select All Branches" Width="236px" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 597px; height: 21px; text-align: left">
                                    &nbsp;<strong>From Date &nbsp; &nbsp; &nbsp; :</strong></td>
                                <td colspan="2" style="height: 21px; text-align: left">
                    <asp:TextBox ID="Txt_FromDate" onkeyup="return checkdate('Txt_FromDate')" runat="server" Width="153px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 597px; height: 21px; text-align: left">
                                    &nbsp;<strong>To Date &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;:</strong></td>
                                <td colspan="2" style="height: 21px; text-align: left">
                    <asp:TextBox ID="Txt_ToDate" onkeyup="return checkdate('Txt_ToDate')" runat="server" Width="153px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 597px; height: 21px; text-align: left">
                                </td>
                                <td colspan="2" style="height: 21px; text-align: left">
                        <table style="width: 142px">
                            <tr>
                                <td style="width: 76px">
                                    <input id="Button1" type="button" value="EXIT" style="width: 74px" onclick="return Button1_onclick()" /></td>
                                <td style="width: 99px">
                                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="76px" /></td>
                            </tr>
                        </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
            TargetControlID="Txt_FromDate">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
            TargetControlID="Txt_ToDate">
        </cc1:CalendarExtender>
        <br />
        <div style="text-align: center">
            &nbsp;</div>
    </div>
</asp:Content>

