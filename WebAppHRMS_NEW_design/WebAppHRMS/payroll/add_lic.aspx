<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="add_lic.aspx.vb" Inherits="WebAppHRMS.leave_add_lic_4c5ff0d22338" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function btn_exit_onclick() {
            window.open('../Home.aspx', '_self');
        }
        var cont = loanno.split('txt');
        function emp_data_fill() {
            if (document.getElementById(cont[0] + "txt_emp_code").value != "") {
                call_server("1$" + document.getElementById(cont[0] + "txt_emp_code").value)
            }
        }
        function call_receiver(arg1) {
            var arg2;
            arg2 = arg1.split("@");
            if (arg2[0] == 11) {
                if (arg2[1] == 5) {
                    alert("Already Added");
                    document.getElementById(cont[0] + "txt_emp_name").value = "";
                    document.getElementById(cont[0] + "txt_lic_amt").value = "";
                }
                else {
                    if (arg2[1] == 4) {
                        alert("Invalid Employee Code");
                        document.getElementById(cont[0] + "txt_emp_name").value = "";
                        document.getElementById(cont[0] + "txt_lic_amt").value = "";
                    }
                    else {
                        document.getElementById(cont[0] + "txt_emp_name").value = arg2[1];
                    }
                }
            }
        }
        function correct1(a, e) {
            var v
            v = document.getElementById(cont[0] + a).value
            var iKeyCode = 0;
            iKeyCode = window.event.keyCode;
            if (isNaN(v) || iKeyCode == 32) {
                document.getElementById(cont[0] + a).value = ""
                document.getElementById(cont[0] + a).focus()
                return false;
            }

        }
        function correct(a, e) {
            document.getElementById(cont[0] + "txt_lic_amt").value = "";
            document.getElementById(cont[0] + "txt_emp_name").value = "";
            document.getElementById(cont[0] + "txt_remark").value = "";
            var v
            v = document.getElementById(cont[0] + a).value
            var iKeyCode = 0;
            iKeyCode = window.event.keyCode;
            if (isNaN(v) || iKeyCode == 32) {
                document.getElementById(cont[0] + a).value = "";
                document.getElementById(cont[0] + a).focus();
                return false;
            }

        }
        function chk_fill() {
            if (document.getElementById(cont[0] + "txt_emp_name").value == "") {
                alert("Enter Employee Code");
                return false;
            }

            if (document.getElementById(cont[0] + "txt_lic_amt").value == "") {
                alert("Enter LIC Amount");
                return false;
            }
            if (document.getElementById(cont[0] + "txt_remark").value == "") {
                alert("Enter Remarks");
                return false;
            }

        }
        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 368px">
            <tr>
                <td colspan="2" style="height: 25px">
                    <span style="font-size: 14pt; font-family: 'Courier New'">ADD LIC</span></td>
            </tr>
            <tr>
                <td style="width: 226px; height: 28px">
                    <span style="font-family: Courier New">Employee Code</span></td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_emp_code" runat="server" Style="font-family: 'Courier New'" MaxLength="5" onblur="return emp_data_fill()" onkeyup="correct('txt_emp_code',event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 226px; height: 28px">
                    <span style="font-family: Courier New">Employee Name</span></td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_emp_name" runat="server" ReadOnly="True" Style="font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 226px; height: 28px">
                    <span style="font-family: Courier New">Lic Amount</span></td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_lic_amt" runat="server" Style="font-family: 'Courier New'" MaxLength="5" onkeyup="correct1('txt_lic_amt',event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 226px; height: 28px">
                    <span style="font-family: Courier New">Remarks</span></td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_remark" runat="server" MaxLength="30" Style="font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 226px; height: 28px; text-align: right">
                    <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClientClick="return chk_fill()" Style="font-family: 'Courier New'" /></td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <input id="btn_exit" style="width: 70px; font-family: 'Courier New';" type="button" value="EXIT" onclick="return btn_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

