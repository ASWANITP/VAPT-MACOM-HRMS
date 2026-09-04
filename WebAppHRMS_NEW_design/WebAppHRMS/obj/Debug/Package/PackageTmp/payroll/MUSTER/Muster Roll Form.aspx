<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Muster Roll Form.aspx.vb" Inherits="WebAppHRMS.Muster_Roll_Form_99a97bd44507" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        //ok
        var con = header.split('TextBox');

        function DateCheck() {
            alert('Please select date using Calendar..');
            document.getElementById(con[0] + "TextBox1").value = "";
            return false;
        }


        function checkFdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(con[0] + Control).value != "") {
                var value1 = document.getElementById(con[0] + Control).value;
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
                if (dbd < 0) {
                    alert("Please Do Not Enter Future Date ..!!")
                    document.getElementById(con[0] + Control).value = '';
                    document.getElementById(con[0] + Control).focus();
                    return false;
                }
            }
        }

        function OnclickConfirm() {
            if (document.getElementById(con[0] + "TextBox1").value == "") {
                alert("Please Select the Date....!");
                document.getElementById(con[0] + "TextBox1").focus();
                return false;
            }
        }
    </script>
    <center>
        <span style="font-size: 14pt"><strong>..MUSTER ROLL..<br />

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                TargetControlID="TextBox1"></cc1:CalendarExtender>
            &nbsp;
        <br />
        </strong>
            <table style="font-weight: bold">
                <tr>
                    <td style="width: 189px">
                        <span style="font-size: 12pt">Select&nbsp; Month</span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox1" runat="server" onkeyup="DateCheck()" onblur="checkFdate('TextBox1')"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 189px"></td>
                    <td style="width: 100px">
                        <asp:Button ID="Button1" runat="server" Text="Confirm" Width="89px" OnClientClick="return OnclickConfirm()" /></td>
                </tr>
            </table>
        </span>
    </center>
</asp:Content>

