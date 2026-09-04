<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="hrm_TFR_APP_tostore.aspx.vb" Inherits="WebAppHRMS.hrm_hrm_TFR_APP_tostore_e546f7998521" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<%--<script runat="server" >

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        End Sub
</script>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split('txt');

function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(cont_name[0]+"txtDate").value = "";
   return false;
}

function check_date(Control)
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(cont_name[0]+Control).value!="")
    {
        var value1 = document.getElementById(cont_name[0]+Control).value;
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
            document.getElementById(cont_name[0]+Control).value='';
            document.getElementById(cont_name[0]+Control).focus();
            return false;
        }
        else
        {
           callserver("1$"+document.getElementById(cont_name[0]+Control).value,1);  
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
        document.getElementById(cont_name[0]+"ddlEcode").options.length=0;
        if (dist[0]=="")
         {  alert("No Details ..!!!");
           return false; 
         }
          ComboFill(dist[0],"ddlEcode"); 
        break;
    }
    case 2:
    {
         var accdtl = arg.split("*");    
         if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(cont_name[0]+"txtEname").value = "";
            document.getElementById(cont_name[0]+"txtBranch").value = "";
            document.getElementById(cont_name[0]+"txtPost").value = "";  
            document.getElementById(cont_name[0]+"txtStatus").value = "";  
    
            return false;
         }
         else
         {
            var stat;
            document.getElementById(cont_name[0]+"txtEname").value = accdtl[0];
            document.getElementById(cont_name[0]+"txtBranch").value = accdtl[1];
            document.getElementById(cont_name[0]+"txtPost").value = accdtl[2];
            if(accdtl[3]==1)
            {
                stat="Live";
            }
            else
            {
                stat="Resigned";
            }
            document.getElementById(cont_name[0]+"txtStatus").value = stat; 
 
         }    
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
      document.getElementById(cont_name[0]+ComboName).add(option1);
   }
}
function ClassChange()
{
     document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlEcode").value;
 
     if(document.getElementById(cont_name[0]+"Hidden1").value==-1)
     {
         document.getElementById(cont_name[0]+"txtEname").value = "";
         document.getElementById(cont_name[0]+"txtBranch").value = "";
         document.getElementById(cont_name[0]+"txtPost").value = "";  
         document.getElementById(cont_name[0]+"txtStatus").value = "";
 
         return false; 
    }
    else
    {
        callserver("2$"+document.getElementById(cont_name[0]+"Hidden1").value,2);  
    }
}

function typchang()
{
document.getElementById(cont_name[0]+"Hdn").value=document.getElementById(cont_name[0]+"ddl1").value;
}
function rdClick()
{
   var sta;
   sta=document.getElementById(cont_name[0]+"txtStatus").value;
   var branch;
   branch=document.getElementById(cont_name[0]+"txtBranch").value;
   if(sta=="Resigned")
   {
       alert("Employee is Resigned Please Hold At H.O"); 
       document.getElementById(cont_name[0]+"rdstore").checked=false;
       return false;
   } 
   else if(branch=="A.O.VALAPAD")
   {
       alert("Employee Branch is H.O Please Hold At H.O"); 
       document.getElementById(cont_name[0]+"rdstore").checked=false;
       return false;
   }
}
function btnAdd_onclick() 
{
    var ecode=document.getElementById(cont_name[0]+"ddlEcode").value;
    
    if(document.getElementById(cont_name[0]+"txtDate").value=="")
    {
        alert('Please Enter Date..!!'); 
        document.getElementById(cont_name[0]+"txtDate").focus(); 
        return false;
    }
    if(document.getElementById(cont_name[0]+"ddlEcode").value==-1)
    {
        alert('Please Select Employee..!!');
        document.getElementById(cont_name[0]+"ddlEcode").focus(); 
        return false;
    }
    if(document.getElementById(cont_name[0]+"txtEname").value=="")
    {
        alert('Please Select Employee..!!');
        document.getElementById(cont_name[0]+"ddlEcode").focus(); 
        return false;
    }
    var send;
    if(document.getElementById(cont_name[0]+"rdstore").checked == true)
    {
        send="Send To Mail Dept";
    }
    if(document.getElementById(cont_name[0]+"Hidden2").value !="")
    {
       
       document.getElementById(cont_name[0]+"Hidden3").value=document.getElementById(cont_name[0]+"Hidden2").value+"!"+document.getElementById(cont_name[0]+"txtDate").value+"#"+document.getElementById(cont_name[0]+"ddlEcode").value+"#"+document.getElementById(cont_name[0]+"txtEname").value+"#"+document.getElementById(cont_name[0]+"txtBranch").value+"#"+document.getElementById(cont_name[0]+"txtPost").value+"#"+document.getElementById(cont_name[0]+"txtStatus").value+"#"+send;
       var data = document.getElementById(cont_name[0]+"Hidden3").value;
       var rows = data.split("!");

       for(i=0;i<=rows.length-2;i++)
       {
          cols = rows[i].split("#");
          if(cols[1]==ecode)
          {
             alert('Already Added..!');
             document.getElementById(cont_name[0]+"ddlEcode").value = -1;
             document.getElementById(cont_name[0]+"txtEname").value = "";
             document.getElementById(cont_name[0]+"txtBranch").value = "";
             document.getElementById(cont_name[0]+"txtPost").value = "";
             document.getElementById(cont_name[0]+"txtStatus").value = "";
             return false;
          }
          
       }
     }
     document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"Hidden2").value+"!"+document.getElementById(cont_name[0]+"txtDate").value+"#"+document.getElementById(cont_name[0]+"ddlEcode").value+"#"+document.getElementById(cont_name[0]+"txtEname").value+"#"+document.getElementById(cont_name[0]+"txtBranch").value+"#"+document.getElementById(cont_name[0]+"txtPost").value+"#"+document.getElementById(cont_name[0]+"txtStatus").value+"#"+send;
     showDetails();
     document.getElementById(cont_name[0]+"ddlEcode").value = -1;
     document.getElementById(cont_name[0]+"txtEname").value = "";
     document.getElementById(cont_name[0]+"txtBranch").value = "";
     document.getElementById(cont_name[0]+"txtPost").value = "";
     document.getElementById(cont_name[0]+"txtStatus").value = "";
}
function showDetails()
{
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1><tr></tr>";
    tmptab  =tmptab+"<tr style='background-color:Wheat'><td width=15% align=left style= 'font-size: 10pt;'><b>DATE</b></td>";
     tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b>EMP CODE</b></td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b>EMP NAME</b></td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b>   BRANCH     </b> </td>";
    tmptab  =tmptab+"<td width=15% align=left style= 'font-size: 10pt;'><b>POST</b></td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b> STATUS</b></td>";
     tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b>TRANSFER / APPOINTMENT</b></td>";
    tmptab  =tmptab+"<td width=5% align=right style= 'font-size: 10pt;'><b>DELETE</b></td></tr>";
    
    var rowSplitarr =document.getElementById(cont_name[0]+"Hidden2").value.split("!");
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
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[0] + "</td>"  ;
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[2] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[3] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[4] + "</td>"  ;
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[5] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[6] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=right style= 'font-size: 10pt;'><a href=javascript:delf("+m+")>Del</a></td></tr>";
    }
    if (row_bg1 == 0)
            tmptab += "<tr style='background-color:OldLace'>";
    else
            tmptab += "<tr style='background-color:Wheat'>"; 
    tmptab          =   tmptab+"</table>";
    document.getElementById(cont_name[0]+"Panel1").innerHTML=tmptab;
    document.getElementById("row1").style.display="inline";
}

