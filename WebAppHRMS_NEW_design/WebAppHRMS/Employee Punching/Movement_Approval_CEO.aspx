<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Movement_Approval_CEO.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_Movement_Approval_CEO_149998143325" %>


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




        //function Cmd_Exit_onclick() 
        //{
        // window.open('../../home.aspx','_self');
        //}

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
        function blockSpecialChar(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || (k >= 48 && k <= 57));
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
        <table border="1" style="margin: 0px auto;">
            <tr>
                <td colspan="4" style="height: 41px; text-align: center; width: 780px;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">MOVEMENT &nbsp;&nbsp; &nbsp;SANCTION</span></strong></span></span></span><%--<asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </span></strong>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="width: 780px; height: 37px; text-align: center">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="width: 780px; height: 37px; text-align: center">
                    <div style="text-align: center">
                        <table style="width: 748px">
                            <tr>
                                <td style="width: 168px; text-align: left">
                                    <span style="font-family: Agency FB"><strong>Select Employee</strong></span></td>
                                <td style="width: 100px; text-align: left">
                                    <asp:DropDownList ID="cmb_emp" runat="server" AutoPostBack="True" BackColor="AliceBlue"
                                        Width="606px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="height: 13px; text-align: center; width: 780px;">
                    <div style="text-align: center">
                        &nbsp;
                    </div>
                    <table border="0" style="width: 784px; height: 79px;">
                        <tr>
                            <td style="width: 301px; height: 29px; text-align: left">
                                <span style="font-size: 11pt; font-family: Courier New"><strong>EMPLOYEE&nbsp;CODE &amp;
                                    NAME</strong></span></td>
                            <td colspan="3" style="height: 29px; text-align: left">
                                <input id="Txt_emp" readonly="readonly" style="width: 571px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 301px; text-align: left; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>DEPARTMENT</strong></span></td>
                            <td style="width: 175px; text-align: left; height: 27px;">
                                <input id="Txt_dep" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 239px;" type="text" readonly="readOnly" /></td>
                            <td style="text-align: left; width: 69px; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>DESIGNATION</strong></span></td>
                            <td style="width: 153px; text-align: left; height: 27px;">
                                <input id="Txt_des" runat="server" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" /></td>
                        </tr>
                        <tr>
                            <td style="width: 301px; height: 13px; text-align: left;">
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
            <tr style="color: #cc0000">
                <td colspan="4" style="height: 14px; text-align: center; width: 780px;">
                    <strong style="font-weight: bold; font-size: 15pt; font-family: 'Courier New'">&nbsp;<span
                        style="font-family: Agency FB">MOVEMENT </span>&nbsp;&nbsp;<span style="font-family: Agency FB"> DETAILS&nbsp; </span>
                        &nbsp; &nbsp; </strong>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 9px; text-align: center; width: 780px;">
                    <table border="0" style="width: 782px; height: 79px;">
                        <tr>
                            <td style="width: 162px; text-align: left; height: 27px;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>MOVEMENT&nbsp;DATE</strong></span></td>
                            <td style="text-align: left; height: 27px; width: 554px;" colspan="4">&nbsp;<asp:TextBox ID="Txt_fdt" runat="server" Width="147px" onkeyPress="return clr('Txt_fdt')" Font-Size="Small" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" ReadOnly="True"></asp:TextBox><span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
                        </tr>

                        <tr>
                            <td style="width: 162px; text-align: left;">
                                <span style="font-size: 11pt; font-family: Courier New"><strong>FROM </strong></span>
                            </td>
                            <td style="width: 74px; text-align: left;">
                                <strong style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                                    <asp:TextBox ID="Txt_From" runat="server" Width="124px" ReadOnly="True" Font-Bold="False" Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></strong></td>
                            <td style="width: 74px; text-align: left">
                                <strong><span style="font-size: 11pt; font-family: Courier New">TO</span></strong></td>
                            <td style="width: 101px">
                                <asp:TextBox ID="Txt_To" runat="server" Width="136px" ReadOnly="True" Font-Bold="False" Style="cursor: hand; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" Font-Size="Small"></asp:TextBox></td>
                        </tr>


                        <tr>
                            <td style="width: 162px; height: 13px; text-align: left;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>MOVEMENT&nbsp;PURPOSE </strong></span>
                            </td>
                            <td style="text-align: left; height: 13px; width: 554px;" colspan="4">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                    <asp:TextBox ID="Txt_purp" runat="server" onkeypress="return isNumberKey(2)" Width="545px" MaxLength="80" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" ReadOnly="True"></asp:TextBox></span></td>
                        </tr>
                        <tr>
                            <td style="width: 162px; height: 13px; text-align: left;">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"><strong>REJECTED&nbsp;REASON </strong></span>
                            </td>
                            <td style="text-align: left; height: 13px; width: 554px;" colspan="4">
                                <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';">
                                    <asp:TextBox ID="Text_RJTRSN" runat="server" Width="545px" MaxLength="80" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'" ReadOnly="FALSE"></asp:TextBox></span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="color: #000000">
                <td colspan="4" style="height: 25px; width: 780px;">
                    <div style="text-align: center">
                    </div>
                    <div style="text-align: center">
                        <table style="width: 462px">
                            <tr>
                                <td style="width: 2227px; height: 31px; text-align: left;">
                                    <asp:Button ID="cmd_confirm" OnClientClick="return tourcliclick()" runat="server" Text="SANCTION" Width="111px" Height="29px" /></td>
                                <td style="width: 146px; height: 31px;">
                                    <asp:Button ID="New_Reject" runat="server" Height="29px" Text="REJECT" Width="113px" /></td>
                                <td style="width: 146px; height: 31px">
                                    <asp:Button ID="cmd_reject" runat="server" Height="29px" Text="REJECT" Width="113px" /></td>
                                <td style="width: 154px; height: 31px;">
                                    <asp:Button ID="Cmd_Exit" runat="server" Text="EXIT" Width="111px" Height="29px" />
                                    <%--                                    <input id="Cmd_Exit" style="width: 105px; height: 29px;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" />--%></td>
                                <td style="width: 22px; height: 31px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


