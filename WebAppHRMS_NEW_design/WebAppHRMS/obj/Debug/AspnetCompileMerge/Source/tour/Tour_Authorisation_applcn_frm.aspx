<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_Authorisation_applcn_frm.aspx.vb" Inherits="WebAppHRMS.TOUR_Tour_Authorisation_applcn_frm_005b7ec02816" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">


<script type="text/javascript">
 // script will use to exit the button
 
function exit()
{
   //alert("Closing");
   window.open('../home.aspx','_self');
   
}

// in textbox print only numbers

function correct(a) 
    {
   //alert("ccccccccccc")
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
       if (isNaN(v))
          {
           document.getElementById("ctl00_cph_edp_"+a).value=""
           document.getElementById("ctl00_cph_edp_"+a).focus()
          }
    }
    
    
     // convert a string to uppercase letters
    
    function string(a) 
    {
   
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
       if (!isNaN(v))
          {
           document.getElementById("ctl00_cph_edp_"+a).value=""
           document.getElementById("ctl00_cph_edp_"+a).focus()
          }
         
       else
          {
          document.getElementById("ctl00_cph_edp_"+a).value=v.toUpperCase()
       document.getElementById("ctl00_cph_edp_"+a).focus()
       }
    }
    

</script>


    <div style="text-align: center">
        <br />
        &nbsp;
        <br />
        <br />
        <div style="text-align: center">
            <table>
                <tr>
                    <td style="width: 100px">
                        <table border="1">
        <tr>
            <td style="width: 18px; text-align: center">
                <table border="1" style="width: 700px">
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:Label ID="lbl_head" runat="server" Font-Bold="True" Text="TOUR AUTHORISATION APPLICATION"
                                Width="340px" BackColor="#FF8080"></asp:Label>
                            <br />
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
<TABLE style="WIDTH: 735px" border=1><TBODY><TR><TD style="HEIGHT: 68px; TEXT-ALIGN: left" colSpan=2>Select&nbsp;Employee</TD><TD style="HEIGHT: 68px; TEXT-ALIGN: left" colSpan=2><asp:DropDownList id="cmb_employee" runat="server" Width="235px" BackColor="#FFE0C0" __designer:wfdid="w62" AutoPostBack="True"></asp:DropDownList> <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" __designer:wfdid="w63" PromptText TargetControlID="cmb_employee"></cc1:ListSearchExtender></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Employee Code</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox style="COLOR: #330000" id="txt_ecode" runat="server" Width="155px" BackColor="BlanchedAlmond" __designer:wfdid="w64" AutoPostBack="True" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Designation</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_desig" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w65" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Name</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_name" runat="server" Width="155px" BackColor="BlanchedAlmond" __designer:wfdid="w66" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Post</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_post" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w67" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Department</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_department" runat="server" Width="153px" BackColor="BlanchedAlmond" __designer:wfdid="w68" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Branch</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_branch" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w69" ReadOnly="True"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                                <triggers>
<asp:AsyncPostBackTrigger ControlID="cmb_employee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Cmd_confirm" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="cmd_cancel" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Cmd_Clear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Cmd_exit" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                            </asp:UpdatePanel>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                <contenttemplate>
&nbsp;&nbsp; <TABLE width=760 border=1><TBODY><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Tour&nbsp;From</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_tfrmdt" runat="server" __designer:wfdid="w43" AutoPostBack="True"></asp:TextBox><BR /><cc1:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w44" TargetControlID="txt_tfrmdt" Format="dd/MMM/yyyy">
    </cc1:CalendarExtender></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Tour&nbsp;To</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_tortdt" runat="server" __designer:wfdid="w45" AutoPostBack="True"></asp:TextBox><BR /><cc1:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w46" TargetControlID="txt_tortdt" Format="dd/MMM/yyyy">
    </cc1:CalendarExtender></TD></TR></TBODY></TABLE><TABLE width=760 border=1 __designer:dtid="1407374883553308"><TBODY><TR __designer:dtid="1407374883553309"><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="1407374883553310">From&nbsp;Time</TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553311"><TABLE style="WIDTH: 21%" __designer:dtid="1407374883553312"><TBODY __designer:dtid="1407374883553313"><TR __designer:dtid="1407374883553314"><TD style="WIDTH: 49px; HEIGHT: 20px" __designer:dtid="1407374883553315"><asp:TextBox id="txt_hh1" onkeyup="correct ('txt_hh1')" runat="server" Width="29px" __designer:dtid="1407374883553316" __designer:wfdid="w47" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 20px" __designer:dtid="1407374883553317"><asp:TextBox id="txt_mm1" onkeyup="correct ('txt_mm1')" runat="server" Width="29px" __designer:dtid="1407374883553318" __designer:wfdid="w48" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 20px" __designer:dtid="1407374883553319"><asp:TextBox id="txt_ss1" onkeyup="correct ('txt_ss1')" runat="server" Width="29px" __designer:dtid="1407374883553320" __designer:wfdid="w49" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 88px; HEIGHT: 20px" __designer:dtid="1407374883553321"><asp:RadioButton id="rd_am1" runat="server" Text="AM" __designer:dtid="1407374883553322" __designer:wfdid="w50" GroupName="ab"></asp:RadioButton></TD><TD style="WIDTH: 73px; HEIGHT: 20px" __designer:dtid="1407374883553323"><asp:RadioButton id="rd_pm1" runat="server" Text="PM" __designer:dtid="1407374883553324" __designer:wfdid="w51" GroupName="ab"></asp:RadioButton></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553325">To Time</TD><TD style="WIDTH: 133px" __designer:dtid="1407374883553326"><TABLE style="WIDTH: 21%" __designer:dtid="1407374883553327"><TBODY><TR __designer:dtid="1407374883553328"><TD style="WIDTH: 100px" __designer:dtid="1407374883553329"><asp:TextBox id="txt_hh2" onkeyup="correct ('txt_hh2')" runat="server" Width="29px" __designer:dtid="1407374883553330" __designer:wfdid="w52" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553331"><asp:TextBox id="txt_mm2" onkeyup="correct ('txt_mm2')" runat="server" Width="29px" __designer:dtid="1407374883553332" __designer:wfdid="w53" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553333"><asp:TextBox id="txt_ss2" onkeyup="correct ('txt_ss2')" runat="server" Width="29px" __designer:dtid="1407374883553334" __designer:wfdid="w54" MaxLength="2"></asp:TextBox></TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553335"><asp:RadioButton id="rd_am2" runat="server" Text="AM" __designer:dtid="1407374883553336" __designer:wfdid="w55" GroupName="bc"></asp:RadioButton></TD><TD style="WIDTH: 53px" __designer:dtid="1407374883553337"><asp:RadioButton id="rd_pm2" runat="server" Text="PM" __designer:dtid="1407374883553338" __designer:wfdid="w56" GroupName="bc"></asp:RadioButton></TD></TR></TBODY></TABLE></TD></TR><TR __designer:dtid="1407374883553339"><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="1407374883553340">Tour&nbsp;Advance&nbsp;Rs</TD><TD style="WIDTH: 100px" __designer:dtid="1407374883553341"><asp:TextBox id="txt_advance" onkeyup="correct ('txt_advance')" runat="server" Width="209px" __designer:dtid="1407374883553342" __designer:wfdid="w57"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left" __designer:dtid="1407374883553343">Tour&nbsp;Place</TD><TD style="WIDTH: 133px" __designer:dtid="1407374883553344"><asp:TextBox id="txt_tourplace" onkeyup="string('txt_tourplace')" runat="server" Width="211px" __designer:dtid="1407374883553345" __designer:wfdid="w58"></asp:TextBox></TD></TR><TR __designer:dtid="1407374883553346"><TD style="TEXT-ALIGN: left" colSpan=2 __designer:dtid="1407374883553347">Tour&nbsp;Purpose</TD><TD colSpan=2 __designer:dtid="1407374883553348"><asp:TextBox id="txt_tourpurpose" onkeyup="string('txt_tourpurpose')" runat="server" Width="322px" __designer:dtid="1407374883553349" __designer:wfdid="w59"></asp:TextBox></TD></TR></TBODY></TABLE><asp:Timer id="Timer1" runat="server" __designer:wfdid="w60" Enabled="False" Interval="2000"></asp:Timer> <asp:Label id="Lbl_MESSAGE" runat="server" Width="739px" Text="Label_message" ForeColor="Red" BorderColor="White" __designer:dtid="3659174697238603" __designer:wfdid="w19"></asp:Label> 
</contenttemplate>
                            </asp:UpdatePanel></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:UpdatePanel id="UpdatePanel3" runat="server">
                                <contenttemplate>
<TABLE style="WIDTH: 760px" border=1><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:Button id="Cmd_confirm" runat="server" Width="98px" Text="CONFIRM"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:Button id="Cmd_Clear" runat="server" Width="98px" Text="CLEAR" OnClick="Cmd_Clear_Click"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:Button id="cmd_cancel" runat="server" Width="98px" Text="CANCEL"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:Button id="Cmd_exit" runat="server" Width="99px" Text="EXIT"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <input id="hidd_statusid" runat="server" type="hidden" />
            </td>
        </tr>
    </table>
                    </td>
                </tr>
            </table>
        </div>
                    <br />
        &nbsp;</div>
    &nbsp;&nbsp;<br />
    &nbsp;&nbsp; &nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp;<br />
    <br />
    <br />
    &nbsp;<div style="text-align: center">
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
    <br />
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;</div>
    </div>
</asp:Content>

