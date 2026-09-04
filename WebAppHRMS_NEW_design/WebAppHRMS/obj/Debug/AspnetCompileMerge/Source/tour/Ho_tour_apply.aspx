<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Ho_tour_apply.aspx.vb" Inherits="WebAppHRMS.november_tour_Tour_apply_d1bb416e6324" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("Txt");
function isNumberKey(ids) 
{ 
//debugger;
    var charcode = (event.which) ? event.which : event.keyCode 
    if(ids==1) 
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32)) 
        {
            return true; 
        } 
        else 
            return false; 
    }
    if(ids==2) 
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32) || (charcode > 46 && charcode <58)) 
        {
            return true; 
        } 
        else 
            return false; 
    }
    if(ids==3) 
    {
        if (charcode > 31 && (charcode < 48 || charcode > 57 )) 
        {
            return false; 
        } 
        else 
            return true; 
    }

}
function checkb()
{
        var ftime;
        var ttime;
        
        ftime=document.getElementById(cs[0]+"Txt_FromTime").value;
        ttime=document.getElementById(cs[0]+"Txt_ToTime").value;
        
        if ((document.getElementById(cs[0]+"Txt_adv").value == '') ||(document.getElementById(cs[0]+"Txt_purp").value== ''))
        {
           alert('Please Fill All Entries');
            return false;
        }
        if((document.getElementById(cs[0]+"Txt_fdt").value)==(document.getElementById(cs[0]+"Txt_tdt").value))
        {
            var fall,fsub,fhr,fmin,fampm;
            fall=ftime.split(":");
            fsub=ftime.split(" ");
            fhr=Math.abs(fall[0]);
            fmin=Math.abs(fall[1]);
            fampm=fsub[1];
            
            var tall,tsub,thr,tmin,tampm;
            tall=ttime.split(":");
            tsub=ttime.split(" ");
            thr=Math.abs(tall[0]);
            tmin=Math.abs(tall[1]);
            tampm=tsub[1];
            
            
            if ((fampm == "pm" || fampm == "PM" || fampm == "Pm") && (tampm == "am" || tampm == "AM" || tampm == "Am"))
            {    
                alert('Your Entered Time is Wrong..!! Pm to Am within same date..!!');
               // window.open('Ho_tour_apply.aspx','_self');
                return false;
            }
            else if ((fhr == thr) && (fmin > tmin))
            {
                alert('Your Entered Time is Wrong..!! From Minute Less Than To Minute in same date..!!');
                //window.open('Ho_tour_apply.aspx','_self');
                return false;
            }
            else if (((fampm == "pm" || fampm == "PM" || fampm == "Pm") && (tampm == "pm" || tampm == "PM" || tampm == "Pm")) || ((fampm == "am" || fampm == "AM" || fampm == "Am") && (tampm == "am" || tampm == "AM" || tampm == "Am")))
            {
               if(fhr > thr)
               {
                 alert('Your Entered Time is Wrong..!! From Hour Less Than To Hour in same date..!!\nCheck AM PM..!!');
                 return false;
               }
            }            
             
        }
}


function change(a) {
var str=document.getElementById(cs[0]+a).value;
if (str==' ')
  {document.getElementById(cs[0]+a).value="";
    document.getElementById(cs[0]+a).focus;
    return false;
   }
 if (isNaN(str))
   {
    document.getElementById(cs[0]+a).value="";
    document.getElementById(cs[0]+a).focus;
    return false;
   }

}
function check1()
{

if(document.getElementById(cs[0]+"chk_br").checked==true)
{
document.getElementById(cs[0]+"chk_oth").checked=false
//alert(document.getElementById(cs[0]+"Txt_oth").visible)
document.getElementById(cs[0]+"Txt_oth").style.display="none"
document.getElementById("row1").style.display="none"
document.getElementById(cs[0]+"cmb_place").style.display="inline"
document.getElementById("row2").style.display="inline"
}
if(document.getElementById(cs[0]+"chk_br").checked==false)
{
document.getElementById(cs[0]+"chk_oth").checked=true
document.getElementById(cs[0]+"Txt_oth").style.display="inline"
document.getElementById("row1").style.display="inline"
document.getElementById(cs[0]+"cmb_place").style.display="none"
document.getElementById("row2").style.display="none"
}
}
function check2()
{
if(document.getElementById(cs[0]+"chk_oth").checked==true)
{
document.getElementById(cs[0]+"chk_br").checked=false
document.getElementById(cs[0]+"cmb_place").style.display="none"
document.getElementById("row2").style.display="none"
document.getElementById(cs[0]+"Txt_oth").style.display="inline"
document.getElementById("row1").style.display="inline"
}
if(document.getElementById(cs[0]+"chk_oth").checked==false)
{
document.getElementById(cs[0]+"chk_br").checked=true
document.getElementById(cs[0]+"cmb_place").style.display="inline"
document.getElementById("row2").style.display="inline"
document.getElementById(cs[0]+"Txt_oth").style.display="none"
document.getElementById("row1").style.display="none"
}
}

