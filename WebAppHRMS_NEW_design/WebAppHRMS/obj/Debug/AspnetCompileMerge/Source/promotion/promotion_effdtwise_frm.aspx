<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_effdtwise_frm.aspx.vb" Inherits="WebAppHRMS.PROMOTION_promotion_effdtwise_frm_99efcef77644" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1" width="750">
            <tr>
                <td colspan="4" style="text-align: center; width: 756px;">
                    <strong style="background-color: #ff6666">PROMOTION&nbsp; OR&nbsp; REVERTING IN EFFECTIVE
                        DATEWISE&nbsp; MODEL<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 756px; text-align: center">
                        <asp:UpdatePanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
<DIV style="TEXT-ALIGN: center"><TABLE width=750 border=1 __designer:dtid="562949953421330"><TBODY><TR __designer:dtid="562949953421331"><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="562949953421332"><STRONG>FROM&nbsp;DATE</STRONG></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="562949953421333"><cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:dtid="562949953421334" __designer:wfdid="w36" TargetControlID="txt_fromdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender> <asp:TextBox id="txt_fromdt" runat="server" Width="205px" __designer:dtid="562949953421335" __designer:wfdid="w37"></asp:TextBox>&nbsp; </TD><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="562949953421336"><STRONG>TO&nbsp;DATE</STRONG></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="562949953421337"><cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:dtid="562949953421338" __designer:wfdid="w38" TargetControlID="txt_todate" Format="dd/MMM/yyyy"></cc1:CalendarExtender> <asp:TextBox id="txt_todate" runat="server" Width="207px" __designer:dtid="562949953421339" __designer:wfdid="w39"></asp:TextBox></TD></TR></TBODY></TABLE></DIV>
</contenttemplate>
                        </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 756px; height: 23px; text-align: center">
                    <div style="text-align: center">
                        <table border="1" width="750">
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="Btn_Generate" runat="server" OnClick="Btn_Generate_Click" Text="GENERATE"
                                        Width="207px" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Btn_Exit" runat="server" OnClick="Btn_Exit_Click" Text="EXIT" Width="195px" /></td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    &nbsp;<br />
    <br />
    <br />
</asp:Content>

