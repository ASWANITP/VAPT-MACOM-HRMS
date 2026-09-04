<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="approve_resign_mac_appr_modify.aspx.vb" Inherits="WebAppHRMS.approve_resign_mac_appr_modify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button2_onclick() {
            window.open('../../home.aspx', '_self');
        }
        function van() {
            debugger;
            alert("Please select date from calendar! ")
            return false;
        }

        function addDays(date, days) {
            var result = new Date(date); // Create a new date object
            result.setDate(result.getDate() + days); // Add days to the new date object
            return result;
        }
        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (str == ' ') {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }

        function changes(v) {
            debugger;
            var mm;
            parts = v.split('/');

            if (parts[1] == 'Jan') {
                mm = "01";
            }
            if (parts[1] == 'Feb') {
                mm = "02";
            }
            if (parts[1] == 'Mar') {
                mm = "03";
            }
            if (parts[1] == 'Apr') {
                mm = "04";
            }
            if (parts[1] == 'May') {
                mm = "05";
            }
            if (parts[1] == 'Jun') {
                mm = "06";
            }
            if (parts[1] == 'Jul') {
                mm = "07";
            }
            if (parts[1] == 'Aug') {
                mm = "08";
            }
            if (parts[1] == 'Sep') {
                mm = "09";
            }
            if (parts[1] == 'Oct') {
                mm = "10";
            }
            if (parts[1] == 'Nov') {
                mm = "11";
            }
            if (parts[1] == 'Dec') {
                mm = "12";
            }

            var parts1 = parts[2] + "-" + mm + "-" + parts[0];
            parts1 = parts1.split('-');
            var givenDate = new Date(parts1[0], parts1[1] - 1, parts1[2]);
            var givenDates = new Date(parts1[0] + '/' + parts1[1] + '/' + parts1[2]);
            var yyyy = new Date().getFullYear();
            var mmm = new Date().getMonth();
            if (mmm.toString.length == 1) {
                mmm = mmm + 1;
                mmm = "0" + mmm;
            }
            var dd = new Date().getDate();
            var todays = new Date(yyyy + '/' + mmm + '/' + dd)
            //if (givenDates < todays) {
            //    alert("YOU CANNOT ENTER BACK DATE IN RESIGNATION!!!");
            //    window.open('../../home.aspx', '_self');
            //    return false;
            //}
            var newDate = addDays(givenDate, 90);
            var endDate = newDate.toDateString();
            var month = endDate.substring(4, 7);
            month = month.trim();
            var day = endDate.substring(7, 10);
            day = day.trim();
            var year = endDate.substring(10, 15);
            year = year.trim();
            if (day.length == 1)
                day = "0" + day;
            var date_nw = day + '/' + month + '/' + year;
            document.getElementById(cs[0] + "TextBox2").value = date_nw;
            return false;


        }


        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (str == ' ') {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }

        function check_dt() {
            alert("Select Date From Calender")
            return false;
        }

        function van() {
            alert("Please select date from calendar! ")
            return false;
        }








      
        // ]]>
    </script>
    <script type="text/javascript">
        function showRejectReason() {
            document.getElementById('trRejectReason').style.display = '';
        }

        function hideRejectReason() {
            document.getElementById('trRejectReason').style.display = 'none';
        }
    </script>
    <div style="text-align: center">
        `<table border="1">
            <tr>
                <td colspan="4">
                    <strong>APPROVE RESIGNATION<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Select&nbsp;Employee</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:DropDownList ID="cmb_emp" runat="server" Width="582px" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 32px; text-align: left" colspan="4">
                                            <table border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 23px; text-align: left" colspan="2"><strong>Employee&nbsp;Code :</strong>
                                                            <asp:Label ID="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></td>
                                                        <td style="width: 392px; height: 23px; text-align: left" colspan="2"><strong>Employee&nbsp;Name :</strong>&nbsp;
                                                            <asp:Label ID="lbl_name" runat="server" Width="274px" Text="No Employee" ForeColor="Navy"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            &nbsp;&nbsp; </td>
                                    </tr>


                                                                        <tr>
    <td style="width: 2773px; height: 23px; text-align: left"><strong>Resignation&nbsp;Entered&nbsp;Date</strong></td>
    <td style="height: 23px; text-align: left" colspan="3">
        <asp:TextBox ID="Txt_rdt"  runat="server" ReadOnly="True" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="lbl1" runat="server" Width="580px"></asp:Label></td>
</tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Resigning&nbsp;Date</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rsdt" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Reason&nbsp;for&nbsp;Resigning</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rea" runat="server" Width="571px" ForeColor="MediumBlue" TextMode="MultiLine" Wrap="True" Height="58px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <asp:Panel ID="pnlRelievingDate" runat="server">
                                       <%-- <tr>
                                            <td style="width: 2773px; height: 23px; text-align: left"><strong>Select&nbsp;Relieving&nbsp;Date</strong></td>
                                            <td style="height: 23px; text-align: left" colspan="3">
                                                <asp:TextBox ID="Txt_rdt" onkeypress="return van()" runat="server" AutoPostBack="True"></asp:TextBox>
                                                <asp:Label ID="lbl1" runat="server" Width="580px"></asp:Label></td>
                                        </tr>--%>
                                    </asp:Panel>
                                </tbody>
                            </table>
<%--                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_rdt"></cc1:CalendarExtender>--%>
                            &nbsp;&nbsp;&nbsp; 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px">
                    <table border="0">
                      <div>
                        <tr>
                            <%--<td style="width: 193px; height: 13px; text-align: left;">
    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>Reject&nbsp;Reason </strong></span>
</td>--%>

                            <td style="width: 162px; height: 13px; text-align: left;">
    <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>
        <asp:Label ID="Label1" runat="server" Text="REJECTED REASON"></asp:Label></strong></span></td>
                                                       <td style="text-align: left; height: 13px;" colspan="3">
                               <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                   <asp:TextBox ID="Txt_rej" runat="server" Width="537px" MaxLength="60" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox></span></td>
                       </tr></div>
                        <div>
                        <tr>
                            <td style="width: 160px">&nbsp;&nbsp;
                    <input id="cmd_att" runat="server" type="button" value="View Attachment" /></td>

        <td style="width: 160px">&nbsp;&nbsp;
<input id="cmd_modify" runat="server" type="button" value="Modify Effect Date" /></td>

   <cc1:CalendarExtender ID="CalendarExtender"
     runat="server" Format="dd/MMM/yyyy" TargetControlID="TextBox1">     </cc1:CalendarExtender>

  <tr>
      <td align="left"  style="width: 24px;text-align: left; height: 5px;">
          <span style="color: #3300cc">
              <asp:Label ID="Label2" runat="server" Text="Resignation Notice Submitted Date"></asp:Label></span></td>
      <td align="left"  style="width: 11px;text-align: left; height: 5px;">
          <asp:TextBox ID="TextBox1" OnTextChanged="TextBox1_TextChanged"  AutoPostBack="true"  runat="server" Enabled="true"></asp:TextBox><br />
      </td>
      <td align="left"  style="width: 142px; height: 5px;">
          <span style="color: #0000cc">
              <asp:Label ID="Label3" runat="server" Text="When is your last day of work?"></asp:Label></span></td>
      <td align="left" style="width: 27px; height: 5px;">
          <asp:TextBox ID="TextBox2" runat="server" onkeypress="return van()"></asp:TextBox>&nbsp;</td>
  </tr>






                            <td style="width: 79px; text-align: center;">
                                <asp:Button ID="cmd_confirm" runat="server" Text="Approve" /></td>
                                                                                <td style="width: 79px; text-align: center;">
<asp:Button ID="new_reject" runat="server" Text="Reject" /></td>


                            <td style="width: 79px; text-align: center;">
    <asp:Button ID="cmd_reject" runat="server" Text="Reject" /></td>


                                                 
                            <td style="width: 122px; text-align: center;">
                               <%-- <input id="Button2" type="button" value="Exit" onclick="return showRejectReason()" style="width: 88px" /></td>--%>
                        
                                    <td style="width: 133px; text-align: center;">
            &nbsp;<input id="Button2" style="width: 76px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>

                            <td style="width: 128px">&nbsp;
                            </td>
                        </tr>
                       </div>
                    </table>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
