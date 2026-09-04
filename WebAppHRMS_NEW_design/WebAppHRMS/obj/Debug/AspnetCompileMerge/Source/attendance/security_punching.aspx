<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="security_punching.aspx.vb" Inherits="WebAppHRMS.attendance_security_punching_da7ab6442965" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
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
<DIV style="TEXT-ALIGN: center"><TABLE width="80%" border=1><TBODY><TR><TD style="TEXT-ALIGN: center" colSpan=2><STRONG><SPAN style="COLOR: #990000">Attendance Marking&nbsp;&nbsp;&nbsp; </SPAN></STRONG></TD></TR><TR><TD align=left>Employee Code</TD><TD align=left><asp:TextBox id="txt_empcode" runat="server" Width="137px" MaxLength="5"></asp:TextBox></TD></TR><TR><TD align=left>PassWord</TD><TD align=left><asp:TextBox id="txt_password" runat="server" OnTextChanged="txt_password_TextChanged" AutoPostBack="True" TextMode="Password"></asp:TextBox></TD></TR><TR><TD align=left>Employee Name</TD><TD align=left><asp:TextBox id="txt_empname" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left>&nbsp;Shift</TD><TD align=left><asp:TextBox id="txt_shift" runat="server" Width="217px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD align=left>Gun Status</TD><TD align=left>&nbsp;<asp:RadioButton id="chk_gun" runat="server" Width="193px" AutoPostBack="True" OnCheckedChanged="chk_gun_CheckedChanged"></asp:RadioButton></TD></TR><TR><TD align=left colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl_message" runat="server" Width="226px" ForeColor="#FF0000" Font-Bold="True" __designer:wfdid="w1"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR></TBODY></TABLE></DIV>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
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

