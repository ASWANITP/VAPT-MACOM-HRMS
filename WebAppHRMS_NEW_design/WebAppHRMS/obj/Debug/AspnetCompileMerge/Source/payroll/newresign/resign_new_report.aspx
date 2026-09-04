<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="resign_new_report.aspx.vb" Inherits="WebAppHRMS.new_resign_report_ce2dc8ce5489" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript" >
function Button1_onclick() 
{
window.open("../../home.aspx",'_self')
}
function check_fromdt()
{
alert("Select Date From Calendar");
document.getElementById("ctl00_cph_edp_txt_fromdt").value="";
document.getElementById("ctl00_cph_edp_txt_fromdt").value=document.getElementById("ctl00_cph_edp_hdn_sysdate").value;
document.getElementById("ctl00_cph_edp_txt_fromdt").focus();
}

function check_todt()
{
alert("Select Date From Calendar")
document.getElementById("ctl00_cph_edp_txt_todt").value="";
document.getElementById("ctl00_cph_edp_txt_todt").value=document.getElementById("ctl00_cph_edp_hdn_sysdate").value;
document.getElementById("ctl00_cph_edp_txt_todt").focus();
}

//function checkDate(sender,args)
//{

// var dt=new Date()
// //alert(new Date());
// if (sender._selectedDate > new Date())
//            {
//                alert("You cannot select a day Greater than today!");
//                sender._selectedDate = new Date();
//                document.getElementById("ctl00_cph_edp_txt_fromdt").value="";
//            }
//}

    function checkDate(sender, args) {
        var today = new Date();

        if (sender._selectedDate > today) {
            alert("You cannot select a date greater than today!");

            // Reset the selected date
            sender.set_selectedDate(today); // If using a date picker
            document.getElementById("ctl00_cph_edp_txt_fromdt").value = ""; // Clears input field
        }
    }


function checkDateq(sender,args)
{ 

 var dt=new Date()
 //alert(new Date());
 if (sender._selectedDate > dt) 
            {
                alert("You cannot select a day Greater than today!");
                sender.set_selectedDate(dt)
                document.getElementById("ctl00_cph_edp_txt_todt").value="";
            }
}

</script>
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>RESIGN STATUS REPORT
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    From Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_fdt" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    To Date</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_tdt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_fdt" OnClientDateSelectionChanged="checkDate"></cc1:calendarextender>
                </td>
                <td colspan="2">
                    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_tdt" OnClientDateSelectionChanged="checkDateq"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td colspan="2">
                    <input id="Button1" style="width: 112px" type="button" value="EXIT"  onclick="return Button1_onclick()"/></td>
            </tr>
        </table>
    </div>
</asp:Content>

