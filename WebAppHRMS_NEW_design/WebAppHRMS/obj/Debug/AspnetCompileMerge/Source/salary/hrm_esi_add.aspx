<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_esi_add.aspx.vb" Inherits="WebAppHRMS.ESI_hrm_esi_add_4adc98564126" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value = "";
   return false;
}
function check_date(Control)
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
function ConClintClick()
{
    if(document.getElementById(con[0]+"txtEsiNo").value=="")
    {
        alert("Please Enter ESI Number...!");
        document.getElementById(con[0]+"txtEsiNo").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEsiBranch").value=="")
    {
        alert("Please Enter ESI Branch....!");
        document.getElementById(con[0]+"txtEsiBranch").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDesp").value=="")
    {
        alert("Please Enter ESI Dispensary....!");
        document.getElementById(con[0]+"txtDesp").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Enter Date of Entry...!!!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
//    if(document.getElementById(con[0]+"FileUpload1").value=="")
//    {
//        alert("Please Upload ESI Card...!!!");
//        document.getElementById(con[0]+"FileUpload1").focus();
//        return false;
//    }
}
function btnExit_onclick() 
{
  window.open("../Home.aspx","_self");  
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
            targetcontrolid="txtDate"></cc1:calendarextender>
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <table border="1" style="width: 50%">
            <tr>
                <td style="width: 25%; height: 23px; text-align: left;">
                    Name of Employee</td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtEcode" runat="server" Width="90%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px; text-align: left;">
                    Insurance Number</td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtEsiNo" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px; text-align: left;">
                    ESI
                    Branch Office</td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtEsiBranch" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px; text-align: left;">
                    Dispensary</td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtDesp" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px; text-align: left">
                    Date Of&nbsp; Entry(Card Issue Date)</td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="90%" onkeyup="return DateCheck()" onchange="check_date('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px; text-align: left">
                    Upload
                    ESI Card
                </td>
                <td style="width: 25%; height: 23px; text-align: left">
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConClintClick()" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 25%; height: 23px">
                </td>
                <td style="width: 25%; height: 23px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

