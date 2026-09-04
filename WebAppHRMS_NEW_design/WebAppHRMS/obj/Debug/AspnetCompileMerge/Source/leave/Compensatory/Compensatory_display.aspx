<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="Compensatory_display.aspx.vb" Inherits="WebAppHRMS.april2010_tour_display_fbfee0d87167" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split("Txt")
function window_onload() {
//call_server("1$"+document.getElementById(cont[0]+"Hidtt").value);
}

function call_receiver(arg1)
{
var bilu;
  bilu=arg1.split("@");
if (bilu[1]==1)
{

if (bilu[0]=='#')
{
alert('No Employee Found');
}
else
{

document.getElementById(cont[0]+"Txt_name").value=bilu[0];
            
}
}
if (bilu[1]==2)   
{
//alert(bilu[0])
var bi;
bi=bilu[0].split("^")  
document.getElementById(cont[0]+"Txt_rec").value=bi[0];
document.getElementById(cont[0]+"Txt_sac").value=bi[1];
}

}


function fchange(a) 
{
 var str=document.getElementById(cont[0]+a).value;
 if (isNaN(str))
   {
    document.getElementById(cont[0]+a).value="";
    document.getElementById(cont[0]+a).focus;
    return false;
   }

}


function funname(b) 
{
 
    call_server("1$"+ document.getElementById(cont[0]+b).value);
   
       }
       
       
function Txt_search_onclick() {
call_server("2$"+document.getElementById(cont[0]+"Txt_emp").value);
}

function Button2_onclick() {
 window.open("../../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 664px">
            <tr>
                <td colspan="4" style="height: 23px">
                    <strong>COMPENSATORY ENQUIRY OF RECOMMENDATION/SANCTION<asp:ScriptManager ID="ScriptManager1"
                        runat="server">
                    </asp:ScriptManager>
                        &nbsp;</strong>
                </td>
            </tr>
            <tr>
                <td style="width: 314px; height: 28px">
                    Enter Employee:</td>
                <td style="width: 102px; height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_emp" onchange="funname('Txt_emp')" onkeyup="return fchange('Txt_emp')" runat="server" MaxLength="6" Width="99px"></asp:TextBox></td>
                <td colspan="2" style="width: 449px; height: 28px; text-align: left">
                    &nbsp;<input id="Txt_search" style="width: 99px" type="button" value="Search" onclick="return Txt_search_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 314px; height: 28px">
                    Employee Name</td>
                <td style="width: 102px; height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_name" runat="server" Width="457px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="2" rowspan="4" style="width: 449px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 314px; height: 28px">
                    Recommentation</td>
                <td style="width: 102px; height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_rec" runat="server" ReadOnly="true" Width="457px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 314px">
                    Sanctioning</td>
                <td style="width: 102px; text-align: left">
                    <asp:TextBox ID="Txt_sac" runat="server" ReadOnly="true" Width="455px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 314px; height: 28px">
                </td>
                <td style="width: 102px; height: 28px; text-align: center;">
                    <input id="Hidtt" runat="server" style="width: 1px" type="hidden" />
                    <input id="Hidpen" runat="server" style="width: 1px" type="hidden" />
                    <input id="Button2" type="button" value="EXIT" style="width: 82px" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

