<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="promotion_with_tfr_frm2_Jwell.aspx.vb" Inherits="WebAppHRMS.promotion_with_tfr_frm2_Jwell_ff7db9055124" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script type="text/javascript">

        function exit() {
            window.open('../home.aspx', '_self');
        }
        var cs = cont_name.split("Txt");
        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }
        function van() {
            alert("please select date from calendar!")
            return false;
        }
    </script>
    <br />
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
    <br />
    <br />
    &nbsp;&nbsp;
        <table border="1" width="750" align="center">
            <tr>
                <td colspan="3" style="height: 19px; text-align: center">
                    <strong style="background-color: #ff6666"><span style="background-color: #ffcc66">PROMOTION&nbsp;WITH&nbsp;TRANSFER</span><asp:ScriptManager
                        ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                        <br />
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="text-align: center">
                                <table style="width: 761px" border="1">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100px; text-align: left">Name</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_name" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 100px; text-align: left">Post&nbsp;Offered</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_postoffered" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: left">Deisgnation</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_designation" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 100px; text-align: left">Department</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_department" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: left">Location&nbsp;(branch)</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_branch" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 100px; text-align: left">Current Firm</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="Txt_currfirm" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmb_employee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center; background-color: #ff9900;">
                    <strong>&nbsp;EMPLOYEE&nbsp;TRANSFER&nbsp;DETAILS</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width: 759px" border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 71px; height: 26px; text-align: left">Prop.&nbsp;Location</td>
                                        <td style="width: 100px; height: 26px; text-align: left">
                                            <asp:DropDownList ID="cmb_branch" TabIndex="1" runat="server" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="cmb_branch_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 34px; height: 26px; text-align: left">Department</td>
                                        <td style="width: 100px; height: 26px; text-align: left">
                                            <asp:DropDownList ID="cmb_department" TabIndex="2" runat="server" Width="228px" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 34px; height: 26px; text-align: left">Post&nbsp;Offered</td>
                                        <td style="width: 34px; height: 36px; text-align: left">
                                            <asp:DropDownList ID="cmb_postoffered" TabIndex="3" runat="server" Width="228px" Height="24px" AutoPostBack="True" OnSelectedIndexChanged="cmb_postoffered_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 34px; height: 9px; text-align: left">Deputation</td>
                                        <td style="width: 100px; height: 39px; text-align: left">
                                            <asp:RadioButton ID="rdbtn_yes" TabIndex="5" runat="server" Width="34px" Text="YES" Font-Size="Smaller" Font-Bold="True" Height="21px" AutoPostBack="True" GroupName="Dep" OnCheckedChanged="rdbtn_yes_CheckedChanged"></asp:RadioButton>
                                            <asp:RadioButton ID="rdbtn_no" TabIndex="4" runat="server" Width="35px" Text="NO" Font-Size="Smaller" Font-Bold="True" Height="21px" AutoPostBack="True" GroupName="Dep" OnCheckedChanged="rdbtn_no_CheckedChanged" Checked="True"></asp:RadioButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 71px; height: 28px; text-align: left">Relieve&nbsp;Date</td>
                                        <td style="width: 100px; height: 28px; text-align: left">
                                            <asp:TextBox ID="txt_relievedate" TabIndex="7" onkeypress="return van()" runat="server" Width="219px" AutoPostBack="True" OnTextChanged="txt_relievedate_TextChanged"></asp:TextBox></td>
                                        <td style="width: 34px; height: 28px; text-align: left">Select&nbsp;Firm</td>
                                        <td style="width: 100px; height: 28px; text-align: left">
                                            <asp:DropDownList ID="cmb_firm" TabIndex="6" runat="server" Width="228px" AutoPostBack="True"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 71px; text-align: left">Reporting&nbsp;(Join)&nbsp;Date</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="txt_joindate" TabIndex="8" onkeypress="return van()" runat="server" Width="219px" AutoPostBack="True" OnTextChanged="txt_joindate_TextChanged"></asp:TextBox></td>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table style="border-left-color: #ffcc33; border-bottom-color: #ffcc33; border-top-style: ridge; border-top-color: #ffcc33; border-right-style: ridge; border-left-style: ridge; text-align: center; border-right-color: #ffcc33; border-bottom-style: ridge" border="1">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 23px; text-align: left" colspan="4">
                                                            <div style="text-align: center">
                                                                <cc1:ListSearchExtender ID="ListSearchExtender7" runat="server" TargetControlID="cmb_state"></cc1:ListSearchExtender>
                                                                <cc1:ListSearchExtender ID="ListSearchExtender8" runat="server" TargetControlID="cmb_hostel"></cc1:ListSearchExtender>
                                                                <table style="width: 800px">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="height: 24px; text-align: left" colspan="2">
                                                                                <table style="width: 332px" id="cathos" runat="server">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 35px; height: 24px">Select&nbsp;category</td>
                                                                                            <td style="width: 65px; height: 24px; text-align: left">
                                                                                                <asp:DropDownList ID="cmb_cat" runat="server" Width="226px" AutoPostBack="True" OnSelectedIndexChanged="cmb_cat_SelectedIndexChanged"></asp:DropDownList></td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                            <td style="width: 115px; height: 24px">Select Hostel</td>
                                                                            <td style="width: 100px; height: 24px; text-align: left">
                                                                                <asp:DropDownList ID="cmb_hostel" runat="server" Width="346px" AutoPostBack="True" OnSelectedIndexChanged="cmb_hostel_SelectedIndexChanged"></asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 108px; height: 24px">Select State</td>
                                                                            <td style="width: 62px; height: 24px; text-align: left">
                                                                                <asp:DropDownList ID="cmb_state" runat="server" Width="214px" AutoPostBack="True" OnSelectedIndexChanged="cmb_state_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            <td style="height: 24px; text-align: left" colspan="2">Total&nbsp;Capacity&nbsp;-<asp:Label ID="totcap" runat="server" Width="36px" Text="0" ForeColor="#0000C0" Font-Bold="True"></asp:Label>&nbsp;&nbsp; Present&nbsp;Capacity&nbsp;&nbsp;-<asp:Label ID="pcap" runat="server" Width="30px" Text="0" ForeColor="Navy" Font-Bold="True"></asp:Label></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right" colspan="2"><span style="color: #990033"><span style="color: #ff0033">*</span>Distance between home &amp; working branch (in Km)</span></td>
                                        <td style="text-align: left" colspan="2">
                                            <asp:TextBox ID="Txt_dist" onkeyup="return change('Txt_dist')" runat="server" MaxLength="5"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_relievedate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_joindate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                            &nbsp;
                            <cc1:ListSearchExtender ID="ListSearchExtender5" runat="server" TargetControlID="cmb_postoffered">
                            </cc1:ListSearchExtender>
                            <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_branch">
                            </cc1:ListSearchExtender>
                            <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_department">
                            </cc1:ListSearchExtender>
                            <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_firm"></cc1:ListSearchExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; background-color: #ff9900; text-align: center">
                    <strong>EMPLOYEE&nbsp;PROMOTION&nbsp;DETAILS</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table style="width: 757px" border="1">
                                <tbody>
                                    <tr>
                                        <td colspan="2" style="text-align: left">Designation</td>
                                        <td colspan="2" style="text-align: left">
                                            <asp:DropDownList ID="cmb_desig" runat="server" Width="301px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">Pay Scale</td>
                                        <td style="width: 100px; text-align: left">
                                            <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_designation">
                                            </cc1:ListSearchExtender>
                                            <asp:DropDownList ID="cmb_designation" TabIndex="9" runat="server" Width="230px" AutoPostBack="True"></asp:DropDownList></td>
                                        <td style="width: 100px; text-align: left">Effective&nbsp;Date</td>
                                        <td style="width: 100px; text-align: left">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_effectivedate" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                            <asp:TextBox ID="txt_effectivedate" onkeypress="return van()" TabIndex="11" runat="server" Width="219px" OnTextChanged="txt_effectivedate_TextChanged"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 28px; text-align: left">Basic&nbsp;Salary</td>
                                        <td style="width: 100px; height: 28px; text-align: left">
                                            <asp:DropDownList ID="cmb_pay_amnt" TabIndex="10" runat="server" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="cmb_pay_amnt_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 100px; height: 28px; text-align: left">Total&nbsp;Salary</td>
                                        <td style="width: 100px; height: 28px; text-align: left">
                                            <asp:TextBox ID="txt_totalsalary" runat="server" Width="219px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">Enter Amount</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="txt_enter" runat="server" Width="221px"></asp:TextBox>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;Whether Promotion / depromotion</td>
                                            <td style="text-align: left" colspan="2">
                                                <asp:RadioButton ID="rbd_pro" runat="server" Width="98px" Text="Promotion" Font-Bold="True" AutoPostBack="True" GroupName="p" OnCheckedChanged="rbd_pro_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rbd_depro" runat="server" Text="Depromotion" Font-Bold="True" AutoPostBack="True" GroupName="g" OnCheckedChanged="RadioButton2_CheckedChanged"></asp:RadioButton></td>
                                        </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmb_designation" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="cmb_pay_amnt" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 23px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lbl_message" runat="server" Width="750px" BackColor="PaleGoldenrod" Text="Label" ForeColor="Red" Font-Bold="True"></asp:Label>
                            <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center"></td>
                <td align="center"></td>
                <td align="center"></td>
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
                                    <asp:Button ID="cmd_Exit" runat="server" Font-Bold="True" Style="background-color: #ccccff"
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

