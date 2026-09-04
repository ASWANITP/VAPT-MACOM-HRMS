<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rej_res.aspx.vb" Inherits="WebAppHRMS.leave_rej_res_bf15cd911896" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button1_onclick() {
            if ((document.getElementById("txt_rej").value) != "") {

                opener.document.forms[0].ctl00_cph_edp_hid_rej.value = document.getElementById("txt_rej").value;
                opener.document.forms[0].action = "Leave_sanction_New.aspx"
                window.opener.cmd_reject_onclick()
                window.close("rej_res.aspx");

                return true;
            }
            else {
                alert("Enter Reason ")
                return false;
            }
        }

        function window_onload() {
            document.getElementById("txt_rej").focus();
        }
        function okonkeydown() {

            if (window.event.keyCode == 13) btnOK_onclick();
        }
        // ]]>
    </script>
</head>
<body onload="return window_onload()">
    <form id="form1" runat="server" style="background-color: antiquewhite">
        <div>
            <div style="text-align: left">
                <br />
                <table>
                    <tr>
                        <td style="width: 213px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        Enter Reason for Reject :
                        </td>
                        <td style="width: 100px">
                            <input id="txt_rej" type="text" style="width: 453px; height: 21px;" maxlength="59" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; height: 26px;">
                            <input id="Button1" style="width: 60px" onkeypress="return okonkeydown()" type="button" value="OK" onclick="return Button1_onclick()" /></td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
