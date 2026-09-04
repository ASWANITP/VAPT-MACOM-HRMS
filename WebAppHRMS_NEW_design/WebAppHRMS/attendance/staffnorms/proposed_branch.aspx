<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="proposed_branch.aspx.vb" Inherits="WebAppHRMS.Staff_norms_consolidation_proposed_branch_8d3f2a041328" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = loanno.split('txt');
        function Button2_onclick() {
            window.open('../../home.aspx', '_self');
        }
        function fonkeyup(a) {
            var st;
            st = document.getElementById(cont[0] + a).value;
            var iKeyCode = 0;
            iKeyCode = window.event.keyCode;
            if (isNaN(st) || iKeyCode == 32) {
                alert('Please Enter No of Branches in Digits!!');
                document.getElementById(cont[0] + a).value = "";
                document.getElementById(cont[0] + a).focus();
                return false;
            }
        }
        function cliclick() {
            if (document.getElementById(cont[0] + "txt_north").value == "") {
                document.getElementById(cont[0] + "txt_north").value = 0;
            }
            if (document.getElementById(cont[0] + "txt_south").value == "") {
                document.getElementById(cont[0] + "txt_south").value = 0;
            }
            if (document.getElementById(cont[0] + "txt_central").value == "") {
                document.getElementById(cont[0] + "txt_central").value = 0;
            }
        }

        // ]]>
    </script>

    <br />
    <br />
    <br />
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Height="89px" Width="301px">
            <div style="text-align: center">
                <table border="1" style="width: 422px; height: 113px">
                    <tr>
                        <td colspan="2">
                            <span style="text-decoration: underline">No.Of Proposed Branches( Entry Form)<br />
                            </span>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px; text-align: center">North Zone :
                        </td>
                        <td style="width: 100px; text-align: left">
                            <asp:TextBox ID="txt_north" onkeyup="return fonkeyup('txt_north')" runat="server" MaxLength="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">South Zone :
                        </td>
                        <td style="width: 100px; text-align: left">
                            <asp:TextBox ID="txt_south" onkeyup="return fonkeyup('txt_south')" runat="server" MaxLength="2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 125px">Central Zone :
                        </td>
                        <td style="width: 100px; text-align: left">
                            <asp:TextBox ID="txt_central" onkeyup="return fonkeyup('txt_central')" runat="server" MaxLength="2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 125px; text-align: right">
                            <input id="Button2" style="width: 88px" type="button" value="EXIT" onclick="return Button2_onclick()" />&nbsp;
                        </td>
                        <td style="width: 100px; text-align: left">&nbsp;
                        <asp:Button ID="Button1" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

