<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="compensatory_apply.aspx.vb" Inherits="WebAppHRMS.leave_compensatory_apply_0ddee57a8529" title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
<!--
//return window_onload()
    window.onload = callback;
    function callback() {
        return window_onload();
    }
// -->
</script>

<script type="text/javascript">
var cont=cont_name.split("txt")
function fill_dtl()
{
sub_call_server("1$"+document.getElementById(cont[0]+"hid_emp_code").value);
}


function sub_call_receiver(arg1,arg2)
{
  var argg=arg1.split("@")
  if(argg[0]==11)
   {
   if(argg[1]==4)
   {
     alert("No Data");
     document.getElementById(cont[0]+"txt_ecode").value=""
     document.getElementById(cont[0]+"txt_ename").value=""
     document.getElementById(cont[0]+"txt_epost").value=""
     document.getElementById(cont[0]+"txt_edesig").value=""
     document.getElementById(cont[0]+"txt_edep").value=""
     document.getElementById(cont[0]+"txt_ebr").value=""
     document.getElementById(cont[0]+"txt_ejoindt").value=""
     document.getElementById(cont[0]+"txt_etype").value=""
   }
   else
   {
     var ar
     ar=argg[1].split("*")
     
     document.getElementById(cont[0]+"txt_ecode").value=ar[0]
     document.getElementById(cont[0]+"txt_ename").value=ar[1]
     document.getElementById(cont[0]+"txt_epost").value=ar[2]
     document.getElementById(cont[0]+"txt_edesig").value=ar[3]
     document.getElementById(cont[0]+"txt_edep").value=ar[4]
     document.getElementById(cont[0]+"txt_ebr").value=ar[5]
     document.getElementById(cont[0]+"txt_ejoindt").value=ar[6]
     document.getElementById(cont[0]+"txt_etype").value=ar[7]
  
  if(argg[2]==5)
   {
   alert("You Have No Compensatory To Apply");
   document.getElementById(cont[0]+"cmd_comp_det").options.length=0;
   }
  else
  {
  var comp_detail=argg[2].split("!");
  document.getElementById(cont[0]+"cmd_comp_det").options.length=0
        for(a=0;a<comp_detail.length-1;a++)
        {
            ar1=comp_detail[a].split("$")
            var option1=document.createElement("OPTION")
            option1.value=ar1[0]
            option1.text=ar1[1]            
            document.getElementById(cont[0]+"cmd_comp_det").add(option1)
        }
  
  }
   
 }
}        
  
 if(argg[0]==22)
     {
     
   
    if(argg[1]==4) 
    {
    alert('Already Applied On This Day');
    }
    else
    {
        alert(argg[2]);
        if(argg[1]==1) 
            {
                window.open("compensatory_apply.aspx",'_self')
            }
        else
            {
                return false;
            } 
    
    }
    }
}

function fill_comp_details()
{
if(document.getElementById(cont[0]+"cmd_comp_det").value=='-1')
{
    document.getElementById(cont[0]+"txt_comp_date").value="";
    document.getElementById(cont[0]+"txt_comp_name").value="";
    document.getElementById(cont[0]+"txt_st_name").value="";
    document.getElementById(cont[0]+"txt_exp_date").value="";
    document.getElementById(cont[0]+"txt_early_date").value="";
    document.getElementById(cont[0]+"txt_reason").value="";
}
else
{   
    var com_detail=document.getElementById(cont[0]+"cmd_comp_det").options[document.getElementById(cont[0]+"cmd_comp_det").selectedIndex].text.split("*")
    document.getElementById(cont[0]+"txt_comp_date").value=com_detail[0];
    document.getElementById(cont[0]+"txt_comp_name").value=com_detail[1];
    document.getElementById(cont[0]+"txt_st_name").value=com_detail[2];
    document.getElementById(cont[0]+"txt_exp_date").value=com_detail[3];
    document.getElementById(cont[0]+"txt_early_date").value="";
    document.getElementById(cont[0]+"txt_reason").value="";
}
}

