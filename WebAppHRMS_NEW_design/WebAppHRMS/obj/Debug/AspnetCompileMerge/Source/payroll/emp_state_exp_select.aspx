<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_state_exp_select.aspx.vb" Inherits="WebAppHRMS.test_emp_exp_emp_state_exp_select_0a84e1ea6311" title="Statewise Employee Experience Details" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split('Cmb');
function Cmd_Exit_onclick() {
 window.open('../home.aspx','_self');
}
function fill1()
{
  if(document.getElementById(cont[0]+"Cmb_State").value!=0)
  {
   sub_call_server(document.getElementById(cont[0]+"Cmb_State").value)
  }
  cmbstatechange();
}
function sub_call_receiver(arg11,arg2) 
{ 
    argg=arg11.split("#")
    arg1=argg[0]
    
        var ar
        var ar1
        ar=arg1.split("~")
//        alert(document.getElementById(cont[0]+"Cmb_District"))
        document.getElementById(cont[0]+"Cmb_District").options.length=0
        for(a=1;a<ar.length;a++)
        {
            ar1=ar[a].split("!")
            var option1=document.createElement("OPTION")
            option1.text=ar1[1]
            option1.value=ar1[0]
            document.getElementById(cont[0]+"Cmb_District").add(option1)
        }
  
}
function window_onload() {
sub_call_server(document.getElementById(cont[0]+"Cmb_State").value)
init();
}
function init()
{
document.getElementById(cont[0]+"Check_State").checked=true;
document.getElementById(cont[0]+"Cmb_State").disabled=false;
document.getElementById(cont[0]+"Hid_State").value=document.getElementById(cont[0]+"Cmb_State").value;
document.getElementById(cont[0]+"Check_District").checked=false;
document.getElementById(cont[0]+"Cmb_District").disabled=true;
document.getElementById(cont[0]+"Hid_District").value=0;
document.getElementById(cont[0]+"Check_Designation").checked=false;
document.getElementById(cont[0]+"Cmb_Designation").disabled=true;
document.getElementById(cont[0]+"Hid_Desig").value=0;
document.getElementById(cont[0]+"Check_Post").checked=false;
document.getElementById(cont[0]+"Cmb_Post").disabled=true;
document.getElementById(cont[0]+"Hid_Post").value=0;
}


function checkstate()
{
 if(document.getElementById(cont[0]+"Check_State").checked==true)
 {
 document.getElementById(cont[0]+"Cmb_State").disabled=false;
 document.getElementById(cont[0]+"Hid_State").value=document.getElementById(cont[0]+"Cmb_State").value;
 }
 if(document.getElementById(cont[0]+"Check_State").checked==false)
 {
  document.getElementById(cont[0]+"Cmb_State").disabled=true;
  document.getElementById(cont[0]+"Hid_State").value=0;
  
  document.getElementById(cont[0]+"Check_District").checked=false;
  document.getElementById(cont[0]+"Cmb_District").disabled=true;
  document.getElementById(cont[0]+"Hid_District").value=0;   
 }
}
function cmbstatechange()
{
  document.getElementById(cont[0]+"Hid_State").value=document.getElementById(cont[0]+"Cmb_State").value;
// alert(document.getElementById(cont[0]+"Hid_State").value);
}

