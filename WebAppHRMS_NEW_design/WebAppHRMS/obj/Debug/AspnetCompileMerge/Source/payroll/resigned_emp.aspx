<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="resigned_emp.aspx.vb" Inherits="WebAppHRMS.Resigned_Employees_resigned_emp_026f53408777" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt");

function cmd_exit_onclick() {
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
    var value1 = document.getElementById(cont[0]+"txt_from").value;
    var value2 = document.getElementById(cont[0]+"txt_to").value;
    
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
      document.getElementById(cont[0]+"txt_from").value=document.getElementById(cont[0]+"hdn_sysdate").value;
        document.getElementById(cont[0]+"txt_to").value=document.getElementById(cont[0]+"hdn_sysdate").value;
     return false;
    }
 }

// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdn_sysdate" runat="server" type="hidden" /><br />
    <div style="text-align: center">
        <table border="1" style="width: 338px; height: 61px">
            <tr>
                <td style="width: 155px; text-align: right">
                    Resigned From :
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_from" onblur="check_date('txt_from')" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 155px; text-align: right">
                    Resigned To :
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_to" onblur="check_date('txt_to')" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 155px; text-align: right">
                    <input id="cmd_exit" style="width: 82px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>
        <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_to"></cc1:calendarextender>
        <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_from"></cc1:calendarextender>
    </div>
</asp:Content>

