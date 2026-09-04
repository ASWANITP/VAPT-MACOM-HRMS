<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_LEAVE_APPLICATION.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_HRM_LEAVE_APPLICATION_6af975976451" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = loanno.split('txt')

        function btn_Exit_onclick() {
            window.open('../home.aspx', '_self')
        }


        function FillEmployDetails() {
            data = document.getElementById(cont[0] + "cmb_Select").value;
            data = data + "%" + 222;
            ToServer(data + "#" + 1, 1);
        }

        function FromServer(arg, context) {
            var Data = arg.split("@");
            //debugger;7/23/2009 12:00:00 AM!7/23/2009 12:00:00 AM!CASUAL!1!7/22/2009 12:00:00 AM@2  
            switch (context) {

                case 1:

                    Data1 = Data[0].split("!");
                    arg1 = Data[1];
                    {
                        document.getElementById(cont[0] + "txt_From").value = Data1[0];
                        document.getElementById(cont[0] + "txt_To").value = Data1[1];
                        document.getElementById(cont[0] + "txt_Type").value = Data1[2];
                        document.getElementById(cont[0] + "txt_Days").value = Data1[3];
                        document.getElementById(cont[0] + "txt_Apply").value = Data1[4];
                    }
                    break;
                case 2:


            }
        }

        function cmd_applnform_onclick() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_Select").value
            window.open("leave_apply_report.aspx?leave_seq=" + arr, '_self')
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td colspan="2">Select Leave
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="cmb_Select" onclick="FillEmployDetails()" runat="server" Width="392px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 13px" colspan="2">&nbsp; &nbsp;
                    </td>
                    <td colspan="2" style="height: 13px">
                        <span style="font-size: 11pt; color: #cc0099">( From Dt ----To Dt----Type----Days---Apply
                            Date)</span></td>
                </tr>
                <tr>
                    <td style="width: 118px; text-align: left">Leave From &nbsp;</td>
                    <td style="width: 113px">
                        <asp:TextBox ID="txt_From" runat="server" Width="147px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 102px; text-align: left">Leave To</td>
                    <td style="width: 100px; text-align: left">
                        <asp:TextBox ID="txt_To" runat="server" Width="143px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 118px; text-align: left">Leave Type&nbsp;</td>
                    <td style="width: 113px">
                        <asp:TextBox ID="txt_Type" runat="server" Width="147px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 102px; text-align: left">Leave days</td>
                    <td style="width: 100px; text-align: left">
                        <asp:TextBox ID="txt_Days" runat="server" Width="143px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 118px; text-align: left">Apply Date</td>
                    <td style="width: 113px">
                        <asp:TextBox ID="txt_Apply" runat="server" Width="147px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 102px">&nbsp;
                    </td>
                    <td style="width: 100px">&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <input id="Button1" type="button" value="Appln Form" onclick="return cmd_applnform_onclick()" /></td>
                    <td colspan="2" style="text-align: left">
                        <input id="btn_Exit" style="width: 102px" type="button" value="Exit" onclick="return btn_Exit_onclick()" /></td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

