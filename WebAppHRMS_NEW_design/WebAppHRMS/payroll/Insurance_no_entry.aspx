<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Insurance_no_entry.aspx.vb" Inherits="WebAppHRMS.ESI_Insurance_no_entry_2c4585a08711" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table border="1" style="width: 490px; height: 93px">
            <tr>
                <td colspan="2" style="height: 43px; text-align: center">
                    <span style="font-size: 13pt; color: #cc0099; text-decoration: underline"><strong>INSURANCE
                    NO. &amp; LOCAL OFFICE ENTRY FORM</strong></span></td>
            </tr>
            <tr>
                <td style="width: 1421px; text-align: right">Emp Code :
                </td>
                <td style="width: 92px; text-align: left">
                    <asp:DropDownList ID="cmb_code" runat="server" Width="314px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 1421px; text-align: right; height: 21px;">Insurance No.
                </td>
                <td style="width: 92px; text-align: left; height: 21px;">
                    <asp:TextBox ID="txt_insurance" runat="server" MaxLength="16"></asp:TextBox>
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code"></cc1:ListSearchExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 1421px; height: 21px; text-align: right">Local Office :
                </td>
                <td style="width: 92px; height: 21px; text-align: left">
                    <asp:DropDownList ID="cmb_local" runat="server" Width="322px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 1421px; text-align: right">
                    <input id="cmd_exit" style="width: 68px" type="button"
                        value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 92px; text-align: left">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

