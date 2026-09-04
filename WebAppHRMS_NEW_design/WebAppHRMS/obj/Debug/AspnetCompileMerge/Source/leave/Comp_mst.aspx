<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Comp_mst.aspx.vb" Inherits="WebAppHRMS.Deepak_Comp_mst_229e70979571" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script type="text/javascript">
      function string(a) 
    {
   
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
       document.getElementById("ctl00_cph_edp_"+a).value=v.toUpperCase()
       document.getElementById("ctl00_cph_edp_"+a).focus()
      
    }
//function check_datel()
//{
//if(document.getElementById("ctl00_cph_edp_txt_date").value=="") 
//  {
// alert("Null")
//  }
//else
//  {  
//var checkstr = "0123456789";
////var DateField = field;
//var DateField =document.getElementById("ctl00_cph_edp_txt_date").value ;
//var Datevalue = "";
//var DateTemp = "";
//var seperator = ".";
//var day;
//var month;
//var year;
//var leap = 0;
//var err = 0;
//var i;
//   err = 0;
// // DateValue = DateField.value;
//   DateValue = DateField;
//   alert(DateValue)
//   /* Delete all chars except 0..9 */
////   for (i = 0; i < DateValue.length; i++) {
////	  if (checkstr.indexOf(DateValue.substr(i,1)) >= 0) {
////	     DateTemp = DateTemp + DateValue.substr(i,1);
////	  }
//    }
//  alert(DateValue)
//   DateValue = DateTemp;
//   /* Always change date to 8 digits - string*/
//   /* if year is entered as 2-digit / always assume 20xx */
//   if (DateValue.length == 6) {
//      DateValue = DateValue.substr(0,4) + '20' + DateValue.substr(4,2); }
//   if (DateValue.length != 8) {
//      err = 19;}
//   /* year is wrong if year = 0000 */
//   year = DateValue.substr(4,4);
//   if (year == 0) {
//      err = 20;
//   }
//   /* Validation of month*/
//   month = DateValue.substr(2,2);
//  
//   if ((month < 1) || (month > 12)) {
//      err = 21;
//   }
//   /* Validation of day*/
//   day = DateValue.substr(0,2);
//   if (day < 1) {
//     err = 22;
//   }
//   /* Validation leap-year / february / day */
//   if ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0)) {
//      leap = 1;
//   }
//   if ((month == 2) && (leap == 1) && (day > 29)) {
//      err = 23;
//   }
//   if ((month == 2) && (leap != 1) && (day > 28)) {
//      err = 24;
//   }
//   /* Validation of other months */
//   if ((day > 31) && ((month == "01") || (month == "03") || (month == "05") || (month == "07") || (month == "08") || (month == "10") || (month == "12"))) {
//      err = 25;
//   }
//   if ((day > 30) && ((month == "04") || (month == "06") || (month == "09") || (month == "11"))) {
//      err = 26;
//   }
//   /* if 00 ist entered, no error, deleting the entry */
//   if ((day == 0) && (month == 0) && (year == 00)) {
//      err = 0; day = ""; month = ""; year = ""; seperator = "";
//   }
//   /* if no error, write the completed date to Input-Field (e.g. 13.12.2001) */
//   if (err == 0) {
//      DateField.value = day + seperator + month + seperator + year;
//   }
//   /* Error-message if err != 0 */
//   else {
//      alert("Date is incorrect!");
//      DateField.select();
//	  DateField.focus();
//   }
//  } 
//}
//function  check_date()
//{
// alert("in")
//// var st;
//// if(document.getElementById("ctl00_cph_edp_txt_date").value=="") 
////  {
//// alert("Enter Compensatory Date")
////  }
//// else
////  {
////     st=document.getElementById("ctl00_cph_edp_txt_date").value.split("/")
////     for (funi=0;funi<st.length;funi++)
////     {
////        if ((st[0] < 1) || (st[0] > 32))
////        {
////        alert("Date is not Correct")  
////        return false
////        }       
////        if ((st[1]=="jan") || (st[1]=="JAN"))
////        {
////        alert("Month is not in Correct format")  
////        return false
////        }  
////     }  
//        
////  } 
//}

