<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="date_select_report.aspx.vb" Inherits="WebAppHRMS.gold_coin_date_select_report_e12261828014" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split('txt');
function Button2_onclick() {
window.open("../../home.aspx","_self");

}
function check(a)
{

alert("Select Date From Below");
document.getElementById(cont[0]+a).value="";
return false;


}
function btn_check()
{
if(document.getElementById(cont[0]+"txt_from_dt").value=="")
{
alert("Select From Date");
return false;
}
if(document.getElementById(cont[0]+"txt_to_dt").value=="")
{
alert("Select To Date");
return false;
}
}


// ]]>
</script>
    <div style="text-align: center">
        <div style="text-align: center">
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="1">
                <tr>
                    <td colspan="2" style="font-family: 'Courier New'">
                        </td>
                </tr>
                <tr>
                    <td style="width: 200px; font-family: 'Courier New';">
                        FROM</td>
                    <td style="width: 200px; font-family: 'Courier New';">
                        TO</td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:TextBox ID="txt_from_dt" runat="server" onkeyup="check('txt_from_dt')" style="font-family: 'Courier New'"></asp:TextBox></td>
                    <td style="width: 200px">
                        <asp:TextBox ID="txt_to_dt" runat="server" onkeyup="check('txt_to_dt')" style="font-family: 'Courier New'"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 200px" align="right">
                        <asp:Button ID="Button1" runat="server" Text="GENERATE" OnclientClick="return btn_check()" style="font-family: 'Courier New'" /></td>
                    <td style="width: 200px" align="left">
                        <input id="Button2" style="width: 110px; font-family: 'Courier New';" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                </tr>
            </table>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                TargetControlID="txt_from_dt">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                TargetControlID="txt_to_dt">
            </cc1:CalendarExtender>
        </div>
    </div>
</asp:Content>

