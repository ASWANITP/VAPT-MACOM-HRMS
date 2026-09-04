<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="early_recomentation.aspx.vb" Inherits="WebAppHRMS.punching_early_recomentation_f01ebbd37283" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <table style="width: 934px; height: 78px" border="2">
        <tr>
            <td colspan="5" style="text-align: center">
                &nbsp;<asp:Label ID="Lbl_msg" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                <strong>EARLY GOING RECOMMENDATION</strong></td>
        </tr>
        <tr>
            <td style="width: 148px; height: 24px">
                &nbsp;Select</td>
            <td colspan="3" style="height: 24px">
                <asp:DropDownList ID="cmb_ecode" runat="server" Width="725px" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 148px; height: 24px">
                &nbsp;Employee Name</td>
            <td style="width: 22px; height: 24px">
                <asp:TextBox ID="txt_name" runat="server" Width="304px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 110px; height: 24px">
                &nbsp;Apply Date</td>
            <td style="width: 100px; height: 24px">
                <asp:TextBox ID="txt_applay_date" runat="server" BackColor="AntiqueWhite" Width="228px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px; height: 24px">
                &nbsp;Reason</td>
            <td style="width: 22px; height: 24px">
                <asp:TextBox ID="txt_reason" runat="server" Width="306px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 110px; height: 24px">
                &nbsp;Early Going Date</td>
            <td style="width: 100px; height: 24px">
                <asp:TextBox ID="txt_leave_date" runat="server" BackColor="AntiqueWhite" Width="228px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px; height: 23px;">
                &nbsp;Recommending Person</td>
            <td colspan="2" style="height: 23px">
                <asp:TextBox ID="cmb_sanc" runat="server" ReadOnly="True" Width="305px"></asp:TextBox></td>
            <td colspan="1" style="height: 23px">
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 45px; text-align: center">
                &nbsp;
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="cmd_reject" runat="server" Text="REJECT" Font-Bold="True" Width="95px" Height="24px" /></td>
                        <td style="width: 100px">
                <asp:Button ID="cmd_confirm" runat="server" Text="ACCEPT" Font-Bold="True" Width="95px" /></td>
                        <td style="width: 100px">
                <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Font-Bold="True" Width="95px" /></td>
                    </tr>
                </table>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

