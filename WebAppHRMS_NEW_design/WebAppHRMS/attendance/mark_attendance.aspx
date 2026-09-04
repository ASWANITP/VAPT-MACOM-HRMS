<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="mark_attendance.aspx.vb" Inherits="WebAppHRMS.attendance_mark_attendance_f50b06c31519" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 60%" border="1">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hdn_time" runat="server" __designer:wfdid="w21"></asp:HiddenField>
                                &nbsp;<asp:Label ID="lbl_message" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 50%" align="left">Employee Code</td>
                            <td style="width: 50%" align="left">
                                <asp:TextBox ID="txt_employee_code" runat="server" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 50%" align="left">Password</td>
                            <td style="width: 50%" align="left">&nbsp;
                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 50%; height: 28px" align="left">Employee Name</td>
                            <td style="width: 50%; height: 28px" align="left">
                                <asp:TextBox ID="txt_employee_name" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 50%" align="left">Shift</td>
                            <td style="width: 50%" align="left">
                                <asp:TextBox ID="txt_shift" runat="server"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="cmd_save" runat="server" Text="Save" Width="114px" />&nbsp;
    </div>
</asp:Content>

