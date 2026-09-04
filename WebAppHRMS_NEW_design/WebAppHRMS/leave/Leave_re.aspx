<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_re.aspx.vb" Inherits="WebAppHRMS.Deepak_Leave_re_c0cfaa653048" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:UpdatePanel
        ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;<table style="width: 901px; position: static; height: 249px" border="1">
                <tbody>
                    <tr>
                        <td style="height: 23px; text-align: center" colspan="4">
                            <asp:Label Style="position: static" ID="Label1" runat="server" Width="344px" Text="LEAVE RECOMMENDATION" ForeColor="DarkBlue" Font-Bold="True" Font-Underline="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 23px; text-align: center" colspan="4">
                            <asp:Label Style="position: static" ID="Lbl_msg" runat="server" Width="744px" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 324px; height: 26px; text-align: left"><span style="color: darkblue">Select</span></td>
                        <td style="height: 26px; text-align: left" colspan="3">
                            <asp:DropDownList Style="position: static" ID="cmb_ecode" runat="server" Width="500px" BackColor="OldLace" ForeColor="DarkBlue" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 324px; text-align: left"><span style="color: darkblue">Employee Name</span></td>
                        <td style="width: 100px; text-align: left">
                            <asp:TextBox Style="position: static" ID="Txt_name" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; text-align: left"><span style="color: darkblue">Duration</span></td>
                        <td style="width: 88px; text-align: left">
                            <asp:TextBox Style="position: static" ID="Txt_dura" runat="server" Width="181px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 324px; height: 5px; text-align: left"><span style="color: darkblue">Apply Date</span></td>
                        <td style="width: 100px; height: 5px; text-align: left">
                            <asp:TextBox Style="position: static" ID="Txt_ap_dt" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; height: 5px; text-align: left"><span style="color: darkblue">Leave Type</span></td>
                        <td style="width: 88px; height: 5px; text-align: left">
                            <asp:TextBox Style="position: static" ID="Txt_lv_typ" runat="server" Width="180px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 324px; text-align: left"><span style="color: darkblue">Leave Reason</span></td>
                        <td style="text-align: left" colspan="3">
                            <asp:TextBox Style="position: static" ID="Txt_reson" runat="server" Width="350px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 324px; height: 27px; text-align: left"><span style="color: darkblue">Recommending Person</span></td>
                        <td style="height: 27px; text-align: left" colspan="3">
                            <asp:TextBox Style="position: static" ID="txt_rec" runat="server" Width="231px" BackColor="OldLace" ReadOnly="True" __designer:wfdid="w2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 2px; text-align: center" colspan="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button Style="position: static" ID="Button1" OnClick="Button1_Click" runat="server" Width="93px" Text="Exit" ForeColor="DarkBlue" Font-Bold="True" Height="26px" __designer:wfdid="w8"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="height: 2px; text-align: center" colspan="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Style="position: static" ID="cmd_reject" OnClick="cmd_reject_Click" runat="server" Width="93px" Text="REJECT" ForeColor="DarkBlue" Font-Bold="True" Height="26px" __designer:wfdid="w11"></asp:Button></td>
                        <td style="height: 2px; text-align: center" colspan="2">&nbsp;<asp:Button Style="position: static" ID="Button2" runat="server" Width="93px" Text="CONFIRM" ForeColor="DarkBlue" Font-Bold="True" Height="26px"></asp:Button></td>
                    </tr>
                </tbody>
            </table>
            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_ecode"></cc1:ListSearchExtender>
            <asp:HiddenField ID="HiddenField2" runat="server"></asp:HiddenField>
            <asp:DropDownList Style="position: static" ID="cmb_sanc" runat="server" Width="280px" Visible="False"></asp:DropDownList>&nbsp;
            <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

