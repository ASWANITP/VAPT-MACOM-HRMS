<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Present.aspx.vb" Inherits="WebAppHRMS.Attendence_Report_Present_080605c55145"   EnableEventValidation="false"  title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/control/DateFiller.ascx" TagName="datefiller" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">

 function Got_home()
    {
        window.open('../../home.aspx','_self')
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
                <td colspan="4" style="height: 22px; text-align: center">
                    <strong>PUNCHING REPORT &nbsp; </strong>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 19px; text-align: left">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE border=1><TBODY><TR><TD style="WIDTH: 272px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=2><asp:RadioButton id="Rdb_con" runat="server" Width="273px" Text="CONSOLIDATED REPORT" Font-Bold="True" AutoPostBack="True" Checked="True"></asp:RadioButton></TD><TD style="WIDTH: 90px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=1>&nbsp; &nbsp;<asp:Label id="lbl1" runat="server" Width="76px" Text="From Date" ForeColor="#0000C0"></asp:Label></TD><TD style="WIDTH: 112px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=1><asp:TextBox id="Txt_frdate" onkeypress="return van()" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 272px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=2><asp:RadioButton id="Rdb_sht" runat="server" Width="255px" Text="BH/ABH SHORT REPORT" Font-Bold="True" AutoPostBack="True"></asp:RadioButton></TD><TD style="WIDTH: 90px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=1>&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 112px; HEIGHT: 22px; TEXT-ALIGN: left" colSpan=1><cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="Txt_frdate" format="dd/MMM/yyyy"></cc1:calendarextender>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; text-align: center">
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

