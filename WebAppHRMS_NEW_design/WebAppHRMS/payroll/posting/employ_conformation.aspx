<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employ_conformation.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_employ_conformation_81d614529648" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function correct(a) {

            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            if (isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
                document.getElementById("ctl00_cph_edp_" + a).focus()
            }
        }

        function ok() {
            if (!(((window.event.keyCode >= 48) || (window.event.keyCode == 46)) && (window.event.keyCode <= 57))) {

                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
        }

        function chkdt() {
            document.getElementById("ctl00_cph_edp_txt_jodt").value = ""
            document.getElementById("ctl00_cph_edp_txt_jodt").focus()
        }

        function fillcheck() {

            if (document.getElementById("ctl00_cph_edp_txt_period").value == "") {
                alert("Enter The Period");
                return false;
            }
            else if (document.getElementById("ctl00_cph_edp_txt_jodt").value == "") {
                alert("Enter Joining date");
                return false;
            }
            else if (document.getElementById("ctl00_cph_edp_txt_secdep").value == "") {
                alert("Enter Security Amount");
                return false;
            }
            else if (document.getElementById("ctl00_cph_edp_txt_depamt").value == "") {
                alert("Enter Deposit Amount");
                return false;
            }

            else if (document.getElementById("ctl00_cph_edp_txt_rdamt").value == "") {
                alert("Enter RD Amount");
                return false;
            }

            else if (document.getElementById("ctl00_cph_edp_txt_instno").value == "") {
                alert("Enter Inst No.");
                return false;
            }

        }




    </script>
    <table align="center" border="1">
        <tr>
            <td style="height: 23px; text-align: center;" colspan="4">
                <strong><span style="color: #cc0033">EMPLOYEE CONFIRMATION</span></strong></td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 528px">
                            <tbody>
                                <tr>
                                    <td colspan="2">Employee</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="cmb_employee" runat="server" Width="258px" OnSelectedIndexChanged="cmb_employee_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 26px; text-align: left">Designation</td>
                                    <td style="width: 100px; height: 26px">
                                        <asp:TextBox ID="txt_desig" runat="server" Width="222px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; height: 26px; text-align: left">Department</td>
                                    <td style="width: 100px; height: 26px">
                                        <asp:TextBox ID="txt_depid" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; text-align: left">Post Offered</td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_post" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; text-align: left">Branch</td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_branch" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_employee">
                        </cc1:ListSearchExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmb_employee" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 588px" align="center" border="1">
                            <tbody>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <cc1:CalendarExtender ID="ce_jodt" runat="server" TargetControlID="txt_jodt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                        &nbsp;
                                    <asp:Label ID="lbl_err" runat="server" Width="206px"></asp:Label>
                                        &nbsp; </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">Employee Type</td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_type" runat="server" Width="163px">
                                            <asp:ListItem Value="1">PERMANENT</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 100px; text-align: left">Period</td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_period" onkeypress="ok()" onkeyup="correct('txt_period')" runat="server" Width="173px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">Firm </td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_firm" runat="server" Width="163px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 100px; text-align: left">Joining Date</td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_jodt" onkeyup="chkdt()" runat="server" Width="173px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">ESI&nbsp; Declaratiom</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:RadioButtonList ID="rd_esi" runat="server" Width="146px" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="T">Yes</asp:ListItem>
                                            <asp:ListItem Value="F">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 100px; text-align: left">Medical Claim</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:RadioButtonList ID="rd_medical" runat="server" Width="157px" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="T">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="F">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">Provident Fund</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:RadioButtonList ID="rd_pf" runat="server" Width="144px" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="T">Yes</asp:ListItem>
                                            <asp:ListItem Value="F">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 100px; text-align: left">Designation</td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="cmb_desigation" runat="server" Width="219px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px"></td>
                                    <td style="width: 100px; text-align: left">Department</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="cmb_dep" runat="server" Width="284px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">Pay </td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:DropDownList ID="cmb_pay" runat="server" Width="163px" OnSelectedIndexChanged="cmb_pay_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 100px; text-align: left">Basic Pay</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:DropDownList ID="cmb_basic" runat="server" Width="178px" OnSelectedIndexChanged="cmb_basic_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; text-align: left">Variable DA</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:RadioButtonList ID="rd_da" runat="server" Width="148px" OnSelectedIndexChanged="rd_da_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="T">Yes</asp:ListItem>
                                            <asp:ListItem Value="F">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 100px; text-align: left">SecurityDeposit</td>
                                    <td style="width: 100px; text-align: center">
                                        <asp:RadioButtonList ID="rd_secdep" runat="server" Width="153px" OnSelectedIndexChanged="rd_secdep_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="T">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="F">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Panel ID="pnl_secdep" runat="server" Height="80px">
                                            <table style="width: 609px" border="1">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 108px; text-align: left">Security Deposit</td>
                                                        <td style="width: 99px">
                                                            <asp:TextBox ID="txt_secdep" onkeypress="ok()" runat="server" Width="195px" MaxLength="7"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 100px; text-align: left">Deposit Amount</td>
                                                        <td style="width: 100px">
                                                            <asp:TextBox ID="txt_depamt" onkeypress="ok()" runat="server" Width="163px" MaxLength="7"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 108px; text-align: left">RD Amount</td>
                                                        <td style="width: 99px">
                                                            <asp:TextBox ID="txt_rdamt" onkeypress="ok()" runat="server" Width="195px" MaxLength="6"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 100px; text-align: left">Inst No</td>
                                                        <td style="width: 100px; text-align: left">
                                                            <asp:TextBox ID="txt_instno" onkeyup=" correct('txt_instno')" runat="server" Width="79px" MaxLength="3"></asp:TextBox>&nbsp;Months</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px; height: 28px; text-align: left">Total Salary</td>
                                    <td style="width: 100px; height: 28px">
                                        <asp:TextBox ID="txt_salary" runat="server" Width="158px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; height: 28px; text-align: left">Bond</td>
                                    <td style="width: 100px; height: 28px">
                                        <asp:DropDownList ID="cmb_bond" runat="server" Width="179px" OnSelectedIndexChanged="cmb_bond_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="0">No Bond</asp:ListItem>
                                            <asp:ListItem Value="1">Indeminity Cum Surety</asp:ListItem>
                                            <asp:ListItem Value="2">Assurance Bond</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Panel ID="pnl_bond" runat="server" Width="125px" Height="50px">
                                            <table border="1" style="width: 609px">
                                                <tr>
                                                    <td style="width: 111px; text-align: left;">Bond Amount</td>
                                                    <td style="width: 79px">
                                                        <asp:TextBox ID="txt_bondamt" runat="server" Width="195px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px; text-align: left;">Period</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txt_bondprd" runat="server" Width="163px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px"></td>
                                    <td style="width: 100px"></td>
                                    <td style="width: 100px"></td>
                                    <td style="width: 100px"></td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rd_secdep" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmb_bond" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmb_pay" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rd_da" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="text-align: center">
                <asp:Button ID="cmd_Confirm" runat="server" OnClientClick="return fillcheck()" Text="Confirm" />
            </td>
            <td style="text-align: center">
                <asp:Button ID="cmd_exit" runat="server" Text="  Exit  " />
            </td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
    </table>
</asp:Content>

