<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="Excel_Leave_Rpt.aspx.vb" Inherits="WebAppHRMS.report_AgencyWiseTrxn_0357ac437527" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name = header.split("Cmb");


function checkDate1(sender,args)
{
 if (sender._selectedDate > new Date()) 
            {
                alert("You cannot select a Future Date..!!");
                //sender._selectedDate = new Date(); 
                document.getElementById(cont_name[0]+"Txt_DateFrom").value=new Date().format(sender._format);               
            }
}

function EmpOnchange()
{
if (document.getElementById(cont_name[0]+"Cmb_Emp").value!="-1")
{
    document.getElementById(cont_name[0]+"HiddenEmp").value=document.getElementById(cont_name[0]+"Cmb_Emp").value;
}    

}

function checkDate2(sender,args)
{
 if (sender._selectedDate > new Date()) 
            {
                alert("You cannot select a Future Date..!");
                //sender._selectedDate = new Date(); 
                document.getElementById(cont_name[0]+"Txt_DateTo").value=new Date().format(sender._format);               
            }
}

function check()
{            
   document.getElementById(cont_name[0]+"Txt_DateFrom").value=new Date().format("dd/MMM/yyyy"); 
   document.getElementById(cont_name[0]+"Txt_DateTo").value=new Date().format("dd/MMM/yyyy");               
 
 }

function sherror(sender,args)
{
                alert("Select from Calendar!");
                check();
}
function cliclick()
{
 var day1, day2;
    var month1, month2;
    var year1, year2;
   if(document.getElementById(cont_name[0]+"Txt_DateFrom").value!="")
   {
    var value1 = document.getElementById(cont_name[0]+"Txt_DateFrom").value;
    //var dt = new Date().format("dd/MMM/yyyy");
    //var value2=dt;
    var value2=document.getElementById(cont_name[0]+"Txt_DateTo").value;
    
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
  alert("From Date Should be Equal or Less Than ToDate...!!")
  document.getElementById(cont_name[0]+"Txt_DateFrom").value=new Date().format("dd/MMM/yyyy"); 
  document.getElementById(cont_name[0]+"Txt_DateTo").value=new Date().format("dd/MMM/yyyy");       
  return false;
}
}
}
function Butn_Exit_onclick() 
{
 window.open('../../home.aspx','_self');
}

function BranchOnchange()
{
     var brid =document.getElementById(cont_name[0]+"Cmb_Branch").value;
     document.getElementById(cont_name[0]+"HiddenBranch").value=brid;
     if(brid!=-1)
     {
     call_server("1*"+brid,1);
     }
}



function call_receiver(arg,context) 
{ 
  switch(context)
  {
      case 1:
      {       

       document.getElementById(cont_name[0]+"Cmb_Emp").options.length = 0;
         var rows = arg.split("%");
         for(a=0; a<rows.length; a++)
         {
            var cols      = rows[a].split("@");
            var option1   = document.createElement("OPTION");
            option1.value = cols[0];
            option1.text  = cols[1];
            document.getElementById(cont_name[0]+"Cmb_Emp").add(option1);
         }
            break;
            
      }
      
    }
   
 } 
 
 function ClickOnchange()
 {
 if(document.getElementById(cont_name[0]+"Cmb_Branch").value==-1)
 {
    alert('Please Select Category');
    document.getElementById(cont_name[0]+"Cmb_Branch").focus();
    return false;
 }
 
  if(document.getElementById(cont_name[0]+"Cmb_Emp").value==-1)
 {
    alert('Please Select Head');
    document.getElementById(cont_name[0]+"Cmb_Emp").focus();
    return false;
 }
 
 }
// ]]>
</script>

    <div style="text-align: center">
        <br />
        <div style="text-align: center">
            <table border="1" style="width: 50%">
                <tr>
                    <td style="width: 50%">
                        Select Category</td>
                    <td style="width: 50%; text-align: left">
                        <asp:DropDownList ID="Cmb_Branch" runat="server" Width="99%">
                            <asp:ListItem Value="-1">------------SELECT-----------</asp:ListItem>
                            <asp:ListItem Value="613">BRANCHES EMPLOYEE</asp:ListItem>
                            <asp:ListItem Value="614">HEAD OFFICE EMPLOYEE</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 50%">
                        Select Head
                    </td>
                    <td style="width: 50%; text-align: left">
                        <asp:DropDownList ID="Cmb_Emp" runat="server" Width="99%">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: right">
                        <asp:Button ID="Butn_Generate" OnClientClick="return ClickOnchange()" runat="server" Height="29px" Text="GENERATE" Width="81px" Font-Bold="True" Font-Names="Courier New" />
                    </td>
                    <td style="width: 50%; text-align: left">
                        <input id="Butn_Exit" style="font-weight: bold; width: 71px; font-family: 'Courier New';
                            height: 28px" type="button" value="EXIT" onclick="return Butn_Exit_onclick()" /></td>
                </tr>
                <tr>
                    <td style="width: 50%">
                    </td>
                    <td style="width: 50%">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        &nbsp;</div>
    &nbsp;&nbsp;
    <asp:HiddenField ID="HiddenEmp" runat="server" /><asp:HiddenField ID="HiddenBranch" runat="server" />
    <br />
</asp:Content>