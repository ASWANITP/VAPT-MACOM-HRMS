<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Maternity_Leave_Form.aspx.vb" Inherits="WebAppHRMS.Maternity_Leave_Report_Maternity_Leave_Form_75798ab17342" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
            <tr>
                <td style="width: 100px; height: 26px;">From Date</td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td style="width: 100px; height: 26px;">To Date</td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="TextBox1"></cc1:CalendarExtender>
                </td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="TextBox2"></cc1:CalendarExtender>
                </td>
            </tr>
        </table>
    </div>
    <center>
        <asp:Button ID="Button1" runat="server" Text="View Report" Width="241px" />
    </center>
</asp:Content>

