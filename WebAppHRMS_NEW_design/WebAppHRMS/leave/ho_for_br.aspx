<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="ho_for_br.aspx.vb" Inherits="WebAppHRMS.punching_ho_for_br_634273e19131" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        var cont = cont_name.split("txt")
        function checkid(id) {
            var main, tos
            if (document.getElementById(cont[0] + id).value == "") {
            }
            else {
                check_emp(id)
            }
        }
        function btn_check() {
            if (document.getElementById(cont[0] + "txt_date").value == "") {
                alert("Select Date")
                return false
            }
            if (document.getElementById(cont[0] + "RadioButton1").checked == false) {
                if (document.getElementById(cont[0] + "RadioButton2").checked == false) {
                    alert("Select Morning Or Evening")
                    return false
                }
            }
            if (document.getElementById(cont[0] + "Panel1").value == "") {
                alert("Could not Confirm")
                return false
            }
            else
                return true
        }
        function check_emp(id) {

            var str;
            var st;
            var flag
            flag = 1
            if (document.getElementById(cont[0] + "Hid_id").value == "") {

                if (document.getElementById(cont[0] + id).value == "__:__:__") {
                    alert("Enter Time")
                    return false
                }
                else {
                    check_time(id)
                }
            }
            else {
                st = document.getElementById(cont[0] + "Hid_id").value.split("@")
                for (funi = 0; funi < st.length; funi++) {
                    if (id == st[funi]) {
                        // flag=0
                        flag = 1
                        // return false
                    }
                }
                if (flag = 1) {

                    if (document.getElementById(cont[0] + id).value == "__:__:__") {
                        alert("Enter Time")
                        return false
                    }
                    else {
                        check_time1(id)
                    }

                }
            }
        }
        function check_time(id) {
            var st, flag
            flag = 1
            st = document.getElementById(cont[0] + id).value.split(":")
            for (funi = 0; funi < st.length; funi++) {
                if (st[funi] == "__") {
                    if (funi == 0) {
                        alert("Hour is not correct.Enter it once more")
                        flag = 0
                        return false
                    }
                    if (funi == 1) {
                        flag = 0
                        alert("minit is not correct.Enter it once more")
                        return false
                    }
                    if (funi == 2) {
                        flag = 0
                        alert("Second is not correct.Enter it once more")
                        return false
                    }
                }
            }
            if (flag = 1) {
                document.getElementById(cont[0] + "hid_time").value = document.getElementById(cont[0] + "hid_time").value + ":" + document.getElementById(cont[0] + id).value
                document.getElementById(cont[0] + "Hid_id").value = id
                str = id + "*" + document.getElementById(cont[0] + id).value
                alert(str)
                document.getElementById(cont[0] + "Hidden1").value = str
            }
        }
        function check_time1(id) {
            var st, flag
            flag = 1
            st = document.getElementById(cont[0] + id).value.split(":")
            for (funi = 0; funi < st.length; funi++) {
                if (st[funi] == "__") {
                    if (funi == 0) {
                        flag = 0
                        alert("Hour is not correct.Enter it once more")
                        return false
                    }
                    if (funi == 1) {
                        flag = 0
                        alert("minit is not correct.Enter it once more")
                        return false
                    }
                    if (funi == 2) {
                        flag = 0
                        alert("Second is not correct.Enter it once more")
                        return false
                    }
                }
            }
            if (flag = 1) {
                document.getElementById(cont[0] + "hid_time").value = document.getElementById(cont[0] + "hid_time").value + ":" + document.getElementById(cont[0] + id).value
                document.getElementById(cont[0] + "Hid_id").value = document.getElementById(cont[0] + "Hid_id").value + "@" + id
                str = id + "*" + document.getElementById(cont[0] + id).value
                document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "Hidden1").value + "!" + str
                alert(str)
            }
        }
        function btn_check_time(str) {
            var st, flag
            flag = 1
            st = str.value.split(":")
            for (funi = 0; funi < st.length; funi++) {
                if (st[funi] == "__") {
                    if (funi == 0) {
                        alert("Hour is not correct.Enter it once more")
                        flag = 0
                        return false
                    }
                    if (funi == 1) {
                        flag = 0
                        alert("minit is not correct.Enter it once more")
                        return false
                    }
                    if (funi == 2) {
                        flag = 0
                        alert("Second is not correct.Enter it once more")
                        return false
                    }
                }
            }
            if (flag = 1) {
                document.getElementById(cont[0] + "Hid_id").value = id
                str = id + "*" + document.getElementById(cont[0] + id).value
                document.getElementById(cont[0] + "Hidden1").value = str
            }
        }
    </script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 792px; position: static; height: 51px" border="1">
                    <tbody>
                        <tr>
                            <td colspan="5"><span style="text-decoration: underline"><strong>BRANCH&nbsp;&nbsp;PUNCH</strong></span></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Label Style="position: static" ID="Label1" runat="server" Width="540px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 193px; height: 28px" colspan="2"><strong>Select Morning/evening</strong></td>
                            <td style="height: 28px; text-align: center" colspan="3">
                                <asp:RadioButton Style="position: static" ID="RadioButton1" runat="server" Text="MORNING" Font-Bold="True" AutoPostBack="True" GroupName="raj" OnCheckedChanged="RadioButton1_CheckedChanged"></asp:RadioButton>
                                <asp:RadioButton Style="position: static" ID="RadioButton2" runat="server" Text="EVENING" Font-Bold="True" AutoPostBack="True" GroupName="raj" OnCheckedChanged="RadioButton2_CheckedChanged"></asp:RadioButton></td>
                        </tr>
                        <tr>
                            <td style="width: 193px; height: 28px" id="TD1" colspan="2" runat="server">
                                <asp:Label Style="position: static" ID="Label2" runat="server" Width="102px" Text="Select Date" Font-Bold="True"></asp:Label></td>
                            <td style="height: 28px; text-align: center" id="TD2" colspan="3" runat="server">
                                <asp:TextBox Style="position: static" ID="txt_date" runat="server" Font-Bold="True" AutoPostBack="True" OnTextChanged="txt_date_TextChanged"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 193px; height: 28px" colspan="2"><strong>Select Branch</strong></td>
                            <td style="height: 28px; text-align: center" colspan="3">
                                <asp:DropDownList Style="position: static" ID="cmb_branch" runat="server" Width="270px" AutoPostBack="True" OnSelectedIndexChanged="cmb_branch_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;&nbsp;
                                <asp:TextBox Style="position: static" ID="txt_hid" runat="server" Width="1px" Visible="False"></asp:TextBox>
                                <input style="width: 1px; position: static" id="Hidden1" type="hidden" runat="server" />
                                <input style="width: 1px; position: static" id="Hid_id" type="hidden" runat="server" />
                                <input style="width: 1px; position: static" id="hid_time" type="hidden" runat="server" />
                                <asp:TextBox ID="txt_cntd" runat="server" Style="position: static" Visible="False"
                                    Width="1px"></asp:TextBox>
                                <asp:TextBox ID="txt_cnt" runat="server" Style="position: static" Visible="False"
                                    Width="1px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 59px" colspan="5">
                                <asp:Panel Style="position: static" ID="Panel1" runat="server" Width="125px" Height="50px">
                                </asp:Panel>
                                &nbsp;&nbsp; </td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button Style="position: static" ID="Button1" OnClick="Button1_click" runat="server" Width="135px" Text="Confirm" Font-Bold="True"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button Style="position: static" ID="Button2" runat="server" Width="61px" Text="Exit" Font-Bold="True" OnClick="Button2_Click"></asp:Button>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_date"></cc1:CalendarExtender>
                                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_branch"></cc1:ListSearchExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

