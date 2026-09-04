<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emprep.aspx.vb" Inherits="WebAppHRMS.employee_report_emprep_bb4a3f117745" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("Chk");

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
function datecheck(id)
 {
    alert('Please Enter the date from Calendar....!\nJust Click on the respective box for Calendar');
    document.getElementById(cs[0]+"txt_from").value="";    
    return false;
 }
// ]]>
</script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<TABLE style="WIDTH: 366px; HEIGHT: 191px" border=1><TBODY><TR><TD style="WIDTH: 142px; HEIGHT: 18px; TEXT-ALIGN: left">&nbsp; <asp:CheckBox id="chk_qualif" runat="server" Text="Qualification :" AutoPostBack="True" OnCheckedChanged="chk_qualif_CheckedChanged"></asp:CheckBox> </TD><TD style="WIDTH: 100px; HEIGHT: 18px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_qualif" runat="server" Width="208px" AutoPostBack="True">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 142px; HEIGHT: 19px; TEXT-ALIGN: left">&nbsp; <asp:CheckBox id="Chk_post" runat="server" Text="Post :" AutoPostBack="True" OnCheckedChanged="Chk_post_CheckedChanged"></asp:CheckBox>&nbsp; </TD><TD style="WIDTH: 100px; HEIGHT: 19px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_post" runat="server" Width="206px" AutoPostBack="True">
                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 142px; HEIGHT: 22px; TEXT-ALIGN: left">&nbsp; <asp:CheckBox id="chk_gender" runat="server" Text="Gender :" AutoPostBack="True" OnCheckedChanged="chk_gender_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 22px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_gender" runat="server" Width="206px" AutoPostBack="True"><asp:ListItem Value="1">Male</asp:ListItem>
<asp:ListItem Value="0">Female</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD style="WIDTH: 142px; HEIGHT: 9px; TEXT-ALIGN: left">&nbsp; <asp:CheckBox id="Chk_age" runat="server" Text="Age : " AutoPostBack="True" OnCheckedChanged="Chk_age_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 9px; TEXT-ALIGN: left"><DIV style="TEXT-ALIGN: left"><TABLE style="WIDTH: 205px; HEIGHT: 18px" border=1><TBODY><TR><TD style="WIDTH: 100px">From </TD><TD style="WIDTH: 30px"><asp:TextBox id="txt_agefrom" runat="server" Width="51px" Height="14px"></asp:TextBox></TD><TD style="WIDTH: 100px">To</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_ageto" runat="server" Width="51px" Height="14px"></asp:TextBox></TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD style="WIDTH: 142px; TEXT-ALIGN: left">&nbsp; Joining Date : </TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><TABLE border=1><TBODY><TR><TD style="WIDTH: 36px">From</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_from" onkeyup="datecheck('txt_from')" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 36px">To</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_to" onkeyup="datecheck('txt_to')" runat="server"></asp:TextBox></TD></TR></TBODY></TABLE><cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy" targetcontrolid="txt_from"></cc1:calendarextender> <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy" targetcontrolid="txt_to"></cc1:calendarextender> </TD></TR></TBODY></TABLE>
</ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td style="width: 100px">
                        <input id="cmd_exit" style="width: 89px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="cmd_confirm" runat="server" Text="REPORT" Width="77px" /></td>
                </tr>
            </table>
        </div>
        &nbsp;</div>
    <br />
</asp:Content>

