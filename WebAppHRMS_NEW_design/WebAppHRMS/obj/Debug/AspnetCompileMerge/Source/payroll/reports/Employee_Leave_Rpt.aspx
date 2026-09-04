<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Employee_Leave_Rpt.aspx.vb" Inherits="WebAppHRMS.STORES_Outward_Mail_Rpt_4b1ab1d41791" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript">


function cmd_exit_onclick() {
window.open('../../home.aspx','_self');
}
var cont_name=header.split('txt'); 
function Datecheck_from()
{  
   
      alert('Please Select the Date By using Calendar..!!!');
      document.getElementById(cont_name[0]+"txt_frdt").value="";
      document.getElementById(cont_name[0]+"txt_frdt").focus();
      return true;
 
}

function Datecheck_to()
{     
      alert('Please Select the Date By using Calendar..!!!');
      document.getElementById(cont_name[0]+"txt_todt").value="";
      document.getElementById(cont_name[0]+"txt_todt").focus();
      return true;
 
}


</script>

<div style="text-align: center">
<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />

        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>EMPLOYEE LEAVE REPORT</strong></td>
            </tr>
            <tr>
                <td colspan="2">                       
                Department Name</td>            
                <td colspan="2" style="width: 100px">
                    <asp:DropDownList ID="Cmb_Dept" runat="server" Width="260px">
                    </asp:DropDownList>
                </td>
            </tr>
           
            <tr>
                <td style="width: 100px">
                    From Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_frdt" runat="server" onpaste="return false" onkeyup="Datecheck_from()" ></asp:TextBox>
                 </td>
                <td style="width: 100px">
                    To Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_todt" runat="server" onpaste="return false" onkeyup="Datecheck_to()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                     <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_frdt"></cc1:calendarextender>
                    &nbsp;
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                     <cc1:calendarextender id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_todt"></cc1:calendarextender>
                </td>
 
                </tr>

            <tr>
                <td style="height: 28px; text-align: right;" colspan="2">
                     <asp:Button ID="cmd_rpt" runat="server" Text="REPORT"  /></td>
                <td style="height: 28px; text-align: left;" colspan="2">
                     <input id="cmd_exit" style="width: 67px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>

        </table>
</div>

</asp:Content>

