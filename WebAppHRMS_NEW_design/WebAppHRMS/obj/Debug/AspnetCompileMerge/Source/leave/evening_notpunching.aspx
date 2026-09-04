<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="evening_notpunching.aspx.vb" Inherits="WebAppHRMS.evening_notpunching_373f330f3842" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" BorderColor="Olive" BorderStyle="Solid" BorderWidth="2px"
            Height="44px" Width="11px">
            <div style="text-align: center">
                <table border="0" style="width: 274px; height: 163px; text-align: left">
                    <tr>
                        <td colspan="2" style="border-bottom: olive thin solid; text-align: center;">
                            <span style="color: #990000"><span style="background-color: #ffe0c9"><span style="text-decoration: underline">
                                EVENING NOT
                        PUNCHING REPORT</span><br />
                            </span>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </span></td>
                    </tr>
                    <tr>
                        <td style="width: 400px; text-align: right; height: 6px;">
                            &nbsp; &nbsp;&nbsp; Select Date :
                        </td>
                        <td style="width: 97px; text-align: left; height: 6px;">
                            <asp:TextBox ID="txt_dt" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 21px; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; text-align: center;" colspan="2">
                            &nbsp;
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                                TargetControlID="txt_dt">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 23px; text-align: right">
                            &nbsp; &nbsp;<asp:Button ID="cmd_report" runat="server" Height="24px" Text="REPORT"
                                Width="71px" BackColor="Transparent" />
                            <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="71px" BackColor="Transparent" />&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <br />
        <br />
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;</div>
</asp:Content>

