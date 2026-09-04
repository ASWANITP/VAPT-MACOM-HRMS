<%@ Page Language="vb" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="edit_emp_address_approve.aspx.vb" Inherits="WebAppHRMS.edit_emp_address_approve" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <style>
        #personl_dtlTBL {
            margin: 0 auto; /* centers the table horizontally */
            border-collapse: collapse;
            width: 55%;
        }

        #tablePd {
            margin: 0 auto; /* centers the table horizontally */
            border-collapse: collapse;
            width: 55%;
        }
        .auto-style1 {
            width: 830px;
            height: 100px;
        }
    </style>
    <script language="javascript" type="text/javascript">

        var cont_name = header.split("txt")


        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');

        }

        function personal_click() {

            document.getElementById(cont_name[0] + "rdPersonal").style.display = 'inline';

        }

        //function change(a) {
        //    var str = document.getElementById("ctl00_cph_edp_" + a).value;
        //    if (str == ' ') {
        //        document.getElementById("ctl00_cph_edp_" + a).value = "";
        //        document.getElementById("ctl00_cph_edp_" + a).focus;
        //        return false;
        //    }
        //    if (isNaN(str)) {
        //        document.getElementById("ctl00_cph_edp_" + a).value = "";
        //        document.getElementById("ctl00_cph_edp_" + a).focus;
        //        return false;
        //    }

        //}


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
    &nbsp;
 
     <table border="1"align="center" style="width: 830px; height: 50px">
         <tr>
             <td colspan="4" style="height: 14px; text-align: center">
                 <span style="color: #cc6600"><strong>EMPLOYEE&nbsp;&nbsp;PERSONAL/QUALIFICATION/EXPERIENCE&nbsp;&nbsp;DETAILS</strong></span></td>
         </tr>

    <table border="1" align="center" style="width: 830px; height: 50px">
        <tr>
            <td style="width: 20%; height: 25px;">
                <asp:RadioButton ID="rdPersonal" runat="server" Checked="true" Text="Personal Details" AutoPostBack="true" OnCheckedChanged="rdPersonal_CheckedChanged" GroupName="DetailsGroup" /></td>
            <td style="width: 20%; height: 25px;">
                <asp:RadioButton ID="rdQual" runat="server" Text="Qualification Details" AutoPostBack="true" OnCheckedChanged="rdQual_CheckedChanged" Width="123px" GroupName="DetailsGroup" /></td>
            <td style="width: 20%; height: 25px;">
                <asp:RadioButton ID="rdExp" runat="server" Text="Experience Details" AutoPostBack="true" OnCheckedChanged="rdExp_CheckedChanged" GroupName="DetailsGroup" /></td>
        </tr>
    </table>

    <table border="1" align="center" style="width: 830px; height: 100px">
        <tr>
            <td colspan="4" style="height: 14px; text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
               <%-- <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
                </cc1:ListSearchExtender>--%>
            </td>
        </tr>

        <tr>
            <td colspan="2" style="height: 12px; text-align: center">SELECT EMPLOYEE</td>
            <td colspan="2" style="height: 12px; text-align: left">
                <asp:DropDownList ID="cmb_code" runat="server" BackColor="Honeydew" AutoPostBack="true"
                    ForeColor="DeepPink" Height="50px" OnSelectedIndexChanged="cmb_code_SelectedIndexChanged"
                    Width="402px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

              
    <div id="section1" runat="server" align="right" >
   <table border="1" id="one" align:"center" class="auto-style1">

            <tr>
                <td colspan="2" style="height: 7px; text-align: right">
                    <span style="color: #000000"><span style="color: #ff0033">*</span> </span>Name (As Given In S.S.L.C Book) :
                </td>
                <td colspan="2" style="height: 7px; text-align: left">
                    <asp:TextBox ID="txt_name" runat="server" onkeyup="string('txt_name')" ReadOnly="True" Width="315px" MaxLength="36"></asp:TextBox></td>
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
                    <asp:TextBox ID="txt_house1" runat="server" Height="18px" onkeyup="string('txt_house1')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; color: #000000; height: 2px; text-align: right">House Name :&nbsp;
                </td>
                <td style="width: 100px; height: 2px; text-align: left">
                    <asp:TextBox ID="txt_house2" runat="server" Height="18px" onkeyup="string('txt_house2')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
            </tr>

            <tr style="color: #000000">
                <td style="width: 154px; height: 2px; text-align: right">
                    <span style="color: #000000">State :&nbsp; </span>
                </td>
                <td style="width: 176px; color: #ff0000; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_state1" runat="server" Height="18px" onkeyup="string('cmb_state1')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; color: #000000; height: 2px; text-align: right">State :&nbsp;
                </td>
                <td style="width: 100px; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_state2" runat="server" Height="18px" onkeyup="string('cmb_state2')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
            </tr>


            <tr style="color: #000000">
                <td style="width: 154px; height: 2px; text-align: right">
                    <span style="color: #000000">District :&nbsp; </span>
                </td>
                <td style="width: 176px; color: #ff0000; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_district1" runat="server" Height="18px" onkeyup="string('cmb_district1')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; color: #000000; height: 2px; text-align: right">District :&nbsp;
                </td>
                <td style="width: 100px; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_district2" runat="server" Height="18px" onkeyup="string('cmb_district2')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
            </tr>


            <tr style="color: #000000">
                <td style="width: 154px; height: 2px; text-align: right">
                    <span style="color: #000000">Post :&nbsp; </span>
                </td>
                <td style="width: 176px; color: #ff0000; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_post1" runat="server" Height="18px" onkeyup="string('cmb_post1')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; color: #000000; height: 2px; text-align: right">Post :&nbsp;
                </td>
                <td style="width: 100px; height: 2px; text-align: left">
                    <asp:TextBox ID="cmb_post2" runat="server" Height="18px" onkeyup="string('cmb_post2')" ReadOnly="True"
                        Width="275px" MaxLength="36"></asp:TextBox></td>
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
                <td style="width: 154px; text-align: right; height: 19px;">
                    <span style="color: #ff0000"></span>Land Mark :
                </td>
                <td colspan="3" style="text-align: left; height: 19px;">
                    <asp:TextBox ID="txt_landmark" runat="server" onkeyup="string('txt_landmark')" ReadOnly="True" Width="689px" MaxLength="36"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 154px; height: 30px; text-align: right">Phone No :&nbsp;</td>
                
                <td style="width: 176px; height: 30px; text-align: left">
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td style="width: 100px; text-align: left">
                    <asp:CheckBox ID="chk_pp" runat="server"  Enabled="false" Text="PP" /></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_phone" runat="server" ReadOnly="True" MaxLength="10"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_phone"
        ErrorMessage="Enter Correctly" ValidationExpression="^([0-9]*[- ]?[0-9]+)$"></asp:RegularExpressionValidator></td>

                <td style="width: 123px; height: 30px; text-align: right">Contact No :&nbsp;</td>
                <td style="width: 100px; height: 30px; text-align: left">
                    <asp:TextBox ID="txt_contactno" runat="server" ReadOnly="True" Width="151px" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 154px; height: 28px; text-align: right">Email :</td>
                <td style="width: 176px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_email" runat="server" Width="275px" ReadOnly="True" MaxLength="10"></asp:TextBox></td>


                <td style="width: 123px; height: 28px; text-align: right">
                    <span style="color: #ff0000">*</span> Gender&nbsp; :&nbsp;
                </td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:RadioButtonList ID="rdb_genderlist" runat="server" ReadOnly="True" Enabled="false" RepeatDirection="Horizontal"
                        Width="215px">
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="0">Female </asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 154px; height: 12px; text-align: right">Father/Husband : &nbsp;</td>
                <td style="width: 176px; height: 12px; text-align: left">
                    <asp:TextBox ID="txt_father" runat="server" ReadOnly="True" onkeyup="string('txt_father')" Width="273px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; height: 12px; text-align: right">
                    <span style="color: #ff0000">*</span> Marital Status :&nbsp;
                </td>
                <td style="width: 100px; height: 12px; text-align: left">
                    <asp:RadioButtonList ID="rdb_maritallist" runat="server" ReadOnly="True"  Enabled="false" RepeatDirection="Horizontal"
                        Width="181px">
                        <asp:ListItem Value="2">Married</asp:ListItem>
                        <asp:ListItem Value="1">Single </asp:ListItem>
                    </asp:RadioButtonList><span style="font-size: 12pt"></span></td>
            </tr>
            <tr>
                <td style="width: 154px; text-align: right">Spouse :
                </td>
                <td style="width: 176px; text-align: left">
                    <asp:TextBox ID="txt_spouse" runat="server" ReadOnly="True" onkeyup="string('txt_spouse')" Width="269px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 123px; text-align: right">
                    <span style="color: #ff0000">*</span> Date Of Birth :&nbsp;
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_dob" ReadOnly="True" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 154px; height: 28px; text-align: right">No Of Children :&nbsp;
                </td>
                <td style="width: 176px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_noofchildren" ReadOnly="True" runat="server" MaxLength="2"></asp:TextBox></td>
                <td style="width: 123px; height: 28px; text-align: right">Age :&nbsp;
                </td>
                <td style="width: 100px; height: 28px; text-align: left">
                    <asp:TextBox ID="txt_age" runat="server" ReadOnly="True" MaxLength="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 154px; height: 23px; text-align: right">
                    <span style="color: #ff0000">*</span> Religion :
                </td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:TextBox ID="cmb_religion" runat="server" onkeyup="string('cmb_religion')" ReadOnly="True" MaxLength="15"></asp:TextBox></td>

                <td style="width: 123px; height: 23px; text-align: right">
                    <span style="color: #ff0000"></span>Caste :&nbsp;
                </td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:TextBox ID="txt_caste" runat="server" onkeyup="string('txt_caste')" MaxLength="15" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 154px; text-align: right">ID Proof :&nbsp;
                </td>
                <td style="width: 176px; text-align: left">

                    <asp:TextBox ID="cmb_idproof" runat="server" onkeyup="string('cmb_idproof')" ReadOnly="True" MaxLength="30"></asp:TextBox></td>
                <td style="width: 123px; text-align: right">ID No :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_idno" runat="server" onkeyup="string('txt_idno')" MaxLength="30" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 154px; text-align: right">
                    <span style="color: #ff0000">*</span> Blood Group :&nbsp;
                </td>
                <td style="width: 176px; text-align: left">

                    <asp:TextBox ID="cmb_bg" runat="server" onkeyup="string('cmb_bg')" ReadOnly="True" MaxLength="30"></asp:TextBox></td>
                <td colspan="2" style="text-align: center">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                </td>
            </tr>
               </table>

    </div>


    <div id="section2" runat="server" style="display: none;">
        <table id="two" border="1" style="width: 830px;">
            <tr>
                <td style="height: 20px; text-align: center;" colspan="5">
                   
                     <span id="spanExp" runat="server" style="color: #0000ff; text-decoration: underline">Present Experience Details</span>
                    &nbsp; &nbsp; &nbsp;&nbsp;<br /><br />
                                       <div style="text-align: left">
                        <table border="1">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="organisation" HeaderText="Organisation" />
        <asp:BoundField DataField="designation" HeaderText="Designation" />
        <asp:BoundField DataField="exp_frdate" HeaderText="From Date" />
        <asp:BoundField DataField="exp_todate" HeaderText="To Date" />
        <asp:BoundField DataField="nature_duty" HeaderText="Nature Of Duty" />
        <asp:BoundField DataField="releaving_reason" HeaderText="Releaving Reason" />
        <asp:BoundField DataField="cont_person" HeaderText="Contact Person" />
        <asp:BoundField DataField="cont_phone" HeaderText="Phone Number" />
    </Columns>
