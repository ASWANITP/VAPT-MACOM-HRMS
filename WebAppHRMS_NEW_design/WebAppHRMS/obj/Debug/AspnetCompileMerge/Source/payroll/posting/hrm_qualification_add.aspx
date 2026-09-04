<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_qualification_add.aspx.vb" Inherits="WebAppHRMS.Qualification_Addition_hrm_qualification_add_cf9fd8193778" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
    window.onload = callback;
    function callback() {
        return window_onload();
    }
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function window_onload() 
{
    document.getElementById(con[0]+"hdnQualAdd").value="";
    document.getElementById(con[0]+"hdnExpAdd").value="";
    document.getElementById("rowExPanel").style.display="none";
    document.getElementById("rowQuPanel").style.display="none";
    showQual();
    showExp();
}

function isNumberKey(ids)
{ 
    var charcode = (event.which) ? event.which : event.keyCode
     if(ids==3)    
    {
        if (charcode > 31 && (charcode < 48 || charcode > 57  ))
        {
            return false;
        } 
        else
            return true;  
    }
}  

function showQual()
{
   var msg="****** Qualification Details *********"  
   var disp="<MARQUEE style=WIDTH: 608px; HEIGHT: 19px bgColor=antiquewhite><STRONG><FONT color=red>" + msg +"</FONT></STRONG></MARQUEE>"
   document.getElementById(con[0]+"lblQual").innerHTML=disp
   
}
function OnlettCaps(a)
{
   var lett = document.getElementById(con[0]+a).value;
   document.getElementById(con[0]+a).value = lett.toUpperCase();
}  
function OnCodecheck()
{

    var b=document.getElementById(con[0]+"txtAppno").value;
    if(isNaN(b))
    {
        alert('Please Enter Valid Application Number...!!!');
        document.getElementById(con[0]+"txtAppno").value = "";
        document.getElementById(con[0]+"txtAppno").focus();
        document.getElementById(con[0]+"txtName").value = ""; 
        return false;
    }
    if(document.getElementById(con[0]+"txtAppno").value!="")
    {   
        callserver("1$"+document.getElementById(con[0]+"txtAppno").value,1); 
    }
} 
function call_receiver(arg,context) 
{     
  switch (context)
  {
    case 1:
    {   
        var accdtl = arg.split("*");    
        if(accdtl=="")
         { 
            alert("Please Enter Valid Application Number...!!!");
            document.getElementById(con[0]+"txtAppno").value = "";
            document.getElementById(con[0]+"txtAppno").focus();
            document.getElementById(con[0]+"txtName").value = "";
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtName").value = accdtl[0];
         } 
         break;   
     }
  }
}
function YearCheck()
{
   var a=document.getElementById(con[0]+"txtYpass").value;
   if(isNaN(a))
   {
      alert('Please Enter Year of Pass in Digits..!!');
      document.getElementById(con[0]+"txtYpass").value = "";
      return false;
   }
} 
function ClassOnchange()
{
    document.getElementById(con[0]+"hdnQual").value=document.getElementById(con[0]+"ddlQual").value;
    return false;
} 
function YearLostFocus()
{
//2020
debugger;
   var a=document.getElementById(con[0]+"txtYpass").value;
   var d = new Date();
   var n = d.getFullYear();
   if((Math.abs(a)<1900)||(Math.abs(a)>n))
   {
      alert("Please Enter Valid Year...!!");
      document.getElementById(con[0]+"txtYpass").value = "";
      document.getElementById(con[0]+"txtYpass").focus(); 
      return false;
   }
}
function MarkCheck()
{
   var a=document.getElementById(con[0]+"txtMark").value;
   if(isNaN(a))
   {
      alert('Please Enter Percentage of Mark in Digits..!!');
      document.getElementById(con[0]+"txtMark").value = "";
      return false;
   }
   else if(a>100)
    {
      alert('Please Enter Valid Percentage of Mark..!!');
      document.getElementById(con[0]+"txtMark").value = "";
      return false;
   }
}  
function btnClear_onclick() 
{
    document.getElementById(con[0]+"ddlQual").value=-1;
    document.getElementById(con[0]+"txtInist").value="";
    document.getElementById(con[0]+"txtUni").value="";
    document.getElementById(con[0]+"txtMark").value="";
    document.getElementById(con[0]+"txtYpass").value="";
}

