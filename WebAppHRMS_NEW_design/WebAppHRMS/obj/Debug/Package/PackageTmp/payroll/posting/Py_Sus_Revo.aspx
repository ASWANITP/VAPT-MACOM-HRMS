<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Py_Sus_Revo.aspx.vb" Inherits="WebAppHRMS.PayRoll_Py_Sus_Revo_ce58b57d5528" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">

        function Cmd_Exit_onclick() {
            window.open('../../home.aspx', '_self');
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
        <strong><span style="font-size: 16pt; color: #ff0000">RESIGNATION/TERMINATION<br />
            <br />
            <table id="TABLE3" style="font-weight: bold; font-size: 16pt; border-left-color: #ffcccc; border-bottom-color: #ffcccc; width: 374px; color: #ff0000; border-top-style: solid; border-top-color: #ffcccc; border-right-style: solid; border-left-style: solid; height: 337px; border-right-color: #ffcccc; border-bottom-style: solid">
                <tr>
                    <td style="background-color: #ffcccc; text-align: right">
                        <span style="font-size: 14pt">Option</span></td>
                    <td style="background-color: #ffcccc">
                        <div style="text-align: center">
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="rad_resig" runat="server" AutoPostBack="True" Checked="True"
                                            Font-Bold="True" Font-Size="12pt" ForeColor="Red" GroupName="john" Text="RESIGN" /></td>
                                    <td style="font-size: 14pt; color: #ff0000">
                                        <asp:RadioButton ID="rad_termi" runat="server" AutoPostBack="True" Font-Bold="True"
                                            Font-Size="12pt" ForeColor="Red" GroupName="john" Text="TERMINATE" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr style="font-size: 14pt; color: #ff0000">
                    <td style="width: 3357px">Employee Code</td>
                    <td style="width: 255px; text-align: right">
                        <asp:TextBox ID="txt_ecode" runat="server" AutoPostBack="True" Width="206px"></asp:TextBox></td>
                </tr>
                <tr style="font-size: 14pt; color: #ff0000">
                    <td style="width: 3357px">Employee Details</td>
                    <td colspan="2" style="height: 99px">
                        <%--<asp:Label ID="Label1" runat="server" Style="left: -110px; position: relative; top: -53px"
                            Text="Emp.Details"></asp:Label>--%>
                        <div style="text-align: right">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:ListBox ID="lst_emp" runat="server" Font-Bold="True" Font-Overline="False" Height="92px"
                                            Width="229px"></asp:ListBox></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 3357px; height: 1px; text-align: right">
                        <span style="font-size: 14pt">Notice date</span></td>
                    <td style="width: 193px; height: 1px; text-align: right">
                        <strong><span style="color: #ff0000"><span style="color: #000000">
                            <asp:TextBox ID="txt_NoRdt" runat="server" Font-Bold="True" onkeypress="return van()"
                                Width="206px"></asp:TextBox></span></span></strong></td>
                </tr>
                <tr>
                    <td style="width: 3357px; text-align: right">
                        <span style="font-size: 14pt">Effect date</span></td>
                    <td style="width: 193px; text-align: right">
                        <asp:TextBox ID="txt_RoTdt" runat="server" Font-Bold="True" onkeypress="return van()"
                            Width="206px"></asp:TextBox></td>
                </tr>
                <tr style="color: #000000">
                    <td style="width: 3357px; text-align: right">
                        <span style="font-size: 14pt; color: #ff0000"><strong>Remark</strong></span></td>
                    <td style="width: 193px; text-align: right">
                        <asp:TextBox ID="txt_remark" runat="server" Height="20px" MaxLength="36" Width="207px"></asp:TextBox></td>
                </tr>
            </table>
            <asp:HiddenField ID="h_ecode" runat="server" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                TargetControlID="txt_NoRdt"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                TargetControlID="txt_RoTdt"></cc1:CalendarExtender>
            &nbsp;
        </span></strong>
        <div style="text-align: center">
            <table style="width: 376px">
                <tr>
                    <td style="background-color: #ffcccc; width: 146px;">
                        <input id="Cmd_Exit" style="width: 97px; font-weight: bold; cursor: hand;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
                    <td style="background-color: #ffcccc; text-align: right">
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="DONE" Width="123px" /></td>
                </tr>
            </table>
        </div>
        &nbsp; &nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;
    </div>

</asp:Content>

