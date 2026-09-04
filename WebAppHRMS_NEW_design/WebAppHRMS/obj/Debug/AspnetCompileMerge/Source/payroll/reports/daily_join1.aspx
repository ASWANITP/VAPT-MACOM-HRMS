<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="daily_join1.aspx.vb" Inherits="WebAppHRMS.daily_joinning_report_daily_join1_fe4f0c143439" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
window.open("../../home.aspx","_self");
}
</script>
    <div style="text-align: center">
        <table border="1">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_fromdate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_todate">
                </cc1:CalendarExtender>
            </caption>
            <tr>
                <td style="width: 100px">
                </td>
                <td colspan="3">
                    <strong><span style="color: #ff0000">SELECT DATE</span></strong></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    From Date</td>
                <td style="width: 100px">
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_fromdate" runat="server" Width="209px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    To Date</td>
                <td style="width: 100px">
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_todate" runat="server" Width="209px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" Width="117px" /></td>
                <td colspan="2">
                </td>
               
                 <td style="width: 100px">
                    <input id="Reset1" style="width: 105px" type="reset" value="EXIT" onclick="return Reset1_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

