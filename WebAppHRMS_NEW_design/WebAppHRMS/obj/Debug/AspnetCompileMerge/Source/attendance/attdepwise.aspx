<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="attdepwise.aspx.vb" Inherits="WebAppHRMS.attendance_departmenrwise_attdepwise_d24e39db4573" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="../control/DateFiller.ascx" TagName="DateFiller" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
 function Got_home()
    {
        window.open('../home.aspx','_self')
    }
function cmd_exit_onclick() {
Got_home()
}
function correct(a,e) 
{

        document.getElementById("ctl00_cph_edp_"+a).value=""
        document.getElementById("ctl00_cph_edp_"+a).focus()
              
}
 </script>
    &nbsp; &nbsp;&nbsp;
    <div style="text-align: center">
        <table style="width: 678px; height: 357px">
            <tr>
                <td style="width: 100px; height: 315px">
    <table border="1" style="width: 600px; position: static; background-color: #ffcc99; text-align: center;">
        <tr>
            <td colspan="4" style="height: 30px">
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager><strong><span style="font-size: 14pt; color: #ff0033"></span></strong></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 30px">
                <strong><span style="font-size: 14pt; color: #cc0033">DEPARTMENT WISE ATTENDANCE REPORT</span></strong></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 123px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server" RenderMode="Inline">
                    <contenttemplate>
<TABLE style="WIDTH: 593px" border=1><TBODY><TR><TD colSpan=2><STRONG>SELECT DEPARTMENT</STRONG></TD><TD style="WIDTH: 316px; TEXT-ALIGN: left" colSpan=2><asp:DropDownList id="cmb_dep" runat="server" Width="285px" AutoPostBack="True" EnableTheming="True"></asp:DropDownList></TD></TR></TBODY></TABLE><cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmb_dep"></cc1:ListSearchExtender> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="cmb_dep" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="Txt_fdt">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="Txt_tdt">
                </cc1:CalendarExtender>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 323px; height: 28px">
                <strong>FROM DATE</strong></td>
            <td style="width: 127px; height: 28px; text-align: center">
                <asp:TextBox ID="Txt_fdt" runat="server" Width="150px" onkeyup="return correct('Txt_fdt',event)"></asp:TextBox></td>
            <td style="width: 72px; height: 28px; text-align: center">
                <strong>TO DATE</strong></td>
            <td style="width: 153px; height: 28px">
                <asp:TextBox ID="Txt_tdt" runat="server" Width="142px" onkeyup="return correct('Txt_tdt',event)"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 323px; height: 27px">
            </td>
            <td style="width: 127px; height: 27px; text-align: center">
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
            <td style="width: 72px; height: 27px; text-align: center">
                <input id="cmd_exit" style="width: 79px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
            <td style="width: 153px; height: 27px">
            </td>
        </tr>
    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

