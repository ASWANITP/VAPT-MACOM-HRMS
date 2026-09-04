<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pf_report.aspx.vb" Inherits="WebAppHRMS.PF_REPORT_pf_report_3682a8bf1124" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <br />
    <div style="text-align: center">
        <table border="1" style="width: 413px; height: 204px">
            <tr>
                <td colspan="2" style="height: 35px; text-align: center">
                    <strong><span style="color: #cc0099; text-decoration: underline">PF MONTHLY REPORTS</span></strong></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right">Firm :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:RadioButtonList ID="rdb_firm" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">Magfil</asp:ListItem>
                        <asp:ListItem Value="2">Maben</asp:ListItem>
                        <asp:ListItem Value="24">Majewel</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 141px; height: 10px; text-align: right">Report :</td>
                <td style="width: 100px; height: 10px; text-align: left">
                    <asp:RadioButtonList ID="rdb_rpt" runat="server" Width="214px">
                        <asp:ListItem Selected="True" Value="3">PF Statement</asp:ListItem>
                        <asp:ListItem Value="1">Form 5</asp:ListItem>
                        <asp:ListItem Value="2">Form 10</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right">Payment
                    &nbsp;Month&nbsp; :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_pay_month" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MMM/yyyy" TargetControlID="txt_pay_month"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right;">
                    <input id="cmd_exit" style="width: 78px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
            <tr>
                <td style="width: 141px"></td>
                <td style="width: 100px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

