<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Referal_incentive_desig_add.aspx.vb" Inherits="WebAppHRMS.referal_incentive_add_designation_556565188171" Title="Untitled Page" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        //'--KRISHNADAS CREATED FOR JEWEL REFERRAL INCENTIVE
        function changes() {
            debugger;
            var str = document.getElementById('<%= txt_total.ClientID %>').value;
    if (str == ' ') {
        document.getElementById('<%= txt_total.ClientID %>').value = "";
                document.getElementById('<%= txt_total.ClientID %>').focus;
        return false;
    }
    if (isNaN(str)) {
        document.getElementById('<%= txt_total.ClientID %>').value = "";
                document.getElementById('<%= txt_total.ClientID %>').focus;
                return false;
            }
        }


        function changet() {
            var str = document.getElementById('<%= txt_first.ClientID %>').value;
    if (str == ' ') {
        document.getElementById('<%= txt_first.ClientID %>').value = "";
    document.getElementById('<%= txt_first.ClientID %>').focus;
        return false;
    }
    if (isNaN(str)) {
        document.getElementById('<%= txt_first.ClientID %>').value = "";
     document.getElementById('<%= txt_first.ClientID %>').focus;
                return false;
            }

        }

        function changeu() {
            var str = document.getElementById('<%= txt_second.ClientID %>').value;
     if (str == ' ') {
         document.getElementById('<%= txt_second.ClientID %>').value = "";
    document.getElementById('<%= txt_second.ClientID %>').focus;
         return false;
     }
     if (isNaN(str)) {
         document.getElementById('<%= txt_second.ClientID %>').value = "";
     document.getElementById('<%= txt_second.ClientID %>').focus;
                return false;
            }

        }


        function changev() {
            var str = document.getElementById('<%= txt_third.ClientID %>').value;
       if (str == ' ') {
           document.getElementById('<%= txt_third.ClientID %>').value = "";
    document.getElementById('<%= txt_third.ClientID %>').focus;
           return false;
       }
       if (isNaN(str)) {
           document.getElementById('<%= txt_third.ClientID %>').value = "";
     document.getElementById('<%= txt_third.ClientID %>').focus;
                return false;
            }
        }
        function Button2_onclick() {
            window.open('../home.aspx', '_self')
        }

    </script>

    <div style="text-align">
        <div style="text-align: center;">
            <div style="text-align: center;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table border="1" style="width: 56%; height: 155px;">
                            <tr>
                                <td colspan="2" style="font-weight: bold; font-size: medium; height: 30px">REFERRAL INCENTIVE-DESIGNATION ADD</td>
                            </tr>

                            <tr>
                                <td style="width: 544%">
                                    <asp:Label ID="lbl_desug" runat="server" Height="24px" Text="DESIGNATION"
                                        Width="232px"></asp:Label></td>
                                <td style="width: 20%">
                                    <asp:DropDownList ID="cmb_desig" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                                        Width="312px" AutoPostBack="True">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 544%; height: 5px;">
                                    <asp:Label ID="lbl_TOTAL" runat="server" Height="24px" Text="TOTAL INCENTIVE" Width="232px"></asp:Label></td>
                                <td style="width: 20%; height: 5px;">
                                    <asp:TextBox ID="txt_total" runat="server" Width="300px" onkeypress="return changes();" MaxLength="7"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 544%">
                                    <asp:Label ID="lbl_emi1" runat="server" Height="24px" Text="FIRST STAGE AMOUNT" Width="232px"></asp:Label></td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txt_first" runat="server" Width="300px" onkeypress="return changet();" MaxLength="7"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 544%">
                                    <asp:Label ID="lbl_emi2" runat="server" Height="24px" Text="SECOND STAGE AMOUNT"
                                        Width="232px"></asp:Label></td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txt_second" runat="server" Width="300px" onkeypress="return changeu();" MaxLength="7"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 544%">
                                    <asp:Label ID="lbl_emi3" runat="server" Height="24px" Text="THIRD  STAGE AMOUNT"
                                        Width="232px"></asp:Label></td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="txt_third" runat="server" Width="300px" onkeypress="return changev();" MaxLength="7"></asp:TextBox></td>
                            </tr>

                        </table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>
    <div style="text-align: center">
        <input id="btn_Confirm" style="font-size: 12pt; width: 93px; font-family: 'Times New Roman'"
            type="button" value="Confirm" runat="server" onserverclick="btn_Confirm_ServerClick" />
        <input id="Button2" style="font-size: 12pt; width: 82px; font-family: 'Times New Roman'"
            type="button" value="Exit" onclick="return Button2_onclick()" />
    </div>
</asp:Content>

