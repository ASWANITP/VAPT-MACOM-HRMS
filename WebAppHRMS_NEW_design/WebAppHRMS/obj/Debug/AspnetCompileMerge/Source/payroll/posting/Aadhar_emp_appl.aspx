<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Aadhar_emp_appl.aspx.vb" Inherits="WebAppHRMS.test_Aadhar_emp_appl_aba36d805593"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
<script src="http://code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src = "https://ajax.googleapis.com/ajax/libs/jQuery/3.5.1/jQuery.min.js" type="text/javascript"></script>
<%--<script type="text/javascript">--%> 
<script language="javascript" type="text/javascript">
// <!CDATA[
//var cont=loanno.split("txt")

//var okyc;
//var cs = cont_name.split("txt");

function Button1_onclick() 
{
    window.open('../../home.aspx','_self')
}


function adhar()
{
debugger;
   if (document.getElementById(cont[0]+"Rado_ad").checked==true)
   {

     
    document.getElementById(cont[0]+"cmd_confirm").disabled=false;

   }
}

//function filleditdata()
//{
//    if (document.getElementById(cont[0]+"txt_appln_no").value!='') 
//    {
//        document.getElementById(cont[0]+"cmd_edit").disabled=true;
//        call_server("9$" + document.getElementById(cont[0]+"txt_appln_no").value,9); 
//    }
//}

//function clearDropDown(dropDownbox) {   

//    var theDropDown = document.getElementById(cont[0]+dropDownbox) 
//    var numberOfOptions = theDropDown.options.length  
//    for (i=0; i<numberOfOptions; i++) 
//    {      
//     //Note: Always remove(0) and NOT remove(i) ; Remove zero' th position of the dropdownbox'  
//     theDropDown.remove(0)  
//    }  
//}  


//function Button2_onclick() {
//debugger;

//    if  (document.getElementById("Checkbox3").checked==true)
//    {
////    clearDropDown("cmb_perm_district")
////    clearDropDown("cmb_perm_post")
////    clearDropDown("cmb_perm_state")
//    
//     //$("[id*=txt_name]").val(okyc.poi.name);
//     $("[id*=txt_Perm_hs_name]").val($("[id*=txt_Perm_hs_select]").val(okyc.poi.name));
//     debugger;
////     document.getElementById("txt_Perm_hs_name").value= document.getElementById("txt_Perm_hs_select").value;
////     document.getElementById("txt_perm_pin").value=document.getElementById("Txt_pin_select").value;
////     document.getElementById("txt_perm_pin").value=document.getElementById("Txt_pin_select").value;
////     var option1   = document.createElement("OPTION");
////                            option1.value = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
////                            option1.text  = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].text;
////                            document.getElementById(cont[0]+"cmb_perm_state").add(option1);
////     var option2   = document.createElement("OPTION");
////                            option2.value = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;
////                            option2.text  = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].text;
////                            document.getElementById(cont[0]+"cmb_perm_district").add(option2);
////     var option3   = document.createElement("OPTION");
////                            option3.value = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
////                            option3.text  = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].text;
////                            document.getElementById(cont[0]+"cmb_perm_post").add(option3);
//                            
//     document.getElementById("hid_perm_state").value=document.getElementById("cmb_state_select").options[document.getElementById("cmb_state_select").selectedIndex].value;
//     document.getElementById("hid_perm_district").value=document.getElementById("cmb_dist_select").options[document.getElementById("cmb_dist_select").selectedIndex].value;        
//     document.getElementById("hid_perm_post").value=document.getElementById("cmb_post_select").options[document.getElementById("cmb_post_select").selectedIndex].value;
//                            
//    }
//        
//    if  (document.getElementById("Checkbox4").checked==true)
//    {
//     document.getElementById("txt_Pres_hs_name").value= document.getElementById("txt_Perm_hs_select").value;
//     document.getElementById("txt_pres_pin").value=document.getElementById("Txt_pin_select").value;
//     
////     clearDropDown("cmb_pres_district")
////     clearDropDown("cmb_pres_post")
////     clearDropDown("cmb_pres_state")
////    
////      var option1   = document.createElement("OPTION");
////                            option1.value = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
////                            option1.text  = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].text;
////                            document.getElementById(cont[0]+"cmb_pres_state").add(option1);
////     var option2   = document.createElement("OPTION");
////                            option2.value = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;
////                            option2.text  = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].text;
////                            document.getElementById(cont[0]+"cmb_pres_district").add(option2);
////       var option3   = document.createElement("OPTION");
////                           option3.value = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
////                            option3.text  = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].text;
////                             document.getElementById(cont[0]+"cmb_pres_post").add(option3);
//                            
//     document.getElementById("hid_pres_state").value=document.getElementById("cmb_state_select").options[document.getElementById("cmb_state_select").selectedIndex].value;
//     document.getElementById("hid_pres_district").value=document.getElementById("cmb_dist_select").options[document.getElementById("cmb_dist_select").selectedIndex].value;        
//     document.getElementById("hid_pres_post").value=document.getElementById("cmb_post_select").options[document.getElementById("cmb_post_select").selectedIndex].value;
//    }
//}


