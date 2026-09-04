<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="early_sanction.aspx.vb" Inherits="WebAppHRMS.punching_early_sanction_832dd8e59886" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <table style="width: 855px; height: 220px; left: 58px; position: relative; top: 0px;" border="1">
        <tr>
            <td colspan="4" style="height: 22px; text-align: center">
                <asp:Label ID="Lbl_msg" runat="server" Width="167px" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 22px; text-align: center">
                <strong>EARLY GOING &nbsp;SANCTION</strong></td>
        </tr>
        <tr>
            <td style="width: 149px; height: 26px">
                &nbsp;Select</td>
            <td colspan="3" style="height: 26px">
                <asp:DropDownList ID="cmb_ecode" runat="server" Width="308px" AutoPostBack="True" Height="2px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 149px; height: 26px;">
                &nbsp;Employ Name</td>
            <td style="width: 25px; height: 26px;">
                <asp:TextBox ID="txt_name" runat="server" Width="192px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 70px; height: 26px;">
                &nbsp;Apply&nbsp;Date &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txt_applay_date" runat="server" Width="192px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 149px; height: 26px">
                &nbsp;Early Going Date</td>
            <td style="width: 25px; height: 26px">
                <asp:TextBox ID="txt_leave_date" runat="server" Width="192px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 70px; height: 26px">
                &nbsp;Reason &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txt_reason" runat="server" Width="363px" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 149px; height: 26px">
                &nbsp;Recommended Person</td>
            <td style="height: 26px" colspan="3">
                <asp:TextBox ID="Txt_reco_pers" runat="server" Width="291px" BackColor="AntiqueWhite" Height="16px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 149px; height: 21px">
                &nbsp;Sanctioned Person</td>
            <td colspan="3" style="height: 21px">
                <asp:TextBox ID="cmb_sanc" runat="server" ReadOnly="True" Width="292px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 24px; text-align: center;" colspan="4">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <br />
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="cmd_reject" runat="server" Font-Bold="True" Text="REJECT" Width="98px" /></td>
                        <td style="width: 100px">
                            <asp:Button ID="cmd_accept" runat="server" Font-Bold="True" Text="ACCEPT" Width="98px" /></td>
                        <td style="width: 100px">
                <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="98px" /></td>
                    </tr>
                </table>
                &nbsp;&nbsp;<br />
                </td>
        </tr>
    </table>
</asp:Content>

