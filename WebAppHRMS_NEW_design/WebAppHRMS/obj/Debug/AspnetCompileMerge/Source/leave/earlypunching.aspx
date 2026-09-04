<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="earlypunching.aspx.vb" Inherits="WebAppHRMS.punching_earlypunching_00846e464627" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 950px">
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 475px; width: 950px;" >
             <div style="text-align: center">
    
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 521px; HEIGHT: 429px" border=1><TBODY><TR><TD style="HEIGHT: 18px; TEXT-ALIGN: center" colSpan=2><asp:Label id="lbl_message" runat="server" Width="385px" ForeColor="Red"></asp:Label></TD></TR><TR style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #000000; FONT-FAMILY: Baskerville Old Face"><TD style="HEIGHT: 42px; TEXT-ALIGN: center" colSpan=2><SPAN style="COLOR: #000000; FONT-FAMILY: Times New Roman">EARLY &nbsp;GOING APPLICATION</SPAN></TD></TR><TR style="FONT-SIZE: 10pt; FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; HEIGHT: 3px; TEXT-ALIGN: left">&nbsp;ENTER EMP_CODE</TD><TD style="WIDTH: 92px; HEIGHT: 3px; TEXT-ALIGN: left"><asp:TextBox id="txt_emp_code" runat="server" BackColor="AntiqueWhite" AutoPostBack="True" ReadOnly="True"></asp:TextBox> </TD></TR><TR style="FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; HEIGHT: 3px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt">&nbsp;<SPAN>EMP NAME</SPAN></SPAN></TD><TD style="WIDTH: 92px; HEIGHT: 3px; TEXT-ALIGN: left"><asp:TextBox id="txt_name" runat="server" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></TD></TR><TR style="FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; HEIGHT: 1px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt">&nbsp;SHIFT &nbsp;TIME &nbsp;&nbsp;</SPAN></TD><TD style="WIDTH: 92px; HEIGHT: 1px; TEXT-ALIGN: left"><STRONG><SPAN style="FONT-SIZE: 14pt; COLOR: #7a96df"><asp:TextBox id="txt_shift_time" runat="server" BackColor="AntiqueWhite" ReadOnly="True"></asp:TextBox></SPAN></STRONG></TD></TR><TR style="FONT-SIZE: 12pt; FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; HEIGHT: 1px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt">&nbsp;LEAVE DATE</SPAN></TD><TD style="WIDTH: 92px; HEIGHT: 1px; TEXT-ALIGN: left"><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:TextBox id="txt_leave_date" runat="server" ValidationGroup="as"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ToolTip="Please enter date in correct format(dd/Mmm/yyyy)" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$" ControlToValidate="txt_leave_date" ErrorMessage="(dd/Mmm/yyyy)" __designer:wfdid="w4" SetFocusOnError="True"></asp:RegularExpressionValidator></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="74px" ControlToValidate="txt_leave_date" ErrorMessage="Enter Date" __designer:wfdid="w3"></asp:RequiredFieldValidator></TD></TR></TBODY></TABLE></TD></TR><TR style="FONT-SIZE: 12pt; FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; HEIGHT: 1px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt">&nbsp;REASON&nbsp; </SPAN></TD><TD style="WIDTH: 92px; HEIGHT: 1px; TEXT-ALIGN: left"><asp:TextBox id="txt_reason" runat="server" Width="257px" Height="39px" TextMode="MultiLine"></asp:TextBox> </TD></TR><TR style="FONT-FAMILY: Times New Roman"><TD style="WIDTH: 178px; TEXT-ALIGN: left"><SPAN style="FONT-SIZE: 10pt">&nbsp;APPLICATION SUBMITTED</SPAN></TD><TD style="WIDTH: 92px"><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="55px" RepeatDirection="Horizontal">
                    <asp:ListItem>YES</asp:ListItem>
                    <asp:ListItem Selected="True">NO</asp:ListItem>
                </asp:RadioButtonList>&nbsp; <asp:HiddenField id="hdn" runat="server" __designer:dtid="1125899906842634" __designer:wfdid="w1"></asp:HiddenField> <asp:HiddenField id="hdn1" runat="server" __designer:dtid="1125899906842635" __designer:wfdid="w2"></asp:HiddenField> <cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w4" Format="dd/MMM/yyyy" TargetControlID="txt_leave_date"></cc1:CalendarExtender><BR />&nbsp; <asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w1" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary></TD></TR></TBODY></TABLE>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
                 &nbsp;&nbsp;<br />
    </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 950px" >
                &nbsp;<asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" Width="97px" />
                <asp:Button ID="cmd_exit" runat="server" OnClick="cmd_exit_Click" Text="EXIT" Width="91px" /></td>
        </tr>
    </table>
 
</asp:Content>

