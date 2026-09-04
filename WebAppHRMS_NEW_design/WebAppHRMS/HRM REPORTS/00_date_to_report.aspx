<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="00_date_to_report.aspx.vb" Inherits="WebAppHRMS.RAT_LIFE_INSURANCE_00_date_to_report_299d56d49883" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        var cont_name = header.split("txt");
        function btn_generate_onclick() {
            isValidDate('txt_from');
            isValidDate('txt_to');
            var From = document.getElementById(cont_name[0] + "txt_from").value
            var To = document.getElementById(cont_name[0] + "txt_to").value
            window.open('TrainingZonal.aspx?from_dt=' + From + '&to_dt=' + To + '', '_self');
        }
        function isValidDate(ctrl) // Server Control Only
        {
            var s = document.getElementById(cont_name[0] + ctrl).value;
            var dateFormat = /^\d{1,4}[\.|\/|-]\d{1,2}[\.|\/|-]\d{1,4}$/;// format D(D)/M(M)/(YY)YY
            if (dateFormat.test(s)) {
                s = s.replace(/0*(\d*)/gi, "$1");// remove any leading zeros from date values
                var dateArray = s.split("/");
                if (Math.abs(dateArray.length) != 3) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                }
                dateArray[1] = dateArray[1] - 1;// correct month value
                // Digit Check In Year
                if (dateArray[2].length != 4) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                    return false;
                }
                // correct year value
                if (dateArray[2].length < 4)
                    dateArray[2] = (parseInt(dateArray[2]) < 50) ? 2000 + parseInt(dateArray[2]) : 1900 + parseInt(dateArray[2]);
                var testDate = new Date(dateArray[2], dateArray[1], dateArray[0]);
                if (testDate.getDate() != dateArray[0] || testDate.getMonth() != dateArray[1] || testDate.getFullYear() != dateArray[2]) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                }
                else
                    return true;
            }
            else {
                alert("Incorrect Date Format!");
                document.getElementById(cont_name[0] + ctrl).focus();
                return false;
            }
        }
        function btn_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
    </script>
    <div style="text-align: center">
        <table border="1" style="width: 40%; font-family: 'Book Antiqua';">
            <tr>
                <td style="width: 50%">
                    <span>From</span></td>
                <td style="width: 50%">To</td>
            </tr>
            <tr>
                <td style="width: 50%">
                    <input id="txt_from" type="text" runat="server" style="text-align: center" size="10" /></td>
                <td style="width: 50%">
                    <input id="txt_to" type="text" runat="server" style="text-align: center" size="10" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="font-size: 10pt; color: #ff3333">* Format dd/mm/yyyy<input id="hid_option_id"
                        runat="server" style="width: 5px" type="hidden" /></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="btn_generate" style="width: 95px; cursor: hand; font-family: 'Book Antiqua'"
                        type="button" value="Generate" onclick="return btn_generate_onclick()" />
                    <input id="btn_exit" style="width: 95px; cursor: hand; font-family: 'Book Antiqua'; height: 25px"
                        type="button" value="Exit" onclick="return btn_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

