<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="lopperasonalac.aspx.vb" Inherits="WebAppHRMS.lop_to_personal_account_report_lopperasonalac_b449ae3b3189" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath ="~/edp.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <table border="1" style="height: 83px">
            <tr>
                <td style="width: 100px; text-align: right">
                    Select Month
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_month" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; text-align: left">
                    &nbsp;<input id="cmd_exit" style="width: 82px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MMM/yyyy" TargetControlID="txt_month">
                    </cc1:CalendarExtender>
    <br />
</asp:Content>

