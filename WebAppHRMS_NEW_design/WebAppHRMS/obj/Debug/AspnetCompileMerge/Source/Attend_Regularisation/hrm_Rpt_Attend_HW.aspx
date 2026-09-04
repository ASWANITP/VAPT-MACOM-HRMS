<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Rpt_Attend_HW.aspx.vb" Inherits="WebAppHRMS.Attend_Regularisation_No_Date_check__Attend_Regularisation_hrm_Rpt_Attend_HW_5d62251a6581" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
 window.open('../home.aspx','_self')
}
var cont = master_no.split("txt")
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

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 42%; height: 56px;">
            <tr>
                <td style="width: 10%">
                    From Date</td>
                <td style="width: 10%">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
                <td style="width: 10%">
                    To Date</td>
                <td style="width: 10%">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 28px;" colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" style="font-size: 12pt; font-family: 'Times New Roman'" Height="26px" Width="90px" />&nbsp;
                    <input id="Button2" style="width: 86px; font-size: 12pt; font-family: 'Times New Roman'; height: 26px;" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
            </tr>
        </table>
    </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_fromdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_todt"></cc1:calendarextender>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdn_sysdate" runat="server" type="hidden" />
</asp:Content>

