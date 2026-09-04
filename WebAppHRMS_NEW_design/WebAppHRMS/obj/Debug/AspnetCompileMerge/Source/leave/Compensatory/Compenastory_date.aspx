<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Compenastory_date.aspx.vb" Inherits="WebAppHRMS.Compenastory_assign_5a9845185501" title="Untitled Page" EnableEventValidation ="true" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

var cont_name=header.split('txt');
  
  function btn_exit_onclick() 
{
window.open ("../../home.aspx","_self")
}
  
 function checkDt()
{

dateFrom=document.getElementById(cont_name[0]+"txt_Compdate").value;
checkDate(dateFrom)
}
function returnFalse()
{
    return false;
}
function checkDate(dateFrom)
{
    var day1,day2;
    var month1,month2;
    var year1,year2;
    
    var dt = new Date().format("dd/MMM/yyyy");
    var value3 = dt;
   
     if(dateFrom =="")
       {
        dateFrom=new Date().format("dd/MMM/yyyy");
       }
    
            value1 = dateFrom;
            
           
            day1= value1.substring (0, value1.indexOf ("/"));
            month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
            year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

            day2= value3.substring (0, value3.indexOf ("/"));
            month2 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
            year2 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);
          
           date1 = year1+"/"+month1+"/"+day1;
            date2 = year2+"/"+month2+"/"+day2;
            
            
            firstDate = Date.parse(date1)
            secondDate = Date.parse(date2)

            msPerDay = 24 * 60 * 60 * 1000
            
            if (firstDate.valueOf()>=secondDate.valueOf())
               {
            alert("Please do not select future date !");
            document.getElementById(cont_name[0]+"txt_Compdate").value="";
            return false ;
               }
               else
               {
            
               return true;       
               }
   
}

function btn_generate_onclick()
{
var com_dat=document.getElementById(cont_name[0]+"txt_Compdate").value;

 if(com_dat=="") 
 {
 alert("Please Select Compensatory date");
 return false;
 }
else
 {
  window.open("Compensatory_Report.aspx?FromDt="+com_dat+"","_self");
  }
}

function preventBackspace(e) {
        var evt = e || window.event;
        if (evt) {
            var keyCode = evt.charCode || evt.keyCode;
            if (keyCode === 8) {
                if (evt.preventDefault) {
                    evt.preventDefault();
                } else {
                    evt.returnValue = false;
                }
            }
        }
    }

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 500px; height: 80px">
            <tr>
                <td align="center" colspan="2" style="height: 6px">
                    <span>&nbsp;COMPENSATORY REPORT&nbsp;</span></td>
            </tr>
            <tr>
                <td align="center" style="text-align: center; height: 13px; width: 166px;">
                    Compensatory Date &nbsp;
                </td>
                <td align="center" style="width: 149px; text-align: left; height: 13px;">
                    <asp:TextBox ID="txt_Compdate" runat="server" Width="168px" onkeypress="return false" onpaste="return false" onKeyDown="return preventBackspace()"  ></asp:TextBox></td>
            </tr>
            <tr>
                 <td style="width: 20%; height: 26px; text-align: right;">
                    <input id="btn_exit" style="font-size: 10pt; width: 76px; font-family: 'Times New Roman'"
                        type="button" value="Exit" onclick="return btn_exit_onclick()" />&nbsp;</td>
                <td style="width: 20%; height: 26px; text-align: left;">
                    &nbsp;
                    <input id="btn_generate" style="font-size: 10pt; font-family: 'Times New Roman'"
                        type="button" value="Generate" onclick="return btn_generate_onclick()" /></td>
            </tr>
            <tr>
                <td align="center" style="height: 12px" colspan="2">
                    &nbsp;<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_Compdate">
                    </cc1:CalendarExtender>
                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

