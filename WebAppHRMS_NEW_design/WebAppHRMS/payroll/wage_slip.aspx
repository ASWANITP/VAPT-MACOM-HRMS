<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="wage_slip.aspx.vb" Inherits="WebAppHRMS.salaryreport_wage_slip_5584e1976448" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong><span style="font-size: 16pt; color: #cc0033">WAGE SLIP<asp:ScriptManager
                        ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    </span></strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>SELECT PROCESS DATE</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_date" runat="server" Width="198px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row3" runat="server">
                <td colspan="2">
                    <asp:CheckBox ID="chk_branch" runat="server" Font-Bold="True" Text="ALL BRANCH" AutoPostBack="True" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:CheckBox ID="chk_allfirm" runat="server" Font-Bold="True" Text="ALL FIRM" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_bran"></cc1:ListSearchExtender>
                    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_firm"></cc1:ListSearchExtender>
                    <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_emp"></cc1:ListSearchExtender>
                </td>
            </tr>
            <tr id="row1" runat="server">
                <td style="width: 85px">
                    <asp:CheckBox ID="chk_bran" runat="server" AutoPostBack="True" Width="103px" /></td>
                <td style="width: 168px">BRANCH WISE</td>
                <td colspan="2">
                    <asp:DropDownList ID="cmb_bran" runat="server" Width="230px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row2" runat="server">
                <td style="width: 85px; height: 26px">
                    <asp:CheckBox ID="chk_firm" runat="server" AutoPostBack="True" Width="105px" /></td>
                <td style="width: 168px; height: 26px">FIRM WISE</td>
                <td colspan="2" style="height: 26px">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="226px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 85px">
                    <asp:CheckBox ID="chk_emp" runat="server" AutoPostBack="True" Width="104px" /></td>
                <td style="width: 168px">PARTICULAR</td>
                <td colspan="2">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="226px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 85px">
                    <asp:LinkButton ID="LinkButton1" PostBackUrl="wage_slip_old.aspx" runat="server">Previous Month</asp:LinkButton></td>

                <td style="width: 168px">
                    <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="111px" /></td>
                <td colspan="2">
                    <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="113px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

