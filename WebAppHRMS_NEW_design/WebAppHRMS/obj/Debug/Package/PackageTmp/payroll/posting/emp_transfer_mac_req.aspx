<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="emp_transfer_mac_req.aspx.vb" Inherits="WebAppHRMS.emp_transfer_mac_req" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function chkdt(a) {
            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()
        }

        var cs = cont_name.split("txt");
        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }

    </script>
    <div style="text-align: center">
        <table>
            <tr>
                <td style="width: 100px">


                    <table border="1" style="text-align: center; background-color: transparent;">
                        <tr>
                            <td colspan="4" style="text-align: center; height: 44px; background-color: #ffcc33; border-right: #ff3333 thin solid; border-top: #ff3333 thin solid; border-left: #ff3333 thin solid; border-bottom: #ff3333 thin solid;">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16pt" Text="EMPLOYEE TRANSFER" ForeColor="Red" Height="27px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center; height: 28px; background-color: moccasin;">&nbsp;<asp:Label ID="Label20" runat="server" Font-Bold="True" Text="CURRENT DETAILS" BackColor="Transparent" Style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 13px; text-align: center; background-color: #ffe654;">
                                <table border="1" style="width: 807px; border-left-color: #ffffff; border-bottom-color: #ffffff; border-top-style: dotted; border-top-color: #ffffff; border-right-style: dotted; border-left-style: dotted; border-right-color: #ffffff; border-bottom-style: dotted;">
                                    <tr>
                                        <td style="width: 22px; height: 26px;">
                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" ForeColor="Navy" Text="Select Employee"
                                                Width="219px"></asp:Label></td>
                                        <td style="width: 107px; height: 26px; text-align: left;">
                                            <asp:TextBox ID="cmb_select" runat="server" MaxLength="6" Width="331px" AutoPostBack="True"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 19px; text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table style="border-right: gold thin dotted; border-top: gold thin dotted; border-left: gold thin dotted; border-bottom: gold thin dotted; text-align: center" border="1">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 100px; text-align: left">
                                                        <asp:Label ID="Label2" runat="server" Width="146px" Text="Name"></asp:Label></td>
                                                    <td style="width: 87px; text-align: left">
                                                        <asp:TextBox ID="txt_name" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="width: 98px; text-align: left">
                                                        <asp:Label ID="Label5" runat="server" Text="Current Post"></asp:Label></td>
                                                    <td style="width: 128px; text-align: left">
                                                        <asp:TextBox ID="txt_currentPost" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="Label3" runat="server" Width="124px" Text="Current Designation"></asp:Label></td>
                                                    <td style="width: 87px; text-align: left">
                                                        <asp:TextBox ID="txt_desig" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="width: 98px">
                                                        <asp:Label ID="Label6" runat="server" Width="129px" Text="Current Department"></asp:Label></td>
                                                    <td style="width: 128px; text-align: left">
                                                        <asp:TextBox ID="txt_currentdept" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 28px; text-align: left">
                                                        <asp:Label ID="Label4" runat="server" Text="Current Branch"></asp:Label></td>
                                                    <td style="width: 87px; height: 28px; text-align: left">
                                                        <asp:TextBox ID="txt_currentbranch" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="width: 98px; height: 28px; text-align: left">
                                                        <asp:Label ID="Label7" runat="server" Text="Joining Date"></asp:Label></td>
                                                    <td style="width: 128px; height: 28px; text-align: left">
                                                        <asp:TextBox ID="txt_joiningdate" runat="server" Width="245px" ReadOnly="True"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 28px; text-align: left">
                                                        <asp:Label ID="Label13" runat="server" Text="Current Firm"></asp:Label></td>
                                                    <td style="width: 87px; height: 28px; text-align: left">
                                                        <asp:TextBox ID="Txt_firm" runat="server" Width="243px" ReadOnly="True"></asp:TextBox></td>
                                                    <td style="height: 28px; text-align: left" colspan="2"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table style="border-right: navajowhite thin dotted; border-top: navajowhite thin dotted; border-left: navajowhite thin dotted; border-bottom: navajowhite thin dotted; text-align: center" border="1">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 809px; height: 34px; text-align: center" colspan="4">
                                                        <asp:Label ID="lbl_msg" runat="server" Width="791px" ForeColor="OrangeRed" Font-Bold="True" Height="26px"></asp:Label></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cmb_select" EventName="textChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 39px; text-align: center; background-color: moccasin;">
                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="TRANSFER DETAILS" BackColor="Transparent" Style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 29px; text-align: center">&nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table style="border-left-color: #ffcc33; border-bottom-color: #ffcc33; border-top-style: ridge; border-top-color: #ffcc33; border-right-style: ridge; border-left-style: ridge; text-align: center; border-right-color: #ffcc33; border-bottom-style: ridge" border="1">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100px; height: 13px; text-align: left">
                                                    <asp:Label ID="Label8" runat="server" Width="119px" Text="Proposed Branch"></asp:Label></td>
                                                <td style="width: 85px; height: 13px">
                                                    <asp:DropDownList ID="cmb_newbranch" runat="server" Width="250px" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td style="width: 98px; height: 13px; text-align: left">
                                                    <asp:Label ID="Label14" runat="server" Width="83px" Text=" Department"></asp:Label></td>
                                                <td style="width: 104px; height: 13px; text-align: left">
                                                    <asp:DropDownList ID="cmb_newdept" runat="server" Width="317px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 18px; text-align: left">
                                                    <asp:Label ID="Label9" runat="server" Width="88px" Text=" Post Offered"></asp:Label></td>
                                                <td style="width: 85px; height: 18px">
                                                    <asp:DropDownList ID="cmb_newpost" runat="server" Width="250px" Font-Bold="False">
                                                    </asp:DropDownList></td>
                                                <td style="width: 98px; height: 18px; text-align: left">
                                                    <asp:Label ID="Label15" runat="server" Width="96px" Text="Relieving Date" Height="20px"></asp:Label></td>
                                                <td style="width: 104px; height: 18px; text-align: left">
                                                    <asp:TextBox ID="txt_releivingdate" onkeyup=" return chkdt('txt_releivingdate')" runat="server" Width="155px" AutoPostBack="True" ToolTip="Releving date should be greater than current system date."></asp:TextBox>&nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 14px; text-align: left">
                                                    <asp:Label ID="Label10" runat="server" Width="75px" Text="Joining Date" Height="19px"></asp:Label></td>
                                                <td style="width: 85px; height: 14px; text-align: left">
                                                    <asp:TextBox ID="txt_tfrjoiningdate" onkeyup="chkdt('txt_tfrjoiningdate')" runat="server" Width="143px" AutoPostBack="True"></asp:TextBox>&nbsp; </td>
                                                <td style="width: 98px; height: 14px; text-align: left">
                                                    <asp:Label ID="Label16" runat="server" Width="98px" Text="Reporting Date" Height="19px"></asp:Label></td>
                                                <td style="width: 104px; height: 14px; text-align: left">
                                                    <asp:TextBox ID="txt_reportingdate" onkeyup="chkdt('txt_reportingdate')" runat="server" Width="156px" AutoPostBack="True" OnTextChanged="txt_reportingdate_TextChanged"></asp:TextBox>&nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 13px; text-align: center" colspan="4">
                                                    <asp:Label ID="lbl_date" runat="server" Width="802px" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 23px; text-align: left">
                                                    <asp:Label ID="Label11" runat="server" Width="91px" Text="Reporting To"></asp:Label></td>
                                                <td style="height: 23px; text-align: left" colspan="3">
                                                    <asp:DropDownList ID="cmb_report_person" runat="server" Width="516px" BackColor="LemonChiffon" ForeColor="Black" Font-Bold="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 23px; text-align: left" colspan="4">
                                                    <table style="border-left-color: #ffcc33; border-bottom-color: #ffcc33; border-top-style: ridge; border-top-color: #ffcc33; border-right-style: ridge; border-left-style: ridge; text-align: center; border-right-color: #ffcc33; border-bottom-style: ridge" border="1">
                                                        <tbody>
                                                            <tr>
                                                                <td style="height: 23px; text-align: left" colspan="4">
                                                                    <div style="text-align: center">
                                                                        <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_state"></cc1:ListSearchExtender>
                                                                        <cc1:ListSearchExtender ID="ListSearchExtender7" runat="server" TargetControlID="cmb_hostel"></cc1:ListSearchExtender>
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
                                                                                    <td style="width: 267px; height: 24px">Select&nbsp;Hostel</td>
                                                                                    <td style="width: 100px; height: 24px; text-align: left">
                                                                                        <asp:DropDownList ID="cmb_hostel" runat="server" Width="346px" AutoPostBack="True" OnSelectedIndexChanged="cmb_hostel_SelectedIndexChanged"></asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 9px; text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State&nbsp;&nbsp;<asp:DropDownList ID="cmb_state" runat="server" Width="214px" AutoPostBack="True" OnSelectedIndexChanged="cmb_state_SelectedIndexChanged"></asp:DropDownList></td>
                                                                                    <td style="height: 9px; text-align: left" colspan="2">Total&nbsp;Capacity&nbsp;-<asp:Label ID="totcap" runat="server" Width="42px" Text="0" ForeColor="#0000C0" Font-Bold="True"></asp:Label>&nbsp;Present&nbsp;Capacity&nbsp;&nbsp;-&nbsp;<asp:Label ID="pcap" runat="server" Width="30px" Text="0" ForeColor="Navy" Font-Bold="True"></asp:Label></td>
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
                                                <td style="height: 19px; text-align: right" colspan="2"><span style="color: #ff0000">*</span><asp:Label ID="Label18" runat="server" Width="320px" Text="Distance between Home & Working Branch (in Km)" ForeColor="Maroon"></asp:Label></td>
                                                <td style="height: 19px; text-align: left" colspan="2">
                                                    <asp:TextBox ID="Txt_dis" onkeyup="return change('Txt_dis')" runat="server" MaxLength="5"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 16px; text-align: center" colspan="4"></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_reportingdate" BehaviorID="ctl26_CalendarExtender3" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_releivingdate" BehaviorID="ctl20_CalendarExtender1" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_newdept">
                                    </cc1:ListSearchExtender>
                                    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_newpost">
                                    </cc1:ListSearchExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_tfrjoiningdate" BehaviorID="ctl23_CalendarExtender2" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                    <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_report_person">
                                    </cc1:ListSearchExtender>
                                    <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_newbranch">
                                    </cc1:ListSearchExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="background-color: moccasin; height: 59px;">
                                <table style="width: 690px">
                                    <tr>
                                        <td style="width: 65px; height: 19px;"></td>
                                        <td style="width: 100px; height: 19px;">
                                            <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="108px" BackColor="SeaShell" BorderColor="#FFC0C0" Font-Bold="True" Height="28px" BorderStyle="Dashed" /></td>
                                        <td style="width: 24px; height: 19px;"></td>
                                        <td style="width: 100px; height: 19px;">
                                            <asp:Button ID="cmd_clear" runat="server" BackColor="SeaShell" Font-Bold="True" Height="31px"
                                                Text="CLEAR" Width="112px" BorderColor="#FFC0C0" BorderStyle="Dashed" /></td>
                                        <td style="width: 23px; height: 19px;"></td>
                                        <td style="width: 119px; height: 19px;">
                                            <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="114px" BackColor="SeaShell" Font-Bold="True" Height="31px" BorderColor="#FFC0C0" BorderStyle="Dashed" /></td>
                                        <td style="width: 25px; height: 19px;"></td>
                                        <td style="width: 119px; height: 19px;">
                                            <asp:Button ID="cmd_vewrepo" runat="server" BackColor="SeaShell" BorderColor="#FFC0C0"
                                                BorderStyle="Dashed" Font-Bold="True" Height="31px" Text="VIEW REPORT" Width="114px" /></td>
                                        <td style="width: 49px; height: 19px;"></td>
                                    </tr>
                                </table>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        return window_onload()
        // ]]>
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function window_onload() {

        }
        var txt
        txt = disb.substr(0, disb.indexOf('cmd'));
        function hh() {
            document.getElementById(txt + "txt_tfrjoiningdate").value = ""
            document.getElementById(txt + "txt_releivingdate").value = ""
            document.getElementById(txt + "txt_reportingdate").value = ""

        }

        // ]]>
    </script>
</asp:Content>
