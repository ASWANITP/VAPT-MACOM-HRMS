<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_confirmation_frm.aspx.vb" Inherits="WebAppHRMS.TOUR_Tour_confirmation_frm_15d3fa521629" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript">

function exit()
{
   //alert("Closing");
   window.open('../home.aspx','_self');
   
}

</script>

    &nbsp;<br />
    <div style="text-align: center">
        &nbsp;<table border="1">
            <tr>
                <td >
                    <asp:Label ID="lbl_head" runat="server" Font-Bold="True" Text="TOUR CONFIRMATION AND CANCELLATION FORM"
                        Width="450px" BackColor="#FF8080"></asp:Label>
                    &nbsp; &nbsp; 
                    <br />
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>&nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE width=750 border=1><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 9px; TEXT-ALIGN: left">Slect&nbsp;Employee</TD><TD style="HEIGHT: 9px; TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="cmb_ecode" runat="server" Width="600px" BackColor="OldLace" OnSelectedIndexChanged="cmb_ecode_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w4">
                </asp:DropDownList> <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" __designer:wfdid="w56" PromptText TargetControlID="cmb_ecode"></cc1:ListSearchExtender></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 47px; TEXT-ALIGN: left">Employee&nbsp;Name</TD><TD style="WIDTH: 100px; HEIGHT: 47px; TEXT-ALIGN: left"><asp:TextBox id="txt_name" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w5" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 47px; TEXT-ALIGN: left">Duration</TD><TD style="WIDTH: 100px; HEIGHT: 47px; TEXT-ALIGN: left">&nbsp;<asp:TextBox id="txt_duration" runat="server" Width="225px" BackColor="OldLace" __designer:wfdid="w6" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left">Apply&nbsp;date</TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="txt_applydate" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w7" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left">Designation</TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="txt_designation" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w8" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left">Tour&nbsp;Place</TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="txt_place" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w9" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left">Tour&nbsp;Purpose</TD><TD style="WIDTH: 100px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="txt_purpose" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w10" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="TEXT-ALIGN: left" colSpan=2>Recommended&nbsp;By</TD><TD style="TEXT-ALIGN: center" colSpan=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox id="txt_recomended" runat="server" Width="229px" BackColor="OldLace" __designer:wfdid="w11"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 22px" colSpan=4><asp:Label id="lbl_message" runat="server" Width="728px" ForeColor="Red" Font-Size="Large" Height="16px" __designer:wfdid="w12"></asp:Label></TD></TR><TR><TD style="HEIGHT: 57px" colSpan=4><TABLE style="WIDTH: 100%" border=1><TBODY><TR><TD style="WIDTH: 100px"><asp:Button id="cmd_confirm" onclick="cmd_confirm_Click" runat="server" Width="119px" Text="CONFIRM" Font-Bold="True" __designer:wfdid="w13"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD colSpan=2><asp:Button id="cmd_Exit" onclick="cmd_Exit_Click" runat="server" Width="169px" Text="EXIT" Font-Bold="True" __designer:wfdid="w14"></asp:Button></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 84px"><asp:Button id="Cmd_cancel" onclick="Cmd_cancel_Click" runat="server" Width="165px" Text="CANCEL" Font-Bold="True" __designer:wfdid="w15"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel><input id="hidd_ecode" runat="server" type="hidden" /></td>
            </tr>
            <tr>
                <td style="height: 99px">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:Timer id="Timer1" runat="server" __designer:wfdid="w71" Interval="1000"></asp:Timer> 
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;
    <br />
    <br />
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;</div>
    </div>
    <br />
    &nbsp;&nbsp;<br />
    &nbsp; &nbsp;
    <br />
</asp:Content>

