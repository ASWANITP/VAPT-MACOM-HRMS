<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="hrm_block_release_req_HO.aspx.vb" Inherits="WebAppHRMS.Block_Release_Request_hrm_block_release_request_a3860c5e9779" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');
function window_onload() 
{
   document.getElementById("rowPanel").style.display='none'; 
   document.getElementById(con[0]+"hdnAdd").value="";
   document.getElementById(con[0]+"hdnAddCheck").value="";
   document.getElementById(con[0]+"hdnAddId").value="";
}
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
           document.getElementById("rowPanel").style.display='none'; 
           document.getElementById(con[0]+"hdnAdd").value="";
           document.getElementById(con[0]+"hdnAddCheck").value="";
           document.getElementById(con[0]+"hdnAddId").value=""; 
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
function OnlettCaps(a)
{
   var lett = document.getElementById(con[0]+a).value;
   document.getElementById(con[0]+a).value = lett.toUpperCase();
}  
function btnAdd_onclick() 
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
    if(document.getElementById(con[0]+"hdnAdd").value !="")   
    {
       var blk=document.getElementById(con[0]+"ddlBlock").options[document.getElementById(con[0]+"ddlBlock").selectedIndex].text;
       document.getElementById(con[0]+"hdnAddCheck").value=document.getElementById(con[0]+"hdnAdd").value+"!"+document.getElementById(con[0]+"ddlBlock").options[document.getElementById(con[0]+"ddlBlock").selectedIndex].text+"#"+document.getElementById(con[0]+"txtreason").value;
       var data = document.getElementById(con[0]+"hdnAddCheck").value;
       var rows = data.split("!");
       for(i=0;i<=rows.length-2;i++)
       {
          cols = rows[i].split("#");
          if(cols[0]==blk)
          {
             alert('Already Added..!');
             document.getElementById(con[0]+"ddlBlock").value=-1;
             document.getElementById(con[0]+"txtReason").value="";
             return false;
          }
       }
    }
    document.getElementById(con[0]+"hdnAdd").value=document.getElementById(con[0]+"hdnAdd").value+"!"+document.getElementById(con[0]+"ddlBlock").options[document.getElementById(con[0]+"ddlBlock").selectedIndex].text+"#"+document.getElementById(con[0]+"txtreason").value;
    document.getElementById(con[0]+"hdnAddId").value=document.getElementById(con[0]+"hdnAddId").value+"!"+document.getElementById(con[0]+"ddlBlock").value+"#"+document.getElementById(con[0]+"txtReason").value;
    showDetailsExp();
    
}
function showDetailsExp()
{
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1><tr></tr>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Block Reason</td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>Avoid reason</td>";
    tmptab  =tmptab+"<td width=4% align=right style= 'font-size: 10pt;'>Delete</td></tr>";
    
    var rowSplitarr =document.getElementById(con[0]+"hdnAdd").value.split("!");
    var colSplitarr;
    var row_bg1     = 0;  
    var m,j,cnt,TotalPrice,TotalWarranty;
    m=0;j=0;cnt=0;TotalPrice=0;TotalWarranty=0;
    for (m=1;m<rowSplitarr.length;m++)
    {	
        if (row_bg1 == 0)
        {
         row_bg1 = 1;
         tmptab += "<tr style='background-color:OldLace'>";
        }
        else
        {
         row_bg1 = 0;  
         tmptab += "<tr style='background-color:Wheat'>";             
        }
        colSplitarr     =   rowSplitarr[m].split("#");
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[0] + "</td>"  ;
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>"  ;
        tmptab          =   tmptab +"<td width=4% align=right style= 'font-size: 10pt;'><a href=javascript:delf("+m+")>Del</a></td></tr>";
    }
    if (row_bg1 == 0)
            tmptab += "<tr style='background-color:OldLace'>";
    else
            tmptab += "<tr style='background-color:Wheat'>"; 
    tmptab          =   tmptab+"</table>";
    document.getElementById(con[0]+"Panel1").innerHTML=tmptab;
     document.getElementById("rowPanel").style.display='inline';
    document.getElementById(con[0]+"ddlBlock").value=-1;
    document.getElementById(con[0]+"txtReason").value="";
}

function delf(m)
{
    var j=m-1,k
    var new_tran=""
    var new_tran1=""
    var arr=document.getElementById(con[0]+"hdnAdd").value.split("!")
    for(k=1;k<=j;k++)
    {
        new_tran=new_tran+"!"+ arr[k]
    }
    for(k=j+2;k<arr.length;k++)
    {
        new_tran=new_tran+"!"+arr[k]
    }
    document.getElementById(con[0]+"hdnAdd").value=new_tran
    showDetailsExp();
}
function OnConfClick()
{
    if(document.getElementById(con[0]+"hdnAddId").value=="")
    {
        alert("Please Add Values...!!!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Add Values...!!!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
    


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
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDate">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="hdnAddId" runat="server" />
        <asp:HiddenField ID="hdnAddCheck" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">
                    Select Date For Request</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="70%" onkeyup="return DateCheck()" onchange="check_date('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Punching Block</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlBlock" runat="server" Width="97%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Release Reason</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="95%" onkeyup="OnlettCaps('txtReason')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btnAdd" style="width: 88px; height: 24px" type="button" value="ADD" onclick="return btnAdd_onclick()" /></td>
            </tr>
            <tr id="rowPanel">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return OnConfClick()" Text="CONFIRM" />
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

