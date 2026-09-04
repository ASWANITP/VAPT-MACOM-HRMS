<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_Sanction_Postwise.aspx.vb" EnableEventValidation="false" Inherits="WebAppHRMS.leave_postwise_sanction_be0310eb1214" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        var cont = cont_name.split("txt")

        function emp_fill() {

            var arr, cnt, arr2;
            if (document.getElementById(cont[0] + "cmb_leave").value == 0) {

                document.getElementById(cont[0] + "txt_name").value = "";
                document.getElementById(cont[0] + "txt_dur").value = "";
                document.getElementById(cont[0] + "txt_appdt").value = "";
                document.getElementById(cont[0] + "txt_frdt").value = "";
                document.getElementById(cont[0] + "txt_todt").value = "";
                document.getElementById(cont[0] + "txt_reason").value = "";
                document.getElementById(cont[0] + "cmb_branch").value = "";
                document.getElementById(cont[0] + "cmb_post").value = "";
                document.getElementById(cont[0] + "txt_tot_mon").value = "";
                document.getElementById(cont[0] + "txt_leave_day").value = "";
                document.getElementById(cont[0] + "txt_recom_reason").value = "";
                document.getElementById(cont[0] + "txt_rec_by").value = "";

                document.getElementById(cont[0] + "txt_ReqFrDt").value = "";
                document.getElementById(cont[0] + "txt_ReqToDt").value = "";
                document.getElementById(cont[0] + "txt_ParFrDt").value = "";
                document.getElementById(cont[0] + "txt_ParToDt").value = "";
                document.getElementById(cont[0] + "txt_req_days").value = "";
                document.getElementById(cont[0] + "txt_par_days").value = "";
                document.getElementById(cont[0] + "txt_RecDate").value = "";
                document.getElementById(cont[0] + "txt_ltyp").value = "";

                document.getElementById(cont[0] + "txt_cas").value = "";
                document.getElementById(cont[0] + "txt_sik").value = "";
                document.getElementById(cont[0] + "txt_earn").value = "";
                document.getElementById(cont[0] + "txtReason").value = "";

                document.getElementById(cont[0] + "txt_cas").value = "";
                document.getElementById(cont[0] + "txt_sik").value = "";
                document.getElementById(cont[0] + "txt_earn").value = "";
                return false;

            }
            else {
                debugger;

                arr = document.getElementById(cont[0] + "cmb_leave").value.split("*")
                document.getElementById(cont[0] + "txt_name").value = arr[1]
                document.getElementById(cont[0] + "txt_dur").value = arr[5]
                document.getElementById(cont[0] + "txt_appdt").value = arr[6]
                document.getElementById(cont[0] + "txt_frdt").value = arr[3]
                document.getElementById(cont[0] + "txt_todt").value = arr[4]
                document.getElementById(cont[0] + "txt_reason").value = arr[7]
                document.getElementById(cont[0] + "cmb_branch").value = arr[8]
                document.getElementById(cont[0] + "cmb_post").value = arr[9]
                document.getElementById(cont[0] + "txt_tot_mon").value = arr[10]
                document.getElementById(cont[0] + "txt_leave_day").value = arr[11]
                document.getElementById(cont[0] + "hid_seq").value = arr[12]
                document.getElementById(cont[0] + "hid_empcode").value = arr[0]
                document.getElementById(cont[0] + "hid_rej").value = "";
                document.getElementById(cont[0] + "HiddenField1").value = arr[2];
                document.getElementById(cont[0] + "txt_cas").value = arr[19]
                document.getElementById(cont[0] + "txt_sik").value = arr[20]
                document.getElementById(cont[0] + "txt_earn").value = arr[21];


                if (arr[3] == arr[4]) {
                    document.getElementById(cont[0] + "Checkbox1").disabled = true;
                    document.getElementById("lima").style.display = 'none';
                }
                else {
                    document.getElementById(cont[0] + "Checkbox1").disabled = false;
                    document.getElementById("lima").style.display = 'inline';
                }

                if (arr[13] == "") {
                    document.getElementById("row1").style.display = "none";
                }
                else {
                    document.getElementById(cont[0] + "txt_recom_reason").value = arr[13];
                    document.getElementById("row1").style.display = "inline";

                }
                if (arr[13] != "") {
                    document.getElementById(cont[0] + "txt_rec_by").value = arr[14] + "(" + arr[15] + ")";
                    document.getElementById("row2").style.display = "inline";

                }
                else {
                    document.getElementById("row2").style.display = "none";
                }


                if (arr[9] == 28 || arr[9] == 173 || arr[9] == 136 || arr[9] == 134 || arr[9] == 141) {
                    document.getElementById(cont[0] + "txt_leave_day").value = '  ----  ';
                }
                //sreeeeeeeeeeeeeeeeeee

                if (arr[16] == "" || arr[17] == "") {

                    document.getElementById(cont[0] + "txt_ReqFrDt").value = arr[3];
                    document.getElementById(cont[0] + "txt_ReqToDt").value = arr[4];
                    document.getElementById(cont[0] + "txt_ParFrDt").value = arr[3];
                    document.getElementById(cont[0] + "txt_ParToDt").value = arr[4];

                    var value1 = arr[3];
                    var value2 = arr[4];
                    var day1, day2;
                    var month1, month2;
                    var year1, year2;
                    day1 = value1.substring(0, value1.indexOf("-"));
                    month1 = value1.substring(value1.indexOf("-") + 1, value1.lastIndexOf("-"));
                    year1 = value1.substring(value1.lastIndexOf("-") + 1, value1.length);

                    day2 = value2.substring(0, value2.indexOf("-"));
                    month2 = value2.substring(value2.indexOf("-") + 1, value2.lastIndexOf("-"));
                    year2 = value2.substring(value2.lastIndexOf("-") + 1, value2.length);

                    date1 = year1 + "/" + month1 + "/" + day1;
                    date2 = year2 + "/" + month2 + "/" + day2;

                    firstDate = Date.parse(date1)
                    secondDate = Date.parse(date2)

                    msPerDay = 24 * 60 * 60 * 1000
                    dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                    document.getElementById(cont[0] + "txt_req_days").value = dbd + 1;
                    document.getElementById(cont[0] + "txt_par_days").value = dbd + 1;
                }
                else {
                    document.getElementById(cont[0] + "txt_ReqFrDt").value = arr[16];
                    document.getElementById(cont[0] + "txt_ReqToDt").value = arr[17];
                    document.getElementById(cont[0] + "txt_ParFrDt").value = arr[3];
                    document.getElementById(cont[0] + "txt_ParToDt").value = arr[4];

                    var value1 = arr[16];
                    var value2 = arr[17];
                    var day1, day2;
                    var month1, month2;
                    var year1, year2;
                    day1 = value1.substring(0, value1.indexOf("-"));
                    month1 = value1.substring(value1.indexOf("-") + 1, value1.lastIndexOf("-"));
                    year1 = value1.substring(value1.lastIndexOf("-") + 1, value1.length);

                    day2 = value2.substring(0, value2.indexOf("-"));
                    month2 = value2.substring(value2.indexOf("-") + 1, value2.lastIndexOf("-"));
                    year2 = value2.substring(value2.lastIndexOf("-") + 1, value2.length);

                    date1 = year1 + "/" + month1 + "/" + day1;
                    date2 = year2 + "/" + month2 + "/" + day2;

                    firstDate = Date.parse(date1)
                    secondDate = Date.parse(date2)

                    msPerDay = 24 * 60 * 60 * 1000
                    dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                    document.getElementById(cont[0] + "txt_par_days").value = arr[5];
                    document.getElementById(cont[0] + "txt_req_days").value = dbd + 1;
                }
                if (arr[18] == "") {
                    var dt = new Date().format("dd-MMM-yyyy");
                    document.getElementById(cont[0] + "txt_RecDate").value = dt;
                }
                else { document.getElementById(cont[0] + "txt_RecDate").value = arr[18]; }

                //sreeeeeeeeeeeeeeeeeee  


                if (arr[2] == 1)
                    document.getElementById(cont[0] + "txt_ltyp").value = "C/L"
                else if (arr[2] == 2)
                    document.getElementById(cont[0] + "txt_ltyp").value = "S/L"
                else if (arr[2] == 3)
                    document.getElementById(cont[0] + "txt_ltyp").value = "E/L"
                else if (arr[2] == 4)
                    document.getElementById(cont[0] + "txt_ltyp").value = "LOP"
                else if (arr[2] == 10)
                    document.getElementById(cont[0] + "txt_ltyp").value = "MAT"
                else if (arr[2] == 6)
                    document.getElementById(cont[0] + "txt_ltyp").value = "L/L"
                else
                    document.getElementById(cont[0] + "txt_ltyp").value = "UNK"

                sub_call_server(4 + "$" + arr[0] + "*" + arr[12], 4);
            }
        }
        function Button3_onclick() {
            window.open("../home.aspx", '_self')
        }
        window.onload = emp_fill
        function Button1_onclick() {
            fill()
        }

        function Button2_onclick() {
            window.open("../home.aspx", '_self')
        }
        function check_null() {
            var arg;
            if (document.getElementById(cont[0] + "cmb_leave").options.length == 0) {
                alert("NO LEAVE FOR REJECTION")
                return false;
            }
            else {
                if ((document.getElementById(cont[0] + "txt_name").value) != "") {

                    //        if((document.getElementById(cont[0]+"hid_rej").value)=="")
                    //        {
                    //            mywin=window.open("rej_res_ho.aspx", "WinC", "width=650,height=120,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
                    //            mywin.moveTo(200,300);
                    //            return false;
                    //            }
                    //            else
                    //            {
                    //             arg=2+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*pp*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
                    //             sub_call_server(arg,2);
                    //             return false;
                    //            }


                    arg = 2 + "$" + document.getElementById(cont[0] + "hid_empcode").value + "*" + document.getElementById(cont[0] + "txt_name").value + "*" + document.getElementById(cont[0] + "txt_ltyp").value + "*" + document.getElementById(cont[0] + "txt_frdt").value + "*" + document.getElementById(cont[0] + "txt_todt").value + "*" + document.getElementById(cont[0] + "txt_dur").value + "*" + document.getElementById(cont[0] + "txt_appdt").value.split("-")[0] + "*" + document.getElementById(cont[0] + "txtReason").value + "*" + document.getElementById(cont[0] + "hid_seq").value + "*" + document.getElementById(cont[0] + "txtReason").value + "*pp*" + document.getElementById(cont[0] + "txt_ParFrDt").value + "*" + document.getElementById(cont[0] + "txt_ParToDt").value + "*" + document.getElementById(cont[0] + "txt_par_days").value;
                    sub_call_server(arg, 2);
                    return false;

                }
                else {
                    alert("Select Employee");
                    return false;
                }
            }
        }
        function check_null1() {
            var arg;
            if (document.getElementById(cont[0] + "cmb_leave").options.length == 0) {
                alert("NO LEAVE FOR SANCTION")
                return false;
            }
            else {
                if ((document.getElementById(cont[0] + "txt_name").value) != "") {
                    //sreeeee
                    //       if(document.getElementById(cont[0]+"Checkbox1").checked==true)
                    //       {
                    //        arg=1+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*pp*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value;
                    //       }
                    //       else
                    //       {
                    //       arg=1+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*pp*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
                    //       }
                    //sreeeee

                    arg = 1 + "$" + document.getElementById(cont[0] + "hid_empcode").value + "*" + document.getElementById(cont[0] + "txt_name").value + "*" + document.getElementById(cont[0] + "txt_ltyp").value + "*" + document.getElementById(cont[0] + "txt_frdt").value + "*" + document.getElementById(cont[0] + "txt_todt").value + "*" + document.getElementById(cont[0] + "txt_dur").value + "*" + document.getElementById(cont[0] + "txt_appdt").value.split("-")[0] + "*" + document.getElementById(cont[0] + "txtReason").value + "*" + document.getElementById(cont[0] + "hid_seq").value + "*" + document.getElementById(cont[0] + "txt_tot_mon").value + "*pp*" + document.getElementById(cont[0] + "txt_ParFrDt").value + "*" + document.getElementById(cont[0] + "txt_ParToDt").value + "*" + document.getElementById(cont[0] + "txt_par_days").value;
                    sub_call_server(arg, 1);
                    return false;
                }
                else {
                    alert("Select Employee");
                    return false;
                }
            }
        }

        function cmd_details_onclick() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_leave").value.split("*");

            if (arr[0] > 0) {
                window.open("leav_rpt.aspx?emp_code=" + arr[0]);
            }
            else {
                alert("Select Employee");
            }

        }
        function sub_call_receiver(arg1, arg2) {


            var ar;
            ar = arg1.split("#")
            if (arg2 == 1) {
                if (ar[0] == 1) {
                    if (ar[1] == 1) {
                        alert(ar[2]);
                        Button1_onclick()
                    }
                    else {
                        alert(ar[2]);
                        return false;
                    }

                }
                else if (ar[0] == 2) {
                    alert(ar[2]);
                    return false;
                }
                else {
                    alert("Error..Please Inform IT");
                    return false;
                }
            }
            else if (arg2 == 2) {
                if (ar[0] == 1) {
                    if (ar[1] == 1) {
                        alert(ar[2]);
                        Button1_onclick()

                    }
                    else {
                        alert(ar[2]);
                        return false;
                    }

                }
                else if (ar[0] == 2) {
                    alert(ar[2]);
                    return false;
                }
                else {
                    alert("Error..Please Inform IT");
                    return false;
                }
            }
            else if (arg2 == 3) {

                if (ar[0] == 1) {
                    if (ar[1] == 1) {
                        alert(ar[2]);
                        Button1_onclick()
                    }
                    else {

                        alert(ar[2]);
                        return false;
                    }

                }
                else if (ar[0] == 2) {
                    alert(ar[2]);
                    return false;
                }
                else {
                    alert("Error..Please Inform IT");
                    return false;
                }
            }
            else if (arg2 == 4) {

                if (arg1 == 0) {
                    document.getElementById(cont[0] + "cmd_support").disabled = true;
                    return false;
                }
                else {
                    document.getElementById(cont[0] + "cmd_support").disabled = false;
                    return false;
                }
            }





            else if (arg2 != 4) {
                alert("Error..Please Inform IT");
                return false;
            }
        }


        function cmb_acc_onclick() {
            if ((document.getElementById(cont[0] + "txt_name").value) == "") {
                alert("Select Employee");
                document.getElementById(cont[0] + "txt_name").focus();
                return false;
            }

            if ((document.getElementById(cont[0] + "txtReason").value) == "") {
                alert("Enter Reason")
                document.getElementById(cont[0] + "txtReason").focus();
                return false;
            }

            check_null1()
            return false;
        }

        function cmd_reject_onclick() {
            if (document.getElementById(cont[0] + "Checkbox1").checked == true) {
                alert('You cannot partially reject a leave');
                return false;
            }


            if ((document.getElementById(cont[0] + "txt_name").value) == "") {
                alert("Select Employee");
                document.getElementById(cont[0] + "txt_name").focus();
                return false;
            }

            if ((document.getElementById(cont[0] + "txtReason").value) == "") {
                alert("Enter Reason")
                document.getElementById(cont[0] + "txtReason").focus();
                return false;
            }

            check_null()
            return false;
        }

        function cmd_rec_onclick() {
            if ((document.getElementById(cont[0] + "txt_name").value) == "") {
                alert("Select Employee");
                document.getElementById(cont[0] + "txt_name").focus();
                return false;
            }

            if ((document.getElementById(cont[0] + "txtReason").value) == "") {
                alert("Enter Reason")
                document.getElementById(cont[0] + "txtReason").focus();
                return false;
            }
            check_null2()
            return true;
        }
        function check_null2() {



            var arg;
            if (document.getElementById(cont[0] + "cmb_leave").options.length == 0) {
                alert("NO LEAVE FOR RECOMMEND")
                return false;
            }
            else {
                if ((document.getElementById(cont[0] + "txt_name").value) != "") {

                    //            if((document.getElementById(cont[0]+"hid_rej").value)=="")
                    //            {
                    //               mywin=window.open("rec_res_ho.aspx", "WinC", "width=650,height=120,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
                    //               mywin.moveTo(200,300);
                    //               return false;
                    //            }
                    //            else
                    //            {
                    //            if(document.getElementById(cont[0]+"Checkbox1").checked==true)
                    //            {
                    //             arg=3+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value+"*"+(document.getElementById(cont[0]+"txt_appdt").value).split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value;
                    //            }
                    //            else
                    //            
                    //            {
                    //            arg=3+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+(document.getElementById(cont[0]+"txt_appdt").value).split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
                    //            }
                    //sreeeee

                    arg = 3 + "$" + document.getElementById(cont[0] + "hid_empcode").value + "*" + document.getElementById(cont[0] + "txt_name").value + "*" + document.getElementById(cont[0] + "txt_ltyp").value + "*" + document.getElementById(cont[0] + "txt_ParFrDt").value + "*" + document.getElementById(cont[0] + "txt_ParToDt").value + "*" + document.getElementById(cont[0] + "txt_par_days").value + "*" + (document.getElementById(cont[0] + "txt_appdt").value).split("-")[0] + "*" + document.getElementById(cont[0] + "txtReason").value + "*" + document.getElementById(cont[0] + "hid_seq").value + "*" + document.getElementById(cont[0] + "txt_tot_mon").value + "*" + document.getElementById(cont[0] + "txtReason").value + "*" + document.getElementById(cont[0] + "txt_frdt").value + "*" + document.getElementById(cont[0] + "txt_todt").value + "*" + document.getElementById(cont[0] + "txt_dur").value;
                    sub_call_server(arg, 3);
                    return false;
                    //        }  

                }
                else {
                    alert("Select Employee");
                    return false;
                }
            }
        }
        function cmd_applnform_onclick() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_leave").value.split("*")
            window.open("leave_apply_report.aspx?leave_seq=" + arr[12])
        }


        function cmd_support_onclick() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_leave").value.split("*");
            window.open('view_leave_supportings.aspx?empcode=' + arr[0] + '&leavesequence=' + arr[12] + '');
        }

        function cmd_pl28_onclick() {
            var arr
            arr = document.getElementById(cont[0] + "cmb_leave").value.split("*");
            window.open('rpt_leave_pl28.aspx?empcode=' + arr[0]);

        }

        function cmd_previous_onclick() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_leave").value.split("*");
            if (arr[0] > 0) {
                window.open("pre_leav_rpt.aspx?emp_code=" + arr[0]);
            }
            else {
                alert("Select Employee");
            }

        }

        function OnCheck() {
            if (document.getElementById(cont[0] + "Checkbox1").checked == true) {
                document.getElementById("sre").style.display = "inline";

                return true;
            }
            else {
                document.getElementById("sre").style.display = "none";

                return false;
            }
        }


        function OnCheckDate() {


            if (document.getElementById(cont[0] + "txt_ParFrDt").value < document.getElementById(cont[0] + "txt_frdt").value) {
                alert("Can not be less than requested from date...!!!");
                document.getElementById(cont[0] + "txt_ParFrDt").value = document.getElementById(cont[0] + "txt_frdt").value;
                return false;
            }
            if (document.getElementById(cont[0] + "txt_ParFrDt").value > document.getElementById(cont[0] + "txt_todt").value) {
                alert("Can not be greater than requested to date...!!!");
                document.getElementById(cont[0] + "txt_ParFrDt").value = document.getElementById(cont[0] + "txt_frdt").value;
                return false;
            }
            check_date();
        }
        function OnCheckToDate() {
            if (document.getElementById(cont[0] + "txt_ParToDt").value > document.getElementById(cont[0] + "txt_todt").value) {
                alert("Can not be greater than requested to date...!!!");
                document.getElementById(cont[0] + "txt_ParToDt").value = document.getElementById(cont[0] + "txt_todt").value;
                return false;
            }
            if (document.getElementById(cont[0] + "txt_ParToDt").value < document.getElementById(cont[0] + "txt_frdt").value) {
                alert("Can not be less than requested from date...!!!");
                document.getElementById(cont[0] + "txt_ParToDt").value = document.getElementById(cont[0] + "txt_todt").value;
                return false;
            }
            check_date();
        }
        function check_date() {
            var value1 = document.getElementById(cont[0] + "txt_ParFrDt").value;
            var value2 = document.getElementById(cont[0] + "txt_ParToDt").value;
            var day1, day2;
            var month1, month2;
            var year1, year2;
            day1 = value1.substring(0, value1.indexOf("-"));
            month1 = value1.substring(value1.indexOf("-") + 1, value1.lastIndexOf("-"));
            year1 = value1.substring(value1.lastIndexOf("-") + 1, value1.length);

            day2 = value2.substring(0, value2.indexOf("-"));
            month2 = value2.substring(value2.indexOf("-") + 1, value2.lastIndexOf("-"));
            year2 = value2.substring(value2.lastIndexOf("-") + 1, value2.length);

            date1 = year1 + "/" + month1 + "/" + day1;
            date2 = year2 + "/" + month2 + "/" + day2;

            firstDate = Date.parse(date1)
            secondDate = Date.parse(date2)

            msPerDay = 24 * 60 * 60 * 1000
            dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
            document.getElementById(cont[0] + "txt_par_days").value = dbd + 1;

        }



        function OnkeyUpChqDate1() {
            if (document.getElementById(cont[0] + "txt_ParFrDt").value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cont[0] + "txt_ParFrDt").value = document.getElementById(cont[0] + "txt_frdt").value;
            }
        }
        function OnkeyUpChqDate() {
            if (document.getElementById(cont[0] + "txt_ParToDt").value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cont[0] + "txt_ParToDt").value = document.getElementById(cont[0] + "txt_todt").value;
            }
        }


        function Button1_onclick() {
            var IntCount;
            var SeleIndex = document.getElementById(cont[0] + "cmb_leave").selectedIndex;
            for (IntCount = document.getElementById(cont[0] + "cmb_leave").options.length - 1; IntCount >= 0; IntCount--) {
                if (SeleIndex == IntCount) {
                    document.getElementById(cont[0] + "cmb_leave").remove(IntCount);
                    document.getElementById(cont[0] + "cmb_leave").selectedIndex = 0;
                    document.getElementById(cont[0] + "txt_name").value = "";
                    document.getElementById(cont[0] + "txt_dur").value = "";
                    document.getElementById(cont[0] + "txt_appdt").value = "";
                    document.getElementById(cont[0] + "txt_frdt").value = "";
                    document.getElementById(cont[0] + "txt_todt").value = "";
                    document.getElementById(cont[0] + "txt_reason").value = "";
                    document.getElementById(cont[0] + "cmb_branch").value = "";
                    document.getElementById(cont[0] + "cmb_post").value = "";
                    document.getElementById(cont[0] + "txt_tot_mon").value = "";
                    document.getElementById(cont[0] + "txt_leave_day").value = "";
                    document.getElementById(cont[0] + "txt_recom_reason").value = "";
                    document.getElementById(cont[0] + "txt_rec_by").value = "";

                    document.getElementById(cont[0] + "txt_ReqFrDt").value = "";
                    document.getElementById(cont[0] + "txt_ReqToDt").value = "";
                    document.getElementById(cont[0] + "txt_ParFrDt").value = "";
                    document.getElementById(cont[0] + "txt_ParToDt").value = "";
                    document.getElementById(cont[0] + "txt_req_days").value = "";
                    document.getElementById(cont[0] + "txt_par_days").value = "";
                    document.getElementById(cont[0] + "txt_RecDate").value = "";
                    document.getElementById(cont[0] + "txt_ltyp").value = "";
                    document.getElementById(cont[0] + "txtReason").value = "";
                    return false;
                }

            }

        }
    </script>
    <div style="text-align: center">
        <table border="1" style="width: 1px; height: 1px">
            <tr>
                <td colspan="6" style="height: 19px">
                    <asp:Label ID="Label1" runat="server" Width="574px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:RadioButton ID="rdbHo" runat="server" AutoPostBack="True" Checked="True" GroupName="rdbctgry"
                        Text="HO Staff" />
                    <asp:RadioButton ID="rdbBr" runat="server" AutoPostBack="True" GroupName="rdbctgry"
                        Text="Branch Staff" Width="115px" /></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                    <asp:RadioButton ID="rdbRec1" runat="server" AutoPostBack="True" Checked="True" GroupName="rdboptn"
                        Text="First Recommend" />&nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rdbRec" runat="server" AutoPostBack="True" Checked="True" GroupName="rdboptn"
                            Text="Second Recommend" />
                    &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rdbSanc" runat="server" AutoPostBack="True" GroupName="rdboptn"
                        Text="Sanction" Width="102px" /></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px"></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                    <asp:DropDownList ID="cmb_leave" runat="server" Width="610px" onChange="emp_fill()" Style="font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px"></td>
            </tr>


            <tr>
                <td colspan="6" style="color: #cc0000;">
                    <span style="font-size: 11pt; font-family: Courier New">(Emp.Code&nbsp; -&nbsp;Leave From date - Leave To Date -Applied Date- Name )</span></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: center">
                    <asp:Panel ID="Panel1" runat="server">
                        <table border="1" style="width: 664px; height: 1px">
                            <tr>
                                <td colspan="6" style="height: 1px; text-align: center">
                                    <strong><span style="color: #6600cc; font-family: Courier New; text-decoration: underline">Details Of Available Leave</span></strong></td>
                            </tr>
                            <tr>
                                <td style="height: 1px; text-align: center" valign="top" colspan="6">
                                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">Casual : <span style="font-size: 24pt"></span>
                                        <input id="txt_cas" style="width: 40px" type="text" runat="server" readonly="readOnly" /></span><span style="color: #0000cc"> 
                            &nbsp; &nbsp;&nbsp;&nbsp;<span style="font-size: 14pt">|</span>&nbsp;
                                        </span></span>
                                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">Sick :&nbsp;
                        <input id="txt_sik" style="width: 40px" type="text" runat="server" readonly="readOnly" />
                                        &nbsp; &nbsp; <span style="font-size: 14pt"></span></span><span style="color: #0000cc">
                                            <span style="font-size: 14pt">|</span> &nbsp; </span>
                                    </span>
                                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">Earned :&nbsp;
                        <input id="txt_earn" style="width: 40px" type="text" runat="server" readonly="readOnly" /></span><span style="color: #ff3399"><span style="color: #0000cc"></span></span></span></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Name</span></td>
                <td colspan="2" style="height: 1px; width: 122px; text-align: left;">
                    <input id="txt_name" style="height: 16px; font-size: 11pt; width: 153px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Duration</span></td>
                <td colspan="2" style="width: 105px; height: 1px; text-align: left">
                    <input id="txt_dur" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'; height: 16px" /></td>
            </tr>
            <tr>
                <td style="width: 243px; text-align: left; height: 22px;">
                    <span style="font-size: 11pt; font-family: Courier New">Apply Date</span></td>
                <td colspan="2" style="height: 22px; width: 122px;">
                    <input id="txt_appdt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 237px; font-family: 'Courier New'; height: 15px" /></td>
                <td style="width: 147px; text-align: left; height: 22px;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave Type</span></td>
                <td colspan="2" style="width: 105px; height: 22px; text-align: left">
                    <input id="txt_ltyp" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'; height: 15px" /></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">From Date </span>
                </td>
                <td colspan="2" style="height: 1px; width: 122px; text-align: left;">
                    <input id="txt_frdt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 153px; font-family: 'Courier New'" /></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">To Date</span></td>
                <td style="width: 105px; height: 1px; text-align: left;" colspan="2">
                    <input id="txt_todt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'" /></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Branch</span></td>
                <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="160px" Font-Bold="False" Style="font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Post</span></td>
                <td style="width: 105px; height: 1px; text-align: left" colspan="2">
                    <asp:DropDownList ID="cmb_post" runat="server" Width="194px" Style="font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">Total&nbsp;Leave&nbsp;of&nbsp;employee in&nbsp;Requested&nbsp;Leave&nbsp;Month</span></td>
                <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="txt_tot_mon" type="text" runat="server" readonly="readOnly" style="width: 153px; font-family: 'Courier New';" /></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">Sanctioned leave in Dept/Branch</span></td>
                <td style="width: 105px; height: 1px; text-align: left" colspan="2">
                    <input id="txt_leave_day" type="text" style="width: 67px; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 243px; text-align: left; height: 17px;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave Reason</span></td>
                <td colspan="5" style="text-align: left; height: 17px;">
                    <input id="txt_reason" readonly="readonly" style="width: 609px; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
            </tr>
            <tr id='row1'>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommended Reason</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="txt_recom_reason" runat="server" readonly="readonly" style="font-size: 11pt; width: 609px; font-family: 'Courier New'"
                        type="text" maxlength="100" /></td>
            </tr>
            <tr id='row2'>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommended By</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="txt_rec_by" runat="server" readonly="readonly" style="font-size: 11pt; width: 609px; font-family: 'Courier New'"
                        type="text" maxlength="100" /></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommended Date</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <asp:TextBox ID="txt_RecDate" runat="server" ReadOnly="True" Width="153px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 15px; text-align: center">
                    <span style="color: #cc0000; font-family: Courier New">
                        <strong><span style="color: #ff0000; text-decoration: underline;">Employee Requested Details</span></strong></span></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 15px; text-align: center">
                    <div style="text-align: center">
                        <table border="0" style="width: 648px; height: 24px">
                            <tr>
                                <td style="width: 103px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">From&nbsp;Date</span></td>
                                <td style="width: 87px; text-align: left">
                                    <asp:TextBox ID="txt_ReqFrDt" runat="server" Font-Names="Courier New" ReadOnly="True" Width="117px" BackColor="MintCream" ForeColor="Blue" Height="16px"></asp:TextBox></td>
                                <td style="width: 94px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">To&nbsp;Date</span></td>
                                <td style="width: 72px; text-align: left">
                                    <asp:TextBox ID="txt_ReqToDt" runat="server" Font-Names="Courier New" ReadOnly="True" Width="127px" BackColor="MintCream" ForeColor="Blue" Height="16px"></asp:TextBox></td>
                                <td style="width: 100px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">Duration</span></td>
                                <td style="width: 100px; text-align: left; font-size: 12pt; font-family: Times New Roman;">
                                    <asp:TextBox ID="txt_req_days" runat="server" BackColor="MintCream" Font-Names="Courier New"
                                        MaxLength="3" ReadOnly="True" Width="99px" Style="vertical-align: middle; text-align: center"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <%-- <tr>
                    <td style="width: 187px; height: 15px; text-align: left;">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                    <td style="width: 100px; height: 15px;">
                        </td>
                    <td style="width: 122px; height: 15px;" colspan="2">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                <td style="width: 100px; height: 15px; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="width: 187px; height: 15px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #3300ff">
                        </span> </span>
                </td>
                <td style="width: 100px; height: 15px; text-align: left">
                    <asp:TextBox ID="txt_req_days1" runat="server" BackColor="MintCream" Font-Names="Courier New"
                        ForeColor="Blue" ReadOnly="True" Width="155px"></asp:TextBox></td>
                <td colspan="2" style="width: 122px; height: 15px">
                    &nbsp;
                </td>
                <td style="font-size: 12pt; width: 100px; height: 15px">
                    &nbsp;
                </td>
            </tr>--%>
            <tr id="lima" style="font-size: 12pt; font-family: Times New Roman;">
                <td style="height: 13px; text-align: center;" colspan="6">&nbsp;
                    <input id="Checkbox1" style="width: 20px; height: 21px; font-weight: bold; font-size: 14pt; color: #ff0000;" type="checkbox" runat="server" />
                    &nbsp; <span
                        style="font-family: Courier New; color: #ff0000; text-decoration: underline;"><strong>Partial
                    Recommendation</strong></span></td>
            </tr>
            <tr id="sre" style="display: none; font-size: 12pt; font-family: Times New Roman;">
                <td colspan="6" style="height: 13px">
                    <div style="text-align: center">
                        <table border="0" style="width: 652px; height: 28px;">
                            <tr>
                                <td style="width: 99px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">From&nbsp;Date</span></td>
                                <td style="width: 69px; text-align: left">
                                    <asp:TextBox ID="txt_ParFrDt" onblur="OnCheckDate()" runat="server" MaxLength="11" Width="117px" Font-Names="Courier New" Height="16px"></asp:TextBox></td>
                                <td style="width: 91px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">To&nbsp;Date</span></td>
                                <td style="width: 106px; text-align: left">
                                    <asp:TextBox ID="txt_ParToDt" onblur="OnCheckToDate()" runat="server" MaxLength="11" Width="127px" Font-Names="Courier New" Height="16px"></asp:TextBox></td>
                                <td style="width: 100px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">Duration</span></td>
                                <td style="width: 100px; text-align: left">
                                    <asp:TextBox ID="txt_par_days" runat="server" Font-Names="Courier New" MaxLength="3"
                                        Width="99px" ReadOnly="True" Style="vertical-align: middle; text-align: center"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                        <table border="0">
                            <tr>
                                <td style="width: 103px; height: 23px">
                                    <input id="btn_Previous" style="width: 165px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="PREVIOUS DETAILS" onclick="return cmd_previous_onclick()" /></td>
                                <td style="width: 100px; height: 23px;">
                                    <input id="cmd_details" style="width: 95px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="DETAILS" onclick="return cmd_details_onclick()" /></td>
                                <td style="width: 100px; height: 23px;">
                                    <input id="cmd_applnform" style="width: 165px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="APPLICATION FORM" onclick="return cmd_applnform_onclick()" runat="server" /></td>
                                <td colspan="2" style="width: 5px; height: 23px;">
                                    <input id="cmd_support" style="width: 119px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="SUPPORTINGS " runat="server" onclick="return cmd_support_onclick()" /></td>
                                <td style="height: 23px">
                                    <input id="cmd_pl28" style="width: 79px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="PL 28" runat="server" onclick="return cmd_pl28_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                        <br />
                        <asp:Panel ID="pnlReco_reason" runat="server">
                            <table style="width: 431px">
                                <tr>
                                    <td style="width: 75px; height: 21px; text-align: left">
                                        <asp:Label ID="Label2" runat="server" Font-Names="Courier New" Font-Size="11pt" Text="Reason"></asp:Label></td>
                                    <td style="height: 21px"></td>
                                    <td style="height: 21px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 21px">
                                        <textarea id="txtReason" rows="2" style="width: 410px" runat="server"></textarea></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table border="0" style="width: 386px; height: 37px">
                            <tr>
                                <td colspan="2" style="height: 31px">
                                    <input id="cmd_rec" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="RECOMMEND" onclick="return cmd_rec_onclick()" runat="server" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="cmb_acc" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="SANCTION" onclick="return cmb_acc_onclick()" runat="server" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="cmd_reject" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="REJECT" onclick="return cmd_reject_onclick()" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="Button2" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="button" value="EXIT" onclick="return Button3_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <cc1:ListSearchExtender
                ID="ListSearchExtender1" runat="server" TargetControlID="cmb_leave">
            </cc1:ListSearchExtender>
            <asp:TextBox ID="txtEmpcode" runat="server" Visible="False"></asp:TextBox>
            &nbsp;
        </div>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
            TargetControlID="txt_ParFrDt"></cc1:CalendarExtender>
        <input id="hid_empcode" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_str" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_seq" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_rej" runat="server" style="width: 1px" type="hidden" />
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
            TargetControlID="txt_ParToDt"></cc1:CalendarExtender>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
</asp:Content>

