<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="suspended_employ.aspx.vb" Inherits="WebAppHRMS.majewel_suspention_majewel_datewise_06cc82cb8712" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
window.open("../../../home.aspx","_self");
}
function ConClintClick()
{


  if(document.getElementById('<%=txt_cal1.ClientID%>').value=="")
    {
        alert("Please Enter From date...!");
         return false;
        
        }

        if(document.getElementById('<%=txt_cal2.ClientID%>').value=="")
       {
        alert("Please Enter To date...!");
       return false;
            }
}
// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 600px; height: 59px">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_cal1">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_cal2">
                </cc1:CalendarExtender>
                &nbsp;<strong><span style="font-size: 14pt"> SUSPENDED EMPLOYEES DETAILS</span>&nbsp;</strong></caption>
            <tr>
                <td style="width: 100px">
                    <strong>From Date</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_cal1" runat="server" Width="179px"></asp:TextBox></td>
                <td style="width: 100px">
                    <strong>To Date</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_cal2" runat="server" Width="179px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:Button ID="Button1" runat="server" OnClientClick="return ConClintClick()"  Text="Confirm" Width="89px" /></td>
                <td style="width: 100px">
                    <input id="Reset1" style="width: 85px" type="reset" value="EXIT" onclick="return Reset1_onclick()" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

