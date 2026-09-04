<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_incentive_edit.aspx.vb" Inherits="WebAppHRMS.Incentive_Edit_hrm_incentive_edit_363618856837" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('ddl');

        function btnExit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function ClassOnChange() {
            document.getElementById(con[0] + "Hidden4").value = "";
            document.getElementById(con[0] + "Hidden1").value = document.getElementById(con[0] + "ddlIncentive").value

            if (document.getElementById(con[0] + "ddlIncentive").value == -1) {
                document.getElementById("row1").style.display = 'none';
                return false;
            }
            if (document.getElementById(con[0] + "Hidden1").value != -1) {
                callserver("1$" + document.getElementById(con[0] + "Hidden1").value, 1);
            }
        }
        function call_receiver(arg, context) {
            var Data = arg.split("@")
            switch (context) {
                case 1:

                    if (document.getElementById(con[0] + "Hidden1").value == -1) {
                        document.getElementById("row1").style.display = 'none';
                        return false;

                    }
                    else {
                        document.getElementById("row1").style.display = 'inline';
                        document.getElementById(con[0] + "Hidden2").value = Data[0];
                        disp();
                    }
                    break;
                case 2:
                    alert(arg);
                    window.open('hrm_incentive_edit.aspx', '_self');
                    break;
                case 3:
                    alert(arg);
                    window.open('hrm_incentive_edit.aspx', '_self');
                    break;
            }
        }
        function disp() {
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(con[0] + "Hidden1").value == -1) {
                document.getElementById(con[0] + "Panel1").innerHTML = "";
                document.getElementById("row1").style.display = "none";
                return false;
            }
            st2 = document.getElementById(con[0] + "Hidden2").value.split("!")
            ar = st2.length - 1;
            if (document.getElementById(con[0] + "Hidden2").value != "") {
                for (k = 0; k < ar; k++) {
                    st3 = st2[k].split("*")
                    st1 = st1 + "<tr><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><input type='checkbox' id='chkm_" + k + "' name='txtm_" + k + "' onclick=chkkm('" + k + "','chkm_" + k + "','txt_" + k + "')></td><td><input type='textbox' id='txt_" + k + "' name='txt_" + k + "' style='display:none' maxlength='100' onkeypress=isNumberKey('" + k + "','txt_" + k + "') onblur=isNumberKey('" + k + "','txt_" + k + "')></td><td id='row" + k + "' width=10% align=right style= 'font-size: 10pt;' ><a href=javascript:delf(" + k + "," + st3[0] + ")>Del</a></td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMPLOYEE&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;AMOUNT&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EDIT&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;ENTER AMOUNT&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;DELETE&nbsp;&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
            }
            else {
                st1 = st + "</table>";
            }
            document.getElementById("row1").style.display = "inline";
            document.getElementById(con[0] + "Panel1").innerHTML = st1;
        }
        function chkkm(id, a, b) {
            //debugger;
            var at = "";
            var rid;
            ar = document.getElementById(con[0] + "Hidden2").value.split("!")

            if ((document.getElementById(a).checked == true) || (document.getElementById(b).value == "")) {
                document.getElementById(b).value = "";
                document.getElementById(b).style.display = "inline";
                document.getElementById(b).focus();
            }
            if ((document.getElementById(a).checked == false)) {
                document.getElementById(b).style.display = "none";
                document.getElementById(b).value = "";
            }

        }
        function isNumberKey(id, a) {
            if (isNaN(document.getElementById(a).value)) {
                document.getElementById(a).value = "";
                return false;
            }
        }
        function delf(a, b) {
            var Flag = confirm("Are You Sure Want To Delete This Record");

            if (Flag == true) {
                document.getElementById("row" + a + "").style.display = "none";
                document.getElementById(con[0] + "Hidden4").value = document.getElementById(con[0] + "Hidden4").value + "#" + document.getElementById(con[0] + "ddlIncentive").value + "!" + b;

                alert(document.getElementById(con[0] + "Hidden4").value);

            }


        }

        function onclickconf() {
            //debugger;
            if (document.getElementById(con[0] + "ddlIncentive").value == -1) {
                alert("Please Select Incentive");
                return false;
            }
            var Flag = confirm("Are You Sure to Confirm");

            if (Flag == true) {
                document.getElementById(con[0] + "Hidden3").value = "";

                if (document.getElementById(con[0] + "Hidden2").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(con[0] + "Hidden2").value.split("!")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("*")
                        var Regular = "T";
                        if (document.getElementById("chkm_" + i + "").checked == false) Regular = "F";
                        if (document.getElementById("chkm_" + i + "").checked == true && document.getElementById("txt_" + i + "").value == "") {
                            alert("Please Enter Amount!!!");
                            document.getElementById("txt_" + i + "").focus();
                            return false;
                        }
                        Amount = document.getElementById("txt_" + i + "").value;
                        document.getElementById(con[0] + "Hidden3").value += st3[0] + "^" + st3[1] + "^" + st3[2] + "^" + Regular + "^" + Amount + "#";
                    }
                }
                var Dataa = document.getElementById(con[0] + "Hidden3").value;
                var InsID = document.getElementById(con[0] + "Hidden1").value;
                data = Dataa + "%" + InsID + "%" + 112;
                callserver("2$" + data, 2);
                callserver("3$" + document.getElementById(con[0] + "Hidden4").value, 3);
            }
            if (Flag == false) {
                return false;
            }
        }
        // ]]>
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="Hidden4" runat="server" />
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="Hidden3" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td style="width: 30%">
                    <strong>Select Incentive</strong></td>
                <td style="width: 30%">
                    <asp:DropDownList ID="ddlIncentive" runat="server" Width="99%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td id="row1" colspan="2" style="height: 42px">
                    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="99%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;<input id="btnConfirm" type="button" value="CONFIRM" onclick="onclickconf()" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 30%"></td>
                <td style="width: 30%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

