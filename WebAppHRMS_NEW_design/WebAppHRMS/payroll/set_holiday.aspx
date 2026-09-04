<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="set_holiday.aspx.vb" Inherits="WebAppHRMS.PF_set_holiday_983b32f82317" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">


        function cmd_ext_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="height: 36px">
                    <strong><span style="color: #cc3300; font-family: Courier New">ASSIGN BRANCH HOLIDAY</span></strong></td>
            </tr>
            <tr>
                <td style="width: 155px; height: 23px">
                    <span style="font-family: Courier New">Select Branch</span></td>
                <td colspan="3" style="height: 23px">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="268px" Font-Names="Courier New">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 155px">
                    <span style="font-family: Courier New">Select Holiday</span></td>
                <td colspan="3">
                    <asp:DropDownList ID="cmb_hol" runat="server" Width="268px" DataTextFormatString="AAA" Font-Bold="False" Font-Names="Courier New">
                        <asp:ListItem Value="1">Sunday</asp:ListItem>
                        <asp:ListItem Value="2">Monday</asp:ListItem>
                        <asp:ListItem Value="3">Tuesday</asp:ListItem>
                        <asp:ListItem Value="4">Wednesday</asp:ListItem>
                        <asp:ListItem Value="5">Thursday</asp:ListItem>
                        <asp:ListItem Value="6">Friday</asp:ListItem>
                        <asp:ListItem Value="7">Saturday</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px; text-align: center">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="93px" /><input id="cmd_ext"
                        style="width: 73px" type="button" value="EXIT" onclick="return cmd_ext_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

