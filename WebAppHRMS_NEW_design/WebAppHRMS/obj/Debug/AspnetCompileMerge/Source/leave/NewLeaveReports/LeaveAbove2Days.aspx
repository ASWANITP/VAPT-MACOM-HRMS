<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LeaveAbove2Days.aspx.vb" Inherits="WebAppHRMS.LeaveAbove2Days_8566fc0d1935" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
function correct(a,e) 
{

        document.getElementById("ctl00_cph_edp_"+a).value=""
        document.getElementById("ctl00_cph_edp_"+a).focus()
              
}

// ]]>
</script>

    <div style="text-align: center">
        <br />
        <br />
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <br />
        <table style="border-right: darkslategray 1px outset; table-layout: fixed; border-top: darkslategray 1px outset;
            border-left: darkslategray 1px outset; width: 615px; border-bottom: darkslategray 1px outset;
            border-collapse: separate; height: auto">
            <tr style="height:30px;">
                <td colspan="4" style="background-color: #5d7b9d; color: white;">
                    &nbsp;<strong><span>MORE THAN 2
                        DAYS LEAVE</span></strong></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
                <td style="height: 30px">
                </td>
                <td style="height: 30px">
                </td>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    FROM DATE</td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBox2" runat="server" onkeyup="return correct('TextBox2',event)" Width="139px"></asp:TextBox></td>
                <td style="text-align: right">
                    TO DATE</td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBox3" runat="server" onkeyup="return correct('TextBox3',event)" Width="137px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 45px">
                </td>
                <td style="height: 45px">
                    <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="TextBox2" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
                <td style="height: 45px">
                </td>
                <td style="height: 45px">
                    <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="TextBox3" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="121px" /></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="EXIT" Width="133px" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        &nbsp;<br />
        <br />
        <br />
    </div>
</asp:Content>

