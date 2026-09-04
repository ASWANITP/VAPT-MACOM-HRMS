<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Daily_Transfer_Dtl.aspx.vb" Inherits="WebAppHRMS.HRM_Daily_Report_Daily_Transfer_Dtl_fa872b086734" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        function Button2_onclick() {
            window.open("../../home.aspx", "_self");
        }


    </script>

    <div style="text-align: center">
        <table border="1" style="width: 60%; position: relative">
            <caption>
                <strong>DAILY TRANSFER REPORT</strong></caption>
            <tr>
                <td style="width: 15%; height: 25px;">
                    <strong>From Date</strong></td>
                <td style="width: 15%; text-align: left; height: 25px;">
                    <asp:TextBox ID="txt_frm" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                <td style="width: 15%; height: 25px;">
                    <strong>To Date</strong></td>
                <td style="width: 15%; height: 25px;">
                    <asp:TextBox ID="txt_to" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; height: 23px;"></td>
                <td style="width: 15%; height: 23px;"></td>
                <td style="width: 15%; height: 23px;"></td>
                <td style="width: 15%; height: 23px;"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Style="position: relative" Text="CONFIRM" /></td>
                <td colspan="2">
                    <input id="Button2" style="width: 96px; position: relative" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="txt_frm"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="txt_to"></cc1:CalendarExtender>
</asp:Content>

