<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="tour_display.aspx.vb" Inherits="WebAppHRMS.april2010_tour_display_c0dff8294511" title="Untitled Page" %>

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
call_server("1$"+document.getElementById(cont[0]+"Hidtt").value);
}

function call_receiver(arg1)
{
var bilu;
  bilu=arg1.split("@");
if (bilu[1]==1)
{

if (bilu[0]=='#')
{
alert('No TOUR Found')
}
else
{
var ar,ar1;

            ar=bilu[0].split("%")        
            document.getElementById(cont[0]+"cmb_tour").options.length=0
            var option1=document.createElement("OPTION")
            for(a=0;a<ar.length-1;a++)
            {
                ar1=ar[a].split("*")                  
                var option1=document.createElement("OPTION")
                option1.text=ar1[0]+"--"+ar1[1]+" , "+ar1[2]+" -To- "+ar1[3]+", "+ar1[6]
                option1.value=ar1[5]
                document.getElementById(cont[0]+"cmb_tour").add(option1)
            }

}
}
if (bilu[1]==2)
{
alert(bilu[0])
var bi;
bi=bilu[0].split("^")  
document.getElementById(cont[0]+"Txt_rec").value=bi[0];
document.getElementById(cont[0]+"Txt_sac").value=bi[1];
document.getElementById(cont[0]+"Txt_sat").value=bi[2];
}

}

function Txt_search_onclick() {
call_server("2$"+document.getElementById(cont[0]+"cmb_tour").value);
}

function Button2_onclick() {
 window.open("../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 708px">
            <tr>
                <td colspan="4" style="height: 23px">
                    <strong>TOUR ENQUIRY OF RECOMMENDATION/SANCTION<asp:ScriptManager ID="ScriptManager1"
                        runat="server">
                    </asp:ScriptManager>
                    </strong>
                    <cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="cmb_tour"></cc1:listsearchextender>
                </td>
            </tr>
            <tr>
                <td style="width: 504px; height: 28px">
                    Select Tour:</td>
                <td style="width: 102px; height: 28px; text-align: left">
                    <asp:DropDownList ID="cmb_tour" runat="server" Width="462px">
                    </asp:DropDownList></td>
                <td colspan="2" style="width: 449px; height: 28px; text-align: left">
                    &nbsp;<input id="Txt_search" style="width: 99px" type="button" value="Search" onclick="return Txt_search_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 504px; height: 27px">
                    <span style="font-family: Courier New"><strong>TOUR STATUS</strong></span></td>
                <td style="width: 102px; height: 27px; text-align: left">
                    <asp:TextBox ID="Txt_sat" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td colspan="2" rowspan="4" style="width: 449px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 504px; height: 28px">
                    Recommentation</td>
                <td style="width: 102px; height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_rec" runat="server" Width="457px" ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr> 
                <td style="width: 504px">
                    Sanctioning</td>
                <td style="width: 102px; text-align: left">
                    <asp:TextBox ID="Txt_sac" runat="server" Width="455px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 504px; height: 28px">
                </td>
                <td style="width: 102px; height: 28px; text-align: center;">
                    <input id="Hidtt" runat="server" style="width: 1px" type="hidden" />
                    <input id="Hidpen" runat="server" style="width: 1px" type="hidden" />
                    <input id="Button2" type="button" value="EXIT" style="width: 82px" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