function Checkbox3_onclick() {
debugger;
    if  (document.getElementById("ctl00_cph_edp_Checkbox3").checked==true)
    {
      document.getElementById('ctl00_cph_edp_Checkbox4').checked=false;
      document.getElementById("ctl00_cph_edp_Checkbox3").checked=true;
    }
    if  (document.getElementById("ctl00_cph_edp_Checkbox3").checked==false)
    {
      document.getElementById("ctl00_cph_edp_Checkbox3").checked=false;
      document.getElementById("ctl00_cph_edp_Checkbox4").checked=true;
    }
}

function Checkbox4_onclick() {
    if  (document.getElementById("ctl00_cph_edp_Checkbox4").checked==true)
    {
      document.getElementById("ctl00_cph_edp_Checkbox3").checked=false;
      document.getElementById("ctl00_cph_edp_Checkbox4").checked=true;
    }
    if  (document.getElementById("ctl00_cph_edp_Checkbox4").checked==false)
    {
      document.getElementById("ctl00_cph_edp_Checkbox4").checked=false;
    }
}

function val_adr()
{
debugger;
//var r_adhar=document.getElementById("txt_adhar").value;
var r_adharq = $("#ctl00_cph_edp_txt_adhar").val();
    if (r_adharq == '' || r_adharq.length!= 12)
      
     { 
     alert('Please Enter Valid Aadhar Number!'); 
    return; 
    }
}


