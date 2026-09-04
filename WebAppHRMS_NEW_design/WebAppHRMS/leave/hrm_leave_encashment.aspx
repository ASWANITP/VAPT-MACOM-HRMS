<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_leave_encashment.aspx.vb" Inherits="WebAppHRMS.ENCASHMENT_hrm_leave_encashment_c4572ebc2057" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }
        var cont = master_no.split("txt")

        function CheckEncash() {
            //debugger;
            // document.getElementById (cont[0]+"Hidden1").value=Math.abs(document.getElementById (cont[0]+"txt_earned").value)-Math.abs(document.getElementById (cont[0]+"txt_encash").value);
            // if (document.getElementById (cont[0]+"Hidden1").value<5)
            //    {
            //      alert("Encashement Leave Must be Greater Than 5...!!!");
            //      document.getElementById (cont[0]+"txt_encash").focus();
            //      return false;     
            //    }


            document.getElementById(cont[0] + "Hidden1").value = Math.abs(document.getElementById(cont[0] + "txt_leave").value);
            if (document.getElementById(cont[0] + "Hidden1").value < Math.abs(document.getElementById(cont[0] + "txt_encash").value)) {
                alert("No.OF Leave Can't be Greater Than Eligible Leave...!!!");
                document.getElementById(cont[0] + "txt_encash").focus();
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

        function OnEncashment() {
            //debugger;
            document.getElementById(cont[0] + "Hidden1").value = Math.abs(document.getElementById(cont[0] + "txt_earned").value) - Math.abs(document.getElementById(cont[0] + "txt_encash").value);
            if (document.getElementById(cont[0] + "Hidden1").value > 12) {
                document.getElementById(cont[0] + "txt_carry").value = 12;
            }
            else {

                document.getElementById(cont[0] + "txt_carry").value = document.getElementById(cont[0] + "Hidden1").value;
            }

        }
        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 52%; height: 1px;">
            <tr>
                <td colspan="4" style="height: 30px; text-align: center">
                    <span style="color: #cc0000"><strong>
                        <br />
                        You can carry forward a maximum of 12 Earned leaves to next year<br />
                        &nbsp; &nbsp;&nbsp;
                    </strong></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; height: 30px; width: 2098px;">Earned Leave Balance as on 31/Dec/2011 :
                </td>
                <td colspan="2" style="text-align: left; height: 30px;">
                    <asp:TextBox ID="txt_earned" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="89px" ReadOnly="True" BackColor="LavenderBlush" ForeColor="#FF0000"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 2098px; text-align: left; height: 30px;">Carry forwarded Earned leave to next year (2012):
                </td>
                <td colspan="2" style="text-align: left; height: 30px;">
                    <asp:TextBox ID="txt_carry" runat="server" BackColor="LavenderBlush" Font-Names="Times New Roman"
                        Font-Size="Medium" ReadOnly="True" Width="89px" ForeColor="#FF0000"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 33px; text-align: left">&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 2098px; text-align: left">No. of&nbsp; Leave Eligible for Encashment :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_leave" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="89px" ReadOnly="True" BackColor="Beige"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 2098px; text-align: left">No. of Leave to Encashment :&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_encash" runat="server" onkeyup="return OnEncashment()" onblur="return CheckEncash()" onkeypress="return isNumberKey(3)" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="89px" MaxLength="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 32px">
                    <asp:Button ID="btn_Confirm" runat="server" Font-Names="Times New Roman" Font-Overline="False"
                        Font-Size="Medium" Text="Confirm" Width="93px" />
                    <input id="Button1" style="width: 90px; font-family: 'Times New Roman'; height: 29px;"
                        type="button" value="Exit" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
    </div>
    <input id="Hidden1" runat="server" style="width: 2px" type="hidden" />
    <input id="Hidden2" runat="server" type="hidden" />
</asp:Content>

