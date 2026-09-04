<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DateFiller.ascx.vb" Inherits="WebAppHRMS.DateFiller" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
function dateerror() 
{
    alert("Please Select Date From Calender");
    return false;
}
</script>


<div style="text-align: center">
    <table border="1" style="width: 80%">
        <tr>
            <td style="width: 62px">
                &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
            <td colspan="2" style="text-align: center">
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" Format="dd/MMM/yyyy">
                </cc1:CalendarExtender>
                &nbsp;<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" Format="dd/MMM/yyyy">
                </cc1:CalendarExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                &nbsp;
                Date Filler
            </td>
            <td style="width: 112px">
                &nbsp; &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 62px">
                FromDate</td>
            <td style="width: 79px">
                <asp:TextBox ID="txt_from"  onkeypress ="return dateerror()" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                To Date</td>
            <td style="width: 112px">
                <asp:TextBox ID="txt_to" onkeypress ="return dateerror()" runat="server"></asp:TextBox></td>
        </tr>
    </table>
</div>
