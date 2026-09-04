<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="BACK_DATE_PUNCH.aspx.vb" Inherits="WebAppHRMS.BACK_DATE_PUNCH_6fbd13442748" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        var cont_name = sal.split('txt');

        function hour(a) {

            var v = document.getElementById("ctl00_cph_edp_" + a).value;
            if (document.getElementById(cont_name[0] + "rd_am").checked == true) {


                //alert(document.getElementById(cont_name[0]+"rd_am").checked)
                if (v > 12 || isNaN(v)) {
                    document.getElementById("ctl00_cph_edp_" + a).value = ""
                }
            }
            if (document.getElementById(cont_name[0] + "rd_pm").checked == true) {


                //alert(document.getElementById(cont_name[0]+"rd_am").checked)
                if (v > 24 || isNaN(v)) {
                    document.getElementById("ctl00_cph_edp_" + a).value = ""
                }
            }
        }

        function minute(a) {
            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            if (v > 59 || isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
            }
        }

        function second(a) {
            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value

            if (v > 59 || isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
            }
        }
        function number(a) {
            var v
            v = document.getElementById("ctl00_cph_edp_" + a).value
            if (isNaN(v)) {
                document.getElementById("ctl00_cph_edp_" + a).value = ""
            }
        }

    </script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="1">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" Width="400px" Text="PUNCHING"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label1" runat="server" Width="136px" Text="EMPLOYEE CODE"></asp:Label></td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_ecode" onkeyup="number('txt_ecode')" runat="server" Width="152px" AutoPostBack="True" OnTextChanged="txt_ecode_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left">
                                <asp:Label ID="Label2" runat="server" Width="88px" Text="NAME"></asp:Label></td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_name" runat="server" Width="256px" BackColor="Bisque" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left">
                                <asp:Label ID="Label3" runat="server" Width="88px" Text="SHIFT"></asp:Label></td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_shift" runat="server" Width="256px" BackColor="Bisque" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left">
                                <asp:Label ID="Label6" runat="server" Width="64px" Text="TIME"></asp:Label></td>
                            <td style="width: 100px; text-align: left">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 23px">
                                                <asp:TextBox onblur="hour('txt_hh')" ID="txt_hh" runat="server" Width="20px" MaxLength="2"></asp:TextBox></td>
                                            <td style="width: 27px">
                                                <asp:TextBox onblur="minute('txt_mm')" ID="txt_mm" runat="server" Width="20px" MaxLength="2"></asp:TextBox></td>
                                            <td style="width: 25px">
                                                <asp:TextBox onblur="second('txt_ss')" ID="txt_ss" runat="server" Width="20px" MaxLength="2"></asp:TextBox></td>
                                            <td style="width: 27px">
                                                <asp:RadioButton ID="rd_am" runat="server" Text="AM" GroupName="t"></asp:RadioButton></td>
                                            <td style="width: 24px">
                                                <asp:RadioButton ID="rd_pm" runat="server" Text="PM" GroupName="t"></asp:RadioButton></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left">
                                <asp:Label ID="Label7" runat="server" Text="DATE"></asp:Label></td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_date" runat="server" Width="152px" AutoPostBack="True" OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_date"></cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 28px; text-align: left">
                                <asp:Label ID="Label4" runat="server" Width="88px" Text="REASON"></asp:Label></td>
                            <td style="width: 100px; height: 28px; text-align: left">
                                <asp:TextBox ID="txt_reason" runat="server" Width="256px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 28px; text-align: center" colspan="2">
                                <asp:Label ID="lbl_mesage" runat="server" Width="410px" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="txt_ecode" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <table>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="CLEAR" Width="80px" /></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

