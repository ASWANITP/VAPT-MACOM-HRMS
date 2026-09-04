<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Present.aspx.vb" Inherits="WebAppHRMS.Attendence_Report_Present_080605c54795" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/control/DateFiller.ascx" TagName="datefiller" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
 function Got_home()
    {
        window.open('../home.aspx','_self')
    }
function cmd_exit_onclick() {
Got_home()
}
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
 </script>
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2" style="font-weight: bold; height: 20px">
                    CONSOLIDATED REPORT<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_frdate"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 79px">
                    From Date &nbsp;&nbsp;
                    <asp:TextBox ID="Txt_frdate" onkeypress="return van()" runat="server"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <table>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                <input id="cmd_exit" style="width: 61px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

