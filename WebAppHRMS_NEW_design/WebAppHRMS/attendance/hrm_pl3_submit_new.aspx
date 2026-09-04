<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_pl3_submit_new.aspx.vb" Inherits="WebAppHRMS.pl3_pl3_submit_new_58b07fd58752" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        return window_onload()
        // ]]>
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = master_no.split("hid")

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }
        function textupper(name) {
            document.getElementById(cont[0] + name).value = document.getElementById(cont[0] + name).value.toUpperCase();
            return true;
        }
        function disp() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont[0] + "Hidden1").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById(cont[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cont[0] + "Hidden1").value.split("!");
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "Hidden1").value != "")
                document.getElementById("hid_Counter").value = 0


            {
                for (i = 0; i < ar; i++) {
                    document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                    var coun = document.getElementById("hid_Counter").value;
                    st3 = st2[i].split("*");                                                                                                                                                                                        //onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL" onclick=chek('chk_"+i+"')<a href=javascript:chkk('" + i + "')>
                    st1 = st1 + "<tr  bgcolor='MistyRose'><td><small>" + coun + "</td><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[3] + "</td><td>'<select name='cmb_" + i + "' id=cmb_" + i + "'>+'<option value=0>NOT INFORMED</option><option value=1>INFORMED</option> <option value=2>APPROVED</option><option value=3>SHIFT</option></select>'</small></td><td><input type='textbox' id='txt_" + i + "' name='txt_" + i + "' style='text-transform:capitalize' maxlength='100'></td></tr>"
                }
                st = st + "<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>SLNO</b></td><td><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;DEP&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>STATUS</b></td><td><b>REASON</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "inline";
            }
            document.getElementById(cont[0] + "Panel1").innerHTML = st1;
        }
        function window_onload() {
            if (document.getElementById(cont[0] + "Hidden3").value != "") {

                document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "Hidden3").value;
                disp();
            }
            else { alert("No Details!!!"); window.open('../home.aspx', '_self'); return false; }
        }

        function onclickconfirm() {
            //debugger;
            var Flag = confirm("Are You Sure to Confirm");
            if (Flag == true) {
                document.getElementById(cont[0] + "Hidden4").value = "";

                if (document.getElementById(cont[0] + "Hidden1").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(cont[0] + "Hidden1").value.split("!")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("*")
                        //       if (document.getElementById("txt_"+i+"").value =="")  Remarks= "NIL";
                        if (document.getElementById("txt_" + i + "").value == "") { alert("Please Enter Reason "); document.getElementById("txt_" + i + "").focus(); return false; }
                        else { Remarks = document.getElementById("txt_" + i + "").value; }
                        Status = document.getElementById("cmb_" + i + "").value;
                        document.getElementById(cont[0] + "Hidden4").value += st3[0] + "^" + st3[1] + "^" + Status + "^" + Remarks + "$";
                    }
                }
                var Dataa = document.getElementById(cont[0] + "Hidden4").value;
                var UserID = document.getElementById(cont[0] + "hid_s").value;
                var BrID = document.getElementById(cont[0] + "hid_br").value;
                data = Dataa + "%" + UserID + "%" + BrID + "%" + 111;
                ToServer(data + "#" + 1, 1);
            }
            if (Flag == false) {
                return false;
            }
        }


        function FromServer(arg, context) {
            //debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:
                    alert(arg);
                    window.open('../home.aspx', '_self');
                    break;
            }
        }
        // ]]>
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="Hidden3" runat="server" />
        <input id="hid_s" runat="server" type="hidden" />
        <input id="hid_Counter" type="hidden" />
        <asp:HiddenField ID="Hidden1" runat="server" EnableViewState="False" />
        <asp:HiddenField ID="Hidden4" runat="server" />
        <asp:HiddenField ID="hid_br" runat="server" />
        <table border="1" style="width: 66%; height: 112px;">
            <tr id="panel_row">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="Button1" onclick="onclickconfirm()" type="button" value="Confirm" />&nbsp;
                    <input id="btn_Exit" type="button" value="Exit" onclick="return Button1_onclick()" style="width: 64px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

