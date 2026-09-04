<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_sanctionRpt.aspx.vb" Inherits="WebAppHRMS.leave_Leave_sanctionRpt_4dc274f75500" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2">LEAVE AUTHORITY DETAILS</td>
            </tr>
            <tr>
                <td style="width: 271px">
                    <asp:RadioButton ID="rdbAuth" runat="server" Checked="True" GroupName="rdbleave"
                        Text="Sanction Authority Details" /></td>
                <td style="width: 299px">
                    <asp:RadioButton ID="rdbExc" runat="server" GroupName="rdbleave" Text="Leave Exception Details" /></td>
            </tr>
            <tr>
                <td style="width: 271px">Leave Type</td>
                <td style="width: 299px">
                    <asp:DropDownList ID="ddrlv" runat="server" Width="256px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 271px">
                    <asp:Button ID="cmdRpt" runat="server" OnClick="cmdRpt_Click" Text="REPORT" /></td>
                <td style="width: 299px">
                    <asp:Button ID="cmdExit" runat="server" Text="EXIT" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

