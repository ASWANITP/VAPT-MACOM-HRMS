<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Block_employee.aspx.vb" Inherits="WebAppHRMS.november_Block_employee_a351de278076" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

      
    </script>

    <div style="text-align: center">
        <table>
            <tr>
                <td colspan="4">
                    <strong><span style="font-size: 14pt">SALARY
                    BLOCK<br />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </span></strong>
                    <cc1:ListSearchExtender ID="ListSearchExtender1"
                        runat="server" TargetControlID="Cmb_block">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">SELECT EMPLOYEE</td>
                <td colspan="2">
                    <asp:DropDownList ID="Cmb_block" runat="server" Width="414px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Cmd_block" runat="server" Text="BLOCK" Width="89px" /></td>
                                <td style="width: 100px">
                                    <input id="Cmd_exit" style="width: 91px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /></td>
                                <td style="width: 100px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

