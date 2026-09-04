<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employee_ded.aspx.vb" Inherits="WebAppHRMS.employee_ded_976c71f41186" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../control/uc_date.ascx" TagName="uc_date" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("txt");

        function TABLE1_onclick() {

        }
        function onblurcheck(tbid) {
            if (document.getElementById(cs[0] + tbid).value != "") {
                if (isNaN(document.getElementById(cs[0] + tbid).value)) {
                    alert("Wrong Entry");
                    document.getElementById(cs[0] + tbid).value = ""
                    document.getElementById(cs[0] + tbid).focus()
                }
            }
        }
        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        function cmdclear_onclick() {
            document.getElementById(cs[0] + "txt_amt").value = ""
            document.getElementById(cs[0] + "txt_reason").value = ""
            document.getElementById(cs[0] + "dt_enterdt").value = ""
        }
        function isNumberKey(event) {

            var charcode = (event.which) ? event.which : event.keyCode
            if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                return false;
            }
            else
                return true;
        }
        function check_dt() {
            alert("Select Date From Calender")
            return false;
        }
        // ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <table border="1" style="width: 510px; height: 21px">
            <tr>
                <td style="width: 2436px; height: 28px; text-align: right" align="center">Select Employee Code :
                </td>
                <td align="center" colspan="4" style="height: 28px; text-align: left; width: 400px;">
                    <asp:DropDownList ID="cmb_empcode" runat="server" Width="344px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_empcode"></cc1:ListSearchExtender>
        <br />
        <br />

        <asp:Panel ID="Panel2" runat="server" Height="105px" Width="547px" BackColor="Transparent" BorderColor="Transparent">
            <table border="1" style="width: 512px; height: 88px">
                <tr>
                    <td style="width: 102px; height: 23px; text-align: right">&nbsp;
                    Amount&nbsp; : &nbsp;</td>
                    <td style="width: 115px; height: 23px; text-align: left">
                        <asp:TextBox ID="txt_amt" onblur="onblurcheck('txt_amt')" runat="server" MaxLength="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 102px; height: 23px; text-align: right">&nbsp; Effect Date &nbsp; &nbsp;: &nbsp;</td>
                    <td style="width: 115px; height: 23px; text-align: left">&nbsp;<asp:TextBox ID="dt_enterdt" runat="server" Onkeypress="return check_dt()"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="dt_enterdt"></cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 102px; height: 20px; text-align: right">&nbsp;
                    Reason&nbsp; &nbsp;: &nbsp;</td>
                    <td style="width: 115px; height: 20px; text-align: left">
                        <asp:TextBox ID="txt_reason" runat="server" Width="390px" Height="22px" MaxLength="60"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 102px; height: 20px; text-align: left">&nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                    <td style="width: 115px; height: 20px; text-align: left">
                        <div style="text-align: left">
                            <br />
                            <table id="TABLE1" border="0" style="width: 306px; height: 22px" onclick="return TABLE1_onclick()">
                                <tr>
                                    <td style="width: 94px; height: 26px;">
                                        <input id="cmdclear" style="width: 86px; cursor: hand;" type="button" value="CLEAR" onclick="return cmdclear_onclick()" /></td>
                                    <td style="width: 100px; height: 26px;">
                                        <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Style="cursor: hand" /></td>
                                    <td style="width: 100px; height: 26px;">
                                        <input id="cmd_exit" style="width: 67px; cursor: hand;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    </div>
    <br />
    &nbsp;<br />
    <br />
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
</asp:Content>
