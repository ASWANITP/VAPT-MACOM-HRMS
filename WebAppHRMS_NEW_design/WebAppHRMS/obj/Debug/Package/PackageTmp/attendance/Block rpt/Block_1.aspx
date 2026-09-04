<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Block_1.aspx.vb" Inherits="WebAppHRMS.HRM_Block_Report_Block_1_1a89d91e4982" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script>
        function cmdExit_onclick() {
            window.open('../../home.aspx', '_self');
        }
    </script>
        <table border="1" style="width: 60%; position: relative; top: 0px">
        
        <caption style="margin-bottom:10px;margin-top:10px;">
            <strong>PUNCH BLOCK REPORT</strong></caption>
        <tr>
            <td style="width: 15%">
                <strong>From Date</strong></td>
            <td style="width: 15%; text-align: left">
                <asp:TextBox ID="txtfdt" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            <td style="width: 15%">
                <strong>To Date</strong></td>
            <td style="width: 15%; text-align: left">
                <asp:TextBox ID="txttdt" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
        </tr>
        <%--<tr>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
        </tr>--%>
        <tr>

            <td colspan="4" style="text-align:center;padding:5px;">
                <asp:Button ID="Button1" runat="server" Height="24px" Style="position: relative;  top: 0px;"
                    Text="CONFIRM" Width="80px" />

                <input id="cmdExit" style=" width: 80px;Height:24px;" type="button"
                    value="EXIT" onclick="return cmdExit_onclick()" /></td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
</asp:Content>

