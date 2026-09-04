<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="BAMovementReport.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_BAMovementReport_1a34b2427851" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function correct(a, e) {

            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()

        }

        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 726px; height: 217px">
            <tr>
                <td colspan="4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <strong style="color: Maroon"><span style="font-size: 14pt; text-decoration: underline;">BA Movement Report</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 11px"></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 42px">
                    <strong>&nbsp;SELECT EMPLOYEE </strong></td>
                <td colspan="2" style="height: 44px; text-align: left">&nbsp; &nbsp;
                    <asp:DropDownList ID="dropemp" runat="server" Width="280px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 120px; height: 39px">FROM DATE</td>
                <td style="width: 120px; height: 39px">
                    <asp:TextBox ID="TextBox2" runat="server" onkeyup="return correct('TextBox2',event)"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
                <td style="width: 126px; height: 39px">TO DATE</td>
                <td style="width: 123px; height: 39px">
                    <asp:TextBox ID="TextBox3" runat="server" onkeyup="return correct('TextBox3',event)"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox3" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 44px">
                    <asp:Button ID="btncnfrm" runat="server" Text="CONFIRM" Width="121px" /></td>
                <td colspan="2" style="height: 44px">&nbsp;<asp:Button ID="btnext" runat="server" Text="EXIT" Width="133px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