function btnAdd_onclick()
{
   
    if(document.getElementById(con[0]+"txtAppno").value=="")
    {
        alert('Please Enter Applcation Number..!!');
        document.getElementById(con[0]+"txtAppno").focus(); 
        document.getElementById(con[0]+"ddlQual").value=-1;
        document.getElementById(con[0]+"txtInist").value="";
        document.getElementById(con[0]+"txtUni").value="";
        document.getElementById(con[0]+"txtMark").value="";
        document.getElementById(con[0]+"txtYpass").value="";
        return false;
    }
    if(document.getElementById(con[0]+"txtName").value=="")
    {
        alert('Please Enter Applcation Number..!!');
        document.getElementById(con[0]+"txtAppno").focus();
        document.getElementById(con[0]+"ddlQual").value=-1;
        document.getElementById(con[0]+"txtInist").value="";
        document.getElementById(con[0]+"txtUni").value="";
        document.getElementById(con[0]+"txtMark").value="";
        document.getElementById(con[0]+"txtYpass").value=""; 
        return false;
    }
    if(document.getElementById(con[0]+"ddlQual").value==-1)
    {
        alert('Please Select Qualification..!!'); 
        document.getElementById(con[0]+"ddlQual").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtInist").value=="")
    {
        alert('Please Enter Institution..!!');
        document.getElementById(con[0]+"txtInist").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtUni").value=="")
    {
        alert('Please Enter University..!!');
        document.getElementById(con[0]+"txtUni").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtMark").value=="")
    {
        alert('Please Enter Persentage of Mark..!!');
        document.getElementById(con[0]+"txtMark").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtYpass").value=="")
    {
        alert('Please Enter Year of Pass..!!');
        document.getElementById(con[0]+"txtYpass").focus(); 
        return false;
    }
    
    if(document.getElementById(con[0]+"hdnQualAdd").value !="")
    {
       var appno=document.getElementById(con[0]+"txtAppno").value;
       var qual=document.getElementById(con[0]+"ddlQual").value;
       document.getElementById(con[0]+"Hidden1").value=document.getElementById(con[0]+"hdnQualAdd").value+"!"+document.getElementById(con[0]+"txtAppno").value+"#"+document.getElementById(con[0]+"txtName").value+"#"+document.getElementById(con[0]+"ddlQual").value+"#"+document.getElementById(con[0]+"txtInist").value+"#"+document.getElementById(con[0]+"txtUni").value+"#"+document.getElementById(con[0]+"txtMark").value+"#"+document.getElementById(con[0]+"txtYpass").value;
       var data = document.getElementById(con[0]+"Hidden1").value;
       var rows = data.split("!");
       var ddlq=document.getElementById(con[0]+"ddlQual").options[document.getElementById(con[0]+"ddlQual").selectedIndex].text

       for(i=0;i<=rows.length-2;i++)
       {
          cols = rows[i].split("#");
          if((cols[0]==appno) && (cols[2]==ddlq))
          {
             alert('Already Added..!');
             
             document.getElementById(con[0]+"ddlQual").value = -1;
             document.getElementById(con[0]+"txtInist").value = "";
             document.getElementById(con[0]+"txtUni").value = "";
             document.getElementById(con[0]+"txtMark").value = "";
             document.getElementById(con[0]+"txtYpass").value = "";
             return false;
          }
          
          
       }
     }
     var kk=document.getElementById(con[0]+"ddlQual").options[document.getElementById(con[0]+"ddlQual").selectedIndex].text
     document.getElementById(con[0]+"hdnQualAdd").value=document.getElementById(con[0]+"hdnQualAdd").value+"!"+document.getElementById(con[0]+"txtAppno").value+"#"+document.getElementById(con[0]+"txtName").value+"#"+kk+"#"+document.getElementById(con[0]+"txtInist").value+"#"+document.getElementById(con[0]+"txtUni").value+"#"+document.getElementById(con[0]+"txtMark").value+"#"+document.getElementById(con[0]+"txtYpass").value;
     showDetails();
     document.getElementById(con[0]+"ddlQual").value = -1;
     document.getElementById(con[0]+"txtInist").value = "";
     document.getElementById(con[0]+"txtUni").value = "";
     document.getElementById(con[0]+"txtMark").value = "";
     document.getElementById(con[0]+"txtYpass").value = "";
}
function showDetails()
{
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1><tr></tr>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>Appl.No</td>";
    tmptab  =tmptab+"<td width=15% align=left style= 'font-size: 10pt;'>Appl.Name</td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Qualification</td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Institution</td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>University</td>";
    tmptab  =tmptab+"<td width=3% align=left style= 'font-size: 10pt;'>Per.Mark</td>";
    tmptab  =tmptab+"<td width=3% align=left style= 'font-size: 10pt;'>Year Pass</td>";
    tmptab  =tmptab+"<td width=4% align=right style= 'font-size: 10pt;'>Delete</td></tr>";
    
    var rowSplitarr =document.getElementById(con[0]+"hdnQualAdd").value.split("!");
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
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[0] + "</td>"  ;
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[2] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[3] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[4] + "</td>"  ;
        tmptab          =   tmptab +"<td width=3% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[5] + "</td>"  ;
        tmptab          =   tmptab +"<td width=3% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[6] + "</td>"  ;
        tmptab          =   tmptab +"<td width=4% align=right style= 'font-size: 10pt;'><a href=javascript:delfq("+m+")>Del</a></td></tr>";
    }
    if (row_bg1 == 0)
            tmptab += "<tr style='background-color:OldLace'>";
    else
            tmptab += "<tr style='background-color:Wheat'>"; 
    tmptab          =   tmptab+"</table>";
    document.getElementById(con[0]+"Panel1").innerHTML=tmptab;
    document.getElementById("rowQuPanel").style.display="table-row";
}

function delfq(m)
{
    var j=m-1,k
    var new_tran=""
    var new_tran1=""
    var arr=document.getElementById(con[0]+"hdnQualAdd").value.split("!")
    for(k=1;k<=j;k++)
    {
        new_tran=new_tran+"!"+ arr[k]
    }
    for(k=j+2;k<arr.length;k++)
    {
        new_tran=new_tran+"!"+arr[k]
    }
    document.getElementById(con[0]+"hdnQualAdd").value=new_tran
    showDetails();
}
//=======================EXPERIANCE==================================

function showExp()
{
   var msg="****** Experiance Details *********"  
   var disp="<MARQUEE style=WIDTH: 608px; HEIGHT: 19px bgColor=antiquewhite><STRONG><FONT color=red>" + msg +"</FONT></STRONG></MARQUEE>"
   document.getElementById(con[0]+"lblExp").innerHTML=disp
   
}
//function DateFCheck()
//{
//   alert('Please Select date Using Calendar..!!');
//   document.getElementById(con[0]+"txtFDate").value = '';
//   return false;
//}
//function DateTCheck()
//{
//   alert('Please Select date Using Calendar..!!');
//   document.getElementById(con[0]+"txtTDate").value = "";
//   return false;
//}
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
function btnEclear_onclick() 
{
    document.getElementById(con[0]+"txtOrg").value="";
    document.getElementById(con[0]+"txtDes").value="";
    document.getElementById(con[0]+"txtFdate").value="";
    document.getElementById(con[0]+"txtTdate").value="";
    document.getElementById(con[0]+"txtDuty").value=""; 
    document.getElementById(con[0]+"txtSalary").value="";
    document.getElementById(con[0]+"txtCon").value="";
    document.getElementById(con[0]+"txtConph").value=""; 
    document.getElementById(con[0]+"txtReason").value=""; 
}
function SalaryCheck()
{
   var a=document.getElementById(con[0]+"txtSalary").value;
   if(isNaN(a))
   {
      alert('Please Salary Drawn in Digits..!!');
      document.getElementById(con[0]+"txtSalary").value = "";
      return false;
   }
}  
function btnEadd_onclick()
{
    if(document.getElementById(con[0]+"txtAppno").value=="")
    {
        alert('Please Enter Application Number..!!');
        document.getElementById(con[0]+"txtAppno").focus();
        document.getElementById(con[0]+"txtOrg").value="";
        document.getElementById(con[0]+"txtDes").value="";
        document.getElementById(con[0]+"txtFdate").value="";
        document.getElementById(con[0]+"txtTdate").value="";
        document.getElementById(con[0]+"txtDuty").value=""; 
        document.getElementById(con[0]+"txtSalary").value="";
        document.getElementById(con[0]+"txtCon").value="";
        document.getElementById(con[0]+"txtConph").value=""; 
        document.getElementById(con[0]+"txtReason").value="";  
        return false;
    }
    if(document.getElementById(con[0]+"txtName").value=="")
    {
        alert('Please Enter Valid Application Number..!!');
        document.getElementById(con[0]+"txtAppno").focus();
        document.getElementById(con[0]+"txtOrg").value="";
        document.getElementById(con[0]+"txtDes").value="";
        document.getElementById(con[0]+"txtFdate").value="";
        document.getElementById(con[0]+"txtTdate").value="";
        document.getElementById(con[0]+"txtDuty").value=""; 
        document.getElementById(con[0]+"txtSalary").value="";
        document.getElementById(con[0]+"txtCon").value="";
        document.getElementById(con[0]+"txtConph").value=""; 
        document.getElementById(con[0]+"txtReason").value="";  
        return false;
    }
    if(document.getElementById(con[0]+"txtOrg").value=="")
    {
        alert('Please Enter Organization..!!');
        document.getElementById(con[0]+"txtOrg").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtDes").value=="")
    {
        alert('Please Enter Designation..!!');
        document.getElementById(con[0]+"txtdes").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtFdate").value=="")
    {
        alert('Please Select From Date..!!');
        document.getElementById(con[0]+"txtFdate").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtTdate").value=="")
    {
        alert('Please Select To Date..!!');
        document.getElementById(con[0]+"txtTdate").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtDuty").value=="")
    {
        alert('Please Enter Nature of Duty..!!');
        document.getElementById(con[0]+"txtDuty").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtSalary").value=="")
    {
        alert('Please Enter Salery Drawn..!!');
        document.getElementById(con[0]+"txtSalary").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtCon").value=="")
    {
        alert('Please Enter Contact Person..!!');
        document.getElementById(con[0]+"txtCon").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtConph").value=="")
    {
        alert('Please Enter Contact Persons Number..!!');
        document.getElementById(con[0]+"txtConph").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"txtReason").value=="")
    {
        alert('Please Enter Reason For Leaving..!!');
        document.getElementById(con[0]+"txtReason").focus(); 
        return false;
    }
    if(document.getElementById(con[0]+"hdnExpAdd").value !="")   //For Checking Duplication
    {
       var org=document.getElementById(con[0]+"txtOrg").value;
       var des=document.getElementById(con[0]+"txtDes").value;
       document.getElementById(con[0]+"Hidden2").value=document.getElementById(con[0]+"hdnExpAdd").value+"!"+document.getElementById(con[0]+"txtOrg").value+"#"+document.getElementById(con[0]+"txtDes").value+"#"+document.getElementById(con[0]+"txtFdate").value+"#"+document.getElementById(con[0]+"txtTdate").value+"#"+document.getElementById(con[0]+"txtDuty").value+"#"+document.getElementById(con[0]+"txtSalary").value+"#"+document.getElementById(con[0]+"txtCon").value+"#"+document.getElementById(con[0]+"txtConph").value+"#"+document.getElementById(con[0]+"txtReason").value;
       var data = document.getElementById(con[0]+"Hidden2").value;
       var rows = data.split("!");
       for(i=0;i<=rows.length-2;i++)
       {
          cols = rows[i].split("#");
          if((cols[0]==org) && (cols[1]==des))
          {
             alert('Already Added..!');
             document.getElementById(con[0]+"txtOrg").value="";
             document.getElementById(con[0]+"txtDes").value="";
             document.getElementById(con[0]+"txtFdate").value="";
             document.getElementById(con[0]+"txtTdate").value="";
             document.getElementById(con[0]+"txtDuty").value=""; 
             document.getElementById(con[0]+"txtSalary").value="";
             document.getElementById(con[0]+"txtCon").value="";
             document.getElementById(con[0]+"txtConph").value=""; 
             document.getElementById(con[0]+"txtReason").value="";    
          }
       }
    }
    document.getElementById(con[0]+"hdnExpAdd").value=document.getElementById(con[0]+"hdnExpAdd").value+"!"+document.getElementById(con[0]+"txtOrg").value+"#"+document.getElementById(con[0]+"txtDes").value+"#"+document.getElementById(con[0]+"txtFdate").value+"#"+document.getElementById(con[0]+"txtTdate").value+"#"+document.getElementById(con[0]+"txtDuty").value+"#"+document.getElementById(con[0]+"txtSalary").value+"#"+document.getElementById(con[0]+"txtCon").value+"#"+document.getElementById(con[0]+"txtConph").value+"#"+document.getElementById(con[0]+"txtReason").value;
    showDetailsExp();
    document.getElementById(con[0]+"txtOrg").value="";
    document.getElementById(con[0]+"txtDes").value="";
    document.getElementById(con[0]+"txtFdate").value="";
    document.getElementById(con[0]+"txtTdate").value="";
    document.getElementById(con[0]+"txtDuty").value=""; 
    document.getElementById(con[0]+"txtSalary").value="";
    document.getElementById(con[0]+"txtCon").value="";
    document.getElementById(con[0]+"txtConph").value=""; 
    document.getElementById(con[0]+"txtReason").value=""; 
}
function showDetailsExp()
{
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1><tr></tr>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Organization</td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Designation</td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>From Dt</td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>To Date</td>";
    tmptab  =tmptab+"<td width=8% align=left style= 'font-size: 10pt;'>Nature of Duty</td>";
    tmptab  =tmptab+"<td width=3% align=left style= 'font-size: 10pt;'>Salary Drawn</td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>Contact Person</td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'>Contact Person Number</td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'>Reason For Leaving</td>";
    tmptab  =tmptab+"<td width=4% align=right style= 'font-size: 10pt;'>Delete</td></tr>";
    
    var rowSplitarr =document.getElementById(con[0]+"hdnExpAdd").value.split("!");
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
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>"  ;
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[2] + "</td>"  ;
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[3] + "</td>"  ;
        tmptab          =   tmptab +"<td width=8% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[4] + "</td>"  ;
        tmptab          =   tmptab +"<td width=3% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[5] + "</td>"  ;
        tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[6] + "</td>"  ;
         tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[7] + "</td>"  ;
          tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[8] + "</td>"  ;
        tmptab          =   tmptab +"<td width=4% align=right style= 'font-size: 10pt;'><a href=javascript:delf("+m+")>Del</a></td></tr>";
    }
    if (row_bg1 == 0)
            tmptab += "<tr style='background-color:OldLace'>";
    else
            tmptab += "<tr style='background-color:Wheat'>"; 
    tmptab          =   tmptab+"</table>";
    document.getElementById(con[0]+"Panel2").innerHTML=tmptab;
    document.getElementById("rowExPanel").style.display="table-row";
}

function delf(m)
{
    var j=m-1,k
    var new_tran=""
    var new_tran1=""
    var arr=document.getElementById(con[0]+"hdnExpAdd").value.split("!")
    for(k=1;k<=j;k++)
    {
        new_tran=new_tran+"!"+ arr[k]
    }
    for(k=j+2;k<arr.length;k++)
    {
        new_tran=new_tran+"!"+arr[k]
    }
    document.getElementById(con[0]+"hdnExpAdd").value=new_tran
    showDetailsExp();
}
function OnConfClick()
{
    if(document.getElementById(con[0]+"txtAppno").value=="")
    {
        alert("Please Enter Application Number...!!!");
        document.getElementById(con[0]+"txtAppno").focus();
        return false;
    }
    if((document.getElementById(con[0]+"hdnQualAdd").value=="")&&(document.getElementById(con[0]+"hdnExpAdd").value==""))
    {
        alert("Please Enter Qualification or Experience Detail...!");
        return false;
    }
} 
function btnExit_onclick() {
window.open('../../home.aspx','_self');
}

//-----------------------------------M*------------------------------
 function checkAlphabet(event)
{  //debugger;48
 
var keyCode = (event.which) ? event.which : event.keyCode

if ((event.keyCode > 32 && event.keyCode < 58) || (event.keyCode > 57 && event.keyCode < 65) || (event.keyCode > 90 && event.keyCode < 97)|| (event.keyCode > 122 && event.keyCode < 127)) 

{
 return false;
}
}
function check_null()
{
    alert("Select Date From Calender")
    return  false;
}   
//----------------------------------------------------------------------

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtFdate"></cc1:calendarextender>
        <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtTdate"></cc1:calendarextender>
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="hdnQualAdd" runat="server" />
        <asp:HiddenField ID="hdnExpAdd" runat="server" />
        <asp:HiddenField ID="hdnQual" runat="server" />
        <table border="1" style="width: 80%">
            <tr>
                <td style="width: 21%; text-align: left">
                    Application Number</td>
                <td style="width: 2%; text-align: left"><%--onblur="OnCodecheck()"--%>
                    <asp:TextBox ID="txtAppno" runat="server" Width="95%"  onkeypress="return isNumberKey(3)" AutoPostBack="True"></asp:TextBox></td>
                <td style="width: 18%; text-align: left">
                    Applicants Name</td>
                <td style="width: 22%; text-align: left">
                    <asp:TextBox ID="txtName" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblQual" runat="server" Width="326px" ForeColor="Transparent"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    Select Qualification</td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="ddlQual" runat="server" Width="100%" onchange="ClassOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">
                    Enter Institution</td>
                <td colspan="2" style="text-align: left;">
                    <asp:TextBox ID="txtInist" runat="server" Width="100%" onkeyup="OnlettCaps('txtInist')" onkeypress="return checkAlphabet(event)" MaxLength="75"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    Enter University</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtUni" runat="server" Width="100%" onkeyup="OnlettCaps('txtUni')" onkeypress="return checkAlphabet(event)" MaxLength="75"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 9px; text-align: left;">
                    Enter Year Of Passing</td>
                <td style="width: 20%; height: 9px; text-align: left;">
                    <asp:TextBox ID="txtYpass" runat="server" Width="98%" onkeyup="return YearCheck()" MaxLength="4" onblur="YearLostFocus()"></asp:TextBox></td>
                <td style="width: 20%; height: 9px; text-align: left;">
                    Enter Percentage Of Mark</td>
                <td style="width: 22%; height: 9px; text-align: left;">
                    <asp:TextBox ID="txtMark" runat="server" Width="100%" onkeyup="return MarkCheck()"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 9px; text-align: center">
                    <input id="btnAdd" style="width: 66px; height: 28px" type="button" value="ADD" onclick="return btnAdd_onclick()" />
                    <input id="btnClear" style="height: 28px" type="button" value="CLEAR" onclick="return btnClear_onclick()" />&nbsp;</td>
            </tr>
            <tr id="rowQuPanel">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblExp" runat="server" Width="300px"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    Name of Organization</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtOrg" runat="server" Width="100%" onkeyup="OnlettCaps('txtOrg')" onkeypress="return checkAlphabet(event)" MaxLength="75"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    Employee Designation
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtDes" runat="server" Width="100%" onkeyup="OnlettCaps('txtDes')" onkeypress="return checkAlphabet(event)" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21%; height: 23px; text-align: left">
                    Period From Date</td>
                <td style="width: 2%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtFdate" runat="server" Width="95%" onkeypress="return check_null()" onblur="checkFdate('txtFdate')"></asp:TextBox></td>
                <td style="width: 18%; height: 23px; text-align: left">
                    Period To Date</td>
                <td style="width: 22%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtTdate" runat="server" Width="100%" onkeypress="return check_null()" onblur="checkTdate('txtTdate')"></asp:TextBox></td>
                    <%--onkeyup="DateTCheck()" --%>
            </tr>
            <tr>
                <td style="width: 21%; text-align: left">
                    Nature Of Duty</td>
                <td style="width: 2%; text-align: left">
                    <asp:TextBox ID="txtDuty" runat="server" Width="95%" onkeyup="OnlettCaps('txtDuty')" onkeypress="return checkAlphabet(event)" MaxLength="50"></asp:TextBox></td>
                <td style="width: 18%; text-align: left">
                    Salary Drawn</td>
                <td style="width: 22%; text-align: left">
                    <asp:TextBox ID="txtSalary" runat="server" Width="100%" onkeyup="return SalaryCheck()" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 21%; text-align: left">
                    Contact Person</td>
                <td style="width: 2%; text-align: left">
                    <asp:TextBox ID="txtCon" runat="server" Width="95%" onkeyup="OnlettCaps('txtCon')" onkeypress="return checkAlphabet(event)" MaxLength="50"></asp:TextBox></td>
                <td style="width: 18%; text-align: left">
                    Contact No.</td>
                <td style="width: 22%; text-align: left">
                    <asp:TextBox ID="txtConph" runat="server" Width="100%" MaxLength="15" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Reason For Leaving</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="100%" onkeyup="OnlettCaps('txtReason')" MaxLength="75"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<input id="btnEadd" style="width: 66px; height: 28px" type="button" value="ADD" onclick="return btnEadd_onclick()" />
                    <input id="btnEclear" style="width: 66px; height: 28px" type="button" value="CLEAR" onclick="return btnEclear_onclick()" /></td>
            </tr>
            <tr id="rowExPanel">
                <td colspan="4" >
                    <asp:Panel ID="Panel2" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="height: 28px;" colspan="4">
                    <asp:Button ID="btnConfirm" runat="server"  OnClientClick="return OnConfClick()" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 22%">
                </td>
                <td style="width: 2%">
                </td>
                <td style="width: 22%">
                </td>
                <td style="width: 22%">
                </td>
            </tr>
        </table>
        &nbsp;
    </div>
</asp:Content>