</script>
 
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<TABLE style="WIDTH: 907px; POSITION: static; HEIGHT: 228px" id="TABLE1" border=1 runat="server"><TBODY><TR><TD style="HEIGHT: 23px" colSpan=4><SPAN style="TEXT-DECORATION: underline"><STRONG><asp:Label style="POSITION: static" id="Label6" runat="server" Width="518px" Text="COMPENSATORY MASTER" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w1"></asp:Label></STRONG></SPAN></TD></TR><TR><TD style="HEIGHT: 28px" colSpan=4><asp:Label id="Lbl_msg" runat="server" Width="616px" ForeColor="Red"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 1px; TEXT-ALIGN: left"><asp:Label style="POSITION: static" id="Label1" runat="server" Width="135px" Text="Compensatory Name" ForeColor="DarkBlue"></asp:Label></TD><TD style="WIDTH: 122px; HEIGHT: 1px; TEXT-ALIGN: left"><asp:TextBox style="POSITION: static" id="Txt_comname" onkeyup="string('Txt_comname')" runat="server" Width="230px"></asp:TextBox></TD><TD style="WIDTH: 108px; HEIGHT: 1px; TEXT-ALIGN: left"><asp:Label style="POSITION: static" id="Label2" runat="server" Text="Date" ForeColor="DarkBlue"></asp:Label></TD><TD style="WIDTH: 106px; HEIGHT: 1px; TEXT-ALIGN: left"><TABLE style="WIDTH: 259px; POSITION: static"><TBODY><TR><TD style="WIDTH: 132px; HEIGHT: 26px" colSpan=2><asp:TextBox style="POSITION: static" id="Txt_date" runat="server" Width="121px"></asp:TextBox></TD><TD style="WIDTH: 101px; HEIGHT: 26px"><asp:RegularExpressionValidator style="POSITION: static" id="RegularExpressionValidator1" runat="server" Width="243px" __designer:wfdid="w1" ErrorMessage="Wrong Compensatory  Date..!" ControlToValidate="Txt_date" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec|JAN|FEB|MAR|APR|MAY|JUN|JULY|AUG|SEP|OCT|NOV|DEC)\/\d{4}$"></asp:RegularExpressionValidator></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="TEXT-ALIGN: left" colSpan=2><asp:Label style="POSITION: static" id="Label5" runat="server" Width="340px" Text="Expire Date Of Compensatory" ForeColor="DarkBlue"></asp:Label></TD><TD style="TEXT-ALIGN: left" colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox style="POSITION: static" id="txt_expire" runat="server" Width="123px"></asp:TextBox> <asp:RegularExpressionValidator style="POSITION: static" id="RegularExpressionValidator2" runat="server" Width="254px" __designer:wfdid="w3" ErrorMessage="Wrong Expiry Date" ControlToValidate="txt_expire" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec|JAN|FEB|MAR|APR|MAY|JUN|JULY|AUG|SEP|OCT|NOV|DEC)\/\d{4}$"></asp:RegularExpressionValidator></TD></TR><TR><TD style="HEIGHT: 37px; TEXT-ALIGN: center" colSpan=4><asp:Button id="cmd_confirm" runat="server" Width="216px" Text="CONFIRM" ForeColor="DarkBlue" Font-Bold="True" Height="27px"></asp:Button>&nbsp; </TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:Label id="Label3" runat="server" Width="134px" Text="Compensatory Name" ForeColor="DarkBlue"></asp:Label></TD><TD style="WIDTH: 122px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:DropDownList id="Cmb_compname" runat="server" Width="235px">
                    </asp:DropDownList></TD><TD style="WIDTH: 108px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:Label id="Label4" runat="server" Width="105px" Text="Applicable State" ForeColor="DarkBlue"></asp:Label></TD><TD style="WIDTH: 106px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:DropDownList id="Cmb_state" runat="server" Width="215px">
                    </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 26px; TEXT-ALIGN: right" colSpan=3><asp:Button style="POSITION: static" id="cmd_insert" runat="server" Width="142px" Text="INSERT" ForeColor="DarkBlue" Font-Bold="True" Height="29px" __designer:wfdid="w1"></asp:Button></TD><TD style="WIDTH: 106px; HEIGHT: 26px; TEXT-ALIGN: center"><asp:Button style="POSITION: static" id="Button1" onclick="Button1_Click" runat="server" Width="132px" Text="EXIT" ForeColor="DarkBlue" Font-Bold="True" Height="28px" __designer:wfdid="w2"></asp:Button></TD></TR><TR><TD style="HEIGHT: 23px" colSpan=4><cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_expire">
                    </cc1:CalendarExtender> <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy" targetcontrolid="Txt_date"></cc1:calendarextender> <asp:ValidationSummary style="POSITION: static" id="ValidationSummary1" runat="server" Width="235px" Height="34px" __designer:wfdid="w2" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD></TR></TBODY></TABLE>
</ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;</div>
</asp:Content>

