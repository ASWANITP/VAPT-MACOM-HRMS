<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Induvidual_Photo.aspx.vb" Inherits="WebAppHRMS.HRM_Punching_Report_Induvidual_Photo_0e0b060f9152" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
    var con = header.split('txt');

    function cmd_exit_onclick()
    {

        window.open('../../home.aspx', '_self');
    }
function isNumeric()
{
     if (isNaN(document.getElementById(con[0]+"txtcode").value)) 
     {
        document.getElementById(con[0]+"txtcode").value="";
        return false; 
     }
}
// ]]>
</script>
    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 60%; position: relative">
                <caption>
                    <strong>INDIVIDUAL PHOTO PUNCHING REPORT</strong></caption>
                <tr>
                    <td style="width: 15%; height: 26px;">
                        <strong>Enter Emp Code</strong></td>
                    <td colspan="2" style="width: 15%">
                        
                            <asp:TextBox ID="txtcode" runat="server"  onkeyup="isNumeric()" Width="147px"></asp:TextBox>
                           
                    </td>
                    <td style="width: 15%; height: 26px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        <strong>From Date</strong></td>
                    <td style="width: 15%">
                        <asp:TextBox ID="txtfdt" runat="server" Style="left: -6px; position: relative;
                            top: 0px"></asp:TextBox></td>
                    <td style="width: 15%">
                        <strong>To Date</strong></td>
                    <td style="width: 15%">
                        <asp:TextBox ID="txttdt" runat="server" Style="position: relative"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="CONFIRM"
                            Width="104px" /></td>
                    <td colspan="2">
                        &nbsp;<input id="Submit1" onclick="cmd_exit_onclick()" style="left: -30px; width: 72px; position: relative" type="button"
                            value="EXIT" /></td>
                </tr>
            </table>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfdt" Format="dd/MMM/yyyy">
            </cc1:CalendarExtender>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttdt" Format="dd/MMM/yyyy">
            </cc1:CalendarExtender>
        </div>
    </div>
</asp:Content>

