<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_salary_sd_confirmation.aspx.vb" Inherits="WebAppHRMS.sd_updation_hrm_salary_sd_confirmation_6b6dff1c8099" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("cmb");

        function Button2_onclick() {
            window.open('../home.aspx', '_self');

        }

        function combochange() {
            document.getElementById("p1").style.display = "none";
            document.getElementById("p2").style.display = "none";
            document.getElementById(cs[0] + "Label1").value = "";

        }
        function sdselect(k) {
            if (document.getElementById("txt_" + k).checked == true) {
                var arr
                var arr1
                var arr2
                arr = document.getElementById("txt_" + k).id.split("_")
                arr2 = arr[1].split("@");
                arr1 = arr2[1];
                if (arr1 == "") {
                    document.getElementById("txt_" + k).checked = false;
                    alert('Sorry, SD.No is incorrect,You Cant Select This');
                    return false;
                }
                else if (arr1.length < 16) {
                    document.getElementById("txt_" + k).checked = false;
                    alert('Sorry, SD.No is incorrect,You Cant Select This');
                    return false;
                }
                else if (parseInt(arr2[2]) > parseInt(20000)) {
                    document.getElementById("txt_" + k).checked = false;
                    alert('Sorry, Amount>20000,You Cant Select This');
                    return false;
                }
            }
        }
        function checkbeforeconfirm() {
            document.getElementById(cs[0] + "hid2").value = "";
            for (k = 1; k <= document.getElementById(cs[0] + "hid1").value; k++) {
                if (document.getElementById("txt_" + k).checked == true) {
                    var arr
                    var arr1
                    var arr2

                    arr = document.getElementById("txt_" + k).id.split("_")
                    arr2 = arr[1].split("@");
                    arr1 = arr2[0] + " $ " + "1";
                    if (k == 1) {
                        document.getElementById(cs[0] + "hid2").value = arr1;
                    }
                    if (k != 1) {
                        document.getElementById(cs[0] + "hid2").value += "!" + arr1;
                    }
                }
                if (document.getElementById("txt_" + k).checked == false) {
                    var arr
                    var arr1
                    var arr2
                    arr = document.getElementById("txt_" + k).id.split("_")
                    arr2 = arr[1].split("@");
                    arr1 = arr2[0] + " $ " + "0";
                    if (k == 1) {
                        document.getElementById(cs[0] + "hid2").value = arr1;
                    }
                    if (k != 1) {
                        document.getElementById(cs[0] + "hid2").value += "!" + arr1;
                    }
                }
            }

        }

        function checkallfunction() {
            if (document.getElementById("txt_all").checked == true) {
                var scount = 0
                for (k = 1; k <= document.getElementById(cs[0] + "hid1").value; k++) {
                    var arr
                    var arr1
                    var arr2
                    arr = document.getElementById("txt_" + k).id.split("_")
                    arr2 = arr[1].split("@");
                    arr1 = arr2[1];
                    if (arr1 == "") {
                        scount = 1
                        document.getElementById("txt_" + k).checked = false;
                    }
                    else if (arr1.length < 16) {
                        scount = 1
                        document.getElementById("txt_" + k).checked = false;
                    }
                    else if (parseInt(arr2[2]) > parseInt(20000)) {
                        scount = 2
                        document.getElementById("txt_" + k).checked = false;
                    }
                    else if (arr1 != "") {
                        document.getElementById("txt_" + k).checked = true;
                    }
                }
                if (scount == 1) {
                    alert('Sorry, SD.No is Missing,You Cant Select Some Records');
                }
                if (scount == 2) {
                    alert('Sorry, Amount>20000,You Cant Select Some Records');
                }

            }

            if (document.getElementById("txt_all").checked == false) {
                for (k = 1; k <= document.getElementById(cs[0] + "hid1").value; k++) {
                    document.getElementById("txt_" + k).checked = false;

                }
            }
        }

        // ]]>
    </script>

    <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="text-align: center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <table style="width: 472px; height: 82px" border="1">
                    <tr>
                        <td style="height: 44px; text-align: center" colspan="2"><span style="color: #ff0099; text-decoration: underline"><strong>HRM SD CONFIRMATION</strong></span></td>
                    </tr>
                    <tr>
                        <td style="width: 120px; text-align: right">Select Department : </td>
                        <td style="width: 100px; text-align: left">
                            <asp:DropDownList ID="cmb_dpt" runat="server" Width="332px">
                            </asp:DropDownList></td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="text-align: center">

        <table border="1" style="width: 472px; height: 3px">
            <tr>
                <td colspan="2" style="height: 9px; text-align: center">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                                <td style="width: 100px">
                                    <input id="Button2" style="width: 74px" type="button"
                                        value="EXIT" onclick="return Button2_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    &nbsp; &nbsp; &nbsp;&nbsp;<asp:HiddenField ID="hid3" runat="server" />
    <br />
    <div style="text-align: center">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Purple" Width="657px"></asp:Label><br />
    </div>
    <div style="text-align: center">
        <table border="0">
            <tr id="p1">
                <td style="width: 100px; height: 63px">
                    <asp:Panel ID="Panel1" runat="server" Height="40px" Visible="False" Width="805px">
                        <asp:HiddenField ID="hid2" runat="server" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="0">
            <tr id="p2">
                <td style="width: 100px; height: 28px">
                    <asp:Panel ID="Panel2" runat="server" Height="50px" Visible="False" Width="125px">
                        &nbsp;<asp:Button ID="cmd_confirm1" runat="server" OnClientClick="checkbeforeconfirm()"
                            Text="CONFIRM" Width="106px" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    &nbsp;<asp:HiddenField ID="hid1" runat="server" />
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
    <br />
    <br />
</asp:Content>

