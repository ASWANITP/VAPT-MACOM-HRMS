<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="resign_report.aspx.vb" Inherits="WebAppHRMS.new_resign_report_ce2dc8ce8153" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>RESIGN STATUS REPORT
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">From Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_fdt" runat="server"></asp:TextBox></td>
                <td style="width: 100px">To Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_tdt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_fdt"></cc1:CalendarExtender>
                </td>
                <td colspan="2">
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_tdt"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td colspan="2">
                    <input id="Button1" style="width: 112px" type="button" value="EXIT" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

