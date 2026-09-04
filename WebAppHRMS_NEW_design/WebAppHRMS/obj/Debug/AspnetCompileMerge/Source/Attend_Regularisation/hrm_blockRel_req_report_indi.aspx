<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_blockRel_req_report_indi.aspx.vb" Inherits="WebAppHRMS.Block_Release_Request_hrm_blockRel_req_report_indi_66fa57f65075" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');
function DateFCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtFDate").value = "";
   return false;
}
function DateTCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtTDate").value = "";
   return false;
}
function checkFdate(Control)
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(con[0]+Control).value!="")
    {
        var value1 = document.getElementById(con[0]+Control).value;
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
            document.getElementById(con[0]+Control).value='';
            document.getElementById(con[0]+Control).focus();
            return false;
        }
   }
} 
function checkTdate(Control)
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(con[0]+Control).value!="")
    {
        var value1 = document.getElementById(con[0]+Control).value;
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
            document.getElementById(con[0]+Control).value='';
            document.getElementById(con[0]+Control).focus();
            return false;
        }
        check_frmDt();
   }
} 
function check_frmDt()
{
    var value1 = document.getElementById(con[0]+"txtFdate").value;
    var value2 = document.getElementById(con[0]+"txtTdate").value;
    
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
      document.getElementById(con[0]+"txtFdate").value=' ';
        document.getElementById(con[0]+"txtTdate").value=' ';
     return false;
    }
}
function OnConfClick()
{
   
    if(document.getElementById(con[0]+"txtFdate").value=="")
    {
        alert("Please Select From Date...!");
        document.getElementById(con[0]+"txtFdate").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtTdate").value=="")
    {
        alert("Please Select To Date...!");
        document.getElementById(con[0]+"txttdate").focus();
        return false;
    }
}
function btnExit_onclick() 
{
    window.open("../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtFdate">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtTdate">
        </cc1:CalendarExtender>
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">
                    Employee Code</td>
                <td colspan="2">
                    <asp:TextBox ID="txtcode" runat="server" onblur="checkTdate('txtTdate')" onkeyup="DateTCheck()"
                        Style="position: relative" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    From Date</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtFdate" runat="server" Width="97%" onkeyup="DateFCheck()" onblur="checkFdate('txtFdate')"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">
                    To Date</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtTdate" runat="server" Width="98%" onkeyup="DateTCheck()" onblur="checkTdate('txtTdate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

