<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Emp_Current_select.aspx.vb" Inherits="WebAppHRMS.Emp_Current_select_bd1dc25f6154" Title="Emp Status Selection" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont_name = sal.split('Cmb');

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }


        //function init()
        //{
        //
        //}
        //window.onload=init;
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        &nbsp;
    </div>
    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 473px; height: 1px">
                <tr>
                    <td style="width: 100px; text-align: left; height: 174px;">
                        <table style="width: 439px; height: 1px">
                            <tr>
                                <td style="width: 2px; text-align: left; height: 24px;">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Select Department:"
                                        Width="162px"></asp:Label></td>
                                <td style="width: 68px; text-align: left; height: 24px;">
                                    <asp:DropDownList ID="Cmb_Department" runat="server" Width="278px" Style="cursor: hand">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 2px; height: 51px; text-align: left"></td>
                                <td style="width: 68px; height: 51px; text-align: left">
                                    <table style="width: 190px">
                                        <tr>
                                            <td style="width: 100px">
                                                <input id="Cmd_Exit" type="button" value="EXIT" tabindex="2" onclick="return Cmd_Exit_onclick()" style="width: 86px; cursor: hand;" /></td>
                                            <td style="width: 100px">
                                                <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" TabIndex="3" Width="94px" Style="cursor: hand" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

