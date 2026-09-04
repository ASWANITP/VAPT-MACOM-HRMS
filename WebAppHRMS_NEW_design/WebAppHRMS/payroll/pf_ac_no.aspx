<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pf_ac_no.aspx.vb" Inherits="WebAppHRMS.pf_ac_no_entry_pf_ac_no_33f12f708933" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
    </cc1:ListSearchExtender>

    <br />
    <div style="text-align: center">
        <table border="1" style="width: 568px; height: 131px">
            <tr>
                <td colspan="2" style="height: 47px; text-align: center">
                    <span style="color: #cc0099; text-decoration: underline"><strong>PF ACCOUNT NO. ENTRY
                        FORM</strong></span></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right">Emp Code :
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:DropDownList ID="cmb_code" runat="server" Width="418px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right;">Company Code :
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:TextBox ID="txt_company" runat="server" ReadOnly="True" Width="211px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right;">PF A/C No.
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:TextBox ID="txt_pf" runat="server" MaxLength="4"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_pf"
                        ErrorMessage="Please Enter Numeric Value" ValidationExpression="^([0-9])*$" Width="417px"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 141px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 141px; text-align: right;">
                    <input id="cmd_exit" style="width: 68px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; text-align: left;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

