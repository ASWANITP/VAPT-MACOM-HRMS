<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Sec_punch.aspx.vb" Inherits="WebAppHRMS.attendance_punch1_6bd9f8f13625" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <script type="text/javascript">
            var cont = cont_name.split("txt")
            function empno_check() {
                if (document.getElementById(cont[0] + "txt_empcd").value == "") {
                    alert("Please Enter Your Employee Code")
                    document.getElementById(cont[0] + "txt_empcd").focus()
                }
                else {
                    emp_pnch(1 + "*" + document.getElementById(cont[0] + "txt_empcd").value + "*" + document.getElementById(cont[0] + "txt_pswd").value, 1)
                }
            }
            function rec_result(arg1, arg2) {
                if (arg1.length == 0) {
                    alert("You are Not A Registred Employee")
                    document.getElementById(cont[0] + "txt_empcd").value = ""
                    document.getElementById(cont[0] + "txt_pswd").value = ""
                    document.getElementById(cont[0] + "txt_ename").value = ""
                    document.getElementById(cont[0] + "txt_shift").value = ""

                    document.getElementById(cont[0] + "txt_empcd").focus()
                    return false
                }
                else {
                    ar1 = arg1.split("!")
                    document.getElementById(cont[0] + "txt_ename").value = ar1[3]
                    document.getElementById(cont[0] + "txt_shift").value = ar1[4]
                    var system_date = new Date
                    var system_time
                    system_time = system_date.toTimeString().substr(0, 8)
                    //alert(system_time)
                    var flag = 0
                    //alert(ar1[15])
                    //        if(system_time<ar1[15])
                    //        {
                    //            alert ("You Can Punch After "+ar1[15])
                    //            document.getElementById(cont[0]+"txt_empcd").value=""
                    //            document.getElementById(cont[0]+"txt_pswd").value=""
                    //            document.getElementById(cont[0]+"txt_ename").value=""
                    //            document.getElementById(cont[0]+"txt_shift").value=""
                    //            document.getElementById(cont[0]+"txt_empcd").focus()
                    //            return false
                    //        }
                    //        if(system_time>ar1[9])
                    //        {
                    //        //alert(ar1[13])
                    //            if (ar1[13]!="")
                    //            {
                    //	            document.getElementById(cont[0]+"lbl_err").innerText ="More than 1 Attempt Ur Attendence will be Erased"
                    //	            document.getElementById(cont[0]+"txt_ename").value=""
                    //	            document.getElementById(cont[0]+"txt_shift").value=""
                    //	            document.getElementById(cont[0]+"txt_empcd").value=""
                    //	            document.getElementById(cont[0]+"txt_pswd").value=""
                    //	            document.getElementById(cont[0]+"txt_empcd").focus()
                    //	            flag=1
                    //	            return false
                    //            }
                    //        }
                    //alert (ar1[7])
                    //        if(system_time<ar1[7])
                    //        {
                    //	        if (ar1[12]!="")
                    //	        {
                    //		        document.getElementById(cont[0]+"lbl_err").innerText ="More than 1 Attempt Ur Attendence will be Erased"
                    //		        document.getElementById(cont[0]+"txt_ename").value=""
                    //		        document.getElementById(cont[0]+"txt_shift").value=""
                    //		        document.getElementById(cont[0]+"txt_empcd").value=""
                    //		        document.getElementById(cont[0]+"txt_pswd").value=""
                    //		        document.getElementById(cont[0]+"txt_empcd").focus()
                    //		        flag=1
                    //		        return false
                    //	        }
                    //        }
                    if (flag != 1) {
                        var m_in_time = ar1[5]
                        var m_ncry_time = ar1[6]
                        var m_cry_time = ar1[7]
                        var e_early_time = ar1[8]
                        var e_out_time = ar1[9]
                        var e_over_time = ar1[10]
                        document.getElementById(cont[0] + "lbl_err").innerText = ""
                        if (system_time <= '10:00:00') {
                            document.getElementById(cont[0] + "lbl_err").innerText = "You can Punch"
                        }
                        else {
                            document.getElementById(cont[0] + "lbl_err").innerText = "BYE BYE SEE U"
                        }
                        //	        if (system_time<=m_in_time)
                        //	        {
                        document.getElementById(cont[0] + "hdn_pun").value = system_time
                        //		        document.getElementById(cont[0]+"lbl_err").innerText ="You can Punch"
                        //        //		document.getElementById(cont[0]+"txt_pswd").value=""
                        //	        } 
                        //	        if (system_time>m_in_time && system_time<=m_cry_time)
                        //	        {
                        //		        document.getElementById(cont[0]+"hdn_pun").value=system_time 
                        //		        document.getElementById(cont[0]+"lbl_err").innerText="For Every 3 late U have 1 Leave"
                        //	        }
                        //	        if (system_time>m_cry_time && system_time<e_early_time)
                        //	        {
                        //		        alert ("Time is over, U can Not Punch")
                        //		        document.getElementById(cont[0]+"txt_empcd").value=""
                        //		        document.getElementById(cont[0]+"txt_ename").value=""
                        //		        document.getElementById(cont[0]+"txt_shift").value=""
                        //		        document.getElementById(cont[0]+"hdn_pun").value=""
                        //		        document.getElementById(cont[0]+"txt_pswd").value=""
                        //		        document.getElementById(cont[0]+"txt_empcd").focus
                        //	        }
                        //	        if (system_time>=e_early_time && system_time<e_out_time)
                        //	        {
                        //		        document.getElementById(cont[0]+"hdn_pun").value=system_time
                        //		        document.getElementById(cont[0]+"lbl_err").innerText="For Every 3 Early Going late U have 1 Leave"
                        //	        } 
                        //	        if (system_time>=e_out_time && system_time<=e_over_time)
                        //	        {
                        //		        document.getElementById(cont[0]+"hdn_pun").value=system_time
                        //		        document.getElementById(cont[0]+"lbl_err").innerText="BYE BYE SEE U"
                        //	        } 
                        //	        if (system_time>e_over_time)
                        //	        {
                        //		        alert ("Time Over")
                        //		        document.getElementById(cont[0]+"cmd_ok").focus()
                        //		        document.getElementById(cont[0]+"txt_empcd").value=""
                        //		        document.getElementById(cont[0]+"txt_ename").value=""
                        //		        document.getElementById(cont[0]+"txt_shift").value=""
                        //		        document.getElementById(cont[0]+"hdn_pun").value=""
                        //		        document.getElementById(cont[0]+"txt_pswd").value=""
                        //	        }
                        document.getElementById(cont[0] + "cmd_ok").focus()
                        document.getElementById(cont[0] + "hdn_pun").value = document.getElementById(cont[0] + "hdn_pun").value + "!" + document.getElementById(cont[0] + "txt_empcd").value
                    }
                }
            }

            function punch_check() {
                if (document.getElementById(cont[0] + "txt_empcd").value == 0 || document.getElementById(cont[0] + "txt_empcd").value == "") {
                    alert("Please Enter The Employee Code....")
                    document.getElementById(cont[0] + "txt_empcd").focus
                    return false
                }
                else if (document.getElementById(cont[0] + "txt_pswd").value == "" || document.getElementById(cont[0] + "txt_pswd").value == 0) {
                    alert("Please Press The Tab key")
                    return false
                }
                if (document.getElementById(cont[0] + "txt_ename").value == "" && document.getElementById(cont[0] + "txt_shift").value == "") {
                    alert("Please Wait Until The Employee Name & Shift Comes....")
                    return false
                }
            }
            function gun_status() {
                if (document.getElementById(cont[0] + "chk_gun").checked == true) {
                    document.getElementById(cont[0] + "lbl_gun").innerHTML = "With Gun"
                }
                else {
                    document.getElementById(cont[0] + "lbl_gun").innerHTML = "With out Gun"
                }
            }

        </script>
        <table border="1" style="width: 576px">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_err" runat="server" Width="270px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <strong><span style="color: #990000">Attendance Marking</span></strong></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: center">&nbsp;&nbsp; Employee Code</td>
                <td style="width: 134px; text-align: center">
                    <input id="txt_empcd" runat="server" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: center; height: 28px;">&nbsp;
                    PassWord</td>
                <td style="width: 134px; text-align: left; height: 28px;">
                    <input id="txt_pswd" type="password" style="width: 149px" onblur="empno_check()" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: center">&nbsp;
                    Employee Name</td>
                <td style="width: 134px; text-align: left">
                    <input id="txt_ename" runat="server" type="text" readonly="readOnly" style="width: 265px" /></td>
            </tr>
            <tr id="sr">
                <td style="width: 109px; text-align: center;">&nbsp; Shift</td>

                <td style="width: 134px; text-align: left">
                    <input id="txt_shift" runat="server" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="text-align: center">Gun Status</td>
                <td>
                    <input id="chk_gun" runat="server" type="checkbox" onclick="gun_status()" />
                    <asp:Label ID="lbl_gun" runat="server" Width="128px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 29px">
                    <input id="hdn_pun" runat="server" style="width: 9px" type="hidden" />
                    <asp:Button ID="cmd_ok" runat="server" Text="Confirm" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

