<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="enterintopl3.aspx.vb" Inherits="WebAppHRMS.enterinpl3_enterintopl3_529b7de75290" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <table border="1" style="width: 684px; height: 151px">
            <tr>
                <td colspan="4" style="height: 29px; background-color: lightcyan;">
                    <strong><span style="font-size: 16pt; color: #660000">PL3 PENDING</span></strong><asp:ScriptManager
                        ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 29px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="width: 684px; height: 70px" border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 177px; height: 32px; text-align: right" colspan="2"><strong>ENTER DATE</strong></td>
                                        <td style="width: 549px; height: 32px; text-align: left" colspan="2">
                                            <asp:TextBox ID="Txt_fdate" runat="server" OnTextChanged="Txt_fdate_TextChanged" __designer:wfdid="w15" AutoPostBack="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 15px; text-align: right" colspan="4">
                                            <table style="width: 678px; background-color: #ffffcc">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 166px; text-align: left"><span style="color: #0000ff">PL3 PENDING</span>
                                                            <asp:CheckBox ID="chk_pl3" runat="server" __designer:wfdid="w4" AutoPostBack="True" OnCheckedChanged="chk_pl3_CheckedChanged"></asp:CheckBox></td>
                                                        <td style="width: 109px; text-align: left"><span style="color: #0000ff">MORNING</span>&nbsp;&nbsp;<asp:CheckBox ID="chk_mor" runat="server" __designer:wfdid="w5" AutoPostBack="True" OnCheckedChanged="chk_mor_CheckedChanged"></asp:CheckBox></td>
                                                        <td style="width: 100px; text-align: left"><span style="color: #0000ff">EVENING</span>&nbsp;<asp:CheckBox ID="chk_eve" runat="server" __designer:wfdid="w6" AutoPostBack="True" OnCheckedChanged="chk_eve_CheckedChanged"></asp:CheckBox></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 177px; height: 15px; text-align: right" colspan="2"><strong><span style="color: #cc0033">SELECT EMPLOYEE&nbsp;</span></strong></td>
                                        <td style="width: 549px; height: 15px; text-align: left" colspan="2">
                                            <asp:DropDownList ID="cmb_employ" runat="server" Width="304px" __designer:wfdid="w16" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" __designer:wfdid="w17" Format="dd/MMM/yyyy" TargetControlID="Txt_fdate"></cc1:CalendarExtender>
                            <table style="width: 684px; height: 151px" border="1" __designer:dtid="562949953421314">
                                <tbody>
                                    <tr>
                                        <td colspan="4" __designer:dtid="562949953421326"><strong __designer:dtid="562949953421327"><span style="font-size: 14pt; color: #993300" __designer:dtid="562949953421328">UPDATION</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px" __designer:dtid="562949953421330"><strong __designer:dtid="562949953421331">BRANCH</strong></td>
                                        <td style="width: 110px; text-align: left" __designer:dtid="562949953421332">
                                            <asp:TextBox ID="Txt_branch" runat="server" Width="177px" __designer:dtid="562949953421333" __designer:wfdid="w18" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100px" __designer:dtid="562949953421334"><strong __designer:dtid="562949953421335">LEAVE TYPE</strong></td>
                                        <td style="width: 110px; text-align: left" __designer:dtid="562949953421336">
                                            <asp:DropDownList ID="cmb_levtype" runat="server" Width="202px" __designer:dtid="562949953421337" __designer:wfdid="w19" AutoPostBack="True">
                                                <asp:ListItem Value="1">INFORMED</asp:ListItem>
                                                <asp:ListItem Value="0">NOT INFORMED</asp:ListItem>
                                                <asp:ListItem Value="2">APPROVED</asp:ListItem>
                                                <asp:ListItem Value="3">SHIFT</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px" __designer:dtid="562949953421339"><strong __designer:dtid="562949953421340">LEAVE DATE</strong></td>
                                        <td style="width: 110px; text-align: left" __designer:dtid="562949953421341">
                                            <asp:TextBox ID="Txt_date" runat="server" Width="175px" __designer:dtid="562949953421342" __designer:wfdid="w20" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100px" __designer:dtid="562949953421343"><strong __designer:dtid="562949953421344">REASON</strong></td>
                                        <td style="width: 110px" __designer:dtid="562949953421345">
                                            <asp:TextBox ID="Txt_reas" runat="server" Width="193px" __designer:dtid="562949953421346" __designer:wfdid="w21" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Txt_fdate" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="cmb_employ" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 129px; height: 34px;"></td>
                <td style="width: 110px; height: 34px;"></td>
                <td style="width: 100px; height: 34px;"></td>
                <td style="width: 127px; height: 34px;"></td>
            </tr>
            <tr>
                <td style="width: 129px"></td>
                <td style="width: 110px; text-align: center">
                    <asp:Button ID="cmd_confirm" runat="server" BackColor="#FFC0C0" Font-Bold="True"
                        Text="CONFIRM" Width="115px" /></td>
                <td style="width: 100px; text-align: center">
                    <asp:Button ID="cmd_exit" runat="server" BackColor="#FFC0C0" Font-Bold="True" Text="EXIT"
                        Width="113px" /></td>
                <td style="width: 127px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

