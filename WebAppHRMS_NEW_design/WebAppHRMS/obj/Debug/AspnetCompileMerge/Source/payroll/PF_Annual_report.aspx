<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PF_Annual_report.aspx.vb" Inherits="WebAppHRMS.PF_REPORT_PF_Annual_report_64f89fd46138" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <br />
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2" style="height: 38px; text-align: center">
                    <span style="color: #cc0099; text-decoration: underline"><strong>PF ANNUAL REPORTS</strong></span></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right">
                    Select Firm</td>
                <td style="width: 100px; text-align: left">
                    <asp:RadioButtonList ID="rdb_firm" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Magfil</asp:ListItem>
                        <asp:ListItem Value="2">Maben</asp:ListItem>
                        <asp:ListItem Value="24">Majewel</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right">
                    Report :
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:RadioButtonList ID="rdb_rpt" runat="server" Width="214px">
                        <asp:ListItem Selected="True" Value="1">Form 3a</asp:ListItem>
                        <asp:ListItem Value="2">Form 6a</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right;">
                    <input id="cmd_exit" style="width: 78px" type="button"
                        value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; text-align: left;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

