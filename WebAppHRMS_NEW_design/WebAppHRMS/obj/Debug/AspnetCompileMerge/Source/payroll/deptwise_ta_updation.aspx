<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="deptwise_ta_updation.aspx.vb" Inherits="WebAppHRMS.TA_Updation_deptwise_ta_updation_9b8162a53815" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('Txt');

function Cmd_Exit_onclick() {
window.open('../home.aspx','_self');
}

function checknumber(t)
{
  var a=document.getElementById(cont_name[0]+t).value;
  if(isNaN(a)) 
  {
    alert('pls enter correct value in number format!!');
    document.getElementById(cont_name[0]+t).value="";
    document.getElementById(cont_name[0]+t).focus;
    return false;
   }
}

function cliclick()
{
 if(document.getElementById(cont_name[0]+"Txt_Value").value=="")
 {
  alert('Please Enter correct Value!!');
  document.getElementById(cont_name[0]+"Txt_Value").focus();
  return false;
 }
}
 
 function init()
 {
  document.getElementById(cont_name[0]+"Txt_Value").value="";
 }
 window.onload = init;

// ]]>
</script>

    <br />
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td style="width: 204px; text-align: left">
                        <strong>
                        Select Employee:</strong></td>
                    <td style="width: 100px; text-align: left">
                        <asp:DropDownList ID="Cmb_Employee" runat="server" Width="228px" style="cursor: hand">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 204px; text-align: left">
                        <strong>
                        Select Item to Update/Insert:</strong></td>
                    <td style="width: 100px; text-align: left">
                        <asp:DropDownList ID="Cmb_Item" runat="server" Width="228px" TabIndex="1" style="cursor: hand">
                            <asp:ListItem Value="0">FIXED TA</asp:ListItem>
                            <asp:ListItem Value="1">ACTUAL TA</asp:ListItem>
                            <asp:ListItem Value="2">OUTSTATION</asp:ListItem>
                            <asp:ListItem Value="3">A.B.H TA</asp:ListItem>
                            <asp:ListItem Value="4">B.H ALLOWANCE</asp:ListItem>
                            <asp:ListItem Value="5">B.H TA</asp:ListItem>
                            <asp:ListItem Value="6">INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="7">TELE. ALLOWANCE</asp:ListItem>
                            <asp:ListItem Value="8">DIST.  ALLOWANCE</asp:ListItem>
                            <asp:ListItem Value="9">H.P TA</asp:ListItem>
                            <asp:ListItem Value="10">H.P INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="11">INS. INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="12">FOREX INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="13">GLR INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="14">DEP MOB</asp:ListItem>
                            <asp:ListItem Value="15">BOND INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="16">BUSINESS LOAN</asp:ListItem>
                            <asp:ListItem Value="17">PERSONAL LOAN</asp:ListItem>
                            <asp:ListItem Value="18">GOLD G.A</asp:ListItem>
                            <asp:ListItem Value="19">MANAGER INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="20">MONTHLY INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="21">DEPOSIT MARKETING</asp:ListItem>
                            <asp:ListItem Value="22">LEGAL INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="23">CIVIL INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="24">CHITS INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="25">OTHER INCENTIVE</asp:ListItem>
                            <asp:ListItem Value="26">SUMMER INCENTIVE</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 204px; text-align: left">
                        <strong>
                        Insert Value:</strong></td>
                    <td style="width: 100px; text-align: left">
                        <asp:TextBox ID="Txt_Value" onkeyup="return checknumber('Txt_Value')" runat="server" Width="103px" MaxLength="7" TabIndex="2"></asp:TextBox></td>
                </tr>
            </table>
            <div style="text-align: center">
                <table border="1">
                    <tr>
                        <td style="width: 100px">
                        <input id="Cmd_Exit" style="width: 97px; cursor: hand;" type="button" value="<= EXIT" onclick="return Cmd_Exit_onclick()" tabindex="3" /></td>
                        <td style="width: 100px">
                        <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="97px" TabIndex="4" ToolTip="To insert or update an item for this Employee !!" style="cursor: hand" /></td>
                        <td style="width: 100px; text-align: left">
                            <asp:Button ID="Cmd_Report" runat="server" Text="REPORT" Width="97px" TabIndex="5" ToolTip="Shows itemwise Report !!" style="cursor: hand" /></td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <cc1:listsearchextender id="ListSearch_Employee" runat="server" targetcontrolid="Cmb_Employee"></cc1:listsearchextender>
            <br />
            <br />
        </div>
    </div>
</asp:Content>

