<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="appln_received_shortlisted.aspx.vb" Inherits="WebAppHRMS.report_appln_received_and_shortlisted_appln_received_shortlisted_5e9742ff6670" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cs = cont_name.split("chk");

// <!CDATA[

function TABLE1_onclick() {

}

function cmd_exit_onclick() {
            window.open('../home.aspx','_self');
}
function enablecombo(a,b,c)
{
 if (c=='2')
    {
     if (document.getElementById(cs[0]+a).checked==true )
        {
              document.getElementById(cs[0]+"cmb_State").disabled=false;
              document.getElementById(cs[0]+"cmb_district").disabled=false;
              document.getElementById(cs[0]+"cmb_qualification").disabled=false;
              document.getElementById(cs[0]+"cmb_gender").disabled=false;
              document.getElementById(cs[0]+"txt_agefrom").disabled=false;
              document.getElementById(cs[0]+"txt_ageto").disabled=false;
              document.getElementById(cs[0]+"txt_dtfrom").disabled=false;
              document.getElementById(cs[0]+"txt_dtto").disabled=false;
              
              document.getElementById(cs[0]+"chk_State").checked=true;
              document.getElementById(cs[0]+"chk_district").checked=true;
              document.getElementById(cs[0]+"chk_qualification").checked=true;
              document.getElementById(cs[0]+"chk_gender").checked=true;
              document.getElementById(cs[0]+"chk_age").checked=true;
              document.getElementById(cs[0]+"chk_date").checked=true;
          
                 
         }
         if (document.getElementById(cs[0]+a).checked==false )
        {
              document.getElementById(cs[0]+"cmb_State").disabled=true;
              document.getElementById(cs[0]+"cmb_district").disabled=true;
              document.getElementById(cs[0]+"cmb_qualification").disabled=true;
              document.getElementById(cs[0]+"cmb_gender").disabled=true;
              document.getElementById(cs[0]+"txt_agefrom").disabled=true;
              document.getElementById(cs[0]+"txt_ageto").disabled=true;
              document.getElementById(cs[0]+"txt_dtfrom").disabled=true;
              document.getElementById(cs[0]+"txt_dtto").disabled=true;
              
               document.getElementById(cs[0]+"chk_State").checked=false;
              document.getElementById(cs[0]+"chk_district").checked=false;
              document.getElementById(cs[0]+"chk_qualification").checked=false;
              document.getElementById(cs[0]+"chk_gender").checked=false;
              document.getElementById(cs[0]+"chk_age").checked=false;
              document.getElementById(cs[0]+"chk_date").checked=false;
                 
         }
    
    }
    else if(c=='1')
    {
      if (document.getElementById(cs[0]+a).checked==true )
        {
              document.getElementById(cs[0]+b).disabled=false;
               }
     if (document.getElementById(cs[0]+a).checked==false )
        {
              document.getElementById(cs[0]+b).disabled=true;
        } 
     }  
     else
     {
     if (document.getElementById(cs[0]+a).checked==true )
        {
              document.getElementById(cs[0]+b).disabled=false;
              document.getElementById(cs[0]+c).disabled=false;
        }
     if (document.getElementById(cs[0]+a).checked==false )
        {
              document.getElementById(cs[0]+b).disabled=true;
              document.getElementById(cs[0]+c).disabled=true;
        } 
     }  
}
function functionvalidate()
{
        if (document.getElementById(cs[0]+"chk_age").checked==true )
        {
              if ((document.getElementById(cs[0]+"txt_agefrom").value=="") || (isNaN(document.getElementById(cs[0]+"txt_agefrom").value)) || (document.getElementById(cs[0]+"txt_ageto").value=="") || (isNaN(document.getElementById(cs[0]+"txt_ageto").value)))
               {
                 document.getElementById(cs[0]+"txt_agefrom").value=""
                 document.getElementById(cs[0]+"txt_ageto").value=""
                 alert('Please Enter Age Limit');
                 return false;
               }
        }
    
        if (document.getElementById(cs[0]+"chk_date").checked==true )
        {
              if ((document.getElementById(cs[0]+"txt_dtfrom").value=="") || (document.getElementById(cs[0]+"txt_dtto").value==""))
               {
                 alert('Please Enter Date');
                 return false;
               }
        }
          
}
  function isNumberKey(ids)
{ //debugger;
 var charcode = (event.which) ? event.which : event.keyCode
 if(ids==1)
 {
 if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32))
  {
     return true;
   } 
    else
     return false;  
  }
 if(ids==2)
 {
 if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32) ||(charcode > 46 && charcode <58))
  {
     return true;
   } 
    else
     return false;  
  }
  
 if(ids==3)    
 {
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))
  {
    return false;
  } 
    else
     return true;  
 }
     
}
 function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cs[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");  
   document.getElementById(cs[0]+Control).value=""
   return false;
  }
} 
// ]]>
</script>

