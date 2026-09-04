<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_with_tfr_frm1_Jwell.aspx.vb" Inherits="WebAppHRMS.promotion_with_tfr_frm1_Jwell_3854a92e6928" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont =loanno.split('Txt');

 function Cmd_Click()
{
    if(document.getElementById(cont[0]+"Txt_empcode").value=="")
    {
    alert('Please Enter Correct Emp code...!!!');
    document.getElementById(cont[0]+"Txt_empcode").focus();
    return false;
    }

}

function Cmd_exit_onclick() 
{
window.open('../home.aspx','_self');
}


function EmpOnchange()
{
   var emp = document.getElementById(cont[0]+"Txt_empcode").value;
   if(emp!="")
   {
    ToServer("1!" + emp,1);
   }
 }  
function FromServer(Arg,Context)
{
if(Arg!="")
{
document.getElementById(cont[0]+"Txt_emp_dtl").value=Arg;
}
else
{
alert('Enter Correct Employee Code..!!');
document.getElementById(cont[0]+"Txt_empcode").value="";
document.getElementById(cont[0]+"Txt_emp_dtl").value="";
return false;
}
}

</script>
    <div style="text-align: center">
        <strong>
            </strong>
        <table border="1" style="border-left-color: #330066; border-bottom-color: #330066; border-top-color: #330066; border-right-color: #330066;" width="60%">
            <tr>
                <td colspan="2" style="height: 20px; text-align: left">
                    <strong><span style="color: #0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; EMPLOYEE PROMOTION AND TRANSFER</span></strong></td>
            </tr>
            <tr>
                <td style="width: 64%; height: 23px; text-align: left;">
                    <span style="font-size: 11pt">EnterEmployee Code</span></td>
                <td style="width: 20%; height: 23px; text-align: left; font-family: Times New Roman;">
                    <asp:TextBox ID="Txt_empcode" runat="server"
                        Width="102px" Font-Bold="False" MaxLength="6" Font-Names="Times New Roman" Font-Size="10pt"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="width: 64%; height: 23px; text-align: left">
                    <strong> </strong><span style="font-size: 11pt">
                        Emp Name,Dept
                        &amp; Post</span></td>
                <td style="width: 20%; height: 23px; text-align: left">
                    <asp:TextBox ID="Txt_emp_dtl" runat="server" Font-Bold="False" Width="272px" Font-Names="Times New Roman" Font-Size="10pt" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td style="height: 28px; text-align: left" colspan="2">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Cmd_Confirm" runat="server" Font-Bold="False" Font-Names="Times New Roman"
                        Height="34px" Text="CONFIRM" Width="80px" /><input id="Cmd_exit" style="font-weight: normal; width: 80px; font-family: 'Times New Roman';
                        height: 34px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td colspan="2" style="height: 28px; text-align: left">
                </td>
            </tr>
        </table>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType=Numbers TargetControlID="Txt_empcode">
    </cc1:FilteredTextBoxExtender>
</asp:Content>