function da(a)
{
      alert('Please Enter Date using Calendar!!');
      document.getElementById(cont[0]+a).value="";
      return false;
}
function error_dt()
{

if((document.getElementById(cont[0]+"txt_early_date").value)!="")
    {
    var dbd;
    var day3;
    var month3;
    var year3;

    value3 = document.getElementById(cont[0]+"txt_early_date").value;
    day3= value3.substring (0, value3.indexOf ("/"));
    month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
    year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);

    var value4 =document.getElementById(cont[0]+"txt_comp_date").value;
    var day4 = value4.substring (0, value4.indexOf ("/"));
    var month4 = value4.substring (value4.indexOf ("/")+1, value4.lastIndexOf ("/"));
    var year4 =value4.substring (value4.lastIndexOf ("/")+1, value4.length);
 
    date3 = year3+"/"+month3+"/"+day3;
    date4 = year4+"/"+month4+"/"+day4;
    firstDate = Date.parse(date3)
    secondDate= Date.parse(date4)
    msPerDay = 24 * 60 * 60 * 1000
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
     
    if (dbd>=0)
    {
    alert("Select Date Greter than Compensatory Date");
    document.getElementById(cont[0]+"txt_early_date").value="";
    document.getElementById(cont[0]+"txt_early_date").focus();
    return false;
    }   
        
  }   
  
  if(document.getElementById(cont[0]+"txt_exp_date").value!="")
    {
    var dbd;
    var day3;
    var month3;
    var year3;

    value3 = document.getElementById(cont[0]+"txt_early_date").value;
    day3= value3.substring (0, value3.indexOf ("/"));
    month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
    year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);

    var value4 =document.getElementById(cont[0]+"txt_exp_date").value;
    var day4 = value4.substring (0, value4.indexOf ("/"));
    var month4 = value4.substring (value4.indexOf ("/")+1, value4.lastIndexOf ("/"));
    var year4 =value4.substring (value4.lastIndexOf ("/")+1, value4.length);
 
    date3 = year3+"/"+month3+"/"+day3;
    date4 = year4+"/"+month4+"/"+day4;
    firstDate = Date.parse(date3)
    secondDate= Date.parse(date4)
    msPerDay = 24 * 60 * 60 * 1000
    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
    if (dbd<0)
    {
    alert("Select Date Below Or Equal To Expiry Date");
    document.getElementById(cont[0]+"txt_early_date").value="";
    document.getElementById(cont[0]+"txt_early_date").focus();
    return false;
    }   
        
  }  
   
}

function check_con()
{
 
    
    if((document.getElementById(cont[0]+"txt_ecode").value)=="")
   {
    alert("Error!.. Contact IT Department")
    return false;
   }

    if((document.getElementById(cont[0]+"txt_comp_date").value)=="")
   {
    alert("Select Compensatory")
    return false;
   }
   if((document.getElementById(cont[0]+"txt_early_date").value)=="")
   {
    alert("Select Compensatory Taken Date")
    return false;
   }
 
    if((document.getElementById(cont[0]+"txt_reason").value)=="")
   {
    alert("Enter Reason")
    return false;
   }
   
   

    arg=2+"$"+document.getElementById(cont[0]+"hid_emp_code").value+"#"+document.getElementById(cont[0]+"txt_early_date").value+"#"+document.getElementById(cont[0]+"cmd_comp_det").value+"#"+document.getElementById(cont[0]+"txt_reason").value+"#"+document.getElementById(cont[0]+"Txt_mail").value;
    sub_call_server(arg);
    return false;
   }

function Button2_onclick() 
{
  window.open("../../home.aspx",'_self')
}
function check_char()
{  
var regexLetter = /^([a-zA-Z ])*$/;   
   if(!regexLetter.test(document.getElementById(cont[0]+"txt_reason").value))
   {
     document.getElementById(cont[0]+"txt_reason").value=""
     alert('Type alphabets Only');
     return false;
   }
  document.getElementById(cont[0]+"txt_reason").value=document.getElementById(cont[0]+"txt_reason").value.toUpperCase()
}
function lbl1()
{
  //document.getElementById(cont[0]+"Label2").innerHTML="<html><body><marquee behavior=scroll direction=left loop=infinite scrollamount=20 scrolldelay=150>Enter your email id to get mail of compenstory status which you applied while recommending or sanctioning. </marquee></body></html>";
document.getElementById(cont[0]+"Label2").innerHTML="<html><body><marquee behavior=scroll direction=left loop=infinite scrollamount=20 scrolldelay=240><FONT color=blue><b>YOU CANNOT APPLY COMPENSATORY ON EXPIRY DATE & COMPENSATORY WILL BE AVAILABLE ONLY BEFORE EXPIRY DATE </b></font></marquee></body></html>";
}
function lbl2()
{
 //document.getElementById(cont[0]+"Label2").innerHTML="";
 document.getElementById(cont[0]+"Label2").innerHTML="<html><body><marquee behavior=scroll direction=left loop=infinite scrollamount=20 scrolldelay=240><FONT color=GREEN><b>YOU CANNOT APPLY COMPENSATORY ON EXPIRY DATE & COMPENSATORY WILL BE AVAILABLE ONLY BEFORE EXPIRY DATE </b></font></marquee></body></html>";
}

function window_onload() {
fill_dtl()
document.getElementById(cont[0]+"Label2").innerHTML="<html><body><marquee behavior=scroll direction=left loop=infinite scrollamount=20 scrolldelay=240><FONT color=RED><b>YOU CANNOT APPLY COMPENSATORY ON EXPIRY DATE & COMPENSATORY WILL BE AVAILABLE ONLY BEFORE EXPIRY DATE </b></font></marquee></body></html>";
}
function RegularExpValidation()
{
   
         var regularExp=/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
     
    var testItem=document.getElementById(cont[0]+'Txt_mail').value;
    if (regularExp.test(testItem)==0)
    {
      document.getElementById(cont[0]+'Txt_mail').value="";
      document.getElementById(cont[0]+'Txt_mail').focus();
      return;
    }
} 



