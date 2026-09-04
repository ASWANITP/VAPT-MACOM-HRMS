<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="tour_applied_status.aspx.vb" Inherits="WebAppHRMS.tour_cancellation_tour_applied_status_da0288ba1432" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <br />
    <div style="text-align:center">
    <table border="1" style="width: 503px; height: 99px">
        <tr>
            <td colspan="3" style="height: 40px; text-align: center">
                <span style="color: #ff0099; text-decoration: underline">TOUR REPORT</span></td>
        </tr>
        <tr>
            <td style="width: 186px; text-align: right">
                Employee Name :&nbsp;
            </td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_code" runat="server" Width="340px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td rowspan="2" style="width: 186px; text-align: right">
                Tour From Date :&nbsp;
            </td>
            <td style="width: 16px; height: 13px; text-align: right">
                From :
            </td>
            <td style="width: 100px; height: 13px; text-align: left">
                <asp:TextBox ID="txt_from" runat="server"></asp:TextBox>
                &nbsp; &nbsp;<cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                    targetcontrolid="txt_from"></cc1:calendarextender>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 16px; height: 4px; text-align: right">
                To :
            </td>
            <td style="width: 100px; height: 4px; text-align: left">
                <asp:TextBox ID="txt_to" runat="server"></asp:TextBox>
                <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                    targetcontrolid="txt_to"></cc1:calendarextender>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 20px;" colspan="3">
                <div style="text-align: center">
                    <table border="1" style="width: 172px">
                        <tr>
                            <td style="width: 100px">
                <input id="Button1"  style="width: 84px" type="button"
                    value="EXIT" onclick="return Button1_onclick()" /></td>
                            <td style="width: 100px">
                <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="79px" /></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

