<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="departmentwise_pl3.aspx.vb" Inherits="WebAppHRMS.departmentwise_pl3_departmentwise_pl3_eef0465d6360" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../control/DateFiller.ascx" TagName="DateFiller" TagPrefix="uc1" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt");
function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cont[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");  
   document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
  }
}
// ]]>
</script>

    <br />
    <br />
    <br />
    <div style="text-align: center">
    <asp:Panel ID="Panel1" runat="server" Height="500px" BorderColor="Transparent" BorderStyle="None" HorizontalAlign="Center">
        
            <div style="text-align: center">
                <table border="1" style="width: 576px; height: 209px; border-right: #ff0066 thin solid; border-top: #ff0066 thin solid; border-left: #ff0066 thin solid; border-bottom: #ff0066 thin solid;" id="TABLE1">
                    <tr>
                        <td colspan="4" style="font-weight: bold; text-align: center">
                            <span style="font-size: 14pt">DEPARTMENTWISE PL3</span></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 270px;">
                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Select Department :&nbsp; &nbsp;</td>
                        <td colspan="2" style="text-align: left; width: 271px;">
                            <asp:DropDownList ID="cmb_dpt" runat="server" Width="262px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 23px">
                            <div style="text-align: center">
                                <table border="1">
                                    <tr>
                                        <td style="width: 100px">
                                            From Date</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txt_fromdt" runat="server"></asp:TextBox></td>
                                        <td style="width: 100px">
                                            To Date</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txt_todt" runat="server"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                            &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 270px; height: 28px;" colspan="2">
                            &nbsp; &nbsp;
                        </td>
                        <td style="height: 28px; text-align: center; width: 271px;" colspan="2">
                            <asp:Button ID="cmd_confirm" runat="server" Height="24px" Text="REPORT" Width="81px" Font-Bold="True" ForeColor="Black" />
                            &nbsp;&nbsp;
                            <input id="cmd_exit" style="font-weight: bold; width: 81px" type="button" value="EXIT" onclick="return cmd_exit_onclick()"  /></td>
                    </tr>
                </table>
            </div>
       
    </asp:Panel>
        &nbsp; &nbsp;&nbsp;
    
     </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_fromdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_todt"></cc1:calendarextender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdn_sysdate" type="hidden" runat="server" /><br />
</asp:Content>

