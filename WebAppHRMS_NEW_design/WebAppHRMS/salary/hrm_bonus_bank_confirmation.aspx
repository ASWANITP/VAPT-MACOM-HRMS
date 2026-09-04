<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_bonus_bank_confirmation.aspx.vb" Inherits="WebAppHRMS.salary_hrm_salary_confirmation_77201fe81537" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        var cont = cont_name.split("cmb");

        function showrow() {
            hid3.value = document.getElementById("cmb_dept").value;
            callServer(hid3.value);
        }
        function FillEmployDetails() {
            //debugger;
            data = document.getElementById(cont[0] + "cmb_dept").value;
            document.getElementById(cont[0] + "hid_dep").value = document.getElementById(cont[0] + "cmb_dept").value;
            data = data + "%" + 111;
            ToServer(data + "#" + 1, 1);

        }

        //function call_receiver(arg,context) 
        //{ 
        //    disp();
        //}    
        function FromServer(arg, context) {
            //debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:
                    //         Data1=Data[1].split("~")
                    //         arg1=Data1[0].split("!")
                    //         document.getElementById(cont[0]+"hid_code").value=arg1[5];   

                    {
                        document.getElementById(cont[0] + "Hidden1").value = Data[0];
                        disp();
                    }
                    break;
                case 2:
                    alert(arg);
                    window.open('hrm_bonus_bank_confirmation.aspx', '_self');
                    break;
            }
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
            st2 = document.getElementById(cont[0] + "Hidden1").value.split("~");
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "Hidden1").value != "")
                document.getElementById("hid_Counter").value = 0


            {
                for (i = 0; i < ar; i++) {
                    document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                    var coun = document.getElementById("hid_Counter").value;
                    st3 = st2[i].split("!");                                                                                                                                                                                        //onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL" onclick=chek('chk_"+i+"')<a href=javascript:chkk('" + i + "')>
                    st1 = st1 + "<tr  bgcolor='MistyRose'><td><small>" + coun + "</td><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[5] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><input type='checkbox' id='chkm_" + i + "' name='txtm_" + i + "'></td></tr>"
                }
                st = st + "<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>SLNO</b></td><td><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;OLD&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;ACC&nbsp;NO&nbsp;&nbsp;</b></td><td><b>&nbsp;BONUS&nbsp;/EXGRATIA&nbsp;</b></td><td><b>&nbsp;REMARKS&nbsp;&nbsp;</b></td><td><b>&nbsp;CHECK&nbsp;ALL&nbsp;<input type=checkbox onclick=checkallfunction() id=chkall name=txt_all /></b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "inline";
            }
            document.getElementById(cont[0] + "Panel1").innerHTML = st1;
        }



        function checkallfunction() {
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                var st3 = "";
                st2 = document.getElementById(cont[0] + "Hidden1").value.split("~")
                ar = st2.length
                for (ii = 0; ii < ar - 1; ii++) {
                    st3 = st2[ii].split("!")
                    document.getElementById("chkm_" + ii + "").checked = true;
                }
            }
            if (document.getElementById("txt_all").checked == false) {
                var st3 = "";
                st2 = document.getElementById(cont[0] + "Hidden1").value.split("~")
                ar = st2.length
                for (ii = 0; ii < ar - 1; ii++) {
                    st3 = st2[ii].split("!")
                    document.getElementById("chkm_" + ii + "").checked = false;
                }
            }
        }

        function onclickconfirm() {
            debugger;
            var Flag = confirm("Are You Sure to Confirm");
            if (Flag == true) {
                document.getElementById(cont[0] + "Hidden4").value = "";

                if (document.getElementById(cont[0] + "Hidden1").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(cont[0] + "Hidden1").value.split("~")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("!")
                        var Verify = 1;
                        if (document.getElementById("chkm_" + i + "").checked == false) Verify = 0;
                        if (document.getElementById("chkm_" + i + "").checked == true && st3[2] == "") { alert("If no Acc/No, can not verify that employee...!!!"); document.getElementById("chkm_" + i + "").focus(); return false; }
                        //document.getElementById(cont[0]+"Hidden4").value += st3[0] + "^" +st3[1] + "^" +st3[5]+ "^" +st3[2] + "^" +st3[3] + "^" +st3[4]+ "^" +Verify +"$" ; 
                        document.getElementById(cont[0] + "Hidden4").value += st3[0] + "^" + st3[1] + "^" + st3[2] + "^" + st3[3] + "^" + Verify + "$";

                    }
                }
                var SalData = document.getElementById(cont[0] + "Hidden4").value;
                var CODE = document.getElementById(cont[0] + "hid_dep").value;
                data = SalData + "%" + CODE + "%" + 112;
                ToServer(data + "#" + 2, 2);
            }
            if (Flag == false) {
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <input id="hid_Counter" type="hidden" /><br />
        <input id="hid3" runat="server" style="width: 25px" type="hidden" />
        <table style="width: 470px" border="1">
            <tr>
                <td colspan="2">
                    <strong><span style="color: #ff0099; text-decoration: underline">HRM SD CONFIRMATION</span></strong></td>
            </tr>
            <tr>
                <td style="width: 215px">Select Department :</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="cmb_dept" onchange="return FillEmployDetails()" onclick="return FillEmployDetails()" runat="server" Width="256px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="msg_row">
                <td colspan="2" style="height: 43px; text-align: right">
                    <asp:Label ID="Label1" runat="server" Width="472px"></asp:Label></td>
            </tr>
            <tr id="panel_row" style="display: none;">
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">&nbsp;<input id="cmd_confirm" onclick="onclickconfirm()" style="width: 87px" type="button" value="CONFIRM" />
                    <input id="cmd_exit" style="width: 84px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
        <br />
        <input id="Hidden1" runat="server" type="hidden" />
        <input id="Hidden4" runat="server" type="hidden" />
        <input id="hid_dep" runat="server" type="hidden" />
    </div>
</asp:Content>

