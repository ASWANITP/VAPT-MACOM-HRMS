<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="special_main_report.aspx.vb" Inherits="WebAppHRMS.special_allowance_special_main_report_1e1122af6436" title="Untitled Page" %>
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
        <table border="1" style="width: 378px">
            <tr>
                <td colspan="2" style="height: 44px">
                    <strong><span style="color: #cc0099; text-decoration: underline">SPECIAL ALLOWANCE&nbsp;
                        REPORT</span></strong></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:RadioButton ID="rdb_am" runat="server" Text="Area Managers (AM)" Checked="True" GroupName="g" />&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:RadioButton ID="rdb_bh" runat="server" Text="Branch Head (BH)" GroupName="g" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:RadioButton ID="rdb_abh" runat="server" Text="Asst.Branch Head (ABH)" GroupName="g" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:RadioButton ID="rdb_special" runat="server" Text="Special Allowance in A.O" GroupName="g" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server" Height="26px" Text="CONFIRM" Width="75px" /></td>
                                <td style="width: 100px">
                    <input id="cmd_exit" style="width: 69px; height: 26px;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

