<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Movement Report.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_Movement_Report_b422ee418693" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
//return window_onload()
// ]]>
    </script>

    <script language="javascript" type="text/javascript">
// <!CDATA[

function EXIT_onclick() 
{
  window.open('../../home.aspx','_self')    
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
//function window_onload() 
//{
// LoginSession();
//}
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
        <table border="1" style="margin: 0px auto;">
            <tr>
                <td colspan="4" style="height: 41px; text-align: center;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">USER STATUS REPORT</span></strong>
                        </span></span></span>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="txt_fromdt"></cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="txt_todt"></cc1:CalendarExtender>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
            </tr>

            <%--  <table border="1" style="width: 42%; height: 48px;">--%>
            <tr>
                <td colspan="4" style="height: 4px">SELECT&nbsp; DATE</td>
            </tr>

            <tr>
                <td colspan="4" style="height: 14px"></td>
            </tr>
            <tr>
                <td style="width: 6%; height: 4px;">&nbsp;&nbsp;From&nbsp;Date&nbsp;&nbsp;</td>
                <td style="width: 9%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Width="169px"></asp:TextBox></td>
                <td style="width: 6%; height: 4px;">To&nbsp;Date</td>
                <td style="width: 10%; text-align: left; height: 4px;">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Width="177px"></asp:TextBox></td>
            </tr>
            <tr>

                <asp:GridView ID="Griduser" HorizontalAlign="Center" runat="server">
                </asp:GridView>
            </tr>
            <tr>
                <td colspan="4" style="height: 14px"></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 14px">
                    <center>
                        <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                            Text="CONFIRM" />
                        &nbsp;<asp:Button ID="Exit_btn" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                            Text="EXIT" />
                        <asp:Button ID="btnReport" runat="server" Font-Names="Times New Roman" Font-Size="Medium" Text="EXPORT" />&nbsp;
                    </center>
                </td>
            </tr>
        </table>
    </div>
    <input id="hid_br" runat="server" style="width: 5px" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
</asp:Content>



