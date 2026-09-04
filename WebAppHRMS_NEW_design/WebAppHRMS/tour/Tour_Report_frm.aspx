<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_Report_frm.aspx.vb" Inherits="WebAppHRMS.TOUR_Tour_Report_frm_b35e37a39468" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <div style="text-align: center">
        <table border="0">
            <tr>
                <td style="width: 100px">
                    <table border="1" width="600">
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <strong style="background-color: #ff9966">TOUR STATUS REPORT</strong></td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="4">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        &nbsp;
                        <table border="1" width="600">
                            <tr>
                                <td style="width: 100px; height: 23px; text-align: left">
                                    <strong>FROM&nbsp;DATE</strong></td>
                                <td style="width: 100px; height: 23px">
                                    <asp:TextBox ID="Txt_fromdate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Txt_fromdate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                </td>
                                <td style="width: 100px; height: 23px; text-align: left">
                                    <strong>TO&nbsp;DATE</strong></td>
                                <td style="width: 100px; height: 23px">
                                    <asp:TextBox ID="Txt_todate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Txt_todate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px"></td>
                            <td style="width: 100px; text-align: center;">
                                <asp:Button ID="Cmd_generate" runat="server" Text="GENERATE" Width="122px" /></td>
                            <td style="width: 100px">
                                <asp:Button ID="cmd_Exit" runat="server" Text="EXIT" Width="133px" /></td>
                            <td style="width: 100px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <br />
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<br />
    &nbsp;<br />
</asp:Content>

