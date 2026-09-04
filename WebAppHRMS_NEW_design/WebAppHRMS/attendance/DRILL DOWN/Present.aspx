<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Present.aspx.vb" Inherits="WebAppHRMS.Attendence_Report_Present_080605c54949" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../../datefiller.ascx" TagName="datefiller" TagPrefix="uc1" %>
<%@ Register Src="../../control/datefiller.ascx" TagName="datefiller" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
 <script language="javascript" type="text/javascript">
 var cont = master_no.split("txt");

 function Got_home()
    {
        window.open('../../home.aspx','_self')
    }
     function cmd_exit_onclick() {

Got_home()
}
function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cont[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");  
   document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
  }
}
 </script>
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2" style="font-weight: bold; text-align: center">
                    <span style="font-size: 14pt">SUMMARY REPORT</span></td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2">
                    <asp:DropDownList ID="CMB_CAT" runat="server" Width="160px">
                        <asp:ListItem Value="1">PRESENT</asp:ListItem>
                        <asp:ListItem Value="2">ABSENT</asp:ListItem>
                        <asp:ListItem Value="3">LATE</asp:ListItem>
                        <asp:ListItem Value="4">EARLY GOING</asp:ListItem>
                        <asp:ListItem Value="5">NON MARKING</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 5px">
                    <div style="text-align: center">
                        <table border="1">
                            <tr>
                                <td style="width: 100px">
                                    From Date</td>
                                <td style="width: 100px; text-align: left">
                                    <asp:TextBox ID="txt_fromdt" runat="server"></asp:TextBox></td>
                                <td style="width: 100px">
                                    To Date</td>
                                <td style="width: 100px; text-align: left">
                                    <asp:TextBox ID="txt_todt" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    &nbsp;
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <table>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" Width="78px" /></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                <input id="cmd_exit" style="width: 79px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_fromdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_todt"></cc1:calendarextender>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdn_sysdate" runat="server" type="hidden" />
</asp:Content>

