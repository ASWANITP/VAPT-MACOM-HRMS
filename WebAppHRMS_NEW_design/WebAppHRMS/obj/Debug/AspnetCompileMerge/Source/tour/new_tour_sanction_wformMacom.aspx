<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="new_tour_sanction_wformMacom.aspx.vb"
    Inherits="Tour_Sanction_tour_sanction_wform_8621ff0f3769" Title="Tour Sanction/Rejection" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[
window.history.forward(1);
var cont=sal.split('Cmb');

function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}
function fill1()
{  debugger;
//   if(document.getElementById(cont[0]+"Txt_EmpCode").value=="")
//   {
//    alert('Please Enter a Valid Employee Code!!');
//    document.getElementById(cont[0]+"Txt_EmpName").value="";
//    document.getElementById(cont[0]+"Txt_Designation").value="";
//    document.getElementById(cont[0]+"Txt_Department").value="";
//    document.getElementById(cont[0]+"Txt_Branch").value="";
//    document.getElementById(cont[0]+"Txt_Post").value="";
//    document.getElementById(cont[0]+"Txt_CurrStatus").value="";
//    document.getElementById(cont[0]+"Txt_RDNo").value="";
//    return false;
//   }
   if(document.getElementById(cont[0]+"Cmb_TourDetails").value!=0)
   {
     sub_call_server(document.getElementById(cont[0]+"Cmb_TourDetails").value);
     
    //     Added on 09-03-2017 for request id =12729
    document.getElementById(cont[0]+"Cmd_Confirm").disabled=false;
    document.getElementById(cont[0]+"Cmd_Cancel").disabled=false;
    document.getElementById(cont[0]+"cmd_rec").disabled=false;
    document.getElementById(cont[0]+"view").disabled=false;

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
   document.getElementById(cont[0]+"Txt_rec").value=="";
   document.getElementById(cont[0]+"tick_status").value=="";
   
  t1.style.display="none";
  b1.style.display="none"; 
  b2.style.display="none"; 
  b3.style.display="none"; 
  b4.style.display="none"; 
  b5.style.display="none"; 
  b6.style.display="none"; 
 b7.style.display="none";
 //n1.style.display="none";  
document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
document.getElementById(cont[0]+"Cmd_Cancel").disabled=true;
document.getElementById(cont[0]+"cmd_rec").disabled=true;
document.getElementById(cont[0]+"view").disabled=true;
 
   } 
}
function sub_call_receiver(arg1)
{debugger;
 if (arg1.startsWith("ALERT:")) {
            // Extract the alert message
            var alertMessage = arg1.split("ALERT:")[1];

            // Display the alert
            alert(alertMessage);

            // Reload the page after the alert is acknowledged
            //location.reload();
//            n5.style.display="none"; 
            window.open("new_tour_sanction_wform.aspx","_self");
        }
if (arg1.startsWith("~")){
var arg2;
var arg4;
  arg2=arg1.split("@");
  arg4=arg2[0].split("~");
if (arg4[1]!="$")
{
//alert(arg2[0])
 var arg3=arg4[1].split("*");
 
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
 document.getElementById(cont[0]+"tick_status").value=arg3[16];
 document.getElementById(cont[0]+"TextBox1").value=arg3[18];
 document.getElementById(cont[0]+"TextBox2").value=arg3[19];
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
  t1.style.display="inline";
  b1.style.display="inline"; 
  b2.style.display="inline"; 
  b3.style.display="inline"; 
  b4.style.display="inline"; 
  b5.style.display="inline"; 
  b6.style.display="inline"; 
  b7.style.display="inline"; 
  n1.style.display="inline";
  n3.style.display="inline";
//  view.style.display="inline";
 if(document.getElementById(cont[0]+"Chk_rec").checked==true)
  {
  n7n.style.display="none";
  n2n.style.display="inline";
  n7.style.display="none";
  n2.style.display="inline";
  //view.style.display="inline";
  }
  if(document.getElementById(cont[0]+"Chk_sac").checked==true)
  {
  n7n.style.display="inline";
  n2n.style.display="none";
  n7.style.display="inline";
  n2.style.display="none";
  //view.style.display="inline";
  document.getElementById(cont[0]+"TextBox4").value=arg3[17];
  }  


}
}
else{

  var arg2;
  arg2=arg1.split("@");
if (arg2[0]!="$")
{
//alert(arg2[0])
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
//  if ((arg3[15])==4) 
//  {
//     document.getElementById(cont[0]+"cmd_rec").disabled=true;
//     }
//     else
//     {
//     
//       document.getElementById(cont[0]+"cmd_rec").disabled=false;
//  }
  t1.style.display="inline";
  b1.style.display="inline"; 
  b2.style.display="inline"; 
  b3.style.display="inline"; 
  b4.style.display="inline"; 
  b5.style.display="inline"; 
  b6.style.display="inline"; 
  b7.style.display="inline"; 
  n1.style.display="none";
  n3.style.display="none"; 
  n2.style.display="none"; 
  n7.style.display="none";
  n2n.style.display="none"; 
  n7n.style.display="none";
//  view.style.display="none";
 // b8.style.display="inline"; 
 // b9.style.display="inline"; 
 // b10.style.display="inline"; 
 // b11.style.display="inline"; 
 // b12.style.display="inline"; 
 // b13.style.display="inline"; 
 //document.getElementById(cont[0]+"Cmd_Confirm").disabled=false;
 //document.getElementById(cont[0]+"Cmd_Cancel").disabled=false;
 // document.getElementById(cont[0]+"cmd_rec").disabled=false;
 }
 }
 
}
//function init()
//{
// document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
// document.getElementById(cont[0]+"Cmd_Cancel").disabled=true;
//   document.getElementById(cont[0]+"cmd_rec").disabled=true;
//}
//window.onload=init;
function Cmd_Exit2_onclick() {
 window.open('../home.aspx','_self');
}

