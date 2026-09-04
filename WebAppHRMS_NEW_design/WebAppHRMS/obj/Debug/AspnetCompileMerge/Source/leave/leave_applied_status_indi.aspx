<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_applied_status_indi.aspx.vb" Inherits="WebAppHRMS.Leave_Module_leave_applied_status_indi_9d3dab947224" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("cmb");

function Button1_onclick() {
window.open('../home.aspx','_self');
}
//function checkconfirm()
//{
//    if(document.getElementById(cs[0]+"cmb_code").options.length==0)
//    {
//        alert('sorry, you havent applied for leave');
//        return false;
//    }
//}

function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cs[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!"); 
   document.getElementById(cs[0]+Control).value="";
   return false;
 }
}


 function check_date(Control)
   {
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(cs[0]+Control).value!="")
    {
    var value1 = document.getElementById(cs[0]+Control).value;
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
      document.getElementById(cs[0]+Control).value=document.getElementById(cs[0]+"hdn_sysdate").value;
      document.getElementById(cs[0]+Control).focus();
     return false;
    }
check_frmDt();
 }

} 

function check_frmDt()
{
    var value1 = document.getElementById(cs[0]+"txt_from").value;
    var value2 = document.getElementById(cs[0]+"txt_to").value;
    
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
      document.getElementById(cs[0]+"txt_from").value=document.getElementById(cs[0]+"hdn_sysdate").value;
        document.getElementById(cs[0]+"txt_to").value=document.getElementById(cs[0]+"hdn_sysdate").value;
     return false;
    }
 }

// ]]>
</script>

    <br />
    <div style="text-align: center">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 503px; height: 99px">
            <tr>
                <td style="width: 186px; text-align: right">
                    Employee Name :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_code" runat="server" Style="position: relative" Width="340px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 186px; text-align: right" rowspan="2">
                    Leave&nbsp; &nbsp;Apply Date
                </td>
                <td style="width: 16px; height: 33px; text-align: right;">
                    From :
                </td>
                <td style="width: 100px; height: 33px; text-align: left">
                    <asp:TextBox ID="txt_from" onblur="check_date('txt_from')" runat="server"></asp:TextBox>
                    &nbsp; &nbsp;<cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_from"></cc1:calendarextender>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 33px; text-align: right">
                    To :
                </td>
                <td style="width: 100px; height: 33px; text-align: left">
                    <asp:TextBox ID="txt_to" onblur="check_date('txt_to')" runat="server"></asp:TextBox>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="txt_to"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server"  Text="CONFIRM" Width="79px" /></td>
                                <td style="width: 100px">
                    
                                    <input id="Button1" style="width: 68px" type="button" value="EXIT" onclick="return Button1_onclick()" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
        </cc1:ListSearchExtender>
        <input id="hdn_sysdate" type="hidden" runat="server" />&nbsp;
   
    </div>
</asp:Content>

