<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_with_tfr_frm2_Jwell.aspx.vb" Inherits="WebAppHRMS.promotion_with_tfr_frm2_Jwell_ff7db9055124" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script type="text/javascript">
function exit()
{
window.open('../home.aspx','_self');
}
var cs = cont_name.split("Txt");
function change(a) {
var str=document.getElementById(cs[0]+a).value;
 if (isNaN(str))
   {
    document.getElementById(cs[0]+a).value="";
    document.getElementById(cs[0]+a).focus;
    return false;
   }

}
function van()
{
alert("please select date from calendar!")
return false;
}
</script>
    <br />
    <br />
    <div style="text-align: center">
        &nbsp;</div>
    <br />
    <br />
    &nbsp;&nbsp;
        <table border="1" width="750"  align="center">
            <tr>
                <td colspan="3" style="height: 19px; text-align: center">
                    <strong style="background-color: #ff6666"><span style="background-color: #ffcc66">PROMOTION&nbsp;WITH&nbsp;TRANSFER</span><asp:ScriptManager
                        id="ScriptManager1" runat="server"></asp:ScriptManager><br />
                    </strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 16px; text-align: center">
                    <div style="text-align: center">
                        <table style="height: 45px; background-color: #ffffcc">
                            <tr>
                                <td style="width: 187px; height: 24px">
                                    <strong><span style="color: #660000">Select Employee</span></strong></td>
                                <td style="width: 134px; height: 24px">
                                    <asp:DropDownList ID="cmb_employee" runat="server" Height="27px"
                                        Width="574px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_employee">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; background-color: #ff9933; text-align: center">
                    <strong>CURRENT&nbsp;EMPLOYEE&nbsp;DETAILS.</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px; background-color: cornsilk; text-align: center">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <contenttemplate>
<DIV style="TEXT-ALIGN: center"><TABLE style="WIDTH: 761px" border=1><TBODY><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Name</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_name" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Post&nbsp;Offered</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_postoffered" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Deisgnation</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_designation" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Department</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_department" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">Location&nbsp;(branch)</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_branch" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Current Firm</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="Txt_currfirm" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD></TR></TBODY></TABLE></DIV>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="cmb_employee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center; background-color: #ff9900;">
                    <strong>&nbsp;EMPLOYEE&nbsp;TRANSFER&nbsp;DETAILS</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel id="UpdatePanel3" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 759px" border=1>
