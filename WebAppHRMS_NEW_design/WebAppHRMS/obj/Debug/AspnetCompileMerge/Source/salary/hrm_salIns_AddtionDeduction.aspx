<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_salIns_AddtionDeduction.aspx.vb" Inherits="WebAppHRMS.Sal_InsAdditioDeduction_hrm_salIns_AddtionDeduction_f4cfa1865262" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">



    <div style="text-align: center">
        <asp:HiddenField ID="hdnToSendDel" runat="server" />
        <asp:HiddenField ID="hdnCheck" runat="server" />
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="hdnDelChange" runat="server" />
        <asp:HiddenField ID="hdnDelData" runat="server" />
        <asp:HiddenField ID="hdnDelCon" runat="server" />

        <table border="1" style="width: 60%">
            <tr>
                <td colspan="4">
                    <asp:RadioButton ID="rdAdd" runat="server" Checked="true" GroupName="Ins" onclick="ClickAddition()" Text="Addition" />
                    <asp:RadioButton ID="rdDeduction" runat="server" GroupName="Ins" onclick="ClickDeduction()" Text="Deduction" />
                    <asp:RadioButton ID="rdDelete" runat="server" GroupName="Ins" onclick="ClickDeletion()" Text="Delete" />
                </td>
            </tr>
            <tr id="rowCombo">
                <td style="width: 12%; height: 29px;">
                    <asp:Label ID="lblText" runat="server" Height="25px" Text="Select Additions" Width="194px"></asp:Label></td>
                <td style="height: 29px; text-align: left;" id="add" colspan="3">
                    <asp:DropDownList ID="ddlDed" runat="server" onchange="ComboChange()" Width="60%">
                        <asp:ListItem Selected="True" Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">LIC</asp:ListItem>
                        <asp:ListItem Value="2">P-Tax</asp:ListItem>
                        <asp:ListItem Value="3">TDS</asp:ListItem>
                        <asp:ListItem Value="4">Other Ded</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDel" runat="server" onchange="ComboChangeDel()" Width="60%">
                        <asp:ListItem Selected="True" Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Arrear Sal</asp:ListItem>
                        <asp:ListItem Value="2">Arrear DA</asp:ListItem>
                        <asp:ListItem Value="3">Other Add</asp:ListItem>
                        <%--<asp:ListItem Value="4">Remark Add</asp:ListItem>--%>
                        <asp:ListItem Value="5">LIC</asp:ListItem>
                        <asp:ListItem Value="6">P-Tax</asp:ListItem>
                        <asp:ListItem Value="7">TDS</asp:ListItem>
                        <asp:ListItem Value="8">Other Ded</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlAdd" onchange="ComboChange()" runat="server" Width="60%">
                        <asp:ListItem Selected="True" Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Arrear Sal</asp:ListItem>
                        <asp:ListItem Value="2">Arrear DA</asp:ListItem>
                        <asp:ListItem Value="3">Other Add</asp:ListItem>
                        <%--<asp:ListItem Value="4">Remark Add</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr id="rowEmp">
                <td style="width: 194px; height: 13px;">Enter Emp. Code</td>
                <td style="width: 194px; height: 13px">
                    <asp:TextBox ID="txtEcode" runat="server" Width="180%" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr id="rowEmpname">
                <td style="width: 194px; height: 13px">Emp. Name</td>
                <td style="width: 194px; height: 13px">
                    <asp:TextBox ID="txtEname" runat="server" Width="180%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="rowAmt">
                <td style="height: 13px; width: 194px; text-align: center">Enter Amount</td>
                <td style="height: 13px; width: 194px; text-align: left">
                    <asp:TextBox ID="txtAmt" runat="server" onblur="isNumericAmt()" onkeypress="isNumericAmt()" Width="180%"></asp:TextBox></td>
            </tr>
            <tr id="rowAdd">
                <td colspan="4" style="height: 23px; text-align: center;">
                    <%--<input id="btnAdd" style="width: 68px; height: 26px" type="button" value="ADD" onclick="return btnAdd_onclick()" /></td>--%>
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClientClick="return btnAdd_onclick()" Height="27px" Width="150px" /></td>
            </tr>

            <tr id="rowDel">
                <td colspan="4" style="height: 19px">
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Height="360px" BorderWidth="2px" ScrollBars="Auto" Width="100%" Wrap="False">
                    </asp:Panel>
                </td>
            </tr>

            <tr id="rowPan">
                <td colspan="4" style="height: 19px">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="360px" BorderWidth="2px" ScrollBars="Auto" Width="100%" Wrap="False">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="pu">
                <td style="height: 28px; width: 194px; text-align: center">REMARKS</td>
                <td style="height: 28px; width: 194px; text-align: center">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="180%" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return onclickconf()" Height="27px" Width="150px" />
                    <%--<asp:Button ID="Button2" runat="server" Text="CONFIRM" OnClientClick="return onclickconf()" Height="27px" />
        <input id="Button2" type="button" value="EXIT" style="width: 88px; height: 27px" onclick="return Button2_onclick()" /></td>--%>
