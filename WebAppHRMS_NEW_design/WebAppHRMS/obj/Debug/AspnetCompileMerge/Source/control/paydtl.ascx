<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="paydtl.ascx.vb" Inherits="WebAppHRMS.paydtl" %>
<table border="1" width="100%">
<script type="text/javascript" >
    var cid_str, all_id;
    all_id = client_id;
    cid_str = all_id.split("#");
    cash = cid_str[0]
    cheque = cid_str[1]
    tfr = cid_str[2]
    total = cid_str[3]
    bank_hdn = cid_str[4]
    bank_dtl = cid_str[5]
    branch_hdn = cid_str[6]
    branch_dtl = cid_str[7]
    pnl_id = cid_str[8]
    function check_cash() {

        if (valid(cash) == true) {
            show_total(cash, cheque, tfr, total)
        }
    }
    function show_total() {

        var sum
        sum = 0
        if (!(isNaN(document.getElementById(cash).value)) && !(document.getElementById(cash).value == "")) {
            sum = sum + parseFloat(document.getElementById(cash).value)

        }
        if (!(isNaN(document.getElementById(cheque).value)) && !(document.getElementById(cheque).value == "")) {
            var bnk_bank = document.getElementById(bank_dtl).value.split("!")
            if (bnk_bank[1] == "") {
                document.getElementById(cash).value = ""
                document.getElementById(cheque).value = ""
                document.getElementById(tfr).value = ""
                document.getElementById(total).value = ""
                alert("BANK NAME NOT ENTERED")
                return
            }
            if (bnk_bank[2] == "") {
                document.getElementById(cash).value = ""
                document.getElementById(cheque).value = ""
                document.getElementById(tfr).value = ""
                document.getElementById(total).value = ""
                alert("CHEQUE NO NOT ENTERED")
                return
            }
            if (bnk_bank[0] == 0 || isNaN(bnk_bank[0])) {
                document.getElementById(cash).value = ""
                document.getElementById(cheque).value = ""
                document.getElementById(tfr).value = ""
                document.getElementById(total).value = ""
                document.getElementById(bank_dtl).value = ""
                document.getElementById(branch_dtl).value = ""
                alert("BANK ACCOUNT IS NOT SELECTED")
                return

            }
            //      document.getElementById(bank_dtl).value=document.getElementById("cmb_bank").value+"!"+document.getElementById("txt_bankname").value+"!"+document.getElementById("txt_cheqno").value+"!"+document.getElementById("dt_cmb_day").value+"/"+document.getElementById("dt_cmb_month").value+"/"+document.getElementById("dt_cmb_year").value
            sum = sum + parseFloat(document.getElementById(cheque).value)
        }
        if (!(isNaN(document.getElementById(tfr).value)) && !(document.getElementById(tfr).value == "")) {
            if (document.getElementById(branch_dtl).value.indexOf("~") == -1) {
                document.getElementById(cash).value = ""
                document.getElementById(cheque).value = ""
                document.getElementById(tfr).value = ""
                document.getElementById(total).value = ""
                document.getElementById(bank_dtl).value = ""
                document.getElementById(branch_dtl).value = ""

                alert("BRANCH ACCOUNT IS NOT SELECTED")
                return
            }
            sum = sum + parseFloat(document.getElementById(tfr).value)
        }
        document.getElementById(total).value = (sum)
    }

    function get_bank_name() {
        if (valid(cheque) == true) {
            var bank_str
            bank_str = "<table border =1><tr><td colspan=4 align=center>BANK DETAILS</td></tr>"
            bank_str = bank_str + "<td> Account</td>"
            bank_str = bank_str + "<td><select name=cmb_bank id=cmb_bank >"
            var banks
            var ind_bank
            banks = document.getElementById(bank_hdn).value.split("^")
            var i
            for (i = 0; i < banks.length - 1; i++) {
                ind_bank = banks[i].split("@")
                bank_str = bank_str + "<option value="
                bank_str = bank_str + ind_bank[0]
                bank_str = bank_str + ">"
                bank_str = bank_str + ind_bank[1]
                bank_str = bank_str + "</option>"
            }
            bank_str = bank_str + "</select>"
            bank_str = bank_str + "</td>"
            bank_str = bank_str + "<td> Bank Name</td><td><input type=text name=txt_bankname id=txt_bankname maxlength=20></td></tr>"
            bank_str = bank_str + "<tr><td>Cheque No</td>"
            bank_str = bank_str + "<td><input type=text name=txt_cheqno id=txt_cheqno maxlength=8 /></td>"
            bank_str = bank_str + "<td> Cheq date</td>"
            bank_str = bank_str + "<td>"
            bank_str = bank_str + "<DIV id=lbl_cheque_dt name=lbl_cheque_dt></DIV>"
            bank_str = bank_str + "</td></tr>"
            bank_str = bank_str + "<tr><td colspan=4 align=center><INPUT id=cmd_bank_ok type=button onclick=add_bank() value=Continue></td></tr>"
            bank_str = bank_str + "</table>"
            document.getElementById(pnl_id).innerHTML = bank_str
            show_date("lbl_cheque_dt", 1)
        }
    }

    function add_bank() {
        document.getElementById(bank_dtl).value = document.getElementById("cmb_bank").value + "!" + document.getElementById("txt_bankname").value + "!" + document.getElementById("txt_cheqno").value + "!" + document.getElementById("dt_cmb_day").value + "/" + document.getElementById("dt_cmb_month").value + "/" + document.getElementById("dt_cmb_year").value
        show_total()
        document.getElementById(pnl_id).innerHTML = ""
    }


    function add_branch() {
        document.getElementById(branch_dtl).value = document.getElementById("cmb_branch").value
        show_total(cash, cheque, tfr, total)
        document.getElementById(pnl_id).innerHTML = ""
    }

    function proceed() {
        return false
    }

    function get_sub_name() {
        if (a_pay_type == 1) {

        }
        else {
            if (valid(tfr) == true)
                var branch_str
            branch_str = branch_str + "<table border =1><tr><td colspan=2 align=center>BRANCH DETAILS</td></tr>"
            branch_str = branch_str + "<td> Account </td>"
            branch_str = branch_str + "<td><select name=cmb_branch id=cmb_branch >"
            var bran_ch
            bran_ch = document.getElementById(branch_hdn).value.split("^")
            var ind_branch
            var i
            for (i = 0; i < bran_ch.length - 1; i++) {
                ind_branch = bran_ch[i].split("@")
                branch_str = branch_str + "<option value="
                branch_str = branch_str + ind_branch[0]
                branch_str = branch_str + ">"
                branch_str = branch_str + ind_branch[1]
                branch_str = branch_str + "</option>"
            }
            branch_str = branch_str + "</select>"
            branch_str = branch_str + "</td></tr>"
            branch_str = branch_str + "<tr><td colspan=2 align=center><INPUT id=cmd_branch_ok type=button onclick=add_branch() value=Continue></td></tr>"
            branch_str = branch_str + "</table>"
            document.getElementById(pnl_id).innerHTML = branch_str
        }
    }
    function valid(a) {
        var v
        v = document.getElementById(a).value
        if (isNaN(v)) {
            document.getElementById(a).value = ""
            document.getElementById(a).focus()
        }
        else
            return true
    }


    function show_date(ctl_name, no_of_years) {
        var date_str
        date_str = "<TABLE id=dt_table style=WIDTH: 136px; HEIGHT: 30px cellSpacing=0 cellPadding=0 width=136 	align=left border=0>"
        date_str = date_str + "<TR>"
        date_str = date_str + "<TD style=WIDTH: 44px><SELECT id=dt_cmb_day style=WIDTH: 48px>"
        var i
        for (i = 1; i <= 31; i = i + 1) {
            date_str = date_str + "<option value=" + i + ">"
            date_str = date_str + i + "</option>"
        }
        date_str = date_str + "</SELECT></TD>"
        date_str = date_str + "<TD style=WIDTH: 49px><SELECT id=dt_cmb_month style=WIDTH: 56px>"
        date_str = date_str + "<option value=JAN>JAN</option>"
        date_str = date_str + "<option value=FEB>FEB</option>"
        date_str = date_str + "<option value=MAR>MAR</option>"
        date_str = date_str + "<option value=APR>APR</option>"
        date_str = date_str + "<option value=MAY>MAY</option>"
        date_str = date_str + "<option value=JUN>JUN</option>"
        date_str = date_str + "<option value=JUL>JUL</option>"
        date_str = date_str + "<option value=AUG>AUG</option>"
        date_str = date_str + "<option value=SEP>SEP</option>"
        date_str = date_str + "<option value=OCT>OCT</option>"
        date_str = date_str + "<option value=NOV>NOV</option>"
        date_str = date_str + "<option value=DEC>DEC</option>"
        date_str = date_str + "</SELECT></TD>"
        date_str = date_str + "<TD><SELECT id=dt_cmb_year style=WIDTH: 57px>"
        var r_date = new Date();
        var curr_year = r_date.getFullYear()
        for (i = curr_year - no_of_years; i <= curr_year + no_of_years; i = i + 1) {
            date_str = date_str + "<option value=" + i + ">"
            date_str = date_str + i + "</option>"
        }
        date_str = date_str + "</SELECT></TD>"
        date_str = date_str + "</TR>"
        date_str = date_str + "</TABLE>"
        document.getElementById(ctl_name).innerHTML = date_str
        document.getElementById("dt_cmb_day").selectedIndex = curr_day - 1
        document.getElementById("dt_cmb_month").selectedIndex = curr_month - 1
        document.getElementById("dt_cmb_year").selectedIndex = no_of_years

    }
    
    function txt_onkeyup1() {
        if (isNumberKey(event) == false) {
            document.getElementById(cash).value = ""
            document.getElementById(cash).focus()
        }
    }

    function txt_onkeyup2() {
        if (isNumberKey(event) == false) {
            document.getElementById(cheque).value = ""
            document.getElementById(cheque).focus()
        }
    }

    function txt_onkeyup3() {
        if (isNumberKey(event) == false) {
            document.getElementById(tfr).value = ""
            document.getElementById(tfr).focus()
        }
    }
    function isNumberKey(event) {
        //alert(event.keyCode)
        var charcode = (event.which) ? event.which : event.keyCode
        if ((charcode > 95 && charcode < 106) || (charcode == 110) || (charcode >= 46 && charcode <= 57) || (charcode == 8) || (charcode >= 37 && charcode <= 40) || (charcode == 144))
            return true;
        else
            return false;

    }


    //-->
