<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="atterepo.aspx.vb" Inherits="WebAppHRMS.specificempattend_atterepo_099614a58770" title="Untitled Page" %>

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
        <table border="1" style="width: 731px; height: 217px">
            <tr>
                <td colspan="4">
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager><strong style="background-color: #ffcc33"><span style="font-size: 14pt">BRANCH VISIT REPORT OF A SPECIFIED EMPLOYEE</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 11px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 42px">
                    <strong>&nbsp;EMPLOYEE CODE</strong></td>
                <td colspan="2" style="height: 42px; text-align: left">
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="225px" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 39px">
                    FROM DATE</td>
                <td style="width: 100px; height: 39px">
                    <asp:TextBox ID="TextBox2" runat="server" onkeyup="return correct('TextBox2',event)"></asp:TextBox>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="TextBox2" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
                <td style="width: 136px; height: 39px">
                    TO DATE</td>
                <td style="width: 123px; height: 39px">
                    &nbsp;<asp:TextBox ID="TextBox3" runat="server" onkeyup="return correct('TextBox3',event)"></asp:TextBox>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="TextBox3" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 44px">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="121px" /></td>
                <td colspan="2" style="height: 44px">
                    &nbsp;<asp:Button ID="Button2" runat="server" Text="EXIT" Width="133px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

