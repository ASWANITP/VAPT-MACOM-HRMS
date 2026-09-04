<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="salary_empcode_select.aspx.vb" Inherits="WebAppHRMS.salary_individual_salary_empcode_select_1fd2a2151281" title="Salary Statement Individual" %>
<%@ MasterType VirtualPath ="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('Txt');
function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}
function okeyup()
{
 var st;
 st=document.getElementById(cont_name[0]+"Txt_EmpCode").value;
 if (isNaN(st))
 {
  alert('Please Enter a Valid Employee Code!!');
  document.getElementById(cont_name[0]+"Txt_EmpCode").value="";
  document.getElementById(cont_name[0]+"Txt_EmpCode").focus();
  return false;
 }
}
function cliclick()
{
 if(document.getElementById(cont_name[0]+"Txt_EmpCode").value=="")
 {
  alert('Please Enter Your Employee Code Here!!');
  document.getElementById(cont_name[0]+"Txt_EmpCode").focus();
  return false;
 }
}
function init()
{
 document.getElementById(cont_name[0]+"Txt_EmpCode").focus();
}
window.onload=init;
// ]]>
</script>

    <div style="text-align: center">
        <br />
        <br />
        <table border="1">
            <tr>
                <td style="width: 217px; text-align: left;">
                    <strong>
                    Enter Your Employee Code:</strong></td>
                <td style="width: 100px; text-align: left;">
                    <asp:TextBox ID="Txt_EmpCode" onkeyup="okeyup()" ondrag="return false;" ondrop="return false;" runat="server" Width="115px" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; height: 53px;">
                    <div style="text-align: center">
                        <table style="width: 114px">
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <input id="Cmd_Exit" type="button" value="EXIT" style="width: 88px" onclick="return Cmd_Exit_onclick()" tabindex="1" /></td>
                                <td style="width: 100px; text-align: left">
                                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" TabIndex="2" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

