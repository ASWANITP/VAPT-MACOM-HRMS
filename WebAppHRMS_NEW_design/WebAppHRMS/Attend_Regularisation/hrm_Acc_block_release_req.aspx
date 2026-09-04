<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Acc_block_release_req.aspx.vb" EnableEventValidation="false" Inherits="WebAppHRMS.Block_Release_For_Accounts_hrm_Acc_block_release_req_c94a88221945" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

    var con = header.split('txt');


function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value = "";
   return false;
}
function check_date(Control)
{   //alert('a');
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
        else
        {
           callserver("1$"+document.getElementById(con[0]+"txtDate").value,1);
        }        
    }
} 
function call_receiver(arg,context) 
{  
   
  switch (context)
  {
    case 1:
    {   
        var dist = arg.split("@"); 
        document.getElementById(con[0]+"ddlBlock").options.length=0;
        if (dist[0]=="") { alert("No Details ..!!!"); return false; }
          ComboFill(dist[0],"ddlBlock"); 
        break;
    }
  }
}
function ComboFill(Data,ComboName)
{
       if (Data[0] == '') return;
       
       var rows = Data.split("*");
       for(a=0; a<rows.length; a++)
   {
      var cols      = rows[a].split("$");
      var option1   = document.createElement("OPTION");
      option1.value = cols[0];
      option1.text  = cols[1];
      document.getElementById(con[0]+ComboName).add(option1);
   }
  
}
function ddlOnchange()
{
    document.getElementById(con[0]+"hdnBlock").value=document.getElementById(con[0]+"ddlBlock").value;
}
function OnlettCaps(a)
{
   var lett = document.getElementById(con[0]+a).value;
   document.getElementById(con[0]+a).value = lett.toUpperCase();
} 
 
function btnExit_onclick() 
{
    window.open("../Home.aspx","_self");
}
function onConfclick()
{
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Select Date...!!!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
    if(document.getElementById(con[0]+"ddlBlock").value==-1)
    {
        alert("Please Select Block...!!!");
        document.getElementById(con[0]+"ddlBlock").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtReason").value=="")
    {
        alert("Please Enter Reason...!!!");
        document.getElementById(con[0]+"txtReason").focus();
        return false;
    }
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDate">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="hdnBlock" runat="server" />
        <table border="1" style="width: 70%">
            <tr>
                <td style="width: 25%; text-align: left;">
                    <strong>
                    Select Date For Request</strong></td>
                <td style="width: 25%; text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="70%" onkeyup="return DateCheck()" onchange="check_date('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left;">
                    <strong>
                    Select Block</strong></td>
                <td style="width: 25%; text-align: left;">
                    <asp:DropDownList ID="ddlBlock" runat="server" Width="99%" onchange="ddlOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left;">
                    <strong>
                    Release Reason</strong></td>
                <td style="width: 25%; text-align: left;">
                    <asp:TextBox ID="txtReason" runat="server" Width="98%" onkeyup="OnlettCaps('txtReason')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnconfirm" runat="server" Text="CONFIRM" OnClientClick="return onConfclick()" />
                    <input id="btnExit" type="button" value="EXIT" style="width: 88px; height: 24px" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 25%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

