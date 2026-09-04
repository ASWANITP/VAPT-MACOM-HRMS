<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Block_employee.aspx.vb" Inherits="WebAppHRMS.november_Block_employee_a351de278076" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <table>
            <tr>
                <td colspan="4">
                    <strong><span style="font-size: 14pt">SALARY
                    BLOCK<br />
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager></span></strong><cc1:listsearchextender id="ListSearchExtender1"
                            runat="server" targetcontrolid="Cmb_block"></cc1:listsearchextender></td>
            </tr>
            <tr>
                <td colspan="2">
                    SELECT EMPLOYEE</td>
                <td colspan="2">
                    <asp:DropDownList ID="Cmb_block" runat="server" Width="414px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="Cmd_block" runat="server" Text="BLOCK" Width="89px" /></td>
                                <td style="width: 100px">
                                    <input id="Cmd_exit" style="width: 91px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /></td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

