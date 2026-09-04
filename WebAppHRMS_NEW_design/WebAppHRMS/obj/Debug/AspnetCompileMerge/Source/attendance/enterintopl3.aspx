<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="enterintopl3.aspx.vb" Inherits="WebAppHRMS.enterinpl3_enterintopl3_529b7de75290" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
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
                    <asp:UpdatePanel id="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <contenttemplate>
<TABLE style="WIDTH: 684px; HEIGHT: 70px" border=1><TBODY><TR><TD style="WIDTH: 177px; HEIGHT: 32px; TEXT-ALIGN: right" colSpan=2><STRONG>ENTER DATE</STRONG></TD><TD style="WIDTH: 549px; HEIGHT: 32px; TEXT-ALIGN: left" colSpan=2><asp:TextBox id="Txt_fdate" runat="server" OnTextChanged="Txt_fdate_TextChanged" __designer:wfdid="w15" AutoPostBack="True"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 15px; TEXT-ALIGN: right" colSpan=4><TABLE style="WIDTH: 678px; BACKGROUND-COLOR: #ffffcc"><TBODY><TR><TD style="WIDTH: 166px; TEXT-ALIGN: left"><SPAN style="COLOR: #0000ff">PL3 PENDING</SPAN> <asp:CheckBox id="chk_pl3" runat="server" __designer:wfdid="w4" AutoPostBack="True" OnCheckedChanged="chk_pl3_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 109px; TEXT-ALIGN: left"><SPAN style="COLOR: #0000ff">MORNING</SPAN>&nbsp;&nbsp;<asp:CheckBox id="chk_mor" runat="server" __designer:wfdid="w5" AutoPostBack="True" OnCheckedChanged="chk_mor_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><SPAN style="COLOR: #0000ff">EVENING</SPAN>&nbsp;<asp:CheckBox id="chk_eve" runat="server" __designer:wfdid="w6" AutoPostBack="True" OnCheckedChanged="chk_eve_CheckedChanged"></asp:CheckBox></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 177px; HEIGHT: 15px; TEXT-ALIGN: right" colSpan=2><STRONG><SPAN style="COLOR: #cc0033">SELECT EMPLOYEE&nbsp;</SPAN></STRONG></TD><TD style="WIDTH: 549px; HEIGHT: 15px; TEXT-ALIGN: left" colSpan=2><asp:DropDownList id="cmb_employ" runat="server" Width="304px" __designer:wfdid="w16" AutoPostBack="True">
                    </asp:DropDownList></TD></TR></TBODY></TABLE><cc1:calendarextender id="CalendarExtender1" runat="server" __designer:wfdid="w17" format="dd/MMM/yyyy" targetcontrolid="Txt_fdate"></cc1:calendarextender> <TABLE style="WIDTH: 684px; HEIGHT: 151px" border=1 __designer:dtid="562949953421314"><TBODY><TR><TD colSpan=4 __designer:dtid="562949953421326"><STRONG __designer:dtid="562949953421327"><SPAN style="FONT-SIZE: 14pt; COLOR: #993300" __designer:dtid="562949953421328">UPDATION</SPAN></STRONG></TD></TR><TR><TD style="WIDTH: 112px" __designer:dtid="562949953421330"><STRONG __designer:dtid="562949953421331">BRANCH</STRONG></TD><TD style="WIDTH: 110px; TEXT-ALIGN: left" __designer:dtid="562949953421332"><asp:TextBox id="Txt_branch" runat="server" Width="177px" __designer:dtid="562949953421333" __designer:wfdid="w18" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px" __designer:dtid="562949953421334"><STRONG __designer:dtid="562949953421335">LEAVE TYPE</STRONG></TD><TD style="WIDTH: 110px; TEXT-ALIGN: left" __designer:dtid="562949953421336"><asp:DropDownList id="cmb_levtype" runat="server" Width="202px" __designer:dtid="562949953421337" __designer:wfdid="w19" AutoPostBack="True"><asp:ListItem Value="1">INFORMED</asp:ListItem>
<asp:ListItem Value="0">NOT INFORMED</asp:ListItem>
<asp:ListItem Value="2">APPROVED</asp:ListItem>
<asp:ListItem Value="3">SHIFT</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 112px" __designer:dtid="562949953421339"><STRONG __designer:dtid="562949953421340">LEAVE DATE</STRONG></TD><TD style="WIDTH: 110px; TEXT-ALIGN: left" __designer:dtid="562949953421341"><asp:TextBox id="Txt_date" runat="server" Width="175px" __designer:dtid="562949953421342" __designer:wfdid="w20" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px" __designer:dtid="562949953421343"><STRONG __designer:dtid="562949953421344">REASON</STRONG></TD><TD style="WIDTH: 110px" __designer:dtid="562949953421345"><asp:TextBox id="Txt_reas" runat="server" Width="193px" __designer:dtid="562949953421346" __designer:wfdid="w21" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="Txt_fdate" EventName="TextChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="cmb_employ" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="width: 129px; height: 34px;">
                </td>
                <td style="width: 110px; height: 34px;">
                </td>
                <td style="width: 100px; height: 34px;">
                </td>
                <td style="width: 127px; height: 34px;">
                </td>
            </tr>
            <tr>
                <td style="width: 129px">
                </td>
                <td style="width: 110px; text-align: center">
                    <asp:Button ID="cmd_confirm" runat="server" BackColor="#FFC0C0" Font-Bold="True"
                        Text="CONFIRM" Width="115px" /></td>
                <td style="width: 100px; text-align: center">
                    <asp:Button ID="cmd_exit" runat="server" BackColor="#FFC0C0" Font-Bold="True" Text="EXIT"
                        Width="113px" /></td>
                <td style="width: 127px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

