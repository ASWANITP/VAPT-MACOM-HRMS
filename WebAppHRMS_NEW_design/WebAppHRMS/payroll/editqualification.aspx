<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editqualification.aspx.vb" Inherits="WebAppHRMS.Edit_present_permanent_addresss_of_emp_editqualification_df52cee62718" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">


        function cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function van() {
            alert("please select date from calendar!")
            return false;
        }
        function string(a) {
            var v;
            v = document.getElementById("ctl00_cph_edp_" + a).value;
            document.getElementById("ctl00_cph_edp_" + a).value = v.toUpperCase();
            document.getElementById("ctl00_cph_edp_" + a).focus();
        }

        function Button1_onclick() {

            //document.getElementById("c100_cph_edp+"+"tablesample"):document.getElementById("c100_cph_edp+"+"tabb");
        }

        function TABLE1_onclick() {

        }

        // ]]>
    </script>
    <div style="text-align: center">
        <table border="1" style="width: 838px; height: 472px">
            <tr>
                <td colspan="5" style="height: 22px">
                    <span style="color: #0000ff"><span style="text-decoration: underline">Qualification
                        Details</span><span
                            style="color: #000000">&nbsp;</span></span></td>
            </tr>
            <tr>
                <td style="text-align: center; height: 206px;" colspan="5">
                    <div style="text-align: center">
                        <div style="text-align: left">
                        </div>
                    </div>
                    &nbsp;&nbsp;<div style="text-align: center">
                        <table id="TABLE1" border="1" onclick="return TABLE1_onclick()">
                            <tr>
                                <td style="height: 37px;" colspan="5">
                                    <table border="1" style="width: 792px; height: 25px">
                                        <tr>
                                            <td style="width: 100px; height: 25px; text-align: center">
                                                <asp:DropDownList ID="cmb_addq" runat="server" Width="200px">
                                                </asp:DropDownList></td>
                                            <td style="width: 100px; height: 25px">
                                                <asp:TextBox ID="txt_addinstitute" runat="server" onkeyup="return string('txt_addinstitute')"></asp:TextBox></td>
                                            <td style="width: 100px; height: 25px">
                                                <asp:TextBox ID="txt_adduniversity" runat="server" onkeyup="return string('txt_adduniversity')"></asp:TextBox></td>
                                            <td style="width: 56px; height: 25px">
                                                <asp:TextBox ID="txt_addpercentage" runat="server" Width="50px"></asp:TextBox></td>
                                            <td style="width: 74px; height: 25px">
                                                <asp:TextBox ID="txt_addyear" runat="server" Width="70px"></asp:TextBox></td>
                                            <td style="width: 100px; height: 25px">
                                                <asp:CheckBox ID="chk_higher" runat="server" Text="Higher" /></td>
                                            <td style="width: 100px; height: 25px">
                                                <asp:Button ID="cmd_clear" runat="server" Text="CLEAR" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 34px">
                                    <asp:Button ID="cmd_add" runat="server" Text="ADD" Width="80px" /></td>
                                <td style="width: 19px">
                                    <asp:Button ID="cmd_edit" runat="server" Text="EDIT" Width="82px" /></td>
                                <td style="width: 45px">
                                    <asp:Button ID="cmd_delete" runat="server" Text="DELETE"></asp:Button></td>
                                <td style="width: 105px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_addpercentage"
                                        ErrorMessage="Please Enter Correct Percentage (Two Decimal Places Allowed)" ValidationExpression="^\d{0,2}(\.\d{1,2})?$" Width="409px" Font-Size="Small" Height="15px"></asp:RegularExpressionValidator></td>
                                <td style="width: 100px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_addyear"
                                        ErrorMessage="Please Enter Year" ValidationExpression="^\d{4}$" Width="137px" Font-Size="Small"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:ListBox ID="ListBox1" runat="server" Height="131px" Width="828px" BackColor="Azure" Font-Bold="True" Rows="7" AutoPostBack="True"></asp:ListBox></td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hid3" runat="server" />
                    &nbsp;<asp:HiddenField ID="hid2" runat="server" />
                    <asp:HiddenField ID="hid1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px; text-align: center;" colspan="5">
                    <span style="color: #0000ff; text-decoration: underline">Present Experience Details</span>
                    &nbsp; &nbsp; &nbsp;&nbsp;<br />
                    <div style="text-align: left">
                        <table border="1">
                            <tr>
                                <td colspan="2" style="height: 139px">
                                    <asp:ListBox ID="ListBox2" runat="server" BackColor="White" Height="131px" Width="824px" Style="background-color: #fff8ff" AutoPostBack="True"></asp:ListBox>&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 233px; height: 23px; text-align: right;">Name of Org :&nbsp;
                </td>
                <td style="width: 131px; height: 23px; text-align: left;">
                    <asp:TextBox ID="txt_org" runat="server" onkeyup="string('txt_org')" Width="207px" MaxLength="36"></asp:TextBox></td>
                <td style="width: 199px; height: 23px; text-align: right;">Designation :&nbsp;
                </td>
                <td style="height: 23px; text-align: left; width: 290px;" colspan="2">
                    <asp:TextBox ID="txt_designation" runat="server" onkeyup="string('txt_designation')" Width="207px" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 233px; text-align: right;">Period From :&nbsp;
                </td>
                <td style="width: 131px; text-align: left;">
                    <asp:TextBox ID="txt_periodfrom" onkeypress="return van()" runat="server" Width="207px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_periodfrom"></cc1:CalendarExtender>
                </td>
                <td style="width: 199px; text-align: right;">Period To :&nbsp;
                </td>
                <td style="text-align: left; width: 290px;" colspan="2">
                    <asp:TextBox ID="txt_periodto" onkeypress="return van()" runat="server" Width="207px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_periodto"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 233px; text-align: right;">Nature of Duty :&nbsp;
                </td>
                <td style="width: 131px; text-align: left;">
                    <asp:TextBox ID="txt_nature" runat="server" onkeyup="string('txt_nature')" Width="207px" MaxLength="30"></asp:TextBox></td>
                <td style="width: 199px; text-align: right;">Salary Drawn :&nbsp;
                </td>
                <td style="text-align: left; width: 290px;" colspan="2">
                    <asp:TextBox ID="txt_salary" runat="server" Width="207px" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 233px; height: 23px; text-align: right;">Contact Person :&nbsp;
                </td>
                <td style="width: 131px; height: 23px; text-align: left;">
                    <asp:TextBox ID="txt_contact" runat="server" onkeyup="string('txt_contact')" Width="207px" MaxLength="12"></asp:TextBox></td>
                <td style="width: 199px; height: 23px; text-align: right;">Contact Phone No :&nbsp;
                </td>
                <td style="height: 23px; text-align: left; width: 290px;" colspan="2">
                    <asp:TextBox ID="txt_contactno" runat="server" Width="207px" MaxLength="12"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 233px; height: 23px; text-align: right;">Reason for Leaving :&nbsp;
                </td>
                <td colspan="4" style="height: 23px; text-align: left">
                    <asp:TextBox ID="txt_reason" runat="server" onkeyup="string('txt_reason')" Width="631px" MaxLength="36"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_contactno"
                        ErrorMessage="Please Enter Contact No Correctly" ValidationExpression='^([0-9]*[- ]?[0-9]+)$'></asp:RegularExpressionValidator>
                    <asp:Button ID="cmd_listadd" runat="server" Text=">>" Width="78px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_salary"
                        ErrorMessage="Please Enter Salary(Two Decimal Places Allowed)" ValidationExpression="^[0-9]*(\.\d{1,2})?$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 49px">
                    <asp:ListBox ID="ListBox3" runat="server" BackColor="#FFEEFF" Font-Bold="True"
                        ForeColor="DeepPink" Height="123px" Width="760px" Style="background-color: #fff8ff"></asp:ListBox>
                    <asp:Button ID="cmd_adde" runat="server" Height="23px" Text="ADD" Width="72px" /></td>
            </tr>
            <tr>
                <td colspan="5">
                    <div style="text-align: center">
                        <span style="color: #ff00ff"><strong><span>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <br />
                            <span style="text-decoration: underline">Joining Details</span></span></strong><br />
                        </span>
                        <table border="1" style="width: 588px; height: 61px; background-color: #fff1ff">
                            <tr>
                                <td style="width: 157px; height: 16px; text-align: right">Date Of Joining :
                                </td>
                                <td style="width: 100px; height: 16px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_join" runat="server" Font-Bold="True" ForeColor="DarkOrchid" Text="Label"
                                        Width="155px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 157px; text-align: right">Designation :
                                </td>
                                <td style="width: 100px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_desig" runat="server" Font-Bold="True" ForeColor="DarkOrchid" Text="Label"
                                        Width="407px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 157px; height: 20px; text-align: right">Branch :</td>
                                <td style="width: 100px; height: 20px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_branch" runat="server" Font-Bold="True" ForeColor="DarkOrchid"
                                        Text="Label" Width="391px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 157px; height: 20px; text-align: right">Branch Abbr :
                                </td>
                                <td style="width: 100px; height: 20px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_abbr" runat="server" Font-Bold="True" ForeColor="DarkOrchid" Text="Label"
                                        Width="305px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 157px; text-align: right">Firm :
                                </td>
                                <td style="width: 100px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_firm" runat="server" Font-Bold="True" ForeColor="DarkOrchid" Text="Label"
                                        Width="381px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 157px; text-align: right">Salary :
                                </td>
                                <td style="width: 100px; text-align: left">&nbsp;
                                    <asp:Label ID="lb_sal" runat="server" Font-Bold="True" ForeColor="DarkOrchid" Text="Label"
                                        Width="211px"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;
                    <input id="cmd_Exit" style="width: 82px" type="button" value="EXIT" onclick="return cmd_Exit_onclick()" />
                    &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;<asp:Button ID="cmd_next" runat="server" Text="NEXT"
                        Width="88px" /></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>

