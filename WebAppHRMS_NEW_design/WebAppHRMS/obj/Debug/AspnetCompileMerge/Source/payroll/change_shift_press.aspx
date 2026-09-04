<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="change_shift_press.aspx.vb" Inherits="WebAppHRMS.feb2009_change_shift_press_40e058a18002" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('lbl');
function Cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
function gov()
{
//alert(document.getElementById(cont_name[0]+"lbl_msg"))
 document.getElementById(cont_name[0]+"lbl_msg").innerHTML="SELECT THE EFFECTIVE DATE BEFORE TAKING REPORT";

}
function gou()
{

//alert("t")
 document.getElementById(cont_name[0]+"lbl_msg").innerHTML="";
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 825px">
            <tr>
                <td colspan="4" style="background-color: #ffcc33; height: 50px;">
                    <strong><span style="font-size: 14pt; color: #ff0000">SHIFT CHANGE</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: transparent">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_employ">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    </td>
            </tr>
            <tr>
                <td style="width: 172px; height: 26px;">
                    <span style="font-family: Georgia">
                    Select Employee</span></td>
                <td colspan="3" style="height: 26px; text-align: left">
                    <asp:DropDownList ID="Cmb_employ" runat="server" Width="636px" BackColor="Azure" Font-Bold="True" ForeColor="Black">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 172px">
                    <span style="font-family: Georgia">
                    Select Effective Date</span></td>
                <td style="width: 83px">
                    <asp:TextBox ID="Txt_effdt" runat="server" ForeColor="Black" BackColor="Azure"></asp:TextBox></td>
                <td style="width: 84px">
                    <span style="font-family: Georgia">
                    Select Shift</span></td>
                <td style="width: 71px; text-align: left;">
                    <asp:DropDownList ID="Cmb_shift" runat="server" Width="386px" BackColor="Azure" ForeColor="Blue">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 46px;" colspan="4">
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_effdt"></cc1:calendarextender>
                </td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align: left">
                    &nbsp;
                <asp:CheckBox ID="chkPerm" runat="server" Text="Make the shift Permanent" /></td>
            </tr>
            
            <tr>
                <td colspan="4">
                    <asp:Label ID="lbl_msg" runat="server" Width="806px" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 55px">
                    <table style="width: 438px">
                        <tr>
                            <td style="width: 125px; text-align: center; height: 26px;">
                                <asp:Button ID="Cmd_confirm" runat="server" Text="CONFIRM" /></td>
                            <td style="width: 125px; height: 26px; text-align: center">
                            </td>
                            <td style="width: 125px; height: 26px; text-align: center">
                                <asp:Button ID="Cmd_report" onmouseover="gov()" onmouseout="gou()" runat="server" Text="REPORT" Width="93px" /></td>
                            <td style="width: 125px; height: 26px; text-align: center">
                            </td>
                            <td style="width: 125px; text-align: center; height: 26px;">
                                <input id="Cmd_exit" style="width: 84px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;</div>
</asp:Content>

