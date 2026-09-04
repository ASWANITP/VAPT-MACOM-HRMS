<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_add_ded.aspx.vb" Inherits="WebAppHRMS.emp_add_ded_5592fbd29480" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../control/uc_date.ascx" TagName="uc_date" TagPrefix="uc1" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("txt");

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
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
        function Button1_onclick() {

            document.getElementById(cs[0] + "txt_arrearbasic").value = ""
            document.getElementById(cs[0] + "txt_arrearda").value = ""
            document.getElementById(cs[0] + "txt_Addothers").value = ""
            document.getElementById(cs[0] + "txt_addremarks").value = ""
            document.getElementById(cs[0] + "txt_insurance").value = ""
            document.getElementById(cs[0] + "txt_proftax").value = ""
            document.getElementById(cs[0] + "txt_tax").value = ""
            document.getElementById(cs[0] + "txt_dedothers").value = ""
            document.getElementById(cs[0] + "txt_dedremarks").value = ""
        }

        function checkbeforeconfirm() {
            if ((document.getElementById(cs[0] + "txt_arrearbasic").value == 0) &&
                (document.getElementById(cs[0] + "txt_arrearda").value == 0) &&
                (document.getElementById(cs[0] + "txt_Addothers").value == 0) &&
                (document.getElementById(cs[0] + "txt_addremarks").value == 0) &&
                (document.getElementById(cs[0] + "txt_insurance").value == 0) &&
                (document.getElementById(cs[0] + "txt_proftax").value == 0) &&
                (document.getElementById(cs[0] + "txt_tax").value == 0) &&
                (document.getElementById(cs[0] + "txt_dedothers").value == 0) &&
                (document.getElementById(cs[0] + "txt_dedremarks").value == 0)
            ) {
                alert('Please enter values.If No enter Zero');
                return false;
            }

            if ((document.getElementById(cs[0] + "txt_arrearbasic").value == "") ||
                (document.getElementById(cs[0] + "txt_arrearda").value == "") ||
                (document.getElementById(cs[0] + "txt_Addothers").value == "") ||
                (document.getElementById(cs[0] + "txt_addremarks").value == "") ||
                (document.getElementById(cs[0] + "txt_insurance").value == "") ||
                (document.getElementById(cs[0] + "txt_proftax").value == "") ||
                (document.getElementById(cs[0] + "txt_tax").value == "") ||
                (document.getElementById(cs[0] + "txt_dedothers").value == "") ||
                (document.getElementById(cs[0] + "txt_dedremarks").value == "")
            ) {
                alert('Please enter values.If No enter Zero');
                return false;
            }
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

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server" Height="174px" Width="841px">
            <br />
            <table border="1" style="width: 501px; height: 33px">
                <tr>
                    <td style="width: 156px; height: 7px; text-align: right">
                        <asp:Label ID="Label1" runat="server" Text="Select Employee : "></asp:Label>&nbsp;
                    </td>
                    <td style="width: 100px; height: 7px; text-align: left">
                        <asp:DropDownList ID="cmb_emp" runat="server" Width="324px">
                        </asp:DropDownList><cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_emp">
                        </cc1:ListSearchExtender>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="125px">
                <table border="1" style="width: 902px; height: 270px">
                    <tr>
                        <td style="width: 100px; height: 151px">
                            <div style="text-align: center">
                                <asp:Panel ID="Panel3" runat="server" Height="50px" Width="125px">
                                    <table border="1" style="width: 450px; height: 186px">
                                        <tr>
                                            <td colspan="2" style="height: 8px">Additions</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Date :
                                            </td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_date" runat="server" Height="21px" Width="149px" onkeypress="return check_dt()"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                                                    TargetControlID="txt_date"></cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 46px;">Arrear Basic :</td>
                                            <td style="width: 100px; text-align: left; height: 46px;">
                                                <asp:TextBox ID="txt_arrearbasic" runat="server" Height="22px" onblur="onblurcheck('txt_arrearbasic')"
                                                    TabIndex="4" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Arrear DA :</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_arrearda" runat="server" Height="22px" onblur="onblurcheck('txt_arrearda')"
                                                    TabIndex="5" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 29px;">Others :</td>
                                            <td style="width: 100px; text-align: left; height: 29px;">
                                                <asp:TextBox ID="txt_Addothers" runat="server" Height="22px" onblur="onblurcheck('txt_Addothers')"
                                                    TabIndex="6" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Remarks :</td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txt_addremarks" runat="server" Height="38px" TabIndex="7"
                                                    Width="315px" MaxLength="60"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;
                            </div>
                        </td>
                        <td style="width: 100px; height: 151px">
                            <div style="text-align: center">
                                <asp:Panel ID="Panel4" runat="server" Height="50px" Width="125px">
                                    <table border="1" style="width: 430px; height: 221px">
                                        <tr>
                                            <td colspan="2">Deductions</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp; &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">LIC :
                                            </td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_insurance" runat="server" Height="22px" onblur="onblurcheck('txt_insurance')"
                                                    TabIndex="8" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Prof.Tax</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_proftax" runat="server" Height="22px" onblur="onblurcheck('txt_proftax')"
                                                    TabIndex="9" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">TDS :</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_tax" runat="server" Height="22px" onblur="onblurcheck('txt_tax')"
                                                    TabIndex="10" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Others :</td>
                                            <td style="width: 100px; text-align: left">
                                                <asp:TextBox ID="txt_dedothers" runat="server" Height="22px" onblur="onblurcheck('txt_dedothers')"
                                                    TabIndex="11" Width="149px" MaxLength="6"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">Remarks :</td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txt_dedremarks" runat="server" Height="38px" TabIndex="12"
                                                    Width="307px" MaxLength="60"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="text-align: center">
                <input id="cmd_clear" type="button" value="CLEAR" onclick="return Button1_onclick()" style="width: 84px" /><asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" OnClientClick="return checkbeforeconfirm()" TabIndex="14" Style="cursor: hand" /><input id="cmd_exit" style="width: 81px; cursor: hand;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />&nbsp;
            </div>
        </asp:Panel>
        <br />
        &nbsp;&nbsp;<br />
        &nbsp; &nbsp;&nbsp;
    </div>
    <div style="text-align: center">
        &nbsp;
    </div>
</asp:Content>

