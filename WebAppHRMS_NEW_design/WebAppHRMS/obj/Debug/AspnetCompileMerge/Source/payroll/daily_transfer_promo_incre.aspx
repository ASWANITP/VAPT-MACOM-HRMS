<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="daily_transfer_promo_incre.aspx.vb" Inherits="WebAppHRMS.report_daily_transfer_promo_incre_561a18014069" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <div style="text-align: center">
        <table border="1" style="width: 612px; height: 124px">
            <tr>
                <td colspan="4" style="height: 29px; background-color: #ffffcc">
                    <strong><span style="font-size: 14pt; color: #330066;">DAILY-TRANSFER-PROMOTION_INCREMENT</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 29px; background-color: transparent">
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_fdt"></cc1:calendarextender>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_tdt"></cc1:calendarextender>
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <strong>CATEGORY</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_cat" runat="server" Width="242px">
                        <asp:ListItem Value="1">TRANSFER</asp:ListItem>
                        <asp:ListItem Value="2">PROMOTION</asp:ListItem>
                        <asp:ListItem Value="3">INCERMENT</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 118px">
                    <strong><span style="color: #ff3300">
                    FROM DATE</span></strong></td>
                <td style="width: 89px; text-align: left;">
                    <asp:TextBox ID="txt_fdt" runat="server"></asp:TextBox></td>
                <td style="width: 78px">
                    <strong><span style="color: #ff3300">
                    TO DATE</span></strong></td>
                <td style="width: 102px; text-align: left;">
                    <asp:TextBox ID="txt_tdt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="105px" Font-Bold="True" /></td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="97px" Font-Bold="True" /></td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

