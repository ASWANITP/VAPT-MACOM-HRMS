<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Emp_Off_Change.aspx.vb" Inherits="WebAppHRMS._7DaysWorking_hrm_Emp_Off_Change_6416ae436365" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<%--<body onload="show()" bgcolor="antiquewhite">
 </body>--%>
<div style="text-align: center">
        <div style="text-align: center">

            <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                targetcontrolid="txt_Date"></cc1:calendarextender>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="0" style="width: 40%;border-right: gray thin solid; border-top: gray thin solid; border-left: gray thin solid; border-bottom: gray thin solid;">
                <tr>
                    <td colspan="4">
                        <asp:RadioButton ID="rdb_Change" onclick="OnClickRadioChange()" runat="server" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="#C00000" GroupName="a" Text="OFF CHANGE" Width="167px" Font-Bold="True" />
                        &nbsp;
                        <asp:RadioButton ID="rdb_Exchange" onclick="OnClickRadioExchange()" runat="server" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="#C00000" GroupName="a" Text="OFF EXCHANGE" Width="153px" Font-Bold="True" /></td>
                </tr>
                <tr id="Change" style="display:none;">
                    <td colspan="4" style="height: 102px">
                        <div style="text-align: left">
                            <table border="1" style="width: 100%; height: 1px;">
                                <tr>
                                    <td colspan="2" style="width: 210px; height: 29px; text-align: center;">
                                        Select&nbsp;Employee&nbsp;Code</td>
                                    <td style="text-align: left; height: 29px; width: 256px;" colspan="2">
                                        <asp:DropDownList ID="cmb_Code" onchange="OnChangeCode()" runat="server" Width="256px" Font-Names="Times New Roman" Font-Size="Medium">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 210px; text-align: center;">
                                        Assigned&nbsp;OFF&nbsp;Day</td>
                                    <td style="text-align: left; width: 256px;" colspan="2">
                                        <asp:TextBox ID="txt_Off" runat="server" Width="249px" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 210px; text-align: center; height: 31px;">
                                        Date</td>
                                    <td colspan="2" style="text-align: left; width: 256px; height: 31px;">
                                        <asp:TextBox ID="txt_Date" onblur="check_date('txt_Date')" runat="server" Width="249px" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 210px; height: 31px; text-align: center">
                                        Enter Reason</td>
                                    <td colspan="2" style="width: 256px; height: 31px; text-align: left; text-transform:capitalize">
                                        <textarea id="TextArea1" onkeypress="return CheckLength(this,'100')"  rows="2" style="width: 250px"></textarea></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="Exchange" style="display:none;">
                    <td colspan="4" style="text-align: left">
                        <div style="text-align: left">
                            <table border="1" style="width: 79%; height: 41px;">
                                <tr>
                                    <td colspan="2" style="text-align: center; height: 29px;">
                                        Select First Employee Code</td>
                                    <td style="text-align: left; height: 29px;" colspan="2"><asp:DropDownList ID="cmb_Code1" onchange="OnChangeCode1()" runat="server" Width="251px" Font-Names="Times New Roman" Font-Size="Medium">
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="height: 5px; text-align: center;" colspan="2">
                                        Assigned OFF Day</td>
                                    <td style="height: 5px; text-align: left;" colspan="2">
                                        <asp:TextBox ID="txt_Off1" runat="server" Width="246px" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px; text-align: center;">
                                        Select&nbsp;Second&nbsp;Employee&nbsp;Code</td>
                                    <td colspan="2" style="height: 5px; text-align: left">
                                        <asp:DropDownList ID="cmb_Code2" onchange="OnChangeCode2()" runat="server" Width="253px" Font-Names="Times New Roman" Font-Size="Medium">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px; text-align: center;">
                                        Assigned OFF Day</td>
                                    <td colspan="2" style="height: 5px; text-align: left">
                                        <asp:TextBox ID="txt_Off2" runat="server" Width="247px" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px; text-align: center">
                                        Enter Reason</td>
                                    <td colspan="2" style="height: 5px; text-align: left;text-transform:capitalize">
                                        <textarea id="TextArea2" onkeypress="return CheckLength(this,'100')"  rows="2" style="width: 248px"></textarea></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 17px">
                        <input id="Button1" onclick="OnClickConfirm()" style="font-size: 12pt; width: 101px; font-family: 'Times New Roman'"
                            type="button" value="CONFIRM" />&nbsp;
                        <input id="Button2" style="font-size: 12pt; width: 97px; font-family: 'Times New Roman'"
                            type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                </tr>
                <tr>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 10%">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    &nbsp;<input id="hid_branch" runat="server" style="width: 17px" type="hidden" />
    <input id="hdn_sysdate" runat="server" style="width: 14px" type="hidden" />
    <input id="hid_post" runat="server" type="hidden" />
   <script language="javascript" type="text/javascript">
       // <!CDATA[
       //window.onload = function () {
       //    debugger;
       //    var textArea = document.getElementById("TextArea2");
       //    if (textArea) {
       //        textArea.value = "";
       //    } else {
       //        console.error("TextArea2 not found");
       //    }
       //};
       var cont = master_no.split("cmb");

       function Button2_onclick() {
           window.open('../home.aspx', '_self')
       }
       function OnClickRadioChange() {
           data = document.getElementById(cont[0] + "hid_branch").value;
           data = data + "%" + 111;
           ToServer(data + "#" + 1, 1);
       }

       function OnClickRadioExchange() {
           data = document.getElementById(cont[0] + "hid_branch").value;
           data = data + "%" + 112;
           ToServer(data + "#" + 2, 2);
       }

       function OnChangeCode() {
           ///  debugger;

           data = document.getElementById(cont[0] + "cmb_Code").value;
           data = data + "%" + 113;
           ToServer(data + "#" + 3, 3);
       }

       function OnChangeCode1() {
           // debugger;
           data = document.getElementById(cont[0] + "cmb_Code1").value;
           data = data + "%" + 114;
           ToServer(data + "#" + 4, 4);
       }
       function OnChangeCode2() {
           /// debugger;
           data = document.getElementById(cont[0] + "cmb_Code2").value;
           data = data + "%" + 115;
           ToServer(data + "#" + 5, 5);
       }


       function ComboFill(Data, ComboName) {
           if (Data[0] == '') return;

           var rows = Data.split("*");
           for (a = 0; a < rows.length; a++) {
               var cols = rows[a].split("$");
               var option1 = document.createElement("OPTION");
               option1.value = cols[0];
               option1.text = cols[1];
               document.getElementById(cont[0] + ComboName).add(option1);
           }

       }



       function FromServer(arg, context) {
           //debugger;
           var Data = arg.split("@")
           switch (context) {
               case 1:
                   document.getElementById("Change").style.display = "inline";
                   document.getElementById("Exchange").style.display = "none";
                   document.getElementById(cont[0] + "cmb_Code").options.length = 0;
                   if (Data[0] == "") { alert("No Employee ..!!!"); window.open('../home.aspx', '_self'); return false; }
                   ComboFill(Data[0], "cmb_Code");
                   Data1 = Data[1].split("~")
                   arg1 = Data1[0].split("!")
                   document.getElementById(cont[0] + "txt_Off").value = arg1[0] + "-" + arg1[1];
                   document.getElementById(cont[0] + "txt_Date").value = arg1[0];
                   document.getElementById(cont[0] + "hdn_sysdate").value = arg1[0];
                   break;

               case 2:
                   document.getElementById("Exchange").style.display = "inline";
                   document.getElementById("Change").style.display = "none";
                   document.getElementById(cont[0] + "cmb_Code1").options.length = 0;
                   if (Data[0] == "") { alert("No Employee ..!!!"); return false; }
                   ComboFill(Data[0], "cmb_Code1");

                   document.getElementById(cont[0] + "cmb_Code2").options.length = 0;
                   if (Data[0] == "") { alert("No Employee ..!!!"); return false; }
                   ComboFill(Data[0], "cmb_Code2");
                   Data1 = Data[1].split("~")
                   arg1 = Data1[0].split("!")
                   document.getElementById(cont[0] + "txt_Off1").value = arg1[0] + "-" + arg1[1];
                   document.getElementById(cont[0] + "txt_Off2").value = arg1[0] + "-" + arg1[1];
                   break;

               case 3:
                   Data1 = Data[0].split("~");
                   arg1 = Data1[0].split("!")
                   document.getElementById(cont[0] + "txt_Off").value = arg1[0] + "-" + arg1[1];
                   document.getElementById(cont[0] + "txt_Date").value = arg1[0];
                   document.getElementById(cont[0] + "hdn_sysdate").value = arg1[0];
                   break;

               case 4:
                   Data1 = Data[0].split("~");
                   arg1 = Data1[0].split("!")
                   document.getElementById(cont[0] + "txt_Off1").value = arg1[0] + "-" + arg1[1];
                   break;

               case 5:
                   Data1 = Data[0].split("~");
                   arg1 = Data1[0].split("!")
                   document.getElementById(cont[0] + "txt_Off2").value = arg1[0] + "-" + arg1[1];
                   break;

               case 6:
                   alert(arg);
                   ///window.open('hrm_Emp_Off_Change.aspx','_self')  ;
                   document.getElementById("TextArea1").value = "";
                   break;

               case 7:
                   alert(arg);
                   document.getElementById("TextArea2").value = "";
                   /// window.open('hrm_Emp_Off_Change.aspx','_self')  ;
                   break;


           }
       }

       function OnkeyUpChqDate(Control) {
           if (document.getElementById(cont[0] + Control).value != "") {
               alert("Select Date from Calender ..!!!!");
               document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
           }
       }


       function check_date(Control) {
           var day1, day2;
           var month1, month2;
           var year1, year2;
           if (document.getElementById(cont[0] + Control).value != "") {
               var value1 = document.getElementById(cont[0] + Control).value;
               //var dt = new Date().format("dd/MMM/yyyy");
               var dt = document.getElementById(cont[0] + "hdn_sysdate").value;
               var value2 = dt;

               day1 = value1.substring(0, value1.indexOf("/"));
               month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
               year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

               day2 = value2.substring(0, value2.indexOf("/"));
               month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
               year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

               date1 = year1 + "/" + month1 + "/" + day1;
               date2 = year2 + "/" + month2 + "/" + day2;

               firstDate = Date.parse(date1)
               secondDate = Date.parse(date2)

               msPerDay = 24 * 60 * 60 * 1000

               dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
               if (dbd > 0) {
                   alert("Please Do Not Enter Past Date ..!!")
                   document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
                   document.getElementById(cont[0] + Control).focus();
                   return false;
               }
           }

       }


       function OnClickConfirm() {
           debugger;
           if (document.getElementById(cont[0] + "rdb_Change").checked == false && document.getElementById(cont[0] + "rdb_Exchange").checked == false) {
               alert("Please Select Compensatory Change Or Compensatory Exchange!!!");
               return false;
           }
           else {
               if (document.getElementById(cont[0] + "rdb_Change").checked == true) {
                   if (document.getElementById("TextArea1").value == "") {
                       alert("Please Enter Reason ...!!!");
                       return false;
                   }
                   var EMPCODE = document.getElementById(cont[0] + "cmb_Code").value;
                   var OFFDAY = document.getElementById(cont[0] + "txt_Off").value;
                   var OFFDATE = document.getElementById(cont[0] + "txt_Date").value;
                   var BRANID = document.getElementById(cont[0] + "hid_branch").value;
                   var REASON = document.getElementById("TextArea1").value;
                   ToData = EMPCODE + "%" + OFFDAY + "%" + OFFDATE + "%" + BRANID + "%" + REASON;
                   ToServer(ToData + "#" + 6, 6)
               }

               if (document.getElementById(cont[0] + "rdb_Exchange").checked == true) {
                   if (document.getElementById("TextArea2").value == "") {
                       alert("Please Enter Reason ...!!!");
                       return false;
                   }
                   var EMPCODE = document.getElementById(cont[0] + "cmb_Code1").value;
                   var OFFDAY = document.getElementById(cont[0] + "txt_Off1").value;
                   var EMPCODE1 = document.getElementById(cont[0] + "cmb_Code2").value;
                   var OFFDAY1 = document.getElementById(cont[0] + "txt_Off2").value;
                   var BRANID = document.getElementById(cont[0] + "hid_branch").value;
                   var REASON = document.getElementById("TextArea2").value;
                   ToData = EMPCODE + "%" + OFFDAY + "%" + EMPCODE1 + "%" + OFFDAY1 + "%" + BRANID + "%" + REASON;
                   ToServer(ToData + "#" + 7, 7)
               }
           }
       }


       function CheckLength(Control, MaxNum) {
           if (Control.value.length <= MaxNum) { return true; }
           else {
               alert("Only " + MaxNum + " Characters Allowed...!!!");
               return false;
           }
       }
// ]]>
   </script>
</asp:Content>


    

