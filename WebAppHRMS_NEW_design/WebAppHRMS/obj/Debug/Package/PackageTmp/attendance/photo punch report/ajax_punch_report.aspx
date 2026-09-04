<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="ajax_punch_report.aspx.vb" Inherits="WebAppHRMS.new_view_punch_report_2b45d0537516" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

    function cmd_exit_onclick()
    {
window.open('../../home.aspx','_self');
}
function van() 
{
alert ("Please select date from calendar! ");
  return false;
}
// ]]>
</script>

    <div style="text-align: center">
        <table>
            <tr>
                <td colspan="4" style="height: 47px">
                    <strong><span style="color: #ff0033">PHOTO PUNCHING REPORT 
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </span></strong>
                </td>
            </tr>
                        <tr>
                <td style="width: 110px; text-align: left">
                    </td>
                <td  style="width: 120px; text-align: left">
                     Employ Wise<asp:CheckBox AutoPostBack="true" ID="CheckBox1" Checked="true" runat="server" />
                     </td>
                <td style="width: 110px; text-align: left">
                     State Wise<asp:CheckBox AutoPostBack="true" ID="CheckBox2" Checked="false" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: left">
                   &nbsp;</td>
                <td  style="width: 120px; text-align: left">
                    &nbsp;
                     </td>
                <td style="width: 110px; text-align: left">
                    &nbsp;
                </td>
            </tr>
                        <tr id="Tr1" runat="server">
                <td style="width: 110px; text-align: left">
                    Select Employee</td>
                <td colspan="2" style="width: 110px; text-align: left">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="218px" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="width: 110px; text-align: left">
                    <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_state">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr id="rt1" runat="server">
                <td style="width: 110px; text-align: left">
                    Select State</td>
                <td colspan="2" style="width: 110px; text-align: left">
                    <asp:DropDownList ID="cmb_state" runat="server" Width="218px" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="width: 110px; text-align: left">
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_state">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr id="rt2" runat="server">
                <td style="width: 110px; text-align: left">
                    Select Branch</td>
                <td colspan="2" style="width: 110px; text-align: left">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="218px">
                    </asp:DropDownList></td>
                <td style="width: 110px; text-align: left">
                    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_branch">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: left">
                    From Date</td>
                <td colspan="2" style="width: 110px; text-align: left">
                    <asp:TextBox ID="Txt_fdt" onkeydown="return false" ondrag="return false" ondrop="return false" onkeypress="return van()" runat="server" Width="159px"></asp:TextBox></td>
                <td style="width: 110px; text-align: left">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: left">
                    To Date</td>
                <td colspan="2" style="width: 110px; text-align: left">
                    <asp:TextBox ID="Txt_tdt" onkeydown="return false" ondrag="return false" ondrop="return false" runat="server" onkeypress="return van()" Width="161px"></asp:TextBox></td>
                <td style="width: 110px; text-align: left">
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_tdt">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 101px; height: 21px; text-align: left">
                </td>
                <td colspan="2" style="height: 21px; text-align: left">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 101px; height: 21px; text-align: left">
                </td>
                <td colspan="2" style="height: 21px; text-align: left">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px; height: 21px">
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                                <td style="width: 100px; height: 21px">
                                    <input id="cmd_exit" style="width: 84px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

