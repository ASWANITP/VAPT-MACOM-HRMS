<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="approve_resign.aspx.vb" Inherits="WebAppHRMS.new_approve_resign_3ee36c041115" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../home.aspx','_self');
}
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
// ]]>
</script>

    <div style="text-align: center">
        `<table border="1">
            <tr>
                <td colspan="4">
                    <strong>APPROVE RESIGNATION<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager></strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE border=1><TBODY><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Select&nbsp;Employee</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="cmb_emp" runat="server" Width="582px" AutoPostBack="True">
                    </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 32px; TEXT-ALIGN: left" colSpan=4><TABLE border=0><TBODY><TR><TD style="HEIGHT: 23px; TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Code :</STRONG> <asp:Label id="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy" __designer:wfdid="w1"></asp:Label></TD><TD style="WIDTH: 392px; HEIGHT: 23px; TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Name :</STRONG>&nbsp; <asp:Label id="lbl_name" runat="server" Width="274px" Text="No Employee" ForeColor="Navy" __designer:wfdid="w2"></asp:Label></TD></TR></TBODY></TABLE>&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Resigning&nbsp;Date</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rsdt" runat="server" __designer:wfdid="w3" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Reason&nbsp;for&nbsp;Resigning</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rea" runat="server" Width="571px" ForeColor="MediumBlue" Height="58px" ReadOnly="True" MaxLength="150" TextMode="singleLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 2773px; HEIGHT: 23px; TEXT-ALIGN: left"><STRONG>Select&nbsp;Relieving&nbsp;Date</STRONG></TD><TD style="HEIGHT: 23px; TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rdt" onkeypress="return van()" runat="server" AutoPostBack="True" __designer:wfdid="w4"></asp:TextBox> <asp:Label id="lbl1" runat="server" Width="580px" __designer:wfdid="w1"></asp:Label></TD></TR></TBODY></TABLE><cc1:calendarextender id="CalendarExtender1" runat="server" __designer:dtid="844424930131976" __designer:wfdid="w8" Format="dd/MMM/yyyy" TargetControlID="Txt_rdt"></cc1:calendarextender>&nbsp;&nbsp;&nbsp; 
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px"><table border="0">
                    <tr>
                <td style="width: 160px">
                    &nbsp;&nbsp;
                    <input id="cmd_att" runat="server" type="button" value="View Attachment" /></td>
                <td style="width: 79px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 122px; text-align: center;">
                    <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                <td style="width: 128px">
                    &nbsp;
                    </td>
                    </tr>
                </table>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