</script>
	
    <tr>
        <td colspan="4">
        </td>
    </tr>
    <tr>
        <td >
            Cash</td>
        <td >
            Cheque</td>
        <td   runat="server" id="tfr_td">
            Transfer</td>
        <td >
            Total</td>
    </tr>
    <tr>
        <td >
            <asp:TextBox ID="txt_cash" onkeyup="txt_onkeyup1()" runat="server" MaxLength="10"></asp:TextBox></td>
        <td >
            <asp:TextBox ID="txt_cheque" onkeyup="txt_onkeyup2()" runat="server" MaxLength="10"></asp:TextBox></td>
        <td >
            <asp:TextBox ID="txt_tfr" onkeyup="txt_onkeyup3()" runat="server" MaxLength="10" ></asp:TextBox></td>
        <td >
            <input id="txt_total" runat="server" readonly="readonly" type="text" maxlength="1000" /></td>
    </tr>
    <tr>
        <td align="center" colspan="4" >
            <asp:Panel ID="pnl_bank" runat="server" Height="90%" Width="100%">
            </asp:Panel>
        <input id="hdn_branchdtl" runat="server" style="width: 96px" type="hidden" />
            <input id="hdn_branch" runat="server" style="width: 76px" type="hidden" />
                <input id="hdn_bank" runat="server" style="width: 55px" type="hidden" />
                <input id="hdn_bankdtl" runat="server" style="width: 125px" type="hidden" /></td>
    </tr>
</table>
