<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_apply.aspx.vb" Inherits="WebAppHRMS.november_tour_Tour_apply_d1bb416e4757" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>


<script language="javascript" type="text/javascript">
// <!CDATA[


var cs = cont_name.split("Txt");
function change(a) {
//debugger;
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

function window_onload() 
{
document.getElementById(cs[0]+"Txt_oth").style.display="none";
document.getElementById("row1").style.display="none";
document.getElementById(cs[0]+"Txt_FromTime").value="00:00 am";
document.getElementById(cs[0]+"Txt_ToTime").value="00:00 am";
document.getElementById(cs[0]+"Txt_oth").value="";
}

function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}

function clr(b)
{
 alert("please select the date");
 document.getElementById(cs[0]+b).value="";
 return false;
}
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
            fhr=fall[0];
            fmin=fall[1];
            fampm=fsub[1];
            
            var tall,tsub,thr,tmin,tampm;
            tall=ttime.split(":");
            tsub=ttime.split(" ");
            thr=tall[0];
            tmin=tall[1];
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

//==-==-==-=-==--=--==-=-=-=-=--=-=-----=-=-=--=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
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
    
// if(dbd>2)
// {
//   alert("Tour Cannot be Apply 2 days less than system date...!!")
//   document.getElementById(cs[0]+a).value="";
//   document.getElementById(cs[0]+a).focus();
//   return false;
// }
}
}
function Fill_Dateto1(a)
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
    
// if(dbd>2)
// {
//   alert("Tour Cannot be Apply 2 days less than system date..!!")
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
        <table border="1" style="width: 800px; height: 362px;">
            <tr>
                <td colspan="4" style="height: 44px; text-align: center;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <strong><span style="text-decoration: underline">TOUR APPLICATION</span></strong>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:calendarextender>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_tdt"></cc1:calendarextender>
                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_place">
                        </cc1:ListSearchExtender>
                    </span></strong>
                    </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                EMPLOYEE CODE &amp; NAME</span></td>
                <td colspan="2" style="text-align: left">
                                <input id="Txt_emp" readonly="readonly" style="width: 391px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 155px; text-align: left">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    DEPARTMENT</span></td>
                <td style="width: 175px; text-align: left;">
                    <input id="Txt_dep" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="text-align: left; width: 132px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    DESIGNATION</span></td>
                <td style="width: 161px; text-align: left;">
                    <input id="Txt_des" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 155px; height: 13px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    BRANCH</span></td>
                <td style="width: 175px; text-align: left; height: 13px;">
                    <input id="Txt_br" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
               <td style="height: 13px; text-align: left; width: 132px;">
                   <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    POST</span></td>
                <td style="width: 161px; text-align: left; height: 13px;">
                    <input id="Txt_post" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px; text-align: center;">
                    <strong style="font-weight: bold; font-size: 14pt; font-family: 'Courier New'">&nbsp;
                        &nbsp; &nbsp;TOUR DETAILS&nbsp; &nbsp; &nbsp; </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 155px; height: 23px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TOUR FROM</span></td>
                <td style="width: 175px; height: 23px; text-align: left;">
                    <asp:TextBox ID="Txt_fdt"  runat="server" Width="117px" onkeyPress="return clr('Txt_fdt')" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
                <td style="height: 23px; text-align: left; width: 132px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TOUR TO</span></td>
                <td style="width: 161px; height: 23px; text-align: left;">
                    <asp:TextBox ID="Txt_tdt" onchange="return Fill_Dateto('Txt_tdt')" runat="server" Width="119px" onkeyPress="return clr('Txt_tdt')" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 155px; height: 8px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">FROM TIME</span></td>
                <td style="width: 175px; height: 8px; text-align: left">
                    <input id="Txt_FromTime" onchange="return validatetime(cs[0]+'Txt_FromTime')" runat="server" maxlength="9" style="width: 117px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                <td style="height: 8px; text-align: left; width: 132px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TO TIME</span></td>
                <td style="width: 161px; height: 8px; text-align: left">
                    <input id="Txt_ToTime" onchange="return validatetime(cs[0]+'Txt_ToTime')" runat="server" maxlength="9" style="width: 117px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 155px; height: 5px; text-align: left;">
                    <span style="font-size: 11pt; font-family: 'Courier New'; font-weight: normal;">TOUR PLACE</span></td>
                <td style="text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">
                    <asp:CheckBox ID="chk_br" onclick="check1()" runat="server" Font-Bold="False" Text="BRANCH" Checked="True" />
                    <asp:CheckBox ID="chk_oth" onclick="check2()" runat="server" Font-Bold="False" Text="OTHERS" /></td>
                <td style="height: 5px; text-align: left; width: 132px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    TOUR&nbsp;ADVANCE&nbsp;Rs&nbsp;</span>
                </td>
                <td style="width: 161px; height: 5px; text-align: left">
                    <asp:TextBox ID="Txt_adv" onkeyup="return change('Txt_adv')" runat="server" Width="117px" MaxLength="9" Font-Size="X-Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox>
                  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_adv"
                        Display="Dynamic" ErrorMessage="Invalid Amount" SetFocusOnError="True"
                        ValidationExpression="^\d+(\.\d\d)?$" Width="242px" Font-Size="Medium"></asp:RegularExpressionValidator></td>
--%>            </tr>
            <tr>
                <td style="width: 155px; height: 9px; text-align: left;" id="row2">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">TOUR PLACE</span></td>
                <td style="width: 175px; text-align: left; height: 9px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">
                    <asp:DropDownList ID="cmb_place" runat="server" Width="254px" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList>&nbsp;</td>
                <td style="height: 9px; text-align: left; width: 132px;" id="row1">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                    OTHER PLACE</span></td>
                <td style="width: 161px; text-align: left; height: 9px;">
                    <asp:TextBox ID="Txt_oth" runat="server" Width="237px"  onkeypress="return isNumberKey(2)" MaxLength="50" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="font-weight: normal; font-size: 11pt; width: 155px; font-family: 'Courier New';
                    text-align: left;">
                                TOUR PURPOSE
                </td>
                <td colspan="4" style="height: 28px; text-align: left">
                                <asp:TextBox ID="Txt_purp" runat="server" onkeypress="return isNumberKey(2)" Width="393px" MaxLength="80" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 39px">
                    <div style="text-align: center">
                    </div>
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" OnClientClick="return tourcliclick()" runat="server" Text="CONFIRM" Width="105px" Height="29px" /></td>
                                <td style="width: 100px">
                                    <input id="Cmd_Exit" style="width: 105px; height: 29px;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

