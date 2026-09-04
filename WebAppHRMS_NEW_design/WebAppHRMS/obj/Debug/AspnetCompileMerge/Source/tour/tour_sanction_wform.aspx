<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="tour_sanction_wform.aspx.vb" Inherits="WebAppHRMS.Tour_Sanction_tour_sanction_wform_8621ff0f1998" title="Tour Sanction/Rejection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath ="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split("Txt")
function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}
function fill1()
{  

   if(document.getElementById(cont[0]+"Cmb_TourDetails").value!=0)
   {
     sub_call_server(document.getElementById(cont[0]+"Cmb_TourDetails").value);
   } 
   if(document.getElementById(cont[0]+"Cmb_TourDetails").value==0)
   {
     document.getElementById(cont[0]+"Txt_EmpCode").value="";
     document.getElementById(cont[0]+"Txt_EmpName").value="";
     document.getElementById(cont[0]+"Txt_Branch").value="";
     document.getElementById(cont[0]+"Txt_Designation").value="";
     document.getElementById(cont[0]+"Txt_Department").value="";
     document.getElementById(cont[0]+"Txt_Post").value="";
     document.getElementById(cont[0]+"Txt_TourFrom").value="";
     document.getElementById(cont[0]+"Txt_TourTo").value="";
     document.getElementById(cont[0]+"Txt_TourPlace").value="";
     document.getElementById(cont[0]+"Txt_Purpose").value="";
 
     document.getElementById(cont[0]+"Txt_Advance").value="";
     document.getElementById(cont[0]+"Txt_FromTime").value="";      
     document.getElementById(cont[0]+"Txt_ToTime").value="";
   document.getElementById(cont[0]+"Txt_rec").value="";
   
  document.getElementById(cont[0]+"t1").style.display="none";
 
 document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
 document.getElementById(cont[0]+"Cmd_Cancel").disabled=true;
   document.getElementById(cont[0]+"cmd_rec").disabled=true;
 
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
 document.getElementById(cont[0]+"Txt_TourFrom").value=arg3[6];
 document.getElementById(cont[0]+"Txt_TourTo").value=arg3[7];

 document.getElementById(cont[0]+"Txt_TourPlace").value=arg3[10];
 document.getElementById(cont[0]+"Txt_Purpose").value=arg3[11];
 
 document.getElementById(cont[0]+"Txt_Advance").value=arg3[12];
 if((arg3[13])!=0)
  {
   document.getElementById(cont[0]+"Txt_ApplyDate").value=arg3[13];
  }
  if((arg3[14])=="--")
  {
   document.getElementById(cont[0]+"Txt_rec").value='No Recommendation';
  }
   else
  {
   document.getElementById(cont[0]+"Txt_rec").value=arg3[14];
  }
 if((arg3[13])==0)
 {
  document.getElementById(cont[0]+"Txt_ApplyDate").value='Not Specified';
 }
 if((arg3[8])!=0)
  {
   document.getElementById(cont[0]+"Txt_FromTime").value=arg3[8];
  }
  if((arg3[8])==0)
  {
   document.getElementById(cont[0]+"Txt_FromTime").value='Not Specified';
  }
  if((arg3[9])!=0)
  {
   document.getElementById(cont[0]+"Txt_ToTime").value=arg3[9];
  }
  if((arg3[9])==0)
  {
   document.getElementById(cont[0]+"Txt_ToTime").value='Not Specified';
  }

  document.getElementById(cont[0]+"t1").style.display="inline";

 document.getElementById(cont[0]+"Cmd_Confirm").disabled=false;
 document.getElementById(cont[0]+"Cmd_Cancel").disabled=false;
 }
 
}

function Cmd_Exit2_onclick() 
{
 window.open('../home.aspx','_self');
}

