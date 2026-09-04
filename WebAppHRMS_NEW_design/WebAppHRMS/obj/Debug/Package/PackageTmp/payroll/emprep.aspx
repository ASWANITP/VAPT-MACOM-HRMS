<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emprep.aspx.vb" Inherits="WebAppHRMS.employee_report_emprep_bb4a3f117745" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("Chk");

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function datecheck(id) {
            alert('Please Enter the date from Calendar....!\nJust Click on the respective box for Calendar');
            document.getElementById(cs[0] + "txt_from").value = "";
            return false;
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 366px; height: 191px" border="1">
                    <tbody>
                        <tr>
                            <td style="width: 142px; height: 18px; text-align: left">&nbsp;
                                <asp:CheckBox ID="chk_qualif" runat="server" Text="Qualification :" AutoPostBack="True" OnCheckedChanged="chk_qualif_CheckedChanged"></asp:CheckBox>
                            </td>
                            <td style="width: 100px; height: 18px; text-align: left">
                                <asp:DropDownList ID="cmb_qualif" runat="server" Width="208px" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 142px; height: 19px; text-align: left">&nbsp;
                                <asp:CheckBox ID="Chk_post" runat="server" Text="Post :" AutoPostBack="True" OnCheckedChanged="Chk_post_CheckedChanged"></asp:CheckBox>&nbsp; </td>
                            <td style="width: 100px; height: 19px; text-align: left">
                                <asp:DropDownList ID="cmb_post" runat="server" Width="206px" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 142px; height: 22px; text-align: left">&nbsp;
                                <asp:CheckBox ID="chk_gender" runat="server" Text="Gender :" AutoPostBack="True" OnCheckedChanged="chk_gender_CheckedChanged"></asp:CheckBox></td>
                            <td style="width: 100px; height: 22px; text-align: left">
                                <asp:DropDownList ID="cmb_gender" runat="server" Width="206px" AutoPostBack="True">
                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                    <asp:ListItem Value="0">Female</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 142px; height: 9px; text-align: left">&nbsp;
                                <asp:CheckBox ID="Chk_age" runat="server" Text="Age : " AutoPostBack="True" OnCheckedChanged="Chk_age_CheckedChanged"></asp:CheckBox></td>
                            <td style="width: 100px; height: 9px; text-align: left">
                                <div style="text-align: left">
                                    <table style="width: 205px; height: 18px" border="1">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100px">From </td>
                                                <td style="width: 30px">
                                                    <asp:TextBox ID="txt_agefrom" runat="server" Width="51px" Height="14px"></asp:TextBox></td>
                                                <td style="width: 100px">To</td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txt_ageto" runat="server" Width="51px" Height="14px"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px; text-align: left">&nbsp; Joining Date : </td>
                            <td style="width: 100px; text-align: left">
                                <table border="1">
                                    <tbody>
                                        <tr>
                                            <td style="width: 36px">From</td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txt_from" onkeyup="datecheck('txt_from')" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 36px">To</td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txt_to" onkeyup="datecheck('txt_to')" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_from"></cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_to"></cc1:CalendarExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
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
        &nbsp;
    </div>
    <br />
</asp:Content>

