<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_Authorisation_applcn_frm.aspx.vb" Inherits="WebAppHRMS.TOUR_Tour_Authorisation_applcn_frm_005b7ec02816" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script type="text/javascript">
        // script will use to exit the button

        function exit() {
            //alert("Closing");
            window.open('../home.aspx', '_self');

        }

        // in textbox print only numbers

        function correct(a) {
            //alert("ccccccccccc")
            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            if (isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
                document.getElementById("ctl00_cph_edp_" + a).focus()
            }
        }


        // convert a string to uppercase letters

        function string(a) {

            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            if (!isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
                document.getElementById("ctl00_cph_edp_" + a).focus()
            }

            else {
                document.getElementById("ctl00_cph_edp_" + a).value = v.toUpperCase()
                document.getElementById("ctl00_cph_edp_" + a).focus()
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
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table style="width: 735px" border="1">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="height: 68px; text-align: left" colspan="2">Select&nbsp;Employee</td>
                                                                    <td style="height: 68px; text-align: left" colspan="2">
                                                                        <asp:DropDownList ID="cmb_employee" runat="server" Width="235px" BackColor="#FFE0C0" __designer:wfdid="w62" AutoPostBack="True"></asp:DropDownList>
                                                                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" __designer:wfdid="w63" PromptText TargetControlID="cmb_employee"></cc1:ListSearchExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px; text-align: left">Employee Code</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox Style="color: #330000" ID="txt_ecode" runat="server" Width="155px" BackColor="BlanchedAlmond" __designer:wfdid="w64" AutoPostBack="True" ReadOnly="True"></asp:TextBox></td>
                                                                    <td style="width: 100px; text-align: left">Designation</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_desig" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w65" ReadOnly="True"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px; text-align: left">Name</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_name" runat="server" Width="155px" BackColor="BlanchedAlmond" __designer:wfdid="w66" ReadOnly="True"></asp:TextBox></td>
                                                                    <td style="width: 100px; text-align: left">Post</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_post" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w67" ReadOnly="True"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px; text-align: left">Department</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_department" runat="server" Width="153px" BackColor="BlanchedAlmond" __designer:wfdid="w68" ReadOnly="True"></asp:TextBox></td>
                                                                    <td style="width: 100px; text-align: left">Branch</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_branch" runat="server" Width="141px" BackColor="BlanchedAlmond" __designer:wfdid="w69" ReadOnly="True"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="cmb_employee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                        <asp:AsyncPostBackTrigger ControlID="Cmd_confirm" EventName="Click"></asp:AsyncPostBackTrigger>
                                                        <asp:AsyncPostBackTrigger ControlID="cmd_cancel" EventName="Click"></asp:AsyncPostBackTrigger>
                                                        <asp:AsyncPostBackTrigger ControlID="Cmd_Clear" EventName="Click"></asp:AsyncPostBackTrigger>
                                                        <asp:AsyncPostBackTrigger ControlID="Cmd_exit" EventName="Click"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        &nbsp;&nbsp;
                                                        <table width="760" border="1">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100px; text-align: left">Tour&nbsp;From</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_tfrmdt" runat="server" __designer:wfdid="w43" AutoPostBack="True"></asp:TextBox><br />
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" __designer:wfdid="w44" TargetControlID="txt_tfrmdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                                    </td>
                                                                    <td style="width: 100px; text-align: left">Tour&nbsp;To</td>
                                                                    <td style="width: 100px; text-align: left">
                                                                        <asp:TextBox ID="txt_tortdt" runat="server" __designer:wfdid="w45" AutoPostBack="True"></asp:TextBox><br />
                                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" __designer:wfdid="w46" TargetControlID="txt_tortdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="760" border="1" __designer:dtid="1407374883553308">
                                                            <tbody>
                                                                <tr __designer:dtid="1407374883553309">
                                                                    <td style="width: 100px; text-align: left" __designer:dtid="1407374883553310">From&nbsp;Time</td>
                                                                    <td style="width: 100px" __designer:dtid="1407374883553311">
                                                                        <table style="width: 21%" __designer:dtid="1407374883553312">
                                                                            <tbody __designer:dtid="1407374883553313">
                                                                                <tr __designer:dtid="1407374883553314">
                                                                                    <td style="width: 49px; height: 20px" __designer:dtid="1407374883553315">
                                                                                        <asp:TextBox ID="txt_hh1" onkeyup="correct ('txt_hh1')" runat="server" Width="29px" __designer:dtid="1407374883553316" __designer:wfdid="w47" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 100px; height: 20px" __designer:dtid="1407374883553317">
                                                                                        <asp:TextBox ID="txt_mm1" onkeyup="correct ('txt_mm1')" runat="server" Width="29px" __designer:dtid="1407374883553318" __designer:wfdid="w48" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 100px; height: 20px" __designer:dtid="1407374883553319">
                                                                                        <asp:TextBox ID="txt_ss1" onkeyup="correct ('txt_ss1')" runat="server" Width="29px" __designer:dtid="1407374883553320" __designer:wfdid="w49" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 88px; height: 20px" __designer:dtid="1407374883553321">
                                                                                        <asp:RadioButton ID="rd_am1" runat="server" Text="AM" __designer:dtid="1407374883553322" __designer:wfdid="w50" GroupName="ab"></asp:RadioButton></td>
                                                                                    <td style="width: 73px; height: 20px" __designer:dtid="1407374883553323">
                                                                                        <asp:RadioButton ID="rd_pm1" runat="server" Text="PM" __designer:dtid="1407374883553324" __designer:wfdid="w51" GroupName="ab"></asp:RadioButton></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td style="width: 100px" __designer:dtid="1407374883553325">To Time</td>
                                                                    <td style="width: 133px" __designer:dtid="1407374883553326">
                                                                        <table style="width: 21%" __designer:dtid="1407374883553327">
                                                                            <tbody>
                                                                                <tr __designer:dtid="1407374883553328">
                                                                                    <td style="width: 100px" __designer:dtid="1407374883553329">
                                                                                        <asp:TextBox ID="txt_hh2" onkeyup="correct ('txt_hh2')" runat="server" Width="29px" __designer:dtid="1407374883553330" __designer:wfdid="w52" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 100px" __designer:dtid="1407374883553331">
                                                                                        <asp:TextBox ID="txt_mm2" onkeyup="correct ('txt_mm2')" runat="server" Width="29px" __designer:dtid="1407374883553332" __designer:wfdid="w53" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 100px" __designer:dtid="1407374883553333">
                                                                                        <asp:TextBox ID="txt_ss2" onkeyup="correct ('txt_ss2')" runat="server" Width="29px" __designer:dtid="1407374883553334" __designer:wfdid="w54" MaxLength="2"></asp:TextBox></td>
                                                                                    <td style="width: 100px" __designer:dtid="1407374883553335">
                                                                                        <asp:RadioButton ID="rd_am2" runat="server" Text="AM" __designer:dtid="1407374883553336" __designer:wfdid="w55" GroupName="bc"></asp:RadioButton></td>
                                                                                    <td style="width: 53px" __designer:dtid="1407374883553337">
                                                                                        <asp:RadioButton ID="rd_pm2" runat="server" Text="PM" __designer:dtid="1407374883553338" __designer:wfdid="w56" GroupName="bc"></asp:RadioButton></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr __designer:dtid="1407374883553339">
                                                                    <td style="width: 100px; text-align: left" __designer:dtid="1407374883553340">Tour&nbsp;Advance&nbsp;Rs</td>
                                                                    <td style="width: 100px" __designer:dtid="1407374883553341">
                                                                        <asp:TextBox ID="txt_advance" onkeyup="correct ('txt_advance')" runat="server" Width="209px" __designer:dtid="1407374883553342" __designer:wfdid="w57"></asp:TextBox></td>
                                                                    <td style="width: 100px; text-align: left" __designer:dtid="1407374883553343">Tour&nbsp;Place</td>
                                                                    <td style="width: 133px" __designer:dtid="1407374883553344">
                                                                        <asp:TextBox ID="txt_tourplace" onkeyup="string('txt_tourplace')" runat="server" Width="211px" __designer:dtid="1407374883553345" __designer:wfdid="w58"></asp:TextBox></td>
                                                                </tr>
                                                                <tr __designer:dtid="1407374883553346">
                                                                    <td style="text-align: left" colspan="2" __designer:dtid="1407374883553347">Tour&nbsp;Purpose</td>
                                                                    <td colspan="2" __designer:dtid="1407374883553348">
                                                                        <asp:TextBox ID="txt_tourpurpose" onkeyup="string('txt_tourpurpose')" runat="server" Width="322px" __designer:dtid="1407374883553349" __designer:wfdid="w59"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:Timer ID="Timer1" runat="server" __designer:wfdid="w60" Enabled="False" Interval="2000"></asp:Timer>
                                                        <asp:Label ID="Lbl_MESSAGE" runat="server" Width="739px" Text="Label_message" ForeColor="Red" BorderColor="White" __designer:dtid="3659174697238603" __designer:wfdid="w19"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 760px" border="1">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100px; height: 28px"></td>
                                                                    <td style="width: 100px; height: 28px"></td>
                                                                    <td style="width: 100px; height: 28px">
                                                                        <asp:Button ID="Cmd_confirm" runat="server" Width="98px" Text="CONFIRM"></asp:Button></td>
                                                                    <td style="width: 100px; height: 28px">
                                                                        <asp:Button ID="Cmd_Clear" runat="server" Width="98px" Text="CLEAR" OnClick="Cmd_Clear_Click"></asp:Button></td>
                                                                    <td style="width: 100px; height: 28px">
                                                                        <asp:Button ID="cmd_cancel" runat="server" Width="98px" Text="CANCEL"></asp:Button></td>
                                                                    <td style="width: 100px; height: 28px">
                                                                        <asp:Button ID="Cmd_exit" runat="server" Width="99px" Text="EXIT"></asp:Button></td>
                                                                    <td style="width: 100px; height: 28px"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
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
        &nbsp;
    </div>
    &nbsp;&nbsp;<br />
    &nbsp;&nbsp; &nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp;<br />
    <br />
    <br />
    &nbsp;<div style="text-align: center">
        &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <br />
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;
        </div>
    </div>
</asp:Content>

