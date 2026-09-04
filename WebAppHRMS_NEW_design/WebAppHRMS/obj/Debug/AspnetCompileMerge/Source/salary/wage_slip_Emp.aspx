<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="wage_slip_Emp.aspx.vb" Inherits="WebAppHRMS.salaryreport_wage_slip_Emp_4965e3be9029" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<%--<script type="text/javascript" oninit="wload()">
function wload()
{
debugger;
document.getElementById("TxtEmployeeCode").value=document.getElementById("hidemp").value;
}
</script>--%>
    <div style="text-align: center">
        <table border="1" style="width :100%;">
            <tr>
                <td colspan="8">
                    <strong><span style="font-size: 16pt; color: #cc0033">WAGE SLIP<asp:ScriptManager
                        id="ScriptManager1" runat="server"></asp:ScriptManager></span></strong></td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtEmployeeCode"
                        ErrorMessage="*" ValidationGroup="grp1"></asp:RequiredFieldValidator>EMPLOYEE
                    CODE:</td>
                <td colspan="1" style="text-align: left">
                    <asp:TextBox ID="TxtEmployeeCode" runat="server"></asp:TextBox></td>
                <td colspan="1" style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="TxtFromdt"
                        ErrorMessage="*" ValidationGroup="grp1" Width="8px"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtFromdt" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$"></asp:RegularExpressionValidator>
                    FROM DATE:</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="TxtFromdt" runat="server"></asp:TextBox>
                    
                    <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TxtTodate"
                        ControlToValidate="TxtFromdt" ErrorMessage="FromDate should be less than ToDate"
                      ValidationGroup="grp1" Type ="Date" CultureInvariantValues="true"   Operator="LessThan" Display="Dynamic"></asp:CompareValidator>--%>
                    
                    <cc1:CalendarExtender ID="CalendarExtender1"  Format="dd-MMM-yyyy" TargetControlID ="TxtFromdt" runat="server">
                    </cc1:CalendarExtender>
                    </td>
                <td colspan="1" style="text-align: left" align="right">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTodate"
                        ErrorMessage="*" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtTodate" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$"></asp:RegularExpressionValidator>
                        TO DATE:</td>
                <td colspan="1" style="text-align: left">
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" TargetControlID ="TxtTodate" runat="server">
                    </cc1:CalendarExtender>
                    <asp:TextBox ID="TxtTodate" runat="server"></asp:TextBox>
                   <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtFromdt"
                        ControlToValidate="TxtTodate" ErrorMessage="ToDate should be greater than FromDate"
                      ValidationGroup="grp1" Type ="Date" CultureInvariantValues="true"   Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
                    --%>  </td>
            </tr>
          <%--  <tr id="trinvalid" visible ="false" runat ="server" >
                <td>
                </td>
                <td>
                </td>
                <td colspan="1">
                </td>
                <td colspan="4">
                    <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                        ForeColor="Red" Text=""></asp:Label></td>
                <td colspan="1">
                </td>
            </tr>--%>
            <tr>
                <td >
                </td>
                <td >
                    </td>
                <td colspan="1">
                </td>
                <td colspan="1">
                </td>
                <td colspan="2" align="left">
                    <asp:Button ID="cmd_confirm" ValidationGroup="grp1" runat="server" Font-Bold="True" Text="CONFIRM" Width="111px" /></td>
                <td colspan="1">
                </td>
                <td colspan="1" align="left">
                    <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="113px" PostBackUrl="~/home.aspx" /></td>
            </tr>
        </table>
    </div>
    <input id="hidemp" style="width: 16px" type="hidden" runat="server" />
</asp:Content>

