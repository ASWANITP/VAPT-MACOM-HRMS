<%@ Page Language="VB" MasterPageFile="~/edp.master"  EnableEventValidation="false" AutoEventWireup="false" CodeBehind="increment_all.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_increment_136df50e2144" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript" language="javascript">
var cs = cont_name.split("cmb");
function correct() 
{
 if (!(((window.event.keyCode >=48) || (window.event.keyCode==46)) && (window.event.keyCode <= 57)) )
     {
                     
         window.event.cancelBubble = true;
         window.event.keyCode = 0;
         return false;
      }
}    
    
function chkdt()
 {
    document.getElementById("ctl00_cph_edp_txt_effdt").value=""
    document.getElementById("ctl00_cph_edp_txt_effdt").focus()
  }
    
function fill1()
{
debugger;
 if(document.getElementById(cs[0]+"cmb_employee").value!=0)
   {  
     sub_call_server("1@"+document.getElementById(cs[0]+"cmb_employee").value);
   } 
  if(document.getElementById(cs[0]+"cmb_employee").value==0)
  {  
    document.getElementById(cs[0]+"txt_name").value="No DATA";
    document.getElementById(cs[0]+"txt_post").value="No DATA";
    document.getElementById(cs[0]+"txt_designtn").value="No DATA";
    document.getElementById(cs[0]+"txt_deptmnt").value="No DATA";
    document.getElementById(cs[0]+"txt_branch").value="No DATA";
    document.getElementById(cs[0]+"txt_joindt").value="No DATA";
    document.getElementById(cs[0]+"txt_firm").value="No DATA";
    document.getElementById(cs[0]+"txt_basic").value="No DATA";
  } 
}
    
    
function fill2()
{   
 if(document.getElementById(cs[0]+"cmb_pay").value!=0)
  {  
     sub_call_server("2@"+document.getElementById(cs[0]+"cmb_pay").value);
   } 
}
   
   function fill3()
{    
 debugger;
 var val=document.getElementById(cs[0]+"cmb_basic").text;
 var ind=document.getElementById(cs[0]+"cmb_basic").selectedIndex
 var item=document.getElementById(cs[0]+"cmb_basic").options[ind].text;
 
 
 if(document.getElementById(cs[0]+"cmb_basic").value>=0)
  {  
  document.getElementById(cs[0]+"txt_totalsal").value=" ";
  document.getElementById("spcl_row").style.display="none";
  sub_call_server("3@"+document.getElementById(cs[0]+"cmb_pay").value+"@"+document.getElementById(cs[0]+"cmb_basic").value);
   }
   else
   {
   document.getElementById(cs[0]+"txt_totalsal").value=" ";
   document.getElementById(cs[0]+"txt_amount").value=" ";
   document.getElementById("spcl_row").style.display="inline";
   } 
}
   function chk4()
{    
 if(document.getElementById("ctl00_cph_edp_txt_effdt").value!="")
  {  
  if (document.getElementById(cs[0]+"cmb_employee").value!=0)
  {
     sub_call_server("4@"+document.getElementById("ctl00_cph_edp_txt_effdt").value+"@"+document.getElementById(cs[0]+"cmb_employee").value);
   }
   else
   {
   alert("Select the Employee");
   }
   } 
}

