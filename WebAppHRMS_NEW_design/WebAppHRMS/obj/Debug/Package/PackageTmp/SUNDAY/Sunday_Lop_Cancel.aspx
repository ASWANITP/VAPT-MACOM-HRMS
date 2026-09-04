<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Sunday_Lop_Cancel.aspx.vb" Inherits="WebAppHRMS.Sunday_Lop_Cancel_0346d3b82049" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cs = cont_name.split("txt");

        function Got_home() {
            window.open('../../home.aspx', '_self')
        }
        function cmd_exit_onclick() {
            Got_home()
        }






        // function checkerr()
        // {
        //  alert("Select Date From Calender");
        // document.getElementById(cs[0]+"txtlopFrom").value="";
        //    return false;
        // }

        function checkerrs() {
            alert("Select Date From Calender");
            document.getElementById(cs[0] + "txtlopToDate").value = "";
            return false;
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
            if (givenDate.toString().substring(0, 3) == "Sun") {
                document.getElementById(cs[0] + "hidLeaveFrom").value = givenDate;
                return true;
            }
            else {
                alert("You Can Only Select Sundays");
                document.getElementById(cs[0] + "txtlopFrom").value = "";
                return false;
            }
        }

        function addDays(date, days) {
            var result = new Date(date); // Create a new date object
            result.setDate(result.getDate() + days); // Add days to the new date object
            return result;
        }


        function check_dt(w) {
            debugger;
            var frdt = coverttodate(document.getElementById(cs[0] + "txtlopFrom").value);
            var todt = coverttodate(w);
            var newDate = addDays(frdt, 7);
            if ((todt > frdt) && (todt < newDate)) {
                //alert("correct");
                console.log("correct");

            }
            else {
                alert("Please select date before next sunday");
                document.getElementById(cs[0] + "txtlopToDate").value = "";
            }

        }


        function coverttodate(dt) {

            var mm;
            parts = dt.split('/');

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
            return givenDate;
        }




 </script>
    <div style="text-align: center">
        &nbsp;
    </div>
    <div style="text-align: center">





        <table border="1">
            <tr>
                <td colspan="3" style="font-weight: bold; height: 1px; width: 471px; text-align: center;">SUNDAY LOP CANCELLATION</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 1px; width: 471px;">
                    <table border="1" style="width: 473px">
                        <tr>
                            <td style="width: 100px; height: 24px;">
                                <asp:Label ID="Label1" runat="server" Text="Select Sunday worked:" Width="170px"></asp:Label></td>
                            <td style="width: 175px; height: 24px;">
                                <%-- <asp:TextBox ID="txtSundayWorked" runat="server" ></asp:TextBox> --%>

                                <%--<input type="date" id="birthday" name="birthday"/>--%>
                                <%-- <asp:TextBox ID="TextBox1" runat="server" Width="200px" TextMode="Date">

                                    </asp:TextBox>--%>

                                <asp:TextBox ID="txtlopFrom" runat="server" Style="font-family: 'Bookman Old Style'; text-align: center"
                                    Width="131px" Enabled="true" Onchange="changes(this.value)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="val" ControlToValidate="txtlopFrom" runat="server" ValidationGroup="validate"></asp:RequiredFieldValidator>
                                <%-- <input type="text"  id="txtlopFrom" runat="server" style="font-family: 'Bookman Old Style';text-align: center; Width:103px" onkeypress="check_dt()"/>
                                     --%>
                                <%--  <asp:DropDownList ID="sunday_date" runat="server" Width="103px">
                    </asp:DropDownList>--%>
                                   
                                    
                                   </td>


                        </tr>

                        <tr>
                            <td style="width: 100px; height: 24px;">
                                <asp:Label ID="Label3" runat="server" Text="Select Cancellation Date:" Width="164px"></asp:Label></td>
                            <td style="width: 175px; height: 24px;">

                                <%-- <asp:DropDownList ID="DropDownList2" runat="server" Width="198px" >
                    </asp:DropDownList>--%>

                                <%--  <input type="date" id="Birthday" name="Birthday" />--%>


                                <asp:TextBox ID="txtlopToDate" runat="server" Style="font-family: 'Bookman Old Style'; padding-left: -20px; margin-left: 0px; text-align: center"
                                    Width="131px" onchange="return check_dt(this.value)" onkeyup="checkerrs()"></asp:TextBox>




                            </td>


                        </tr>

                        <tr>
                            <td style="width: 90px; height: 40px;">
                                <asp:Label ID="Label2" runat="server" Text="Remarks:" Width="141px"></asp:Label></td>
                            <td style="width: 175px; height: 40px">
                                <asp:TextBox ID="txtremarks" MaxLength="100" runat="server" Width="128px" TextMode="MultiLine" Style="text-align: center" />&nbsp;</td>
                        </tr>




                    </table>
                </td>
            </tr>
        </table>
        <%-- <tr>
                <td colspan="3">
                    &nbsp;<uc3:DateFiller ID="DateFiller1" runat="server" />
                </td>
            </tr>--%>
        <table border="1">
            <tr>
                <td colspan="3" style="width: 471px; height: 62px">
                    <%--<table border="0" style="width: 412px">
                        <tr>
                            <td style="width: 10px; height: 30px;" align="center">
                                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
                        
                            <td style="width: 10px; height: 40px;">
                              
                                <asp:Button ID="cmd_exit" runat="server" Text="Exit" /></td>
                                
                        </tr>
                    </table>--%>


                    <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" Width="80px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      
                    <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="80px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />
                    <%-- <%-- <asp:Button ID="cmd_san" runat="server" Text="SANCTION" Width="95px" OnClientClick="return chk_data()" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True"/>&nbsp;--%>

                    <%--   <input id="cmd_exit" style="width: 95px; height: 24px; font-family: 'Courier New'; font-weight: bold; background-color: gainsboro;" type="button" value="Exit" /></td>--%>
                    
                    
                    
                    
                </td>
            </tr>
        </table>
        <br />


        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>



        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtlopFrom"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtlopToDate"></cc1:CalendarExtender>
        <%-- <input id="hidEmpCode" runat="server" style="width: 12px" type="hidden" />--%>
        <input id="hidlopFrom" runat="server" style="width: 12px" type="hidden" />
        <input id="hidlopTo" runat="server" style="width: 12px" type="hidden" />
        <input id="hidLeaveFrom" runat="server" style="width: 12px" type="hidden" />

    </div>
</asp:Content>



