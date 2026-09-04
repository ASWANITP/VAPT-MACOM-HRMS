<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_profile_select.aspx.vb" Inherits="WebAppHRMS.raj_emp_profile_select_6a4269eb9606" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont = loanno.split('txt');
function cmdExit_onclick() 
{
   window.open('../home.aspx','_self');
}
function OnConfirmCheck()
{  
   if(document.getElementById(cont[0]+"txtEmpCode").value=="" || document.getElementById(cont[0]+"txtEmpCode").value<10001)
   {
      alert('Please Enter Valid Employee Code..!!');
      document.getElementById(cont[0]+"txtEmpCode").value     = "";
      document.getElementById(cont[0]+"txtEmpName").value     = "";
      document.getElementById(cont[0]+"txtEmpCode").focus();
      return false;   
   }     
}
function EmpCodeKeyUp()
{     
   var a = document.getElementById(cont[0]+"txtEmpCode").value;
   if(isNaN(a)) 
   {
        alert('Please enter correct Employee Code in number Format!!');
        document.getElementById(cont[0]+"txtEmpCode").value = "";
        document.getElementById(cont[0]+"txtEmpName").value = "";
        document.getElementById(cont[0]+"txtEmpCode").focus();
        return false;
   }
}
function EmpCodeFind()
{
debugger;
   if(document.getElementById(cont[0]+"txtEmpCode").value=="" || parseInt(document.getElementById(cont[0]+"txtEmpCode").value) < 10001)
   {
      alert('Please Enter a Valid Employee Code..!!');       
      document.getElementById(cont[0]+"txtEmpCode").value = "";  
      document.getElementById(cont[0]+"txtEmpName").value = "";    
      document.getElementById(cont[0]+"txtEmpCode").focus();
      return false;
   }       
   else
   {     
      call_server("1$"+document.getElementById(cont[0]+"txtEmpCode").value);
   } 
}
function call_receiver(arg1)
{
  var arg2,dat;
  arg2 = arg1.split("@");
  if(arg2[0]==11)
  {     
    if(arg2[1]=="N")
    {
       alert('There is No Employee Exists in This Code..!! Please Check..!!');        
       document.getElementById(cont[0]+"txtEmpCode").value     = "";
       document.getElementById(cont[0]+"txtEmpName").value = "";         
       document.getElementById(cont[0]+"txtEmpCode").focus();
    }
    else
    {
       document.getElementById(cont[0]+"txtEmpName").value = arg2[1]; 
    }     
  }  
}
function init()
{     
   document.getElementById(cont[0]+"txtEmpCode").value     = "";
   document.getElementById(cont[0]+"txtEmpName").value     = "";
   document.getElementById(cont[0]+"txtEmpCode").focus();
}
window.onload = init;
</script>

    <div style="text-align: center">
        <br />
        <table border="1" style="width: 80%; font-family: 'Bookman Old Style'; font-variant: small-caps;">
            <tr>
                <td style="width: 21%; text-align: left;">
                    Enter Employee Code</td>
                <td style="width: 14%; text-align: left;">
                    <asp:TextBox ID="txtEmpCode" onkeyup="EmpCodeKeyUp()" onchange="EmpCodeFind()" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: center" MaxLength="6"></asp:TextBox></td>
                <td style="width: 17%; text-align: left;">
                    Employee Name</td>
                <td style="width: 20%; text-align: left;">
                    <asp:TextBox ID="txtEmpName" runat="server" Style="font-family: 'Bookman Old Style'"
                        Width="200px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:Button ID="cmdConfirm" OnClientClick="return OnConfirmCheck()" runat="server" Style="cursor: hand; font-family: 'Bookman Old Style'"
                        Text="Confirm" /></td>
                <td colspan="2" style="text-align: left">
                    <input id="cmdExit" style="cursor: hand; font-family: 'Bookman Old Style'; width: 81px;" type="button"
                        value="Exit" onclick="return cmdExit_onclick()" /></td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