function delf(m)
{
    var j=m-1,k
    var new_tran=""
    var new_tran1=""
    var arr=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
    for(k=1;k<=j;k++)
    {
        new_tran=new_tran+"!"+ arr[k]
    }
    for(k=j+2;k<arr.length;k++)
    {
        new_tran=new_tran+"!"+arr[k]
    }
    document.getElementById(cont_name[0]+"Hidden2").value=new_tran
    showDetails();
}
function btnExit_onclick() 
{
    window.open("../../home.aspx","_self");
}
function OnconfClick()
{
    if(document.getElementById(cont_name[0]+"Hidden2").value=="")
    {
        alert("Please Add Data...!");
        document.getElementById(cont_name[0]+"txtDate").focus();
        return false;
    }
    if (document.getElementById(cont_name[0]+"Hidden2").value!="")
    {  
            var st3 = "";
            st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
            ar=st2.length
            for(i=1;i<ar;i++)
            {
                st3=st2[i].split("#")
                document.getElementById(cont_name[0]+"hdnSend").value +="#"+st3[1]+ "^" +st3[6];
            }
    }
}
function window_onload()
{
    document.getElementById(cont_name[0]+"hdnSend").value="";
    document.getElementById(cont_name[0]+"Hidden2").value="";
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MMM/yyyy">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="Hdn" runat="server" />
        &nbsp;
        <asp:HiddenField ID="Hidden3" runat="server" />
        <asp:HiddenField ID="hdnSend" runat="server" />
        <table border="1" style="width: 80%">
            <tr>
                <td colspan="2" style="text-align: center; height: 24px;">
                    Select Appointment / Transfer</td>
                <td colspan="2" style="text-align: left; height: 24px;">
                    <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" Style="position: relative"
                        Width="67%" onchange="typchang()">
                        <asp:ListItem Value="0">------ SELECT TYPE ------</asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">APPOINTMENT</asp:ListItem>
                        <asp:ListItem Value="2">TRANSFER</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    Select Appointment / Transfer Date</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="65%" onkeyup="DateCheck()" onblur="check_date('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 26px">
                    Select Employees</td>
                <td colspan="2" style="height: 26px">
                    <asp:DropDownList ID="ddlEcode" runat="server" Width="96%" onchange="ClassChange()">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 28px; text-align: left;">
                    Name</td>
                <td style="width: 20%; height: 28px;">
                    <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 20%; height: 28px; text-align: left;">
                    Branch</td>
                <td style="width: 20%; height: 28px;">
                    <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 14px; text-align: left;">
                    Post</td>
                <td style="width: 20%; height: 14px;">
                    <asp:TextBox ID="txtPost" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 20%; height: 14px; text-align: left;">
                    Status</td>
                <td style="width: 20%; height: 14px;">
                    <asp:TextBox ID="txtStatus" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 24px;" colspan="4">
                    &nbsp;
                    &nbsp;<asp:RadioButton ID="rdstore" runat="server" GroupName="Send" onclick="rdClick()" Text="Send To Mail Dept" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btnAdd" type="button" value="ADD" onclick="return btnAdd_onclick()" style="width: 68px" /></td>
            </tr>
            <tr id="row1">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" OnClientClick="return OnconfClick()" runat="server" Text="CONFIRM" />
                    <input id="btnExit" type="button" value="EXIT" onclick="return btnExit_onclick()" style="width: 88px; height: 24px" /></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 13px;">
                </td>
                <td style="width: 20%; height: 13px;">
                </td>
                <td style="width: 20%; height: 13px;">
                </td>
                <td style="width: 20%; height: 13px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

