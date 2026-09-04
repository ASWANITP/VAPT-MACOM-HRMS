<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="dateHandling.aspx.vb" Inherits="WebAppHRMS.HRM_Reports_dateHandling_a333e88a7124" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
    </script>

    <script language="javascript" type="text/javascript">
// <!CDATA[
// ]]>
var cont_name = header.split("txt");
function btn_from_onclick() 
{
       isValidDate('txt_from');
       isValidDate('txt_to'); 
       var From = document.getElementById(cont_name[0]+"txt_from").value
       var To = document.getElementById(cont_name[0]+"txt_to").value
       var OptionID = document.getElementById(cont_name[0]+"hdn_option_id").value;
       switch (OptionID)  
       {
          case "1":
          {
             window.open('rpt_Schedule_Promotion.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "2":
          {
             window.open('rptScheduleExternal.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "3":
          {
             window.open('rpt_Absentees.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "4":
          {
             window.open('TrainingPostpone.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "5":
          {
             window.open('FeedbackTrainingwise.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "6":
          {
             window.open('FeedbackTrainerwise.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
          case "7":
          {
             window.open('DailyReportTrained.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
           case "8":
          {
             window.open('DailyReportToBeTrained.aspx?from_dt='+ From +'&to_dt='+ To +'','_self');
             break;
          }
       }
}
function isValidDate(ctrl) 
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
		}
		dateArray[1] = dateArray[1]-1;// correct month value
		// Digit Check In Year
		if (dateArray[2].length != 4)
		{
		   alert("Incorrect Date Format!");	
		   document.getElementById(cont_name[0]+ctrl).focus();
		   return false;
		}
		// correct year value
		if (dateArray[2].length<4) 
    		dateArray[2] = (parseInt(dateArray[2]) < 50) ? 2000 + parseInt(dateArray[2]) : 1900 + parseInt(dateArray[2]);
		var testDate = new Date(dateArray[2], dateArray[1], dateArray[0]);
		if (testDate.getDate()!=dateArray[0] || testDate.getMonth()!=dateArray[1] || testDate.getFullYear()!=dateArray[2])
		{
		   alert("Incorrect Date Format!");	
		   document.getElementById(cont_name[0]+ctrl).focus();
		}
		else
			return true;
	} 
	else 
	{
	   alert("Incorrect Date Format!");	
	   document.getElementById(cont_name[0]+ctrl).focus();
	   return false;
	}
}
function back()
{
    window.open("../home.aspx","_self")
}        

function window_onload() 
{
var DateOption = document.getElementById(cont_name[0]+"hdn_option_id").value;
if(DateOption==7)
{
  document.getElementById("rowDate").style.display="none";
  document.getElementById("cellDate").value="date";
  document.getElementById(cont_name[0]+"Label1").innerHTML="Date"
}  
}

    </script>

    <div style="text-align: center; font-family: 'Courier New';">
        <table id="TABLE1" border="1" style="width: 40%">
            <tr id="rowDate">
                <td style="width: 20%">From Date</td>
                <td style="width: 20%">
                    <input id="txt_from" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td id="cellDate" style="width: 20%; height: 23px;">
                    <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label></td>
                <td style="width: 20%; height: 23px;">
                    <input id="txt_to" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: #ff0000">* Format dd/mm/yyyy<input id="hdn_option_id" runat="server"
                        style="width: 1px" type="hidden" /></span></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <input id="btn_generate" style="cursor: hand; font-family: 'Courier New'" type="button"
                        value="GENERATE" onclick="return btn_from_onclick()" />
                    <input id="btn_exit" onclick="return back()" style="cursor: hand; font-family: 'Courier New'" type="button"
                        value="EXIT" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

