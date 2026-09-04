<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="Individual.aspx.vb" Inherits="WebAppHRMS.Attendence_Report_Present_080605c52897" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/control/DateFiller.ascx" TagName="DateFiller" TagPrefix="uc3" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
 
function cmd_exit_onclick() 
{
   window.open('../../home.aspx','_self');
}
function correct(a,e) 
{

        document.getElementById("ctl00_cph_edp_"+a).value=""
        document.getElementById("ctl00_cph_edp_"+a).focus()
              
}
function CheckOnClientClick()
{
   if(document.getElementById("ctl00_cph_edp_"+"rd_ecode").checked==true)
   {
      if(document.getElementById("ctl00_cph_edp_"+"txt_empcode").value=="")
      {
         alert('Please Enter Employee Code..!!');
         document.getElementById("ctl00_cph_edp_"+"txt_empcode").focus();
         return false;
      }
   }
}
 </script>
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1">
            <tr>
                <td colspan="2" style="font-weight: bold; text-align: center; height: 23px;">
                    DETAILED REPORT</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:DropDownList ID="CMB_CAT" runat="server" Width="160px" AutoPostBack="True">
                        <asp:ListItem Value="1">PRESENT</asp:ListItem>
                        <asp:ListItem Value="2">ABSENT</asp:ListItem>
                        <asp:ListItem Value="3">LATE</asp:ListItem>
                        <asp:ListItem Value="4">EARLY GOING</asp:ListItem>
                        <asp:ListItem Value="5">NON MARKING</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: center; height: 99px;">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:RadioButton id="rd_ecode" runat="server" Width="160px" Text="EMPLOYEE CODE" AutoPostBack="True" GroupName="cat"></asp:RadioButton></TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_empcode" runat="server" MaxLength="5"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="rd_branch" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
                <td colspan="1" style="text-align: center; height: 99px;">
                    <asp:UpdatePanel id="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
<TABLE><TR><TD style="WIDTH: 100px"><asp:RadioButton id="rd_branch" runat="server" Width="120px" Text="BRANCH" GroupName="cat" AutoPostBack="True"></asp:RadioButton></TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_branch" runat="server" Width="270px" AutoPostBack="True"></asp:DropDownList></TD></TR></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="rd_ecode" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="1" style="height: 29px; text-align: center">
                    Select Department</td>
                <td colspan="1" style="height: 29px; text-align: center">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 79px">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    FROM DATE</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="Txt_fdate" runat="server" onkeyup="return correct('Txt_fdate',event)"></asp:TextBox></td>
                                <td style="width: 100px">
                                    TO DATE</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="Txt_tdate" runat="server" onkeyup="return correct('Txt_tdate',event)"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_fdate"></cc1:calendarextender>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_tdate"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <table>
                        <tr>
                            <td style="width: 100px; height: 26px;">
                            </td>
                            <td style="width: 100px; height: 26px;">
                                <asp:Button ID="cmd_confirm" OnClientClick="return CheckOnClientClick()" runat="server" Text="Confirm" /></td>
                            <td style="width: 100px; height: 26px;">
                            </td>
                            <td style="width: 100px; height: 26px;">
                                <input id="cmd_exit" style="width: 73px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
                            <td style="width: 100px; height: 26px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