</script>
    <div style="text-align: center">
        <table border="1" style="width: 646px; height: 59px">
            <tr>
                <td colspan="4" style="height: 24px; background-color: mintcream;">
                    <strong><span style="font-size: 14pt; color: crimson; font-family: Courier New">COMPENSATORY
                        APPLICATION</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 24px">
                    <asp:ScriptManager id="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Label ID="Label1" runat="server" Width="610px"></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Width="650px" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Code</span></td>
                <td style="width: 612px; height: 7px; text-align: left;">
                    <input id="txt_ecode" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Name</span></td>
                <td style="width: 88px; height: 7px; text-align: left;">
                    <input id="txt_ename" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Designation</span></td>
                <td style="width: 612px; height: 1px; text-align: left;">
                    <input id="txt_edesig" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Department</span></td>
                <td style="width: 88px; height: 1px; text-align: center;">
                    <input id="txt_edep" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 16px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Post</span></td>
                <td style="width: 612px; height: 16px; text-align: left;">
                    <input id="txt_epost" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 16px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Current&nbsp;branch</span></td>
                <td style="width: 88px; height: 16px; text-align: center;">
                    <input id="txt_ebr" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Join&nbsp;Date</span></td>
                <td style="width: 612px; height: 1px; text-align: left;">
                    <input id="txt_ejoindt" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Type</span></td>
                <td style="width: 88px; height: 1px; text-align: center;">
                    <input id="txt_etype" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 1px; text-align: center; background-color: mintcream;">
                    <span style="font-family: Courier New"><strong>COMPENSATORY DETAILS</strong></span></td>
            </tr>
           
    <%--</TR>--%>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">
                    Select&nbsp;Compensatory</span></td>
                <td align="left" colspan="3" style="height: 1px; text-align: left">
                    <asp:DropDownList ID="cmd_comp_det" runat="server" Width="468px" onchange="return fill_comp_details()" style="font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Compensatory&nbsp;Date</span></td>
                <td align="left" style="width: 612px; height: 1px; text-align: left">
                    <input id="txt_comp_date" runat="server" style="width: 117px; font-family: 'Courier New';"  type="text" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-family: Courier New">
                    Compensatory&nbsp;Name</span></td>
                <td style="width: 88px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_comp_name" runat="server" Width="117px" style="font-family: 'Courier New'" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left; font-family: 'Courier New';">
                    State&nbsp;Name</td>
                <td align="left" style="width: 612px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_st_name" runat="server" Width="117px" ReadOnly="True" style="font-family: 'Courier New'"></asp:TextBox></td>
                <td style="width: 100px; height: 1px; text-align: left; font-family: 'Courier New';">
                    Expiry&nbsp;Date</td>
                <td style="width: 88px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_exp_date" runat="server" Width="117px" ReadOnly="True" style="font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 1px; text-align: center; background-color: mintcream;">
                    <span style="font-family: Courier New"><strong>COMPENSATORY TAKING DETAILS</strong></span></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Applied&nbsp;Date</span></td>
                <td style="width: 612px; height: 1px; text-align: left;" align="left" ReadOnly="True">
                    <input id="txt_apply_date" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Compensatory&nbsp;Taken&nbsp;Date </span></td>
                <td style="width: 88px; height: 1px; text-align: left;">
                    <asp:TextBox ID="txt_early_date" runat="server" Width="117px"  style="font-family: 'Courier New'" onkeyup="return da('txt_early_date')" OnChange="return error_dt()"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-family: Courier New; font-size: 11pt;">Reason</span></td>
                <td colspan="3" style="height: 1px; text-align: left">
                    <asp:TextBox ID="txt_reason" runat="server" Width="367px" MaxLength="60" style="font-family: 'Courier New'" onkeyup="return check_char()"></asp:TextBox>
                    </td>
            </tr>
                <tr>
                    <td style="width: 100px; height: 1px; text-align: left">
                        Enter&nbsp;Your&nbsp;Email&nbsp;id<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txt_mail"
                            ErrorMessage="INVALID -EMAIL ID !" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="166px"></asp:RegularExpressionValidator></td>
                    <td colspan="3" style="height: 1px; text-align: left">
                        <asp:TextBox ID="Txt_mail" onchange="RegularExpValidation()" onmouseover="lbl1()" onmouseout="lbl2()" runat="server" Width="433px" MaxLength="60"></asp:TextBox>&nbsp;
                        </td>
                </tr>
            <tr>
                <td colspan="4" style="height: 15px">
                    <asp:Button ID="Button1" runat="server" Text="APPLY" Width="151px" OnClientClick="return check_con()" style="font-family: 'Courier New'" Font-Bold="True"/>&nbsp;
                    &nbsp;<input id="Button2" style="width: 121px; font-family: 'Courier New'; font-weight: bold;" type="button" value="EXIT" onclick="return Button2_onclick()" />&nbsp;&nbsp;&nbsp;<br />
                    &nbsp; &nbsp;
                    
                </td>
            </tr>

        </TABLE>
    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_early_date">
                    </cc1:CalendarExtender>
                    <input id="hid_emp_code" runat="server" type="hidden" style="width: 1px" />
</asp:Content>

