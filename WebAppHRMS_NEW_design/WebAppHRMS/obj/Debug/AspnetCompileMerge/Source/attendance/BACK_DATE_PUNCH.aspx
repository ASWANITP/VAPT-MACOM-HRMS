<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="BACK_DATE_PUNCH.aspx.vb" Inherits="WebAppHRMS.BACK_DATE_PUNCH_6fbd13442748" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript">
var cont_name=sal.split('txt');

function hour(a)
{

   var v=document.getElementById("ctl00_cph_edp_"+a).value;
  if(document.getElementById(cont_name[0]+"rd_am").checked==true)
  {  
    
  
  //alert(document.getElementById(cont_name[0]+"rd_am").checked)
    if(v>12 || isNaN(v))
    {   
     document.getElementById("ctl00_cph_edp_"+a).value=""
    }
   }
    if(document.getElementById(cont_name[0]+"rd_pm").checked==true)
  {  
    
  
  //alert(document.getElementById(cont_name[0]+"rd_am").checked)
    if(v>24 || isNaN(v))
    {   
     document.getElementById("ctl00_cph_edp_"+a).value=""
    }
   }
}

function minute(a)
{
 var v     
    v=document.getElementById("ctl00_cph_edp_"+a).value
    if(v>59 || isNaN(v))
    {   
     document.getElementById("ctl00_cph_edp_"+a).value=""
    }
}

function second(a)
{
 var v     
    v=document.getElementById("ctl00_cph_edp_"+a).value
   
    if(v>59 || isNaN(v))
    {   
     document.getElementById("ctl00_cph_edp_"+a).value=""
    }
}
function number(a)
{
var v     
    v=document.getElementById("ctl00_cph_edp_"+a).value
    if(isNaN(v))
    {   
     document.getElementById("ctl00_cph_edp_"+a).value=""
    }
}

</script>
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<TABLE border=1><TBODY><TR><TD colSpan=2><asp:Label id="Label5" runat="server" Width="400px" Text="PUNCHING"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="136px" Text="EMPLOYEE CODE"></asp:Label></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_ecode" onkeyup="number('txt_ecode')" runat="server" Width="152px" AutoPostBack="True" OnTextChanged="txt_ecode_TextChanged"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:Label id="Label2" runat="server" Width="88px" Text="NAME"></asp:Label></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_name" runat="server" Width="256px" BackColor="Bisque" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:Label id="Label3" runat="server" Width="88px" Text="SHIFT"></asp:Label></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_shift" runat="server" Width="256px" BackColor="Bisque" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:Label id="Label6" runat="server" Width="64px" Text="TIME"></asp:Label></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><TABLE><TBODY><TR><TD style="WIDTH: 23px"><asp:TextBox onblur="hour('txt_hh')" id="txt_hh" runat="server" Width="20px" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 27px"><asp:TextBox onblur="minute('txt_mm')" id="txt_mm" runat="server" Width="20px" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 25px"><asp:TextBox onblur="second('txt_ss')" id="txt_ss" runat="server" Width="20px" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 27px"><asp:RadioButton id="rd_am" runat="server" Text="AM" GroupName="t"></asp:RadioButton></TD><TD style="WIDTH: 24px"><asp:RadioButton id="rd_pm" runat="server" Text="PM" GroupName="t"></asp:RadioButton></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:Label id="Label7" runat="server" Text="DATE"></asp:Label></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_date" runat="server" Width="152px" AutoPostBack="True" OnTextChanged="txt_date_TextChanged"></asp:TextBox> <cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_date"></cc1:CalendarExtender></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:Label id="Label4" runat="server" Width="88px" Text="REASON"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:TextBox id="txt_reason" runat="server" Width="256px"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 28px; TEXT-ALIGN: center" colSpan=2><asp:Label id="lbl_mesage" runat="server" Width="410px" Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE>
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="txt_ecode" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="CLEAR" Width="80px" /></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

