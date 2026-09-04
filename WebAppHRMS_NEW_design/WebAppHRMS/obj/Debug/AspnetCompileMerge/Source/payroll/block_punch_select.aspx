<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="block_punch_select.aspx.vb" Inherits="WebAppHRMS.new_newmail_block_punch_select_cdba7c323295" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
function da()
{
      alert('Please Enter Date using Calendar!!');
      document.getElementById(cs[0]+"Txt_dt").value="";
  
}
// ]]>
</script>

    <div style="text-align: center">
        <table>
            <tr>
                <td colspan="4">
                    <strong>PUNCH BLOCK DETAILS<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
                        <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="Txt_dt" Format="dd/MMM/yyyy"></cc1:calendarextender>
                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 154px; height: 40px">
                    <asp:CheckBox ID="Chk_emp" runat="server" AutoPostBack="True" Font-Bold="True" Text="Select Employee "
                        Width="131px" /></td>
                <td style="width: 100px; height: 40px">
                    <asp:DropDownList ID="Cmb_emp" runat="server" Width="253px">
                    </asp:DropDownList></td>
                <td style="width: 130px; height: 40px">
                    <strong>Select Date</strong></td>
                <td style="width: 100px; height: 40px">
                    <asp:TextBox ID="Txt_dt" onkeyup="da()" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 154px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 130px; height: 21px">
                    <input id="cmd_exit" style="width: 86px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 154px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 130px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

