<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="appl_other_detail.aspx.vb" Inherits="WebAppHRMS.payroll_posting_appl_other_detail_3df3eea01904" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        // <!CDATA[
        var cont = header.split('txt');

        function Button1_onclick() {
            window.open('../../home.aspx', '_self')
        }

        function hiderow1() {
            debugger;
            if (document.getElementById(cont[0] + "chk_emp").checked == true) {
                document.getElementById("row1").style.display = "inline";
            }
            else {
                document.getElementById("row1").style.display = "none";
            }
        }

        function hiderow2() {
            debugger;
            if (document.getElementById(cont[0] + "chk_director").checked == true) {
                document.getElementById("row2").style.display = "inline";
            }
            else {
                document.getElementById("row2").style.display = "none";
            }
        }


        function checkbeforeconfirm() {
            if (document.getElementById(cont[0] + "txt_appno").value == '') {
                alert('Please Enter Application No..');
                return false;
            }
            if ((document.getElementById(cont[0] + "txt_ref1name").value == '') || (document.getElementById(cont[0] + "txt_ref1address").value == '') || (document.getElementById(cont[0] + "txt_ref1phone").value == '') || (document.getElementById(cont[0] + "txt_ref2name").value == '') || (document.getElementById(cont[0] + "txt_ref2address").value == '') || (document.getElementById(cont[0] + "txt_ref2phone").value == '')) {
                alert('Please Fill all Reference Details');
                return false;
            }
            if ((document.getElementById(cont[0] + "chk_emp").checked == true) && ((document.getElementById(cont[0] + "txt_empname").value == '') || (document.getElementById(cont[0] + "txt_emprelation").value == ''))) {
                alert('Please Fill Manappuram Employee Details');
                return false;
            }
            if ((document.getElementById(cont[0] + "chk_director").checked == true) && ((document.getElementById(cont[0] + "txt_directorname").value == '') || (document.getElementById(cont[0] + "txt_directorrelation").value == ''))) {
                alert('Please Fill Director Details');
                return false;
            }
        }

        //--------------------------------------M*-----------------------------------------------
        function checkAlphabet(event) {  //debugger;48

            var keyCode = (event.which) ? event.which : event.keyCode

            if ((event.keyCode > 32 && event.keyCode < 58) || (event.keyCode > 57 && event.keyCode < 65) || (event.keyCode > 90 && event.keyCode < 97) || (event.keyCode > 122 && event.keyCode < 127)) {
                return false;
            }
        }

        function isNumberKey(ids) {
            var charcode = (event.which) ? event.which : event.keyCode
            if (ids == 3) {
                if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                    return false;
                }
                else
                    return true;
            }
        }

        //function OnCodecheck()
        //{

        //    var b=document.getElementById(con[0]+"txt_appno").value;
        //    if(isNaN(b))
        //    {
        //        alert('Please Enter Valid Application Number...!!!');
        //        document.getElementById(con[0]+"txt_appno").value = "";
        //        document.getElementById(con[0]+"txt_appno").focus();
        //        document.getElementById(con[0]+"txt_appname").value = "";
        //        return false;
        //    }
        //    else if
        //    }
        //-----------------------------------------------------------------------------------*
        // ]]>
    </script>

    <br />



    <table style="width: 743px" align="center" border="1">
        <tr>
            <td style="width: 341px; text-align: left; height: 28px;">Application No :</td>
            <td style="width: 199px; text-align: left; height: 28px;">
                <%--<input id="txt_appno" runat="server" style="width: 164px" type="text" maxlength="12" />--%>
                <%--  <asp:TextBox="txt_appno" runat="server" Width="164px" MaxLength="12"></asp:TextBox>--%><%--onblur="OnCodecheck()" --%>
                <asp:TextBox ID="txt_appno" runat="server" Width="164px" MaxLength="8" AutoPostBack="True" onkeypress="return isNumberKey(3)"></asp:TextBox>
            </td>
            <td style="width: 197px; text-align: left; height: 28px;">Applicants Name :
            </td>
            <td style="width: 100px; text-align: left; height: 28px;">
                <input id="txt_appname" runat="server" style="width: 216px" type="text" /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 21px; text-align: left">Specify relatives, if any ,employed in Manappuram Group :</td>
            <td style="width: 197px; height: 21px; text-align: left">
                <input id="chk_emp" runat="server" type="checkbox" onclick="return hiderow1()" /></td>
            <td style="width: 100px; height: 21px; text-align: left">&nbsp;&nbsp;
            </td>
        </tr>
        <tr id="row1" style="display: none">
            <td style="width: 341px; text-align: left">Employee Name :
            </td>
            <td style="width: 199px; text-align: left">
                <input id="txt_empname" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
            <td style="width: 197px; text-align: left">Relation :
            </td>
            <td style="width: 100px; text-align: left">
                <input id="txt_emprelation" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">Specify relationship with Directors,if any :</td>
            <td style="width: 197px; text-align: left">
                <input id="chk_director" runat="server" type="checkbox" onclick="return hiderow2()" /></td>
            <td style="width: 100px">&nbsp;&nbsp;
            </td>
        </tr>
        <tr id="row2" style="display: none">
            <td style="width: 341px; height: 21px; text-align: left">Director's Name :
            </td>
            <td style="width: 199px; height: 21px; text-align: left">
                <input id="txt_directorname" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
            <td style="width: 197px; height: 21px; text-align: left">Relation :
            </td>
            <td style="width: 100px; height: 21px; text-align: left">
                <input id="txt_directorrelation" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <span style="color: #ff0033">* </span>Reference Details</td>
        </tr>
        <tr>
            <td colspan="2">Reference I</td>
            <td colspan="2">Reference II</td>
        </tr>
        <tr>
            <td style="width: 341px; height: 26px; text-align: left">Name :
            </td>
            <td style="width: 199px; height: 26px">
                <input id="txt_ref1name" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
            <td style="width: 197px; height: 26px; text-align: left">Name :
            </td>
            <td style="width: 100px; height: 26px; text-align: left">
                <input id="txt_ref2name" runat="server" style="width: 185px" type="text" maxlength="30" onkeypress="return checkAlphabet(event)" /></td>
        </tr>
        <tr>
            <td style="width: 341px; text-align: left">Address :
            </td>
            <td style="width: 199px; text-align: left">
                <input id="txt_ref1address" runat="server" style="width: 185px" type="text" maxlength="75" /></td>
            <td style="width: 197px; text-align: left">Address :</td>
            <td style="width: 100px; text-align: left">
                <input id="txt_ref2address" runat="server" style="width: 185px" type="text" maxlength="75" /></td>
        </tr>
        <tr>
            <td style="width: 341px; text-align: left">Phone :
            </td>
            <td style="width: 199px; text-align: left">
                <input id="txt_ref1phone" runat="server" style="width: 185px" type="text" maxlength="15" onkeypress="return isNumberKey(3)" /></td>
            <td style="width: 197px; text-align: left">Phone :</td>
            <td style="width: 100px; text-align: left">
                <input id="txt_ref2phone" runat="server" style="width: 185px" type="text" maxlength="15" onkeypress="return isNumberKey(3)" /></td>
        </tr>
        <tr>
            <td style="width: 341px; height: 13px">Any Other Details :
            </td>
            <td colspan="3" style="height: 13px; text-align: left">
                <input id="txt_other" runat="server" style="width: 530px; height: 17px;" type="text" maxlength="100" /></td>
        </tr>
        <tr>
            <td style="text-align: right;" colspan="2">
                <asp:Button ID="cmd_add" runat="server" Text="ADD" Width="75px" OnClientClick="return checkbeforeconfirm()" /></td>
            <td colspan="2">
                <input id="cmd_exit" type="button" value="EXIT" onclick="return Button1_onclick()" style="width: 72px" /></td>
        </tr>
    </table>
    <br />
</asp:Content>