<TBODY><TR><TD style="WIDTH: 71px; HEIGHT: 26px; TEXT-ALIGN: left">Prop.&nbsp;Location</TD>
<TD style="WIDTH: 100px; HEIGHT: 26px; TEXT-ALIGN: left">
<asp:DropDownList id="cmb_branch" tabIndex=1 runat="server" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="cmb_branch_SelectedIndexChanged"></asp:DropDownList>
</TD><TD style="WIDTH: 34px; HEIGHT: 26px; TEXT-ALIGN: left">Department</TD><TD style="WIDTH: 100px; HEIGHT: 26px; TEXT-ALIGN: left">
<asp:DropDownList id="cmb_department" tabIndex=2 runat="server" Width="228px" AutoPostBack="True">
</asp:DropDownList></TD></TR><TR>
<TD style="WIDTH: 34px; HEIGHT: 26px; TEXT-ALIGN: left">Post&nbsp;Offered</TD>
<TD style="WIDTH: 34px; HEIGHT: 36px; TEXT-ALIGN: left">
<asp:DropDownList id="cmb_postoffered" tabIndex=3 runat="server" Width="228px" Height="24px" AutoPostBack="True" OnSelectedIndexChanged="cmb_postoffered_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 34px; HEIGHT: 9px; TEXT-ALIGN: left">Deputation</TD>
<TD style="WIDTH: 100px; HEIGHT: 39px; TEXT-ALIGN: left"><asp:RadioButton id="rdbtn_yes" tabIndex=5 runat="server" Width="34px" Text="YES" Font-Size="Smaller" Font-Bold="True" Height="21px" AutoPostBack="True" GroupName="Dep" OnCheckedChanged="rdbtn_yes_CheckedChanged"></asp:RadioButton> <asp:RadioButton id="rdbtn_no" tabIndex=4 runat="server" Width="35px" Text="NO" Font-Size="Smaller" Font-Bold="True" Height="21px" AutoPostBack="True" GroupName="Dep" OnCheckedChanged="rdbtn_no_CheckedChanged" Checked="True"></asp:RadioButton></TD></TR><TR><TD style="WIDTH: 71px; HEIGHT: 28px; TEXT-ALIGN: left">Relieve&nbsp;Date</TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:TextBox id="txt_relievedate" tabIndex=7 onkeypress="return van()" runat="server" Width="219px" AutoPostBack="True" OnTextChanged="txt_relievedate_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 34px; HEIGHT: 28px; TEXT-ALIGN: left">Select&nbsp;Firm</TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_firm" tabIndex=6 runat="server" Width="228px" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 71px; TEXT-ALIGN: left">Reporting&nbsp;(Join)&nbsp;Date</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_joindate" tabIndex=8 onkeypress="return van()" runat="server" Width="219px" AutoPostBack="True" OnTextChanged="txt_joindate_TextChanged"></asp:TextBox></TD><TD colSpan=2></TD></TR><TR><TD colSpan=4><TABLE style="BORDER-LEFT-COLOR: #ffcc33; BORDER-BOTTOM-COLOR: #ffcc33; BORDER-TOP-STYLE: ridge; BORDER-TOP-COLOR: #ffcc33; BORDER-RIGHT-STYLE: ridge; BORDER-LEFT-STYLE: ridge; TEXT-ALIGN: center; BORDER-RIGHT-COLOR: #ffcc33; BORDER-BOTTOM-STYLE: ridge" border=1><TBODY><TR><TD style="HEIGHT: 23px; TEXT-ALIGN: left" colSpan=4><DIV style="TEXT-ALIGN: center"><cc1:ListSearchExtender id="ListSearchExtender7" runat="server" TargetControlID="cmb_state"></cc1:ListSearchExtender> <cc1:ListSearchExtender id="ListSearchExtender8" runat="server" TargetControlID="cmb_hostel"></cc1:ListSearchExtender> <TABLE style="WIDTH: 800px"><TBODY><TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2><TABLE style="WIDTH: 332px" id="cathos" runat="server"><TBODY><TR><TD style="WIDTH: 35px; HEIGHT: 24px">Select&nbsp;category</TD><TD style="WIDTH: 65px; HEIGHT: 24px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_cat" runat="server" Width="226px" AutoPostBack="True" OnSelectedIndexChanged="cmb_cat_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 115px; HEIGHT: 24px">Select Hostel</TD><TD style="WIDTH: 100px; HEIGHT: 24px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_hostel" runat="server" Width="346px" AutoPostBack="True" OnSelectedIndexChanged="cmb_hostel_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 24px">Select State</TD><TD style="WIDTH: 62px; HEIGHT: 24px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_state" runat="server" Width="214px" AutoPostBack="True" OnSelectedIndexChanged="cmb_state_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2>Total&nbsp;Capacity&nbsp;-<asp:Label id="totcap" runat="server" Width="36px" Text="0" ForeColor="#0000C0" Font-Bold="True"></asp:Label>&nbsp;&nbsp; Present&nbsp;Capacity&nbsp;&nbsp;-<asp:Label id="pcap" runat="server" Width="30px" Text="0" ForeColor="Navy" Font-Bold="True"></asp:Label></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE></TD></TR><TR><TD style="TEXT-ALIGN: right" colSpan=2><SPAN style="COLOR: #990033"><SPAN style="COLOR: #ff0033">*</SPAN>Distance between home &amp; working branch (in Km)</SPAN></TD><TD style="TEXT-ALIGN: left" colSpan=2><asp:TextBox id="Txt_dist" onkeyup="return change('Txt_dist')" runat="server" MaxLength="5"></asp:TextBox></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txt_relievedate" Format="dd/MMM/yyyy">
                                </cc1:CalendarExtender> <cc1:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="txt_joindate" Format="dd/MMM/yyyy">
                                    </cc1:CalendarExtender>&nbsp; <cc1:ListSearchExtender id="ListSearchExtender5" runat="server" TargetControlID="cmb_postoffered">
                                </cc1:ListSearchExtender> <cc1:ListSearchExtender id="ListSearchExtender3" runat="server" TargetControlID="cmb_branch">
                                </cc1:ListSearchExtender> <cc1:ListSearchExtender id="ListSearchExtender4" runat="server" TargetControlID="cmb_department">
                                </cc1:ListSearchExtender> <cc1:ListSearchExtender id="ListSearchExtender6" runat="server" TargetControlID="cmb_firm"></cc1:ListSearchExtender> 
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; background-color: #ff9900; text-align: center">
                    <strong>EMPLOYEE&nbsp;PROMOTION&nbsp;DETAILS</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel id="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