function sub_call_receiver(arg1)
{ 
//debugger;

var arg10=arg1.split("^")
if (arg10[1]==1)
{

  var arg2;
  arg2=arg10[0].split("@");
  
  if (arg2[0]!="$")
  { 
     var arg3=arg2[0].split("*"); 

     if (arg3[0]!=" ")
     {
     document.getElementById(cs[0]+"txt_name").value=arg3[0];
     }
     else
     {
         document.getElementById(cs[0]+"txt_name").value="No DATA";
         }
        
    document.getElementById(cs[0]+"txt_basic").value="No DATA";
    if (arg3[1]!=" ")
    {
     document.getElementById(cs[0]+"txt_post").value=arg3[1];
     }
     else
     {
        document.getElementById(cs[0]+"txt_post").value="No DATA";
     }
     if (arg3[2]!=" ")
    {
         document.getElementById(cs[0]+"txt_designtn").value=arg3[2];
     }
     else
     {
         document.getElementById(cs[0]+"txt_designtn").value="No DATA";
     }
     if (arg3[3]!=" ")
    {
     document.getElementById(cs[0]+"txt_deptmnt").value=arg3[3];
     }
     else
     {
       document.getElementById(cs[0]+"txt_deptmnt").value="No DATA";  
     }
     if (arg3[4]!=" ")
    {
       document.getElementById(cs[0]+"txt_branch").value=arg3[4];
     }
     else
     {
        document.getElementById(cs[0]+"txt_branch").value="No DATA"; 
     }
     if (arg3[5]!=" ")
    {
     document.getElementById(cs[0]+"txt_joindt").value=arg3[5];
     }
     else
     {
        document.getElementById(cs[0]+"txt_joindt").value="No DATA"; 
     }
     if (arg3[6]!=" ")
    {
      document.getElementById(cs[0]+"txt_firm").value=arg3[6];
     }
     else
     {
       document.getElementById(cs[0]+"txt_firm").value="No DATA"; 
     }
     if (arg3[7]!=" ")
    {
     document.getElementById(cs[0]+"txt_basic").value=arg3[7];
     }
     else
     {
        document.getElementById(cs[0]+"txt_basic").value="No DATA";  
     }
 
  } 
  
 else
 {
  document.getElementById(cs[0]+"txt_name").value="Not Available";
    document.getElementById(cs[0]+"txt_post").value="Not Available";
    document.getElementById(cs[0]+"txt_designtn").value="Not Available";
    document.getElementById(cs[0]+"txt_deptmnt").value="Not Available";
    document.getElementById(cs[0]+"txt_branch").value="Not Available";
    document.getElementById(cs[0]+"txt_joindt").value="Not Available";
    document.getElementById(cs[0]+"txt_firm").value="Not Available";
    document.getElementById(cs[0]+"txt_basic").value="Not Available";
 } 
  
}
 if (arg10[1]==2)
{
document.getElementById(cs[0]+"txt_amount").value="";
document.getElementById(cs[0]+"txt_totalsal").value=" ";
  var rs1=arg10[0].split("#");
  
  document.getElementById(cs[0]+"cmb_basic").options.length=0;
  for (h=0;h<rs1.length-1;h++)
    {	  
      var option2 = document.createElement("OPTION");
      option2.value =rs1[h];
      option2.text  =rs1[h];
      document.getElementById(cs[0]+"cmb_basic").add(option2);
    }
 }
 
 if (arg10[1]==3)
{

    document.getElementById(cs[0]+"txt_totalsal").value=" ";
    document.getElementById(cs[0]+"hid_basic").value=" ";
    document.getElementById(cs[0]+"txt_totalsal").value=arg10[0];
 document.getElementById(cs[0]+"hid_basic").value=document.getElementById(cs[0]+"cmb_basic").value;
 var da=document.getElementById(cs[0]+"hid_basic").value;
 if (isNaN(da))
 { document.getElementById(cs[0]+"hid_basic").value=-1;
 }
}


if (arg10[1]==4)
{
var rs1=arg10[0].split("~");
 if(rs1[0]==1)
 {
 alert(rs1[1]);
 document.getElementById("ctl00_cph_edp_txt_effdt").value=""
    document.getElementById("ctl00_cph_edp_txt_effdt").focus()
 }
}
} 
function isNumeric()
{
//debugger;
     if (isNaN(document.getElementById(cs[0]+"txt_amount").value)) 
     {
        document.getElementById(cs[0]+"txt_amount").value="";
        return false; 
     }
     var key = event.keyCode || event.charCode;
     
     
}





function detailDisplay()
{
debugger;
 if (isNaN(document.getElementById(cs[0]+"txt_amount").value)) 
     {
         document.getElementById(cs[0]+"txt_amount").value="";
                return false; 
     }
     if(document.getElementById(cs[0]+"txt_amount").value=="")
     {   
         document.getElementById(cs[0]+"txt_totalsal").value=""
         return false; 
    }
if(document.getElementById(cs[0]+"txt_amount").value!="")
    {
        sub_call_server("5@"+document.getElementById(cs[0]+"cmb_pay").value+"@"+document.getElementById(cs[0]+"txt_amount").value);
   }


}

