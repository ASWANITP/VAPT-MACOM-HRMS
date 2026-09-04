<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_morethan_2_d.aspx.vb" Inherits="WebAppHRMS.feb2009_llll_leave_morethan_2_d_3ceae7504571" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        var cs = cont_name.split("Txt");
        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
        }
        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong><span style="color: #cc0000">Leave Days More Than 2 Days per month</span></strong></td>
            </tr>
            <tr>
                <td style="width: 100px">Select Month</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="Cmb_month" runat="server" Width="120px">
                        <asp:ListItem Value="Jan">January</asp:ListItem>
                        <asp:ListItem Value="Feb">February</asp:ListItem>
                        <asp:ListItem>March</asp:ListItem>
                        <asp:ListItem>April</asp:ListItem>
                        <asp:ListItem>May</asp:ListItem>
                        <asp:ListItem>June</asp:ListItem>
                        <asp:ListItem>July</asp:ListItem>
                        <asp:ListItem Value="Aug">August</asp:ListItem>
                        <asp:ListItem Value="Sep">September</asp:ListItem>
                        <asp:ListItem Value="Oct">October</asp:ListItem>
                        <asp:ListItem Value="Nov">November</asp:ListItem>
                        <asp:ListItem Value="Dec">December</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px">Enter Year</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_yr" onkeyup="return change('Txt_yr')" runat="server" Width="109px" MaxLength="4"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 28px"></td>
                <td style="width: 100px; height: 28px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; height: 28px">
                    <input id="cmd_exit" style="width: 68px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; height: 28px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

