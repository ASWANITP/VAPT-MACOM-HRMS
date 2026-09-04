<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leaveless10.aspx.vb" Inherits="WebAppHRMS.leave_leavegreater10_59266a909512" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
<!--

    function Button1_onclick() {
        window.open('../Home.aspx', '_self');
    }

    // -->
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 486px">
            <tr>
                <td colspan="2">
                    <strong>LEAVE LESS THAN 10 REPORT</strong></td>
            </tr>
            <tr>
                <td style="width: 170px; height: 23px; text-align: right;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="166px">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">REGULAR</asp:ListItem>
                        <asp:ListItem Value="2">REGULARISED</asp:ListItem>
                        <asp:ListItem Value="3">OUTSOURCE</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="166px">
                        <asp:ListItem Value="0">ALL</asp:ListItem>
                        <asp:ListItem Value="1">LIVE</asp:ListItem>
                        <asp:ListItem Value="2">NOT LIVE</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    <div style="text-align: right">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="btn_sub" runat="server" Text="SUBMIT" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 100px; text-align: left">
                    <div style="text-align: left">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <input id="Button1" style="width: 66px" type="button" value="EXIT" language="javascript" onclick="return Button1_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

