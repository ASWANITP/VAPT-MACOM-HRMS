<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LeaveEntryAtAO1.aspx.vb" Inherits="WebAppHRMS.payroll_LeaveEntryAtAO_b18b22968017" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript" for="window" event="onload">return WindowOnload()</script>
<script type="text/javascript">
var cont_name = header.split("txt");
function btnOK_onclick() 
{
   EmployeeOnchange();
}
function EmpCodeOnkeydown()
{
   if (window.event.keyCode == 27) {document.getElementById("btnExit").focus(); return;}
   if (window.event.keyCode == 13) btnOK_onclick();
   else
   {
      document.getElementById(cont_name[0]+"txtEmpName").value = "";         
      document.getElementById("rowDetails").style.display = "none";
      document.getElementById("btnConfirm").disabled = true;
   }
}
function EmployeeOnchange()
{
   var EmpCode = document.getElementById(cont_name[0]+"txtEmpCode").value;
   document.getElementById("btnConfirm").style.cursor = "wait";   
   toServer("1" + EmpCode,1);
}
function CheckApplied()
{
   if (document.getElementById(cont_name[0]+"chkApplication").checked == true)
      document.getElementById(cont_name[0]+"txtAppliedDt").disabled = false;
   else
      document.getElementById(cont_name[0]+"txtAppliedDt").disabled = true;
}
function CheckFutureDate()
{
   var AppliedDt = document.getElementById(cont_name[0]+"txtAppliedDt").value;
   document.getElementById("btnConfirm").style.cursor = "wait";   
   toServer("2" + AppliedDt,2);
}
function DateOnkeyup()
{
   if (window.event.keyCode != 13) document.getElementById("btnConfirm").style.cursor = "wait";
}
function GetDays()
{
   var FromDt  = document.getElementById(cont_name[0]+"txtFromDt").value;
   var ToDt    = document.getElementById(cont_name[0]+"txtToDt").value;
   var Type    = document.getElementById(cont_name[0]+"cmbLeaveType").value;
   var EmpCode = document.getElementById(cont_name[0]+"txtEmpCode").value;
   document.getElementById("btnConfirm").style.cursor = "wait";   
   toServer("3" + FromDt + "" + ToDt + "" + Type + "" +EmpCode,3);
}
function checkWaiting()
{
   if (document.getElementById("btnConfirm").style.cursor == "wait") 
   {
      document.getElementById(cont_name[0]+"txtReason").focus();
      document.getElementById("colForMessage").innerHTML = "Please Wait...";
   }
}
function btnConfirm_onclick() 
{
   if (document.getElementById("btnConfirm").style.cursor == "wait") { document.getElementById("colForMessage").style.color = "Blue"; return;}
   //--//-- Abstraction --//--//
   var EmpCode     = document.getElementById(cont_name[0]+"txtEmpCode").value;
   var Applied     = 0;
   if (document.getElementById(cont_name[0]+"chkApplication").checked == true) Applied = 1;
   var AppliedDt   = document.getElementById(cont_name[0]+"txtAppliedDt").value;
   var LeaveType   = document.getElementById(cont_name[0]+"cmbLeaveType").value;
   var FromDt      = document.getElementById(cont_name[0]+"txtFromDt").value;
   var ToDt        = document.getElementById(cont_name[0]+"txtToDt").value;
   var WorkingDays = document.getElementById(cont_name[0]+"txtDays").value;
   var Reason      = document.getElementById(cont_name[0]+"txtReason").value;
   var TotalDays   = document.getElementById(cont_name[0]+"hidTotalDays").value;
   //--//-----------------//--//
   //--//-- Validations --//--//
   if (Reason.replace(/^\s+/g,"") == "") {alert("You Should Specify The Reason !"); document.getElementById(cont_name[0]+"txtReason").focus(); return;}   
   var lYear = document.getElementById(cont_name[0]+"txtFromDt").value.split("/"); //-- Getting FromDate Year
   var nYear = document.getElementById(cont_name[0]+"txtToDt").value.split("/");   //-- Getting ToDate Year
   if (Math.abs(lYear[2]) < Math.abs(new Date().getFullYear())-1)
   { alert("You Are Too Late To Update !"); return; } 
   if (Math.abs(nYear[2]) > Math.abs(new Date().getFullYear()) && Math.abs(LeaveType) >= 1 && Math.abs(LeaveType <= 2) )
   { alert("You Are Too Early To Update !"); return; }    
   if (Math.abs(WorkingDays) == 0)
   { alert("Verify Dates !"); document.getElementById(cont_name[0]+"txtFromDt").focus(); return; }
   if (Math.abs(TotalDays) > 3 && LeaveType == 1)
   { alert("Only 3 Consecutive Casual Leaves Are Allowed !"); document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }   
   var Casual = document.getElementById(cont_name[0]+"txtCasual").value;
   var Sick   = document.getElementById(cont_name[0]+"txtSick").value;
   var Earned = document.getElementById(cont_name[0]+"txtEarned").value;   
   if (Math.abs(lYear[2]) == Math.abs(new Date().getFullYear()))
   {
      if (LeaveType == 1 && Math.abs(Casual) == 0)
      { alert("No Casual Leave Pending !"); document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }   
      if (LeaveType == 1 && WorkingDays > Math.abs(Casual))
      { alert("Casual Leave Pending is Only " + Casual)   ; return; } 
      if (LeaveType == 2 && Math.abs(Sick) == 0)
      { alert("No Sick Leave Pending !");   document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }    
      if (LeaveType == 2 && WorkingDays > Math.abs(Sick))
      { alert("Sick Leave Pending is Only " + Sick); document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }    
      if (LeaveType == 3 && Math.abs(Earned) == 0)
      { alert("No Earned Leave Pending !"); document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }    
      if (LeaveType == 3 && WorkingDays > Math.abs(Earned))
      { alert("Earned Leave Pending is Only " + Earned); document.getElementById(cont_name[0]+"cmbLeaveType").focus(); return; }      
   }
   if (confirm('Are You Sure ? ') == false) return;    
   //--//-----------------//--//
   var Data        = "";
   Data           += "9"    + "" + EmpCode + "" + Applied     + "" + AppliedDt + "" + LeaveType + "";
   Data           += FromDt + "" + ToDt    + "" + WorkingDays + "" + Reason    + "" + TotalDays;
   document.getElementById("btnConfirm").style.cursor = "wait";   
   toServer(Data,9);
}
function fromServer(Arg,Context)
{
   switch (Context)
   {
      case 1:
      {
         var Name_Casual_Sick_Earned = Arg.split("");
         if (Name_Casual_Sick_Earned[4] == "Error")
         {
            alert(Name_Casual_Sick_Earned[5]); break;
         }
         document.getElementById("rowDetails").style.display = "inline";         
         document.getElementById(cont_name[0]+"txtEmpName").value = Name_Casual_Sick_Earned[0];         
         document.getElementById(cont_name[0]+"txtCasual").value = Name_Casual_Sick_Earned[1];
         document.getElementById(cont_name[0]+"txtSick").value = Name_Casual_Sick_Earned[2];
         document.getElementById(cont_name[0]+"txtEarned").value = Name_Casual_Sick_Earned[3];
         
         document.getElementById(cont_name[0]+"chkApplication").checked = true;
         document.getElementById(cont_name[0]+"txtAppliedDt").disabled = false;
         document.getElementById(cont_name[0]+"txtAppliedDt").focus();
         
         document.getElementById("btnConfirm").disabled = false;         
         break;
      }
      case 2:
      {
         if (Arg != "0") 
         {
            alert("Applied Date Should Not Be a Future Date !");
            document.getElementById(cont_name[0]+"txtAppliedDt").value = document.getElementById(cont_name[0]+"hidSystemDate").value;
            document.getElementById(cont_name[0]+"txtAppliedDt").focus();
         }
         break;
      }      
      case 3:
      {
         var TotalDays_WorkingDays = Arg.split("");
         document.getElementById(cont_name[0]+"hidTotalDays").value = TotalDays_WorkingDays[0];         
         document.getElementById(cont_name[0]+"txtDays").value = TotalDays_WorkingDays[1];
         document.getElementById(cont_name[0]+"txtFromDt").value = TotalDays_WorkingDays[2];
         document.getElementById(cont_name[0]+"txtToDt").value = TotalDays_WorkingDays[3];
         break;
      }
      case 9:
      {
         var data = Arg.split("");
         alert(data[0])
         if (data[0] == "Successfully Updated")
         {
            document.getElementById(cont_name[0]+"chkApplication").checked == true;
            document.getElementById(cont_name[0]+"txtAppliedDt").value = document.getElementById(cont_name[0]+"hidSystemDate").value;
            document.getElementById(cont_name[0]+"cmbLeaveType").value = 1;
            document.getElementById(cont_name[0]+"txtFromDt").value = document.getElementById(cont_name[0]+"hidSystemDate").value;
            document.getElementById(cont_name[0]+"txtToDt").value = document.getElementById(cont_name[0]+"hidSystemDate").value;
            document.getElementById(cont_name[0]+"txtDays").value = 1;
            document.getElementById(cont_name[0]+"txtReason").value = "";
            document.getElementById(cont_name[0]+"hidTotalDays").value = 1;
            document.getElementById(cont_name[0]+"txtCasual").value = data[1];
            document.getElementById(cont_name[0]+"txtSick").value = data[2];
            document.getElementById(cont_name[0]+"txtEarned").value = data[3]; 
         }
         else  document.getElementById(cont_name[0]+"cmbLeaveType").focus();
         break;
      }
   }
   document.getElementById("btnConfirm").style.cursor = "hand";
   document.getElementById("colForMessage").innerHTML = "";
}
function isValidDate(ctrl) // Server Control Only
{
    var s = document.getElementById(cont_name[0]+ctrl).value;
	var dateFormat = /^\d{1,4}[\.|\/|-]\d{1,2}[\.|\/|-]\d{1,4}$/;// format D(D)/M(M)/(YY)YY
	if (dateFormat.test(s)) 
	{
		s = s.replace(/0*(\d*)/gi,"$1");// remove any leading zeros from date values
		var dateArray = s.split("/");
		if( Math.abs(dateArray.length) != 3 ) 
		{
		   alert("Incorrect Date Format!");	
		   document.getElementById(cont_name[0]+ctrl).focus();
		   return;
		}
		dateArray[1] = dateArray[1]-1;// correct month value
		// Digit Check In Year
		if (dateArray[2].length != 4)
		{
		   alert("Incorrect Date Format!");	
		   document.getElementById(cont_name[0]+ctrl).focus();
		   return;
		}
		// correct year value
		if (dateArray[2].length<4) 
    		dateArray[2] = (parseInt(dateArray[2]) < 50) ? 2000 + parseInt(dateArray[2]) : 1900 + parseInt(dateArray[2]);
		var testDate = new Date(dateArray[2], dateArray[1], dateArray[0]);
		if (testDate.getDate()!=dateArray[0] || testDate.getMonth()!=dateArray[1] || testDate.getFullYear()!=dateArray[2])
		{
		   alert("Incorrect Date Format!");	
		   document.getElementById(cont_name[0]+ctrl).focus();
		   return;
		}
	} 
	else 
	{
	   alert("Incorrect Date Format!");	
	   document.getElementById(cont_name[0]+ctrl).focus();
	   return;
	}
}
function WindowOnload()    
{ 
   document.getElementById(cont_name[0]+"txtEmpCode").focus();
   document.getElementById("btnConfirm").disabled = true; 
}
function FocusToServer(Ctrl){if (window.event.keyCode == 13) document.getElementById(cont_name[0]+Ctrl).focus(); if (window.event.keyCode == 27) document.getElementById("btnConfirm").focus();}
function FocusToClient(Ctrl){if (window.event.keyCode == 13) document.getElementById(Ctrl).focus();              if (window.event.keyCode == 27) document.getElementById("btnConfirm").focus();}
function btnExit_onclick()  {window.open('../home.aspx','_self'); }
</script>
    <div id="divTotal" style="text-align: center">
                    <div style="text-align: center">
            <table border="1" style="width: 95%; font-family: 'Book Antiqua';">
                <tr>
                    <td style="width: 50%">
                        Employee Code</td>
                    <td style="width: 50%">
                        <input id="txtEmpCode" runat="server" type="text" />
                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <input id="btnOK" style="width: 70px; cursor: hand; font-family: 'Book Antiqua';" type="button" value="OK" onclick="return btnOK_onclick()" /></td>
                </tr>
                <tr>
                    <td style="width: 50%">
                        Employee Name</td>
                    <td style="width: 50%">
                        <input id="txtEmpName" runat="server" size="40" type="text" readonly="readOnly" /></td>
                </tr>
            </table>
        </div>
        <table id="rowDetails" border="1" style="width: 95%; font-family: 'Book Antiqua'; display:none">
            <tr style="height=40px">
                <td colspan="2">
                    Whether Leave Form Submitted &nbsp; &nbsp;&nbsp;
                        <input id="chkApplication" type="checkbox" checked="CHECKED" runat="server" />
                    </td>
                <td colspan="2" rowspan="2">
                    <strong>Pending Leave Details</strong></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Applied On</td>
                <td style="width: 25%">
                    <strong><span
                        style="font-size: 10pt; color: #f08080">
                        <asp:TextBox ID="txtAppliedDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Leave Type</td>
                <td style="width: 25%"><strong><span
                        style="font-size: 10pt; color: lightcoral">
                    <asp:DropDownList ID="cmbLeaveType" runat="server" Font-Names="Courier New" Width="70%">
                    </asp:DropDownList></span></strong></td>
                <td style="width: 25%">
                    Casual</td>
                <td style="width: 25%">
                    <input id="txtCasual" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    From Date</td>
                <td style="width: 25%">
                    <strong><span
                        style="font-size: 10pt; color: lightcoral">
                        <asp:TextBox ID="txtFromDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
                <td style="width: 25%">
                    Sick</td>
                <td style="width: 25%">
                    <input id="txtSick" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    To Date</td>
                <td style="width: 25%">
                    <strong><span
                        style="font-size: 10pt; color: lightcoral">
                        <asp:TextBox ID="txtToDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
                <td style="width: 25%">
                    Earned</td>
                <td style="width: 25%">
                    <input id="txtEarned" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    No. of Days</td>
                <td style="width: 25%">
                    <input id="txtDays" type="text" readonly="readOnly" runat="server" /></td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Reason</td>
                <td colspan="3">
                    <input id="txtReason" type="text" size="97" maxlength="100" runat="server" /></td>
            </tr>
            <tr>
                <td id="colForMessage" colspan="4">
                </td>
            </tr>
        </table>
        <input id="hidTotalDays" runat="server" style="width: 11px" type="hidden" />
        <input id="hidSystemDate" runat="server" style="width: 11px" type="hidden" /><br />
        <table border="1" style="width: 22%">
            <tr>
                <td style="width: 50%">
                    <input id="btnConfirm" style="width: 88px; cursor: hand; font-family: 'Book Antiqua';
                        height: 26px" type="button" value="CONFIRM" onfocus="checkWaiting()" onmouseover="checkWaiting()" onclick="return btnConfirm_onclick()"/></td>
                <td style="width: 50%">
                    <input id="btnExit" style="width: 88px; cursor: hand; font-family: 'Book Antiqua';
                        height: 26px" type="button" value="EXIT" onclick="return btnExit_onclick()"/></td>
            </tr>
        </table>        
    </div>
    &nbsp;
</asp:Content>

