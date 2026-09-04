<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Make_Employ_to_live.aspx.vb" Inherits="WebAppHRMS.Make_Employ_to_live_ffe0af696554" title="SALARY REQUEST Sanction/Rejection" %>
<%@ MasterType VirtualPath ="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=sal.split('Cmb');

function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}
function fill1()
{    
   if(document.getElementById(cont[0]+"Cmb_res").value!=0)
   {  
  
     sub_call_server(document.getElementById(cont[0]+"Cmb_res").value);
   } 
   if(document.getElementById(cont[0]+"Cmb_res").value==0)
   {
     document.getElementById(cont[0]+"Txt_EmpCode").value="";
     document.getElementById(cont[0]+"Txt_EmpName").value="";
     document.getElementById(cont[0]+"Txt_Branch").value="";
     document.getElementById(cont[0]+"Txt_Designation").value="";
     document.getElementById(cont[0]+"Txt_Department").value="";
     document.getElementById(cont[0]+"Txt_Post").value="";
     document.getElementById(cont[0]+"Txt_cancel").value="";
      document.getElementById(cont[0]+"Txt_resig_Date").value="";
 
  b1.style.display="none"; 
  b2.style.display="none"; 
  b3.style.display="none"; 
  b4.style.display="none";
 
 document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
    } 
}
function sub_call_receiver(arg1)
{ 
  var arg2;
  arg2=arg1.split("@");
if (arg2[0]!="$")
{ 

 var arg3=arg2[0].split("*");
 
  document.getElementById(cont[0]+"Txt_EmpCode").value=arg3[0];
 document.getElementById(cont[0]+"Txt_EmpName").value=arg3[1];
 document.getElementById(cont[0]+"Txt_Branch").value=arg3[2];
 document.getElementById(cont[0]+"Txt_Designation").value=arg3[3];
 document.getElementById(cont[0]+"Txt_Department").value=arg3[4];
 document.getElementById(cont[0]+"Txt_Post").value=arg3[5];
  document.getElementById(cont[0]+"Txt_cancel").value=arg3[6];
    document.getElementById(cont[0]+"Txt_resig_Date").value=arg3[7];
 

  b1.style.display="inline"; 
  b2.style.display="inline"; 
  b3.style.display="inline"; 
     b4.style.display="inline";  
  document.getElementById(cont[0]+"Cmd_Confirm").disabled=false;
 
 } 
 
}
function init()
{
 document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
 
}
window.onload=init;


// ]]>
</script>

    <span style="font-family: Courier New">&nbsp; </span>
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;</div>
    </div>
    <div style="text-align: center">
        <div style="text-align: center">
            <table style="width: 724px; font-family: Courier New;">
                <tr>
                    <td colspan="2" style="height: 24px; text-align: center">
                        <strong><span style="font-size: 14pt; font-family: Times New Roman">LIVE THE RESIGNED EMPLOYEE</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 87px; text-align: left; height: 24px;">
                        <strong>
                    Select :</strong></td>
                    <td style="width: 100px; text-align: left; height: 24px;">
                        <asp:DropDownList ID="Cmb_res" runat="server" Width="514px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <span style="font-size: 9pt; color: #0000ff"><strong>TOTAL RECORD-<asp:Label ID="lbl_rec"
                            runat="server" Text="Label"></asp:Label></strong></span></td>
                </tr>
            </table>
        <table border="1" style="font-family: Courier New">
            <tr id="b1" style="display:none">
                <td colspan="2" style="text-align: left; width: 107px;">
                    <strong>Employee Code</strong></td>
                <td colspan="2" style="width: 247px; text-align: left">
                                                    <asp:TextBox ID="Txt_EmpCode" runat="server" Width="145px" ReadOnly="True" Font-Bold="True" ForeColor="Black"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Employee Name</strong></td>
                <td colspan="2" style="text-align: left">
                                                    <asp:TextBox ID="Txt_EmpName" runat="server" Width="238px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
            </tr>
            <tr id="b2" style="display:none">
                <td colspan="2" style="text-align: left; width: 107px;">
                    <strong>
                                                    Branch Name</strong></td>
                <td colspan="2" style="width: 247px; text-align: left">
                                                    <asp:TextBox ID="Txt_Branch" runat="server" Width="238px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Designation</strong></td>
                <td colspan="2" style="text-align: left">
                                                    <asp:TextBox ID="Txt_Designation" runat="server" Width="238px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
            </tr>
            <tr id="b3" style="display:none">
                <td colspan="2" style="text-align: left; width: 107px; height: 28px;">
                    <strong>
                                                    Department</strong></td>
                <td colspan="2" style="width: 247px; text-align: left; height: 28px;">
                                                    <asp:TextBox ID="Txt_Department" runat="server" Width="238px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 111px; height: 28px;">
                    <strong>
                    Post Name</strong></td>
                <td colspan="2" style="text-align: left; height: 28px;">
                    <asp:TextBox ID="Txt_Post" runat="server" Width="238px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
            </tr>
            <tr id="b4" style="display: none">
                <td colspan="2" style="width: 107px; height: 28px; text-align: left">
                    <strong>Entered&nbsp;Person</strong></td>
                <td colspan="2" style="width: 247px; height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_cancel" runat="server" Width="239px" ReadOnly="True" Font-Bold="True"></asp:TextBox></td>
                <td colspan="2" style="width: 111px; height: 28px; text-align: left">
                    <strong>Resigned Date</strong></td>
                <td colspan="2" style="height: 28px; text-align: left">
                    <asp:TextBox ID="Txt_resig_Date" runat="server" Width="91px" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
        <table border="1" style="font-family: Courier New">
            <tr>
                <td colspan="2" style="height: 23px; text-align: left; width: 98px;">
                    <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" Width="92px" /></td>
                <td style="width: 57px; height: 23px; text-align: left">
                    </td>
                <td style="width: 47px; height: 23px; text-align: left">
                    <input id="Button2" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" style="width: 86px" /></td>
            </tr>
        </table>
            <br />
        </div>
        <div style="text-align: center">
    <br />
            <span style="font-family: Courier New">&nbsp;</span></div>
    </div>
</asp:Content>

