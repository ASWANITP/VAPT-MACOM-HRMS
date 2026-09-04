<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Sunday_conso.aspx.vb" Inherits="WebAppHRMS.SUNDAY_Sunday_conso_3632b2806425" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont = loanno.split('txt');
function cmdExit_onclick() 
{
   window.open('../home.aspx','_self');
}
function KeyUps(a)
{
   alert('Please Select Date Using Calendar..!!');
  document.getElementById(cont[0]+a).value = document.getElementById(cont[0]+"hidLeaveFrom").value;
   document.getElementById(cont[0]+a).focus();
   return false;
}
function KeyUps1(a)
{
   alert('Please Select Date Using Calendar..!!');
   document.getElementById(cont[0]+a).value = document.getElementById(cont[0]+"hidLeaveTo").value;
   document.getElementById(cont[0]+a).focus();
   return false;
}
//function EmpNameFind()
//{
//   if(document.getElementById(cont[0]+"txtEmpCode").value=="" || parseInt(document.getElementById(cont[0]+"txtEmpCode").value) < 9999)
//   {
//     alert('Please Enter a Valid Employee Code..!!');
//     document.getElementById(cont[0]+"txtEmpName").value = "";
//     document.getElementById(cont[0]+"hidEmpCode").value = 0;        
//     document.getElementById(cont[0]+"txtEmpCode").value = "";     
//     document.getElementById(cont[0]+"Label1").InnerHtml = ""; 
//     document.getElementById(cont[0]+"txtEmpCode").focus();
//     return false;
//   }       
//   else
//   {
//     document.getElementById(cont[0]+"hidEmpCode").value = document.getElementById(cont[0]+"txtEmpCode").value;
//     call_server("1$"+document.getElementById(cont[0]+"hidEmpCode").value);
//   } 
//}
//function EmpCodeKeyUp()
//{
//   document.getElementById(cont[0]+"txtEmpName").value = "";
//   document.getElementById(cont[0]+"hidEmpCode").value = 0;
//   var a = document.getElementById(cont[0]+"txtEmpCode").value;
//   if(isNaN(a)) 
//   {
//        alert('Please enter correct Employee Code in number Format!!');
//        document.getElementById(cont[0]+"txtEmpCode").value = "";
//        document.getElementById(cont[0]+"txtEmpCode").focus();
//        return false;
//   }
//}
function Fill_Dateto()
{
    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;       
    if((document.getElementById(cont[0]+"txtLeaveToDate").value !="") && (document.getElementById(cont[0]+"txtLeaveFrom").value != ""))
    {    
            value1 = document.getElementById(cont[0]+"txtLeaveFrom").value;
            value2 = document.getElementById(cont[0]+"txtLeaveToDate").value;
           
            day1= value1.substring (0, value1.indexOf ("/"));
            month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
            year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

            day2= value2.substring (0, value2.indexOf ("/"));
            month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
            year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);  
         
            date1 = year1+"/"+month1+"/"+day1;
            date2 = year2+"/"+month2+"/"+day2;
            //date3 = year3+"/"+month3+"/"+day3;
            
            firstDate = Date.parse(date1);
            secondDate= Date.parse(date2);
            //thirdDate = Date.parse(date3);            

            msPerDay = 24 * 60 * 60 * 1000;
            
            dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;            
            if(dbd<0)
            {
                alert("Wrong Entry..!! Your FromDate Greater than ToDate.. Please Change..!!")
                document.getElementById(cont[0]+"txtLeaveFrom").value   = document.getElementById(cont[0]+"hidLeaveFrom").value;
                document.getElementById(cont[0]+"txtLeaveToDate").value = document.getElementById(cont[0]+"hidLeaveTo").value;
                document.getElementById(cont[0]+"txtLeaveFrom").focus();
                return false;
            }
    }
}
//function ClientCheck()
//{
//   if((document.getElementById(cont[0]+"hidEmpCode").value == "")||(document.getElementById(cont[0]+"hidEmpCode").value == 0))
//   {
//      alert('Please Type EmployeeCode Whose Leave Report to get..!!');
//      document.getElementById(cont[0]+"txtEmpCode").focus();
//      return false;
//   }
//   if(document.getElementById(cont[0]+"txtLeaveFrom").value == "")
//   {
//      alert('Please Select Leave From Date..!!');
//      document.getElementById(cont[0]+"txtLeaveFrom").focus();
//      return false;
//   }
//   if(document.getElementById(cont[0]+"txtLeaveToDate").value == "")
//   {
//      alert('Please Select Leave To Date..!!');
//      document.getElementById(cont[0]+"txtLeaveToDate").focus();
//      return false;
//   }
//}
//function call_receiver(arg1)
//{
//  var arg2,dat;
//  arg2 = arg1.split("@");
//  if(arg2[0]==11)
//  {
//    document.getElementById(cont[0]+"Label1").InnerHtml = "";    
//    if(arg2[1]=="N")
//    {
//       alert('There is No Employee Exists..Please Check..!!');       
//       document.getElementById(cont[0]+"hidEmpCode").value     = 0;
//       document.getElementById(cont[0]+"txtEmpCode").value     = "";
//       document.getElementById(cont[0]+"txtEmpName").value     = "";
//       document.getElementById(cont[0]+"txtEmpCode").focus();      
//    }        
//    else
//    {       //em.emp_code||'*'||em.emp_name||'*'||dm.designation||'*'||dp.dep_name||'*'||bm.branch_name||'*'||pm.post_name||'*'||case
//       dat = arg2[1].split("*");       
//       document.getElementById(cont[0]+"txtEmpName").value     = dat[0];
//       if (dat[1] == "$")
//       {
//          alert('No Leave Found For This Employee in This Year..!!');
//          document.getElementById(cont[0]+"txtLeaveToDate").value = document.getElementById(cont[0]+"hidLeaveTo").value;          
//       } 
//       else
//       {
//          document.getElementById(cont[0]+"txtLeaveToDate").value = dat[1];
//       }                      
//    }  
//  }  
//}
function init()
{
   document.getElementById(cont[0]+"hidEmpCode").value = 0;   
   document.getElementById(cont[0]+"txtEmpCode").value = "";   
   document.getElementById(cont[0]+"txtEmpName").value = "";
   document.getElementById(cont[0]+"txtEmpCode").focus();
}
window.onload = init;
</script>
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 97%; font-family: 'Bookman Old Style'; height: 176px;">
            <tr>
                <td style="width: 100%">
                    <div style="text-align: center">
               
                        <table border="1" style="width: 63%; font-family: 'Bookman Old Style'; height: 72px;">
                             <tr>
                <td colspan="4" style="height: 30px">
                    <span style="font-family: Courier New">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#C00000" Text="SUNDAY LOP CANCELLATION REPORT " Height="15px" Width="672px"></asp:Label></span></td>
            </tr>
            <tr></tr>
            <tr></tr>
            <tr></tr>
                            <tr>
                                <td style="width: 25%; height: 7px; text-align: left">
                                    &nbsp;From Date</td>
                                <td style="width: 11%; height: 7px; text-align: center">
                                    <asp:TextBox ID="txtLeaveFrom" onkeyup="return KeyUps('txtLeaveFrom')" onchange="Fill_Dateto()" runat="server" Style="font-family: 'Bookman Old Style';
                                        text-align: center" Width="192px"></asp:TextBox></td>
                                <td style="width: 25%; height: 7px; text-align: left">
                                    &nbsp;To Date</td>
                                <td style="width: 25%; height: 7px; text-align: left">
                                    <asp:TextBox ID="txtLeaveToDate" onkeyup="return KeyUps1('txtLeaveToDate')" onchange="Fill_Dateto()" runat="server" Style="font-family: 'Bookman Old Style';
                                        text-align: center" Width="192px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 4px; text-align: center">
                                    <div style="text-align: center">
                                        <table style="width: 130px">
                                            <tr>
                                                <td style="width: 100px; text-align: right">
                                                    <asp:Button ID="cmdConfirm" OnClientClick="return ClientCheck()" runat="server" Style="cursor: hand; font-family: 'Bookman Old Style'"
                                                        Text="Confirm" Width="72px" /></td>
                                                <td style="width: 100px; text-align: left">
                                                    <input id="cmdExit" style="cursor: hand; font-family: 'Bookman Old Style'; width: 72px;" type="button"
                                                        value="Exit" onclick="return cmdExit_onclick()" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                                    </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Height="24px" Style="font-weight: bold; font-family: 'Bookman Old Style';
                        font-variant: small-caps" Width="820px"></asp:Label></td>
            </tr>
        </table>
    </div>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtLeaveFrom">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtLeaveToDate">
    </cc1:CalendarExtender>
    <input id="hidEmpCode" runat="server" style="width: 12px" type="hidden" />
    <input id="hidLeaveFrom" runat="server" style="width: 12px" type="hidden" />
    <input id="hidLeaveTo" runat="server" style="width: 12px" type="hidden" />
</asp:Content>

