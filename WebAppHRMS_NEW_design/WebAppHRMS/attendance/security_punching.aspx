<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="security_punching.aspx.vb" Inherits="WebAppHRMS.attendance_security_punching_da7ab6442965" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('../Home.aspx','_self');
}

// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <table border="1" width="80%">
            <tr>
                <td align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="text-align: center">
                                <table width="80%" border="1">
                                    <tbody>
                                        <tr>
                                            <td style="text-align: center" colspan="2"><strong><span style="color: #990000">Attendance Marking&nbsp;&nbsp;&nbsp; </span></strong></td>
                                        </tr>
                                        <tr>
                                            <td align="left">Employee Code</td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_empcode" runat="server" Width="137px" MaxLength="5"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left">PassWord</td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_password" runat="server" OnTextChanged="txt_password_TextChanged" AutoPostBack="True" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left">Employee Name</td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_empname" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left">&nbsp;Shift</td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_shift" runat="server" Width="217px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left">Gun Status</td>
                                            <td align="left">&nbsp;<asp:RadioButton ID="chk_gun" runat="server" Width="193px" AutoPostBack="True" OnCheckedChanged="chk_gun_CheckedChanged"></asp:RadioButton></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_message" runat="server" Width="226px" ForeColor="#FF0000" Font-Bold="True" __designer:wfdid="w1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="cmd_ok" runat="server" Text="Confirm" />
                    <input id="Button1" style="width: 66px" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

