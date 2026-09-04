<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="date_select.aspx.vb" Inherits="WebAppHRMS.pledge_MJ_report_mj_date_select_3a47b73e9042" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split('txt');
function btn_exit_onclick() 
{
window.open('../../home.aspx','_self');
}
function checkDt()
{
checkDate(document.getElementById(cont_name[0]+"txt_from").value,document.getElementById(cont_name[0]+"txt_to").value,2)
}
function returnFalse()
{
    return false;
}

function checkDate(dateFrom,dateTo,stat)
{

    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;
    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;
    
    if((dateFrom =="") || (dateTo == ""))
    {
     if(dateFrom =="")
       {
        dateFrom=new Date().format("dd/MMM/yyyy");
       }
    if(dateTo =="")
    {
    dateTo=new Date().format("dd/MMM/yyyy");
    }
    }
    
            value1 = dateFrom;
            value2 = dateTo;
           
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
            
            firstDate = Date.parse(date1)
            secondDate= Date.parse(date2)
            thirdDate = Date.parse(date3)
            

            msPerDay = 24 * 60 * 60 * 1000
            
            dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd1 = Math.round((thirdDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
            dbd2 = Math.round((thirdDate.valueOf()-secondDate.valueOf())/ msPerDay) ;   
            if(stat==1)
              {
              
               if (dbd1<0 || dbd2<0)
                 {
                  alert('Please Do not enter Future Date..!!');
                  return false;
                }
               
              }
              
           if(stat==2)
              {
             
               if (dbd1<dbd2)
                 {
                  alert('Check the dates');
                  document.getElementById(cont_name[0]+"txt_from").value=""
                  document.getElementById(cont_name[0]+"txt_to").value=""
                  return false ;
               }
              }  
          
           if(stat==3)
              {
              
               if (dbd1>0 || dbd2>0)
                 {
                  alert('Please Do not enter Past Date..!!');
                  return false;
                }
               
              }
              if (stat==4)
              {
                if (dbd>62)
                    {
                        alert("Check Date")
                        return false;
                    }
              }
       return true;       
           
   
}

//function btn_generate_onclick() 
//{
//debugger;
////if(!document.getElementById (cont_name[0]+"txt_per").value)
////{
////    document.getElementById (cont_name[0]+"txt_per").value="";
////    document.getElementById (cont_name[0]+"txt_per").focus;
////    alert("ENTER PERIOD");
////    return false;
////}


// var fdt=document.getElementById (cont_name[0]+"txt_from").value;
// var tdt=document.getElementById (cont_name[0]+"txt_to").value;
// var pr=document.getElementById (cont_name[0]+"txt_per").value;
//  window.open ("leave_repo.aspx?FromDt="+fdt+"&ToDt="+tdt+"&per="+pr+"","_self")
// 
//}


function validat(a,e)
{
debugger;
var x=document.getElementById(cont_name[0]+a).value;
var len=x.length

if (isNaN(x))
   {
    document.getElementById(cont_name[0]+a).value="";
    document.getElementById(cont_name[0]+a).focus;
    return false;
    }
    
 if(len>2)
 {
  document.getElementById(cont_name[0]+a).value="";
  document.getElementById(cont_name[0]+a).focus;
  return false;
 }  

}

 

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>&nbsp;<table border="1" style="width: 32%; font-size: 10pt; font-family: 'Times New Roman';">
        <tr>
       <td style="text-align:center" colspan="2">
            <strong><span style="font-size: 16pt">
        Period wise Leave Report </span></strong>
        </td>
        </tr>
            <tr>
                <td style="width: 20%">
                    Date From</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txt_from" runat="server" Font-Names="Times New Roman" Font-Size="10pt"
                        Width="60%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%">
                   Date To</td>
                <td style="width: 25%"><asp:TextBox ID="txt_to" runat="server" Font-Names="Times New Roman" Font-Size="10pt"
                        Width="60%"></asp:TextBox>
                </td>
                <%-- <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_from"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_to"></cc1:calendarextender>--%>
            </tr>
            <tr>
                <td style="width: 20%">
                    period</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txt_per" runat="server" onkeyup="validat('txt_per',event)" Width="60%"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 26px;">
                    <input id="btn_exit" style="font-size: 10pt; width: 76px; font-family: 'Times New Roman'"
                        type="button" value="Exit"  runat="server" /></td>
                <td style="width: 25%; height: 26px;">
                    <input id="btn_generate" style="font-size: 10pt; font-family: 'Times New Roman'"
                        type="button" value="Generate" runat="server"/></td>
            </tr>
        </table>
    </div>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" format="dd/MMM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" format="dd/MMM/yyyy">
    </cc1:CalendarExtender>

</asp:Content>

