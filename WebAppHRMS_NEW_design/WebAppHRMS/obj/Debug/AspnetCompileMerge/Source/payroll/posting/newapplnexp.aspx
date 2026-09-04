<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="newapplnexp.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_newapplnexp_e9d240db4065" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript">

  function string(a) 
    {
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
     document.getElementById("ctl00_cph_edp_"+a).value=v.toUpperCase()
     document.getElementById("ctl00_cph_edp_"+a).focus()
     }
</script>
    &nbsp; &nbsp;&nbsp;&nbsp;<table align="center" style="width: 532px" border="1">
            <tr>
            <td colspan="5" style="text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:UpdatePanel ID="upnl_appln" runat="server">
                    <ContentTemplate>
                        &nbsp;<asp:Label ID="lbl_err" runat="server" Width="206px"></asp:Label>
            <table align="center" style="width: 784px" border="1">
                            <tr>
                                <td style="width: 312px">
                                    Application No</td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txt_applnno" runat="server" Width="174px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 299px">
                                    Candidate Name</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txt_cname" runat="server" Width="194px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
                                <td style="width: 100px; text-align: center">
                                </td>
            <td style="width: 100px; text-align: center">
            </td>
            <td style="width: 100px; text-align: center">
            </td>
            <td style="width: 100px; text-align: center">
            </td>
            <td style="width: 100px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                &nbsp;
    <asp:UpdatePanel ID="upnl_qual" runat="server" UpdateMode="Conditional">
                    <ContentTemplate><table align="center" style="width: 532px" border="1">
                        <tr>
                            <td style="width: 100px; text-align: center">
                                    Qualification</td>
                                <td style="width: 100px; text-align: center">
                                    Institution</td>
                                <td style="width: 100px; text-align: center">
                                    University</td>
                                <td style="width: 100px; text-align: center">
                                    Percentage</td>
                                <td style="width: 100px; text-align: center">
                                    Year of Passing</td>
                        </tr>
                        <tr>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="cmb_qualification" runat="server" Width="197px">
                                    </asp:DropDownList></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_institution" runat="server" onkeyup="string('txt_institution')" Width="174px"></asp:TextBox></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_university" runat="server" onkeyup="string('txt_university')" Width="176px"></asp:TextBox></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_percentage" runat="server" Width="84px" MaxLength="6"></asp:TextBox></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txt_passyear" runat="server" Width="97px" MaxLength="4"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 100px; height: 23px;">
                <asp:RegularExpressionValidator ID="rv_perce" runat="server" ControlToValidate="txt_percentage"
                    ErrorMessage="Enter Percentage of Mark" SetFocusOnError="True" ValidationExpression='^([0-9"."])*$'
                    Width="194px"></asp:RegularExpressionValidator></td>
            <td colspan="2" style="text-align: center; height: 23px;">
                <asp:Button ID="cmd_add" runat="server" Text="Add" Width="75px" /></td>
            <td colspan="2" style="height: 23px">
                <asp:RegularExpressionValidator ID="rv_passyear" runat="server" ControlToValidate="txt_passyear"
                    ErrorMessage="Enter a Valid Year" SetFocusOnError="True" ValidationExpression="^([0-9])*$"></asp:RegularExpressionValidator></td>
                        </tr>
                    </table>
                        <asp:Panel ID="pnl_qual" runat="server" Height="16px" Width="77px">
                        </asp:Panel>
                <asp:HiddenField ID="hd_qual" runat="server" />
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td style="width: 100px">
            </td>
            <td >
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                &nbsp;<asp:UpdatePanel ID="upnl_exp" runat="server">
                    <ContentTemplate><table align="center" style="width: 788px" border="1">
                        <tr>
                            <td style="width: 233px; height: 28px; text-align: left" >
                Name of Organization</td>
            <td style="width: 226px; height: 28px; text-align: left;">
                <asp:TextBox ID="txt_orgnization" runat="server" onkeyup="string('txt_orgnization')" Width="175px"></asp:TextBox></td>
            <td style="width: 139px; height: 28px; text-align: left" >
                Designation</td>
            <td colspan="2" style="height: 28px">
                <asp:TextBox ID="txt_designation" onkeyup="string('txt_designation')" runat="server" Width="199px"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 233px; text-align: left" >
                Period From</td>
            <td style="width: 226px; text-align: left" >
                <asp:TextBox ID="txt_expfrom" runat="server" Width="175px"></asp:TextBox></td>
            <td style="width: 139px; text-align: left" >
                Period To</td>
            <td colspan="2">
                <asp:TextBox ID="txt_expto" runat="server" Width="199px"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 233px; text-align: left" >
                Nature of Duty</td>
            <td style="width: 226px; text-align: left" >
                <asp:TextBox ID="txt_dutynature" runat="server" onkeyup="string('txt_dutynature')" Width="175px"></asp:TextBox></td>
            <td style="width: 139px; text-align: left" >
                Salary Drawn</td>
            <td colspan="2">
                <asp:TextBox ID="txt_presalary" runat="server" Width="199px" MaxLength="12"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 233px; text-align: left" >
                Contact Person</td>
            <td style="width: 226px; text-align: left" >
                <asp:TextBox ID="txt_cperson" runat="server" onkeyup="string('txt_cperson')" Width="175px"></asp:TextBox></td>
            <td style="width: 139px; text-align: left" >
                Contact Phone No</td>
            <td colspan="2">
                <asp:TextBox ID="txt_cphoneno" runat="server" Width="199px" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 233px; text-align: left" >
                Reason for Leaving</td>
            <td colspan="4">
                <asp:TextBox ID="txt_reason" runat="server" onkeyup="string('txt_reason')"  Width="576px"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 233px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_presalary"
                    ErrorMessage="Enter Salary" SetFocusOnError="True" ValidationExpression='^([0-9"."])*$'></asp:RegularExpressionValidator></td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="cmd_addexp" runat="server" Text="Add" Width="70px" /></td>
            <td colspan="2">
                <asp:RegularExpressionValidator ID="rv_phone" runat="server" ControlToValidate="txt_cphoneno"
                    ErrorMessage="Enter Valid Phone No" SetFocusOnError="True" ValidationExpression='^([0-9"-"\s])*$'></asp:RegularExpressionValidator></td>
                        </tr>
                    </table>
                        <asp:Panel ID="pnl_exp" runat="server" Height="12px" Width="125px">
                        </asp:Panel>
                        <asp:HiddenField ID="hd_exp" runat="server" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_expfrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_expto">
                </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="text-align: center" >
                <asp:Button ID="cmd_confirm" runat="server" Text="Next" Width="60px" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
                 
</asp:Content>

