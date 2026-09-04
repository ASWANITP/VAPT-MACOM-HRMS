<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="AssignLeave_authorityMAC.aspx.vb" Inherits="WebAppHRMS.leave_AssignLeave_authority_54ff50e76897" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = loanno.split("txt");


        function txtexit_onclick() {
            window.open('../home.aspx', '_self');
        }
        var st, st1;
        function emp_fill() {

            var ecode = document.getElementById(con[0] + "ddl_emp").value;
            call_server("1*" + ecode, 1);
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1:
                    {
                        DynmcTbleFill(arg);
                        break;
                    }
            }
        }




        function DynmcTbleFill(str) {
            debugger;
            st = "";
            st1 = "";
            var rid;
            var rnm;
            var snm;
            var qty = str.split("@");
            for (a = 0; a < qty.length - 1; a++) {
                var msr = qty[a].split("*");
                rid = a + 1;
                //debugger;
                if (msr[6] == -1) {
                    rnm = 'NO AUTHORITY';
                }
                else {
                    rnm = msr[2];
                }
                if (msr[7] == -1) {
                    snm = 'NO AUTHORITY';
                }
                else {
                    snm = msr[3];
                }
                st1 = st1 + "<tr><td><small>" + msr[0] + " TO " + msr[1] + "</td><td><small><a href=javascript:update(" + rid + ",1)>" + rnm + "</td><td><small><a href=javascript:update(" + rid + ",2)>" + snm + "</td><td style=display:none>" + msr[6] + "</td><td style=display:none>" + msr[7] + "</td><td style=display:none>" + msr[8] + "</td></tr>"
                document.getElementById(con[0] + "txtBranch").value = msr[4];
                document.getElementById(con[0] + "txtPost").value = msr[5];
            }
            ////
            for (a = 0; a <= qty.length; a++) {
                if (a == qty.length) {
                    var msrs = qty[a - 1].split("*");
                    var ms = msrs[0].split("#");
                    var mss = msrs[1].split("#");
                    rid = rid + 1;
                    var rnmc = ms[0]
                    var snmc = mss[0]
                    var rnmt = ms[1]
                    var snmt = mss[1]
                    var rnma = ms[2]
                    var snma = mss[2]
                    var rnme = ms[3]
                    var snme = mss[3]

                    var rcoc = ms[4]
                    var scoc = mss[4]
                    var rcot = ms[5]
                    var scot = mss[5]
                    var rcoa = ms[6]
                    var scoa = mss[6]
                    var rcoe = ms[7]
                    var scoe = mss[7]
                    var rules = mss[8]
                    var scomp = "<tr><td><small><b>COMPENSATORY</td><td><small><a href=javascript:update(" + rid + ",3)>" + rnmc + "</td><td><small><a href=javascript:update(" + rid + ",4)>" + snmc + "</td><td style=display:none>" + rcoc + "</td><td style=display:none>" + scoc + "</td><td style=display:none>" + rules + "</td></tr>"
                    rid = rid + 1
                    var stour = "<tr><td><small><b>TOUR</td><td><small><a href=javascript:update(" + rid + ",5)>" + rnmt + "</td><td><small><a href=javascript:update(" + rid + ",6)>" + snmt + "</td><td style=display:none>" + rcot + "</td><td style=display:none>" + scot + "</td><td style=display:none>" + rules + "</td></tr>"
                    rid = rid + 1
                    var satt = "<tr><td><small><b>ATTENDANCE REGULARIZATION</td><td><small><a href=javascript:update(" + rid + ",7)>" + rnma + "</td><td><small><a href=javascript:update(" + rid + ",8)>" + snma + "</td><td style=display:none>" + rcoa + "</td><td style=display:none>" + scoa + "</td><td style=display:none>" + rules + "</td></tr>"
                    rid = rid + 1
                    var sear = "<tr><td><small><b>EARLY GOING</td><td><small><a href=javascript:update(" + rid + ",9)>" + rnme + "</td><td><small><a href=javascript:update(" + rid + ",10)>" + snme + "</td><td style=display:none>" + rcoe + "</td><td style=display:none>" + scoe + "</td><td style=display:none>" + rules + "</td></tr>"
                }
            }
            ////
            st = st + "<table id='mytable' border=1 width='835px' style='margin: 0 auto;'><tr><td><small><b>Leave Days</b></td><td><small><b>Recommendation</b></td><td><small><b>Sanction</b></td></tr>"
            st1 = st + st1 + scomp + stour + satt + sear + "</table>"
            //st1=st+st1+"</table>" 
            document.getElementById("row1").style.display = "inline"; 820
            document.getElementById(con[0] + "Panel1").innerHTML = st1
        }
        function update(id, opn) {

            debugger;

            document.addEventListener("DOMContentLoaded", function () {
                // using 'con[0]' and 'id' assumes these are defined globally or elsewhere in your script
                document.getElementById(con[0] + "Hidden1").value = id;
            });

            document.getElementById(con[0] + "Hidden1").value = id;
            if (opn == 1) {
                document.getElementById("rowrec").style.display = "inline";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 2) {
                document.getElementById("rowsan").style.display = "inline";
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 3) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "inline";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 4) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "inline";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 5) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "inline";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 6) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "inline";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 7) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "inline";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 8) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "inline";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 9) {
                debugger;
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "inline";
                document.getElementById("saear").style.display = "none";
            }
            if (opn == 10) {
                document.getElementById("rowrec").style.display = "none";
                document.getElementById("rowsan").style.display = "none";
                document.getElementById("recom").style.display = "none";
                document.getElementById("sacom").style.display = "none";
                document.getElementById("retour").style.display = "none";
                document.getElementById("satour").style.display = "none";
                document.getElementById("reat").style.display = "none";
                document.getElementById("saat").style.display = "none";
                document.getElementById("reear").style.display = "none";
                document.getElementById("saear").style.display = "inline";
            }
        }


        function update_data(opt) {
            debugger;
            var rowid = 0;

            //document.addEventListener("DOMContentLoaded", function () {
            //    rowid = document.getElementById(con[0] + "Hidden1").value;
            //});

            rowid = document.getElementById(con[0] + "Hidden1").value;


            if (opt == 1)//recom
            {
                if (document.getElementById(con[0] + "ddlRec").value == -1) {
                    alert("Select Recommendation authority..!");
                    return false;
                }
                if (document.getElementById(con[0] + "ddlRec").value == document.getElementById(con[0] + "ddl_emp").value) {
                    alert("An Employee cannot be authority to him/her self!");
                    return false;
                }

                document.getElementById("mytable").rows[rowid].cells[1].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "ddlRec").options[document.getElementById(con[0] + "ddlRec").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[3].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "ddlRec").value;

            }
            if (opt == 2) {
                if (document.getElementById(con[0] + "ddlSac").value == -1) {
                    alert("Select Sanction authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[2].innerHTML = "<small><a href=javascript:update(" + rowid + ",2)>" + document.getElementById(con[0] + "ddlSac").options[document.getElementById(con[0] + "ddlSac").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[4].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "ddlSac").value;
            }
            if (opt == 3)//recom
            {
                if (document.getElementById(con[0] + "DropDownList3").value == -1) {
                    alert("Select Compensatory Recommendation authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[1].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList3").options[document.getElementById(con[0] + "DropDownList3").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[3].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList3").value;

            }
            if (opt == 4) {
                if (document.getElementById(con[0] + "DropDownList4").value == -1) {
                    alert("Select Compensatory Sanction authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[2].innerHTML = "<small><a href=javascript:update(" + rowid + ",2)>" + document.getElementById(con[0] + "DropDownList4").options[document.getElementById(con[0] + "DropDownList4").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[4].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList4").value;
            }
            if (opt == 5)//recom
            {
                if (document.getElementById(con[0] + "DropDownList5").value == -1) {
                    alert("Select Tour Recommendation authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[1].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList5").options[document.getElementById(con[0] + "DropDownList5").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[3].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList5").value;

            }
            if (opt == 6) {
                if (document.getElementById(con[0] + "DropDownList6").value == -1) {
                    alert("Select Tour Sanction authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[2].innerHTML = "<small><a href=javascript:update(" + rowid + ",2)>" + document.getElementById(con[0] + "DropDownList6").options[document.getElementById(con[0] + "DropDownList6").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[4].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList6").value;
            }
            if (opt == 7)//recom
            {
                if (document.getElementById(con[0] + "DropDownList7").value == -1) {
                    alert("Select Regularization Recommendation authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[1].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList7").options[document.getElementById(con[0] + "DropDownList7").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[3].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList7").value;

            }
            if (opt == 8) {
                if (document.getElementById(con[0] + "DropDownList8").value == -1) {
                    alert("Select Regularization Sanction authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[2].innerHTML = "<small><a href=javascript:update(" + rowid + ",2)>" + document.getElementById(con[0] + "DropDownList8").options[document.getElementById(con[0] + "DropDownList8").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[4].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList8").value;
            }
            if (opt == 9)//recom
            {
                debugger;
                if (document.getElementById(con[0] + "DropDownList9").value == -1) {
                    alert("Select Regularization Recommendation authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[1].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList9").options[document.getElementById(con[0] + "DropDownList9").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[3].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList9").value;

            }
            if (opt == 10) {
                if (document.getElementById(con[0] + "DropDownList10").value == -1) {
                    alert("Select Regularization Sanction authority..!");
                    return false;
                }
                document.getElementById("mytable").rows[rowid].cells[2].innerHTML = "<small><a href=javascript:update(" + rowid + ",2)>" + document.getElementById(con[0] + "DropDownList10").options[document.getElementById(con[0] + "DropDownList10").selectedIndex].text;
                document.getElementById("mytable").rows[rowid].cells[4].innerHTML = "<small><a href=javascript:update(" + rowid + ",1)>" + document.getElementById(con[0] + "DropDownList10").value;
            }
        }
        function cancel() {
            debugger;
            document.getElementById("rowsan").style.display = "none";
            document.getElementById("rowrec").style.display = "none";
            document.getElementById("recom").style.display = "none";
            document.getElementById("sacom").style.display = "none";
            document.getElementById("retour").style.display = "none";
            document.getElementById("satour").style.display = "none";
            document.getElementById("reat").style.display = "none";
            document.getElementById("saat").style.display = "none";
            document.getElementById("reear").style.display = "none";
            document.getElementById("saear").style.display = "none";
            document.getElementById(con[0] + "Hidden1").value = "";
        }
        function OnConfirm() {
            debugger;
            var cnt;
            cnt = document.getElementById("mytable").rows.length;
            for (i = 0; i < cnt - 1; i++) {
                if (document.getElementById("mytable").rows[i + 1].cells[0].innerText != "COMPENSATORY" && document.getElementById("mytable").rows[i + 1].cells[0].innerText != "TOUR" && document.getElementById("mytable").rows[i + 1].cells[0].innerText != "ATTENDANCE REGULARIZATION" && document.getElementById("mytable").rows[i + 1].cells[0].innerText != "EARLY GOING") {
                    if (document.getElementById(con[0] + "Hidden2").value == "") {
                        document.getElementById(con[0] + "Hidden2").value = document.getElementById("mytable").rows[i + 1].cells[3].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[4].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[5].innerText;
                    }
                    else {
                        document.getElementById(con[0] + "Hidden2").value = document.getElementById(con[0] + "Hidden2").value + "@" + document.getElementById("mytable").rows[i + 1].cells[3].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[4].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[5].innerText;
                    }
                }
                else {
                    if (document.getElementById(con[0] + "Hidden3").value == "") {
                        document.getElementById(con[0] + "Hidden3").value = document.getElementById("mytable").rows[i + 1].cells[3].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[4].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[5].innerText;
                    }
                    else {
                        document.getElementById(con[0] + "Hidden3").value = document.getElementById(con[0] + "Hidden3").value + "@" + document.getElementById("mytable").rows[i + 1].cells[3].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[4].innerText + "#" + document.getElementById("mytable").rows[i + 1].cells[5].innerText;
                    }
                }
            }
            // alert(document.getElementById(con[0]+"hidden2").value)
        }
        // ]]>
    </script>

    <table border="1">
        <tr>
            <td colspan="4" style="height: 23px; text-align: center;">ASSIGN LEAVE AUTHORITY</td>
        </tr>
        <tr>
            <td style="width: 50px; text-align: center;">Employee</td>
            <td colspan="4" style="text-align: left;">
                <asp:DropDownList ID="ddl_emp" runat="server" Width="404px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: center;">Branch</td>
            <td style="width: 50px; text-align: left;">
                <input id="txtBranch" runat="server" style="width: 307px" type="text" readonly="readOnly" /></td>
            <td style="width: 100px; text-align: center;">Post</td>
            <td style="width: 100px">
                <input id="txtPost" runat="server" style="width: 287px" type="text" readonly="readOnly" /></td>
        </tr>
        <%--<tr id="row1" style="display:none;text-align:center;">
                <td colspan="4" style="height: 41px">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>--%>

        <tr>
            <td colspan="2" style="height: 28px; text-align: right;">
                <input id="Hidden1" type="hidden" runat="server" />
                <asp:Button ID="cmd_cfm" runat="server" Text="SUBMIT" OnClientClick="return OnConfirm()" /></td>
            <td colspan="2" style="height: 28px; text-align: left;">
                <input id="txtexit" style="width: 86px" type="button" value="EXIT" onclick="return txtexit_onclick()" />
                <input id="Hidden2" runat="server" type="hidden" />
                <input id="Hidden3" runat="server" type="hidden" /></td>
        </tr>
    </table>
    <table>
        <tr id="row1" style="display: none; text-align: center;">
            <td colspan="4" style="height: 41px">
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
            </td>
        </tr>
    </table>
    <div style="text-align: center;">
        <table id="mytable" border="1" width="835px" style="margin: 0 auto;">
            <tr id="rowrec" style="display: none;">
                <td colspan="4" style="height: 26px; text-align: left">Leave Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="ddlRec" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="cmdrec" type="button" value="UPDATE" onclick="update_data(1)" />
                    <input id="cmdrcancel" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="rowsan" style="display: none;">
                <td colspan="4" style="height: 28px; text-align: left">Leave Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:DropDownList ID="ddlSac" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="cmdsan" type="button" value="UPDATE" onclick="update_data(2)" />
                    <input id="cmdscancel" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>


            <tr id="recom" style="display: none;">
                <td colspan="4" style="height: 26px; text-align: left">Compensatory Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList3" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button1" type="button" value="UPDATE" onclick="update_data(3)" />
                    <input id="Button2" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="sacom" style="display: none;">
                <td colspan="4" style="height: 28px; text-align: left">Compensatory Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:DropDownList ID="DropDownList4" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button3" type="button" value="UPDATE" onclick="update_data(4)" />
                    <input id="Button4" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>

            <tr id="retour" style="display: none;">
                <td colspan="4" style="height: 26px; text-align: left">Tour Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList5" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button5" type="button" value="UPDATE" onclick="update_data(5)" />
                    <input id="Button6" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="satour" style="display: none;">
                <td colspan="4" style="height: 28px; text-align: left">Tour Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:DropDownList ID="DropDownList6" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button7" type="button" value="UPDATE" onclick="update_data(6)" />
                    <input id="Button8" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>

            <tr id="reat" style="display: none;">
                <td colspan="4" style="height: 26px; text-align: left">Regularization Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList7" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button9" type="button" value="UPDATE" onclick="update_data(7)" />
                    <input id="Button10" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="saat" style="display: none;">
                <td colspan="4" style="height: 28px; text-align: left">Regularization Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:DropDownList ID="DropDownList8" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button11" type="button" value="UPDATE" onclick="update_data(8)" />
                    <input id="Button12" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>

            <tr id="reear" style="display: none;">
                <td colspan="4" style="height: 26px; text-align: left">Early Going Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList9" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button13" type="button" value="UPDATE" onclick="update_data(9)" />
                    <input id="Button14" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="saear" style="display: none;">
                <td colspan="4" style="height: 28px; text-align: left">Early Going Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:DropDownList ID="DropDownList10" runat="server" Width="312px">
            </asp:DropDownList>
                    <input id="Button15" type="button" value="UPDATE" onclick="update_data(10)" />
                    <input id="Button16" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
        </table>
    </div>


</asp:Content>





