<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="earlypunching.aspx.vb" Inherits="WebAppHRMS.punching_earlypunching_00846e464627" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 950px"></td>
        </tr>
        <tr>
            <td align="center" style="height: 475px; width: 950px;">
                <div style="text-align: center">

                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="width: 521px; height: 429px" border="1">
                                <tbody>
                                    <tr>
                                        <td style="height: 18px; text-align: center" colspan="2">
                                            <asp:Label ID="lbl_message" runat="server" Width="385px" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr style="font-weight: bold; font-size: 10pt; color: #000000; font-family: Baskerville Old Face">
                                        <td style="height: 42px; text-align: center" colspan="2"><span style="color: #000000; font-family: Times New Roman">EARLY &nbsp;GOING APPLICATION</span></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Times New Roman">
                                        <td style="width: 178px; height: 3px; text-align: left">&nbsp;ENTER EMP_CODE</td>
                                        <td style="width: 92px; height: 3px; text-align: left">
                                            <asp:TextBox ID="txt_emp_code" runat="server" BackColor="AntiqueWhite" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="width: 178px; height: 3px; text-align: left"><span style="font-size: 10pt">&nbsp;<span>EMP NAME</span></span></td>
                                        <td style="width: 92px; height: 3px; text-align: left">
                                            <asp:TextBox ID="txt_name" runat="server" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="width: 178px; height: 1px; text-align: left"><span style="font-size: 10pt">&nbsp;SHIFT &nbsp;TIME &nbsp;&nbsp;</span></td>
                                        <td style="width: 92px; height: 1px; text-align: left"><strong><span style="font-size: 14pt; color: #7a96df">
                                            <asp:TextBox ID="txt_shift_time" runat="server" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></span></strong></td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td style="width: 178px; height: 1px; text-align: left"><span style="font-size: 10pt">&nbsp;LEAVE DATE</span></td>
                                        <td style="width: 92px; height: 1px; text-align: left">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="txt_leave_date" runat="server" ValidationGroup="as"></asp:TextBox></td>
                                                        <td style="width: 100px">
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ToolTip="Please enter date in correct format(dd/Mmm/yyyy)" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$" ControlToValidate="txt_leave_date" ErrorMessage="(dd/Mmm/yyyy)" __designer:wfdid="w4" SetFocusOnError="True"></asp:RegularExpressionValidator></td>
                                                        <td style="width: 100px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="74px" ControlToValidate="txt_leave_date" ErrorMessage="Enter Date" __designer:wfdid="w3"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td style="width: 178px; height: 1px; text-align: left"><span style="font-size: 10pt">&nbsp;REASON&nbsp; </span></td>
                                        <td style="width: 92px; height: 1px; text-align: left">
                                            <asp:TextBox ID="txt_reason" runat="server" Width="257px" Height="39px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="font-family: Times New Roman">
                                        <td style="width: 178px; text-align: left"><span style="font-size: 10pt">&nbsp;APPLICATION SUBMITTED</span></td>
                                        <td style="width: 92px">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="55px" RepeatDirection="Horizontal">
                                                <asp:ListItem>YES</asp:ListItem>
                                                <asp:ListItem Selected="True">NO</asp:ListItem>
                                            </asp:RadioButtonList>&nbsp;
                                            <asp:HiddenField ID="hdn" runat="server" __designer:dtid="1125899906842634" __designer:wfdid="w1"></asp:HiddenField>
                                            <asp:HiddenField ID="hdn1" runat="server" __designer:dtid="1125899906842635" __designer:wfdid="w2"></asp:HiddenField>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" __designer:wfdid="w4" Format="dd/MMM/yyyy" TargetControlID="txt_leave_date"></cc1:CalendarExtender>
                                            <br />
                                            &nbsp;
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" __designer:wfdid="w1" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;&nbsp; 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    &nbsp;&nbsp;<br />
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 950px">&nbsp;<asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" Width="97px" />
                <asp:Button ID="cmd_exit" runat="server" OnClick="cmd_exit_Click" Text="EXIT" Width="91px" /></td>
        </tr>
    </table>

</asp:Content>

