<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_intimation_ceo.aspx.vb" Inherits="WebAppHRMS.Payroll_leave_intimation_leave_intimation_ceo_88b160c29851" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
</script>
   <div style="text-align: center">
        <table  border="1" style="margin:0px auto;" >
    <tr>
            <td colspan="4" style="height: 41px; text-align: center;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                        <strong><span style="text-decoration: underline">LEAVE INTIMATION REPORT</span></strong>
                        </span></span></span>
        <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_fromdt"></cc1:calendarextender>
        <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_todt"></cc1:calendarextender>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </tr>
       
      <%--  <table border="1" style="width: 42%; height: 48px;">--%>
            <tr>
                <td colspan="4" style="height: 4px">
                    SELECT&nbsp; DATE</td>
            </tr>
                
        <tr>
            <td colspan="4" style="height: 14px">
            </td>
        </tr>
            <tr>
                <td style="width: 6%; height: 4px;">
                    &nbsp;&nbsp;From&nbsp;Date&nbsp;&nbsp;</td>
                <td style="width: 9%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Width="169px"></asp:TextBox></td>
                <td style="width: 6%; height: 4px;">
                    To&nbsp;Date</td>
                <td style="width: 10%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Width="177px"></asp:TextBox></td>
            </tr>
                <tr>

             <asp:GridView ID="Griduser"  horizontalalign="Center" runat="server" >
             </asp:GridView></tr>
        <tr>
            <td colspan="4" style="height: 14px">
            </td>
        </tr>
            <tr>
                <td colspan="4" style="height: 14px">
                <center>
                    <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="GENERATE" />
                    &nbsp;<asp:Button ID="Exit_btn" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="EXIT" />
               <asp:Button ID="btnReport" runat="server" Font-Names="Times New Roman" Font-Size="Medium" Text="EXPORT" />&nbsp;
               </center>
                </td> 
            </tr>
        </table>
    </div>
    <input id="hid_br" runat="server" style="width: 5px" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
  
  
</asp:Content>

