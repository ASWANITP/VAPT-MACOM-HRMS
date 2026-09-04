<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Comp_confirmation.aspx.vb" Inherits="WebAppHRMS.LEAVE_DETAILS_Comp_confirmation_e1f782796584" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;
            <br />
            <table style="width: 875px; position: static; height: 206px" border="1">
                <tbody>
                    <tr>
                        <td style="text-align: center" colspan="4">
                            <asp:Label ID="Label4" runat="server" Text="COMPENSATION CONFIRMATION" ForeColor="DarkBlue" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="4">
                            <asp:Label Style="position: static" ID="Label5" runat="server" Width="600px" Height="22px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 20px; text-align: left">
                            <asp:Label ID="Label2" runat="server" Text="Select" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="height: 20px; text-align: left" colspan="3">
                            <asp:DropDownList Style="position: static" ID="cmb_ecode" runat="server" Width="685px" Font-Bold="False" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">
                            <asp:Label ID="Label3" runat="server" Width="105px" Text="Employee Name" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_name" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; text-align: left">
                            <asp:Label ID="Label7" runat="server" Width="62px" Text="Off Date" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_offdate" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">
                            <asp:Label ID="Label1" runat="server" Width="72px" Text="Leave Date" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_leavdate" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; text-align: left">
                            <asp:Label ID="Label6" runat="server" Text="Designation" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_designation" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">
                            <asp:Label ID="Label8" runat="server" Width="114px" Text="Recommended By" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_recomended" runat="server" Width="227px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:Label ID="Label9" runat="server" Width="121px" Text="Sanctioned Person" ForeColor="DarkBlue"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox Style="position: static" ID="txt_rec" runat="server" Width="229px" BackColor="OldLace" ReadOnly="True" __designer:wfdid="w1"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 28px; text-align: center" colspan="2">
                            <asp:Button Style="position: static" ID="cmd_reject" runat="server" Width="105px" Text="Reject" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w8"></asp:Button></td>
                        <td style="width: 100px; height: 28px">
                            <asp:Button Style="position: static" ID="cmd_confirm" runat="server" Width="117px" Text="Confirm" ForeColor="DarkBlue" Font-Bold="True"></asp:Button></td>
                        <td style="width: 100px; height: 28px; text-align: center">
                            <asp:Button Style="position: static" ID="Button1" OnClick="Button1_Click" runat="server" Width="101px" Text="Exit" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w4"></asp:Button></td>
                    </tr>
                </tbody>
            </table>
            <asp:DropDownList Style="position: static" ID="cmb_san_person" runat="server" Width="232px" Visible="False"></asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

