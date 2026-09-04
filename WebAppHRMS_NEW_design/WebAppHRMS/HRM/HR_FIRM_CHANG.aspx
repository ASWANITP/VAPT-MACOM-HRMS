<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HR_FIRM_CHANG.aspx.vb" Inherits="WebAppHRMS.Check_HR_FIRM_CHANG_bcdf99557071" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = header_txt.split('Cmb');


        function btnConfirm_onclick() {
            if (Math.abs(document.getElementById(cont_name[0] + "txtNetAmount").value) == 0) {
                alert("Net Amount Should Not Be Zero !");
                return;
            }
            var CustID = document.getElementById(cont_name[0] + "cmbCustomer").value;
            var TotAmt = document.getElementById(cont_name[0] + "hidTotalAmt").value;
            var Discount = document.getElementById(cont_name[0] + "txtDiscount").value;
            var SaleDtl = document.getElementById(cont_name[0] + "hidData").value;
            ToServer(CustID + "?" + Math.abs(TotAmt) + "?" + Math.abs(Discount) + "?" + SaleDtl, 1);
        }
        function FromServer(Arg, Context) {
            //debugger;
            if (Arg == "") {
                alert("Please Check Employee Code and his Firm Name...!! \n\n Conditions:  Don't Enter Other Firm Employee Code!!");
                return false;
            }
            else {
                var Data = Arg.split("~");
                //17814~VIJAYA KUMAR  M ~0~A.O.VALAPAD~1~MANAPPURAM FINANCE  LIMITED~65~DY. MANAGER~17~DY. MANAGER~07-APR-10
                document.getElementById(cont_name[0] + "Txt_Empname").value = Data[1];
                document.getElementById(cont_name[0] + "Txt_post").value = Data[7];
                document.getElementById(cont_name[0] + "Txt_Branch").value = Data[3];
                document.getElementById(cont_name[0] + "Txt_Joindt").value = Data[10];
                document.getElementById(cont_name[0] + "Txt_Designation").value = Data[9];
                document.getElementById(cont_name[0] + "Txt_Firm").value = Data[5];
            }
        }





        function IsNumericCheck(evt, control) {  //debugger;
            var keyCode = evt.which ? evt.which : evt.keyCode;
            if (keyCode == 46 || (keyCode >= 48 && keyCode <= 57)) {
                var num = document.getElementById(cont_name[0] + control).value;
                if (keyCode == 46) {
                    if (num.indexOf(".") == -1) { return true; }
                    else { return false; }
                }
                return true;
            }
            else { return false; }

        }



        function Check_onclick() {
            var Empcode = document.getElementById(cont_name[0] + "Txt_Empcode").value
            if (Empcode == "") {
                alert('Please Enter Employee Code');
                document.getElementById(cont_name[0] + "Txt_Empcode").focus();
                return false;
            }
            else {
                document.getElementById(cont_name[0] + "HiddenEmp").value = Empcode;
                ToServer(Empcode, 1);
            }
        }

        function FirmOnchange() {
            var firm = document.getElementById(cont_name[0] + "Cmb_Firm").value;
            if (firm != "-1") {
                document.getElementById(cont_name[0] + "HiddenFirm").value = firm;
            }

        }


    </script>


    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 60%; position: relative; left: 0px; top: 0px;">
                <caption>
                    <strong>FIRM CHANGE</strong></caption>
                <tr>
                    <td style="width: 15%">Employee Code</td>
                    <td style="width: 15%; text-align: left;">
                        <asp:TextBox ID="Txt_Empcode" runat="server" Width="93px"></asp:TextBox>
                        <input id="Butn_check" type="button" value="Check" onclick="return Check_onclick()" style="font-weight: bold; width: 48px; font-family: 'Courier New'" /></td>
                    <td style="width: 15%">Employee Name</td>
                    <td style="width: 15%">
                        <asp:TextBox ID="Txt_Empname" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">Post
                    </td>
                    <td style="width: 15%">
                        <asp:TextBox ID="Txt_post" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 15%">Branch</td>
                    <td style="width: 15%">
                        <asp:TextBox ID="Txt_Branch" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 23px;">Join Date</td>
                    <td style="width: 15%; height: 23px;">
                        <asp:TextBox ID="Txt_Joindt" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 15%; height: 23px;">Designation</td>
                    <td style="width: 15%; height: 23px;">
                        <asp:TextBox ID="Txt_Designation" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">Current Firm</td>
                    <td style="width: 15%">
                        <asp:TextBox ID="Txt_Firm" runat="server" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 15%">Change To Firm</td>
                    <td style="width: 15%; text-align: left;">
                        <asp:DropDownList ID="Cmb_Firm" runat="server" Width="160px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px; text-align: right">
                        <asp:Button ID="Butn_Chage" runat="server" Text="Confirm" Font-Bold="True" Font-Names="Courier New" />
                    </td>
                    <td colspan="2" style="height: 28px; text-align: left;">
                        <input id="Buttn_Exit" type="button" value="Exit" onclick="window.open('../home.aspx','_self');" style="font-weight: bold; width: 70px; font-family: 'Courier New'" />
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="HiddenEmp" runat="server" />
            <asp:HiddenField ID="HiddenFirm" runat="server" />
        </div>
    </div>
</asp:Content>

