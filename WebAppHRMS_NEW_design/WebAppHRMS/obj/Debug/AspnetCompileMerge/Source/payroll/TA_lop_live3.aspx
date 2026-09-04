<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="TA_lop_live3.aspx.vb" Inherits="WebAppHRMS.TA_lop_live3_85ddf83d6894" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
//return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('txt');
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}

function change(a) 
{
//alert(document.getElementById(cont_name[0]+"txt_qual").value)
//var a=document.getElementById(txt[0]+"txt_qual").value;
//document.getElementById(txt[0]+"txt_qual").value=a.toUppercase();
var str=document.getElementById(cont_name[0]+a).value;
//alert(document.getElementById(cont_name[0]+a).value)
   if (isNaN(str))
   {
    document.getElementById(cont_name[0]+a).value="";
    document.getElementById(cont_name[0]+a).focus;
    return false;
   }

}
// ]]>
</script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="height: 23px; background-color: #ffcc66;">
                    <strong><span style="font-size: 14pt; color: #cc0033"> TA-LEAVE </span></strong></td>
            </tr>
            <tr>
                <td style="width: 158px">
                </td>
                <td style="width: 95px">
                    <asp:CheckBox ID="chk_reg" runat="server" Width="121px" Font-Bold="True" Text="PERMANANT" AutoPostBack="True" BackColor="Transparent" ForeColor="Blue" /></td>
                <td style="width: 159px; text-align: left;">
                    <asp:CheckBox ID="chk_out" runat="server" Width="113px" Font-Bold="True" Text="OUTSOURCE" AutoPostBack="True" BackColor="Transparent" ForeColor="Blue" /></td>
                <td style="width: 168px; text-align: left;">
                    <asp:CheckBox ID="chk_all" runat="server" Width="39px" Font-Bold="True" Text="ALL" AutoPostBack="True" BackColor="Transparent" ForeColor="Blue" /></td>
            </tr>
            <tr>
                <td style="width: 158px; height: 28px">
                    <strong>
                    FROM DATE</strong></td>
                <td style="width: 95px; height: 28px">
                    <asp:TextBox ID="txt_fdt"  onkeypress="return van()" runat="server"></asp:TextBox></td>
                <td style="width: 159px; height: 28px">
                    <strong>TO DATE</strong></td>
                <td style="width: 168px; height: 28px; text-align: left;">
                    <asp:TextBox ID="txt_tdt" onkeypress="return van()" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 158px; height: 46px;">
                </td>
                <td style="width: 95px; height: 46px;">
                    <cc1:calendarextender id="CalendarExtender1" runat="server" TargetControlID="txt_fdt" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
                <td style="width: 159px; height: 46px;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td style="width: 168px; height: 46px;">
                    <cc1:calendarextender id="CalendarExtender2" runat="server" TargetControlID="txt_tdt" Format="dd/MMM/yyyy"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 46px">
                    <strong>EMPLOYEE STATUS</strong></td>
                <td style="width: 95px; height: 46px">
                    <asp:DropDownList ID="cmb_status" runat="server" Width="208px" AutoPostBack="True">
                        <asp:ListItem Value="1">NORMAL</asp:ListItem>
                        <asp:ListItem Value="3">RESIGNED</asp:ListItem>
                        <asp:ListItem Value="88">REGULARIZED</asp:ListItem>
                        <asp:ListItem Value="4">SUSPENDED</asp:ListItem>
                        <asp:ListItem Value="5">TERMINATED</asp:ListItem>
                        <asp:ListItem Value="6">LONGLEAVE</asp:ListItem>
                        <asp:ListItem Value="10">MATERNITY</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 159px; height: 46px">
                    <asp:CheckBox ID="chk_leave" runat="server" AutoPostBack="True" Font-Bold="True"
                        ForeColor="Maroon" Text="ALL LEAVES" /></td>
                <td style="width: 168px; height: 46px">
                    <asp:CheckBox ID="chk_lleav" runat="server" AutoPostBack="True" Font-Bold="True"
                        ForeColor="Maroon" Text="LONGLEAVE" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <asp:Label ID="lbl" runat="server" Font-Bold="True" Text="ENTER THE LIMIT OF EMPLOYEE CODE "
                        Width="374px"></asp:Label></td>
                <td style="width: 159px; height: 23px; text-align: left;">
                    <asp:TextBox ID="txt_lf" onkeyup="return change('txt_lf')" runat="server" MaxLength="6"></asp:TextBox>&nbsp;
                </td>
                <td style="width: 168px; height: 23px; text-align: left;">
                    <strong></strong>
                    <asp:TextBox ID="txt_lt" onkeyup="return change('txt_lt')" runat="server" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 158px; height: 34px;">
                </td>
                <td style="width: 95px; height: 34px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="119px" Height="31px" /></td>
                <td style="width: 159px; height: 34px; text-align: center;">
                    <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="119px" Height="31px" /></td>
                <td style="width: 168px; height: 34px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

