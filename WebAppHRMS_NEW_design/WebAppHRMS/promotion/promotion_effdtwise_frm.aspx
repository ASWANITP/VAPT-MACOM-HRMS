<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_effdtwise_frm.aspx.vb" Inherits="WebAppHRMS.PROMOTION_promotion_effdtwise_frm_99efcef77644" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1" width="750">
            <tr>
                <td colspan="4" style="text-align: center; width: 756px;">
                    <strong style="background-color: #ff6666">PROMOTION&nbsp; OR&nbsp; REVERTING IN EFFECTIVE
                        DATEWISE&nbsp; MODEL<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 756px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="text-align: center">
                                <table width="750" border="1" __designer:dtid="562949953421330">
                                    <tbody>
                                        <tr __designer:dtid="562949953421331">
                                            <td style="width: 100px; text-align: left" __designer:dtid="562949953421332"><strong>FROM&nbsp;DATE</strong></td>
                                            <td style="width: 100px; text-align: left" __designer:dtid="562949953421333">
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" __designer:dtid="562949953421334" __designer:wfdid="w36" TargetControlID="txt_fromdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                <asp:TextBox ID="txt_fromdt" runat="server" Width="205px" __designer:dtid="562949953421335" __designer:wfdid="w37"></asp:TextBox>&nbsp; </td>
                                            <td style="width: 100px; text-align: left" __designer:dtid="562949953421336"><strong>TO&nbsp;DATE</strong></td>
                                            <td style="width: 100px; text-align: left" __designer:dtid="562949953421337">
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" __designer:dtid="562949953421338" __designer:wfdid="w38" TargetControlID="txt_todate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                <asp:TextBox ID="txt_todate" runat="server" Width="207px" __designer:dtid="562949953421339" __designer:wfdid="w39"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 756px; height: 23px; text-align: center">
                    <div style="text-align: center">
                        <table border="1" width="750">
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Btn_Generate" runat="server" OnClick="Btn_Generate_Click" Text="GENERATE"
                                        Width="207px" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Btn_Exit" runat="server" OnClick="Btn_Exit_Click" Text="EXIT" Width="195px" /></td>
                                <td style="width: 100px"></td>
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

