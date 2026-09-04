<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Py_Sus_Revo.aspx.vb" Inherits="WebAppHRMS.PayRoll_Py_Sus_Revo_71cebe146396" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript">
function cmd_exit_onclick() {
window.open('../../../home.aspx','_self');
}
function van()
{
alert("please select date from calendar!")
return false;
}
</script>
    <br />
    <div style="text-align: center">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<BR /><STRONG><SPAN style="COLOR: #ff0000"><SPAN style="FONT-SIZE: 14pt"><SPAN style="FONT-SIZE: 16pt">SUSPENTION/REVOCATION<BR /></SPAN><BR /></SPAN></SPAN></STRONG><TABLE style="BORDER-LEFT-COLOR: #ffcccc; BORDER-BOTTOM-COLOR: #ffcccc; WIDTH: 374px; BORDER-TOP-STYLE: solid; BORDER-TOP-COLOR: #ffcccc; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; HEIGHT: 337px; BORDER-RIGHT-COLOR: #ffcccc; BORDER-BOTTOM-STYLE: solid" id="TABLE3"><TBODY><TR><TD style="BACKGROUND-COLOR: #ffcccc; TEXT-ALIGN: right"><STRONG><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000">Option</SPAN></STRONG></TD><TD style="WIDTH: 212px; BACKGROUND-COLOR: #ffcccc"><DIV style="TEXT-ALIGN: center"><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:RadioButton id="rad_susp" runat="server" Text="SUSPEND" Font-Bold="True" Checked="True" AutoPostBack="True" GroupName="john"></asp:RadioButton></TD><TD style="WIDTH: 100px"><asp:RadioButton id="rad_revok" runat="server" Text="REVOKE" Font-Bold="True" AutoPostBack="True" GroupName="john"></asp:RadioButton></TD></TR></TBODY></TABLE></DIV></TD></TR><TR style="FONT-SIZE: 14pt; COLOR: #ff0000"><TD style="WIDTH: 141px; TEXT-ALIGN: right"><STRONG><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000"><asp:Label style="LEFT: -4px; POSITION: relative; TOP: -7px" id="lbl_ecode" runat="server" Text="Employee Code"></asp:Label> <asp:Label style="LEFT: -7px; POSITION: relative; TOP: -1px" id="lbl_emp" runat="server" Width="66px" Text="Employee"></asp:Label></SPAN></STRONG></TD><TD style="WIDTH: 212px"><DIV style="TEXT-ALIGN: center"><TABLE id="TABLE2" runat="server"><TBODY><TR><TD style="WIDTH: 3px"><asp:TextBox id="txt_ecode" runat="server" Width="201px" AutoPostBack="True"></asp:TextBox></TD></TR></TBODY></TABLE></DIV><DIV style="TEXT-ALIGN: center"><TABLE id="TABLE1" runat="server"><TBODY><TR><TD style="HEIGHT: 24px"><asp:DropDownList id="drp_emp" runat="server" Width="207px" AutoPostBack="True">
                                    </asp:DropDownList></TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD style="BORDER-RIGHT: #ffcccc 2px solid; BORDER-TOP: #ffcccc 2px solid; BORDER-LEFT: #ffcccc 2px solid; BORDER-BOTTOM: #ffcccc 2px solid" colSpan=2><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000"></SPAN><asp:Label style="LEFT: 16px; POSITION: relative; TOP: -35px" id="Label1" runat="server" Text="Emp.Details" ForeColor="#FF0000" Font-Size="14pt" Font-Bold="True" Height="24px"></asp:Label> &nbsp; &nbsp; &nbsp;<asp:ListBox id="lst_emp" runat="server" Width="229px" Font-Bold="True" Height="92px" Font-Overline="False"></asp:ListBox></TD></TR><TR><TD style="HEIGHT: 26px; TEXT-ALIGN: right"><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000"><asp:Label id="lbl_ind" runat="server" Font-Bold="True"></asp:Label></SPAN></TD><TD style="WIDTH: 212px; HEIGHT: 26px; TEXT-ALIGN: center"><STRONG><SPAN style="COLOR: #ff0000"><SPAN style="COLOR: #000000"><asp:TextBox id="txt_tdate" onkeypress="return van()" runat="server" Width="206px" Font-Bold="True"></asp:TextBox></SPAN></SPAN></STRONG></TD></TR><TR style="COLOR: #000000"><TD style="WIDTH: 141px; TEXT-ALIGN: right"><SPAN style="FONT-SIZE: 14pt; COLOR: #ff0000"><STRONG>Remark</STRONG></SPAN></TD><TD style="WIDTH: 212px"><asp:TextBox id="txt_remark" runat="server" Width="207px" Height="21px" MaxLength="36"></asp:TextBox></TD></TR></TBODY></TABLE><asp:HiddenField id="h_ecode" runat="server"></asp:HiddenField> <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd-MMM-yyyy" targetcontrolid="txt_tdate"></cc1:calendarextender> 
</contenttemplate>
        </asp:UpdatePanel><div style="text-align: center">
            <table>
                <tr>
                    <td style="width: 185px; background-color: #ffcccc">
                    <asp:Button ID="Button1" runat="server" Text="DONE" Width="123px" Font-Bold="True" /></td>
                    <td style="width: 183px; background-color: #ffcccc">
                        <input id="cmd_exit" style="width: 109px; font-weight: bold;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
    
</asp:Content>

