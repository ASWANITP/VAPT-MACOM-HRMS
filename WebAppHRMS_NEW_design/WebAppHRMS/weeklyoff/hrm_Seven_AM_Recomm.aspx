<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Seven_AM_Recomm.aspx.vb" Inherits="WebAppHRMS._7DaysWorking_hrm_Seven_AM_Recomm_e05ab3dc8499" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var cont = master_no.split("cmb");

        function Button2_onclick() {
            window.open('../home.aspx', '_self')
        }
        function FillEmployDetails() {
            data = document.getElementById(cont[0] + "cmb_Select").value;
            document.getElementById(cont[0] + "hid_emp").value = document.getElementById(cont[0] + "cmb_Select").value;
            data = data + "%" + 111;
            ToServer(data + "#" + 1, 1);
        }
        function disp() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont[0] + "Hidden1").value == "") {
                document.getElementById(cont[0] + "Panel1").innerHTML = "";
                document.getElementById("row1").style.display = "none";
                return;
            }
            st2 = document.getElementById(cont[0] + "Hidden1").value.split("!")
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                for (k = 0; k < ar; k++) {
                    st3 = st2[k].split("*")
                    if (st3[5] == 1)
                        var STA = 'SUNDAY';
                    if (st3[5] == 2)
                        var STA = 'MONDAY';
                    if (st3[5] == 3)
                        var STA = 'TUESDAY';
                    if (st3[5] == 4)
                        var STA = 'WEDNESDAY';
                    if (st3[5] == 5)
                        var STA = 'THURSDAY';
                    if (st3[5] == 6)
                        var STA = 'FRIDAY';
                    if (st3[5] == 7)
                        var STA = 'SATURDAY';

                    st1 = st1 + "<tr><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + STA + "</td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>BRANCH</b></td><td><small><b>BH ASSIGNED FROM DATE</b></td><td><small><b>ASSIGNED OFF DAY</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
            }
            else {
                st1 = st + "</table>";
            }
            document.getElementById("row1").style.display = "inline";
            document.getElementById(cont[0] + "Panel1").innerHTML = st1;
        }
        function FromServer(arg, context) {
            //debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:

                    if (document.getElementById(cont[0] + "cmb_Select").value == 0) {
                        document.getElementById("row1").style.display = "none";

                        return false;
                    }
                    else {
                        document.getElementById(cont[0] + "Hidden1").value = Data[0];
                        disp();

                    }
                    break;
                case 2:
                    alert(arg);
                    window.open('hrm_Seven_AM_Recomm.aspx', '_self');
                    break;
            }
        }


        function onclickconfirm() {

            var Status = 1
            //debugger;
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                var Dataa = document.getElementById(cont[0] + "Hidden1").value;
                var Code = document.getElementById(cont[0] + "hid_emp").value;
                data = Dataa + "%" + Code + "%" + Status + "%" + 112;
                ToServer(data + "#" + 2, 2);
            }

        }

        function onclickReject() {
            var Status = 2
            //debugger;
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                var Dataa = document.getElementById(cont[0] + "Hidden1").value;
                var Code = document.getElementById(cont[0] + "hid_emp").value;
                data = Dataa + "%" + Code + "%" + Status + "%" + 112;
                ToServer(data + "#" + 2, 2);
            }

        }


        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 53%; height: 89px;">
            <tr>
                <td colspan="2" style="height: 29px; width: 256px;">Select Employee</td>
                <td style="height: 29px; text-align: left;" colspan="2">
                    <asp:DropDownList ID="cmb_Select" onchange="FillEmployDetails()" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="390px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 9px; width: 256px;">Effective date</td>
                <td colspan="2" style="height: 9px; text-align: left">
                    <asp:TextBox ID="txt_date" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="row1" style="display: none">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Height="50px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btn_reject" onclick="onclickReject()" style="font-size: 12.5pt; width: 138px; font-family: 'Times New Roman'"
                        type="button" value="REJECT" />&nbsp;
                    <input id="Button1" onclick="onclickconfirm()" style="font-size: 12pt; width: 123px; font-family: 'Times New Roman'"
                        type="button" value="SANCTION" />
                    <input id="Button2" style="font-size: 12pt; width: 116px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
    <input id="Hidden1" runat="server" type="hidden" style="width: 16px" />
    <input id="hid_emp" runat="server" type="hidden" style="width: 16px" />
    <input id="hid_area" runat="server" type="hidden" />
</asp:Content>

