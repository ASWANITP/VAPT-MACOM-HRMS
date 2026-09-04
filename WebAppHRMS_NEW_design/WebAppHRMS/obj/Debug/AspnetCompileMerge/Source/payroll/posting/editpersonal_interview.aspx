<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editpersonal_interview.aspx.vb" Inherits="WebAppHRMS.edit_interview_details_editpersonal_interview_38847f0f8765" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont_name=header.split("txt")

// <!CDATA[

function cmd_exit_onclick() {
window.open('../../home.aspx','_self');
}

function upperconverter1()
{
    document.getElementById(cont_name[0]+"txt_house1").value=document.getElementById(cont_name[0]+"txt_house1").value.toUpperCase();
  }
   function upperconverter2()
{
    document.getElementById(cont_name[0]+"txt_house2").value=document.getElementById(cont_name[0]+"txt_house2").value.toUpperCase();
}
function upperconverter3()
{
    document.getElementById(cont_name[0]+"txt_lmark").value=document.getElementById(cont_name[0]+"txt_lmark").value.toUpperCase();
}
function upperconverter4()
{
    document.getElementById(cont_name[0]+"txt_idno").value=document.getElementById(cont_name[0]+"txt_idno").value.toUpperCase();

}
  

// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 937px; HEIGHT: 235px" border=1><TBODY><TR><TD style="HEIGHT: 26px; TEXT-ALIGN: right" colSpan=2><SPAN style="FONT-SIZE: 13pt">Select Application No :</SPAN> </TD><TD style="HEIGHT: 26px; TEXT-ALIGN: left" colSpan=2><asp:DropDownList id="cmb_appno" runat="server" Width="366px" __designer:wfdid="w6" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 186px; HEIGHT: 28px; TEXT-ALIGN: left">Name :</TD><TD style="HEIGHT: 28px; TEXT-ALIGN: left" colSpan=3><asp:TextBox id="txt_name" runat="server" Width="374px" BackColor="Ivory" ForeColor="Red" Font-Bold="True" __designer:wfdid="w7" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 186px; HEIGHT: 216px; TEXT-ALIGN: left">Address : </TD><TD style="HEIGHT: 216px; TEXT-ALIGN: left" colSpan=3><DIV style="TEXT-ALIGN: left"><DIV style="TEXT-ALIGN: left">&nbsp;</DIV></DIV><DIV style="TEXT-ALIGN: left"><DIV style="TEXT-ALIGN: left"><TABLE style="WIDTH: 764px; HEIGHT: 143px" border=1><TBODY><TR><TD style="HEIGHT: 23px; TEXT-ALIGN: center" colSpan=2>Permanant</TD><TD style="HEIGHT: 23px; TEXT-ALIGN: center" colSpan=2>Present</TD></TR><TR><TD style="WIDTH: 96px; HEIGHT: 28px">House Name : </TD><TD style="WIDTH: 102px; HEIGHT: 28px"><asp:TextBox id="txt_house1" runat="server" Width="264px" __designer:wfdid="w8" AutoPostBack="True"></asp:TextBox></TD><TD style="WIDTH: 88px; HEIGHT: 28px">House Name : </TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txt_house2" runat="server" Width="252px" __designer:wfdid="w9" AutoPostBack="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 96px">State : </TD><TD style="WIDTH: 102px"><asp:DropDownList id="cmb_state1" runat="server" Width="210px" __designer:wfdid="w10" AutoPostBack="True">
                                            </asp:DropDownList></TD><TD style="WIDTH: 88px">State : </TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_state2" runat="server" Width="210px" __designer:wfdid="w11" AutoPostBack="True">
                                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 96px; HEIGHT: 26px">District :</TD><TD style="WIDTH: 102px; HEIGHT: 26px"><asp:DropDownList id="cmb_district1" runat="server" Width="210px" __designer:wfdid="w12" AutoPostBack="True">
                                            </asp:DropDownList></TD><TD style="WIDTH: 88px; HEIGHT: 26px">District :</TD><TD style="WIDTH: 100px; HEIGHT: 26px"><asp:DropDownList id="cmb_district2" runat="server" Width="210px" __designer:wfdid="w13" AutoPostBack="True">
                                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 96px">Post : </TD><TD style="WIDTH: 102px"><asp:DropDownList id="cmb_post1" runat="server" Width="210px" __designer:wfdid="w14" AutoPostBack="True">
                                            </asp:DropDownList></TD><TD style="WIDTH: 88px">Post : </TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_post2" runat="server" Width="210px" __designer:wfdid="w15" AutoPostBack="True">
                                            </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 96px; HEIGHT: 28px">PIN : </TD><TD style="WIDTH: 102px; HEIGHT: 28px"><asp:TextBox id="txt_pin1" runat="server" Width="202px" __designer:wfdid="w16" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 88px; HEIGHT: 28px">PIN : </TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txt_pin2" runat="server" Width="202px" __designer:wfdid="w17" ReadOnly="True"></asp:TextBox></TD></TR></TBODY></TABLE></DIV></DIV><asp:CheckBox id="chk_same" runat="server" Width="405px" Text="Present Address Same As Permanant Address" Font-Bold="True" __designer:wfdid="w18" AutoPostBack="True"></asp:CheckBox></TD></TR><TR><TD style="WIDTH: 186px; TEXT-ALIGN: left">Land Mark :</TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:TextBox id="txt_lmark" runat="server" Width="756px" __designer:wfdid="w19" AutoPostBack="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 186px; HEIGHT: 13px; TEXT-ALIGN: left">Phone No. (Residence) : </TD><TD style="WIDTH: 392px; HEIGHT: 13px; TEXT-ALIGN: left"><TABLE border=0><TBODY><TR><TD style="WIDTH: 48px"><asp:CheckBox id="Chk_pp" runat="server" Width="50px" Text=" PP" __designer:wfdid="w20"></asp:CheckBox></TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_phone" runat="server" Width="155px" __designer:wfdid="w21"></asp:TextBox></TD></TR></TBODY></TABLE><asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" __designer:wfdid="w22" ControlToValidate="txt_phone" EnableTheming="True" ErrorMessage="Please Enter Correctly" ValidationExpression='^([0-9"-"\s])*$'></asp:RegularExpressionValidator></TD><TD style="WIDTH: 56px; HEIGHT: 13px; TEXT-ALIGN: left">Contact No :&nbsp;&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 13px; TEXT-ALIGN: left"><asp:TextBox id="txt_contact" runat="server" __designer:wfdid="w23"></asp:TextBox><BR /><asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" Width="155px" __designer:wfdid="w24" ControlToValidate="txt_contact" ErrorMessage="Please Enter Correctly" ValidationExpression='^([0-9"-"\s])*$'></asp:RegularExpressionValidator></TD></TR><TR><TD style="WIDTH: 186px; HEIGHT: 23px; TEXT-ALIGN: left">Email :<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" __designer:wfdid="w25" ControlToValidate="txt_email" ErrorMessage="Please Enter Correctly" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD><TD style="WIDTH: 392px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="txt_email" runat="server" Width="211px" __designer:wfdid="w26"></asp:TextBox><SPAN style="FONT-SIZE: 1pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</SPAN></TD><TD style="WIDTH: 56px; HEIGHT: 23px; TEXT-ALIGN: left">Blood Group :</TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_bg" runat="server" Width="154px" __designer:wfdid="w27" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 186px; TEXT-ALIGN: left">ID Proof :</TD><TD style="WIDTH: 392px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_idproof" runat="server" Width="218px" __designer:wfdid="w28" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 56px; TEXT-ALIGN: left">ID No : </TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_idno" runat="server" __designer:wfdid="w29"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
    <br />
      <div style="text-align: center">
    &nbsp;&nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="EDIT"
        Width="82px" style="cursor: hand" />&nbsp;
          <input id="cmd_exit" onclick="return cmd_exit_onclick()" style="width: 78px; cursor: hand;" type="button"
              value="EXIT" /><br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </div>
    <div style="text-align: center">
        &nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;</div>
</asp:Content>

