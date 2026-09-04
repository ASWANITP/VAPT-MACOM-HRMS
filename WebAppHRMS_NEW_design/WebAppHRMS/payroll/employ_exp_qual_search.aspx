<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employ_exp_qual_search.aspx.vb" Inherits="WebAppHRMS.employ_expqual_9411ca966601" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onkeyup">
        return window_onkeyup()
    </script>

    <script language="javascript" type="text/javascript">


        var cont_name = sal.split('txt');
        function change(a) {
            var str = document.getElementById(cont_name[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cont_name[0] + a).value = "";
                document.getElementById(cont_name[0] + a).focus;
                return false;
            }

        }

        // ]]>
    </script>

    <div style="text-align: center">
        &nbsp;
    </div>
    <div style="text-align: center">
        <table>
            <tr>
                <td style="width: 100px; height: 483px;">
                    <table border="1" style="display: block; border-left-color: #ffcccc; border-bottom-color: #ffcccc; border-top-style: dotted; border-top-color: #ffcccc; border-right-style: dotted; border-left-style: dotted; border-right-color: #ffcccc; border-bottom-style: dotted">
                        <tr>
                            <td colspan="6" style="height: 26px">
                                <span style="font-size: 14pt; color: #cc3333"><strong>EMPLOYEE&nbsp;EMPLOYMENT&nbsp;SEARCH<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                </strong></span></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: left; height: 23px;"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right; width: 587px;">
                                <strong>SELECT ALL</strong></td>
                            <td colspan="3" style="text-align: left">
                                <asp:CheckBox ID="chk_all" runat="server" AutoPostBack="True" /></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 191px">
                                <div style="text-align: center">
                                    <table>
                                        <tr>
                                            <td style="width: 100px">
                                                <table border="1" style="display: block; border-left-color: #ffcccc; border-bottom-color: #ffcccc; border-top-style: dotted; border-top-color: #ffcccc; border-right-style: dotted; border-left-style: dotted; border-right-color: #ffcccc; border-bottom-style: dotted">
                                                    <tr>
                                                        <td style="width: 2086px; height: 27px">
                                                            <asp:CheckBox ID="chk_state" runat="server" AutoPostBack="True" Width="1px" /></td>
                                                        <td style="width: 453628px; height: 27px">
                                                            <strong>STATE</strong></td>
                                                        <td colspan="2" style="height: 27px">
                                                            <asp:DropDownList ID="cmb_state" runat="server" AutoPostBack="True" Width="254px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 23px; height: 27px">
                                                            <asp:CheckBox ID="chk_dis" runat="server" AutoPostBack="True" /></td>
                                                        <td style="width: 83px; height: 27px">
                                                            <strong>DISTRICT</strong></td>
                                                        <td style="width: 100px; height: 27px">
                                                            <asp:DropDownList ID="cmb_dis" runat="server" AutoPostBack="True" Width="238px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 2086px">
                                                            <asp:CheckBox ID="chk_exp" runat="server" AutoPostBack="True" Width="1px" /></td>
                                                        <td style="width: 453628px">
                                                            <strong>EXPERIENCE</strong><br />
                                                            <span style="color: #ff0033"><strong>(<span style="font-size: 9pt">IN MONTH WISE</span>)</strong></span></td>
                                                        <td style="text-align: left;" colspan="2">
                                                            <asp:TextBox ID="txt_exp" onkeyup="return change('txt_exp')" runat="server" Width="43px"></asp:TextBox></td>
                                                        <td style="width: 23px">
                                                            <asp:CheckBox ID="chk_qual" runat="server" AutoPostBack="True" /></td>
                                                        <td style="width: 83px">
                                                            <strong>QUALIFICATION<br />
                                                                CATEGORY</strong></td>
                                                        <td style="width: 100px">
                                                            <asp:DropDownList ID="cmb_qual" runat="server" AutoPostBack="True" Width="240px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 2086px; height: 43px">
                                                            <asp:CheckBox ID="chk_des" runat="server" AutoPostBack="True" Height="30px" Width="1px" /></td>
                                                        <td style="width: 453628px; height: 43px">
                                                            <strong>DESIGNATION</strong></td>
                                                        <td colspan="2" style="height: 43px">
                                                            <asp:DropDownList ID="cmb_des" runat="server" AutoPostBack="True" Width="252px">
                                                            </asp:DropDownList></td>
                                                        <td style="height: 43px" colspan="3"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;
                                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_des"></cc1:ListSearchExtender>
                                <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_dis"></cc1:ListSearchExtender>
                                <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_qual"></cc1:ListSearchExtender>
                                <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_state"></cc1:ListSearchExtender>
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 587px; height: 28px; text-align: center">
                                <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="139px" /></td>
                            <td colspan="3" style="height: 28px;">
                                <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="151px" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

