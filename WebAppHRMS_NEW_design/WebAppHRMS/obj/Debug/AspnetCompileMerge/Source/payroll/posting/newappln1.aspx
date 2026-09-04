<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="newappln1.aspx.vb" Inherits="WebAppHRMS.payroll_newappln1_bfc6228f3070" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    </asp:UpdatePanel>
<script type="text/javascript">
  function string(a) 
    {
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
     document.getElementById("ctl00_cph_edp_"+a).value=v.toUpperCase()
     document.getElementById("ctl00_cph_edp_"+a).focus()
     }
  function check_null()
  {
   alert("Select Date From Calender")
   return  false;
  }   
  
  
  function isNumberKey(ids)
{ //debugger;
 var charcode = (event.which) ? event.which : event.keyCode
 if(ids==1)
 {
 if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32))
  {
     return true;
   } 
    else
     return false;  
  }
 if(ids==2)
 {
 if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32) ||(charcode > 46 && charcode <58))
  {
     return true;
   } 
    else
     return false;  
  }
  
 if(ids==3)    
 {
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))
  {
    return false;
  } 
    else
     return true;  
 }
     
}
function Button1_onclick() 
{
 window.open('../../home.aspx','_self')
}

</script>

    <table align="center" border="1" style="width: 674px; height: 831px">
        <tr>
            <td style="width: 1048px; text-align: center">
                &nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_phone"
                    ErrorMessage="Enter Correct Phone No" SetFocusOnError="True" ValidationExpression='^([0-9"-"\s])*$'
                    Width="199px"></asp:RegularExpressionValidator><span style="color: #ff0000">&nbsp; </span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_contactno"
                    ErrorMessage="Enter Correct Contact  No" SetFocusOnError="True" ValidationExpression='^([0-9"-"\s])*$'
                    Width="178px"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        runat="server" ControlToValidate="txt_fathus" ErrorMessage="Enter Father  Name"
                        SetFocusOnError="True" ValidationExpression='^([a-zA-Z"."\s])*$' Width="158px"></asp:RegularExpressionValidator><span
                            style="color: #000000">&nbsp; </span>
                <asp:Label ID="lbl_err" runat="server" Width="227px"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 1048px; height: 793px; text-align: center">
                &nbsp;<span style="color: #ff0000"> </span>
                <asp:HiddenField ID="hd_post" runat="server" />
                <table style="width: 623px; height: 728px;">
                    <tr>
                        <td colspan="6" style="text-align: center">
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                                TargetControlID="txt_dob">
                            </cc1:CalendarExtender>
                            <span style="color: #ff0000">&nbsp; </span>NEW APPLICATION</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span style="color: #000000">Na</span>me (As given <span style="color: #000000">i</span><span
                                style="color: #ff0000">n SSLC Book)</span><span style="color: #ff0000"><span style="color: #000000">
                                </span><span style="color: #000000">*</span></span></td>
                        <td colspan="4" style="color: #000000">
                            <asp:TextBox ID="txt_name" runat="server" MaxLength="40" onkeyup="string('txt_name')"
                                TabIndex="1" Width="304px"></asp:TextBox></td>
                    </tr>
                    <tr style="color: #000000">
                        <td colspan="2">
                            <span style="color: #ff3300">Address</span><span style="color: #ff0000"><span style="color: #000000">
                            </span><span style="color: #000000">*</span></span></td>
                        <td colspan="2" style="color: #000000">
                            <table border="1">
                                <tr>
                                    <td colspan="5" style="text-align: center">
                                        Permanant</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 124px; height: 27px; text-align: left">
                                        <asp:Label ID="Label6" runat="server" Text="House Name :" Width="88px"></asp:Label></td>
                                    <td colspan="3" style="width: 292px; height: 27px">
                                        <asp:TextBox ID="txt_Perm_hs_name" runat="server" MaxLength="50" onkeyup="string('txt_Perm_hs_name')"
                                            TabIndex="2" Width="280px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 124px; text-align: left">
                                        <asp:Label ID="Lbl7" runat="server" Text="state :"></asp:Label></td>
                                    <td colspan="3" style="width: 292px; text-align: left">
                                        <asp:DropDownList ID="cmb_perm_state" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_perm_state_SelectedIndexChanged"
                                            TabIndex="3" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 124px; text-align: left">
                                        <asp:Label ID="Label8" runat="server" Text="District :"></asp:Label></td>
                                    <td colspan="3" style="width: 292px; text-align: left">
                                        <asp:DropDownList ID="cmb_perm_district" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_perm_district_SelectedIndexChanged"
                                            TabIndex="4" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 124px; height: 12px; text-align: left">
                                        <asp:Label ID="Label9" runat="server" Text="Post :"></asp:Label></td>
                                    <td colspan="3" style="width: 292px; height: 12px; text-align: left">
                                        <asp:DropDownList ID="cmb_perm_post" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_perm_post_SelectedIndexChanged"
                                            TabIndex="5" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 124px; height: 24px; text-align: left">
                                        <asp:Label ID="Label10" runat="server" Text="PIN :"></asp:Label></td>
                                    <td colspan="3" style="width: 292px; height: 24px; text-align: left">
                                        <asp:TextBox ID="txt_perm_pin" runat="server" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                            </table>
                            <asp:CheckBox ID="chk_add" runat="server" AutoPostBack="True" OnCheckedChanged="chk_add_CheckedChanged"
                                TabIndex="6" Text="Present address same as Permenant address" /></td>
                        <td colspan="2">
                            <table border="1">
                                <tr>
                                    <td colspan="5" style="text-align: center">
                                        Present</td>
                                </tr>
                                <tr>
                                    <td style="width: 101px; text-align: left">
                                        <asp:Label ID="Label11" runat="server" Text="House Name :" Width="90px"></asp:Label></td>
                                    <td colspan="4" style="width: 289px">
                                        <asp:TextBox ID="txt_Pres_hs_name" runat="server" MaxLength="50" onkeyup="string('txt_Pres_hs_name')"
                                            TabIndex="7" Width="280px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 101px; text-align: left">
                                        <asp:Label ID="Label12" runat="server" Text="State :"></asp:Label></td>
                                    <td colspan="4" style="width: 289px; text-align: left">
                                        <asp:DropDownList ID="cmb_pres_state" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_pres_state_SelectedIndexChanged"
                                            TabIndex="8" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 101px; text-align: left">
                                        <asp:Label ID="Label13" runat="server" Text="District :"></asp:Label></td>
                                    <td colspan="4" style="width: 289px; text-align: left">
                                        <asp:DropDownList ID="cmb_pres_district" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_pres_district_SelectedIndexChanged"
                                            TabIndex="9" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 101px; text-align: left">
                                        <asp:Label ID="Label14" runat="server" Text="Post :"></asp:Label></td>
                                    <td colspan="4" style="width: 289px; text-align: left">
                                        <asp:DropDownList ID="cmb_pres_post" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_pres_post_SelectedIndexChanged"
                                            TabIndex="10" Width="200px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 101px; height: 8px; text-align: left">
                                        <asp:Label ID="Label15" runat="server" Text="PIN :"></asp:Label></td>
                                    <td colspan="4" style="width: 289px; height: 8px; text-align: left">
                                        <asp:TextBox ID="txt_pres_pin" runat="server" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                            </table>
                            <asp:Label ID="Label1" runat="server" Width="163px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 11px">
                            Land Mark<span style="color: #ff0000">*</span></td>
                        <td colspan="4" style="height: 11px">
                            <asp:TextBox ID="txt_lankmark" runat="server" MaxLength="60" onkeyup="string('txt_lankmark')"
                                TabIndex="11" Width="665px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Phone No(Residence)<span style="color: #ff0000">*</span></td>
                        <td style="width: 311px; text-align: center">
                            <asp:CheckBox ID="chk_pp" runat="server" TabIndex="12" Text="PP" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_phone" onkeypress="return isNumberKey(3)" runat="server" MaxLength="15" TabIndex="13" Width="210px"></asp:TextBox></td>
                        <td style="width: 100px">
                            Contact No</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_contactno" onkeypress="return isNumberKey(3)" runat="server" MaxLength="15" TabIndex="14" Width="234px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Email
                            <asp:RegularExpressionValidator ID="val_email" runat="server" ControlToValidate="txt_email"
                                ErrorMessage="Enter Correct Email Add" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_email" runat="server" MaxLength="30" TabIndex="15" Width="306px"></asp:TextBox></td>
                        <td style="width: 100px">
                            Gender</td>
                        <td style="width: 100px">
                            <asp:RadioButtonList ID="rd_gender" runat="server" RepeatDirection="Horizontal" TabIndex="16"
                                Width="205px">
                                <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="0">Female</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Father/Husband Name</td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_fathus" runat="server" MaxLength="40" onkeyup="string('txt_fathus')"
                                TabIndex="17" Width="306px"></asp:TextBox></td>
                        <td style="width: 100px">
                            Marital Status <span style="color: #ff0000">*</span></td>
                        <td style="width: 100px">
                            <asp:RadioButtonList ID="rd_marital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rd_marital_SelectedIndexChanged"
                                RepeatDirection="Horizontal" TabIndex="18" Width="165px">
                                <asp:ListItem Selected="True" Value="2">Married</asp:ListItem>
                                <asp:ListItem Value="1">Single</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="lbl_spouse" runat="server" Text="Spouse"></asp:Label></td>
                        <td style="width: 331px">
                            <asp:TextBox ID="txt_spousename" runat="server" MaxLength="40" onkeyup="string('txt_spousename')"
                                TabIndex="19" Width="141px"></asp:TextBox></td>
                        <td style="width: 311px; text-align: left">
                            &nbsp;
                            <asp:Label ID="lbl_no" runat="server" Text="No.of Childrens"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_child" onkeypress="return isNumberKey(3)" runat="server" TabIndex="20" Width="66px"></asp:TextBox></td>
                        <td colspan="2">
                            &nbsp;<table style="width: 339px">
                                <tr>
                                    <td style="width: 99px">
                                        Date of Birth <span style="color: #ff0000">*</span></td>
                                    <td style="width: 99px">
                                        <asp:TextBox ID="txt_dob" runat="server" AutoPostBack="True" OnTextChanged="txt_dob_TextChanged"
                                            TabIndex="21" onkeypress="return check_null()"></asp:TextBox></td>
                                    <td style="width: 99px">
                                        <asp:Label ID="lbl_age" runat="server" Text="Age" Width="38px"></asp:Label></td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txt_age" runat="server" ReadOnly="True" Width="57px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Religion</td>
                        <td style="width: 311px">
                            <asp:DropDownList ID="cmb_religion" runat="server" TabIndex="22" Width="171px">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <span style="color: #ff3300"></span>Caste<span style="color: #ff3300">*</span></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txt_caste" runat="server" MaxLength="15" onkeyup="string('txt_caste')"
                                TabIndex="23" Width="230px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px">
                            ID Proof</td>
                        <td style="width: 331px; height: 26px">
                            <asp:DropDownList ID="cmb_idproof" runat="server" TabIndex="24" Width="181px">
                            </asp:DropDownList></td>
                        <td style="width: 311px; height: 26px">
                            ID No</td>
                        <td style="width: 100px; height: 26px">
                            <asp:TextBox ID="txt_idno" runat="server" MaxLength="25" onkeyup="string('txt_idno')"
                                TabIndex="25" Width="113px"></asp:TextBox></td>
                        <td style="width: 100px; height: 26px">
                            Blood Group</td>
                        <td style="width: 100px; height: 26px">
                            <asp:DropDownList ID="cmb_bloodgp" runat="server" TabIndex="26" Width="133px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 24px">
                            Nearest Manappuram Branch In Your Location</td>
                        <td colspan="3" style="height: 24px; text-align: center">
                            <select id="cmb_nrbr" runat="server" style="width: 178px">
                                <option selected="selected"></option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 24px">
                            Information Source of Vacancy</td>
                        <td colspan="3" style="height: 24px; text-align: center">
                            <asp:DropDownList ID="cmb_vacanysource" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_vacanysource_SelectedIndexChanged"
                                TabIndex="24" Width="181px">
                                <asp:ListItem Value="0">Directors / Employee </asp:ListItem>
                                <asp:ListItem Value="1">News Paper</asp:ListItem>
                                <asp:ListItem Value="2">Internet</asp:ListItem>
                                <asp:ListItem Value="3">Friends</asp:ListItem>
                                <asp:ListItem Value="4">Others</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: center">
                            <asp:Panel ID="pnl_vacancy" runat="server" Height="50px" Visible="False" Width="125px">
                                <table border="1" style="width: 596px">
                                    <tr>
                                        <td style="width: 291px; height: 26px; text-align: left">
                                            Employee Code &amp; Name</td>
                                        <td style="width: 100px; height: 26px; text-align: left">
                                            <asp:DropDownList ID="cmb_emp" runat="server" Width="270px">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnl_other" runat="server" Height="50px" Visible="False" Width="125px">
                                <table border="1" style="width: 596px">
                                    <tr>
                                        <td style="width: 266px; height: 17px; text-align: left">
                                            If Other Specify
                                        </td>
                                        <td style="width: 100px; height: 17px; text-align: left">
                                            <asp:TextBox ID="txt_other" runat="server" Width="309px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 1048px; height: 55px">
                <table style="width: 371px">
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: center">
                            &nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="Next" Width="65px" /></td>
                        <td style="width: 100px; height: 26px; text-align: center">
                            <input id="Button1" style="width: 69px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

