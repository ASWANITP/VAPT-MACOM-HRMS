<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="MainBlockSelect.aspx.vb" Inherits="WebAppHRMS.BlockALert_MainBlockSelect_65e117c06930" title="Main Blocks Exception" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont=loanno.split('txt');
function cmdExit_onclick() 
{
   window.open('../home.aspx','_self');
}
function CheckKeyUp()
{
   alert("Please Select Date Using Calendar..No Need for Typing The Date..!!");
   document.getElementById(cont[0]+"txt_SelectDate").value = "";
   document.getElementById(cont[0]+"txt_SelectDate").focus();
   return false;
}
function CheckDate()
{
    var day1, day2 , day3;
    var month1, month2 , month3;
    var year1, year2, year3;
    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;
    
    if(document.getElementById(cont[0]+"txt_SelectDate").value !="")
    {    
            value1 = document.getElementById(cont[0]+"txt_SelectDate").value;            
           
            day1= value1.substring (0, value1.indexOf ("/"));
            month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
            year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);          
            
            day3 = value3.substring (0, value3.indexOf ("/"));
            month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
            year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);
         
            date1 = year1+"/"+month1+"/"+day1;            
            date3 = year3+"/"+month3+"/"+day3;
            
            firstDate = Date.parse(date1);            
            thirdDate = Date.parse(date3);
            

            msPerDay = 24 * 60 * 60 * 1000;            
            
            dbd1 = Math.round((thirdDate.valueOf()-firstDate.valueOf())/ msPerDay) ;  
            
            
            if (dbd1<0)
            {
               alert('Please Do not enter Future Date..!!');              
               document.getElementById(cont[0]+"txt_SelectDate").value="";
               document.getElementById(cont[0]+"txt_SelectDate").focus();
               return false;              
            }
    }
}
function cmdConfirm_onclick() 
{
   if(document.getElementById(cont[0]+"txt_SelectDate").value == "")
   {
      alert('Please Select date From Calendar and Click Confirm Button..!!');
      document.getElementById(cont[0]+"txt_SelectDate").focus();
      return false;
   }
   else
   {
      window.open('HighRiskPendingRpt.aspx?SelDate='+ document.getElementById(cont[0]+"txt_SelectDate").value ,'_self');
   }
}

</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 36%; font-family: 'Bookman Old Style';">
            <tr>
                <td style="width: 34%; text-align: left;">
                    Select Date
                </td>
                <td style="width: 25%; text-align: left;">
                    <asp:TextBox ID="txt_SelectDate" onkeyup="return CheckKeyUp()" onchange="CheckDate()" runat="server" style="font-family: 'Bookman Old Style'"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align: center">
                        <table style="width: 182px">
                            <tr>
                                <td style="width: 100px; text-align: right"><input id="cmdConfirm" style="width: 88px; cursor: hand; font-family: 'Bookman Old Style'"
                                        type="button" value="Confirm" onclick="return cmdConfirm_onclick()" /></td>
                                <td style="width: 100px; text-align: left">
                                    <input id="cmdExit" style="width: 88px; cursor: hand; font-family: 'Bookman Old Style'"
                                        type="button" value="Exit" onclick="return cmdExit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_SelectDate"></cc1:calendarextender>
</asp:Content>

