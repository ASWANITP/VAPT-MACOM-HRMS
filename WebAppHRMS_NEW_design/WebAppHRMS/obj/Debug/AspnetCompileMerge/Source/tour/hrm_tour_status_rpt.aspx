<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_tour_status_rpt.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_hrm_tour_status_rpt_61a2ec587861" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[

function EXIT_onclick() 
{
  window.open('../home.aspx','_self')
}
var cont = master_no.split("hid");

function LoginSession()

{
  if (document.getElementById(cont[0]+"hid_br").value==0)
  {
     document.getElementById("row1").style.display="inline"; 
     return true; 
  
  }
  else
  
 {
     document.getElementById("row1").style.display="none"; 
     return true; 
  
  }


}
function window_onload() 
{
 LoginSession();
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
//    if(dbd<0)
//    {
//     alert("Please Do Not Enter Future Date ..!!")
//     document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
//     document.getElementById(cont[0]+Control).focus();
//     return false;
//    }
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
        <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_fromdt"></cc1:calendarextender>
        <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txt_todt"></cc1:calendarextender>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 69%; height: 80px;">
         <tr><td colspan="4" style="height: 27px; text-align: center">
                                        <span style="font-size: 14pt">&nbsp;<strong>TOUR SANCTIONED REPORT</strong></span></td>
                                </tr>
            <tr id="row1" style="display:none">
                <td style="height: 11px;" colspan="2">
                    Employee code</td>
                <td style="height: 11px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_empid" runat="server" MaxLength="7" ReadOnly="True" Width="312px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 6%; height: 18px;">
                    &nbsp;&nbsp;From&nbsp;Date&nbsp;&nbsp;</td>
                <td style="width: 9%; text-align: left; height: 18px;">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Width="169px"></asp:TextBox></td>
                <td style="width: 6%; height: 18px;">
                    To&nbsp;Date</td>
                <td style="width: 10%; text-align: left; height: 18px;">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Width="177px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 14px">
                    <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="CONFIRM" />
                    &nbsp;<input id="EXIT" style="font-size: 12.5pt; width: 101px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return EXIT_onclick()" /></td>
            </tr>
        </table>
    </div>
    <input id="hid_br" runat="server" style="width: 5px" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
</asp:Content>

