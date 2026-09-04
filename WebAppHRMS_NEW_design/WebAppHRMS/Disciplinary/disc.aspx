<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="disc.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_hrm_Add_Post_528746868019" Title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <%--<script language="javascript" type="text/javascript">
window_onload() 
function window_onload() 
{debugger;
var a=document.getElementById("Txt_FromTime1").value;
var b=document.getElementById("Txt_ToTime").value;
}
</script> --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="tb_fd" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="tb_td" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MMM/yyyy" TargetControlID="TextBox6" runat="server"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MMM/yyyy" TargetControlID="TextBox3" runat="server"></cc1:CalendarExtender>
    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <p>&nbsp;</p>
                <table style="border-collapse: collapse; width: 687pt; border-left-color: #000000; border-bottom-color: #000000; border-top-style: solid; border-top-color: #000000; border-right-style: solid; border-left-style: solid; border-right-color: #000000; border-bottom-style: solid;" id="TABLE1" onclick="return TABLE1_onclick()">
                    <tbody>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 25.2pt; width: 51px;">
                                <br>
                            </td>
                            <td rowspan colspan="4" style="color: black; font-size: 24px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none;">Disciplinary Action Register</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 25.2pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 24px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 24px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 24px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 24px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 38px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: middle; border: .5pt solid windowtext; width: 223px; height: 38px;">Emp. Code &amp; Emp. Name</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: middle; border: none; width: 154px; height: 38px;">
                                <br>
                            </td>
                            <td colspan="2" style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: bottom; border: .5pt solid windowtext; width: 321pt; height: 38px;">
                                <asp:DropDownList OnSelectedIndexChanged="textb1_SelectedIndexChanged" ID="textb1" runat="server" AutoPostBack="True" BackColor="AliceBlue"
                                    Width="606px">
                                </asp:DropDownList></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 38px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: middle; border: .5pt solid windowtext; width: 223px;">Department</td>
                            <td colspan="2" style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: bottom; border: none; border-top: .5pt solid windowtext; border-right: .5pt solid black; border-bottom: .5pt solid windowtext; border-left: none;">Post</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: middle; border: .5pt solid windowtext; border-left: none; width: 400px;">Designation</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>

                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 52px; width: 51px;">
                                <br>
                            </td>
                            <td style="width: 399px; border-right: windowtext 0.5pt solid; border-top: medium none; font-weight: 400; font-size: 15px; vertical-align: bottom; border-left: windowtext 0.5pt solid; color: #000; border-bottom: windowtext 0.5pt solid; font-style: normal; font-family: Calibri, sans-serif; text-decoration: none;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                            <td colspan="2" style="border-right: windowtext 0.5pt solid; border-top: medium none; font-weight: 400; font-size: 15px; vertical-align: bottom; border-left: windowtext 0.5pt solid; width: 399px; color: #000; border-bottom: windowtext 0.5pt solid; font-style: normal; font-family: Calibri, sans-serif; text-decoration: none;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="width: 400px; border-right: windowtext 0.5pt solid; border-top: medium none; font-weight: 400; font-size: 15px; vertical-align: bottom; border-left: windowtext 0.5pt solid; color: #000; border-bottom: windowtext 0.5pt solid; font-style: normal; font-family: Calibri, sans-serif; text-decoration: none;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 52px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 14.4pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 41px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px; height: 41px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px; height: 41px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px; height: 41px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px; height: 41px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 41px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 6px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px; height: 6px;">Disciplinary Action</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 6px; width: 54px;">
                                <br>
                            </td>
                            <td colspan="2" style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: bottom; border: .5pt solid windowtext; height: 6px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" BackColor="AliceBlue" Width="606px"></asp:DropDownList>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 6px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 43px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px; height: 43px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px; height: 43px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px; height: 43px;">
                                <br>
                            </td>
                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px; height: 43px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 43px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border-top: windowtext; border-bottom: windowtext; border-left: windowtext 1pt solid; height: 6px; width: 51px; border-border-right: windowtext 0.5pt solid;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px; height: 6px;">&nbsp;Action Occurred Date</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px; height: 6px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 399px; height: 6px;">From Date</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-left: none; width: 400px; height: 6px;">To Date</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 6px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 31px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px; height: 31px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 31px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border-top: windowtext 0.5pt solid; width: 223px; border-right: windowtext 0.5pt solid; border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 31px;">

                                <asp:TextBox ID="tb_fd" onkeypress="return isNumberKey(3)" onkeydown="return false" runat="server"></asp:TextBox>

                            </td>



                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-top: none; border-left: none; width: 400px; height: 31px;">

                                <asp:TextBox ID="tb_td" runat="server" onkeydown="return false"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
              
                            </td>

                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 31px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 39px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 399px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 400px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 39px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border-top: windowtext; border-bottom: windowtext; border-left: windowtext 1pt solid; height: 14.4pt; width: 51px; border-border-right: windowtext 0.5pt solid;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px;">&nbsp;Action Occurred Time</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 399px;">From Time</td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-left: none; width: 400px;">To Time</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 39px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 223px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 154px; height: 39px;">
                                <br>
                            </td>
                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-top: none; width: 399px; height: 39px;">

                                <asp:TextBox onchange="return validatetime('this')" Style="width: 169px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" ID="Txt_FromTime1" runat="server"></asp:TextBox>

                            </td>

                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-top: none; border-left: none; width: 400px; height: 39px;">

                                <asp:TextBox onchange="return validatetime('this')" Style="width: 169px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" ID="Txt_ToTime" runat="server"></asp:TextBox>

                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 57px; height: 39px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border-top: windowtext; border-bottom: windowtext; border-left: windowtext 1pt solid; height: 14.4pt; width: 51px; border-border-right: windowtext 0.5pt solid;">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>

                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border-top: windowtext; border-bottom: windowtext; border-left: windowtext 1pt solid; height: 14.4pt; width: 51px; border-border-right: windowtext 0.5pt solid;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px; height: 21px;">&nbsp;Remarks:-</td>
                        </tr>
                        <tr>

                            <td colspan="7" style="text-align: center; font-weight: 400; font-size: 15px; color: black; font-style: normal; font-family: Calibri, sans-serif; height: 14px; text-decoration: none;">
                                <asp:TextBox ID="TextBox8" MinLength="0" MaxLength="300" runat="server" Height="58px" TextMode="MultiLine" Wrap="true" Width="900px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; width: 51px; height: 46px;">
                                <br>
                            </td>
                            <td style="height: 46px; width: 223px;">
                                <br>
                            </td>
                            <td style="width: 154px">
                                <br>
                            </td>
                            <td style="width: 399px">
                                <br>
                            </td>
                            <td style="height: 46px; width: 400px;"></td>
                            <td style="height: 46px; width: 57px;">
                                <br>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 21px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px; height: 21px;">
                                <strong>Showcause given Date</strong></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 21px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 21px; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: center; vertical-align: bottom; border: .5pt solid windowtext; height: 21px; width: 400px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox6" runat="server" onkeydown="return false"></asp:TextBox>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; height: 21px; width: 57px;">
                                <br>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 38px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; width: 223px; height: 38px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 38px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 38px; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 400px; height: 38px;">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="394px" />
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*You can upload pdf only"
                                    Width="243px"></asp:Label></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; height: 38px; width: 57px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 45px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 45px; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 45px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 45px; width: 399px;">
                                <br>
                            </td>

                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 45px; width: 400px;">
                                <br>
                            </td>

                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; height: 45px; width: 57px;">
                                <br>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 38px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; width: 223px; height: 38px;">
                                <strong>Showcause reply Date</strong></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 38px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 38px; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; w height: 21px; width: 400px; height: 38px;">&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;
                <asp:TextBox ID="TextBox3" runat="server" onkeydown="return false"></asp:TextBox></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; height: 38px; width: 57px;">
                                <br>
                            </td>

                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 46px; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 46px; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 46px; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 46px; width: 399px;">
                                <br>
                            </td>
                            <td style="color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: .5pt solid windowtext; border-top: none; height: 46px; width: 400px;">
                                <asp:FileUpload ID="FileUpload2" runat="server" Width="394px" />
                                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*You can upload pdf only"
                                    Width="243px"></asp:Label></td>
                            <td style="width: 57px; height: 46px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: 1.0pt solid windowtext; height: 15.0pt; width: 51px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; width: 223px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; width: 154px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; width: 399px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; width: 400px;">
                                <br>
                            </td>

                        </tr>
                        <tr>
                            <td style="height: 31px"></td>
                            <td style="height: 31px"></td>
                            <td style="height: 31px"></td>
                            <td style="height: 31px">
                                <asp:Button ID="Button1confirm" runat="server" BorderColor="Black" BorderStyle="Solid" Text="CONFIRM" Width="155px" /></td>
                            &nbsp; &nbsp;&nbsp;
               <td style="width: 400px; height: 31px;">
                   <asp:Button ID="Button2" runat="server" BorderColor="Black" BorderStyle="Solid" ForeColor="Black"
                       Text="EXIT" Width="132px" /></td>
                            <br />
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