<%--                    <asp:Button ID="Button2" runat="server" Text="EXIT" Height="27px" Width="150px" />--%>

                    <Button ID="Button2" type="button"  style="Width:150px;" OnClick="Button2_Click()" >EXIT</button>


                </td>
            </tr>

            <tr>
                <td style="width: 12%"></td>
                <td style="width: 11%"></td>
                <td style="width: 7%"></td>
                <td style="width: 15%"></td>
            </tr>
        </table>
    </div>
    <%--<div style="text-align: center">
    <table border="1" style="width: 60%">
        
    </table>
        </div>--%>


    <script language="javascript" type="text/javascript">
        // <!CDATA[
        debugger;
        var con = header.split('txt');

        function Button2_Click() {
            window.open("../home.aspx", '_self')
        }

        function window_onload() {
            debugger;
            document.getElementById(con[0] + "ddlDed").style.display = 'none';
            document.getElementById(con[0] + "ddlDel").style.display = 'none';
            document.getElementById(con[0] + "lblText").innerHTML = "Select Additions";
            document.getElementById("rowPan").style.display = 'none';
            document.getElementById(con[0] + "hdnAdd").value = "";
            document.getElementById("rowDel").style.display = 'none';
            document.getElementById("txtRemarks").style.display = 'inline-block'; // Ensure remarks is displayed by default
        }

        function ClickAddition() {
            debugger;
            document.getElementById(con[0] + "ddlAdd").style.display = 'inline';
            document.getElementById(con[0] + "ddlDed").style.display = 'none';
            document.getElementById(con[0] + "ddlDel").style.display = 'none';
            document.getElementById(con[0] + "lblText").innerHTML = "Select Additions";
            document.getElementById(con[0] + "ddlAdd").value = 0;
            document.getElementById(con[0] + "hdnAdd").value = "";
            showDetails();
            document.getElementById(con[0] + "txtEcode").value = "";
            document.getElementById(con[0] + "txtEname").value = "";
            document.getElementById(con[0] + "txtAmt").value = "";
            document.getElementById("rowEmp").style.display = 'table-row';
            document.getElementById("rowEmpname").style.display = 'table-row';
            document.getElementById("rowAmt").style.display = 'table-row';
            document.getElementById("rowAdd").style.display = 'table-row';
            document.getElementById("rowPan").style.display = 'table-row';
            document.getElementById("rowDel").style.display = 'none';
            /*document.getElementById("rowPan").style.display = 'none';*/

            //    document.getElementById(con[0] + "txtRemarks").style.display = 'iniline-block'; // Show remarks textbox
            document.getElementById("txtRemarks").style.display = 'iniline-block'; // Show remarks textbox

        }

        function ClickDeduction() {
            debugger;
            document.getElementById(con[0] + "ddlAdd").style.display = 'none';
            document.getElementById(con[0] + "ddlDed").style.display = 'inline';
            document.getElementById(con[0] + "ddlDel").style.display = 'none';
            document.getElementById(con[0] + "lblText").innerHTML = "Select Deductions";
            document.getElementById(con[0] + "ddlDed").value = 0;
            document.getElementById(con[0] + "hdnAdd").value = "";
            showDetails();
            document.getElementById(con[0] + "txtEcode").value = "";
            document.getElementById(con[0] + "txtEname").value = "";
            document.getElementById(con[0] + "txtAmt").value = "";
            document.getElementById("rowEmp").style.display = 'table-row';
            document.getElementById("rowEmpname").style.display = 'table-row';
            document.getElementById("rowAmt").style.display = 'table-row';
            document.getElementById("rowAdd").style.display = 'table-row';
            document.getElementById("rowPan").style.display = 'table-row';
            document.getElementById("rowDel").style.display = 'none';
            /*document.getElementById("rowPan").style.display = 'none';*/

            //    document.getElementById(con[0] + "txtRemarks").style.display = 'inline-block'; // Show remarks textbox
            document.getElementById("txtRemarks").style.display = 'iniline-block';
        }

        function ClickDeletion() {
            debugger;
            document.getElementById(con[0] + "ddlAdd").style.display = 'none';
            document.getElementById(con[0] + "ddlDed").style.display = 'none';
            document.getElementById(con[0] + "ddlDel").style.display = 'inline';
            document.getElementById(con[0] + "lblText").innerHTML = "Select Deletion Item";
            document.getElementById(con[0] + "ddlDel").value = 0;
            document.getElementById(con[0] + "hdnAdd").value = "";
            document.getElementById("rowEmp").style.display = 'none';
            document.getElementById("rowEmpname").style.display = 'none';
            document.getElementById("rowAmt").style.display = 'none';
            document.getElementById("rowAdd").style.display = 'none';
            document.getElementById("rowPan").style.display = 'none';
            document.getElementById("rowDel").style.display = 'none';

            // Hide the remarks textbox when delete is selected
            //document.getElementById(con[0] + "txtRemarks").style.display = 'none';
            document.getElementById("txtRemarks").style.display = 'none';
            document.getElementById("pu").style.display = 'none';
        }

        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
        }
        function isNumericAmt() {
            if (isNaN(document.getElementById(con[0] + "txtAmt").value)) {
                document.getElementById(con[0] + "txtAmt").value = "";
                return false;
            }
        }
        function ComboChange() {
            debugger;
            document.getElementById(con[0] + "txtEcode").value = "";
            document.getElementById(con[0] + "txtEname").value = "";
            document.getElementById(con[0] + "txtAmt").value = "";
        }
        function ComboChangeDel() {
            debugger;
            document.getElementById(con[0] + "hdnDelChange").value = document.getElementById(con[0] + "ddlDel").value;
            if (document.getElementById(con[0] + "hdnDelChange").value == 0) {
                document.getElementById(con[0] + "hdnDelData").value = "";
                document.getElementById("rowDel").style.display = 'none';
            }
            if (document.getElementById(con[0] + "hdnDelChange").value != 0) {
                callserver("2$" + document.getElementById(con[0] + "hdnDelChange").value, 2);
            }
        }
        function detailDisplay() {
            debugger;
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                document.getElementById(con[0] + "txtEname").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value != "") {
                callserver("1$" + document.getElementById(con[0] + "txtEcode").value, 1);
            }
        }
        function call_receiver(arg, context) {
            debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Select valid Employee Code");
                            document.getElementById(con[0] + "txtEcode").value = "";
                            document.getElementById(con[0] + "txtEname").value = "";
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txtEname").value = accdtl[0];
                        }
                        break;
                    }
                case 2:

                    if (document.getElementById(con[0] + "hdnDelChange").value == 0) {
                        document.getElementById("rowDel").style.display = 'none';
                        return false;

                    }
                    else {
                        document.getElementById("rowDel").style.display = 'table-row';
                        document.getElementById(con[0] + "hdnDelData").value = Data[0];
                        disp();
                    }
                    break;
            }
        }


        function disp() {
            debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(con[0] + "hdnDelChange").value == 0) {
                document.getElementById(con[0] + "Panel2").innerHTML = "";
                document.getElementById("rowDel").style.display = "none";
                return false;
            }
            st2 = document.getElementById(con[0] + "hdnDelData").value.split("!")
            ar = st2.length - 1;
            if (document.getElementById(con[0] + "hdnDelData").value != "") {
                for (k = 0; k < ar; k++) {
                    st3 = st2[k].split("*")
                    st1 = st1 + "<tr><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><input type='checkbox' id='chkm_" + k + "' name='txtm_" + k + "'></td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP CODE</b></td><td><small><b>   EMPLOYEE NAME   </b></td><td><small><b>   DELETE   </b></td></tr>"
                st1 = st + st1 + "</table>"
            }
            else {
                st1 = st + "</table>";
            }
            document.getElementById("rowDel").style.display = "table-row";
            document.getElementById(con[0] + "Panel2").innerHTML = st1;
        }
        function btnAdd_onclick() {
            debugger;
            if (document.getElementById(con[0] + "rdAdd").checked == true) {
                if (document.getElementById(con[0] + "ddlAdd").value == 0) {
                    alert('Please Select Addition Item..!!');
                    document.getElementById(con[0] + "ddlAdd").focus();
                    return false;
                }
            }
            if (document.getElementById(con[0] + "rdDeduction").checked == true) {
                if (document.getElementById(con[0] + "ddlDed").value == 0) {
                    alert('Please Select Deduction Item..!!');
                    document.getElementById(con[0] + "ddlDed").focus();
                    return false;
                }
            }
            if (document.getElementById(con[0] + "rdDelete").checked == true) {
                if (document.getElementById(con[0] + "ddlDel").value == 0) {
                    alert('Please Select Deletion Item..!!');
                    document.getElementById(con[0] + "ddlDel").focus();
                    return false;
                }
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert('Please Enter Employee ID.!!');
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEname").value == "") {
                alert('Please Enter Employee Name.!!');
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "hdnAdd").value != "") {
                document.getElementById(con[0] + "hdnCheck").value = document.getElementById(con[0] + "hdnAdd").value + "!" + document.getElementById(con[0] + "txtEcode").value + "#" + document.getElementById(con[0] + "txtEname").value + "#" + compval + "#" + document.getElementById(con[0] + "txtAmt").value;
                var data = document.getElementById(con[0] + "hdnCheck").value;
                var rows = data.split("!");
                eid = document.getElementById(con[0] + "txtEcode").value;
                for (i = 0; i <= rows.length - 2; i++) {
                    cols = rows[i].split("#");
                    if (document.getElementById(con[0] + "rdAdd").checked == true) {
                        var item = document.getElementById(con[0] + "ddlAdd").options[document.getElementById(con[0] + "ddlAdd").selectedIndex].text;

                    }
                    if (document.getElementById(con[0] + "rdDeduction").checked == true) {
                        var item = document.getElementById(con[0] + "ddlDed").options[document.getElementById(con[0] + "ddlDed").selectedIndex].text;
                    }
                    if ((cols[0] == eid) && (cols[2] == item)) {
                        alert('Already Added..!');
                        document.getElementById(con[0] + "txtEcode").value = "";
                        document.getElementById(con[0] + "txtEname").value = "";
                        return false;
                    }

                }
            }
            var compval;
            if (document.getElementById(con[0] + "rdAdd").checked == true) {
                if (document.getElementById(con[0] + "txtAmt").value == "") {
                    alert('Please Enter Amount!!');
                    document.getElementById(con[0] + "txtAmt").focus();
                    return false;
                }
                compval = document.getElementById(con[0] + "ddlAdd").options[document.getElementById(con[0] + "ddlAdd").selectedIndex].text;

            }
            if (document.getElementById(con[0] + "rdDeduction").checked == true) {
                if (document.getElementById(con[0] + "txtAmt").value == "") {
                    alert('Please Enter Amount!!');
                    document.getElementById(con[0] + "txtAmt").focus();
                    return false;
                }
                compval = document.getElementById(con[0] + "ddlDed").options[document.getElementById(con[0] + "ddlDed").selectedIndex].text;

            }
            if (document.getElementById(con[0] + "rdDelete").checked == true) {
                compval = document.getElementById(con[0] + "ddlDel").options[document.getElementById(con[0] + "ddlDel").selectedIndex].text;

            }
            document.getElementById(con[0] + "hdnAdd").value = document.getElementById(con[0] + "hdnAdd").value + "!" + document.getElementById(con[0] + "txtEcode").value + "#" + document.getElementById(con[0] + "txtEname").value + "#" + compval + "#" + document.getElementById(con[0] + "txtAmt").value;
            document.getElementById("rowPan").style.display = 'table-row';

            showDetails();
            document.getElementById(con[0] + "txtEcode").value = "";
            document.getElementById(con[0] + "txtEname").value = "";
            document.getElementById(con[0] + "txtAmt").value = "";
            return false;
        }
        function showDetails() {
            debugger;
            var tmptab;
            tmptab = "";
            tmptab = "<table align=center width=100% border=1><tr></tr>";
            tmptab = tmptab + "<tr style='background-color:Wheat'><td width=15% align=left style= 'font-size: 10pt;'>Ecode</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>ENAME</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>INS ITEM</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>AMOUNT</td>";
            tmptab = tmptab + "<td width=5% align=right style= 'font-size: 10pt;'>DELETE</td></tr>";

            var rowSplitarr = document.getElementById(con[0] + "hdnAdd").value.split("!");
            var row_bg1 = 0;
            var m, j, cnt;
            m = 0; j = 0; cnt = 0;
            for (m = 1; m < rowSplitarr.length; m++) {
                var colSplitarr;
                if (row_bg1 == 0) {
                    row_bg1 = 1;
                    tmptab += "<tr style='background-color:OldLace'>";
                }
                else {
                    row_bg1 = 0;
                    tmptab += "<tr style='background-color:Wheat'>";
                }
                colSplitarr = rowSplitarr[m].split("#");
                tmptab = tmptab + "<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[0] + "</td>";
                tmptab = tmptab + "<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>";
                tmptab = tmptab + "<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[2] + "</td>";
                tmptab = tmptab + "<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[3] + "</td>";
                tmptab = tmptab + "<td width=10% align=right style= 'font-size: 10pt;'><a href=javascript:delf(" + m + ")>Del</a></td></tr>";
            }
            if (row_bg1 == 0)
                tmptab += "<tr style='background-color:OldLace'>";
            else
                tmptab += "<tr style='background-color:Wheat'>";
            tmptab = tmptab + "</table>";
            document.getElementById(con[0] + "Panel1").innerHTML = tmptab;

        }
        function delf(m) {
            debugger;
            var j = m - 1, k
            var new_tran = ""
            var new_tran1 = ""
            var arr = document.getElementById(con[0] + "hdnAdd").value.split("!")
            for (k = 1; k <= j; k++) {
                new_tran = new_tran + "!" + arr[k]
            }
            for (k = j + 2; k < arr.length; k++) {
                new_tran = new_tran + "!" + arr[k]
            }
            document.getElementById(con[0] + "hdnAdd").value = new_tran
            showDetails();
        }

        function onclickconf()


        //if (document.getElementById(con[0] + "rdAdd").checked == true || document.getElementById(con[0] + "rdDeduction").checked == true) {
        //        // Assuming you have a hidden field or a flag to track if Add button was clicked
        //        if (document.getElementById(con[0] + "hdnAddClicked").value != "true") {
        //            alert('Please click the Add button before proceeding.');
        //            document.getElementById(con[0] + "btnAdd").focus(); 
        //            return false;
        //        }
        //    }
        {
            debugger;
            if (document.getElementById(con[0] + "rdDelete").checked == true) {
                if (document.getElementById(con[0] + "ddlDel").value == 0) {
                    alert("Please Select Deletion Item...!");
                    return false;
                }
                document.getElementById(con[0] + "hdnDelCon").value = "";
                if (document.getElementById(con[0] + "hdnDelData").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(con[0] + "hdnDelData").value.split("!")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("*")
                        var Regular = "T";
                        if (document.getElementById("chkm_" + i + "").checked == false) {
                            Regular = "F";
                        }
                        else {
                            document.getElementById(con[0] + "hdnToSendDel").value += st3[0] + "^" + Regular + "#";
                        }
                        document.getElementById(con[0] + "hdnDelCon").value += st3[0] + "^" + Regular + "#";
                    }
                }
            }
        }


    </script>

    <script>
        window.onload = window_onload;
    </script>

</asp:Content>
