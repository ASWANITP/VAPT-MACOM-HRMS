<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Approval_bulk.aspx.vb" Inherits="WebAppHRMS.bulk_upload_Approval_bulk_19edc3762153" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function Button2_onclick() {
            window.open('../home.aspx', '_self');
        }
        function van() {
            alert("Please select date from calendar! ")
            return false;
        }

script src = "~/script/jquery.min.js" type = "text/javascript" ></script>
    <script src="~/script/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    <script type="text/javascript">     

</script>
    &nbsp;<div style="text-align: center">
        <table border="1" style="border-collapse: collapse;">
            <tr>
                <td colspan="4" style="width: 550px; height: 20px;">
                    <strong style="font-size: 25px;">Approval-Bulk Upload<br />
                    </strong>
                </td>


            </tr>


            <tr>
                <td colspan="4" style="width: 550px">
                    <br />
                    <br />
                    <input style="width: 0.01px; height: 0px; color: #faebd7; border-color: #faebd7; background-color: #faebd7; float: right; display: none;" type="button" id="bt1" runat="server" />


                    <b>SELECT CATEGORY:</b>&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>


                    <form method="post" action="">

                        <asp:Button ID="Button1" runat="server" Text="VIEW EXCEL FILE" /><br />
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="True">
                        </asp:GridView>
                        <br />





                        <asp:Button ID="cmd_confirm" runat="server" Text="APPROVE" Width="109px" />
                        <asp:Button ID="cmd_reject" runat="server" Text="REJECT" Width="109px" />
                        <asp:Button ID="Button2" runat="server" Text="EXIT" Width="93px" /><br />

                    </form>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 550px"></td>

            </tr>

        </table>

    </div>
    <div id="divResult"></div>
</asp:Content>

