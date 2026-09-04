<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_datewise_frm.aspx.vb" Inherits="WebAppHRMS.PROMOTION_promotion_datewise_frm_bf06af8c8771" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1" width="750">
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Label ID="lbl_message" runat="server" BackColor="LightCoral" Font-Bold="True"
                        Text="DATEWISE EMPLOYEE PROMOTION LISTING REPORT" Width="544px"></asp:Label><br />
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<DIV style="TEXT-ALIGN: center"><TABLE width=750 border=1><TBODY><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left"><STRONG>FROM DATE</STRONG></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_fromdate"></cc1:CalendarExtender> <asp:TextBox id="txt_fromdate" runat="server" Width="207px"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><STRONG>TO DATE</STRONG></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_todate"></cc1:CalendarExtender> <asp:TextBox id="txt_todate" runat="server" Width="209px"></asp:TextBox></TD></TR></TBODY></TABLE></DIV>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 28px">
                </td>
                <td style="width: 100px; height: 28px; text-align: center;">
                    <asp:Button ID="cmd_GENERATE" runat="server" Text="GENERATE" Width="119px" /></td>
                <td style="width: 100px; height: 28px; text-align: center;">
                    <asp:Button ID="cmd_Exit" runat="server" Text="EXIT" Width="123px" /></td>
                <td style="width: 100px; height: 28px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

