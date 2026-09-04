<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="special_all_consolidated.aspx.vb" Inherits="WebAppHRMS.special_allowance_special_all_consolidated_880ed2b57596" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script>

        function cmd_exit_onclick() {
            window.open("../home.aspx", "_Self");
        }
    </script>
    <br />
    <div style="text-align:center">
    <table border="1" style="width: 502px">
        <tr>
            <td colspan="2" style="height: 44px">
                <strong><span style="color: #cc0099; text-decoration: underline">SPECIAL ALLOWANCE&nbsp;
                    (CONSOLIDATED) REPORT</span></strong></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:RadioButton ID="rdb_am" runat="server" Checked="True" GroupName="g" Text="AM Allowance" />&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:RadioButton ID="rdb_bh" runat="server" GroupName="g" Text="BH Allowance" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:RadioButton ID="rdb_abh" runat="server" GroupName="g" Text="ABH Allowance" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:RadioButton ID="rdb_special" runat="server" GroupName="g" Text="Special Allowance In A.O" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <div style="text-align: center">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                <asp:Button ID="cmd_confirm" runat="server" Height="26px" Text="CONFIRM" Width="75px" /></td>
                            <td style="width: 100px">
                                <input id="cmd_exit" onclick="return cmd_exit_onclick()" style="width: 69px; height: 26px"
                                    type="button" value="EXIT" /></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <br />
</asp:Content>