function checkdistrict()
{
  if((document.getElementById(cont[0]+"Check_District").checked==true)&&(document.getElementById(cont[0]+"Check_State").checked==false))
  {
   alert('Please Select State First!!');
   document.getElementById(cont[0]+"Check_District").checked=false;
   document.getElementById(cont[0]+"Cmb_District").disabled=true;
     document.getElementById(cont[0]+"Hid_District").value=0;
  }
 if(document.getElementById(cont[0]+"Check_State").checked==true)
 {
  if(document.getElementById(cont[0]+"Check_District").checked==true)
   {  
    document.getElementById(cont[0]+"Cmb_District").disabled=false;
    document.getElementById(cont[0]+"Hid_District").value=document.getElementById(cont[0]+"Cmb_District").value;
   }
  if(document.getElementById(cont[0]+"Check_District").checked==false)
   {
     document.getElementById(cont[0]+"Cmb_District").disabled=true;
     document.getElementById(cont[0]+"Hid_District").value=0;
   }
 }
 
}
function cmbdistrictchange()
{
 document.getElementById(cont[0]+"Hid_District").value=document.getElementById(cont[0]+"Cmb_District").value;
// alert(document.getElementById(cont[0]+"Hid_District").value);
}
/////////////////////////////////////////////////////////////////
function checkdesig()
{
  if(document.getElementById(cont[0]+"Check_Designation").checked==true)
 {
 document.getElementById(cont[0]+"Cmb_Designation").disabled=false;
 document.getElementById(cont[0]+"Hid_Desig").value=document.getElementById(cont[0]+"Cmb_Designation").value;
 }
 if(document.getElementById(cont[0]+"Check_Designation").checked==false)
 {
  document.getElementById(cont[0]+"Cmb_Designation").disabled=true;
  document.getElementById(cont[0]+"Hid_Desig").value=0;
 }
}
function cmbdesigchange()
{
 document.getElementById(cont[0]+"Hid_Desig").value=document.getElementById(cont[0]+"Cmb_Designation").value;
}
///////////////////////////
function checkpost()
{
  if(document.getElementById(cont[0]+"Check_Post").checked==true)
 {
  document.getElementById(cont[0]+"Cmb_Post").disabled=false;
  document.getElementById(cont[0]+"Hid_Post").value=document.getElementById(cont[0]+"Cmb_Post").value;
 }
 if(document.getElementById(cont[0]+"Check_Post").checked==false)
 {
  document.getElementById(cont[0]+"Cmb_Post").disabled=true;
  document.getElementById(cont[0]+"Hid_Post").value=0;
 }
}
function cmbpostchange()
{
 document.getElementById(cont[0]+"Hid_Post").value=document.getElementById(cont[0]+"Cmb_Post").value;
}
// ]]>
</script>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table border="1" style="width: 725px; height: 86px">
            <tr>
                <td style="width: 104px; text-align: left; height: 20px;">
                    <strong>
                    Select State:</strong></td>
                <td style="width: 234px; text-align: left; height: 20px;">
                    <div style="text-align: left">
                        <table>
                            <tr>
                                <td style="width: 21px">
                                    <input id="Check_State" type="checkbox" onclick="checkstate()" runat="server" /></td>
                                <td style="width: 100px">
                    <asp:DropDownList ID="Cmb_State" runat="server" Width="215px">
                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 791px; text-align: right; height: 20px;" colspan="2">
                    <strong>
                    Select District:</strong></td>
                <td colspan="2" style="width: 148px; height: 20px; text-align: left">
                    <div style="text-align: left">
                        <table>
                            <tr>
                                <td style="width: 23px">
                                    <input id="Check_District" type="checkbox" onclick="checkdistrict()" runat="server" /></td>
                                <td style="width: 100px">
                    <asp:DropDownList ID="Cmb_District" onchange="cmbdistrictchange()" runat="server" Width="202px">
                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 104px; text-align: left; height: 2px;">
                    <strong>
                    Designation:</strong></td>
                <td style="width: 234px; text-align: left; height: 2px;">
                    <div style="text-align: left">
                        <table>
                            <tr>
                                <td style="width: 33px">
                                    <input id="Check_Designation" type="checkbox" onclick="checkdesig()" runat="server" /></td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="Cmb_Designation" onchange="cmbdesigchange()" runat="server" Width="215px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 791px; text-align: right; height: 2px;" colspan="2">
                    <strong>
                    Post:</strong></td>
                <td style="width: 148px; text-align: left; height: 2px;" colspan="2">
                    <table>
                        <tr>
                            <td style="width: 22px">
                                <input id="Check_Post" type="checkbox" onclick="checkpost()" runat="server" /></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="Cmb_Post" onchange="cmbpostchange()" runat="server" Width="206px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <table border="1" style="width: 116px; height: 31px">
                <tr>
                    <td style="width: 100px; text-align: right">
                    <input id="Cmd_Exit" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" style="width: 70px" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" /></td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="Hid_State" runat="server" Value="0"  />
        <asp:HiddenField ID="Hid_District" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_Desig" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_Post" runat="server" Value="0" />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

