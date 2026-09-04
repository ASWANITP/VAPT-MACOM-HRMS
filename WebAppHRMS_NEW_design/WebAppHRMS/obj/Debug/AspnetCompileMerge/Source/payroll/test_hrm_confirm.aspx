<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="test_hrm_confirm.aspx.vb" Inherits="WebAppHRMS.test_hrm_confirmation_test_hrm_confirm_450a4f9d2771" title="TA & Others:HRM Confirmation" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split('Txt');

function confirmation() 
{
	var answer = confirm("This Allowance/Incentive is Completely Entered For This Month.Are You Sure?")
	if (answer){
		alert('Thank You!');
		}
	else{
		alert('Ok..You Can Check Another Or Go back !');
		return false;
	    }
}


function Cmd_Exit_onclick() 
{
window.open('../home.aspx','_self');
}
function get_final_total()
{
call_server(document.getElementById(cont[0]+"Cmb_Item").value)
}
function call_receiver(arg1)
{
document.getElementById(cont[0]+"Txt_ItemTotal").value=arg1;
}
function init()
{
 get_final_total();
}

window.onload=init;
// ]]>
</script>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1">
            <tr>
                <td style="width: 119px; text-align: left">
                    <strong>
                    Select Item:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="Cmb_Item" runat="server" Width="222px" style="cursor: hand">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 119px; height: 23px; text-align: left">
                    <strong>
                    Final Total:</strong></td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:TextBox ID="Txt_ItemTotal" runat="server" BackColor="Honeydew" Width="111px" ReadOnly="True" style="cursor: text" TabIndex="1" ToolTip="Final Total for this month!!"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="1" style="width: 222px; height: 22px">
            <tr>
                <td style="width: 59px; text-align: left">
                    <input id="Cmd_Exit" type="button" value="EXIT" style="width: 64px; cursor: hand;" onclick="return Cmd_Exit_onclick()" tabindex="2" /></td>
                <td style="width: 84px; text-align: left">
                    <asp:Button ID="Cmd_Confirm" OnClientClick="return confirmation()" runat="server" Text="CONFIRM" style="cursor: hand; color: black;" TabIndex="3" ToolTip="Click if final total Tally for this item!!" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:Button ID="Cmd_Report" runat="server" Text="REPORT" Width="73px" style="cursor: hand" TabIndex="4" ToolTip="Click for Itemwise Report Before CONFIRM!!" /></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

