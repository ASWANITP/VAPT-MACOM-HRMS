<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_report.aspx.vb" Inherits="WebAppHRMS.promotiondetails_promotion_report_1ee797829058" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script language="javascript" type="text/javascript">

        function van() {
            alert("Please select date from calendar! ")
            return false;
        }

    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 518px; background-color: transparent">
            <tr>
                <td colspan="2" style="height: 23px; background-color: #ffffcc; width: 525px;">
                    <strong><span style="font-size: 14pt; color: #660000">EMPLOYEE PROMOTION DETAILS</span></strong></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px; width: 525px;">&nbsp;<cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_select"></cc1:ListSearchExtender>
                    <table border="1" style="width: 518px">
                        <tr>
                            <td style="width: 206px">SELECT EMPLOYEE :</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="cmb_select" runat="server" Width="310px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    &nbsp;
                    <div style="text-align: center">
                        <table style="width: 520px">
                            <tr>
                                <td style="width: 100px">FROM DATE</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_fdt" onkeypress="return van()" runat="server"></asp:TextBox></td>
                                <td style="width: 100px">TO DATE</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_tdt" onkeypress="return van()" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_fdt"></cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_tdt"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px; width: 525px;">
                    <div style="text-align: center">
                        <table style="width: 504px">
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="87px" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="83px" /></td>
                                <td style="width: 100px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

