<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="edli_main.aspx.vb" Inherits="WebAppHRMS.EDLI_edli_main_056275936263" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <br />

    <br />
    <div style="text-align: center">
        <table border="1" style="width: 367px; height: 151px">
            <tr>
                <td colspan="2" style="height: 40px">
                    <strong><span style="color: #ff0099; text-decoration: underline">EDLI &nbsp; REPORTS</span></strong></td>
            </tr>
            <tr>
                <td style="width: 87px; text-align: right">
                    Firm :&nbsp;
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:RadioButtonList ID="rdb_firm" runat="server" Width="158px">
                        <asp:ListItem Selected="True" Value="1">Magfil</asp:ListItem>
                        <asp:ListItem Value="2">maben &amp; Magro</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 87px; height: 6px; text-align: right">
                    Report :&nbsp;
                </td>
                <td style="width: 100px; height: 6px; text-align: left">
                    <asp:RadioButtonList ID="rdb_rpt" runat="server" Width="217px">
                        <asp:ListItem Selected="True" Value="3">Existing Employees</asp:ListItem>
                        <asp:ListItem Value="1">Newly Joined</asp:ListItem>
                        <asp:ListItem Value="2">Resigned</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 87px; text-align: right; height: 6px;">
                    &nbsp;<input id="Button1" style="width: 68px" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
                <td style="width: 100px; height: 6px; text-align: left;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="85px" /></td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>

