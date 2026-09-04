<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Py_Sus_Revo.aspx.vb" Inherits="WebAppHRMS.PayRoll_Py_Sus_Revo_71cebe146396" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script type="text/javascript">
        function cmd_exit_onclick() {
            window.open('../../../home.aspx', '_self');
        }
        function van() {
            alert("please select date from calendar!")
            return false;
        }
    </script>

    <br />
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <strong><span style="color: #ff0000"><span style="font-size: 14pt"><span style="font-size: 16pt">SUSPENTION/REVOCATION<br />
                </span>
                    <br />
                </span></span></strong>
                <table style="border-left-color: #ffcccc; border-bottom-color: #ffcccc; width: 374px; border-top-style: solid; border-top-color: #ffcccc; border-right-style: solid; border-left-style: solid; height: 337px; border-right-color: #ffcccc; border-bottom-style: solid" id="TABLE3">
                    <tbody>
                        <tr>
                            <td style="background-color: #ffcccc; text-align: right"><strong><span style="font-size: 14pt; color: #ff0000">Option</span></strong></td>
                            <td style="width: 212px; background-color: #ffcccc">
                                <div style="text-align: center">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:RadioButton ID="rad_susp" runat="server" Text="SUSPEND" Font-Bold="True" Checked="True" AutoPostBack="True" GroupName="john"></asp:RadioButton></td>
                                                <td style="width: 100px">
                                                    <asp:RadioButton ID="rad_revok" runat="server" Text="REVOKE" Font-Bold="True" AutoPostBack="True" GroupName="john"></asp:RadioButton></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="font-size: 14pt; color: #ff0000">
                            <td style="width: 141px; text-align: right"><strong><span style="font-size: 14pt; color: #ff0000">
                                <asp:Label Style="left: -4px; position: relative; top: -7px" ID="lbl_ecode" runat="server" Text="Employee Code"></asp:Label>
                                <asp:Label Style="left: -7px; position: relative; top: -1px" ID="lbl_emp" runat="server" Width="66px" Text="Employee"></asp:Label></span></strong></td>
                            <td style="width: 212px">
                                <div style="text-align: center">
                                    <table id="TABLE2" runat="server">
                                        <tbody>
                                            <tr>
                                                <td style="width: 3px">
                                                    <asp:TextBox ID="txt_ecode" runat="server" Width="201px" AutoPostBack="True"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div style="text-align: center">
                                    <table id="TABLE1" runat="server">
                                        <tbody>
                                            <tr>
                                                <td style="height: 24px">
                                                    <asp:DropDownList ID="drp_emp" runat="server" Width="207px" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: #ffcccc 2px solid; border-top: #ffcccc 2px solid; border-left: #ffcccc 2px solid; border-bottom: #ffcccc 2px solid" colspan="2"><span style="font-size: 14pt; color: #ff0000"></span>
                                <asp:Label Style="left: 16px; position: relative; top: -35px" ID="Label1" runat="server" Text="Emp.Details" ForeColor="#FF0000" Font-Size="14pt" Font-Bold="True" Height="24px"></asp:Label>
                                &nbsp; &nbsp; &nbsp;<asp:ListBox ID="lst_emp" runat="server" Width="229px" Font-Bold="True" Height="92px" Font-Overline="False"></asp:ListBox></td>
                        </tr>
                        <tr>
                            <td style="height: 26px; text-align: right"><span style="font-size: 14pt; color: #ff0000">
                                <asp:Label ID="lbl_ind" runat="server" Font-Bold="True"></asp:Label></span></td>
                            <td style="width: 212px; height: 26px; text-align: center"><strong><span style="color: #ff0000"><span style="color: #000000">
                                <asp:TextBox ID="txt_tdate" onkeypress="return van()" runat="server" Width="206px" Font-Bold="True"></asp:TextBox></span></span></strong></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="width: 141px; text-align: right"><span style="font-size: 14pt; color: #ff0000"><strong>Remark</strong></span></td>
                            <td style="width: 212px">
                                <asp:TextBox ID="txt_remark" runat="server" Width="207px" Height="21px" MaxLength="36"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
                <asp:HiddenField ID="h_ecode" runat="server"></asp:HiddenField>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_tdate"></cc1:CalendarExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: center">
            <table>
                <tr>
                    <td style="width: 185px; background-color: #ffcccc">
                        <asp:Button ID="Button1" runat="server" Text="DONE" Width="123px" Font-Bold="True" /></td>
                    <td style="width: 183px; background-color: #ffcccc">
                        <input id="cmd_exit" style="width: 109px; font-weight: bold;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>

</asp:Content>