// ]]>
</script>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="Cmb_TourDetails"></cc1:listsearchextender>
    
    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table width="80%">
                    <tr>
                        <td>
                            <table border="1" width="100%" style="font-family: 'Courier New'">
                                <tr>
                                    <td style="width: 122px; text-align: left">
                                        <asp:Label ID="Label1" runat="server" Text="Select From List:" Width="192px"></asp:Label></td>
                                    <td style="width: 100px; text-align: left">
    <asp:DropDownList ID="Cmb_TourDetails" runat="server" Width="676px" Font-Italic="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small">
    </asp:DropDownList></td>
                                </tr>
                            </table>
        <table id='t1' runat="server" border="1" style="display: none;" width="100%">           
            <tr id="b1" style="display:block">
                <td colspan="2" style="text-align: left; width: 122px; ">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Employee Code</strong></td>
                <td colspan="2" style="width: 112px; text-align: left; ">
                                                    <asp:TextBox ID="Txt_EmpCode" runat="server" Width="119px" ReadOnly="True" Font-Bold="False" ForeColor="Black" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Employee Name</strong></td>
                <td colspan="2" style="text-align: left; width: 248px;">
                                                    <asp:TextBox ID="Txt_EmpName" runat="server" Width="253px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
            </tr>
            <tr id="b2" style="display:block">
                <td colspan="2" style="text-align: left; width: 122px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                                                    Branch Name</strong></td>
                <td colspan="2" style="width: 112px; text-align: left">
                                                    <asp:TextBox ID="Txt_Branch" runat="server" Width="306px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Designation</strong></td>
                <td colspan="2" style="text-align: left; width: 248px;">
                                                    <asp:TextBox ID="Txt_Designation" runat="server" Width="253px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
            </tr>
            <tr id="b3" style="display:block">
                <td colspan="2" style="text-align: left; width: 122px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                                                    Department</strong></td>
                <td colspan="2" style="width: 112px; text-align: left">
                                                    <asp:TextBox ID="Txt_Department" runat="server" Width="306px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                    Post Name</strong></td>
                <td colspan="2" style="text-align: left; width: 248px;">
                    <asp:TextBox ID="Txt_Post" runat="server" Width="253px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
            </tr>
            <tr id="b4" style="display:block">
                <td colspan="2" style="text-align: left; height: 1px; width: 122px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour From</strong></td>
                <td colspan="2" style="width: 112px; text-align: left; height: 1px;">
                            <table style="width: 240px">
                                <tr>
                                    <td style="width: 100px">
                    <asp:TextBox ID="Txt_TourFrom" runat="server" Width="124px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                                    <td style="width: 100px">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">To:</strong></td>
                                    <td style="width: 101px">
                    <asp:TextBox ID="Txt_TourTo" runat="server" Width="120px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                                </tr>
                            </table>
                </td>
                <td colspan="2" style="text-align: left; height: 1px; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour Time</strong></td>
                <td colspan="2" style="text-align: left; height: 1px; width: 248px;">
                            <table style="width: 237px">
                                <tr>
                                    <td style="width: 100px">
                    <asp:TextBox ID="Txt_FromTime" runat="server" Width="85px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                                    <td style="width: 173px">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">To:</strong></td>
                                    <td style="width: 100px">
                    <asp:TextBox ID="Txt_ToTime" runat="server" Width="84px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                                </tr>
                            </table>
                </td>
            </tr>
            <tr id="b5" style="display:block">
                <td colspan="2" style="text-align: left; width: 122px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                                                    Tour Place</strong></td>
                <td colspan="2" style="width: 112px; text-align: left">
                    <asp:TextBox ID="Txt_TourPlace" runat="server" Width="235px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                    Tour Purpose</strong></td>
                <td colspan="2" style="text-align: left; width: 248px;">
                    <asp:TextBox ID="Txt_Purpose" runat="server" Width="261px" ReadOnly="True" Font-Bold="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
            </tr>
            <tr id="b6" style="display:block">
                <td colspan="2" style="text-align: left; width: 122px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour Advance</strong></td>
                <td colspan="2" style="width: 112px; text-align: left">
                    <asp:TextBox ID="Txt_Advance" runat="server" Font-Bold="False" ReadOnly="True" Width="81px" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                <td colspan="2" style="text-align: left; width: 256px;">
                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Apply Date</strong></td>
                <td colspan="2" style="text-align: left; width: 248px;">
                    <asp:TextBox ID="Txt_ApplyDate" runat="server" Width="91px" Font-Bold="False" ReadOnly="True" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
            </tr>
            <tr id="b7" style="display: block">
                <td colspan="2" style="width: 122px; text-align: left;">
                    <span style="font-family: Courier">Recommended&nbsp;Person</span></td>
                <td colspan="6" style="text-align: left;">
                    <asp:TextBox ID="Txt_rec" runat="server" ReadOnly="True" Width="575px"></asp:TextBox></td>
            </tr>
        </table>
                        </td>
                    </tr>
                </table>
            </div>
        <table border="1">
            <tr>
                <td colspan="2" style="text-align: left; width: 98px;">
                    <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" Width="92px" style="cursor: hand" Font-Bold="True" /></td>
                <td style="width: 57px; text-align: left"><asp:Button ID="cmd_rec" runat="server" Text="RECOMMEND" Width="92px" style="cursor: hand" Font-Bold="True" /></td>
                <td style="width: 47px; text-align: left">
                    <asp:Button ID="Cmd_Cancel" runat="server" Text="REJECT" Width="82px" style="cursor: hand" Font-Bold="True" /></td>
                <td style="width: 47px; text-align: left">
                    <input id="Button2" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" style="width: 86px; cursor: hand; font-weight: bold;" /></td>
            </tr>
        </table>
        </div>
        <div style="text-align: center">
            &nbsp;</div>
    </div>
</asp:Content>

