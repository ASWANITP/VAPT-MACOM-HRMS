<%@ Page Language="VB" MasterPageFile="~/salaryserver.master" AutoEventWireup="false" CodeBehind="Salary_master.aspx.vb" Inherits="WebAppHRMS.Circular_Show_Corcular_circular_display_b4c564f21859" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" for="window" event="onload">
        //return getQueryStringValues('mid');
        window.onload = callback;
        function callback() {
            return getQueryStringValues('mid');
        }
    </script>

    <script language="javascript" type="text/javascript">
        var cs = loanno.split('down1');
        function getQueryStringValues(key) {
            debugger;
            var arrParamValues = [];
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var arrParamInfo = url[i].split('=');
                //        if (arrParamInfo[0] == key || arrParamInfo[0] == key+'[]') {
                //            arrParamValues.push(decodeURIComponent(urlparam[1]));
                //        }
            }
            //return (arrParamValues.length > 0 ? (arrParamValues.length == 1 ? arrParamValues[0] : arrParamValues) : null);

            if (arrParamInfo[1] == 8) {
                document.getElementById("exec").style.display = "block";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "none";
            }
            if (arrParamInfo[1] == 9) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "block";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "none";
            }
            if (arrParamInfo[1] == 10) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "block";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "none";
            }
            if (arrParamInfo[1] == 11) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "block";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "none";
            }
            if (arrParamInfo[1] == 12) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "block";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "none";
            }
            if (arrParamInfo[1] == 13) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "block";
                document.getElementById("exec6").style.display = "none";
            }
            //     if (arrParamInfo[1]==14)
            //    {
            //    document.getElementById("exec").style.display="none";
            //    document.getElementById("exec1").style.display="block";
            //    }
            if (arrParamInfo[1] == 15) {
                document.getElementById("exec").style.display = "none";
                document.getElementById("exec1").style.display = "none";
                document.getElementById("exec2").style.display = "none";
                document.getElementById("exec3").style.display = "none";
                document.getElementById("exec4").style.display = "none";
                document.getElementById("exec5").style.display = "none";
                document.getElementById("exec6").style.display = "block";
            }

            if (arrParamInfo[1] == 23) {
                document.getElementById(cs[0] + "ddlDed").style.display = 'none';
                document.getElementById(cs[0] + "ddlDel").style.display = 'none';
                document.getElementById(cs[0] + "lblText").innerHTML = "Select Additions"
                document.getElementById("rowPan").style.display = 'none';
                document.getElementById(cs[0] + "hdnAdd").value = "";
                document.getElementById("rowDel").style.display = 'none';
                document.getElementById(cs[0] + "btnConfirm").style.display = "none";
            }
            check_use();
        }

        function Numberonly(Control) {
            debugger;
            if (isNaN(document.getElementById(cs[0] + Control).value)) {
                document.getElementById(cs[0] + Control).value = "";
                return false;
            }
        }
        function call_click_con() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec1").style.display = "none";
            ToServer(2, 2);
        }

        function call_click_LOP() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec2").style.display = "none";
            ToServer(3, 3);
        }

        function call_click_MER() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec3").style.display = "none";
            ToServer(4, 4);
        }

        function call_click_PF() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec4").style.display = "none";
            ToServer(5, 5);
        }

        function call_click_ESI() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec5").style.display = "none";
            ToServer(6, 6);
        }

        function call_click_ENTRY() {
            debugger;
            var flh = confirm("Are you sure?");
            if (flh == true) {
                document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
                document.getElementById("sp").style.display = "block";
                document.getElementById("exec6").style.display = "none";
                ToServer(7, 7);
            }
            else {
                document.getElementById("sp1").innerHTML = "";
                document.getElementById("sp").style.display = "none";
            }
            return false;
        }

        function check_use() {
            debugger;
            var arrParamValues = [];
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var arrParamInfo = url[i].split('=');
            }
            ToServer(0 + "#" + arrParamInfo[1], 0);
        }


        function call_click_run() {
            debugger;
            document.getElementById("sp1").innerHTML = "<img src='load.gif' alt='Please Wait...' />";
            document.getElementById("sp").style.display = "block";
            document.getElementById("exec").style.display = "none";
            ToServer(1, 1);
        }

        function FromServer(arg, context) {
            debugger;
            if (context == 0) {
                document.getElementById("lbl_user_name").innerText = arg.split('{')[1];
                if (arg.split('{')[0] == "C") {
                    alert("Please Consolidate Allowance First.\n\nDo The Process Step By Step!!");
                    document.getElementById("exec2").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "D") {
                    alert("Please Deduct LOP From Allowance.\n\nDo The Process Step By Step!!");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "M") {
                    alert("Please Merge Allowance.\n\nDo The Process Step By Step!!");
                    document.getElementById("exec4").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "P") {
                    alert("Please Process PF.\n\nDo The Process Step By Step!!");
                    document.getElementById("exec5").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "ESI") {
                    alert("Please Process ESI.\n\nDo The Process Step By Step!!");
                    document.getElementById("exec6").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "L") {
                    alert("You Have Reached The Final Stage Of Salary Processing.\n\nPlease Verify All Of Your Data Till Now Before Passing The Salary Entry!!");
                    return false;
                }

                if (arg.split('{')[0] == "T") {
                    alert("TDS Is Not Entered.\n\nTry After Entered!!");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "AC") {
                    alert("Already Consolidated.\n\nCannot Repeat!!");
                    document.getElementById("exec1").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "AD") {
                    alert("Already Deducted LOP.\n\nCannot Repeat!!");
                    document.getElementById("exec2").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "AM") {
                    alert("Already Merged.\n\nCannot Repeat!!");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "PFN") {
                    alert("PF Not Processed.");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "ESN") {
                    alert("ESI Not Processed.");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "MN") {
                    alert("ESI Not Processed.");
                    document.getElementById("exec3").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "CNO") {
                    alert("Allowance Not Consolidated.");
                    window.open("salary_master.aspx?mid=9", "_self");
                }

                if (arg.split('{')[0] == "AP") {
                    alert("Already Deducted PF.\n\nCannot Repeat!!");
                    document.getElementById("exec4").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "AE") {
                    alert("Already Deducted ESI.\n\nCannot Repeat!!");
                    document.getElementById("exec5").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "AL") {
                    alert("Already Entry Passed.\n\nCannot Repeat!!");
                    document.getElementById("exec6").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "MR") {
                    alert("Cannot Process Salary When Merged!!");
                    document.getElementById("exec").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "PR") {
                    alert("Cannot Process Salary When Merged!!");
                    document.getElementById("exec").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "ER") {
                    alert("Cannot Process Salary When Merged!!");
                    document.getElementById("exec").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if (arg.split('{')[0] == "EP") {
                    alert("Salary Process Already Completed!!");
                    window.open("salary_master.aspx?mid=0", "_self");
                    return false;
                }

                if (arg.split('{')[0] == "LR") {
                    alert("Cannot Process Salary When Merged!!");
                    document.getElementById("exec").style.display = "none";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>Operation Aborted!</i>"
                    return false;
                }

                if ((arg.split('#')[0] == "PFYA") || (arg.split('#')[0] == "ESYA") || (arg.split('#')[0] == "PFYD") || (arg.split('#')[0] == "ESYD")) {
                    var str = arg.split('#')[1].split('!');
                    var st, st3, st1, col1, col2, ar, delb, cap, opt;
                    st1 = "";
                    st = "";
                    if ((arg.split('#')[0] == "PFYA") || (arg.split('#')[0] == "PFYD")) {
                        col1 = "PF";
                        col2 = "E-PF";
                        if (arg.split('#')[0] == "PFYD") {
                            delb = "Delete PF";
                            cap = "BULK PF DELETION"
                            opt = 0;
                        }
                        else {
                            delb = "Add PF";
                            cap = "BULK PF ADDITION"
                            opt = 2;
                        }
                    }
                    else {
                        col1 = "ESI";
                        col2 = "E-ESI";
                        if (arg.split('#')[0] == "ESYD") {
                            delb = "Delete ESI";
                            cap = "BULK ESI DELETION"
                            opt = 1;
                        }
                        else {
                            delb = "Add ESI";
                            cap = "BULK ESI ADDITION"
                            opt = 3;
                        }
                    }
                    ar = str.length - 1;
                    for (i = 0; i < ar; i++) {
                        st3 = str[i].split("*");
                        st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td>";
                        st1 += "<td><small><input type='checkbox' id='chkm_" + i + "' name='txtm_" + i + "'></td>";
                        st1 += "</tr>";
                    }
                    st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>&nbsp;</td><td style='border-left:none;text-align:center;'><small><input value='" + delb + "' type='button' style='width:90px; height:28px; background-color :SeaShell; border-color:#FFC0C0; border-style:dashed; font-weight:bold;' id='inputs' onclick='done(" + opt + ")'/></td><td style='border-left:none;'><small>&nbsp;</td><td style='border-left:none;'><small>&nbsp;</td>";
                    st1 += "<td style='border-left:none;'><small>&nbsp;</td>";
                    st1 += "</tr>";
                    st = st + "<table id='mytable' border=1 style='width:980px; height:35px; text-align:left'><tr  bgcolor='darkred' style='font-size:85%'></td><td colspan='5' style='text-align:center;color:white;'><b>" + cap + "</td>";
                    st = st + "<tr  bgcolor='#CCCCEE' style='font-size:85%'></td><td><b>&nbsp;EMP CODE&nbsp;</b><td><b>&nbsp;EMP NAME&nbsp;</b></td><td><b>&nbsp;" + col1 + "&nbsp;</b></td><td><b>&nbsp;" + col2 + "&nbsp;</b></td><td><b>&nbsp;Mark&nbsp;</b></td>";

                    st1 = st + st1 + "</table>"
                    document.getElementById(cs[0] + "Pnl_Inbox").innerHTML = st1;
                    return true;
                }

            }
            if (context == 1) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    //alert("Successfully Executed. Please Download New Salary File.");
                    var Flag = confirm("Successfully Executed. Are You Sure To Download New Salary File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=5", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }

            if (context == 2) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    var Flag = confirm("Successfully Executed. Are You Sure To Download Final Allowance File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=7", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }

            if (context == 3) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    var Flag = confirm("Successfully Executed. Are You Sure To Download Final Allowance File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=7", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }


            if (context == 4) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    var Flag = confirm("Successfully Executed. Are You Sure To Download New Salary File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=5", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }

            if (context == 5) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    var Flag = confirm("Successfully Executed. Are You Sure To Download New Salary File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=5", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }

            if (context == 6) {
                if (arg == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    var Flag = confirm("Successfully Executed. Are You Sure To Download New Salary File?");
                    if (Flag == true) {
                        window.open("salary_master.aspx?mid=5", "_self");
                    }
                    else {
                        window.open("salary_master.aspx?mid=2", "_self");
                    }
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("sp").style.display = "none";
                }
            }

            if (context == 7) {
                if (arg.split('#')[0] == "Y") {
                    document.getElementById("sp1").innerHTML = "";
                    //document.getElementById("sp1").innerHTML ="<i style='color:green;'>Successfully Executed. Please Download New Salary File.</i>"
                    alert("Accounts Ledger Entry Has Successfull.\n\nDear " + arg.split('#')[1] + ", You Have Successfully Completed Current Month Salary Processing");

                    window.open("salary_master.aspx?mid=2", "_self");
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "N") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>"
                    document.getElementById("exec6").style.display = "none";
                    document.getElementById("sp").style.display = "none";
                }
                if (arg == "E") {
                    document.getElementById("sp1").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>"
                    document.getElementById("exec6").style.display = "none";
                    document.getElementById("sp").style.display = "none";
                }
            }



            if (context == 8) {
                if ((arg.split('#')[0] == "Y") || (arg.split('#')[0] == "N")) {
                    if (arg.split('#')[0] == "Y") {

                        if (arg.split('#')[1] == "0") {
                            alert("Successfully Deleted PF From Selected Employee(s)");
                            window.open("salary_master.aspx?mid=16", "_self");
                        }

                        if (arg.split('#')[1] == "2") {
                            alert("Successfully Added PF For Selected Employee(s)");
                            window.open("salary_master.aspx?mid=17", "_self");
                        }

                        if (arg.split('#')[1] == "1") {
                            alert("Successfully Deleted ESI From Selected Employee(s)");
                            window.open("salary_master.aspx?mid=18", "_self");
                        }

                        if (arg.split('#')[1] == "3") {
                            alert("Successfully Added ESI For Selected Employee(s)");
                            window.open("salary_master.aspx?mid=19", "_self");
                        }

                    }

                    if (arg.split('#')[0] == "N") {
                        document.getElementById("spc").innerHTML = "";
                        document.getElementById(cs[0] + "Pnl_Inbox").innerHTML = "";
                        document.getElementById("spc").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Try After Some Time.</i>";
                    }
                }
                else {
                    document.getElementById("spc").innerHTML = "";
                    document.getElementById(cs[0] + "Pnl_Inbox").innerHTML = "";
                    document.getElementById("sp1").innerHTML = "<i style='color:red;'>An Error Occurred While Executing! Please Inform HRMS-IT.</i>";
                }
            }


            if (context == 9) {
                if (arg.split('#')[0] == "Y") {
                    document.getElementById(cs[0] + "txtEname").value = arg.split('#')[1];
                }
            }


            if (context == 10) {
                var Data = arg.split("@")
                if ((Data[0] == "") || (Data[0] == " ")) {
                    document.getElementById("rowDel").style.display = 'inline';
                    document.getElementById(cs[0] + "Panel2").innerHTML = "<span style='color:red;'>No Data Found!</span>";
                    document.getElementById(cs[0] + "btnConfirm").style.display = "none";
                }
                else {
                    if (document.getElementById(cs[0] + "hdnDelChange").value == 0) {
                        document.getElementById("rowDel").style.display = 'none';
                        return false;

                    }
                    else {
                        document.getElementById("rowDel").style.display = 'inline';
                        document.getElementById(cs[0] + "hdnDelData").value = Data[0];
                        dispe();
                    }
                }
            }
        }


        function dispe() {
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cs[0] + "hdnDelChange").value == 0) {
                document.getElementById(cs[0] + "Panel2").innerHTML = "";
                document.getElementById("rowDel").style.display = "none";
                return false;
            }
            st2 = document.getElementById(cs[0] + "hdnDelData").value.split("!")
            ar = st2.length - 1;
            if (document.getElementById(cs[0] + "hdnDelData").value != "") {
                for (k = 0; k < ar; k++) {
                    st3 = st2[k].split("*")
                    st1 = st1 + "<tr><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><input type='checkbox' id='chkm_" + k + "' name='txtm_" + k + "'></td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMPLOYEE&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;AMOUNT&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;DELETE&nbsp;&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + "</table>"
            }
            else {
                st1 = st + "</table>";
            }
            document.getElementById("rowDel").style.display = "inline";
            document.getElementById(cs[0] + "Panel2").innerHTML = st1;
            document.getElementById(cs[0] + "btnConfirm").style.display = "block";
        }

        function done(op) {
            debugger;
            var cnt;
            var shabai = 0;
            document.getElementById(cs[0] + "hidden2").value = "";
            cnt = document.getElementById("mytable").rows.length;
            for (i = 0; i < cnt - 3; i++) {
                if (document.getElementById(cs[0] + "hidden2").value == "" && document.getElementById("chkm_" + i + "").checked == true) {
                    shabai = i + 1;
                    document.getElementById(cs[0] + "hidden2").value = document.getElementById("mytable").rows[i + 2].cells[0].innerText + "$" + op;
                }
                else {
                    if (document.getElementById(cs[0] + "hidden2").value != "" && document.getElementById("chkm_" + i + "").checked == true) {
                        shabai = i + 1;
                        document.getElementById(cs[0] + "hidden2").value = document.getElementById(cs[0] + "hidden2").value + "@" + document.getElementById("mytable").rows[i + 2].cells[0].innerText + "$" + op;
                    }
                }
            }
            if (shabai <= 0) {
                alert("Please Select Any Employee!!");
                return false;
            } else {
                var dta = document.getElementById(cs[0] + "hidden2").value;
                ToServer(8 + "#" + dta, 8);
            }
        }



        function genconfirm() {
            debugger;
            document.getElementById(cs[0] + "tr4").style.display = "none";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        function ClickAddition() {
            document.getElementById(cs[0] + "ddlAdd").style.display = 'inline';
            document.getElementById(cs[0] + "ddlDed").style.display = 'none';
            document.getElementById(cs[0] + "ddlDel").style.display = 'none';
            document.getElementById(cs[0] + "lblText").innerHTML = "Select Additions"
            document.getElementById(cs[0] + "ddlAdd").value = 0;
            document.getElementById(cs[0] + "hdnAdd").value = "";
            showDetails();
            document.getElementById(cs[0] + "txtEcode").value = "";
            document.getElementById(cs[0] + "txtEname").value = "";
            document.getElementById(cs[0] + "txtAmt").value = "";
            document.getElementById("rowEmp").style.display = 'inline';
            document.getElementById("rowAmt").style.display = 'inline';
            document.getElementById("rowAdd").style.display = 'inline';
            document.getElementById("rowPan").style.display = 'inline';
            document.getElementById("rowDel").style.display = 'none';
        }

        function ClickDeduction() {
            document.getElementById(cs[0] + "ddlAdd").style.display = 'none';
            document.getElementById(cs[0] + "ddlDed").style.display = 'inline';
            document.getElementById(cs[0] + "ddlDel").style.display = 'none';
            document.getElementById(cs[0] + "lblText").innerHTML = "Select Deductions"
            document.getElementById(cs[0] + "ddlDed").value = 0;
            document.getElementById(cs[0] + "hdnAdd").value = "";
            showDetails();
            document.getElementById(cs[0] + "txtEcode").value = "";
            document.getElementById(cs[0] + "txtEname").value = "";
            document.getElementById(cs[0] + "txtAmt").value = "";
            document.getElementById("rowEmp").style.display = 'inline';
            document.getElementById("rowAmt").style.display = 'inline';
            document.getElementById("rowAdd").style.display = 'inline';
            document.getElementById("rowPan").style.display = 'inline';
            document.getElementById("rowDel").style.display = 'none';
        }

        function ClickDeletion() {
            debugger;
            document.getElementById(cs[0] + "ddlAdd").style.display = 'none';
            document.getElementById(cs[0] + "ddlDed").style.display = 'none';
            document.getElementById(cs[0] + "ddlDel").style.display = 'inline';
            document.getElementById(cs[0] + "lblText").innerHTML = "Select Deletion Item";
            document.getElementById(cs[0] + "ddlDel").value = 0;
            document.getElementById(cs[0] + "hdnAdd").value = "";
            document.getElementById("rowEmp").style.display = 'none';
            document.getElementById("rowAmt").style.display = 'none';
            document.getElementById("rowAdd").style.display = 'none';
            document.getElementById("rowPan").style.display = 'none';
            document.getElementById("rowDel").style.display = 'none';

        }
        function isNumeric() {
            if (isNaN(document.getElementById(cs[0] + "txtEcode").value)) {
                document.getElementById(cs[0] + "txtEcode").value = "";
                return false;
            }
        }
        function isNumericAmt() {
            if (isNaN(document.getElementById(cs[0] + "txtAmt").value)) {
                document.getElementById(cs[0] + "txtAmt").value = "";
                return false;
            }
        }
        function ComboChange() {
            document.getElementById(cs[0] + "txtEcode").value = "";
            document.getElementById(cs[0] + "txtEname").value = "";
            document.getElementById(cs[0] + "txtAmt").value = "";
        }
        function ComboChangeDel() {
            document.getElementById(cs[0] + "hdnDelChange").value = document.getElementById(cs[0] + "ddlDel").value;
            if (document.getElementById(cs[0] + "hdnDelChange").value == 0) {
                document.getElementById(cs[0] + "hdnDelData").value = "";
                document.getElementById("rowDel").style.display = 'none';
            }
            if (document.getElementById(cs[0] + "hdnDelChange").value != 0) {
                //callserver("2$"+document.getElementById(cs[0]+"hdnDelChange").value,2); 
                ToServer(10 + "#" + document.getElementById(cs[0] + "hdnDelChange").value, 10);
            }
        }
        function detailDisplay() {
            debugger;
            if (isNaN(document.getElementById(cs[0] + "txtEcode").value)) {
                document.getElementById(cs[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(cs[0] + "txtEcode").value == "") {
                document.getElementById(cs[0] + "txtEname").value = "";
                return false;
            }
            if (document.getElementById(cs[0] + "txtEcode").value != "") {
                //callserver("1$"+document.getElementById(cs[0]+"txtEcode").value,1);  
                var dta = document.getElementById(cs[0] + "txtEcode").value;
                ToServer(9 + "#" + dta, 9);
            }
        }




        function btnAdd_onclick() {
            debugger;
            if (document.getElementById(cs[0] + "rdAdd").checked == true) {
                if (document.getElementById(cs[0] + "ddlAdd").value == 0) {
                    alert('Please Select Addition Item..!!');
                    document.getElementById(cs[0] + "ddlAdd").focus();
                    return false;
                }
            }
            if (document.getElementById(cs[0] + "rdDeduction").checked == true) {
                if (document.getElementById(cs[0] + "ddlDed").value == 0) {
                    alert('Please Select Deduction Item..!!');
                    document.getElementById(cs[0] + "ddlDed").focus();
                    return false;
                }
            }
            if (document.getElementById(cs[0] + "rdDelete").checked == true) {
                if (document.getElementById(con[0] + "ddlDel").value == 0) {
                    alert('Please Select Delection Item..!!');
                    document.getElementById(cs[0] + "ddlDel").focus();
                    return false;
                }
            }
            if (document.getElementById(cs[0] + "txtEcode").value == "") {
                alert('Please Enter Employee ID.!!');
                document.getElementById(cs[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(cs[0] + "txtEname").value == "") {
                alert('Please Enter Employee ID.!!');
                document.getElementById(cs[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(cs[0] + "hdnAdd").value != "") {
                document.getElementById(cs[0] + "hdnCheck").value = document.getElementById(cs[0] + "hdnAdd").value + "!" + document.getElementById(cs[0] + "txtEcode").value + "#" + document.getElementById(cs[0] + "txtEname").value + "#" + compval + "#" + document.getElementById(cs[0] + "txtAmt").value;
                var data = document.getElementById(cs[0] + "hdnCheck").value;
                var rows = data.split("!");
                eid = document.getElementById(cs[0] + "txtEcode").value;
                for (i = 0; i <= rows.length - 2; i++) {
                    cols = rows[i].split("#");
                    if (document.getElementById(cs[0] + "rdAdd").checked == true) {
                        var item = document.getElementById(cs[0] + "ddlAdd").options[document.getElementById(cs[0] + "ddlAdd").selectedIndex].text;

                    }
                    if (document.getElementById(cs[0] + "rdDeduction").checked == true) {
                        var item = document.getElementById(cs[0] + "ddlDed").options[document.getElementById(cs[0] + "ddlDed").selectedIndex].text;
                    }
                    if ((cols[0] == eid) && (cols[2] == item)) {
                        alert('Already Added..!');
                        document.getElementById(cs[0] + "txtEcode").value = "";
                        document.getElementById(cs[0] + "txtEname").value = "";
                        return false;
                    }

                }
            }
            var compval;
            if (document.getElementById(cs[0] + "rdAdd").checked == true) {
                if (document.getElementById(cs[0] + "txtAmt").value == "") {
                    alert('Please Enter Amount!!');
                    document.getElementById(cs[0] + "txtAmt").focus();
                    return false;
                }
                compval = document.getElementById(cs[0] + "ddlAdd").options[document.getElementById(cs[0] + "ddlAdd").selectedIndex].text;

            }
            if (document.getElementById(cs[0] + "rdDeduction").checked == true) {
                if (document.getElementById(cs[0] + "txtAmt").value == "") {
                    alert('Please Enter Amount!!');
                    document.getElementById(cs[0] + "txtAmt").focus();
                    return false;
                }
                compval = document.getElementById(cs[0] + "ddlDed").options[document.getElementById(cs[0] + "ddlDed").selectedIndex].text;

            }
            if (document.getElementById(cs[0] + "rdDelete").checked == true) {
                compval = document.getElementById(cs[0] + "ddlDel").options[document.getElementById(cs[0] + "ddlDel").selectedIndex].text;

            }
            document.getElementById(cs[0] + "hdnAdd").value = document.getElementById(cs[0] + "hdnAdd").value + "!" + document.getElementById(cs[0] + "txtEcode").value + "#" + document.getElementById(cs[0] + "txtEname").value + "#" + compval + "#" + document.getElementById(cs[0] + "txtAmt").value;
            document.getElementById("rowPan").style.display = 'inline';

            showDetails();
            document.getElementById(cs[0] + "txtEcode").value = "";
            document.getElementById(cs[0] + "txtEname").value = "";
            document.getElementById(cs[0] + "txtAmt").value = "";
            document.getElementById(cs[0] + "btnConfirm").style.display = "block";
            return false;
        }


        function delf(m) {
            debugger;
            var j = m - 1, k
            var new_tran = ""
            var new_tran1 = ""
            var arr = document.getElementById(cs[0] + "hdnAdd").value.split("!")
            for (k = 1; k <= j; k++) {
                new_tran = new_tran + "!" + arr[k]
            }
            for (k = j + 2; k < arr.length; k++) {
                new_tran = new_tran + "!" + arr[k]
            }
            document.getElementById(cs[0] + "hdnAdd").value = new_tran
            showDetails();
        }

        function showDetails() {
            var tmptab;
            tmptab = "";
            tmptab = "<table align=center width=100% border=1><tr></tr>";
            tmptab = tmptab + "<tr style='background-color:Wheat'><td width=15% align=left style= 'font-size: 10pt;'>Ecode</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>ENAME</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>INS ITEM</td>";
            tmptab = tmptab + "<td width=5% align=left style= 'font-size: 10pt;'>AMOUNT</td>";
            tmptab = tmptab + "<td width=5% align=right style= 'font-size: 10pt;'>DELETE</td></tr>";

            var rowSplitarr = document.getElementById(cs[0] + "hdnAdd").value.split("!");
            var row_bg1 = 0;
            var m, j, cnt;
            m = 0; j = 0; cnt = 0;
            if (rowSplitarr.length >= 2) {
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
                    tmptab = tmptab + "<td width=10% align=right style= 'font-size: 10pt;'><a href=javascript:delf(" + m + ")>Delete</a></td></tr>";
                }
                if (row_bg1 == 0)
                    tmptab += "<tr style='background-color:OldLace'>";
                else
                    tmptab += "<tr style='background-color:Wheat'>";
                tmptab = tmptab + "</table>";
                document.getElementById(cs[0] + "Panel1").innerHTML = tmptab;
            }
            else {
                document.getElementById(cs[0] + "Panel1").innerHTML = "";
                document.getElementById(cs[0] + "btnConfirm").style.display = "none";
            }
        }

        function onclickconf() {
            debugger;


            if (document.getElementById(cs[0] + "rdDelete").checked == true) {
                if (document.getElementById(cs[0] + "ddlDel").value == 0) {
                    alert("Please Select Deletion Item...!");
                    return false;
                }
                document.getElementById(cs[0] + "hdnDelCon").value = "";
                if (document.getElementById(cs[0] + "hdnDelData").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(cs[0] + "hdnDelData").value.split("!")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("*")
                        var Regular = "T";
                        if (document.getElementById("chkm_" + i + "").checked == false) {
                            Regular = "F";
                        }
                        else {
                            document.getElementById(cs[0] + "hdnToSendDel").value += st3[0] + "^" + Regular + "#";
                        }
                        // document.getElementById(con[0]+"hdnDelCon").value += st3[0] + "^" +st3[1] + "^" +Regular+"#" ; 
                        document.getElementById(cs[0] + "hdnDelCon").value += st3[0] + "^" + Regular + "#";
                    }
                }
            }
        }
    </script>

    <div style="text-align: center" runat="server" id="div1">

        <br />
        <table border="2" style="width: 100%">
            <tr>
                <td colspan="3">
                    <span id="spc"></span>
                    <asp:Panel ID="Pnl_Inbox" runat="server" BorderStyle="Solid" Height="360px" BorderWidth="2px"
                        ScrollBars="Auto" Width="100%" Wrap="False">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
        </table>
        <asp:HiddenField ID="hidden2" runat="server" />
    </div>

    <div runat="server" style="text-align: left; border: double;" id="div2">
    </div>
    <div runat="server" style="text-align: center; border: double; height: 360px;" id="div3">
        <br>
        <br>
        <br>
        <br>
        <asp:GridView ID="grid" runat="server"></asp:GridView>
        <asp:Button Text="Click Here To Download" Width="160px" BackColor="SeaShell" BorderColor="#FFC0C0" Font-Bold="True" Height="28px" BorderStyle="Dashed" ID="down1_d" runat="server" />
        <asp:Button Text="Click Here To Download" Width="160px" ID="down2_d" BackColor="SeaShell" BorderColor="#FFC0C0" Font-Bold="True" Height="28px" BorderStyle="Dashed" runat="server" />
        <asp:Button Text="Click Here To Download" Width="160px" ID="down3_d" BackColor="SeaShell" BorderColor="#FFC0C0" Font-Bold="True" Height="28px" BorderStyle="Dashed" runat="server" />

    </div>
    <div runat="server" style="text-align: center; border: double; height: 360px;" id="div4">
        <br>
        <br>
        <br>
        <br>
        <input type="button" value="Click Here To Process Salary" onclick="call_click_run()" style="width: 200px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec" />
        <input type="button" value="Click Here To Consolidate" onclick="call_click_con()" style="width: 190px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec1" />
        <input type="button" value="Click Here For LOP Deduction" onclick="call_click_LOP()" style="width: 200px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec2" />
        <input type="button" value="Click Here To Merge" onclick="call_click_MER()" style="width: 190px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec3" />
        <input type="button" value="Click Here To Process PF" onclick="call_click_PF()" style="width: 190px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec4" />
        <input type="button" value="Click Here To Process ESI" onclick="call_click_ESI()" style="width: 190px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec5" />
        <input type="button" value="Click Here For Accounts Entry" onclick="call_click_ENTRY()" style="width: 200px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold; margin: 0 auto; cursor: pointer;" id="exec6" />
        <span id="sp1"></span>
        <span id="sp" style="display: none;">Executing...</span>
        <%--<img src="~/Salary Process Macom/load.gif" id="gifexe" alt="please wait..."/>--%>
    </div>
    <div runat="server" style="text-align: center; border: double; height: 360px;" id="div5">
        <br>
        <br>
        <br>
        <br>
        <table border="1" style="width: 40%; height: 56px; text-align: left">
            <tr style="background-color: darkred;">
                <td colspan="3" style="width: 20%; text-align: center; color: white;">
                    <b>OUSTATION AFTER BATTA DAYS UPDATION</td>
            </tr>
            <tr id="rw1">
                <td style="width: 20%; text-align: right; color: darkred;">
                    <b>Select Employee&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="drop_SelectedIndexChanged" ID="drop" Width="264px"></asp:DropDownList></td>
            </tr>
            <tr id="rw2">
                <td style="width: 20%; text-align: right; height: 28px; color: darkred;">
                    <b>Current Amount&nbsp;
                </td>
                <td style="width: 20%; text-align: left; height: 28px; color: darkred;">
                    <asp:Label ID="lab" runat="server">Rs. 0.00</asp:Label></td>
            </tr>
            <tr id="amount_row">
                <td style="width: 20%; text-align: right; color: darkred;">
                    <b>Enter New Amount&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_amount" onfocusout="Numberonly('txt_amount')" runat="server" Width="181px" MaxLength="6" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <tr id="trowam" runat="server">
                <td colspan="3" style="text-align: center">
                    <asp:Label runat="server" ID="msge"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <asp:Button ID="Button3" runat="server" Text="Update" Style="width: 60px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold;" OnClientClick="delconfirm()" /></td>
            </tr>
        </table>
    </div>

    <div runat="server" style="text-align: center; border: double; height: 360px;" id="div6">
        <br>
        <br>
        <br>
        <br>
        <table border="1" style="width: 40%; height: 56px; text-align: left">
            <tr style="background-color: darkred;">
                <td colspan="3" style="width: 20%; text-align: center; color: white;">
                    <b>LEAVES AVAILED REPORT</td>
            </tr>
            <tr id="Tr1">
                <td style="width: 20%; text-align: right; color: darkred;">
                    <b>Select From Date&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="text1" runat="server" Width="150px"></asp:TextBox></td>
            </tr>
            <tr id="Tr2">
                <td style="width: 20%; text-align: right; height: 28px; color: darkred;">
                    <b>Select To Date&nbsp;
                </td>
                <td style="width: 20%; text-align: left; height: 28px; color: darkred;">
                    <asp:TextBox ID="text2" runat="server" Width="150px"></asp:TextBox></td>
            </tr>
            <tr id="tr4" runat="server">
                <td colspan="3" style="text-align: center">
                    <asp:Label runat="server" ID="Label2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MMM/yyyy" TargetControlID="text1" runat="server"></cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="text2" runat="server"></cc1:CalendarExtender>
                    <asp:Button ID="Button1" runat="server" Text="Generate" Style="width: 70px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold;" OnClientClick="genconfirm()" /></td>
            </tr>
        </table>
    </div>

    <div runat="server" style="text-align: center; border: double; height: auto;" id="div7">
        <asp:HiddenField ID="hdnToSendDel" runat="server" />
        <asp:HiddenField ID="hdnCheck" runat="server" />
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="hdnDelChange" runat="server" />
        <asp:HiddenField ID="hdnDelData" runat="server" />
        <asp:HiddenField ID="hdnDelCon" runat="server" />
        <br>
        <table border="1" style="width: 60%">
            <tr style="background-color: darkred;">
                <td colspan="4" style="width: 20%; text-align: center; color: white;">
                    <b>ADD/DEDUCT SALARY ELEMENTS
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:RadioButton ID="rdAdd" ForeColor="darkred" runat="server" Checked="True" GroupName="Ins" onclick="ClickAddition()" Text="Addition" />
                    <asp:RadioButton ID="rdDeduction" ForeColor="darkred" runat="server" GroupName="Ins" onclick="ClickDeduction()" Text="Deduction" />
                    <asp:RadioButton ID="rdDelete" ForeColor="darkred" runat="server" GroupName="Ins" onclick="ClickDeletion()" Text="Delete" /></td>
            </tr>
            <tr id="rowCombo">
                <td style="width: 12%; height: 29px;">
                    <asp:Label ID="lblText" runat="server" Height="25px" ForeColor="darkred" Text="Select Additions" Width="194px"></asp:Label></td>
                <td style="height: 29px; text-align: left;" id="add" colspan="3">
                    <asp:DropDownList ID="ddlDed" runat="server" onchange="ComboChange()" Width="60%">
                        <asp:ListItem Selected="True" Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">LIC</asp:ListItem>
                        <asp:ListItem Value="2">P-Tax</asp:ListItem>
                        <asp:ListItem Value="3">TDS</asp:ListItem>
                        <asp:ListItem Value="4">Other Ded</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDel" runat="server" onchange="ComboChangeDel()" Width="60%">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Arrear Sal</asp:ListItem>
                        <asp:ListItem Value="2">Arrear DA</asp:ListItem>
                        <asp:ListItem Value="3">Other Add</asp:ListItem>

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

                    </asp:DropDownList></td>
            </tr>
            <tr id="rowEmp">
                <td style="width: 12%; height: 13px; text-align: center; color: darkred;">Enter Emp. Code</td>
                <td style="width: 11%; height: 13px">
                    <asp:TextBox ID="txtEcode" runat="server" Width="95%" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="6"></asp:TextBox></td>
                <td style="width: 15%; height: 13px; color: darkred;">Emp. Name</td>
                <td style="width: 15%; height: 13px">
                    <asp:TextBox ID="txtEname" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="rowAmt">
                <td colspan="2" style="height: 13px; text-align: center; color: darkred;">Enter Amount</td>
                <td colspan="2" style="height: 13px; text-align: left">
                    <asp:TextBox ID="txtAmt" runat="server" onblur="isNumericAmt()" onkeypress="isNumericAmt()" Width="70%"></asp:TextBox></td>
            </tr>
            <tr id="rowAdd">
                <td colspan="4" style="height: 23px">
                    <input id="btnAdd" style="width: 70px; height: 28px; background-color: SeaShell; border-color: #FFC0C0; border-style: dashed; font-weight: bold;" type="button" value="ADD" onclick="return btnAdd_onclick()" /></td>
            </tr>
            <tr id="rowPan">
                <td colspan="4" style="height: 19px">
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="rowDel">
                <td colspan="4" style="height: 19px">
                    <asp:Panel ID="Panel2" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return onclickconf()" BackColor="seashell" BorderColor="#FFC0C0" BorderStyle="Dashed" Font-Bold="true" Width="70px" Height="28px" />
                    <%--<input id="btnExit" type="button" value="EXIT" style="width:50px; height:28px; background-color :SeaShell; border-color:#FFC0C0; border-style:dashed; font-weight:bold;" onclick="return btnExit_onclick()" />--%></td>
            </tr>
            <tr>
                <td style="width: 12%"></td>
                <td style="width: 11%"></td>
                <td style="width: 7%"></td>
                <td style="width: 15%"></td>
            </tr>
        </table>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
    </div>

</asp:Content>

