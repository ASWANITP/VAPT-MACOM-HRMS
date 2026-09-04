<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="earlygoing_apply.aspx.vb" Inherits="WebAppHRMS.november_tour_Tour_apply_5ace8aa13319" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <%--<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>
    --%>



    <script language="javascript" type="text/javascript">
        // <!CDATA[


        var cs = cont_name.split("Txt");
        function change(a) {
            //debugger;
            var str = document.getElementById(cs[0] + a).value;
            if (str == ' ') {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }
        function isNumberKey(ids) {
            //debugger;
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




        function Cmd_Exit_onclick() {
            window.open('../../home.aspx', '_self');
        }

        function clr(b) {
            alert("please select the date");
            document.getElementById(cs[0] + b).value = "";
            return false;
        }
        //=-=-=-=-=--=-=--=-=-=-=-=-==-=-===Time  using Text Box=-Modified on 22 may 2009=-=--=-=-=-=-=-==--=-==-=-=-=--=

        function IsNumeric(strString) {
            var strValidChars = "0123456789:";
            var strChar;
            var blnResult = true;
            //var strSequence = document.frmQuestionDetail.txtSequence.value; 

            //test strString consists of valid characters listed above 

            if (strString.length == 0)
                return false;
            for (i = 0; i < strString.length && blnResult == true; i++) {
                strChar = strString.charAt(i);
                if (strValidChars.indexOf(strChar) == -1) {
                    blnResult = false;
                }
            }
            return blnResult;
        }

        //==-==-==-=-==--=--==-=-=-=-=--=-=-----=-=-=--=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        function tourcliclick() {
            if (document.getElementById(cs[0] + "Txt_fdt").value == '') {
                alert('Please Enter From Date');
                return false;
            }
            if (document.getElementById(cs[0] + "Txt_purp").value == '') {
                alert('Please Enter Purpose');
                return false;
            }
        }


        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 642px; height: 331px;">
            <tr>
                <td colspan="4" style="height: 41px; text-align: center;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">EARLY-GOING APPLICATION</span></strong>
                        </span></span></span>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:CalendarExtender>
                    </span></strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; text-align: center">
                    <div style="text-align: center">
                        &nbsp;
                    </div>
                    <table border="1" style="width: 648px; height: 79px;">
                        <tr>
                            <td style="width: 156px; height: 29px; text-align: left">
                                <span style="font-size: 11pt; font-family: Courier New"><strong>EMPLOYEE&nbsp;CODE&nbsp;NAME</strong></span></td>
                            <td colspan="3" style="height: 29px; text-align: left">
                                <input id="Txt_emp" readonly="readonly" style="width: 571px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 156px; text-align: left; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>DEPARTMENT</strong></span></td>
                            <td style="width: 175px; text-align: left; height: 27px;">
                                <input id="Txt_dep" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 239px;" type="text" readonly="readOnly" /></td>
                            <td style="text-align: left; width: 69px; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>DESIGNATION</strong></span></td>
                            <td style="width: 153px; text-align: left; height: 27px;">
                                <input id="Txt_des" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" /></td>
                        </tr>
                        <tr>
                            <td style="width: 156px; height: 13px; text-align: left;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>BRANCH</strong></span></td>
                            <td style="width: 175px; text-align: left; height: 13px;">
                                <input id="Txt_br" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 241px;" type="text" readonly="readOnly" /></td>
                            <td style="height: 13px; text-align: left; width: 69px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>POST</strong></span></td>
                            <td style="width: 153px; text-align: left; height: 13px;">
                                <input id="Txt_post" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 14px; text-align: center;">
                    <strong style="font-weight: bold; font-size: 14pt; font-family: 'Courier New'">&nbsp;&nbsp; <span style="font-family: Agency FB">EARLY-GOING DETAILS&nbsp; </span>
                        &nbsp; &nbsp; </strong>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 15px; text-align: center">
                    <table border="1" style="width: 762px; height: 79px;">
                        <tr>
                            <td style="width: 193px; text-align: left; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>Early-Going&nbsp;Date</strong></span></td>
                            <td style="text-align: left; height: 27px;" colspan="3">&nbsp;<asp:TextBox ID="Txt_fdt" runat="server" Width="147px" onkeyPress="return clr('Txt_fdt')" Font-Size="Small" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox><span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
                        </tr>
                        <tr>
                            <td style="width: 193px; height: 13px; text-align: left;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>Early&nbsp;-&nbsp;Going&nbsp;PURPOSE </strong></span>
                            </td>
                            <td style="text-align: left; height: 13px;" colspan="3">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                    <asp:TextBox ID="Txt_purp" runat="server" onkeypress="return isNumberKey(2)" Width="537px" MaxLength="60" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" Height="29px"></asp:TextBox></span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 39px">
                    <div style="text-align: center">
                    </div>
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" OnClientClick="return tourcliclick()" runat="server" Text="CONFIRM" Width="105px" Height="29px" /></td>
                                <td style="width: 100px">
                                    <input id="Cmd_Exit" style="width: 105px; height: 29px;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