function calculateAge(birthDate) {
    const today = new Date();
    const birth = new Date(birthDate);
    let age = today.getFullYear() - birth.getFullYear();
    const monthDifference = today.getMonth() - birth.getMonth();

    // Adjust age if the current month and day are before the birth month and day
    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birth.getDate())) {
        age--;
    }

    return age;
}


 function DeleteKartItems() 
   {     
   debugger;
  var r_adhar = $("#ctl00_cph_edp_txt_adhar").val();
    console.log("1st log");
    $.ajax({
        type: 'POST',
        url: 'https://testing.net.in/MacaadharAPI/api/Aadhar/Aadharcheck',
        data: "{aadharID:'" + r_adhar + "'}",
        async: true,
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Result) {
           
        
        debugger;
		var okyc;
            res = Result;
            debugger;
			            if (res.status == "FAIL") {
            alert('OTP Validation Failed!');
            }
            if (res.data.response_status.status == "SUCCESS") {
            debugger;
            alert('OTP Validated successfully!');
           okyc=res.data.result.offlinePaperlessKyc.uidData;


 $("[id*=txt_name]").val(okyc.poi.name);
  $("[id*=txt_Perm_hs_select]").val(okyc.poa.house);
  $("[id*=Text_state]").val(okyc.poa.state);
  // $("[id*=cmb_state_select]").val(okyc.poa.state);
 //$("#ddlFirm option:selected").val();
     $("[id*=Text_dist]").val(okyc.poa.dist);
     $("[id*=Text_post]").val(okyc.poa.po);
     $("[id*=Txt_pin_select]").val(okyc.poa.pc); 
      $("[id*=txt_lankmark]").val(okyc.poa.landmark);
       //$("[id*=txt_dob]").val(okyc.poi.dob);
       
       
       var dates=okyc.poi.dob;
const days=dates.split('-');
var months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec']
//var formattedDate = getDateString('15/12/2024', "d-M-y");
var dayss=days[0]+'/'+months[days[1]-1] +'/'+days[2];
$("[id*=txt_dob]").val(dayss);
debugger;
var a=calculateAge(dayss);
$("[id*=txt_age]").val(a);


       
//      debugger;
//      var dddd=okyc.poi.dob;
//      var  cm=okyc.poi.dob.format("dd/mm/yyyy");
//      debugger;
//      let options = [{day: 'numeric'}, {month: 'short'}, {year: 'numeric'}];
//      let joined=IsValidDate(dddd);
//let joined = join(dddd, options, '-');
      //var dob = DateTime.ParseExact(okyc.poi.dob , dd/MM/yy ,CultureInfo.InvariantCulture,DateTimeStyles.None).ToString(dd-MMM-yyyy)
//       $("[id*=txt_dob]").val(joined);
//       debugger;
     //Output = DateTime.ParseExact(yourDate , dd/MM/yy ,CultureInfo.InvariantCulture,DateTimeStyles.None).ToString(�dd-MMM-yyyy�)
 
            //$("#txt_name").val(okyc.poi.name);
          
//             $("#Txname").val(okyc.poi.name);
            
            }
            else {
                alert("Failed to verify Aadhar! Mobile Number not registered with this Aadhar ID");
            }
        },
        error: function (xhr, status, exception) {
            alert("Here inside error");
            alert(xhr.status + ': ' + xhr.statusText);
        }
    });
      let person = prompt("Please enter OTP", "");
      
      
      validateAadharOTP(person);
      
      
   }
   
   
//  function IsValidDate(myDate) {
//                var filter = /^([012]?\d|3[01])-([Jj][Aa][Nn]|[Ff][Ee][bB]|[Mm][Aa][Rr]|[Aa][Pp][Rr]|[Mm][Aa][Yy]|[Jj][Uu][Nn]|[Jj][u]l|[aA][Uu][gG]|[Ss][eE][pP]|[oO][Cc]|[Nn][oO][Vv]|[Dd][Ee][Cc])-(19|20)\d\d$/
//                                return filter.test(myDate);
//            } 
//   
//   function join(date, options, separator) {
//   function format(option) {
//      let formatter = new Intl.DateTimeFormat('en', option);
//      return formatter.format(date);
//   }
//   return options.map(format).join(separator);
//}

   
//   changeFormate(date) {
//let month_names = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
//let incomingDateChnge: any = new Date(date);
//let incomingDay = incomingDateChnge.getDate();
//let incomingMonth = incomingDateChnge.getMonth();

//let incomingYear = incomingDateChnge.getFullYear();
//if (incomingDay < 10) {
//  incomingDay = '0' + incomingDay;
//}

//incomingDateChnge = incomingDay + ' ' + month_names[incomingMonth] + ' ' + incomingYear;
//return incomingDateChnge;
// }


//    Date.prototype.toShortFormat = function() {