function init()
{
  document.getElementById(cs[0]+"Txt_oth").style.display="none";
  document.getElementById("row1").style.display="none";
  document.getElementById(cs[0]+"Txt_FromTime").value="07:30 am";
  document.getElementById(cs[0]+"Txt_ToTime").value="09:00 pm";
}
window.onload=init;

function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}

function clr(b)
{
 alert("please select the date");
 document.getElementById(cs[0]+b).value="";
 document.getElementById(cs[0]+b).focus();
 return false;
}

///

function fill1()
{    
   if(document.getElementById(cs[0]+"Cmb_Select").value!=0)
   {  
  
     sub_call_server(document.getElementById(cs[0]+"Cmb_Select").value);
   } 
   if(document.getElementById(cs[0]+"Cmb_Select").value==0)
   {
     document.getElementById(cs[0]+"Txt_emp").value="";
     document.getElementById(cs[0]+"Txt_dep").value="";
     document.getElementById(cs[0]+"Txt_des").value="";
     document.getElementById(cs[0]+"Txt_post").value="";
     document.getElementById(cs[0]+"Txt_br").value="";
       
     } 
}
function sub_call_receiver(arg1)
{ 
  var arg2;
  arg2=arg1.split("@");
  if (arg2[0]!="$")
  { 
    var arg3=arg2[0].split("*"); 
    document.getElementById(cs[0]+"Txt_emp").value=arg3[0];
    document.getElementById(cs[0]+"Txt_dep").value=arg3[1];
    document.getElementById(cs[0]+"Txt_des").value=arg3[2];
    document.getElementById(cs[0]+"Txt_post").value=arg3[3];
    document.getElementById(cs[0]+"Txt_br").value=arg3[4];
  } 
}
////=-=-=-=-=-=-==-=-=--=-==time checking modified on 22 may-2009=-=-=-=-=-=-=-==-=-=-===sss
//=-=-=-=-=--=-=--=-=-=-=-=-==-=-===Time  using Text Box=-Modified on 22 may 2009=-=--=-=-=-=-=-==--=-==-=-=-=--=
function validatetime(a)
 {
//bilu time check...
  var strval = document.getElementById(a).value;
  var strval1;
    
  //minimum lenght is 6. example 1:2 AM

  if(strval.length < 6)
  {
   alert("Invalid time. Time format should be HH:MM AM/PM.");
   document.getElementById(a).value="00:00 am";
   return false;
  }
  
  //Maximum length is 8. example 10:45 AM

  if(strval.lenght > 8)
  {
   alert("invalid time. Time format should be HH:MM AM/PM.");
      document.getElementById(a).value="00:00 am";
      return false;
  }
  
  //Removing all space

  strval = trimAllSpace(strval); 
  
  //Checking AM/PM

  if(strval.charAt(strval.length - 1) != "M" && strval.charAt(
      strval.length - 1) != "m")
  {
   alert("Invalid time. Time shoule be end with AM or PM.");
      document.getElementById(a).value="00:00 am";
      return false;
   
  }
  else if(strval.charAt(strval.length - 2) != 'A' && strval.charAt(
      strval.length - 2) != 'a' && strval.charAt(
      strval.length - 2) != 'p' && strval.charAt(strval.length - 2) != 'P')
  {
   alert("Invalid time. Time shoule be end with AM or PM.");
      document.getElementById(a).value="00:00 am";
      return false;
   
  }
  
  //Give one space before AM/PM

  
  strval1 =  strval.substring(0,strval.length - 2);
  strval1 = strval1 + ' ' + strval.substring(strval.length - 2,strval.length)
  
  strval = strval1;
      
  var pos1 = strval.indexOf(':');
  document.getElementById(a).value = strval;
  
  if(pos1 < 0 )
  {
   alert("invlalid time. A color(:) is missing between hour and minute.");
     document.getElementById(a).value="00:00 am";
      return false;
  }
  else if(pos1 > 2 || pos1 < 1)
  {
   alert("invalid time. Time format should be HH:MM AM/PM.");
     document.getElementById(a).value="00:00 am";
      return false;
  }
  
  //Checking hours

  var horval =  trimString(strval.substring(0,pos1));
   
  if(horval == -100)
  {
   alert("Invalid time. Hour should contain only integer value (0-11).");
     document.getElementById(a).value="00:00 am";
      return false;
  }
      
  if(horval > 12)
  {
   alert("invalid time. Hour can not be greater that 12.");
     document.getElementById(a).value="00:00 am";
      return false;
  }
  else if(horval < 0)
  {
   alert("Invalid time. Hour can not be hours less than 0.");
     document.getElementById(a).value="00:00 am";
      return false;
  }
  //Completes checking hours.

  
  //Checking minutes.

  var minval =  trimString(strval.substring(pos1+1,pos1 + 3));
  
  if(minval == -100)
  {
   alert("Invalid time. Minute should have only integer value (0-59).");
      document.getElementById(a).value="00:00 am";
      return false;
  }
    
  if(minval > 59)
  {
     alert("Invalid time. Minute can not be more than 59.");
     
       document.getElementById(a).value="00:00 am";
        return false;
  }   
  else if(minval < 0)
  {
   alert("Invalid time. Minute can not be less than 0.");
   
      document.getElementById(a).value="00:00 am";
      return false;
  }
   
  //Checking minutes completed.  

  
  //Checking one space after the mintues 

  minpos = pos1 + minval.length + 1;
  if(strval.charAt(minpos) != ' ')
  {
   alert("Invalid time. Space missing after minute.Time should have HH:MM AM/PM format.");
     document.getElementById(a).value="00:00 am";
      return false;
  }
 
   alert("Please Make Sure Time & Also Check Am/Pm Before Confirm") 
   

    return true;
  
  
 }
