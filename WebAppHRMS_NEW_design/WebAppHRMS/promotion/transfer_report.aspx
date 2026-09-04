<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="transfer_report.aspx.vb" Inherits="WebAppHRMS.transferreport_transfer_report_2dded1574234" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 518px; background-color: transparent">
            <tr>
                <td colspan="2" style="height: 23px; background-color: #ffffcc">
                    <strong><span style="font-size: 14pt; color: #660000">EMPLOYEE TRANSFER DETAILS</span></strong></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">&nbsp;<cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_select"></cc1:ListSearchExtender>
                    <table border="1" style="width: 518px">
                        <tr>
                            <td style="width: 206px">SELECT EMPLOYEE :</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="cmb_select" runat="server" AutoPostBack="True" Width="310px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <div style="text-align: center">
                        <table style="width: 518px">
                            <tr>
                                <td style="width: 100px; height: 21px">FROM DATE</td>
                                <td style="width: 100px; height: 21px">
                                    <asp:TextBox ID="Txt_fdt" runat="server"></asp:TextBox></td>
                                <td style="width: 100px; height: 21px">TO DATE</td>
                                <td style="width: 100px; height: 21px">
                                    <asp:TextBox ID="Txt_tdt" runat="server" CausesValidation="True"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_fdt"></cc1:CalendarExtender>
                    &nbsp;
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_tdt"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <div style="text-align: center">
                        <table style="width: 504px">
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="87px" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="83px" /></td>
                                <td style="width: 100px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
</asp:Content>