//    const monthNames = ["Jan", "Feb", "Mar", "Apr",
//                        "May", "Jun", "Jul", "Aug",
//                        "Sep", "Oct", "Nov", "Dec"];
//    
//    const day = this.getDate();
//    
//    const monthIndex = this.getMonth();
//    const monthName = monthNames[monthIndex];
//    
//    const year = this.getFullYear();
//    
//    return `${day}/${monthName}/${year}`;  
//}
//    
    function validateAadharOTP(person) {
    debugger;
    console.log("2nd log");
    console.log(person);
    
    var r_adhar = $("#ctl00_cph_edp_txt_adhar").val();
//    var otp1 = document.getElementById("tx").value;
       var otp1=person;
    $.ajax({
        type: "POST",
        //url: 'http://localhost:11027/api/Aadhar/Aadharotpcheck',
        url: 'https://testing.net.in/MacaadharAPI/api/Aadhar/Aadharotpcheck',
        data: "{aadharID:'" + r_adhar + "',otp: '" + otp1 + "'}",
        async: false,
        cache: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Result) {
        debugger;
            Result = Result.responseMsg;
            if (Result == "Success") {
                //alert('OTP Validated successfully!');
                console.log("Verifying OTP!");
            }
            else {
                //alert('Invalid OTP!');
                console.log("Verifying OTP!!");
            }
        },
        error: function () {
            alert('Invalid Entry!');
        }
    });
}

//function Button2_onclick() {

//}



// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%-- <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_dob"></cc1:calendarextender>--%>
 
    <table id="tab_01" border="1" style="width:80%" align="center">
        <tr>
           <%-- <td colspan="1" style="height: 27px; text-align: right; width: 233px;">
                <input id="rdb_new" runat="server"  name="aaa" type="radio" style="color: #ff0066" onclick="return hiderow6()"/><span
                    style="font-size: 14pt; color: #ff0066">New
                Application &nbsp; &nbsp; </span>
            </td>--%>
           <%-- <td colspan="1" style="height: 27px; text-align: left; width: 311px;">
                &nbsp;&nbsp;
                <input id="rdb_edit" runat="server" name="aaa" type="radio" style="color: #ff0066" onclick="return hiderow6()"/><span
                    style="color: #ff0066"> <span style="font-size: 14pt">
                Edit Application</span></span></td>--%>
         <%--   newly  --%> 
         
         
         
           <td colspan="4" style="height: 27px; text-align: left">
                &nbsp;&nbsp;
                <input id="Rado_ad" runat="server" name="aaa" type="radio" style="color: #ff0066" onclick="return adhar()"/><span
                    style="color: #ff0066"> <span style="font-size: 14pt">
                Aadhar Application</span></span></td>
                
                
        </tr>
      <%--  <tr id ="row6" style="display:none">
            <td colspan="2" style="height: 10px; text-align: right">
                Enter Application No :</td>
            <td colspan="2" style="height: 10px; text-align: left">
                <input id="txt_Appln_no" maxlength="10" style="width: 162px; font-family: Verdana;" type="text" onchange="return filleditdata()" runat="server"/></td>
        </tr>--%>
        
            <tr id ="Tr1">
            <td colspan="1" style="height: 10px; text-align: left; width: 233px;">
                Enter Aadhar No :</td>
            <td id="Td1" colspan="3" style="height: 10px; text-align: left" runat="server">
                <input id="txt_adhar" maxlength="12" style="width: 319px; font-family: Verdana;" type="text" runat="server" onchange="return val_adr()"/></td>
                
           
                
                
              
        </tr>
        <tr>
            <td colspan="1" style="text-align: left; height: 28px; width: 233px;">
                Name  <span style="color: #000000"></span><span style="color: #ff0000">
                    </span><span style="color: #ff0000"><span style="color: #000000"> </span><span
                        style="color: #000000"></span></span></td>
            <td colspan="3" style="text-align: left; height: 28px;">
                <input id="txt_name" runat="server" maxlength="75" style="width: 319px; font-family: Verdana;" type="text" readonly="readonly" /></td>
        </tr>
        
        
       
         <tr id ="Tr2">
            <td colspan="1" style="height: 10px; text-align: right; width: 233px;">
              </td>
            <td colspan="1" style="height: 10px; text-align: left">
                <input id="get_otp" value="GET OTP"  style="width: 162px; font-family: Verdana;" type="button" runat="server" onclick="return DeleteKartItems()"/></td>
                
           
                
                
        </tr>
        <tr>
            <td colspan="4" style="height: 164px; text-align: right">
                <span style="color: #000099"></span>
                <table border="1" style="width:100%;  height: 208px;">
                    <tr>
                        <td colspan="5" style="text-align: center; height: 23px;">
                            <strong><span style="color: #000099"></span></strong></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong><span style="color: #cc3300"><span style="color: #000099">Select State,District &amp; Post for </span>
                            Permanant/Present selection</span></strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style=" text-align: left; width: 198px; height: 24px;">
                            <strong><span style="color: #ff0000">Select category</span></strong></td>
                        <td colspan="3" style="HEIGHT: 24px; TEXT-ALIGN: left">
                            &nbsp;
                            <input id="Checkbox3" type="checkbox" runat="server" checked="CHECKED" onchange="Checkbox3_onclick()" /><strong>Permanant </strong>
                            <input id="Checkbox4" type="checkbox" runat="server" onchange="Checkbox4_onclick()" /><strong>Present</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style=" text-align: left; width: 198px; height: 36px;">
                            <asp:Label ID="Label7" runat="server" Text="House Name :" Width="88px"></asp:Label></td>
                        <td colspan="3" style="text-align: left; height: 36px;">
                          <%--  <asp:TextBox ID="txt_Perm_hs_select" runat="server" ReadOnly="true" Height="24px" MaxLength="50"
                                TabIndex="2" Width="222px" Font-Names="Verdana"></asp:TextBox>--%>
                                 <input id="txt_Perm_hs_select" maxlength="10" style="width: 162px; font-family: Verdana;" ReadOnly="ReadOnly" type="text" runat="server"/>
                                </td>
                    </tr>
                    <tr>
                        <%--<td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label3" runat="server" Text="state :" Width="64px"></asp:Label></td>--%>
                        <%--<td colspan="3" style="text-align: left">--%> <%--onchange="return perm_state_change()"--%>
                         <%--   <asp:DropDownList ID="cmb_state_select" runat="server" onchange="return perm_state_change()"  onkeypress="return perm_state_change()"
                                TabIndex="3" Width="224px" Font-Names="Verdana" >
                            </asp:DropDownList>--%>
                            
                            <%--'a'--%>
                            <tr id ="Tr3" >
 <td colspan="2" style=" text-align: left; width: 198px; height: 36px;">
                            <asp:Label ID="Label16" runat="server" Text="State :" Width="88px"></asp:Label></td>
            <td colspan="2" style="height: 36px; text-align: left">
                <input id="Text_state" maxlength="10" style="width: 162px; font-family: Verdana;" ReadOnly="ReadOnly" type="text" runat="server"/></td>
        </tr>
     <%--   </td>--%>
        
        
            <%--'a'--%>
                    </tr>
                    <tr>
                       <%-- <td colspan="2" style=" text-align: left; width: 198px; height: 26px;">
                            <asp:Label ID="Label4" runat="server" Text="District :" Width="64px"></asp:Label></td>--%>
                       <%-- <td colspan="3" style=" text-align: left; height: 26px;">--%>
                          <%--  <asp:DropDownList ID="cmb_dist_select" runat="server" onchange="return perm_district_change()"  onkeypress="return perm_district_change()"
                                TabIndex="4" Width="224px" Font-Names="Verdana">
                            </asp:DropDownList>--%>
                            
                                                       <%--'a'--%>
                            <tr id ="Tr4">
 <td colspan="2" style=" text-align: left; width: 198px; height: 36px;">
                            <asp:Label ID="Label17" runat="server" Text="District :" Width="88px"></asp:Label></td>
            <td colspan="2" style="height: 10px; text-align: left">
                <input id="Text_dist" maxlength="20" style="width: 162px; font-family: Verdana;" type="text" ReadOnly="ReadOnly" runat="server"/></td>
        </tr>
        <%--</td>--%>
        
        
            <%--'a'--%>
                            
                    </tr>
                    <tr>
                       <%-- <td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label5" runat="server" Text="Post :" Width="63px"></asp:Label></td>
                        <td colspan="3" style="text-align: left">
                            <asp:DropDownList ID="cmb_post_select" runat="server" onchange="return perm_post_change()"  onkeypress="return perm_post_change()"
                                TabIndex="5" Width="224px" Font-Names="Verdana">
                            </asp:DropDownList></td>--%>
                            
                            
                                                       <%--'a'--%>
                            <tr id ="Tr5" >
 <td colspan="2" style=" text-align: left; width: 198px; height: 36px;">
                            <asp:Label ID="Label18" runat="server" Text="Post :" Width="88px"></asp:Label></td>
            <td colspan="2" style="height: 36px; text-align: left">
                <input id="Text_post" maxlength="20" style="width: 162px; font-family: Verdana;" type="text"  runat="server"/></td>
        </tr>
      <%--  </td>--%>
        
        
            <%--'a'--%>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px; height: 28px;">
                            <asp:Label ID="Label2" runat="server" Text="PIN :" Width="62px"></asp:Label></td>
                        <td colspan="3" style="text-align: left; height: 28px;">
                         <input id="Txt_pin_select" maxlength="10" style="width: 162px; font-family: Verdana;" ReadOnly="ReadOnly" type="text" runat="server"/>
                            <%--<asp:TextBox ID="Txt_pin_select" runat="server"  Width="162px" ReadOnly="true" Font-Names="Verdana"></asp:TextBox>--%></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;">
                        </td>
                        <td colspan="3" style="text-align: left">
                            <input id="Button2" style="font-weight: bold; width: 225px" type="button" value="ADD" runat="server"  /></td>
                            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 233px">
                <span style="color: #3300cc"><strong>
                Address : <span style="color: #ff0033">*</span></strong></span></td>
            <td style="width: 311px; text-align: left">
                <table border="1" style="width: 302px">
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong>
                            Permanant</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 27px; text-align: left">
                            <asp:Label ID="Label6" runat="server" Text="House Name :" Width="88px"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 27px">
                            <asp:TextBox ID="txt_Perm_hs_name" runat="server" Height="24px" MaxLength="50" 
                                TabIndex="2" Width="193px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; text-align: left; height: 26px;">
                            <asp:Label ID="Lbl7" runat="server" Text="state :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; text-align: left; height: 26px;">
                            <asp:TextBox ID="Text_perm_state" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; text-align: left">
                            <asp:Label ID="Label8" runat="server" Text="District :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; text-align: left">
                            <asp:TextBox ID="Text_perm_dis" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 12px; text-align: left">
                            <asp:Label ID="Label9" runat="server" Text="Post :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 12px; text-align: left">
                            <asp:TextBox ID="Text_perm_post" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 24px; text-align: left">
                            <asp:Label ID="Label10" runat="server" Text="PIN :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 24px; text-align: left">
                            <asp:TextBox ID="txt_perm_pin" runat="server" ReadOnly="True" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:CheckBox ID="chk_add" runat="server" 
                    TabIndex="6" Text="Present address same as Permenant address" Height="34px" Width="304px" Enabled="false" /></td>
            <td colspan="2" style="text-align: left">
                <table border="1">
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong>
                            Present</strong></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label11" runat="server" Text="House Name :" Width="90px"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:TextBox ID="txt_Pres_hs_name" runat="server" Height="28px" MaxLength="50" 
                                TabIndex="7" Width="197px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label12" runat="server" Text="State :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:TextBox ID="Text_pers_state" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label13" runat="server" Text="District :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:TextBox ID="Text_pers_dis" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label14" runat="server" Text="Post :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:TextBox ID="Text_pers_post" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; height: 8px; text-align: left">
                            <asp:Label ID="Label15" runat="server" Text="PIN :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; height: 8px; text-align: left">
                            <asp:TextBox ID="txt_pres_pin" runat="server" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Width="323px" Height="35px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 233px">
                Land&nbsp;Mark : <span style="color: #ff0033">*</span></td>
            <td colspan="3" style="text-align: left">
                <asp:TextBox ID="txt_lankmark" runat="server" MaxLength="60" 
                    TabIndex="11" Width="626px" Height="17px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 233px">
                (Residence)
                Phone<span style="color: #ff0000">* :</span></td>
            <td style="width: 311px">
                <asp:TextBox ID="txt_phone" runat="server" MaxLength="15" onkeypress="return isNumberKey(3)"
                    TabIndex="13" Width="210px"></asp:TextBox></td>
            <td colspan="2">
                <asp:CheckBox ID="chk_pp" runat="server" TabIndex="12" Text="PP" /></td>
        </tr>
        <tr>
            <td style="width: 233px">
                Contact No :</td>
            <td style="width: 311px">
                <asp:TextBox ID="txt_contactno" runat="server" MaxLength="15" onkeypress="return isNumberKey(3)"
                    TabIndex="14" Width="210px"></asp:TextBox></td>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 233px; height: 27px;">
                Email ID:
            </td>
            <td style="width: 311px; height: 27px;">
                <asp:TextBox ID="txt_email" runat="server" Height="15px" MaxLength="30" TabIndex="15"
                    Width="298px"></asp:TextBox></td>
            <td colspan="2" style="height: 27px">
                <asp:RegularExpressionValidator ID="val_email" runat="server" ControlToValidate="txt_email"
                    ErrorMessage="Enter Correct Email Add" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 233px">
                Father/Husband&nbsp;Name :
            </td>
            <td style="width: 311px">
                <asp:TextBox ID="txt_fathus" runat="server" MaxLength="40"
                    TabIndex="17" Width="298px"></asp:TextBox></td>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center; height: 198px;">
                <div style="text-align: center">
                    <table style="width: 840px; height: 386px;" border="1">
                        <tr>
                            <td style="width: 122px; text-align: left">
                                Gender : &nbsp;</td>
                            <td style="width: 190px; text-align: left">
                                <asp:RadioButtonList ID="rd_gender" runat="server" RepeatDirection="Horizontal" TabIndex="16"
                                    Width="205px">
                                    <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                    <asp:ListItem Value="0">Female</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 98px; text-align: right">
                                Marital&nbsp;Status&nbsp;<span style="color: #ff0033">*</span>&nbsp;:<span style="color: #ff0033"></span><span style="color: #ff0000"></span>
                            </td>
                            <td style="width: 100px; text-align: left"><asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="16" 
                                    Width="205px" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="1">Married</asp:ListItem>
                                <asp:ListItem Value="0">single</asp:ListItem>
                            </asp:RadioButtonList></td>
                        </tr>
                        <tr id="row3" runat="server">
                            <td style="width: 122px; text-align: left">
                                Spouse :
                            </td> 
                            <td style="width: 190px; text-align: left">
                                <asp:TextBox ID="txt_spousename" runat="server" MaxLength="40"
                                    TabIndex="19" Width="173px" Font-Names="Verdana"></asp:TextBox></td>
                            <td style="width: 98px; text-align: right;">
                                No&nbsp;Of&nbsp;Children&nbsp;:</td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_child" runat="server" onkeypress="return isNumberKey(3)" TabIndex="20"
                                    Width="66px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 122px; text-align: left; height: 16px;">
                                Date&nbsp;of&nbsp;Birth&nbsp;<span style="color: #ff0033">*</span>&nbsp;:&nbsp;</td>
                            <td style="width: 190px; height: 16px; text-align: left;">
                            <input type="text" id="txt_dob"  runat="server" style="width:173px;" readonly="readonly" />
                                <%--<asp:TextBox ID="txt_dob" runat="server" ReadOnly="true"
                                     TabIndex="21" Width="173px" Font-Names="Verdana"></asp:TextBox>--%></td>
                            <td style="width: 98px; height: 16px; text-align: left;">
                                Age :&nbsp;</td>
                            <td style="width: 100px; height: 16px; text-align: left;">
                            <input type="text" id="txt_age"  runat="server" style="width:30px;" readonly="readonly" />
                                <%--<asp:TextBox ID="txt_age" runat="server"  Width="65px" ReadOnly="true" Font-Names="Verdana"></asp:TextBox>--%></td>
                        </tr>
                        <tr>
                            <td style="width: 122px; text-align: left;">
                                Religion :&nbsp;</td>
                            <td style="width: 190px; text-align: left;">
                                <asp:DropDownList ID="cmb_religion" runat="server" TabIndex="22" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left;">
                                Caste<span style="color: #ff3300">* :&nbsp; </span>
                            </td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_caste" runat="server" MaxLength="15" 
                                    TabIndex="23" Width="268px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 122px; text-align: left;">
                                ID Proof&nbsp; :&nbsp;
                            </td>
                            <td style="width: 190px; text-align: left;">
                                <asp:DropDownList ID="cmb_idproof" runat="server" TabIndex="24" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left;">
                                ID No :&nbsp;
                            </td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_idno" runat="server" MaxLength="25" 
                                    TabIndex="25" Width="269px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 122px; text-align: left">
                                Blood Group :&nbsp;
                            </td>
                            <td style="width: 190px; text-align: left">
                                <asp:DropDownList ID="cmb_bloodgp" runat="server" TabIndex="26" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left">
                                SSLC No :
                            </td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_sslc" runat="server" AutoCompleteType="Disabled" MaxLength="40"
                                   TabIndex="19" Width="173px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 122px; text-align: left;">
                            </td>
                            <td style="width: 190px; text-align: left;">
                                </td>
                            <td style="text-align: left;" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                Nearest Manappuram Branch In Your Location :</td>
                            <td colspan="2" style="text-align: left">
                <select id="cmb_nrbr" runat="server" style="width: 310px">
                    <option selected="selected"></option>
                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                Information Source of Vacancy :</td>
                            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_vacanysource" runat="server" onchange="hiderow()"
                    TabIndex="24" Width="310px" Font-Names="Verdana">
                    <asp:ListItem Value="0">Directors / Employee </asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">News Paper</asp:ListItem>
                    <asp:ListItem Value="2">Internet</asp:ListItem>
                    <asp:ListItem Value="3">Friends</asp:ListItem>
                    <asp:ListItem Value="4">Others</asp:ListItem>
                </asp:DropDownList></td>
                        </tr>
                         <tr id="row1" style="display:none">
                            <td colspan="2" style="text-align: left">
                Employee Code &amp; Name :</td>
                            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_emp" runat="server" Width="310px" Font-Names="Verdana" onchange="setval()">
                </asp:DropDownList></td>
                        </tr>
                        <tr id="row2"  style="display:none">
                            <td colspan="2" style="text-align: left; height: 28px;">
                If Other Specify :</td>
                            <td colspan="2" style="text-align: left; height: 28px;">
                <asp:TextBox ID="txt_other" runat="server" Width="305px"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="cmd_confirm" runat="server" Text="ADD" Width="68px" onclientclick="return checkbeforeconfirm()" Font-Names="Verdana"/></td>
                        <td style="width: 100px">
                           <%-- <asp:Button ID="cmd_edit" runat="server" Text="EDIT" Width="74px" Font-Names="Verdana" />--%></td>
                        <td style="width: 100px">
                <input id="Button1"  style="width: 69px; font-family: Verdana;" type="button"
                    value="EXIT" onclick="return Button1_onclick()" /></td>
                    </tr>
                </table>
                `</td>
        </tr>
    </table>
   <%-- <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_perm_district" >
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender7" runat="server" TargetControlID="cmb_vacanysource">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_pres_state">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender8" runat="server" TargetControlID="cmb_state_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_perm_state">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender9" runat="server" TargetControlID="cmb_dist_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender10" runat="server" TargetControlID="cmb_post_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_pres_post">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_perm_post">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender5" runat="server" TargetControlID="cmb_pres_district">
    </cc1:ListSearchExtender>--%>
    <input id="hid_perm_district" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_district" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_perm_state" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_state" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_perm_post" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_post" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_emp" runat="server" style="width: 21px" type="hidden" />&nbsp;
</asp:Content>