</asp:GridView>
                            </table>
                         </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="section3" runat="server" style="display: none;">
        <table id="three"  border="1" style="width: 830px;">
            <tr>
                <td style="height: 20px; text-align: center;" colspan="5">
                  <span id="spanQualification" runat="server" style="color: #0000ff; text-decoration: underline">Qualification Details</span>
                    &nbsp; &nbsp; &nbsp;&nbsp;<br /><br />
                     <div style="text-align: left">
                        <table border="1">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="qualification" HeaderText="Qualification" />
        <asp:BoundField DataField="institution" HeaderText="Institution" />
        <asp:BoundField DataField="university" HeaderText="University" />
        <asp:BoundField DataField="percentage" HeaderText="Percentage" />
        <asp:BoundField DataField="year_pass" HeaderText="Year of Passing" />
    </Columns>
</asp:GridView>
                            </table>
                         </div>
                </td>
            </tr>
        </table>
    </div>

              </table>

<br />
    <div style="text-align: center">

    <table>

        <tbody>
            <tr>

                <td style="width: 100px; text-align: left">&nbsp;&nbsp;
                    <asp:Button ID="cmd_update" runat="server" Text="APPROVE" /></td>
                <td style="width: 100px; text-align: left">&nbsp;&nbsp;
    <asp:Button ID="cmd_reject" runat="server" Text="REJECT" /></td>
                <td style="width: 100px; text-align: left">
                    <input id="cmd_exit" style="width: 74px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </tbody>
    </table>
        </div>
    <asp:HiddenField ID="hidQualID" runat="server" />
    <asp:HiddenField ID="hidInstitution" runat="server" />
    <asp:HiddenField ID="hidUniversity" runat="server" />
    <asp:HiddenField ID="hidPercentage" runat="server" />
    <asp:HiddenField ID="hidYearPass" runat="server" />


    <asp:HiddenField ID="hidOrganisation" runat="server" />
    <asp:HiddenField ID="hidDesignation" runat="server" />
    <asp:HiddenField ID="hidExpFrom" runat="server" />
    <asp:HiddenField ID="hidExpTo" runat="server" />
    <asp:HiddenField ID="hidNatureDuty" runat="server" />
    <asp:HiddenField ID="hidRelievingReason" runat="server" />
    <asp:HiddenField ID="hidContactPerson" runat="server" />
    <asp:HiddenField ID="hidContactPhone" runat="server" />
    <asp:HiddenField ID="hidSalary" runat="server" />

</asp:Content>