function trimAllSpace(str) 
{ 
    var str1 = ''; 
    var i = 0; 
    while(i != str.length) 
    { 
        if(str.charAt(i) != ' ') 
            str1 = str1 + str.charAt(i); i ++; 
    } 
    return str1; 
}
function trimString(str) 
{ 
     var str1 = ''; 
     var i = 0; 
     while ( i != str.length) 
     { 
         if(str.charAt(i) != ' ') str1 = str1 + str.charAt(i); i++; 
     }
     var retval = IsNumeric(str1); 
     if(retval == false) 
         return -100; 
     else 
         return str1; 
} 
function IsNumeric(strString) 
{ 
    var strValidChars = "0123456789:"; 
    var strChar; 
    var blnResult = true; 
    //var strSequence = document.frmQuestionDetail.txtSequence.value; 

    //test strString consists of valid characters listed above 

    if (strString.length == 0) 
        return false; 
    for (i = 0; i < strString.length && blnResult == true; i++) 
    { 
        strChar = strString.charAt(i); 
        if (strValidChars.indexOf(strChar) == -1) 
        { 
            blnResult = false; 
        } 
     } 
return blnResult; 
}

//=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=
function tourcliclick()

{
    if (document.getElementById(cs[0]+"Txt_fdt").value=='')
        {
            alert('Please Enter From Date');
            return false;
        }   
        if (document.getElementById(cs[0]+"Txt_tdt").value=='')
        {
            alert('Please Enter To Date');
            return false;
        }   
   
   var a=Fill_Dateboth();
   if(a==true)
   {
     if(document.getElementById(cs[0]+"Txt_FromTime").value=="00:00 am" || document.getElementById(cs[0]+"Txt_FromTime").value=="")
      {
         alert('Please Enter Tour From Time Correctly..!!');
         document.getElementById(cs[0]+"Txt_FromTime").value="00:00 am";
         document.getElementById(cs[0]+"Txt_FromTime").focus();
         return false;
      }
      if(document.getElementById(cs[0]+"Txt_ToTime").value=="00:00 am" || document.getElementById(cs[0]+"Txt_ToTime").value=="")
      {
         alert('Please Enter Tour To Time Correctly..!!');
         document.getElementById(cs[0]+"Txt_ToTime").value="00:00 am";
         document.getElementById(cs[0]+"Txt_ToTime").focus();
          return false;
      }
      var mm;
      mm=checkb();
      if(mm==false)
      {  return false;}
   }
   else
   {
      return false;
   }
}
function Fill_Dateto(a)
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
   if(document.getElementById(cs[0]+a).value!="")
   {
    var value1 = document.getElementById(cs[0]+a).value;
    var dt = new Date().format("dd/MMM/yyyy");
    var value2=dt;
    
    day1= value1.substring (0, value1.indexOf ("/"));
    month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
    year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

    day2= value2.substring (0, value2.indexOf ("/"));
    month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
    year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);
