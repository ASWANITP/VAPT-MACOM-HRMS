<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="gratuity_main.aspx.vb" Inherits="WebAppHRMS.grtuity_gratuity_main_2a148bdc5282" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2" style="height: 37px; text-align: center">
                    <span style="color: #ff0099; text-decoration: underline"><strong>GRATUITY REPORTS</strong></span></td>
            </tr>
            <tr>
                <td style="width: 148px; text-align: right;">Select Firm :
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="144px">
                        <asp:ListItem Value="5">MAGRO</asp:ListItem>
                        <asp:ListItem Value="2">MABEN</asp:ListItem>
                        <asp:ListItem Value="1">MAGFIL</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 148px; text-align: right;">Select Reprort :
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:RadioButtonList ID="rdb_report" runat="server" Width="175px">
                        <asp:ListItem Selected="True" Value="3">Existing Employees</asp:ListItem>
                        <asp:ListItem Value="1">Newly Joined</asp:ListItem>
                        <asp:ListItem Value="2">Resigned</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 148px; text-align: right;">
                    <input id="cmd_exit" style="width: 77px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; text-align: left;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="93px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

