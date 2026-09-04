<%@ Page Language="VB"  MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Movementslip_macom.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_Movementslip_mfdtn_494216743145" title=""  %>
<%--onchange="return validatetime(cs[0]+'Txt_FromTime')"--%> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<%--<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>--%>



<script language="javascript" type="text/javascript">
function  checken() 
{
  var now = new Date();
  var val = document.getElementById("Txt_FromTime").value;
  var dt = (now.getMonth()+1) + "/" + now.getDate() + "/" + now.getFullYear() + " " + val;
  var valDt = new Date(dt);
  var res = (valDt > now);
  if (res)
    document.getElementById("result").innerHTML = "val is greater";
  else
    document.getElementById("result").innerHTML = "val is less or equal";
}

//function mov()
//{
//   var msg="****** PERSONAL MOVEMENT ONLY 3 HOUR PER MONTH *******"
//   var disp="<MARQUEE style=WIDTH: 608px; HEIGHT: 19px bgColor=antiquewhite><STRONG><FONT color=black>" + msg +"</FONT></STRONG></MARQUEE>"
//   document.getElementById("lbl_mov").innerHTML=disp
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
//return window_onload()
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

//function Cmd_Exit_onclick() 
//{
// window.open('../home.aspx','_self');
//}



//=-=-=-=-=--=-=--=-=-=-=-=-==-=-===Time  using Text Box==-=--=-=-=-=-=-==--=-==-=-=-=--=
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
   alert("invlalid time. A column(:) is missing between hour and minute.");
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
 
        function blockSpecialChar(e) {
        var k;
        document.all ? k = e.keyCode : k = e.which;
        return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || (k >= 48 && k <= 57));
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
</script>

 <div style="text-align: center" >
        <table  border="1" style="margin:0px auto;" >
            <tr>
                <td colspan="4" style="height: 41px; text-align: center;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                        <strong><span style="text-decoration: underline">MOVEMENT APPLICATION</span></strong>
                        </span></span></span>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:calendarextender>
                    </span></strong>
                     <tr>
             <td colspan="4" style="height: 22px; text-align: center">
               <marquee behavior="scroll" direction="left"> ******* PERSONAL MOVEMENT ONLY 3 HOUR PER MONTH AND 1 HOUR PER DAY *******  </marquee>
             <asp:Label ID="lbl_mov" runat="server" Font-Bold="True" ForeColor="Black" Width="100%"></asp:Label>
            
            </td>
            
                    </td>
            </tr>
            
           
            
            
            
            <tr>
                <td colspan="4" style="height: 22px; text-align: center">
                    <div style="text-align: center">
                        &nbsp;</div>
                    <table border="1" style="width: 648px; height: 79px;">
                        <tr>
                            <td style="width: 156px; height: 29px; text-align: left">
                                <span style="font-size: 11pt; font-family: Courier New"><strong>
                                EMPLOYEE&nbsp;CODE&nbsp;NAME</strong></span></td>
                            <td colspan="3" style="height: 29px; text-align: left">
                                <input id="Txt_emp" readonly="readonly" style="width: 571px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
                        </tr>
                        <tr>
                <td style="width: 156px; text-align: left; height: 27px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                    DEPARTMENT</strong></span></td>
                <td style="width: 175px; text-align: left; height: 27px;">
                    <input id="Txt_dep" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 239px;" type="text" readonly="readOnly" /></td>
                <td style="text-align: left; width: 69px; height: 27px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                    DESIGNATION</strong></span></td>
                <td style="width: 153px; text-align: left; height: 27px;">
                    <input id="Txt_des" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" /></td>
                        </tr>
                        <tr>
                <td style="width: 156px; height: 13px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                    BRANCH</strong></span></td>
                <td style="width: 175px; text-align: left; height: 13px;">
                    <input id="Txt_br" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 241px;" type="text" readonly="readOnly" /></td>
               <td style="height: 13px; text-align: left; width: 69px;">
                   <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                    POST</strong></span></td>
                <td style="width: 153px; text-align: left; height: 13px;">
                    <input id="Txt_post" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 14px; text-align: center;">
                    <strong style="font-weight: bold; font-size: 14pt; font-family: 'Courier New'">&nbsp;<span style="font-family: Agency FB">
                        MOVEMENT DETAILS&nbsp; </span>
                        &nbsp; &nbsp; </strong>
                </td>
            </tr>
           <%-- <tr style="color: #000000">
                <td colspan="4" style="height: 15px; text-align: center"><table border="1" style="width: 762px; height: 79px;">
                  
                  <%-- <tr>
                        <td style="width: 52px; text-align: left; height: 17px;">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                                EMPLOYEE IMAGE</strong></span></td>
                        <td style="text-align: left; height: 17px;" colspan="3">
                            <%--<input id="Txt_fdt" runat="server" Autopostback="True"style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" />--%>
                           <%-- <asp:TextBox ID="txt_img"  runat="server" Width="473px"  Autopostback="True" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; height:279px;">
                           
                            </asp:TextBox> --%><%--<img style="display :none; width: 254px;" id="imgCapture" onclick="return imgCapture_onclick()"/>
                           
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
                    </tr>--%>
                  
               <%--   </table>--%>
                  
                   <tr style="color: #000000">
                <td colspan="4" style="height: 15px; text-align: center"><table border="1" style="width: 762px; height: 79px;">
                  
                  
                  
                    <tr>
                        <td style="width: 193px; text-align: left; height: 27px;">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                                MOVEMENT DATE</strong></span></td>
                        <td style="text-align: left; height: 27px;" colspan="3">
                            <%--<input id="Txt_fdt" runat="server" Autopostback="True"style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" />--%>
                            <asp:TextBox ID="Txt_fdt"  runat="server" Width="147px"  Autopostback="True" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox>
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
                    </tr>
                     <tr>
                            <td style="width: 193px; text-align: left;width: 554px; height: 13px;">
                            
                            <span style="font-size: 11pt;font-weight:normal; font-family: 'Courier New';"><strong>MOVEMENT TYPE&nbsp;</strong></span></td>
                      
                            <td colspan="3" style="height: 13px; text-align: left">
                            <asp:DropDownList ID="ddl_movtype"   runat="server" Width="214px" >
                               
                               
                            </asp:DropDownList></td>
                            
                       
                            
                    </tr>
                  
                    
                    
                <tr>
                <td style="width: 155px; height: 8px; text-align: left;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                        EXIT TIME</strong></span></td>
                <td style="width: 175px; height: 8px; text-align: left">
                 <asp:TextBox ID="Txt_FromTime" runat="server" Width="117px" Autopostback="true"  MaxLength="8" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox>
