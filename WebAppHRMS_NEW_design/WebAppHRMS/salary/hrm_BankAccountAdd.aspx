<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_BankAccountAdd.aspx.vb" Inherits="WebAppHRMS.Account_No_Add_hrm_BankAccountAdd_996b8a538607" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('txt');
        function btnExit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function detailDisplay() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtDep").value = "";
                document.getElementById(con[0] + "txtDes").value = "";
                document.getElementById(con[0] + "txtBranch").value = "";
                document.getElementById(con[0] + "txtAcc").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value != "") {
                callserver("1$" + document.getElementById(con[0] + "txtEcode").value, 1);
            }
        }

        function call_receiver(arg, context) {
            //debugger;
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Select valid Employee Code");
                            document.getElementById(con[0] + "txtEcode").value = "";
                            document.getElementById(con[0] + "txtEname").value = "";
                            document.getElementById(con[0] + "txtDep").value = "";
                            document.getElementById(con[0] + "txtDes").value = "";
                            document.getElementById(con[0] + "txtBranch").value = "";
                            document.getElementById(con[0] + "txtAcc").value = "";
                            document.getElementById(con[0] + "DDLEmpcode").value = 0;
                            document.getElementById(con[0] + "txt_curbnk").value = "";
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txtEname").value = accdtl[0];
                            document.getElementById(con[0] + "txtDep").value = accdtl[1];
                            document.getElementById(con[0] + "txtDes").value = accdtl[2];
                            document.getElementById(con[0] + "txtBranch").value = accdtl[3];
                            document.getElementById(con[0] + "txtAcc").value = accdtl[4];
                            //             document.getElementById(con[0]+"DDLEmpcode").value = accdtl[6];   
                            document.getElementById(con[0] + "txt_curbnk").value = accdtl[7];
                        }
                        break;
                    }
                case 2:
                    {
                        alert(arg);
                        window.open('hrm_BankAccountAdd.aspx', '_self');
                        break;
                    }
            }
        }
        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
        }
        function isNumericAcc() {
            if (isNaN(document.getElementById(con[0] + "txtAcc").value)) {
                document.getElementById(con[0] + "txtAcc").value = "";
                return false;
            }
        }
        function detailDisplayAcc() {
            if (isNaN(document.getElementById(con[0] + "txtAcc").value)) {
                document.getElementById(con[0] + "txtAcc").value = "";
                return false;
            }
        }
        function onclickconf() {
            //debugger;
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert("Please Enter Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEname").value == "") {
                alert("Please Enter Valid Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtAcc").value == "") {
                alert("Please Enter Account Number");
                document.getElementById(con[0] + "txtAcc").focus();
                return false;
            }
            var Flag = confirm("Are You Sure to Confirm");

            if (Flag == true) {
                callserver("2$" + document.getElementById(con[0] + "txtEcode").value + "$" + document.getElementById(con[0] + "txtAcc").value + "$" + document.getElementById(con[0] + "DDLEmpcode").value, 2);
            }
            if (Flag == false) {
                return false;
            }
        }

        function vldtns() {
            //debugger;
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert("Please Enter Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEname").value == "") {
                alert("Please Enter Valid Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtAcc").value == "") {
                alert("Please Enter Account Number");
                document.getElementById(con[0] + "txtAcc").focus();
                return false;
            }
        }


        // ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp; &nbsp;
            
            <table border="1" style="width: 80%; height: 187px;">
                <tr>
                    <td colspan="2">Enter Employee Code</td>
                    <td colspan="2" style="text-align: left">
                        <asp:TextBox ID="txtEcode" runat="server" MaxLength="5" Width="70%" onblur="detailDisplay()" onkeypress="isNumeric()" Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 23px; text-align: left;">Employee Name</td>
                    <td style="width: 19%; height: 23px">
                        <asp:TextBox ID="txtEname" runat="server" Width="97%" ReadOnly="True" Height="20px"></asp:TextBox></td>
                    <td style="width: 15%; height: 23px; text-align: left;">Department</td>
                    <td style="width: 20%; height: 23px">
                        <asp:TextBox ID="txtDep" runat="server" Width="97%" ReadOnly="True" Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 23px; text-align: left;">Designation</td>
                    <td style="width: 19%; height: 23px">
                        <asp:TextBox ID="txtDes" runat="server" Width="97%" ReadOnly="True" Height="20px"></asp:TextBox></td>
                    <td style="width: 15%; height: 23px; text-align: left;">Branch</td>
                    <td style="width: 20%; height: 23px">
                        <asp:TextBox ID="txtBranch" runat="server" Width="97%" ReadOnly="True" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 23px">Account Number</td>
                    <td colspan="2" style="height: 23px">
                        <asp:TextBox ID="txtAcc" runat="server" Width="97%" MaxLength="20" onblur="detailDisplayAcc()" onkeypress="isNumericAcc()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 23px; text-align: left;">Current
                        Bank</td>
                    <td style="width: 19%; height: 23px">
                        <asp:TextBox ID="txt_curbnk" runat="server" Width="97%" ReadOnly="True" Height="20px"></asp:TextBox></td>
                    <td style="width: 15%; height: 23px; text-align: left;">Update Bank</td>
                    <td style="width: 20%; height: 23px">
                        <asp:DropDownList ID="DDLEmpcode" runat="server" Width="248px" AppendDataBoundItems="True" DataTextField="textdata" DataValueField="emp_code">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 23px"></td>
                    <td colspan="2" style="height: 23px" align="left"></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 23px">&nbsp;<input id="btnConfirm" style="height: 27px" type="button" value="CONFIRM" onclick="onclickconf()" />
                        <input id="btnExit" type="button" value="EXIT" onclick="return btnExit_onclick()" style="width: 90px; height: 27px" /></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 20px"></td>
                    <td style="width: 19%; height: 20px"></td>
                    <td style="width: 15%; height: 20px"></td>
                    <td style="width: 20%; height: 20px"></td>
                </tr>
            </table>

        </div>
    </div>

</asp:Content>

