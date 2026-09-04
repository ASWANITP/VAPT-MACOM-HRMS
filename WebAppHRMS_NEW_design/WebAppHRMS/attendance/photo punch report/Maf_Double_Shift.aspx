<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Maf_Double_Shift.aspx.vb" Inherits="WebAppHRMS.maf_22e172ab7320" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
    var cont = loanno.split('txt');

function cmdExit_onclick() 
{
   window.open('../home.aspx','_self');
}
function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cont[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");  
   document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
  }
}
 function check_date(Control)
   {
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(cont[0]+Control).value!="")
    {
    var value1 = document.getElementById(cont[0]+Control).value;
    var dt = new Date().format("dd/MMM/yyyy");
    var value2=dt;
    
    day1= value1.substring (0, value1.indexOf ("/"));
    month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
    year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

    day2= value2.substring (0, value2.indexOf ("/"));
    month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
    year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);

    date1 = year1+"/"+month1+"/"+day1;
    date2 = year2+"/"+month2+"/"+day2;
    
    firstDate = Date.parse(date1)
    secondDate= Date.parse(date2)
   
    msPerDay = 24 * 60 * 60 * 1000
    
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    if(dbd<0)
    {
     alert("Please Do Not Enter Future Date ..!!")
     document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
     document.getElementById(cont[0]+Control).focus();
     return false;
    }
check_frmDt();
 }

} 

function check_frmDt()
{
    var value1 = document.getElementById(cont[0]+"txt_fromdt").value;
    var value2 = document.getElementById(cont[0]+"txt_todt").value;
    
    day1= value1.substring (0, value1.indexOf ("/"));
    month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
    year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

    day2= value2.substring (0, value2.indexOf ("/"));
    month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
    year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);

    date1 = year1+"/"+month1+"/"+day1;
    date2 = year2+"/"+month2+"/"+day2;
    
    firstDate = Date.parse(date1)
    secondDate= Date.parse(date2)
    msPerDay = 24 * 60 * 60 * 1000
    
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    if(dbd<0)
    {
      alert("Can not Select- From Date Greater than- To Date")
      document.getElementById(cont[0]+"txt_fromdt").value=document.getElementById(cont[0]+"hdn_sysdate").value;
      document.getElementById(cont[0]+"txt_todt").value=document.getElementById(cont[0]+"hdn_sysdate").value;
      return false;
    }
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
        <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_fromdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_todt"></cc1:calendarextender>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager></div>

    <div style="text-align: center">
        <br />
        <table border="1" style="width: 80%; font-family: 'Bookman Old Style'; font-variant: small-caps;">
            <tr>
                <td style="width: 21%; text-align: left;">
                    Enter Employee Code</td>
                <td style="width: 14%; text-align: left;">
                    <asp:TextBox ID="txtEmpCode" onkeyup="EmpCodeKeyUp()" onchange="EmpCodeFind()" runat="server" Width="200px" Style="font-family: 'Bookman Old Style';
                        text-align: center" MaxLength="6"></asp:TextBox></td>
                <td style="width: 17%; text-align: left;">
                    Employee Name</td>
                <td style="width: 20%; text-align: left;">
                    <asp:TextBox ID="txtEmpName" runat="server" Style="font-family: 'Bookman Old Style'"
                        Width="200px" ReadOnly="True"></asp:TextBox></td>
            </tr>
                          
        <tr>
            <td colspan="4" style="height: 14px">
            </td>
        </tr>
            <tr>
                <td style="width: 21%; text-align: left;height: 4px;">
                    &nbsp;Select&nbsp;From&nbsp;Date&nbsp;&nbsp;</td>
                <td style="width: 14%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Width="200px"></asp:TextBox></td>
                <td style="width: 6%; text-align: left;height: 4px;">
                    &nbsp;Select &nbsp;To&nbsp;Date</td>
                <td style="width: 10%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Width="200px"></asp:TextBox></td>
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
      <input id="hid_br" runat="server" style="width: 5px" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
</asp:Content>