<%--                    <input id="Txt_FromTime" onchange="return validatetime(cs[0]+'Txt_FromTime')" runat="server" maxlength="9" style="width: 117px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" />--%></td>
                <td style="height: 8px; text-align: left; width: 132px;">
                    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                        ENTRY TIME</strong></span></td>
                <td style="width: 161px; height: 8px; text-align: left">
                    
                   <asp:TextBox ID="Txt_ToTime" runat="server" Width="117px" Autopostback="true" MaxLength="8" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox></td>
            </tr>
             <tr>
                        <td style="width: 193px; height: 13px; text-align: left;">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                                TOTAL TIME </strong></span>
                        <%--  <asp:Label ID="Label1"  runat="server" Text="Invaled time" Visible="false"></asp:Label>--%>
                        </td>
                        <td style="text-align: left; height: 13px;" colspan="3">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                <asp:TextBox ID="Txt_tot_time" runat="server" onkeypress="return isNumberKey(2)" Width="117px" MaxLength="9" style="font-weight: normal; font-size: 11pt;font-family: 'Courier New'" Height="29px"></asp:TextBox></span></td>
                    </tr>
                    <tr>
                        <td style="width: 193px; text-align: left">
                            <strong><span style="font-size: 11pt; font-family: Courier New">PLACE</span></strong></td>
                        <td colspan="3" style="text-align: left">
                        
                          <asp:TextBox ID="Txtplace" runat="server"  Width="537px" MaxLength="60" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox></span></td>
                           <%-- <input id="Txtplace" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 241px;" type="text"  /></td>--%>
                    </tr>
          
                    <tr>
                        <td style="width: 193px; height: 13px; text-align: left;">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
                                MOVEMENT&nbsp;PURPOSE </strong></span>
                        </td>
                        <td style="text-align: left; height: 13px;" colspan="3">
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                <asp:TextBox ID="Txt_purp" runat="server"  Width="537px" MaxLength="60" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox></span></td>
                    </tr>
                    <tr>
                        <td style="width: 193px; height: 13px; text-align: left">
                            <strong><span style="font-size: 11pt; font-family: Courier New">SELECT RECOMMENDER&nbsp;</span></strong></td>
                        <td colspan="3" style="height: 13px; text-align: left">
                            <asp:DropDownList ID="ddltl" runat="server" Width="214px">
                            </asp:DropDownList></td>
                          <%-- <td style="text-align: left; height: 27px; width: 9px;" colspan="3" id="TD1" runat="server">--%>
                            <%--<input id="Txt_fdt" runat="server" Autopostback="True"style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" />--%>
                               &nbsp;<span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
                   
                    </tr>
                    <tr>
                        <td style="width: 193px; height: 13px; text-align: left">
                            <span style="font-size: 11pt; font-family: Courier New"><strong>SELECT APPROVER&nbsp;</strong></span></td>
                        <td colspan="3" style="height: 13px; text-align: left">
                            <asp:DropDownList ID="ddlapp" runat="server" Width="214px">
                            </asp:DropDownList></td>
                    </tr>
                </table>
             
           
            <tr style="color: #000000">
                <td colspan="4" style="height: 39px">
                   <div style="text-align: center">
                    </div>
                    <div style="text-align: center">
                        &nbsp;<table>
                            <tr>
                                <td style="width: 100px">
                                <center>
                                 <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="105px" Height="29px" /></center></td>
                                <td style="width: 100px"><center/>
                                 <asp:Button ID="Cmd_Exit" runat="server" Text="EXIT" Width="111px" Height="29px" /></td>
                                   <%-- <input id="Cmd_Exit" style="width: 105px; height: 29px;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></center></td> --%>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
     
    </div>
</asp:Content>






