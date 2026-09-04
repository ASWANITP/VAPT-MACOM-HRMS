<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="typeselect.aspx.vb" Inherits="WebAppHRMS.EmpResAppTerSusReport_typeselect_b1f9342c6488" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = sal.split('Txt');

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function date(a) {
            alert('Please select date from Calendar!!');
            document.getElementById(cont_name[0] + a).value = "";
            document.getElementById(cont_name[0] + a).focus();
            return false;
        }
        function chekfirm() {

            if (document.getElementById(cont_name[0] + "Check_Firm").checked == true) {
                document.getElementById(cont_name[0] + "Cmb_Firm").disabled = false;
                document.getElementById(cont_name[0] + "Hid_Firm").value = document.getElementById(cont_name[0] + "Cmb_Firm").value;

            }
            if (document.getElementById(cont_name[0] + "Check_Firm").checked == false) {
                document.getElementById(cont_name[0] + "Cmb_Firm").disabled = true;
                document.getElementById(cont_name[0] + "Hid_Firm").value = 0;

            }
        }
        function cmbfirmchange() {
            document.getElementById(cont_name[0] + "Hid_Firm").value = document.getElementById(cont_name[0] + "Cmb_Firm").value;

        }
        /////////////////////desig..check and change
        function chekdesig() {
            if (document.getElementById(cont_name[0] + "Check_Designation").checked == true) {
                document.getElementById(cont_name[0] + "Cmb_Designation").disabled = false;
                document.getElementById(cont_name[0] + "Hid_designation").value = document.getElementById(cont_name[0] + "Cmb_Designation").value;;
            }
            if (document.getElementById(cont_name[0] + "Check_Designation").checked == false) {
                document.getElementById(cont_name[0] + "Cmb_Designation").disabled = true;
                document.getElementById(cont_name[0] + "Hid_designation").value = 0;
            }
        }
        function cmbdesigchange() {
            document.getElementById(cont_name[0] + "Hid_designation").value = document.getElementById(cont_name[0] + "Cmb_Designation").value;
        }
        //function init()
        //{
        // document.getElementById(cont_name[0]+"Cmb_Firm").disabled=true;
        // document.getElementById(cont_name[0]+"Cmb_Designation").disabled=true;
        //}
        //window.onload=init;


        function Cmd_Appointed_onclick() {
            jtype.style.display = "inline";
            document.getElementById(cont_name[0] + "Hid_Status").value = 1;
            document.getElementById(cont_name[0] + "Cmd_Resigned").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Suspended").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Terminated").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Clear").disabled = false;

            // document.getElementById(cont_name[0]+"Cmd_EmpTypePerm").disabled=false;
            //  document.getElementById(cont_name[0]+"Cmd_EmpTypeOut").disabled=false;
            //  document.getElementById(cont_name[0]+"Cmd_EmpTypeAll").disabled=false;
        }

        function Cmd_Resigned_onclick() {
            document.getElementById(cont_name[0] + "Hid_Status").value = 3;
            document.getElementById(cont_name[0] + "Cmd_Appointed").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Suspended").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Terminated").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Clear").disabled = false;

            entdate.style.display = "inline";

        }

        function Cmd_Suspended_onclick() {
            document.getElementById(cont_name[0] + "Hid_Status").value = 4;
            document.getElementById(cont_name[0] + "Cmd_Appointed").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Resigned").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Terminated").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Clear").disabled = false;

            entdate.style.display = "inline";

        }

        function Cmd_Terminated_onclick() {
            document.getElementById(cont_name[0] + "Hid_Status").value = 5;
            document.getElementById(cont_name[0] + "Cmd_Appointed").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Suspended").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Resigned").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_Clear").disabled = false;

            entdate.style.display = "inline";

        }

        function Cmd_Clear_onclick() {
            if (document.getElementById(cont_name[0] + "Hid_EmpType").value != 0) {
                document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_EmpTypeAll").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_EmpTypePerm").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_EmpTypeOut").disabled = false;
            }
            else if ((document.getElementById(cont_name[0] + "Hid_EmpType").value == 0) && (document.getElementById(cont_name[0] + "Hid_joinType").value == 3)) {
                document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
                document.getElementById(cont_name[0] + "Hid_joinType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_EmpTypePerm").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_EmpTypeOut").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_EmpTypeAll").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_AppNew").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_AppRegu").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_AppAll").disabled = false;
            }
            else if ((document.getElementById(cont_name[0] + "Hid_Status").value == 1) && (document.getElementById(cont_name[0] + "Hid_joinType").value != 3) && (document.getElementById(cont_name[0] + "Hid_joinType").value != 0)) {
                document.getElementById(cont_name[0] + "Hid_joinType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_AppNew").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_AppRegu").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_AppAll").disabled = false;
            }
            else if ((document.getElementById(cont_name[0] + "Hid_Status").value == 1) && (document.getElementById(cont_name[0] + "Hid_joinType").value == 0)) {
                jtype.style.display = "none";
                document.getElementById(cont_name[0] + "Hid_Status").value = 0;
                document.getElementById(cont_name[0] + "Hid_joinType").value = 0;
                document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_Suspended").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Resigned").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Terminated").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Clear").disabled = true;
            }
            else if ((document.getElementById(cont_name[0] + "Hid_Status").value > 1) && (document.getElementById(cont_name[0] + "Hid_DateType").value > 0)) {
                document.getElementById(cont_name[0] + "Hid_DateType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_DiscontDate").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_EnterDate").disabled = false;

            }
            else if ((document.getElementById(cont_name[0] + "Hid_Status").value > 1) && (document.getElementById(cont_name[0] + "Hid_DateType").value == 0)) {
                document.getElementById(cont_name[0] + "Hid_Status").value = 0;
                document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
                document.getElementById(cont_name[0] + "Cmd_Appointed").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Suspended").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Resigned").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Terminated").disabled = false;
                document.getElementById(cont_name[0] + "Cmd_Clear").disabled = true;
                entdate.style.display = "none";
            }
        }

        function Cmd_AppAll_onclick()  // //all both new join and regularised
        {
            document.getElementById(cont_name[0] + "Hid_joinType").value = 1;
            document.getElementById(cont_name[0] + "Cmd_AppNew").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_AppRegu").disabled = true;
        }

        function Cmd_AppNew_onclick() //new AppEmpoyees Only
        {
            document.getElementById(cont_name[0] + "Hid_joinType").value = 2;
            document.getElementById(cont_name[0] + "Cmd_AppAll").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_AppRegu").disabled = true;
        }

        function Cmd_AppRegu_onclick() //only Regularised 
        {
            document.getElementById(cont_name[0] + "Hid_joinType").value = 3;
            document.getElementById(cont_name[0] + "Cmd_AppAll").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_AppNew").disabled = true;
            document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
            document.getElementById(cont_name[0] + "Cmd_EmpTypePerm").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeOut").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeAll").disabled = true;

        }

        function Cmd_EmpTypeAll_onclick() {
            document.getElementById(cont_name[0] + "Hid_EmpType").value = 3;
            document.getElementById(cont_name[0] + "Cmd_EmpTypePerm").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeOut").disabled = true;

        }

        function Cmd_EmpTypePerm_onclick() {
            document.getElementById(cont_name[0] + "Hid_EmpType").value = 1;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeAll").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeOut").disabled = true;
        }

        function Cmd_EmpTypeOut_onclick() {
            document.getElementById(cont_name[0] + "Hid_EmpType").value = 2;
            document.getElementById(cont_name[0] + "Cmd_EmpTypeAll").disabled = true;
            document.getElementById(cont_name[0] + "Cmd_EmpTypePerm").disabled = true;
        }
        function cliclick() {
            if (document.getElementById(cont_name[0] + "Txt_FromDate").value == "") {
                alert('Please Enter From Date!!');
                document.getElementById(cont_name[0] + "Txt_FromDate").focus();
                return false;
            }
            if (document.getElementById(cont_name[0] + "Txt_ToDate").value == "") {
                alert('Please Enter To Date!!');
                document.getElementById(cont_name[0] + "Txt_ToDate").focus();
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Hid_DateType").value == 0) && (document.getElementById(cont_name[0] + "Hid_Status").value > 1)) {
                alert('Please Select whether Enter date Or Discontinue Date  !!');
                return false;
            }

            if (document.getElementById(cont_name[0] + "Hid_Status").value == 0) {
                alert('Please Select which Report You Need !!');
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Hid_Status").value == 1) && (document.getElementById(cont_name[0] + "Hid_joinType").value == 0)) {
                alert('Please Select Joined Employee Type !!');
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Hid_Status").value == 1) && (document.getElementById(cont_name[0] + "Hid_joinType").value > 0) && (document.getElementById(cont_name[0] + "Hid_joinType").value < 3) && (document.getElementById(cont_name[0] + "Hid_EmpType").value == 0)) {
                alert('Please Select Employee Type !!');
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Hid_Status").value > 1) && (document.getElementById(cont_name[0] + "Hid_EmpType").value == 0)) {
                alert('Please Select Employee Type  !!');
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Hid_EmpType").value == 0) && (document.getElementById(cont_name[0] + "Hid_joinType").value != 3)) {
                alert('Please Select Employee Type  !!');
                return false;
            }
        }

        function init() {
            document.getElementById(cont_name[0] + "Hid_EmpType").value = 0;
            document.getElementById(cont_name[0] + "Hid_Status").value = 0;
            document.getElementById(cont_name[0] + "Hid_joinType").value = 0;
            document.getElementById(cont_name[0] + "Check_Firm").checked = false;
            document.getElementById(cont_name[0] + "Check_Designation").checked = false;
            document.getElementById(cont_name[0] + "Cmb_Firm").disabled = true;
            document.getElementById(cont_name[0] + "Cmb_Designation").disabled = true;
            document.getElementById(cont_name[0] + "Hid_Firm").value = 0;
            document.getElementById(cont_name[0] + "Hid_designation").value = 0;
            document.getElementById(cont_name[0] + "Hid_DateType").value = 0;
        }
        window.onload = init;

        function Cmd_EnterDate_onclick() {
            document.getElementById(cont_name[0] + "Hid_DateType").value = 2;
            document.getElementById(cont_name[0] + "Cmd_DiscontDate").disabled = true;

        }

        function Cmd_DiscontDate_onclick() {
            document.getElementById(cont_name[0] + "Hid_DateType").value = 1;
            document.getElementById(cont_name[0] + "Cmd_EnterDate").disabled = true;
        }

        // ]]>
    </script>

    <br />

    <br />
    <br />
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="text-align: center">
            <table border="1" style="width: 682px; height: 198px">
                <tr>
                    <td colspan="6" style="height: 23px">
                        <strong>Select The Status</strong></td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 14px">
                        <div style="text-align: center">
                            <table style="width: 224px; height: 24px">
                                <tr>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_Appointed" type="button" value="APPOINTED" onclick="return Cmd_Appointed_onclick()" runat="server" style="cursor: hand" /></td>
                                    <td style="width: 95px; text-align: left">
                                        <input id="Cmd_Resigned" type="button" value="RESIGNED" onclick="return Cmd_Resigned_onclick()" runat="server" style="cursor: hand" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_Suspended" type="button" value="SUSPENDED" onclick="return Cmd_Suspended_onclick()" runat="server" style="cursor: hand" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_Terminated" type="button" value="TERMINATED" onclick="return Cmd_Terminated_onclick()" runat="server" style="cursor: hand" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_Clear" type="button" value="CLEAR" onclick="return Cmd_Clear_onclick()" runat="server" style="cursor: hand" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="jtype" style="display: none">
                    <td colspan="6">
                        <div style="text-align: center">
                            <table>
                                <tr>
                                    <td style="width: 183px; text-align: left">Select Join Type:</td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_AppAll" type="button" value="ALL" style="width: 106px; cursor: hand;" onclick="return Cmd_AppAll_onclick()" runat="server" /></td>
                                    <td style="width: 90px; text-align: left">
                                        <input id="Cmd_AppNew" type="button" value="NEWLY JOINED" style="width: 129px; cursor: hand;" onclick="return Cmd_AppNew_onclick()" runat="server" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_AppRegu" type="button" value="REGULARISED" style="width: 119px; cursor: hand;" onclick="return Cmd_AppRegu_onclick()" runat="server" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div style="text-align: center">
                            <table>
                                <tr>
                                    <td style="width: 184px; text-align: left">Select Employee Type:</td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_EmpTypeAll" type="button" value="ALL" style="width: 106px; cursor: hand;" onclick="return Cmd_EmpTypeAll_onclick()" runat="server" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <input id="Cmd_EmpTypePerm" type="button" value="PERMANANT" onclick="return Cmd_EmpTypePerm_onclick()" runat="server" style="cursor: hand" /></td>
                                    <td style="width: 86px; text-align: left">
                                        <input id="Cmd_EmpTypeOut" type="button" value="OUTSOURCE" onclick="return Cmd_EmpTypeOut_onclick()" runat="server" style="cursor: hand" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="entdate" style="display: none">
                    <td colspan="5" style="text-align: left">Do you want Report With Enter Date (Not Discontinue Date)?</td>
                    <td style="width: 100px; text-align: left">
                        <div style="text-align: left">
                            <table border="0">
                                <tr>
                                    <td style="width: 36px">
                                        <input id="Cmd_EnterDate" type="button" value="ENTER DATE" style="width: 94px; cursor: hand;" onclick="return Cmd_EnterDate_onclick()" runat="server" /></td>
                                    <td style="width: 55px">
                                        <input id="Cmd_DiscontDate" type="button" value="DISCONT DATE" style="width: 102px; cursor: hand;" onclick="return Cmd_DiscontDate_onclick()" runat="server" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 658px; height: 20px; text-align: left;">Select Firmwise:</td>
                    <td style="width: 12px; height: 20px; text-align: left;">
                        <input id="Check_Firm" onclick="chekfirm()" type="checkbox" runat="server" style="cursor: hand" /></td>
                    <td style="width: 11px; height: 20px; text-align: left;">
                        <asp:DropDownList ID="Cmb_Firm" onchange="cmbfirmchange()" runat="server" Width="138px" Style="cursor: hand">
                        </asp:DropDownList></td>
                    <td style="width: 145px; height: 20px; text-align: left;">Designationwise:</td>
                    <td style="width: 16px; height: 20px; text-align: left;">
                        <input id="Check_Designation" type="checkbox" onclick="chekdesig()" runat="server" style="cursor: hand" /></td>
                    <td style="width: 100px; height: 20px; text-align: left;">
                        <asp:DropDownList ID="Cmb_Designation" onchange="cmbdesigchange()" runat="server" Width="204px" Style="cursor: hand">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align: left;" colspan="2">From Date:</td>
                    <td style="width: 11px; text-align: left;">
                        <asp:TextBox ID="Txt_FromDate" onkeyup="return date('Txt_FromDate')" runat="server" Width="131px" Style="cursor: hand"></asp:TextBox></td>
                    <td style="text-align: left;" colspan="2">To Date:</td>
                    <td style="width: 100px; text-align: left;">
                        <asp:TextBox ID="Txt_ToDate" onkeyup="return date('Txt_ToDate')" runat="server" Width="131px" Style="cursor: hand"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div style="text-align: center">
                            <table border="0" style="width: 108px; height: 30px">
                                <tr>
                                    <td style="width: 54px; text-align: left">
                                        <input id="Cmd_Exit" type="button" value="EXIT" style="width: 80px; cursor: hand;" onclick="return Cmd_Exit_onclick()" /></td>
                                    <td style="width: 100px; text-align: left">
                                        <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Style="cursor: hand" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <cc1:CalendarExtender ID="CalendarExtender_From" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="Txt_FromDate"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender_To" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="Txt_ToDate"></cc1:CalendarExtender>
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_Designation">
        </cc1:ListSearchExtender>
        <asp:HiddenField ID="Hid_Firm" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_designation" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_Status" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_joinType" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_EmpType" runat="server" Value="0" />
        <asp:HiddenField ID="Hid_DateType" runat="server" Value="0" />
        <br />
        <br />
        <br />
        <br />
    </div>

</asp:Content>


