<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Ho_Employees_reg_status.aspx.vb" Inherits="WebAppHRMS.vipin_forms_Ho_Employees_reg_status_80192d688963" Title="Untitled Page" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>

    <script language="javascript" type="text/javascript">
        var cont = header.split('txt');



    </script>

    <form id="f1">
        <div style="text-align: center">
            <table border="1" style="width: 509px">
                <caption>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_frmdate"></cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_todate"></cc1:CalendarExtender>
                </caption>
                <tr>
                    <td colspan="6" style="height: 26px">
                        <strong><span style="font-size: 14pt; color: #cc3300;">ATTENDANCE
                        REGULARIZATION REPORT</span></strong></td>
                </tr>
                <tr>
                    <td colspan="2">Enter Employee Code</td>
                    <td style="width: 100px"></td>
                    <td colspan="2" style="width: 159px">
                        <asp:TextBox ID="txt_empcode" runat="server" Width="151px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td style="width: 100px">From Date</td>
                    <td style="width: 90px">
                        <asp:TextBox ID="txt_frmdate" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">To Date</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_todate" runat="server" Width="145px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>

                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btn_confirm" runat="server" Text="Confirm" Width="109px" />
                        <asp:Button ID="btn_exit" runat="server" Text="Exit" Width="97px" /></td>

                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Report" Width="97px" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>


