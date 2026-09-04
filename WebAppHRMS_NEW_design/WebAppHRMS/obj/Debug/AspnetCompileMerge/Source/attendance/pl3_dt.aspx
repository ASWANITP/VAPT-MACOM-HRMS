<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pl3_dt.aspx.vb" Inherits="WebAppHRMS.payroll_pl3_dt_463bec5a8240" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=cont_name.split("txt")
function check_dt()
{
 alert("Select Date From Calender")
 return false;
}
function dt_check()
{
 var mydate=new Date()
var year=mydate.getYear()
if (year < 1000)
year+=1900
var day=mydate.getDay()
var month=mydate.getMonth()
var daym=mydate.getDate()
if (daym<10)
daym="0"+daym
 var montharray=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
 mydate=daym+"/"+montharray[month]+"/"+year
    var dbd
    var day3;
    var month3;
    var year3;

    value3 = document.getElementById(cont[0]+"txt_dt").value;
    day3= value3.substring (0, value3.indexOf ("/"));
    month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
    year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);

    var value4 = mydate;
    var day4 = value4.substring (0, value4.indexOf ("/"));
    var month4 = value4.substring (value4.indexOf ("/")+1, value4.lastIndexOf ("/"));
    var year4 =value4.substring (value4.lastIndexOf ("/")+1, value4.length);
 
    date3 = year3+"/"+month3+"/"+day3;
    date4 = year4+"/"+month4+"/"+day4;
    firstDate = Date.parse(date3)
    secondDate= Date.parse(date4)
    msPerDay = 24 * 60 * 60 * 1000
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    if(dbd<0)
    {
     alert("Future date Cannot be selected");
     return false; 
    }
     
 
}
function Button1_onclick() {
 window.open("../home.aspx",'_self')
}

</script>
    <table align="center" border="1">
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_dt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 169px">
                Enter Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_dt" runat="server" onkeypress="return check_dt()"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 169px; text-align: right">
                <asp:Button ID="cmd_gnrt" runat="server" Text="Generate"  OnClientClick="return dt_check()"/></td>
            <td style="width: 100px">
                &nbsp;<input id="Button1" style="width: 78px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
        </tr>
    </table>
</asp:Content>

