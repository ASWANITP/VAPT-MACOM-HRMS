<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Transfer_cancel.aspx.vb" Inherits="WebAppHRMS.nov2010_Transfer_cancel_8880928d7527" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script language="javascript" type="text/javascript">

        var cs = cont_name.split("Txt");

        function fill() {

            var str = document.getElementById(cs[0] + 'Txt_empcode').value;
            if (str == ' ') {
                document.getElementById(cs[0] + 'Txt_empcode').value = "";
                document.getElementById(cs[0] + 'Txt_empcode').focus;
                document.getElementById(cs[0] + "Txt_empname").value = "";
                document.getElementById(cs[0] + "Txt_des").value = "";
                document.getElementById(cs[0] + "Txt_dep").value = "";
                document.getElementById(cs[0] + "Txt_pos").value = "";
                document.getElementById(cs[0] + "Txt_br").value = "";
                document.getElementById(cs[0] + "Txt_br1").value = "";
                document.getElementById(cs[0] + "Txt_ps1").value = "";
                document.getElementById(cs[0] + "Txt_dt").value = "";
                alert("PLEASE ENTER THE EMPLOYEE CODE")
                return false;
            }
            if (isNaN(str)) {
                document.getElementById(cs[0] + 'Txt_empcode').value = "";
                document.getElementById(cs[0] + 'Txt_empcode').focus;
                document.getElementById(cs[0] + "Txt_empname").value = "";
                document.getElementById(cs[0] + "Txt_des").value = "";
                document.getElementById(cs[0] + "Txt_dep").value = "";
                document.getElementById(cs[0] + "Txt_pos").value = "";
                document.getElementById(cs[0] + "Txt_br").value = "";
                document.getElementById(cs[0] + "Txt_br1").value = "";
                document.getElementById(cs[0] + "Txt_ps1").value = "";
                document.getElementById(cs[0] + "Txt_dt").value = "";
                document.getElementById(cs[0] + "Txt_dp1").value = "";
                alert("PLEASE ENTER THE EMPLOYEE CODE")
                return false;
            }

            sub_call_server(document.getElementById(cs[0] + 'Txt_empcode').value);
        }

        function sub_call_receiver(arg1) {
            var arg2;
            arg2 = arg1.split("@");
            if (arg2[0] != "$") {

                var arg3 = arg2[0].split("*");

                document.getElementById(cs[0] + "Txt_empname").value = arg3[1];
                document.getElementById(cs[0] + "Txt_des").value = arg3[2];
                document.getElementById(cs[0] + "Txt_dep").value = arg3[3];
                document.getElementById(cs[0] + "Txt_pos").value = arg3[4];
                document.getElementById(cs[0] + "Txt_br").value = arg3[5];
                document.getElementById(cs[0] + "Txt_br1").value = arg3[8];
                document.getElementById(cs[0] + "Txt_ps1").value = arg3[7];
                document.getElementById(cs[0] + "Txt_dt").value = arg3[6];
                document.getElementById(cs[0] + "Txt_dp1").value = arg3[9];
            }
            else {
                alert('EMPLOYEE NOT FOUND!')
                document.getElementById(cs[0] + "Txt_empname").value = "";
                document.getElementById(cs[0] + "Txt_des").value = "";
                document.getElementById(cs[0] + "Txt_dep").value = "";
                document.getElementById(cs[0] + "Txt_pos").value = "";
                document.getElementById(cs[0] + "Txt_br").value = "";
                document.getElementById(cs[0] + "Txt_br1").value = "";
                document.getElementById(cs[0] + "Txt_ps1").value = "";
                document.getElementById(cs[0] + "Txt_dt").value = "";
                document.getElementById(cs[0] + "Txt_dp1").value = "";
            }
        }
        function exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <table style="width: 740px">
            <tr>
                <td colspan="4" style="height: 21px">
                    <strong><span style="color: #cc0033">TRANSFER CANCEL</span></strong></td>
            </tr>
            <tr>
                <td style="width: 150px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <strong>Enter employee Code:</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="Txt_empcode" runat="server" Width="127px" onchange="return fill()"></asp:TextBox></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 150px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <strong>EMPLOYEE DETAILS</strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 107px">
                    <table style="width: 746px">
                        <tr>
                            <td style="width: 645px; height: 22px; text-align: left">
                                <span style="font-family: Courier New">EMPLOYEE NAME:</span></td>
                            <td colspan="2" style="height: 22px; text-align: left">
                                <asp:TextBox ID="Txt_empname" runat="server" ReadOnly="True" Width="337px"></asp:TextBox><span
                                    style="font-family: Courier New"></span></td>
                            <td style="width: 93px; height: 22px; text-align: left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 645px; text-align: left">
                                <span style="font-family: Courier New">DESIGNATION:</span></td>
                            <td style="width: 96px; text-align: left">
                                <asp:TextBox ID="Txt_des" runat="server" ReadOnly="True" Width="221px"></asp:TextBox>
                            </td>
                            <td style="width: 49px; text-align: left">
                                <span style="font-family: Courier New">POST:</span></td>
                            <td style="width: 93px; text-align: left">
                                <asp:TextBox ID="Txt_pos" runat="server" ReadOnly="True" Width="225px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 645px; text-align: left">
                                <span style="font-family: Courier New">BRANCH:</span></td>
                            <td style="width: 96px; text-align: left">
                                <asp:TextBox ID="Txt_br" runat="server" ReadOnly="True" Width="223px"></asp:TextBox></td>
                            <td style="width: 49px; text-align: left">
                                <span style="font-family: Courier New">DEPARTMENT:</span></td>
                            <td style="width: 93px; text-align: left">
                                <asp:TextBox ID="Txt_dep" runat="server" ReadOnly="True" Width="227px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 21px; text-align: center">
                                <strong>LATEST TRANSFER DETAILS</strong></td>
                        </tr>
                        <tr>
                            <td style="width: 645px; text-align: left">
                                <span style="font-family: Courier New">BRANCH :</span></td>
                            <td style="width: 96px; text-align: left">
                                <asp:TextBox ID="Txt_br1" runat="server" Width="225px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 49px; text-align: left">
                                <span style="font-family: Courier New">POST :</span></td>
                            <td style="width: 93px; text-align: left">
                                <asp:TextBox ID="Txt_ps1" runat="server" Width="225px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 645px; text-align: left">
                                <span style="font-family: Courier New">FROM DATE :</span></td>
                            <td style="width: 96px; text-align: left">
                                <asp:TextBox ID="Txt_dt" runat="server" Width="225px" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 49px; text-align: left">
                                <span style="font-family: Courier New">DEPARTMENT:</span></td>
                            <td style="width: 93px; text-align: left">
                                <asp:TextBox ID="Txt_dp1" runat="server" Width="225px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table style="width: 740px">
            <tr>
                <td style="width: 150px"></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="Cancel Latest Transfer"
                        Width="207px" /></td>
                <td style="width: 100px">
                    <input id="exit" style="font-weight: bold; width: 105px" type="button" value="EXIT" onclick="return exit_onclick()" /></td>
                <td style="width: 100px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

