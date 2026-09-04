<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_Ao_report.aspx.vb" Inherits="WebAppHRMS.Tour_Ao_report_f615ae3d2844" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Cmd_Exit_onclick() {
window.open('../home.aspx','_self');

}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong><span style="font-size: 14pt">TOUR&nbsp; DETAILS<asp:ScriptManager id="ScriptManager1"
                        runat="server"></asp:ScriptManager>
                        <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_tdt"></cc1:calendarextender>
                        <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:calendarextender>
                    </span></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    FROM DATE</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_fdt" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    TO DATE</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_tdt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" Width="123px" /></td>
                                <td style="width: 100px">
                                    <input id="Cmd_Exit" style="width: 129px" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
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