//function mouse()
//{
//debugger;
//var dss=document.getElementById(cs[0]+"cmb_basic").value;
// if(document.getElementById(cs[0]+"txt_amount").value=="")
// {
// if (document.getElementById(cs[0]+"cmb_basic").value>=0)
// {
// document.getElementById(cs[0]+"txt_totalsal").value=""
// }
// }
//}





    
</script>
    <table align="center" border="1" style="width: 545px; height: 452px;">
        <tr>
            <td colspan="4" style="text-align: center">
                <strong><span style="color: #990033">SALARY INCREMENT<br />
                </span></strong>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lbl_err" runat="server" ForeColor="#400000" Width="543px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center; height: 229px;">
                <table align="center" style="width: 533px">
                    <tr>
                        <td colspan="4" style="height: 18px; text-align: center; background-color: #ffcccc;">
                            <table align="center" style="width: 533px" border="1">
                                <tr>
                                    <td colspan="2" style="height: 24px; text-align: left; width: 112px;">
                                        <strong><span style="color: #cc0033">
                                        Select&nbsp;Employee</span></strong></td>
                                    <td colspan="2" style="height: 24px; text-align: left">
                                        <asp:DropDownList ID="cmb_employee" runat="server" Width="420px" BackColor="WhiteSmoke" Font-Bold="True">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_employee">
                </cc1:ListSearchExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">
                            Name</td>
                        <td style="width: 100px">
                            <input id="txt_name" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; text-align: left">
                            Post</td>
                        <td style="width: 112px">
                            <input id="txt_post" runat="server" readonly="readonly" type="text" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">
                            Designation</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_designtn" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">
                            Department</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_deptmnt" runat="server" readonly="readonly" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">
                            Branch</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_branch" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">
                            Joining Date</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_joindt" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">
                            Firm</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_firm" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">
                            Current Basic</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_basic" runat="server" readonly="readonly" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 26px; text-align: left">
                            <table align="center" style="width: 533px">
                                <tr>
                                    <td colspan="4" style="height: 24px; text-align: center">
                                        <strong><span style="font-size: 11pt; color: #cc0033; text-decoration: underline;">INCREMENT DETAILS</span></strong></td>
                                </tr>
                                <tr>
                        <td style="width: 100px; height: 24px; text-align: left">
                            <strong><span style="color: #ff0033">Pay&nbsp;Scale</span></strong></td>
                        <td style="width: 82px; height: 24px">
                            <asp:DropDownList ID="cmb_pay" runat="server" Width="288px">
                            </asp:DropDownList></td>
                        <td style="width: 889px; height: 24px; text-align: left">
                            <strong><span style="color: #ff0033">Basic&nbsp;Pay</span></strong></td>
                        <td style="width: 119px; height: 24px">
                            <asp:DropDownList ID="cmb_basic" runat="server" Width="344px">
                            </asp:DropDownList></td>
                                </tr>
                                <tr id="spcl_row">
                                    <td style="width: 100px; height: 24px; text-align: left">
                                    </td>
                                    <td style="width: 82px; height: 24px">
                                    </td>
                                    <td style="width: 889px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Amount</span></strong></td>
                                    <td style="width: 119px; height: 24px">
                                        <asp:TextBox ID="txt_amount" runat="server" MaxLength="20" onkeypress="isNumeric()" onblur="detailDisplay()" Width="336px"></asp:TextBox></td>
                                </tr>
                                <tr>
                        <td style="width: 100px; height: 24px; text-align: left">
                            <strong><span style="color: #ff0033">
                            Effective&nbsp;Date</span></strong></td>
                        <td style="width: 82px; height: 24px; text-align: left">
                            <asp:TextBox ID="txt_effdt" runat="server" onkeyup="chkdt()" Width="280px"></asp:TextBox></td>
                        <td style="width: 889px; height: 24px; text-align: left">
                            <strong><span style="color: #ff0033">
                            Total&nbsp;Salary</span></strong></td>
                        <td style="width: 119px; height: 24px; text-align: left">
                            <asp:TextBox ID="txt_totalsal" runat="server" MaxLength="7" onkeypress="correct() "
                                ReadOnly="true" Width="336px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                
                                   <td style="width: 100px; height: 24px; text-align: left">
                            <strong><span style="color: #ff0033">
                            Remark</span></strong></td>
                                    <td id="Td4" runat="server" style="Width:292px; height: 28px; text-align: left">
                                    <asp:TextBox ID="text_remark" runat="server" Width="296px" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 117px;" colspan="4">
                <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_basic">
                </cc1:ListSearchExtender>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_effdt">
                </cc1:CalendarExtender>
                <table style="width: 349px">
                    <tr>
                        <td>
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" Font-Bold="True" Width="80px" BackColor="#C0C0FF" /></td>
                        <td>
                <asp:Button ID="cmd_exit" runat="server" Text="  Exit  " Font-Bold="True" Width="71px" BackColor="#C0C0FF" /></td>
                        <td>
                            <asp:Button ID="cmd_report" runat="server" Font-Bold="True" Text="Report" Width="92px" BackColor="#C0C0FF" /></td>
                    </tr>
                </table>
                <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_pay">
                </cc1:ListSearchExtender>
                <input id="hid_basic"  runat="server" style="width: 10px" type="hidden" /></td>
        </tr>
    </table>
</asp:Content>