// ]]>
function second()
{
  window.open('Copy of new_tour_sanction_wform.aspx');
}

function autoResize(textbox) { 
    textbox.style.height = 'auto'; 
    textbox.style.height = textbox.scrollHeight + 'px'; 
}
    </script>

    <div style="text-align: center">
        <div style="text-align: center; font-weight: bold; font-size: 14pt; color: #cc0099;
            font-family: 'Courier New'; text-decoration: underline;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;</div>
    </div>
    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table>
                    <tr>
                        <td style="width: 100px; height: 21px">
                            <table border="1" style="width: 794px; font-family: 'Courier New'">
                                <tr>
                                    <td colspan="2" style="height: 27px; text-align: center">
                                        <span style="font-size: 16pt">&nbsp;<strong>TOUR RECOMMEND/SANCTION</strong></span></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 15px; text-align: left">
                                        <div style="text-align: center">
                                            <table style="width: 398px">
                                                <tr>
                                                    <td style="width: 267823px; height: 23px; text-align: left">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#0000CC" Text="Category :"
                                                            Width="168px"></asp:Label></td>
                                                    <td style="width: 100px; height: 23px; text-align: left">
                                                        <asp:CheckBox ID="Chk_Br" runat="server" AutoPostBack="True" Checked="True" Font-Bold="True"
                                                            Text="BRANCH STAFF" Width="168px" /></td>
                                                    <td style="width: 100px; height: 23px; text-align: left">
                                                        <asp:CheckBox ID="Chk_ho" runat="server" AutoPostBack="True" Font-Bold="True" Text="HEADOFFICE STAFF"
                                                            Width="216px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 267823px; height: 23px; text-align: left">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#0000CC" Text="Option       :"
                                                            Width="169px"></asp:Label></td>
                                                    <td style="width: 100px; height: 23px; text-align: left;">
                                                        <asp:CheckBox ID="Chk_rec" runat="server" Checked="True" Font-Bold="True" ForeColor="#C00000"
                                                            Text="RECOMMEND" AutoPostBack="True" /></td>
                                                    <td style="width: 100px; height: 23px; text-align: left;">
                                                        <asp:CheckBox ID="Chk_sac" runat="server" Font-Bold="True" ForeColor="Green" Text="SANCTION"
                                                            AutoPostBack="True" Width="122px" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td style="width: 190px; height: 23px; text-align: left">
                                        <asp:Label ID="Label1" runat="server" Text="Select From List:" Width="170px"></asp:Label></td>
                                    <td style="width: 100px; height: 23px; text-align: left">
    <asp:DropDownList ID="Cmb_TourDetails" runat="server" Width="700px" Height="25px" Font-Italic="False" style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small">
    </asp:DropDownList></td>
                                </tr>
                            </table>
                            <table id="t1" border="1" style="display: none; width: 887px; height: 259px">
                                <tr id="b1" style="display: none">
                                    <td colspan="2" style="text-align: left; width: 157px; height: 30px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Employee
                                            Code</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left; height: 30px;">
                                        <asp:TextBox ID="Txt_EmpCode" runat="server" Width="119px" ReadOnly="True" Font-Bold="False"
                                            ForeColor="Black" Style="cursor: hand; font-weight: normal; font-size: 11pt;
                                            font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                                    <td colspan="2" style="text-align: left; width: 177px; height: 30px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Employee
                                            Name</strong></td>
                                    <td colspan="2" style="text-align: left; height: 30px;">
                                        <asp:TextBox ID="Txt_EmpName" runat="server" Width="237px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr id="b2" style="display: none">
                                    <td colspan="2" style="text-align: left; width: 157px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Branch
                                            Name</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left">
                                        <asp:TextBox ID="Txt_Branch" runat="server" Width="282px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                    <td colspan="2" style="text-align: left; width: 177px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Designation</strong></td>
                                    <td colspan="2" style="text-align: left">
                                        <asp:TextBox ID="Txt_Designation" runat="server" Width="237px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr id="b3" style="display: none">
                                    <td colspan="2" style="text-align: left; width: 157px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Department</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left">
                                        <asp:TextBox ID="Txt_Department" runat="server" Width="280px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                    <td colspan="2" style="text-align: left; width: 177px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Post
                                            Name</strong></td>
                                    <td colspan="2" style="text-align: left">
                                        <asp:TextBox ID="Txt_Post" runat="server" Width="237px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr id="b4" style="display: none">
                                    <td colspan="2" style="text-align: left; height: 1px; width: 157px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour
                                            From</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left; height: 1px;">
                                        <table style="width: 240px">
                                            <tr>
                                                <td style="width: 100px; height: 27px;">
                                                    <asp:TextBox ID="Txt_TourFrom" runat="server" Width="124px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                                <td style="width: 100px; height: 27px;">
                                                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">To:</strong></td>
                                                <td style="width: 101px; height: 27px;">
                                                    <asp:TextBox ID="Txt_TourTo" runat="server" Width="136px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2" style="text-align: left; height: 1px; width: 177px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour
                                            Time</strong></td>
                                    <td colspan="2" style="text-align: left; height: 1px;">
                                        <table style="width: 237px">
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="Txt_FromTime" runat="server" Width="95px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                                <td style="width: 173px">
                                                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">To:</strong></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="Txt_ToTime" runat="server" Width="92px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="b5" style="display: none">
                                    <td colspan="2" style="text-align: left; width: 157px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour
                                            Place</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left">
                                        <asp:TextBox ID="Txt_TourPlace" runat="server" Width="281px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                    <td colspan="2" style="text-align: left; width: 177px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour
                                            Purpose</strong></td>
                                    <td colspan="2" style="text-align: left">
                                        <asp:TextBox ID="Txt_Purpose" runat="server" Width="237px" ReadOnly="True" Font-Bold="False"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr id="b6" style="display: none">
                                    <td colspan="2" style="text-align: left; width: 157px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Tour
                                            Advance</strong></td>
                                    <td colspan="2" style="width: 248px; text-align: left">
                                        <asp:TextBox ID="Txt_Advance" runat="server" Font-Bold="False" ReadOnly="True" Width="139px"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                    <td colspan="2" style="text-align: left; width: 177px;">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Apply
                                            Date</strong></td>
                                    <td colspan="2" style="text-align: left">
                                        <asp:TextBox ID="Txt_ApplyDate" runat="server" Width="195px" Font-Bold="False" ReadOnly="True"
                                            Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                            Font-Size="Small"></asp:TextBox></td>
                                </tr>
                                <tr id="b7" style="display: none">
                                    <td colspan="2" style="width: 157px; text-align: left; height: 30px;">
                                        <span style="font-family: Courier">Recommended&nbsp;Person</span></td>
                                    <td colspan="6" style="text-align: left; height: 30px;">
                                        <asp:TextBox ID="Txt_rec" runat="server" ReadOnly="True" Width="399px"></asp:TextBox></td>
                                </tr>
                                <tr id="n1" style="display: none" >
                           <td colspan="2" style="width: 157px; text-align: left; height: 30px;">
                                        <span style="font-family: Courier">Call&nbsp;Feedback&nbsp;form</span></td>
                                <td colspan="2" style="height: 23px; text-align: left; width: 98px;">
                        <%--<asp:Button ID="view" runat="server" Text="VIEW" Width="92px" Style="cursor: hand"
                            Font-Bold="True" OnClientClick="return second();" />--%>
                            <input type="button" id="Button1" value="VIEW" style="cursor: hand;Width:92px; font-weight:bold;"
                             onclick="return second();" /></td>
                                </tr>
                                <tr id="n3" style="display: none">
                                    <td colspan="2" style="height: 56px">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Punch
                                            Time</strong></td>
                                    <td style="height: 56px">
                                        <table style="width: 240px">
                                            <tr>
                                                <td style="width: 100px; height: 27px;">
                                                    <asp:TextBox ID="TextBox1" runat="server" Width="124px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                                <td style="width: 100px; height: 27px;">
                                                    <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">To:</strong></td>
                                                <td style="width: 101px; height: 27px;">
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="136px" ReadOnly="True" Font-Bold="False"
                                                        Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                        Font-Size="Small"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <td colspan="3" style="text-align: left; width: 177px; height: 56px;">
                                            <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Ticket
                                                Status</strong></td>
                                        <td style="width: 180px; height: 56px;">
                                            <asp:TextBox ID="tick_status" runat="server" Width="270px" ReadOnly="True" Font-Bold="False"
                                                Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                                Font-Size="Small"></asp:TextBox></td>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="n2" colspan="2" style="height: 17px; ">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Remarks</strong></td>
                                        <td id="n2n" colspan="2" style="text-align: left; width: 248px;">
                                             <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Rows="1" ReadOnly="False"
                                          Style="overflow-y: hidden; min-height: 50px; max-height: 200px; width: 237px; resize: none;" 
                                            oninput="autoResize(this)"></asp:TextBox></asp:TextBox></td>
                                    
                                    <td id="n7" colspan="2" style="height: 17px; ">
                                        <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">Recommender Remarks</strong> </td>
                                        <td id="n7n" colspan="2" style="text-align: left">
                                            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Rows="1" ReadOnly="True"
                                          Style="overflow-y: hidden; min-height: 50px; max-height: 200px; width: 237px; resize: none;" 
                                            oninput="autoResize(this)"></asp:TextBox></td>
                                   
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <table border="1">
                <tr>
                 
                    <td colspan="2" style="height: 23px; text-align: left; width: 98px;">
                        <asp:Button ID="Cmd_Confirm" runat="server" Text="SANCTION" Width="92px" Style="cursor: hand"
                            Font-Bold="True" /></td>
                    <td style="width: 57px; height: 23px; text-align: left">
                        <asp:Button ID="cmd_rec" runat="server" Font-Bold="True" Text="RECOMMEND" Style="cursor: hand"
                            Width="111px" /></td>
                    <td style="width: 47px; height: 23px; text-align: left">
                        <asp:Button ID="Cmd_Cancel" runat="server" Text="REJECT" Width="82px" Style="cursor: hand"
                            Font-Bold="True" /></td>
                    <td style="width: 47px; height: 23px; text-align: left">
                        <input id="Button2" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()"
                            style="width: 86px; cursor: hand; font-weight: bold;" /></td>
                </tr>
            </table>
        </div>
        <div style="text-align: center">
            &nbsp;</div>
    </div>
</asp:Content>
