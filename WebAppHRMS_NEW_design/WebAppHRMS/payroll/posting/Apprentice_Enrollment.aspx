<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="Apprentice_Enrollment.aspx.vb" Inherits="WebAppHRMS.Apprentice_Enrollment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">
    <style>
/* ── Container Styling ───────────────────────────────────────────────────── */
#tblApprenticeForm {
  /* gradient background + rounded corners + drop shadow */
  background: linear-gradient(to right, #E0BBE4, #C3D9EF);
  border-radius: 12px;
  box-shadow: 0 6px 15px rgba(0,0,0,0.1);

  /* table settings */
  width: 100%;              /* full width of its wrapper */
  border-collapse: collapse;
  margin: 30px auto;        /* center + breathing room */
  padding: 20px;            /* this only works on display:block tables */
  display: block;           /* make padding on table work */
  box-sizing: border-box;
}

/* ── Cell & Label Layout ───────────────────────────────────────────────── */
#tblApprenticeForm td {
  padding: 10px;
  vertical-align: middle;
}
#tblApprenticeForm td label,
#tblApprenticeForm td .aspNetLabel {
  display: block;
  font-weight: bold;
  color: #2F4F6F;
  text-align: right;
  padding-right: 10px;
}

/* ── Inputs & Selects ───────────────────────────────────────────────────── */
#tblApprenticeForm input[type="text"],
#tblApprenticeForm select,
#tblApprenticeForm .aspNetTextBox {
  width: 100%;
  padding: 8px 10px;
  font-size: 15px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}
#tblApprenticeForm input[readonly] {
  background-color: #f5f5f5;
}

/* ── Error Label ────────────────────────────────────────────────────────── */
#tblApprenticeForm #<%= lbl_err.ClientID %> {
  /* if you can’t use the server ID, target by color or position */
  color: red;
  font-size: 16px;
  font-weight: bold;
  text-align: center;
  margin-bottom: 15px;
  display: block;
}

/* ── Section Headers (row9) ─────────────────────────────────────────────── */
#tblApprenticeForm tr[id^="row9"] td {
  border-top: 1px solid #ccc;
  padding-top: 15px;
  font-weight: bold;
  color: #2F4F6F;
  text-align: center;
  height:100%;
}

