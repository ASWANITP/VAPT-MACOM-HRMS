<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="new_compensatory_sanction.aspx.vb" Inherits="WebAppHRMS.leave_early_going_sanction_87bf77ed5407" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
<!--
    return window_onload()
    // -->
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('cmb');

        function early_goingOnchange() {
            if (document.getElementById(con[0] + "cmb_emp").value != '-1') {
                call_server("1*" + document.getElementById(con[0] + "cmb_emp").value, 1);
            }

            else {
                document.getElementById(con[0] + "txt_empcd").value = "";
                document.getElementById(con[0] + "txt_enm").value = "";
                document.getElementById(con[0] + "txt_branch").value = "";
                document.getElementById(con[0] + "txt_post").value = "";
                document.getElementById(con[0] + "txt_dt").value = "";
                document.getElementById(con[0] + "txt_app_dt").value = "";
                document.getElementById(con[0] + "txt_comp_name").value = "";
                document.getElementById(con[0] + "txt_comp_dt").value = "";
                document.getElementById(con[0] + "txt_exp_dt").value = "";
                document.getElementById(con[0] + "txt_rsn").value = "";
            }
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1://  0              1                     2                  3                    4               5                   6
                    {
                        //el.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||el.going_dt||'*'||el.going_time||'*'||el.reason 
                        // document.getElementById(con[0]+"Hidden1").value=arg;
                        if (arg == 4) {
                            document.getElementById(con[0] + "txt_empcd").value = "";
                            document.getElementById(con[0] + "txt_enm").value = "";
                            document.getElementById(con[0] + "txt_branch").value = "";
                            document.getElementById(con[0] + "txt_post").value = "";
                            document.getElementById(con[0] + "txt_dt").value = "";
                            document.getElementById(con[0] + "txt_app_dt").value = "";
                            document.getElementById(con[0] + "txt_comp_name").value = "";
                            document.getElementById(con[0] + "txt_comp_dt").value = "";
                            document.getElementById(con[0] + "txt_exp_dt").value = "";
                            document.getElementById(con[0] + "txt_rsn").value = "";
                            break;
                        }
                        else {
                            var ar = arg.split("*");
                            document.getElementById(con[0] + "txt_empcd").value = ar[0];
                            document.getElementById(con[0] + "txt_enm").value = ar[1];
                            document.getElementById(con[0] + "txt_branch").value = ar[2];
                            document.getElementById(con[0] + "txt_post").value = ar[3];
                            document.getElementById(con[0] + "txt_dt").value = ar[4];
                            document.getElementById(con[0] + "txt_app_dt").value = ar[5];
                            document.getElementById(con[0] + "txt_comp_name").value = ar[6];
                            document.getElementById(con[0] + "txt_comp_dt").value = ar[7];
                            document.getElementById(con[0] + "txt_exp_dt").value = ar[8];
                            document.getElementById(con[0] + "txt_rsn").value = ar[9];
                            break;
                        }
                    }
                case 2:
                    {
                        var arg1 = arg.split("*")
                        alert(arg1[1]);
                        if (arg1[0] == 1) {
                            window.open('compensatory_sanction.aspx', '_self');
                        }
                    }
            }
        }

        function cmd_ext_onclick() {
            window.open('../../Home.aspx', '_self')
        }

        function window_onload() {
            if (document.getElementById(con[0] + "hid_access").value == '1') {
                document.getElementById(con[0] + "cmd_san").style.display = 'inline'
                document.getElementById(con[0] + "cmd_rec").style.display = 'none'
            }
            else {
                document.getElementById(con[0] + "cmd_san").style.display = 'inline'
                document.getElementById(con[0] + "cmd_rec").style.display = 'inline'
            }
        }

        function chk_data() {
            if (document.getElementById(con[0] + "cmb_emp").value == '-1' || document.getElementById(con[0] + "cmb_emp").options.length == 0) {
                alert("Select Employee");
                return false;
            }
            if (document.getElementById(con[0] + "txt_empcd").value == "") {
                alert("Select Employee");
                return false;
            }
        }
        function chk_data1() {
            if (document.getElementById(con[0] + "cmb_emp").value == '-1' || document.getElementById(con[0] + "cmb_emp").options.length == 0) {
                alert("Select Employee");
                return false;
            }

            if (document.getElementById(con[0] + "txt_empcd").value == "") {
                alert("Select Employee");
                return false;
            }

            if ((document.getElementById(con[0] + "hid_rej").value) == "") {
                mywin = window.open("rej_res1.aspx", "WinC", "width=500,height=50,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
                mywin.moveTo(200, 300);
                return false;
            }
            else {
                arg = 2 + "*" + document.getElementById(con[0] + "cmb_emp").value + "*" + document.getElementById(con[0] + "emp_type").value + "*" + document.getElementById(con[0] + "hid_user").value + "*" + document.getElementById(con[0] + "hid_rej").value
                call_server(arg, 2);
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 685px; height: 275px">
            <tr>
                <td colspan="4" style="height: 30px">
                    <span style="font-family: Courier New">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" BackColor="WhiteSmoke" ForeColor="#C00000" Height="27px" Width="672px">COMPENSATORY RECOMMEND / SANCTION</asp:Label></span></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <asp:CheckBox ID="chk_rec" runat="server" AutoPostBack="True" Checked="True" Font-Bold="True"
                        Text="Recommend" Width="209px" ForeColor="#C00000" /></td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:CheckBox ID="chk_san" runat="server" AutoPostBack="True" Font-Bold="True" Text="Sanction"
                        Width="183px" ForeColor="#C00000" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <span style="font-family: Courier New"><strong>Select </strong></span></td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="358px" onchange="return early_goingOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;code</span></td>
                <td style="width: 141px; height: 23px">
                    <input id="txt_empcd" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;name</span></td>
                <td style="width: 72px; height: 23px; text-align: left">
                    <input id="txt_enm" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'; width: 171px;" /></td>
            </tr>
            <tr>
                <td style="width: 114px; text-align: left; height: 28px;">
                    <span style="font-family: Courier New">Branch</span></td>
                <td style="width: 141px; height: 28px;">
                    <input id="txt_branch" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; text-align: left; height: 28px;">
                    <span style="font-family: Courier New">Post</span></td>
                <td style="width: 72px; text-align: left; height: 28px;">
                    <input id="txt_post" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'; width: 171px;" /></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Leave&nbsp;Date</span></td>
                <td style="width: 141px; height: 23px; text-align: left">
                    <input id="txt_dt" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Applied&nbsp;Date</span></td>
                <td style="width: 72px; height: 23px; text-align: left">
                    <asp:TextBox ID="txt_app_dt" runat="server" Style="font-family: 'Courier New'" Width="171px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Compensatory</td>
                <td style="width: 141px; height: 23px; text-align: left">
                    <input id="txt_comp_name" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Compensatory&nbsp;Date</td>
                <td style="width: 72px; height: 23px; text-align: left">
                    <input id="txt_comp_dt" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 114px; height: 5px; text-align: left">
                    <span style="font-family: Courier New">Expiry&nbsp;Date</td>
                <td style="width: 141px; height: 5px; text-align: left">
                    <input id="txt_exp_dt" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 5px; text-align: left">
                    <span style="font-family: Courier New"></td>
                <td style="width: 72px; height: 5px; text-align: left"></td>
            </tr>
            <tr>
                <td style="width: 114px; text-align: left">
                    <span style="font-family: Courier New">Reason </span>
                </td>
                <td colspan="3" style="text-align: left">
                    <input id="txt_rsn" runat="server" style="width: 537px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="height: 23px" colspan="4">
                    <input id="emp_type" runat="server" style="width: 1px" type="hidden" />
                    <input id="Hidden1" runat="server" style="width: 7px" type="hidden" />
                    <input id="hid_user" runat="server" style="width: 5px" type="hidden" />
                    <input id="hid_rej" runat="server" style="width: 5px" type="hidden" />
                    <input id="hid_access" runat="server" style="width: 5px" type="hidden" />
                    <asp:Button ID="cmd_rec" runat="server" Text="RECOMMEND" Width="95px" OnClientClick="return chk_data()" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    <asp:Button ID="cmd_san" runat="server" Text="SANCTION" Width="95px" OnClientClick="return chk_data()" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    <asp:Button ID="cmd_rej" runat="server" Height="25px" Text="REJECT" Width="95px" OnClientClick="return chk_data1()" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    <input id="cmd_ext" style="width: 95px; height: 24px; font-family: 'Courier New'; font-weight: bold; background-color: gainsboro;" type="button" value="EXIT" onclick="return cmd_ext_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

