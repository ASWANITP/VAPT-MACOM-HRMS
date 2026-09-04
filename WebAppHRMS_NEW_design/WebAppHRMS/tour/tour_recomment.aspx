<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="tour_recomment.aspx.vb" Inherits="WebAppHRMS.tour_recomment_aa4fe9a24056" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script type="text/javascript">
        function next(emp) {
            //alert('fdgdfg');
            window.open('../home.aspx', '_self');

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <table border="1" style="width: 724px; height: 324px">
            <tr>
                <td colspan="3" style="font-weight: bold; font-size: large; text-transform: uppercase; width: 755px; color: crimson; height: 43px; background-color: gold;">TOUR RECOMMENTATION</td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; height: 16px">
                    <table border="1" style="width: 750px">
                        <tr>
                            <td colspan="4" style="height: 23px"></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 23px">
                                <table border="1" style="width: 742px">
                                    <tr>
                                        <td style="width: 112px; height: 29px; background-color: #33ffff;">
                                            <asp:Label ID="Label13" runat="server" Text="Select  Tour " Font-Bold="True"></asp:Label></td>
                                        <td style="width: 463px; height: 29px; background-color: #33ffff;">
                                            <asp:DropDownList ID="cmb_tour" runat="server" AutoPostBack="True" BackColor="Snow"
                                                Font-Bold="True" ForeColor="Blue" Width="568px">
                                                <asp:ListItem Value="0">---select tour---</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 51px; height: 23px">
                                <asp:Label ID="Label1" runat="server" Text="Employee Code" Width="114px"></asp:Label></td>
                            <td style="width: 94px; height: 23px">
                                <asp:TextBox ID="Txt_code" runat="server" Width="223px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
                            <td style="width: 62px; height: 23px; text-align: left;">&nbsp;<asp:Label ID="Label3" runat="server" Text="Designation"></asp:Label></td>
                            <td style="width: 99px; height: 23px">
                                <asp:TextBox ID="Tx_tdesignation" runat="server" Width="223px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 51px">&nbsp;<asp:Label ID="Label2" runat="server" Text="Name" Width="97px"></asp:Label></td>
                            <td style="width: 94px">
                                <asp:TextBox ID="Txt_name" runat="server" Width="221px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
                            <td style="width: 62px">
                                <asp:Label ID="Label4" runat="server" Text="Branch" Width="67px"></asp:Label></td>
                            <td style="width: 99px">
                                <asp:TextBox ID="Txt_branch" runat="server" Width="223px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; height: 15px">
                    <table border="1" style="width: 752px; height: 64px">
                        <tr>
                            <td style="width: 129px; height: 28px; text-align: left;">
                                <asp:Label ID="Label7" runat="server" Text="Tour Date  From"></asp:Label></td>
                            <td style="width: 231px; height: 28px; text-align: left;" colspan="2">
                                <asp:TextBox ID="Txt_from_date" runat="server" ReadOnly="True" BackColor="Snow" BorderColor="Snow" Width="221px"></asp:TextBox></td>
                            <td style="width: 62px; height: 28px">
                                <asp:Label ID="Label5" runat="server" Text="Tour Date To" Width="88px"></asp:Label></td>
                            <td colspan="2" style="height: 28px; text-align: left">
                                <asp:TextBox ID="Txt_date_to" runat="server" ReadOnly="True" BackColor="Snow" BorderColor="Snow" Width="219px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 129px; height: 28px; text-align: left;">
                                <asp:Label ID="Label8" runat="server" Text="Time From" Width="99px"></asp:Label></td>
                            <td style="width: 231px; height: 28px; text-align: left;" colspan="2">
                                <asp:TextBox ID="Txt_time_from" runat="server" ReadOnly="True" BackColor="Snow" BorderColor="Snow" Width="219px"></asp:TextBox></td>
                            <td style="width: 62px; height: 28px">
                                <asp:Label ID="Label6" runat="server" Text="Time To" Width="85px"></asp:Label></td>
                            <td colspan="2" style="height: 28px; text-align: left">
                                <asp:TextBox ID="Txt_to_date" runat="server" ReadOnly="True" BackColor="Snow" BorderColor="Snow" Width="219px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 70px">&nbsp;<asp:Label ID="Label9" runat="server" Text="Tour Advance Rs." Width="113px"></asp:Label></td>
                <td style="width: 101px">
                    <asp:TextBox ID="Txt_advance" runat="server" Width="319px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 70px; height: 23px">
                    <asp:Label ID="Label10" runat="server" Text="Tour Place" Width="110px"></asp:Label></td>
                <td style="width: 101px; height: 23px">
                    <asp:TextBox ID="Txt_place" runat="server" Width="321px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 70px; height: 23px">
                    <asp:Label ID="Label11" runat="server" Text="Tour Purpose" Width="109px"></asp:Label></td>
                <td style="width: 101px; height: 23px; text-align: left;">
                    <asp:TextBox ID="Txt_purpose" runat="server" TextMode="MultiLine" Width="321px" ReadOnly="True" BackColor="Snow" BorderColor="Snow"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 70px; height: 23px; background-color: #33ffff; text-align: left;">&nbsp;<asp:Label ID="Label12" runat="server" Text="Recommended By" Width="124px"></asp:Label></td>
                <td style="width: 101px; height: 23px; background-color: #33ffff; text-align: left;">
                    <asp:TextBox ID="Txt_recomment" runat="server" Width="321px" ReadOnly="True" BackColor="LemonChiffon" BorderColor="Khaki" Font-Bold="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; height: 43px;">
                    <table border="1" style="width: 752px">
                        <tr>
                            <td style="width: 79px; height: 23px">
                                <asp:Label ID="Label14" runat="server" Text="Decision" Width="70px"></asp:Label></td>
                            <td style="width: 100px; height: 23px">
                                <asp:RadioButton ID="rd_app" runat="server" AutoPostBack="True" GroupName="tour"
                                    Text="Approved" Font-Bold="True" ToolTip="Don't &quot;SELECT&quot; decision  while no data's  found above!" /></td>
                            <td style="width: 100px; height: 23px">
                                <asp:RadioButton ID="rd_rej" runat="server" AutoPostBack="True" GroupName="tour"
                                    Text="Rejected" Font-Bold="True" ToolTip="Don't &quot;SELECT&quot; decision  while no data's  found above!" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; height: 28px; background-color: #ffffcc;">
                    <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Names="Times New Roman" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; text-align: right; height: 13px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="width: 755px; height: 43px; background-color: moccasin;">
                    <div style="text-align: center">
                        <table style="width: 744px">
                            <tr>
                                <td style="width: 100px; height: 59px;"></td>
                                <td style="width: 6px; height: 59px;"></td>
                                <td style="width: 100px; height: 59px;"></td>
                                <td style="width: 125px; height: 59px;">
                                    <asp:Button ID="cmd_done" runat="server" BackColor="#E0E0E0" BorderColor="GrayText"
                                        ForeColor="Maroon" Text="DONE" Width="97px" Height="30px" BorderStyle="Dashed" Font-Bold="True" /><br />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                                <td style="width: 6px; height: 59px;"></td>
                                <td style="width: 131px; height: 59px;">
                                    <table style="height: 33px">
                                        <tr>
                                            <td style="width: 100px; height: 30px">
                                                <asp:Button ID="cmd_exit" runat="server" BackColor="#E0E0E0" BorderColor="GrayText"
                                                    Height="31px" Text="EXIT" Width="97px" BorderStyle="Dashed" Font-Bold="True" ForeColor="Maroon" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 151px; height: 59px;"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

