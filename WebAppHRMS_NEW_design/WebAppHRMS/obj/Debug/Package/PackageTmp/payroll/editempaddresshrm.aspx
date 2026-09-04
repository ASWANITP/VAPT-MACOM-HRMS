<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editempaddresshrm.aspx.vb" Inherits="WebAppHRMS.new_edit_personal_and_qualification_details1_editempaddresshrm_4c6a90a03251" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = header.split("txt")


        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');

        }

        function change(a) {
            var str = document.getElementById("ctl00_cph_edp_" + a).value;
            if (str == ' ') {
                document.getElementById("ctl00_cph_edp_" + a).value = "";
                document.getElementById("ctl00_cph_edp_" + a).focus;
                return false;
            }
            if (isNaN(str)) {
                document.getElementById("ctl00_cph_edp_" + a).value = "";
                document.getElementById("ctl00_cph_edp_" + a).focus;
                return false;
            }

        }


        function van() {
            alert("please select date from calendar!")
            return false;
        }

        function string(a) {
            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            document.getElementById("ctl00_cph_edp_" + a).value = v.toUpperCase()
            document.getElementById("ctl00_cph_edp_" + a).focus()
        }



        function isNumberKey(ids) { //debugger;
            var charcode = (event.which) ? event.which : event.keyCode
            if (ids == 1) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32)) {
                    return true;
                }
                else
                    return false;
            }
            if (ids == 2) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32) || (charcode > 46 && charcode < 58)) {
                    return true;
                }
                else
                    return false;
            }

            if (ids == 3) {
                if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                    return false;
                }
                else
                    return true;
            }

        }
        // ]]>
    </script>

    <br />
    &nbsp;<table border="1" align="center" style="width: 841px; height: 209px">
        <tr>
            <td colspan="4" style="height: 14px; text-align: center">
                <span style="color: #cc6600"><strong>EDIT PERSONAL DETAILS</strong></span></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 14px; text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
                </cc1:ListSearchExtender>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 14px; text-align: right">Select Employee :&nbsp;
            </td>
            <td colspan="2" style="height: 14px; text-align: left">
                <span style="color: #ff0000; text-decoration: underline">
                    <asp:TextBox ID="Txt_emp" onkeyup="return change('Txt_emp')" runat="server" AutoPostBack="True" MaxLength="6" Width="196px"></asp:TextBox>
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 12px; text-align: right">EMPLOYEE</td>
            <td colspan="2" style="height: 12px; text-align: left">
                <asp:DropDownList ID="cmb_code" runat="server" BackColor="Honeydew"
                    ForeColor="DeepPink" Height="50px" OnSelectedIndexChanged="cmb_code_SelectedIndexChanged1"
                    Width="402px">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td colspan="2" style="height: 7px; text-align: right">
                <span style="color: #000000"><span style="color: #ff0033">*</span> </span>Name (As Given In S.S.L.C Book) :
            </td>
            <td colspan="2" style="height: 7px; text-align: left">
                <asp:TextBox ID="txt_name" runat="server" onkeyup="string('txt_name')" Width="315px" MaxLength="36"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px">
                <span style="color: #000000"><span><span style="color: #ff0033">*</span> Permanent Address</span>
                </span>
            </td>
            <td colspan="2" style="color: #000000; height: 23px">
                <span style="color: #000000"><span style="color: #ff0033">*</span> Present Address</span></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 154px; height: 2px; text-align: right">
                <span style="color: #000000">House Name :&nbsp; </span>
            </td>
            <td style="width: 176px; color: #ff0000; height: 2px; text-align: left">
                <asp:TextBox ID="txt_house1" runat="server" Height="18px" onkeyup="string('txt_house1')"
                    Width="275px" MaxLength="36"></asp:TextBox></td>
            <td style="width: 123px; color: #000000; height: 2px; text-align: right">House Name :&nbsp;
            </td>
            <td style="width: 100px; height: 2px; text-align: left">
                <asp:TextBox ID="txt_house2" runat="server" Height="18px" onkeyup="string('txt_house2')"
                    Width="275px" MaxLength="36"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">State :&nbsp;
            </td>
            <td style="width: 176px; text-align: left">
                <asp:DropDownList ID="cmb_state1" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
            <td style="width: 123px; text-align: right">State :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:DropDownList ID="cmb_state2" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="cmb_state2_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">District :&nbsp;
            </td>
            <td style="width: 176px; text-align: left">
                <asp:DropDownList ID="cmb_district1" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="cmb_district1_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
            <td style="width: 123px; text-align: right">
                <span style="color: #000000">District :&nbsp; </span>
            </td>
            <td style="width: 100px; color: #ff0000; text-align: left">
                <asp:DropDownList ID="cmb_district2" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="cmb_district2_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 154px; height: 6px; text-align: right">Post :&nbsp;
            </td>
            <td style="width: 176px; height: 6px; text-align: left">
                <asp:DropDownList ID="cmb_post1" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="cmb_post1_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
            <td style="width: 123px; height: 6px; text-align: right">Post :&nbsp;
            </td>
            <td style="width: 100px; height: 6px; text-align: left">
                <asp:DropDownList ID="cmb_post2" runat="server" AutoPostBack="True" Height="18px"
                    OnSelectedIndexChanged="cmb_post2_SelectedIndexChanged" Width="280px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">Pin Code :&nbsp;
            </td>
            <td style="width: 176px; text-align: left">
                <asp:TextBox ID="txt_pin1" runat="server" ReadOnly="True" MaxLength="15"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">Pin Code :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_pin2" runat="server" ReadOnly="True" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:CheckBox ID="chk_same" runat="server" AutoPostBack="True" OnCheckedChanged="chk_same_CheckedChanged"
                    Text="Permanent Address Same As Present Address" /></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right; height: 19px;">
                <span style="color: #ff0000"></span>Land Mark :
            </td>
            <td colspan="3" style="text-align: left; height: 19px;">
                <asp:TextBox ID="txt_landmark" runat="server" onkeyup="string('txt_landmark')" Width="689px" MaxLength="36"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 154px; height: 30px; text-align: right">Phone No :&nbsp;
            </td>
            <td style="width: 176px; height: 30px; text-align: left">
                <div style="text-align: center">
                    <table border="1">
                        <tr>
                            <td style="width: 100px; text-align: left">
                                <asp:CheckBox ID="chk_pp" runat="server" Text="PP" /></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txt_phone" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_phone"
                    ErrorMessage="Enter Correctly" ValidationExpression="^([0-9]*[- ]?[0-9]+)$"></asp:RegularExpressionValidator></td>
            <td style="width: 123px; height: 30px; text-align: right">Contact No :&nbsp;
            </td>
            <td style="width: 100px; height: 30px; text-align: left">
                <asp:TextBox ID="txt_contactno" runat="server" Width="151px" MaxLength="10"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_contactno"
                    ErrorMessage="Enter Correctly" ValidationExpression="^([0-9]*[- ]?[0-9]+)$" Width="162px"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 154px; height: 28px; text-align: right">Email :
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
                    ErrorMessage="Enter Correctly" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            <td style="width: 176px; height: 28px; text-align: left">
                <asp:TextBox ID="txt_email" runat="server" Width="275px" MaxLength="10"></asp:TextBox></td>
            <td style="width: 123px; height: 28px; text-align: right">
                <span style="color: #ff0000">*</span> Gender&nbsp; :&nbsp;
            </td>
            <td style="width: 100px; height: 28px; text-align: left">
                <asp:RadioButtonList ID="rdb_genderlist" runat="server" RepeatDirection="Horizontal"
                    Width="215px">
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="0">Female </asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 154px; height: 12px; text-align: right">Father/Husband : &nbsp;</td>
            <td style="width: 176px; height: 12px; text-align: left">
                <asp:TextBox ID="txt_father" runat="server" onkeyup="string('txt_father')" Width="273px" MaxLength="36"></asp:TextBox></td>
            <td style="width: 123px; height: 12px; text-align: right">
                <span style="color: #ff0000">*</span> Marital Status :&nbsp;
            </td>
            <td style="width: 100px; height: 12px; text-align: left">
                <asp:RadioButtonList ID="rdb_maritallist" runat="server" RepeatDirection="Horizontal"
                    Width="181px">
                    <asp:ListItem Value="2">Married</asp:ListItem>
                    <asp:ListItem Value="1">Single </asp:ListItem>
                </asp:RadioButtonList><span style="font-size: 12pt"></span></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">Spouse :
            </td>
            <td style="width: 176px; text-align: left">
                <asp:TextBox ID="txt_spouse" runat="server" onkeyup="string('txt_spouse')" Width="269px" MaxLength="36"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">
                <span style="color: #ff0000">*</span> Date Of Birth :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_dob" onkeypress="return van()" runat="server" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 154px; height: 28px; text-align: right">No Of Children :&nbsp;
            </td>
            <td style="width: 176px; height: 28px; text-align: left">
                <asp:TextBox ID="txt_noofchildren" onkeypress="return isNumberKey(3)" runat="server" MaxLength="2"></asp:TextBox></td>
            <td style="width: 123px; height: 28px; text-align: right">Age :&nbsp;
            </td>
            <td style="width: 100px; height: 28px; text-align: left">
                <asp:TextBox ID="txt_age" runat="server" ReadOnly="True" MaxLength="3"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 154px; height: 23px; text-align: right">
                <span style="color: #ff0000">*</span> Religion :
            </td>
            <td style="width: 176px; height: 23px; text-align: left">
                <asp:DropDownList ID="cmb_religion" runat="server" Width="276px">
                </asp:DropDownList></td>
            <td style="width: 123px; height: 23px; text-align: right">
                <span style="color: #ff0000"></span>Caste :&nbsp;
            </td>
            <td style="width: 100px; height: 23px; text-align: left">
                <asp:TextBox ID="txt_caste" runat="server" onkeyup="string('txt_caste')" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">ID Proof :&nbsp;
            </td>
            <td style="width: 176px; text-align: left">
                <asp:DropDownList ID="cmb_idproof" runat="server" Width="276px">
                </asp:DropDownList></td>
            <td style="width: 123px; text-align: right">ID No :
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_idno" runat="server" onkeyup="string('txt_idno')" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 154px; text-align: right">
                <span style="color: #ff0000">*</span> Blood Group :&nbsp;
            </td>
            <td style="width: 176px; text-align: left">
                <asp:DropDownList ID="cmb_bg" runat="server" Width="92px">
                </asp:DropDownList></td>
            <td colspan="2" style="text-align: center">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 25px; text-align: center">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                    ErrorMessage="Please Enter Name "></asp:RequiredFieldValidator>
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_dob" ErrorMessage="Enter Date Of Birth"></asp:RequiredFieldValidator>
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            </td>
        </tr>
    </table>
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td style="width: 100px; text-align: right">&nbsp;<asp:Button ID="cmd_next" runat="server" Text="NEXT" Width="74px" />&nbsp;
                </td>
                <td style="width: 100px; text-align: left">&nbsp;&nbsp;
                <asp:Button ID="cmd_update" runat="server" Text="UPDATE" /></td>
                <td style="width: 100px; text-align: left">
                    <input id="cmd_exit" style="width: 74px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

