<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="newReportAO.aspx.vb" Inherits="WebAppHRMS.test_newReportAO_7c32dcbd9719" title="Punching Report Selection" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
    var cont = header.split("txt");

function cmdExit_onclick() 
{
   window.open('../../home.aspx','_self');
}
function CheckBranchClick()
{
   if(document.getElementById(cont[0]+"checkBranch").checked==true)
   {
      document.getElementById(cont[0]+"cmbBranch").value      = 0;
      document.getElementById(cont[0]+"cmbBranch").disabled   = true;
      document.getElementById(cont[0]+"hidBranch").value      = 100000;    
   }
   if(document.getElementById(cont[0]+"checkBranch").checked==false)
   {      
      document.getElementById(cont[0]+"cmbBranch").disabled   = false;
      document.getElementById(cont[0]+"cmbBranch").value      = 0;
      document.getElementById(cont[0]+"hidBranch").value      = 0; 
   }
}
function CmbBranchChange()
{
   document.getElementById(cont[0]+"hidBranch").value = document.getElementById(cont[0]+"cmbBranch").value;
}
function FuncKeyUps(a)
{
   alert('Please Select Date Using Calendar..!!');
   document.getElementById(cont[0]+a).value = document.getElementById(cont[0]+"hidToday").value;
   document.getElementById(cont[0]+a).focus();
   return false;
}
function Fill_Dateto()
{
    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;    
    if((document.getElementById(cont[0]+"txtFromDate").value !="") && (document.getElementById(cont[0]+"txtToDate").value != ""))
    {    
        value1 = document.getElementById(cont[0]+"txtFromDate").value;
        value2 = document.getElementById(cont[0]+"txtToDate").value;
       
        day1= value1.substring (0, value1.indexOf ("/"));
        month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
        year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

        day2= value2.substring (0, value2.indexOf ("/"));
        month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
        year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);
        
        day3 = value3.substring (0, value3.indexOf ("/"));
        month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
        year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);
     
        date1 = year1+"/"+month1+"/"+day1;
        date2 = year2+"/"+month2+"/"+day2;
        date3 = year3+"/"+month3+"/"+day3;
        
        firstDate = Date.parse(date1);
        secondDate= Date.parse(date2);
        thirdDate = Date.parse(date3);

        msPerDay = 24 * 60 * 60 * 1000;
        
        dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
        dbd1 = Math.round((thirdDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
        dbd2 = Math.round((thirdDate.valueOf()-secondDate.valueOf())/ msPerDay);
        if(dbd<0)
        {
            alert("Wrong Entry..!! Your FromDate Greater than ToDate.. Please Change..!!");
            document.getElementById(cont[0]+"txtFromDate").value  = document.getElementById(cont[0]+"hidToday").value;
            document.getElementById(cont[0]+"txtToDate").value    = document.getElementById(cont[0]+"hidToday").value;
            document.getElementById(cont[0]+"txtFromDate").focus();
            return false;
        }
        if (dbd1<0 || dbd2<0)
        {
           alert('Please Do not enter Future Date..!!');
           if(dbd1<0)
           {
             document.getElementById(cont[0]+"txtFromDate").value=document.getElementById(cont[0]+"hidToday").value;
             document.getElementById(cont[0]+"txtFromDate").focus();
             return false;
           }
           else if (dbd2<0)
           {
             document.getElementById(cont[0]+"txtToDate").value=document.getElementById(cont[0]+"hidToday").value;
             document.getElementById(cont[0]+"txtToDate").focus();
             return false;
           }
        }
    }
}
function init()
{
   document.getElementById(cont[0]+"cmbBranch").disabled   = false;
   document.getElementById(cont[0]+"checkBranch").checked  = false;
   document.getElementById(cont[0]+"cmbBranch").value      = 0;
   document.getElementById(cont[0]+"hidBranch").value      = 0;
   document.getElementById(cont[0]+"txtFromDate").value    = document.getElementById(cont[0]+"hidToday").value;
   document.getElementById(cont[0]+"txtToDate").value      = document.getElementById(cont[0]+"hidToday").value;
}
window.onload=init;
</script>

    
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 80%; font-family: 'Courier New'; font-variant: small-caps;">
            <tr>
                <td style="width: 20%; text-align: left; height: 8px;">
                    &nbsp;Select Branch</td>
                <td style="text-align: left; height: 8px;" colspan="2">
                    <asp:DropDownList ID="cmbBranch" onchange="CmbBranchChange()" runat="server" Style="cursor: hand; font-family: 'Courier New'"
                        Width="99%">
                    </asp:DropDownList></td>
                <td style="width: 20%; text-align: left; height: 8px;">
                    <asp:CheckBox ID="checkBranch" onclick="CheckBranchClick()" runat="server" Style="cursor: hand; font-family: 'Courier New'"
                        Text=" All Branches" Width="138px" /></td>
            </tr>
            <tr>
                <td style="width: 20%; text-align: left">
                    &nbsp;From Date</td>
                <td style="width: 20%; text-align: left">
                    <asp:TextBox ID="txtFromDate" onkeyup="return FuncKeyUps('txtFromDate')" onchange="Fill_Dateto()" runat="server" Style="cursor: hand; font-family: 'Courier New';
                        text-align: center" Width="96%"></asp:TextBox></td>
                <td style="width: 20%; text-align: center">
                    &nbsp;To Date</td>
                <td style="width: 20%; text-align: left">
                    <asp:TextBox ID="txtToDate" onkeyup="return FuncKeyUps('txtToDate')" onchange="Fill_Dateto()" runat="server" Style="cursor: hand; font-family: 'Courier New';
                        text-align: center" Width="96%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 22px; text-align: right">
                    <asp:Button ID="cmdConfirm" runat="server" Style="cursor: hand; font-family: 'Courier New'"
                        Text="Confirm" /></td>
                <td colspan="2" style="height: 22px; text-align: left">
                    <input id="cmdExit" style="cursor: hand; font-family: 'Courier New'; width: 84px;" type="button"
                        value="Exit" onclick="return cmdExit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtFromDate"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtToDate"></cc1:calendarextender>
    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmbBranch">
    </cc1:ListSearchExtender>
    <input id="hidToday" runat="server" style="width: 12px" type="hidden" />
    <input id="hidBranch" runat="server" style="width: 12px" type="hidden" />
</asp:Content>

