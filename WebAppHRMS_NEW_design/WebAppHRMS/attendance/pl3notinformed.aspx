<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pl3notinformed.aspx.vb" Inherits="WebAppHRMS.pl3absent_pl3notinformed_d108b4909634" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function correct(a, e) {

            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()

        }

        // ]]>
    </script>
    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" BackColor="BlanchedAlmond" Font-Bold="True"
                            Font-Size="Large" ForeColor="Maroon" Text="NOT INFROMED PL3" Width="636px" Height="26px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <table border="1" style="width: 472px">
                                <tr>
                                    <td style="width: 148px; height: 28px">
                                        <strong><span style="color: #660033">Select category</span></strong></td>
                                    <td style="width: 90px; height: 28px; text-align: left">
                                        <asp:DropDownList ID="Cmb_category" runat="server" Width="304px">
                                            <asp:ListItem Value="1">MORNING</asp:ListItem>
                                            <asp:ListItem Value="2">EVENING</asp:ListItem>
                                            <asp:ListItem Value="3">BOTH MORNING &amp; EVENING</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 148px; height: 28px">
                                        <strong><span style="color: #330000">ENTER DATE</span></strong></td>
                                    <td style="width: 90px; height: 28px; text-align: left">
                                        <asp:TextBox ID="Txt_fdate" runat="server" Width="155px" onkeyup="return correct('Txt_fdate',event)"></asp:TextBox></td>
                                </tr>
                            </table>
                        </div>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="Txt_fdate"></cc1:CalendarExtender>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <table>
                                <tr>
                                    <td style="width: 100px; height: 31px"></td>
                                    <td style="width: 100px; height: 31px"></td>
                                    <td style="width: 100px; height: 31px">
                                        <asp:Button ID="cmd_confrim" runat="server" BackColor="#FFC0C0" Font-Bold="True"
                                            ForeColor="#400000" Text="CONFIRM" Width="99px" /></td>
                                    <td style="width: 100px; height: 31px">
                                        <asp:Button ID="cmd_exit" runat="server" BackColor="#FFC0C0" Font-Bold="True" ForeColor="#400040"
                                            Text="EXIT" Width="105px" /></td>
                                    <td style="width: 100px; height: 31px"></td>
                                    <td style="width: 100px; height: 31px"></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px; text-align: center">&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

