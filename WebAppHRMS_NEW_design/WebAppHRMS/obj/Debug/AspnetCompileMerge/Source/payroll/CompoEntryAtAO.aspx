<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="CompoEntryAtAO.aspx.vb" Inherits="WebAppHRMS.CompoEntryAtAO_a8608d4f3984" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript" for="window" event="onload">return WindowOnload()</script>
<script type="text/javascript">
function btnExit_onclick()  {window.open('../home.aspx','_self'); }
</script>
    <div id="divTotal" style="text-align: center">
                    <div style="text-align: center">
            <table border="1" style="width: 80%; font-family: 'Book Antiqua'; ">
            <tr>
                <td colspan="4" style="background-color: #ffcc33; height: 30px;">
                <strong><span style="font-size: 12pt; color: #ff0000">COMPENSATORY LEAVE ENTRY</span></strong></td>
            </tr>
            
            <tr><td>
                <tr>
                    <td style="width: 50%">
                        Employee Code</td>
                    <td style="width: 50%; text-align: left;">
                        &nbsp;
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnCheckName" runat="server" Text="OK" Width="66px" /></td>
                </tr>
                <tr>
                    <td style="width: 50%; height: 28px;">
                        Employee Name</td>
                    <td style="width: 50%; text-align: left; height: 28px;">
                        &nbsp;
                        <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 50%">
                    </td>
                    <td style="width: 50%">
                    </td>
                </tr>
            </table>
        </div>
        <table id="rowDetails" border="1" style="width: 80%; font-family: 'Book Antiqua'; height: 231px;">
            <tr style="height=30px">
                <td colspan="2">
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                <td colspan="2" rowspan="2">
                    <strong>Pending Compensatory</strong> <strong>Leave Details</strong></td>
            </tr>
            <tr>
                <td style="width: 25%;font-size: 11pt;">
                    Applied On</td>
                <td style="width: 25%; text-align: left;">
                    <strong><span
                        style="font-size: 10pt; color: #f08080">
                        <asp:TextBox ID="txtAppliedDt" runat="server" Width="32%" ReadOnly="True"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 22px">
                </td>
                <td style="width: 25%; height: 22px; text-align: left">
                </td>
                <td style="width: 25%; height: 22px">
                    <span style="font-size: 11pt; font-family: Courier New">Compensatory count&nbsp;</span></td>
                <td style="width: 25%; height: 22px; text-align: left">
                    <asp:TextBox ID="txtCount" runat="server" Width="73px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 38px;font-size: 11pt;">
                    Compo off taken &nbsp;date</td>
                <td style="width: 25%; text-align: left; height: 38px;">
                    <strong><span
                        style="font-size: 10pt; color: lightcoral">
                        <asp:TextBox ID="txtFromDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
                <td style="width: 25%; height: 38px;">
                    <span style="font-size: 11pt; font-family: Courier New">Select Compensatory</span></td>
                <td style="width: 25%; text-align: left; height: 38px;">
                    <asp:DropDownList ID="cmd_comp_det" runat="server" 
                        Style="font-family: 'Courier New'" Width="314px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="Reas">
                <td style="width: 25%; height: 28px;">
                    Reason</td>
                <td colspan="3" style="text-align: left; height: 28px;">
                    <asp:TextBox ID="txtReason" runat="server" Width="437px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 20px">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                </td>
            </tr>
            <tr>
                <td id="colForMessage" colspan="4">
                </td>
            </tr>
        </table>
        <input id="hidTotalDays" runat="server" style="width: 11px" type="hidden" />
        <input id="hidSystemDate" runat="server" style="width: 11px" type="hidden" /><br />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDt" Format="dd/MMM/yyyy">
        </cc1:CalendarExtender>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 22%">
            <tr>
                <td style="width: 50%">
                    <asp:Button ID="btnConfirm" runat="server" Font-Size="Small" Text="CONFIRM" Width="81px" /></td>
                <td style="width: 50%">
                    <input id="btnExit" style="width: 88px; cursor: hand; font-family: 'Book Antiqua';
                        height: 26px" type="button" value="EXIT" onclick="return btnExit_onclick()"/></td>
            </tr>
        </table>        
    </div>
   <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="TextBox1">
    </cc1:CalendarExtender>--%>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
  <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="TextBox2">
    </cc1:CalendarExtender>--%>
    <asp:HiddenField ID="hid1" runat="server" />
    <input id="Hidden2" style="width: 40px" type="hidden" /><input id="Hidden9" style="width: 19px"
        type="hidden" /><input id="Hidden3" style="width: 28px" type="hidden" /><input id="Hidden4"
            style="width: 4px" type="hidden" /><input id="Hidden6" style="width: 26px" type="hidden" /><input
                id="Hidden1" style="width: 35px" type="hidden" runat="server" /><input id="Hidden5" style="width: 10px"
                    type="hidden" /><input id="Hidden7" style="width: 5px" type="hidden" /><input id="Hidden8"
                        style="width: 2px" type="hidden" /><input id="Hidden10" runat="server" style="width: 13px"
                            type="hidden" />
    <input id="hid_check" runat="server" type="hidden" />
</asp:Content>


