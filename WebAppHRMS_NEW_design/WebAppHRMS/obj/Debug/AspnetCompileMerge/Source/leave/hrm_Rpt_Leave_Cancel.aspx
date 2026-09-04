<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Rpt_Leave_Cancel.aspx.vb" Inherits="WebAppHRMS.new_leave_hrm_Rpt_Leave_Cancel_d1b03d506623" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath ="~/edp.master"  %>
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
    //debugger;
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
   if (firstDate<=1269369000000)
      {
      alert("Can Not Select From Date Less Than 24/March/2010 !!!");
      document.getElementById(cont[0]+Control).value="";
      return false;
      }
    else
    
    {
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

    <div style="text-align: center">
        <table border="1" style="width: 34%; height: 49px;">
            <tr>
                <td style="width: 10%">
                    From&nbsp;Date</td>
                <td style="width: 10%; text-align: left;">
                    <asp:TextBox ID="txt_From" onchange="check_date('txt_From')"  runat="server"></asp:TextBox></td>
                <td style="width: 10%">
                    To&nbsp;Date</td>
                <td style="width: 10%; text-align: left;">
                    <asp:TextBox ID="txt_To"  onchange="check_date('txt_To')"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Style="font-weight: bold; font-size: 12pt; color: #990033; font-family: 'Times New Roman'"
                        Text="CONFIRM" Width="91px" />&nbsp;
                    <input id="Button2" style="font-weight: bold; font-size: 12pt; width: 91px; color: #990033;
                        font-family: 'Times New Roman'" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_From"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_To"></cc1:calendarextender>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
</asp:Content>

