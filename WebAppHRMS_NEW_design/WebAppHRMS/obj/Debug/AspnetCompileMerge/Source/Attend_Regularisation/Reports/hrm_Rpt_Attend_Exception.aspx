<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Rpt_Attend_Exception.aspx.vb" Inherits="WebAppHRMS.AnyTimePunching_New_Reports_hrm_Rpt_Attend_Exception_829a651c6771" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt");

function Button2_onclick() 
{
 window.open('../../home.aspx','_self')
}

function OnClickIndividual()
{
  if(document.getElementById(cont[0]+"rdb_Indiv_Late").checked==true)
    {
      document.getElementById("Individual").style.display="inline";
      return true;
    }
}



function OnClickAllLate()
{
  if(document.getElementById(cont[0]+"rdb_AllLate").checked==true)
    {
      document.getElementById("Individual").style.display="none";
      return false;
    }
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
function isNumberKey()
{   
 var charcode = (event.which) ? event.which : event.keyCode
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))
  {
    return false;
  } 
    else
     return true; 
     
}
// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 40%; height: 147px;">
            <tr>
                <td style="text-align: right;" colspan="2">
                    <asp:RadioButton ID="rdb_AllLate" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#C00000"
                        GroupName="a" Text="All Late" TextAlign="Left" Width="158px" /></td>
                <td style="text-align: left;" colspan="2">
                    <asp:RadioButton ID="rdb_Indiv_Late" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Size="Medium" ForeColor="#C00000" GroupName="a" Text="Individual Late" Width="147px" /></td>
            </tr>
            <tr id="Individual" style="display:none">
                <td style="text-align: right;" colspan="2">
                    <asp:RadioButton ID="rdb_Branch" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Size="Medium" ForeColor="#C00000" GroupName="b" Text="Branch" TextAlign="Left"
                        Width="158px" /></td>
                <td style="text-align: left;" colspan="2">
                    <asp:RadioButton ID="rdb_Code" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Size="Medium" ForeColor="#C00000" GroupName="b" Text="Employee Code" Width="147px" /></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    &nbsp;&nbsp;From&nbsp;Date&nbsp;&nbsp;</td>
                <td style="width: 10%">
                    <asp:TextBox ID="txt_fromdt" onblur="check_date('txt_fromdt')" runat="server" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
                <td style="width: 10%">
                    To&nbsp;Date</td>
                <td style="width: 10%">
                    <asp:TextBox ID="txt_todt" onblur="check_date('txt_todt')" runat="server" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    Count&nbsp;
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_count" onkeypress="return isNumberKey()" runat="server" Font-Names="Times New Roman" Font-Size="Medium" MaxLength="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                    <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="CONFIRM" Width="89px" Height="26px" /></td>
                <td style="width: 10%">
                    <input id="Button2" style="font-size: 12pt; width: 90px; font-family: 'Times New Roman'; height: 26px;"
                        type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                <td style="width: 10%">
                </td>
            </tr>
        </table>
    </div>
    <br />
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_fromdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_todt"></cc1:calendarextender>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdn_sysdate" runat="server" type="hidden" />
</asp:Content>