<div style="text-align:center " >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<TABLE style="WIDTH: 466px; HEIGHT: 259px" border=1><TBODY><TR><TD style="HEIGHT: 21px; TEXT-ALIGN: center" colSpan=3><SPAN><asp:RadioButton id="rdbapp" runat="server" Text="Applications Received" GroupName="g1" Checked="True" AutoPostBack="True" OnCheckedChanged="rdbapp_CheckedChanged1"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButton id="Rdbshort" runat="server" Text="Short Listed" GroupName="g1" AutoPostBack="True" OnCheckedChanged="Rdbshort_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR />&nbsp; &nbsp; &nbsp; </SPAN></TD></TR><TR><TD style="WIDTH: 1128px; HEIGHT: 25px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="Chk_state" onclick="return enablecombo('Chk_state','cmb_state','1')" runat="server" Text=" State" AutoPostBack="True" OnCheckedChanged="chk_state_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 25px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_state" runat="server" Width="222px" AutoPostBack="True" OnSelectedIndexChanged="cmb_state_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 1128px; HEIGHT: 25px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="chk_district" onclick="return enablecombo('Chk_district','cmb_district','1')" runat="server" Text="   District" AutoPostBack="True"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 25px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_district" runat="server" Width="224px" AutoPostBack="True" OnSelectedIndexChanged="cmb_district_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 1128px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="chk_qualification" onclick="return enablecombo('Chk_qualification','cmb_qualification','1')" runat="server" Text="   Qualification" AutoPostBack="True"></asp:CheckBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_qualification" runat="server" Width="224px" AutoPostBack="True" OnSelectedIndexChanged="cmb_qualification_SelectedIndexChanged"></asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 1128px; HEIGHT: 26px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="chk_gender" onclick="return enablecombo('Chk_gender','cmb_gender','1')" runat="server" Text="   Gender" AutoPostBack="True"></asp:CheckBox></TD><TD style="WIDTH: 100px; HEIGHT: 26px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_gender" runat="server" Width="224px" AutoPostBack="True" OnSelectedIndexChanged="cmb_gender_SelectedIndexChanged"><asp:ListItem Value="0">Male</asp:ListItem>
<asp:ListItem Value="1">Female</asp:ListItem>
</asp:DropDownList> </TD></TR><TR><TD style="WIDTH: 1128px; HEIGHT: 10px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="chk_age" onclick="return enablecombo('Chk_age','txt_Agefrom','txt_Ageto')" runat="server" Text="   Age" AutoPostBack="True">
    </asp:CheckBox> </TD><TD style="WIDTH: 100px; HEIGHT: 10px; TEXT-ALIGN: left"><TABLE style="WIDTH: 235px; HEIGHT: 25px" border=0><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 24px">from&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:TextBox id="txt_agefrom" onkeypress="return isNumberKey(3)" runat="server" Width="54px" Height="16px" MaxLength="2"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 24px">to</TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:TextBox id="txt_ageto" onkeypress="return isNumberKey(3)" runat="server" Width="52px" Height="16px" MaxLength="2"></asp:TextBox> </TD></TR></TBODY></TABLE></TD></TR><TR><TD style="WIDTH: 1128px; HEIGHT: 10px; TEXT-ALIGN: left" colSpan=2>&nbsp; <asp:CheckBox id="chk_date" onclick="return enablecombo('Chk_date','txt_dtfrom','txt_dtto')" runat="server" Width="155px" Text="  Application Date " AutoPostBack="True" OnCheckedChanged="chk_date_CheckedChanged"></asp:CheckBox> </TD><TD style="WIDTH: 100px; HEIGHT: 10px; TEXT-ALIGN: left"><cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_dtto"></cc1:CalendarExtender> <TABLE style="WIDTH: 225px; HEIGHT: 23px" border=1><TBODY><TR><TD style="WIDTH: 74px; HEIGHT: 24px">from&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:TextBox id="Txt_dtfrom" runat="server" Width="136px" Height="16px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 74px; HEIGHT: 24px">to</TD><TD style="WIDTH: 100px; HEIGHT: 24px"><asp:TextBox id="Txt_dtto" runat="server" Width="136px" Height="16px"></asp:TextBox></TD></TR></TBODY></TABLE> <cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txt_dtfrom" Format="dd/MMM/yyyy"></cc1:CalendarExtender></TD></TR><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left" colSpan=3>&nbsp; <asp:CheckBox id="chk_all" onclick="return enablecombo('Chk_all','txt_Agefrom','2')" runat="server" Text="   All     " AutoPostBack="True" OnCheckedChanged="chk_all_CheckedChanged"></asp:CheckBox></TD></TR><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: center" colSpan=3><asp:Label id="lbl_msg" runat="server" Width="388px" ForeColor="Red"></asp:Label></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel><asp:HiddenField ID="hid1" runat="server" Value="1" />
    <div style="text-align: center">
        <table border="1" id="TABLE1" onclick="return TABLE1_onclick()" style="width: 186px; height: 34px">
            <tr>
                <td style="width: 100px">
                <asp:Button ID="cmd_report" runat="server" OnClientClick="return functionvalidate()" Text="REPORT" /></td>
                <td style="width: 100px">
                    <input id="cmd_exit" style="width: 74px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
  </div>  
</asp:Content>

