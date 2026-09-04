<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="appln_conf.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_appln_conf_dc38b86b2612" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        return window_onload()
        // ]]>
    </script>


    <script language="javascript" type="text/javascript">
        function check_dt() {
            alert("Select Date From Calender");
            return false;
        }
        function window_onload() {

        }

    </script>
    <table align="center" border="1" style="width: 674px">
        <tr>
            <td style="height: 23px; text-align: center;" colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 17px;" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 708px" align="center" border="1">
                            <tbody>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="lbl_msg" runat="server" Width="208px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                        Interview Details</td>
                                </tr>
                                <tr>
                                    <td colspan="2">Application No &amp; Candidate Name</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="cmb_appln" runat="server" Width="357px"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 104px">Interviewed By</td>
                                    <td>
                                        <asp:TextBox ID="txt_intvwid" runat="server" Width="160px" AutoPostBack="True"></asp:TextBox></td>
                                    <td>Name</td>
                                    <td>
                                        <asp:TextBox ID="txt_intvwname" runat="server" Width="160px" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 104px">Interviewed At</td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_place" runat="server" Width="165px">
                                        </asp:DropDownList></td>
                                    <td style="width: 100px">Post Offered</td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_post" runat="server" Width="304px"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 104px">Interview Date</td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_dt" onkeypress="return check_dt()" runat="server" Width="160px" AutoPostBack="True" OnTextChanged="txt_dt_TextChanged"></asp:TextBox></td>
                                    <td style="width: 100px">Status</td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_status" runat="server" Width="165px">
                                            <asp:ListItem Value="1">CLEARED</asp:ListItem>
                                            <asp:ListItem Value="2">PENDING</asp:ListItem>
                                            <asp:ListItem Value="0">REJECTED</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 28px">
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" />
            </td>
            <td align="center" style="height: 28px">
                <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="68px" />
            </td>
        </tr>
    </table>
</asp:Content>

