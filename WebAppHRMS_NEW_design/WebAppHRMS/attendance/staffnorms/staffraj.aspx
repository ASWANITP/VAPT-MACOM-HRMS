<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="staffraj.aspx.vb" Inherits="WebAppHRMS.satffnorms_staffraj_acbe912b6339" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont_name = sal.split('Txt');

        function CmdExit_onclick() {
            window.open('../../home.aspx', '_self')
        }
        function checkcase() {
            var v
            v = document.getElementById(cont_name[0] + "TxtStaff").value
            var iKeyCode = 0;
            iKeyCode = window.event.keyCode;
            if (isNaN(v) || iKeyCode == 32) {
                document.getElementById(cont_name[0] + "TxtStaff").value = ""
                document.getElementById(cont_name[0] + "TxtStaff").focus()
                return false;
            }
        }

        function validate() {
            if (document.getElementById(cont_name[0] + "TxtStaff").value == "") {
                alert('Please Enter the no of Staffs!!');
                document.getElementById(cont_name[0] + "TxtStaff").focus;
                return false;
            }

            if (document.getElementById(cont_name[0] + "Txtstaff").value == document.getElementById(cont_name[0] + "Hid_staff").value) {
                alert('You did not Changed the already existed no of Staffs!!\n If you want to change the no of staffs please enter it and Click UPDATE Button!!\nElse Click EXIT Button to go Back..!!');
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 356px; height: 101px" id="TABLE1" border="1">
                    <tbody>
                        <tr>
                            <td style="width: 100px; text-align: left">Select Zone:</td>
                            <td style="width: 100px; text-align: left">
                                <asp:DropDownList ID="Cmb_zone" runat="server" Width="238px" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left">Select Type:</td>
                            <td style="width: 100px; text-align: left">
                                <asp:DropDownList ID="Cmb_Norm" runat="server" Width="236px" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 7px; text-align: left">Staff:</td>
                            <td style="width: 100px; height: 7px; text-align: left">
                                <asp:TextBox ID="TxtStaff" onkeyup="checkcase(event)" runat="server" Width="59px" MaxLength="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="2">
                                <asp:HiddenField ID="Hid_staff" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: center">
            <table border="0">
                <tr>
                    <td style="width: 100px; text-align: left">
                        <input id="CmdExit" type="button" value="<=  EXIT" onclick="return CmdExit_onclick()" style="width: 96px" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:Button ID="CmdUpdate" runat="server" OnClientClick="return validate()" Text="UPDATE" Width="96px" /></td>
                </tr>
            </table>
        </div>
        <div style="text-align: center">
            &nbsp;
        </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>

