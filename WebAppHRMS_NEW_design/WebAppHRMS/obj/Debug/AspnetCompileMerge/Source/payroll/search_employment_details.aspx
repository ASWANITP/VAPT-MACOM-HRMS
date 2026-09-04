        <%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="search_employment_details.aspx.vb" Inherits="WebAppHRMS.search_employment_details_4196ce4b8918" Title="Untitled Page" %>

        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
            <script language="javascript" type="text/javascript">
                // <!CDATA[

                function cmd_exit_onclick() {
                    window.open('../home.aspx', '_self');
                }

                // ]]>
            </script>
            <div style="text-align: center">
                &nbsp;
            </div>
            <div style="text-align: center">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <table border="1" style="display: block; border-left-color: #ffcccc; border-bottom-color: #ffcccc; border-top-style: dotted; border-top-color: #ffcccc; border-right-style: dotted; border-left-style: dotted; border-right-color: #ffcccc; border-bottom-style: dotted">
                                <tr>
                                    <td colspan="6" style="height: 26px">
                                        <span style="font-size: 14pt; color: #cc3333"><strong>EMPLOYEE EMPLOYMENT DETAILS<br />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                        </strong></span></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 163px">FROM DATE</td>
                                    <td style="width: 84px; text-align: left">
                                        <asp:TextBox ID="txt_fdt" runat="server" Width="187px"></asp:TextBox></td>
                                    <td colspan="2" style="width: 95px">TO DATE</td>
                                    <td style="width: 100px; text-align: left">
                                        <asp:TextBox ID="txt_tdt" runat="server" Width="197px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: right">SELECT ALL</td>
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
                                                                <td style="width: 23px; height: 27px">
                                                                    <asp:CheckBox ID="chk_emp" runat="server" AutoPostBack="True" /></td>
                                                                <td style="width: 83px; height: 27px">EMPLOYEE TYPE</td>
                                                                <td style="width: 100px; height: 27px">
                                                                    <asp:DropDownList ID="cmb_type" runat="server" AutoPostBack="True" Width="238px">
                                                                        <asp:ListItem Value="1">REGULAR</asp:ListItem>
                                                                        <asp:ListItem Value="2">OUTSOURCE</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td style="width: 23px; height: 27px">
                                                                    <asp:CheckBox ID="chk_firm" runat="server" AutoPostBack="True" /></td>
                                                                <td style="width: 83px; height: 27px">FIRM</td>
                                                                <td style="width: 100px; height: 27px">
                                                                    <asp:DropDownList ID="cmb_firm" runat="server" AutoPostBack="True" Width="238px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 23px">
                                                                    <asp:CheckBox ID="chk_branch" runat="server" AutoPostBack="True"  /></td>
                                                                <td style="width: 83px">BRANCH</td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="cmb_branch" runat="server" AutoPostBack="True" Width="240px">
                                                                    </asp:DropDownList></td>
                                                                <td style="width: 23px">
                                                                    <asp:CheckBox ID="chk_dep" runat="server" AutoPostBack="True" /></td>
                                                                <td style="width: 83px">DEPARTMENT</td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="cmb_dep" runat="server" AutoPostBack="True" Width="240px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 23px;height: 43px">
                                                                    <asp:CheckBox ID="chk_des" runat="server" AutoPostBack="True"  /></td>
                                                                <td style="width: 83px; height: 43px">DESIGNATION</td>
                                                                <td style="width: 100px; height: 43px">
                                                                    <asp:DropDownList ID="cmb_des" runat="server" AutoPostBack="True" Width="240px">
                                                                    </asp:DropDownList></td>
                                                                <td style="width: 23px; height: 43px">
                                                                    <asp:CheckBox ID="chk_post" runat="server" AutoPostBack="True" /></td>
                                                                <td style="width: 83px; height: 43px">POST</td>
                                                                <td style="width: 100px; height: 43px">
                                                                    <asp:DropDownList ID="cmb_post" runat="server" AutoPostBack="True" Width="240px">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                                            TargetControlID="txt_tdt"></cc1:CalendarExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                                            TargetControlID="txt_fdt"></cc1:CalendarExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_type"></cc1:ListSearchExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_firm"></cc1:ListSearchExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_branch"></cc1:ListSearchExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_dep"></cc1:ListSearchExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender5" runat="server" TargetControlID="cmb_des"></cc1:ListSearchExtender>
                                        <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_post"></cc1:ListSearchExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 163px"></td>
                                    <td style="width: 84px; text-align: center;">
                                        <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="139px" /></td>
                                    <td colspan="2" style="width: 95px"></td>
                                    <td style="width: 100px">
                                    <%--<asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="151px" /></td>--%>
                                    <input id="cmd_exit" type="button" value="EXIT" onclick="return cmd_exit_onclick()" style="width: 151px" />
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Content>

