<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pl3_submit.aspx.vb" Inherits="WebAppHRMS.payroll_pl3_submit_464bf23d1190" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function TABLE1_onclick() {

        }

        // ]]>
    </script>

    &nbsp;<table align="center" style="width: 826px; height: 270px;" border="1" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 116px"></td>
            <td style="text-align: center;" colspan="2">
                <strong><span style="color: #000066">DAILY STAFF POSITION</span></strong></td>
            <td style="width: 176px"></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 78px;"></td>
            <td colspan="2" style="text-align: center; height: 78px;">&nbsp;<asp:Panel ID="pnl_ho" runat="server" Height="50px" Visible="False" Width="150px">
                <asp:RadioButtonList ID="rd_ho" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    Width="315px">
                    <asp:ListItem Value="0">Ho</asp:ListItem>
                    <asp:ListItem Value="1">Branch</asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
            </td>
            <td style="width: 176px; height: 78px;"></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 57px;"></td>
            <td colspan="2" style="text-align: center; height: 57px;">
                <asp:Panel ID="pnl_br" runat="server" Height="50px" Visible="False" Width="125px">
                    <table border="1" style="width: 317px">
                        <tr>
                            <td style="width: 100px; height: 24px; text-align: left">Branch Name</td>
                            <td style="width: 100px; height: 24px">
                                <asp:DropDownList ID="cmb_branch" runat="server" AutoPostBack="True" Width="200px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 176px; height: 57px;"></td>
        </tr>
        <tr>
            <td style="width: 116px; height: 17px">Employee Name</td>
            <td style="width: 106px; height: 17px">
                <asp:DropDownList ID="cmb_employ" runat="server" Height="35px" Width="251px">
                </asp:DropDownList></td>
            <td style="width: 114px; height: 17px">Leave Particulars</td>
            <td style="width: 176px; height: 17px">
                <asp:DropDownList ID="cmb_particulars" runat="server" Height="35px" Width="213px">
                    <asp:ListItem Value="1">INFORMED</asp:ListItem>
                    <asp:ListItem Value="0">NOT INFORMED</asp:ListItem>
                    <asp:ListItem Value="2">APPROVED</asp:ListItem>
                    <asp:ListItem Value="3">SHIFT</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 17px">Reason</td>
            <td colspan="2" style="height: 17px">
                <asp:TextBox ID="txt_reason" runat="server" Width="431px" MaxLength="60"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 17px; text-align: center">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" Width="79px" /></td>
            <td colspan="2" style="height: 17px; text-align: center">
                <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="79px" /></td>
        </tr>
    </table>
</asp:Content>

