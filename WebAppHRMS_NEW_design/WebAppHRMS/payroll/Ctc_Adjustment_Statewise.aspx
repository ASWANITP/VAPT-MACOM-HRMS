<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Ctc_Adjustment_Statewise.aspx.vb" Inherits="WebAppHRMS.jewel_Ctc_Adjustment_Statewise_76d1f4866604" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="../control/uc_date.ascx" TagName="uc_date" TagPrefix="uc1" %>--%>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">

        return window_onload()

    </script>

    <script language="javascript" type="text/javascript">


        var cs = cont_name.split("txt");
        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        function emp_fill() {
            debugger;
            if (document.getElementById(cs[0] + "cmb_State").options[document.getElementById(cs[0] + "cmb_State").selectedIndex].text == "JR. ASST.") {
                document.getElementById("row1").style.display = "inline";
            }
            else {
                document.getElementById("row1").style.display = "none";
            }
            call_server("1$" + document.getElementById(cs[0] + "cmb_State").value + "$" + document.getElementById(cs[0] + "cmb_emp").value, 1);
        }

        function quali_fill() {
            debugger;

            call_server("2$" + document.getElementById(cs[0] + "cmb_State").value + "$" + document.getElementById(cs[0] + "cmb_emp").value, 2);

        }


        function checkvalue() {
            if (isNaN(document.getElementById(cs[0] + "txt_newda").value) || document.getElementById(cs[0] + "txt_newda").value == "") {
                alert("Wrong Entry");
                document.getElementById(cs[0] + "txt_newda").value = ""
                document.getElementById(cs[0] + "txt_newda").focus()
                return false;
            }

        }
        function isNumberKey(event) {

            var charcode = (event.which) ? event.which : event.keyCode
            if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                return false;
            }
            else
                return true;
        }

        //function check_dt()
        //{
        // alert("Select Date From Calender")
        // return false;
        //}

        //function dt_check()
        //{
        //var mydate=new Date()
        //var year=mydate.getYear()
        //if (year < 1000)
        //year+=1900
        //var day=mydate.getDay()
        //var month=mydate.getMonth()
        //var daym=mydate.getDate()
        //if (daym<10)
        //daym="0"+daym
        // var montharray=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
        // mydate=daym+"/"+montharray[month]+"/"+year
        //    var dbd
        //    var day3;
        //    var month3;
        //    var year3;

        //    value3 = document.getElementById(cs[0]+"dt_effect").value;
        //    day3= value3.substring (0, value3.indexOf ("/"));
        //    month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
        //    year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);

        //    var value4 = mydate;
        //    var day4 = value4.substring (0, value4.indexOf ("/"));
        //    var month4 = value4.substring (value4.indexOf ("/")+1, value4.lastIndexOf ("/"));
        //    var year4 =value4.substring (value4.lastIndexOf ("/")+1, value4.length);
        // 
        //    date3 = year3+"/"+month3+"/"+day3;
        //    date4 = year4+"/"+month4+"/"+day4;
        //    firstDate = Date.parse(date3)
        //    secondDate= Date.parse(date4)
        //    msPerDay = 24 * 60 * 60 * 1000
        //    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
        //    if(dbd<-10)
        //    {
        //     alert("You can only Select 1 year future Date");
        //     return false; 
        //    }
        //    if(dbd>10)
        //    {
        //     alert("You can only Select 1 year Back Date");
        //     return false; 
        //    }
        // }


        function call_receiver(arg, context) {
            debugger;
            switch (context) {
                case 1:
                    {
                        document.getElementById(cs[0] + "txt_preda").value = arg;
                        break;
                    }
                case 2:
                    {
                        document.getElementById(cs[0] + "txt_preda").value = arg;
                        break;
                    }
            }
        }


        function window_onload() {

            document.getElementById("row1").style.display = "none";
        }

    </script>


    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" BackColor="Transparent" BorderStyle="Solid"
            BorderWidth="1px" Height="350px" Width="500px" BorderColor="Black">
            <br />
            <br />

            <table border="1" style="width: 480px; height: 160px">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl_hd" runat="server" Font-Bold="True" Font-Size="Large" Font-Underline="True"
                            ForeColor="red" Height="32px" Text="STATE WISE CTC ADJUSTMENT UPDATION" Width="416px"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 305px; text-align: justify; height: 27px;">Select&nbsp;Designation &nbsp; &nbsp; &nbsp; &nbsp;: &nbsp; &nbsp;&nbsp;</td>
                    <td style="width: 200px; text-align: justify; height: 27px;">
                        <asp:DropDownList ID="cmb_State" runat="server">
                        </asp:DropDownList>


                    </td>
                </tr>
                <tr id="row1">
                    <td style="width: 305px; text-align: justify; height: 27px;">Qualification :</td>
                    <td style="width: 200px; text-align: justify; height: 27px;">
                        <asp:DropDownList ID="cmb_emp" runat="server" Width="310px">
                        </asp:DropDownList></td>
                </tr>
                <%--<tr>
                <td style="width: 205px; height: 27px; text-align: justify">
                    Select District :</td>
                <td style="width: 233px; height: 27px; text-align: justify">
                    <asp:DropDownList ID="cmb_District" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>--%>
                <tr>
                    <td style="width: 162px; text-align: left">Present&nbsp;Minimum&nbsp;CTC&nbsp; :
                    </td>
                    <td style="width: 65px; text-align: center">
                        <asp:TextBox ID="txt_preda" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>

                <tr>

                    <td style="width: 162px; text-align: left; height: 28px;">New&nbsp;Minimum&nbsp;CTC :
                    </td>
                    <td style="width: 65px; text-align: center; height: 28px;">
                        <asp:TextBox ID="txt_newda" onblur="return checkvalue()" runat="server" MaxLength="8"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 162px; height: 23px; text-align: left">Effect&nbsp;Date &nbsp;: 
                    </td>

                    <td style="width: 233px; height: 23px; text-align: left">
                        <%-- <asp:TextBox ID="dt_effect"  runat="server" onkeypress="return check_dt()"></asp:TextBox></td>--%>
                        <asp:TextBox ID="dt_effect" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 26px; text-align: center">
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="dt_effect"></cc1:CalendarExtender>
                    </td>
                </tr>
                <%-- <tr>
                <td style="width: 205px">
                </td>
                <td style="width: 233px">
                </td>
            </tr>--%>

                <div>
                    <tr>
                        <td style="width: 205px; text-align: center">
                            <asp:Button ID="Btn_confirm" runat="server" Text="CONFIRM" Height="24px" Width="100px" Style="cursor: hand" OnClientClick="return dt_check()" /></td>
                        <td style="width: 205px; text-align: center">
                            <input id="Btn_exit" style="width: 100px; cursor: hand;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />

                        </td>
                    </tr>
                </div>

            </table>

        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        &nbsp;
    </div>

</asp:Content>