<TABLE style="WIDTH: 757px" border=1><TBODY>
    <tr>
        <td colspan="2" style="text-align: left">
            Designation</td>
        <td colspan="2" style="text-align: left">
            <asp:DropDownList ID="cmb_desig" runat="server" Width="301px">
            </asp:DropDownList></td>
    </tr>
    <TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">
    Pay Scale</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><cc1:ListSearchExtender id="ListSearchExtender2" runat="server" TargetControlID="cmb_designation">
                                </cc1:ListSearchExtender> <asp:DropDownList id="cmb_designation" tabIndex=9 runat="server" Width="230px" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Effective&nbsp;Date</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txt_effectivedate" Format="dd/MMM/yyyy">
                                </cc1:CalendarExtender> <asp:TextBox id="txt_effectivedate" onkeypress="return van()" tabIndex=11 runat="server" Width="219px" OnTextChanged="txt_effectivedate_TextChanged"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left">Basic&nbsp;Salary</TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_pay_amnt" tabIndex=10 runat="server" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="cmb_pay_amnt_SelectedIndexChanged"></asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left">Total&nbsp;Salary</TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><asp:TextBox id="txt_totalsalary" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></TD></TR> <TR><TD style="WIDTH: 100px; TEXT-ALIGN: left">
                                    Enter Amount</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">
                                    <asp:TextBox ID="txt_enter" runat="server" Width="221px"></asp:TextBox><TR><TD style="TEXT-ALIGN: left" colSpan=2>&nbsp;Whether Promotion / depromotion</TD><TD style="TEXT-ALIGN: left" colSpan=2><asp:RadioButton id="rbd_pro" runat="server" Width="98px" Text="Promotion" Font-Bold="True" AutoPostBack="True" GroupName="p" OnCheckedChanged="rbd_pro_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton id="rbd_depro" runat="server" Text="Depromotion" Font-Bold="True" AutoPostBack="True" GroupName="g" OnCheckedChanged="RadioButton2_CheckedChanged"></asp:RadioButton></TD></TR></TBODY></TABLE>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="cmb_designation" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="cmb_pay_amnt" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<asp:Label id="lbl_message" runat="server" Width="750px" BackColor="PaleGoldenrod" Text="Label" ForeColor="Red" Font-Bold="True"></asp:Label> <asp:Timer id="Timer1" runat="server" Interval="1000"></asp:Timer> 
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td align="center"  >
                    </td>
                <td align="center"  >
                    </td>
                <td align="center"  >
                    </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <div style="text-align: center">
                        <table style="width: 768px">
                            <tr>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_clear" runat="server" Font-Bold="True" Style="background-color: #ccccff"
                        Text="CLEAR" Width="99px" TabIndex="12" /></td>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Style="background-color: #ccccff"
                        Text="CONFIRM" Width="99px" BackColor="PeachPuff" BorderColor="#E0E0E0" TabIndex="13" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Button1" runat="server" BackColor="#C0C0FF" BorderColor="#E0E0E0"
                                        Text="VIEW REPORT" Width="109px" Font-Bold="True" /></td>
                                <td style="width: 100px">
                    <asp:Button ID="cmd_Exit" runat="server"  Font-Bold="True" Style="background-color: #ccccff"
                        Text="EXIT" Width="91px" TabIndex="14" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    <br />
    &nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;
</asp:Content>