/* ── Buttons ───────────────────────────────────────────────────────────── */
#tblApprenticeForm input[type="button"],
#tblApprenticeForm input[type="submit"],
#tblApprenticeForm button,
#tblApprenticeForm .aspNetButton {
  padding: 10px 25px;
  font-size: 16px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  background-color: #2F4F6F;
  color: #fff;
  transition: background-color .3s ease;
}
#tblApprenticeForm input[type="button"]:hover,
#tblApprenticeForm input[type="submit"]:hover,
#tblApprenticeForm button:hover,
#tblApprenticeForm .aspNetButton:hover {
  background-color: #1c5fc0;
}
</style>

        <script language="javascript" type="text/javascript">
        var cont = loanno.split("txt")

        window.onload = window_onload;

        function window_onload() {
            debugger;
            //document.getElementById(cont[0] + "hid_esi").value = "T";
            //document.getElementById(cont[0] + "hid_pf").value = "F";
            //document.getElementById(cont[0] + "hid_security").value = "T";
            document.getElementById("row9").style.display = "none";
            document.getElementById("row4").style.display = "none";
            document.getElementById("row5").style.display = "none";
            document.getElementById("row6").style.display = "none";
            document.getElementById("row7").style.display = "none";
            document.getElementById("row8").style.display = "none";
            document.getElementById("row10").style.display = "none";
            document.getElementById("row11").style.display = "none";
            document.getElementById("row12").style.display = "none";
            document.getElementById("row13").style.display = "none";
            document.getElementById(cont[0] + "hid_datas").value = ""
            document.getElementById(cont[0] + "hid_others").value = ""




            //   document.getElementById(cont[0]+"hid_basic").value=parseInt(document.getElementById(cont[0]+"cmb_basic").options[document.getElementById(cont[0]+"cmb_basic").selectedIndex].text);

            basicfill();
            // document.getElementById("txt_total").value=parseInt(document.getElementById(cont[0]+"cmb_basic").options[document.getElementById(cont[0]+"cmb_basic").selectedIndex].text);
        }
        // <!CDATA[

        function fillname() {
            debugger;
            document.getElementById(cont[0] + "lbl_err").innerText = '';
            document.getElementById(cont[0] + "hid_appln_no").value = document.getElementById(cont[0] + "txt_applnno").value;
            call_server("2$" + document.getElementById(cont[0] + "hid_appln_no").value);
            }

       

        function vdafill() {
            //
            debugger;
            if (document.getElementById(cont[0] + "cmb_type").value == 1) {
                //document.getElementById(cont[0] + "hid_da").value = "T";
                //document.getElementById("rdb_vda_yes").checked = true;
                //document.getElementById("rdb_vda_no").checked = false;
                document.getElementById("Amt").value = parseInt(document.getElementById(cont[0] + "hid_da").value) + parseInt(document.getElementById(cont[0] + "sal").options[document.getElementById(cont[0] + "sal").selectedIndex].text);
            }
            else {
                //document.getElementById(cont[0] + "hid_da").value = "F";
                //document.getElementById("rdb_vda_yes").checked = false;
                //document.getElementById("rdb_vda_no").checked = true;
                document.getElementById("Amt").value = parseInt(document.getElementById(cont[0] + "sal").options[document.getElementById(cont[0] + "sal").selectedIndex].text);
            }
        }
        function totfill() {
            debugger;
            //if (document.getElementById("rdb_vda_yes").checked == true) {
            //    document.getElementById(cont[0] + "hid_da").value = "T";
            //}
            //else {
            //    document.getElementById(cont[0] + "hid_da").value = "F";
            //}

            //document.getElementById(cont[0] + "hid_basic").value = parseInt(document.getElementById(cont[0] + "sal").options[document.getElementById(cont[0] + "sal").selectedIndex].text);
            //if (document.getElementById("rdb_vda_yes").checked == true) {
            //    document.getElementById("Amt").value = parseInt(document.getElementById(cont[0] + "hid1_da").value) + parseInt(document.getElementById(cont[0] + "sal").options[document.getElementById(cont[0] + "sal").selectedIndex].text);
            //}
            //else {
            //    document.getElementById("Amt").value = parseInt(document.getElementById(cont[0] + "sal").options[document.getElementById(cont[0] + "sal").selectedIndex].text);
            //}
        }
        //function esifill() {
        //    debugger;
        //    if (document.getElementById("rdb_esi_yes").checked == true) {
        //        document.getElementById(cont[0] + "hid_esi").value = "T";
        //    }
        //    else {
        //        document.getElementById(cont[0] + "hid_esi").value = "F";
        //    }
        //}
        //function pffill() {
        //    debugger;
        //    if (document.getElementById("rdb_pf_yes").checked == true) {
        //        document.getElementById(cont[0] + "hid_pf").value = "T";
        //    }
        //    else {
        //        document.getElementById(cont[0] + "hid_pf").value = "F";
        //    }
        //}
        //function rejoiningfill() {
        //    debugger;
        //    if (document.getElementById("rdb_rejoining_yes").checked == true) {
        //        document.getElementById(cont[0] + "hid_rejoining").value = "T";
        //    }
        //    else {
        //        document.getElementById(cont[0] + "hid_rejoining").value = "F";
        //    }
        //}
        function basicfill() {
            debugger;
            document.getElementById(cont[0] + "hid1").value = document.getElementById(cont[0] + "cat_drop").value;
            call_server("1$" + document.getElementById(cont[0] + "hid1").value);
        }


        function call_receiver(arg1) {
            debugger;
            var gg;
            gg = arg1.split("$")
            if (gg[0] == 1) {
                var arg2;
                arg2 = gg[1].split("#");
              
                document.getElementById("sal").value = arg2[0]
                document.getElementById("Amt").value = arg2[1]

            }
            else if (gg[0] == 2) {
                document.getElementById("txt_applnname").value = gg[1];

                ss = gg[2].split("@")
                num = ss[0]
                if (ss[0] == 1) {
                    document.getElementById("row9").style.display = "table-row";
                    document.getElementById("row4").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_data1").innerText = ss[1] + " TO " + ss[2];
                    document.getElementById("row5").style.display = "none";
                    document.getElementById("row6").style.display = "none";
                    document.getElementById("row7").style.display = "none";
                    document.getElementById("row8").style.display = "none";
                    document.getElementById("row10").style.display = "table-row";
                    document.getElementById("row11").style.display = "table-row";
                    document.getElementById("row12").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_compen").innerText = " Compensatory "
                    document.getElementById(cont[0] + "lbl_tour").innerText = " Tour "
                    document.getElementById(cont[0] + "lbl_early").innerText = " Early Going "
                    document.getElementById("row13").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_attend").innerText = " Attendance "
                }
                if (ss[0] == 2) {
                    document.getElementById("row9").style.display = "table-row";
                    document.getElementById("row4").style.display = "table-row";
                    document.getElementById("row5").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_data1").innerText = ss[1] + " TO " + ss[2];//ss[1];
                    document.getElementById(cont[0] + "lbl_data2").innerText = ss[3] + " TO " + ss[4];//ss[2];
                    document.getElementById("row6").style.display = "none";
                    document.getElementById("row7").style.display = "none";
                    document.getElementById("row8").style.display = "none";
                    document.getElementById("row10").style.display = "table-row";
                    document.getElementById("row11").style.display = "table-row";
                    document.getElementById("row12").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_compen").innerText = " Compensatory "
                    document.getElementById(cont[0] + "lbl_tour").innerText = " Tour "
                    document.getElementById(cont[0] + "lbl_early").innerText = " Early Going "
                    document.getElementById("row13").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_attend").innerText = " Attendance "
                }
                if (ss[0] == 3) {
                    document.getElementById("row9").style.display = "table-row";
                    document.getElementById("row4").style.display = "table-row";
                    document.getElementById("row5").style.display = "table-row";
                    document.getElementById("row6").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_data1").innerText = ss[1] + " TO " + ss[2];//ss[1];
                    document.getElementById(cont[0] + "lbl_data2").innerText = ss[3] + " TO " + ss[4];//ss[2];
                    document.getElementById(cont[0] + "lbl_data3").innerText = ss[5] + " TO " + ss[6];//ss[3];
                    document.getElementById("row7").style.display = "none";
                    document.getElementById("row8").style.display = "none";
                    document.getElementById("row10").style.display = "table-row";
                    document.getElementById("row11").style.display = "table-row";
                    document.getElementById("row12").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_compen").innerText = " Compensatory "
                    document.getElementById(cont[0] + "lbl_tour").innerText = " Tour "
                    document.getElementById(cont[0] + "lbl_early").innerText = " Early Going "
                    document.getElementById("row13").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_attend").innerText = " Attendance "
                }
                if (ss[0] == 4) {
                    document.getElementById("row9").style.display = "table-row";
                    document.getElementById("row4").style.display = "table-row";
                    document.getElementById("row5").style.display = "table-row";
                    document.getElementById("row6").style.display = "table-row";
                    document.getElementById("row7").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_data1").innerText = ss[1] + " TO " + ss[2];//ss[1];
                    document.getElementById(cont[0] + "lbl_data2").innerText = ss[3] + " TO " + ss[4];//ss[2];
                    document.getElementById(cont[0] + "lbl_data3").innerText = ss[5] + " TO " + ss[6];//ss[3];
                    document.getElementById(cont[0] + "lbl_data4").innerText = ss[7] + " TO " + ss[8];//ss[4];
                    document.getElementById("row8").style.display = "none";
                    document.getElementById("row10").style.display = "table-row";
                    document.getElementById("row11").style.display = "table-row";
                    document.getElementById("row12").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_compen").innerText = " Compensatory "
                    document.getElementById(cont[0] + "lbl_tour").innerText = " Tour "
                    document.getElementById(cont[0] + "lbl_early").innerText = " Early Going "
                    document.getElementById("row13").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_attend").innerText = " Attendance "
                }
                if (ss[0] == 5) {
                    document.getElementById("row9").style.display = "table-row";
                    document.getElementById("row4").style.display = "table-row";
                    document.getElementById("row5").style.display = "table-row";
                    document.getElementById("row6").style.display = "table-row";
                    document.getElementById("row7").style.display = "table-row";
                    document.getElementById("row8").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_data1").innerText = ss[1] + " TO " + ss[2];//ss[1];
                    document.getElementById(cont[0] + "lbl_data2").innerText = ss[3] + " TO " + ss[4];//ss[2];
                    document.getElementById(cont[0] + "lbl_data3").innerText = ss[5] + " TO " + ss[6];//ss[3];
                    document.getElementById(cont[0] + "lbl_data4").innerText = ss[7] + " TO " + ss[8];//ss[4];
                    document.getElementById(cont[0] + "lbl_data5").innerText = ss[9] + " TO " + ss[10];//ss[5];
                    document.getElementById("row10").style.display = "table-row";
                    document.getElementById("row11").style.display = "table-row";
                    document.getElementById("row12").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_compen").innerText = " Compensatory "
                    document.getElementById(cont[0] + "lbl_tour").innerText = " Tour "
                    document.getElementById(cont[0] + "lbl_early").innerText = " Early Going "
                    document.getElementById("row13").style.display = "table-row";
                    document.getElementById(cont[0] + "lbl_attend").innerText = " Attendance "
                }



            }
            else if (gg[0] == 3) {
                document.getElementById(cont[0] + "lbl_err").innerText = " Check the Application No Entered is Cleared or Not";
                document.getElementById("txt_applnname").value = '';
                document.getElementById(cont[0] + "txt_applnno").value = ""
                document.getElementById(cont[0] + "txt_applnno").focus();

            }
            else if (gg[0] == 4) {
                document.getElementById(cont[0] + "lbl_err").innerText = "Application No does not exist"
                document.getElementById("txt_applnname").value = '';
                document.getElementById(cont[0] + "txt_applnno").value = ""
                document.getElementById(cont[0] + "txt_applnno").focus();
            }
            else if (gg[0] == 5) {
                document.getElementById(cont[0] + "lbl_err").innerText = "Application No does not exist"
                document.getElementById("txt_applnname").value = '';
                document.getElementById(cont[0] + "txt_applnno").value = ""
                document.getElementById(cont[0] + "txt_applnno").focus();
            }
            else if (gg[0] == 6) {
                document.getElementById(cont[0] + "lbl_err").innerText = "Entrollment Already Done"
                document.getElementById("txt_applnname").value = '';
                document.getElementById(cont[0] + "txt_applnno").value = ""
                document.getElementById(cont[0] + "txt_applnno").focus();
            }
            else if (gg[0] == 7) {
                document.getElementById(cont[0] + "lbl_err").innerText = "This Application Is Not Ready For Enrollment"
                document.getElementById("txt_applnname").value = '';
                document.getElementById(cont[0] + "txt_applnno").value = ""
                document.getElementById(cont[0] + "txt_applnno").focus();
            }
            //else if (gg[0] == 9) {


            //    var confirmre = confirm("Rejoining Case!Do you want to continue")
            //    if (confirmre) {

            //        AppliDetails();
            //        return true;

            //    }
            //    else {


            //        return false;
            //    }

                function AppliDetails() {
                    debugger;
                    document.getElementById(cont[0] + "lbl_err").innerText = '';
                    document.getElementById(cont[0] + "hid_appln_no").value = document.getElementById(cont[0] + "txt_applnno").value;
                    call_server("3$" + document.getElementById(cont[0] + "hid_appln_no").value);
                }


        }

            function isNumberKey(evt) {
                var charCode = evt.which ? evt.which : evt.keyCode;
                // Allow only numbers (48-57 are ASCII codes for 0-9)
                if (charCode >= 48 && charCode <= 57) {
                    return true;
                }
                return false;
            }

       
        //function showrow() {
        //    debugger;
        //    if (document.getElementById("rdb_sec_yes").checked == true) {
        //        document.getElementById("row1").style.display = "table-row";
        //        document.getElementById("row2").style.display = "table-row";
        //        document.getElementById(cont[0] + "hid_security").value = "T";
        //        //ADDED T AND F FOR HID_SECURITTY KRISHNADAS
        //    }
        //    else if (document.getElementById("rdb_sec_no").checked == true) {
        //        document.getElementById("row1").style.display = "none";
        //        document.getElementById("row2").style.display = "none";
        //        document.getElementById(cont[0] + "hid_security").value = "F";
        //    }
        //}
        //function showbondrow() {
        //    if (document.getElementById(cont[0] + "cmb_bond").value == 2) {
        //        document.getElementById("row3").style.display = "table-row";
        //    }
        //    else {
        //        document.getElementById("row3").style.display = "none";
        //    }
        //}

        function correct(a) {
            var v;
            debugger;
            v = document.getElementById(cont[0] + a).value
            if (isNaN(v)) {
                document.getElementById(cont[0] + a).value = ""
                document.getElementById(cont[0] + a).focus()
            }
        }

        function ValidateNumber(a, b) {// 
            debugger;
            if (window.event.keyCode == 46) {
                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
            if (document.getElementById(cont[0] + a).value.length >= b) {
                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
            var txt = document.getElementById(cont[0] + a);
            if (!(((window.event.keyCode >= 48) || (window.event.keyCode == 46)) && (window.event.keyCode <= 57))) {
                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
            else {
                if (window.event.keyCode == 46) {
                    if (txt.value.indexOf(".") < 0) {
                        if (txt.value.length > 7) {
                            window.event.cancelBubble = true;
                            window.event.keyCode = 0;
                            alert("7 digits only allowed before decimal");
                            txt.focus();
                            return false;
                        }
                    }
                    else {
                        window.event.cancelBubble = true;
                        window.event.keyCode = 0;
                        alert("only one decimal allowed");
                        txt.focus();
                        return false;
                    }
                }
                else {
                    if (txt.value.indexOf(".") >= 0) {
                        var str = txt.value.substring(txt.value.indexOf(".") + 1);
                        if (str.length >= 2) {
                            window.event.cancelBubble = true;
                            window.event.keyCode = 0;
                            alert("Maximum 2 digits only allowed after decimal");
                            txt.focus();
                        }
                    }
                }

            }
        }

            function datechk(a) {
                document.getElementById(cont[0] + a).value = ""
                document.getElementById(cont[0] + a).focus()

            }
            function check_date(Control) {
                var day1, day2;
                var month1, month2;
                var year1, year2;
                if (document.getElementById(cont[0] + Control).value != "") {
                    var value1 = document.getElementById(cont[0] + Control).value;
                    var dt = new Date().format("dd/MMM/yyyy");
                    var value2 = dt;

                    day1 = value1.substring(0, value1.indexOf("/"));
                    month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                    year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                    day2 = value2.substring(0, value2.indexOf("/"));
                    month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                    year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                    date1 = year1 + "/" + month1 + "/" + day1;
                    date2 = year2 + "/" + month2 + "/" + day2;

                    firstDate = Date.parse(date1)
                    secondDate = Date.parse(date2)

                    msPerDay = 24 * 60 * 60 * 1000

                    dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                    if (dbd > 0) {
                        alert("Please Do Not Enter Past Date ..!!")
                        document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
                        document.getElementById(cont[0] + Control).focus();
                        return false;
                    }
                }

            } 
            function checkMonthLimit(input) {
                var value = parseInt(input.value, 10);
                if (value > 12) {
                    alert("The apprenticeship period cannot exceed 12 months.");
                    input.value = ""; // clear the field
                }
            }

        //........................Edited by Megha on 5/10/2015......ReqID-10497............................................
            

        function check_value1() {
            debugger;

            if (document.getElementById(cont[0] + "cmb_rec1").value == document.getElementById(cont[0] + "cmb_sanct1").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec1").value = -1
                return false;
            }
        }

        function check_value2() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec2").value == document.getElementById(cont[0] + "cmb_sanct2").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec2").value = -1
                return false;
            }
        }
        function check_value3() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec3").value == document.getElementById(cont[0] + "cmb_sanct3").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec3").value = -1
                return false;
            }
        }
        function check_value4() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec4").value == document.getElementById(cont[0] + "cmb_sanct4").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec4").value = -1
                return false;
            }
        }
        function check_value5() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec5").value == document.getElementById(cont[0] + "cmb_sanct5").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec5").value = -1
                return false;
            }
        }
        function check_value6() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec6").value == document.getElementById(cont[0] + "cmb_sanct6").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec6").value = -1
                return false;
            }
        }
        function check_value7() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec7").value == document.getElementById(cont[0] + "cmb_sanct7").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec7").value = -1
                return false;
            }
        }
        function check_value8() {
            debugger;
            if (document.getElementById(cont[0] + "cmb_rec8").value == document.getElementById(cont[0] + "cmb_sanct8").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec8").value = -1
                return false;
            }
        }
        function check_value9() {
            debugger;

            if (document.getElementById(cont[0] + "cmb_rec9").value == document.getElementById(cont[0] + "cmb_sanct9").value) {
                alert(' Recommended Employee should not be Sanctioned Employee');
                document.getElementById(cont[0] + "cmb_rec9").value = -1
                return false;
            }
        }




        function checkbefore() {
            debugger;


            var datas;
            var others;

           
            var applnInput = document.getElementById('<%= txt_applnno.ClientID %>');

            if (applnInput.value.trim() === "") {
                alert("Please enter the Application Number!!!!");
                return false;
            }
            
            
            if (num == 1) {
                datas = document.getElementById(cont[0] + "lbl_data1").innerText + "@" + document.getElementById(cont[0] + "cmb_rec1").value + "*" + document.getElementById(cont[0] + "cmb_sanct1").value
                others = document.getElementById(cont[0] + "cmb_rec6").value + "*" + document.getElementById(cont[0] + "cmb_sanct6").value + "*" + document.getElementById(cont[0] + "cmb_rec7").value + "*" + document.getElementById(cont[0] + "cmb_sanct7").value + "*" + document.getElementById(cont[0] + "cmb_rec8").value + "*" + document.getElementById(cont[0] + "cmb_sanct8").value + "*" + document.getElementById(cont[0] + "cmb_rec9").value + "*" + document.getElementById(cont[0] + "cmb_sanct9").value

                if ((document.getElementById(cont[0] + "cmb_rec1").value == -1) || (document.getElementById(cont[0] + "cmb_rec6").value == -1) || (document.getElementById(cont[0] + "cmb_rec7").value == -1) || (document.getElementById(cont[0] + "cmb_rec8").value == -1) || (document.getElementById(cont[0] + "cmb_rec9").value == -1) || (document.getElementById(cont[0] + "cmb_sanct1").value == -1) || (document.getElementById(cont[0] + "cmb_sanct6").value == -1) || (document.getElementById(cont[0] + "cmb_sanct7").value == -1) || (document.getElementById(cont[0] + "cmb_sanct8").value == -1) || (document.getElementById(cont[0] + "cmb_sanct9").value == -1)) {
                    alert('Please Select Recommendation/Sanction Details Correctly');
                    return false;
                }

            }
            else if (num == 2) {
                datas = document.getElementById(cont[0] + "lbl_data1").innerText + "@" + document.getElementById(cont[0] + "cmb_rec1").value + "*" + document.getElementById(cont[0] + "cmb_sanct1").value + "#" + document.getElementById(cont[0] + "lbl_data2").innerText + "@" + document.getElementById(cont[0] + "cmb_rec2").value + "*" + document.getElementById(cont[0] + "cmb_sanct2").value
                others = document.getElementById(cont[0] + "cmb_rec6").value + "*" + document.getElementById(cont[0] + "cmb_sanct6").value + "*" + document.getElementById(cont[0] + "cmb_rec7").value + "*" + document.getElementById(cont[0] + "cmb_sanct7").value + "*" + document.getElementById(cont[0] + "cmb_rec8").value + "*" + document.getElementById(cont[0] + "cmb_sanct8").value + "*" + document.getElementById(cont[0] + "cmb_rec9").value + "*" + document.getElementById(cont[0] + "cmb_sanct9").value

                if ((document.getElementById(cont[0] + "cmb_rec1").value == -1) || (document.getElementById(cont[0] + "cmb_rec2").value == -1) || (document.getElementById(cont[0] + "cmb_rec6").value == -1) || (document.getElementById(cont[0] + "cmb_rec7").value == -1) || (document.getElementById(cont[0] + "cmb_rec8").value == -1) || (document.getElementById(cont[0] + "cmb_rec9").value == -1) || (document.getElementById(cont[0] + "cmb_sanct1").value == -1) || (document.getElementById(cont[0] + "cmb_sanct2").value == -1) || (document.getElementById(cont[0] + "cmb_sanct6").value == -1) || (document.getElementById(cont[0] + "cmb_sanct7").value == -1) || (document.getElementById(cont[0] + "cmb_sanct8").value == -1) || (document.getElementById(cont[0] + "cmb_sanct9").value == -1)) {
                    alert('Please Select Recommendation/Sanction Details Correctly');
                    return false;
                }


            }
            else if (num == 3) {
                datas = document.getElementById(cont[0] + "lbl_data1").innerText + "@" + document.getElementById(cont[0] + "cmb_rec1").value + "*" + document.getElementById(cont[0] + "cmb_sanct1").value + "#" + document.getElementById(cont[0] + "lbl_data2").innerText + "@" + document.getElementById(cont[0] + "cmb_rec2").value + "*" + document.getElementById(cont[0] + "cmb_sanct2").value + "#" + document.getElementById(cont[0] + "lbl_data3").innerText + "@" + document.getElementById(cont[0] + "cmb_rec3").value + "*" + document.getElementById(cont[0] + "cmb_sanct3").value
                others = document.getElementById(cont[0] + "cmb_rec6").value + "*" + document.getElementById(cont[0] + "cmb_sanct6").value + "*" + document.getElementById(cont[0] + "cmb_rec7").value + "*" + document.getElementById(cont[0] + "cmb_sanct7").value + "*" + document.getElementById(cont[0] + "cmb_rec8").value + "*" + document.getElementById(cont[0] + "cmb_sanct8").value + "*" + document.getElementById(cont[0] + "cmb_rec9").value + "*" + document.getElementById(cont[0] + "cmb_sanct9").value

                if ((document.getElementById(cont[0] + "cmb_rec1").value == -1) || (document.getElementById(cont[0] + "cmb_rec2").value == -1) || (document.getElementById(cont[0] + "cmb_rec3").value == -1) || (document.getElementById(cont[0] + "cmb_rec6").value == -1) || (document.getElementById(cont[0] + "cmb_rec7").value == -1) || (document.getElementById(cont[0] + "cmb_rec8").value == -1) || (document.getElementById(cont[0] + "cmb_rec9").value == -1) || (document.getElementById(cont[0] + "cmb_sanct1").value == -1) || (document.getElementById(cont[0] + "cmb_sanct2").value == -1) || (document.getElementById(cont[0] + "cmb_sanct3").value == -1) || (document.getElementById(cont[0] + "cmb_sanct6").value == -1) || (document.getElementById(cont[0] + "cmb_sanct7").value == -1) || (document.getElementById(cont[0] + "cmb_sanct8").value == -1) || (document.getElementById(cont[0] + "cmb_sanct9").value == -1)) {
                    alert('Please Select Recommendation/Sanction Details Correctly');
                    return false;
                }

            }
            else if (num == 4) {
                datas = document.getElementById(cont[0] + "lbl_data1").innerText + "@" + document.getElementById(cont[0] + "cmb_rec1").value + "*" + document.getElementById(cont[0] + "cmb_sanct1").value + "#" + document.getElementById(cont[0] + "lbl_data2").innerText + "@" + document.getElementById(cont[0] + "cmb_rec2").value + "*" + document.getElementById(cont[0] + "cmb_sanct2").value + "#" + document.getElementById(cont[0] + "lbl_data3").innerText + "@" + document.getElementById(cont[0] + "cmb_rec3").value + "*" + document.getElementById(cont[0] + "cmb_sanct3").value + "#" + document.getElementById(cont[0] + "lbl_data4").innerText + "@" + document.getElementById(cont[0] + "cmb_rec4").value + "*" + document.getElementById(cont[0] + "cmb_sanct4").value
                others = document.getElementById(cont[0] + "cmb_rec6").value + "*" + document.getElementById(cont[0] + "cmb_sanct6").value + "*" + document.getElementById(cont[0] + "cmb_rec7").value + "*" + document.getElementById(cont[0] + "cmb_sanct7").value + "*" + document.getElementById(cont[0] + "cmb_rec8").value + "*" + document.getElementById(cont[0] + "cmb_sanct8").value + "*" + document.getElementById(cont[0] + "cmb_rec9").value + "*" + document.getElementById(cont[0] + "cmb_sanct9").value

                if ((document.getElementById(cont[0] + "cmb_rec1").value == -1) || (document.getElementById(cont[0] + "cmb_rec2").value == -1) || (document.getElementById(cont[0] + "cmb_rec3").value == -1) || (document.getElementById(cont[0] + "cmb_rec4").value == -1) || (document.getElementById(cont[0] + "cmb_rec6").value == -1) || (document.getElementById(cont[0] + "cmb_rec7").value == -1) || (document.getElementById(cont[0] + "cmb_rec8").value == -1) || (document.getElementById(cont[0] + "cmb_rec9").value == -1) || (document.getElementById(cont[0] + "cmb_sanct1").value == -1) || (document.getElementById(cont[0] + "cmb_sanct2").value == -1) || (document.getElementById(cont[0] + "cmb_sanct3").value == -1) || (document.getElementById(cont[0] + "cmb_sanct4").value == -1) || (document.getElementById(cont[0] + "cmb_sanct6").value == -1) || (document.getElementById(cont[0] + "cmb_sanct7").value == -1) || (document.getElementById(cont[0] + "cmb_sanct8").value == -1) || (document.getElementById(cont[0] + "cmb_sanct9").value == -1)) {
                    alert('Please Select Recommendation/Sanction Details Correctly');
                    return false;
                }

            }
            else if (num == 5) {
                datas = document.getElementById(cont[0] + "lbl_data1").innerText + "@" + document.getElementById(cont[0] + "cmb_rec1").value + "*" + document.getElementById(cont[0] + "cmb_sanct1").value + "#" + document.getElementById(cont[0] + "lbl_data2").innerText + "@" + document.getElementById(cont[0] + "cmb_rec2").value + "*" + document.getElementById(cont[0] + "cmb_sanct2").value + "#" + document.getElementById(cont[0] + "lbl_data3").innerText + "@" + document.getElementById(cont[0] + "cmb_rec3").value + "*" + document.getElementById(cont[0] + "cmb_sanct3").value + "#" + document.getElementById(cont[0] + "lbl_data4").innerText + "@" + document.getElementById(cont[0] + "cmb_rec4").value + "*" + document.getElementById(cont[0] + "cmb_sanct4").value + "#" + document.getElementById(cont[0] + "lbl_data5").innerText + "@" + document.getElementById(cont[0] + "cmb_rec5").value + "*" + document.getElementById(cont[0] + "cmb_sanct5").value
                others = document.getElementById(cont[0] + "cmb_rec6").value + "*" + document.getElementById(cont[0] + "cmb_sanct6").value + "*" + document.getElementById(cont[0] + "cmb_rec7").value + "*" + document.getElementById(cont[0] + "cmb_sanct7").value + "*" + document.getElementById(cont[0] + "cmb_rec8").value + "*" + document.getElementById(cont[0] + "cmb_sanct8").value + "*" + document.getElementById(cont[0] + "cmb_rec9").value + "*" + document.getElementById(cont[0] + "cmb_sanct9").value

                if ((document.getElementById(cont[0] + "cmb_rec1").value == -1) || (document.getElementById(cont[0] + "cmb_rec2").value == -1) || (document.getElementById(cont[0] + "cmb_rec3").value == -1) || (document.getElementById(cont[0] + "cmb_rec4").value == -1) || (document.getElementById(cont[0] + "cmb_rec5").value == -1) || (document.getElementById(cont[0] + "cmb_rec6").value == -1) || (document.getElementById(cont[0] + "cmb_rec7").value == -1) || (document.getElementById(cont[0] + "cmb_rec8").value == -1) || (document.getElementById(cont[0] + "cmb_rec9").value == -1) || (document.getElementById(cont[0] + "cmb_sanct1").value == -1) || (document.getElementById(cont[0] + "cmb_sanct2").value == -1) || (document.getElementById(cont[0] + "cmb_sanct3").value == -1) || (document.getElementById(cont[0] + "cmb_sanct4").value == -1) || (document.getElementById(cont[0] + "cmb_sanct5").value == -1) || (document.getElementById(cont[0] + "cmb_sanct6").value == -1) || (document.getElementById(cont[0] + "cmb_sanct7").value == -1) || (document.getElementById(cont[0] + "cmb_sanct8").value == -1) || (document.getElementById(cont[0] + "cmb_sanct9").value == -1)) {
                    alert('Please Select Recommendation/Sanction Details Correctly');
                    return false;
                }


            }
            document.getElementById(cont[0] + "hid_datas").value = datas
            document.getElementById(cont[0] + "hid_others").value = others



            //..................................................*Megha................................................
         





            if (document.getElementById(cont[0] + "lbl_err").innerText != '') {
                alert('Please Enter Application No Correctly');
                return false;
            }
            if (document.getElementById(cont[0] + "txt_applnno").value == '') {
                alert('Please Enter Application Number');
                document.getElementById(cont[0] + "txt_applnno").focus();
                return false;
            }
            if (document.getElementById("rdb_sec_yes").checked == true) {
                if (parseInt(document.getElementById(cont[0] + "txt_sec").value) != (parseInt(document.getElementById(cont[0] + "txt_dep").value) + parseInt(document.getElementById(cont[0] + "txt_installments").value) * parseInt(document.getElementById(cont[0] + "txt_installment_amount").value))) {
                    alert('Please Enter Security Deposit Details Correctly');
                    return false;
                }
                if (document.getElementById(cont[0] + "txt_sec").value == '') {
                    alert('Please Enter Security Deposit');
                    document.getElementById(cont[0] + "txt_sec").focus();
                    return false;
                }
                if (document.getElementById(cont[0] + "txt_installments").value == '') {
                    alert('Please Enter Installment');
                    document.getElementById(cont[0] + "txt_installments").focus();
                    return false;
                }

                if (document.getElementById(cont[0] + "txt_dep").value == '') {
                    alert('Please Enter Deposit Amount');
                    document.getElementById(cont[0] + "txt_dep").focus();
                    return false;
                }

                if (document.getElementById(cont[0] + "txt_installment_amount").value == '') {
                    alert('Please Enter Installment');
                    document.getElementById(cont[0] + "txt_installment_amount").focus();
                    return false;
                }
            }


            //sreeetxt_period
            if (document.getElementById(cont[0] + "txt_period").value == '') {
                alert('Please Enter Period');
                document.getElementById(cont[0] + "txt_period").focus();
                return false;
            }



            if (document.getElementById(cont[0] + "txt_jodt").value == '') {
                alert('Please Enter Join Date');
                document.getElementById(cont[0] + "txt_jodt").focus();
                return false;
            }
              
              if((document.getElementById("rdb_vda_yes").checked==false) && (document.getElementById("rdb_vda_no").checked==false))
              { 
                alert('Please Select VDA');
                return false;
              }
                if ((document.getElementById("rdb_esi_yes").checked == false) && (document.getElementById("rdb_esi_no").checked == false)) {
                    alert('Please Select ESI');
                    return false;
                }
                if ((document.getElementById("rdb_medi_yes").checked == false) && (document.getElementById("rdb_medi_no").checked == false)) {
                    alert('Please Select Mediclaim');
                    return false;
                }
                if ((document.getElementById("rdb_sec_yes").checked == false) && (document.getElementById("rdb_sec_no").checked == false)) {
                    alert('Please Select Security Deposit');
                    return false;
                }
                if ((document.getElementById("rdb_pf_yes").checked == false) && (document.getElementById("rdb_pf_no").checked == false)) {
                    alert('Please Select PF');
                    return false;
                }

                if (document.getElementById(cont[0] + "cmb_bond").value == 2) {
                    if ((document.getElementById(cont[0] + "txt_bond") == '') || (document.getElementById(cont[0] + "txt_bond_period") == '')) {
                        alert('Please Enter Bond ');
                        return false;
                    }
                }

            }
            function Button1_onclick() {
                window.open('../../home.aspx', '_self')
            }

        // ]]>
        </script>
   <div style="text-align: center">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy" targetcontrolid="txt_jodt"></cc1:calendarextender>
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
    <br />
  
    <br />
    <asp:Label ID="lbl_err" runat="server" Height="24px" Width="642px" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label><br />
    <table id="tblApprenticeForm" style="width: 1000px;">
        <tr>
            <td colspan="3" style="text-align: right">Application&nbsp;No :
            </td>
            <td colspan="3" style="text-align: left">
                <input id="txt_applnno" onkeypress = "return isNumberKey(event);" style="width: 241px" onchange="return fillname()  " type="text" runat="server" maxlength="8" />
            
            </td>
        </tr>
        <tr>
             <td style="height: 23px;text-align:left;">Name</td>
 <td colspan="2" style="height: 23px; text-align: left">
     <input id="txt_applnname" style="width: 241px" type="text" readonly="readOnly" /></td>

            <td style="width: 154px; text-align: left">Employee&nbsp;Type :</td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_type" onchange="return vdafill()" runat="server" Width="250px">
                    <asp:ListItem Value="6">APPRENTICE</asp:ListItem>
             
                </asp:DropDownList></td>
           
        </tr>
        <tr>
             <td style="width: 5762px; text-align: left">Period (Months) :</td>
 <td style="text-align: left" colspan="2">
     <input id="txt_period" onkeypress = "return isNumberKey(event);" oninput="checkMonthLimit(this)"  style="width: 250px" type="text" runat="server" maxlength="2" /></td>
            <td style="width: 154px; text-align: left">Firm :
            </td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_firm" runat="server" Width="250px">
                </asp:DropDownList></td>
           
        </tr>
        <tr>
             <td style="width: 5762px; text-align: left">Join&nbsp;Date :
 </td>
 <td style="text-align: left" colspan="2">
     <asp:TextBox ID="txt_jodt" runat="server" onkeyup="datechk('txt_jodt')" onblur="check_date('txt_jodt')" Width="250px"></asp:TextBox></td>
            <td style="width: 154px; text-align: left">Department :
            </td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_dep" runat="server" Width="250px">
                </asp:DropDownList></td>
           
        </tr>

        <tr>
             <td style="width: 5762px; text-align: left">Designation :</td>
 <td style="text-align: left" colspan="2">
     <asp:DropDownList ID="cmb_desigation" runat="server" Width="250px">
     </asp:DropDownList></td>
            <td style="width: 154px; text-align: left">Category&nbsp;:</td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cat_drop" onchange="basicfill()" runat="server" Width="250px">
                </asp:DropDownList></td>

           

        </tr>
        <tr>
             <td style="width: 5762px; text-align: left">Apprentice Sal :</td>
 <td style="text-align: left" colspan="2">
     <input id="sal" readonly="readOnly" style="width: 250px" type="text"   /></td>
            <td style="width: 5762px; text-align: left">Apprentice Amount :</td>
            <td style="text-align: left" colspan="2">
                <input id="Amt"   readonly="readOnly" style="width: 250px" type="text"  /></td>

        </tr>




        <%-- -------------------------------------new---------------------------------------------------------%>


        <tr id="row9" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
            <td>
                <asp:Label ID="lbl_head1" runat="server" Text="Leave days"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center;">
                <asp:Label ID="lbl_head2" runat="server" Text="Recommendation"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:Label ID="lbl_head3" runat="server" Text="Sanction"></asp:Label>
            </td>
        </tr>


        <tr id="row4">
            <td style="height: 26px">
                <asp:Label ID="lbl_data1" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 26px; text-align: center">
                <asp:DropDownList ID="cmb_rec1" runat="server" Width="328px" onchange="check_value1()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 26px; text-align: left">
                <asp:DropDownList ID="cmb_sanct1" runat="server" Width="328px" onchange="check_value1()">
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="row5">
            <td>
                <asp:Label ID="lbl_data2" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec2" runat="server" Width="328px" onchange="check_value2()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct2" runat="server" Width="328px" onchange="check_value2()">
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="row6">
            <td>
                <asp:Label ID="lbl_data3" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec3" runat="server" Width="328px" onchange="check_value3()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct3" runat="server" Width="328px" onchange="check_value3()">
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="row7">
            <td>
                <asp:Label ID="lbl_data4" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec4" runat="server" Width="328px" onchange="check_value4()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct4" runat="server" Width="328px" onchange="check_value4()">
                </asp:DropDownList>
            </td>
        </tr>


        <tr id="row8">
            <td>
                <asp:Label ID="lbl_data5" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec5" runat="server" Width="328px" onchange="check_value5()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct5" runat="server" Width="328px" onchange="check_value5()">
                </asp:DropDownList>
            </td>
        </tr>


        <tr id="row10">
            <td style="height: 26px">
                <asp:Label ID="lbl_compen" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 26px; text-align: center">
                <asp:DropDownList ID="cmb_rec6" runat="server" Width="328px" onchange="check_value6()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 26px; text-align: left">
                <asp:DropDownList ID="cmb_sanct6" runat="server" Width="328px" onchange="check_value6()">
                </asp:DropDownList>
            </td>

        </tr>
        <tr id="row11">
            <td>
                <asp:Label ID="lbl_tour" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec7" runat="server" Width="328px" onchange="check_value7()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct7" runat="server" Width="328px" onchange="check_value7()">
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="row12">
            <td>
                <asp:Label ID="lbl_early" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec8" runat="server" Width="328px" onchange="check_value8()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct8" runat="server" Width="328px" onchange="check_value8()">
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="row13">
            <td>
                <asp:Label ID="lbl_attend" runat="server"></asp:Label>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: center">
                <asp:DropDownList ID="cmb_rec9" runat="server" Width="328px" onchange="check_value9()">
                </asp:DropDownList>
            </td>
            <td colspan="3" style="font-size: medium; font-family: Verdana; height: 3px; text-align: left">
                <asp:DropDownList ID="cmb_sanct9" runat="server" Width="328px" onchange="check_value9()">
                </asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td style="width: 154px; height: 14px; text-align: left">&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td colspan="2" style="height: 14px; text-align: right">
                <asp:Button ID="cmd_confirm" runat="server" OnClientClick="return checkbefore()"  Text="CONFIRM" style="width:130px; height:32px;" /></td>
            <td style=" height: 14px; text-align: right">
                <input id="Button1" type="button" value="EXIT" onclick="return Button1_onclick()" style="width:130px; height:32px;" /></td>
            <td style="height: 14px; text-align: left" colspan="2">&nbsp;&nbsp;
            </td>
        </tr>
    </table>

    <input id="hid1" runat="server" style="width: 11px" type="hidden" />
    <input id="hid2" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_da" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_appln_no" runat="server" style="width: 11px" type="hidden" />
    <br />

    <input id="hid_datas" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_others" runat="server" style="width: 11px" type="hidden" />


</div>
</asp:Content>