// 
    date1 = year1+"/"+month1+"/"+day1;
    date2 = year2+"/"+month2+"/"+day2;
    
    firstDate = Date.parse(date1)
    secondDate= Date.parse(date2)
    

    msPerDay = 24 * 60 * 60 * 1000
    
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    
// if(dbd > 2)
// {
//   alert("Tour Cannot be Apply less than 2 days from system date..!!")
//   document.getElementById(cs[0]+a).value="";
//   document.getElementById(cs[0]+a).focus();
//   return false;
// }
}
}
function Fill_Dateboth()
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
   if(document.getElementById(cs[0]+"Txt_fdt").value!="" && document.getElementById(cs[0]+"Txt_tdt").value!="")
   {
    var value1 = document.getElementById(cs[0]+"Txt_fdt").value;
    //var dt = new Date().format("dd/MMM/yyyy");
    //var value2=dt;
    var value2=document.getElementById(cs[0]+"Txt_tdt").value;
    
    day1= value1.substring (0, value1.indexOf ("/"));
    month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
    year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

    day2= value2.substring (0, value2.indexOf ("/"));
    month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
    year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);
// 
    date1 = year1+"/"+month1+"/"+day1;
    date2 = year2+"/"+month2+"/"+day2;
    
    firstDate = Date.parse(date1)
    secondDate= Date.parse(date2)
    

    msPerDay = 24 * 60 * 60 * 1000
    
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    
 if(dbd<0)
 {
   alert("Tour From Date is Greater Than Tour To Date.Please Make it Correct ..!!")
   document.getElementById(cs[0]+"Txt_fdt").value="";
   document.getElementById(cs[0]+"Txt_tdt").value="";
   document.getElementById(cs[0]+"Txt_fdt").focus();
   return false;
 }
 else
 {
  return true;
 }
}
}
// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 818px; height: 390px;">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #cc0033"><span style="font-weight: bold;
                        font-size: 14pt; font-family: 'Courier New'; text-decoration: underline">TOUR APPLICATION</span>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:calendarextender>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_tdt"></cc1:calendarextender>
                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_place">
                        </cc1:ListSearchExtender>
                        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</span></strong>
                    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="Cmb_Select">
                    </cc1:ListSearchExtender>
                    </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="2" style="text-align: left">
                    <strong><span style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">SELECT EMPLOYEE</span></strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="Cmb_Select" runat="server" Width="420px" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>
            <tr style="color: #000000">
                <td colspan="2" style="text-align: left">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                EMPLOYEE CODE &amp; NAME</span></td>
                <td colspan="2" style="text-align: left">
                                <input id="Txt_emp" readonly="readonly" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 257px;" type="text" runat="server" /></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 584px; text-align: left">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    DEPARTMENT</span></td>
                <td style="width: 260px; text-align: left;">
                    <input id="Txt_dep" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 161px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    DESIGNATION</span></td>
                <td style="width: 161px; text-align: left;">
                    <input id="Txt_des" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 584px; height: 13px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    BRANCH</span></td>
                <td style="width: 260px; text-align: left; height: 13px;">
                    <input id="Txt_br" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
               <td style="width: 161px; height: 13px; text-align: left;">
                   <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    POST</span></td>
                <td style="width: 161px; text-align: left; height: 13px;">
                    <input id="Txt_post" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 23px">
                    <strong style="font-weight: bold; font-size: 13pt; font-family: 'Courier New'">TOUR DETAILS&nbsp; &nbsp; &nbsp; </strong>
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 584px; height: 7px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">FROM DATE</span></td>
                <td style="width: 260px; height: 7px; text-align: left;">
                    <asp:TextBox ID="Txt_fdt"  runat="server" Width="117px" onkeyPress="return clr('Txt_fdt')" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
                <td style="width: 161px; height: 7px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TO DATE</span></td>
                <td style="width: 161px; height: 7px; text-align: left;">
                    <asp:TextBox ID="Txt_tdt" onchange="return Fill_Dateto('Txt_tdt')" runat="server" Width="119px" onkeyPress="return clr('Txt_tdt')" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 584px; height: 23px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">FROM TIME</span></td>
                <td style="width: 260px; height: 23px; text-align: left">
                    <input id="Txt_FromTime" onchange="return validatetime(cs[0]+'Txt_FromTime')" maxlength="9" style="width: 117px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
                <td style="width: 161px; height: 23px; text-align: left;">
                    <span style="font-size: 12pt; font-weight: normal; font-family: 'Courier New';">TO TIME</span></td>
                <td style="width: 161px; height: 23px; text-align: left">
                    <input id="Txt_ToTime" onchange="return validatetime(cs[0]+'Txt_ToTime')" maxlength="9" style="width: 119px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 584px; height: 14px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TOUR PLACE</span></td>
                <td style="width: 260px; height: 14px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">
                    <asp:CheckBox ID="chk_br" onclick="check1()" runat="server" Font-Bold="False" Text="BRANCH" Checked="True" Font-Size="Small" />
                    <asp:CheckBox ID="chk_oth" onclick="check2()" runat="server" Font-Bold="False" Text="OTHERS" Font-Size="Small" /></td>
                <td style="width: 161px; height: 14px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    TOUR ADVANCE Rs&nbsp;</span>
                </td>
                    <td style="width: 161px; height: 14px; text-align: left" ><asp:TextBox ID="Txt_adv" onkeyup="return change('Txt_adv')"  runat="server" Width="119px" MaxLength="9" Font-Size="Medium" style="font-family: 'Courier New'">0</asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 584px; height: 10px; text-align: left;" id="row2">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TOUR PLACE</span></td>
                <td style="width: 260px; text-align: left; height: 10px;">
                    <asp:DropDownList ID="cmb_place" runat="server" Width="254px" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
                <td style="width: 161px; height: 10px; text-align: left;" id="row1">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    OTHER PLACE</span></td>
                <td style="width: 161px; text-align: left; height: 10px;">
                    <asp:TextBox ID="Txt_oth" onkeypress="return isNumberKey(2)" runat="server" Width="251px" MaxLength="50" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';
                    text-align: left; width: 584px;">
                                TOUR PURPOSE</td>
                <td colspan="4" style="height: 24px; text-align: left">
                                <asp:TextBox ID="Txt_purp" onkeypress="return isNumberKey(2)" runat="server" Width="411px" MaxLength="80" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">INSPECTION</asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 39px">
                    <div style="text-align: center">
                    </div>
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px; height: 26px;">
                                    <asp:Button ID="cmd_appl" runat="server" Text="Apply" Width="99px" /></td>
                                <td style="width: 55px; height: 26px; cursor: hand; font-family: 'Courier New';">
                    <asp:Button ID="cmd_confirm" OnClientClick="return tourcliclick()" runat="server" Text="Sanction" Width="97px" Height="27px" style="cursor: hand; font-family: 'Courier New'" /></td>
                                <td style="width: 81px; height: 26px;">
                                    <asp:Button ID="cmd_Recommend" OnClientClick="return tourcliclick()" runat="server" Height="27px" Style="cursor: hand; font-family: 'Courier New'"
                                        Text="Recommend" Width="97px" /></td>
                                <td style="width: 100px; height: 26px; text-align: left;">
                                    <input id="Cmd_Exit" style="width: 97px; height: 27px; cursor: hand; font-family: 'Courier New';" type="button" value="Exit" onclick="return Cmd_Exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

