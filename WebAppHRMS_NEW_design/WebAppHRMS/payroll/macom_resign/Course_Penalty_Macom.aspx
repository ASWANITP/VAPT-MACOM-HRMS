<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Course_Penalty_Macom.aspx.vb" Inherits="WebAppHRMS.Payroll_macom_resign_Course_Penalty_Macom_75516bea3920" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        //function Button2_onclick() {
        //window.open('../../home.aspx','_self');
        //}
        //function HandleOnCheck()
        //{
//  document.getElementById("<%=h1.ClientID %>").click();
        //}
        //function HandleOnCheck1()
        //{
//  document.getElementById("<%=h2.ClientID %>").click();
        //}


    </script>

    <div style="text-align: center">
        <table border="1" style="width: 500px; height: 75px;">
            <tr>
                <td colspan="4" style="height: 41px;">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Courier New"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">COURSE PENALTY DETAILS</span></strong></span></span></span>
                    </span></strong>
                </td>
            </tr>


            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Employee Code</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="txt_emp" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Employee Name</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="Txt_empname" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Course Name</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="Txt_course" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Course Duration(days)</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="Txt_durat" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Course Fee</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="Txt_fee" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 199px; text-align: left; height: 24px;">
                    <span style="font-family: Courier New"><strong>Penalty Amount</strong></span></td>
                <td style="width: 100px; text-align: center; height: 24px;">
                    <asp:TextBox ID="Txt_amount" ReadOnly="true" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <table border="1" style="width: 500px; height: 35px;">

            <tr>

                <td style="width: 250px; text-align: left; height: 41px;">

                    <asp:CheckBox ID="ch1" Text="I Accept the Penalty" onclick="return false;" Checked="true" runat="server" TextAlign="right" Width="490px"></asp:CheckBox>

                    &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                                 <%--   <asp:LinkButton ID="LinkButton1" runat="server">VIEW CIRCULAR</asp:LinkButton>--%>
                </td>

            </tr>
        </table>
        <table border="1" style="width: 500px; height: 35px;">
            <tr>
                <td style="width: 215px; height: 24px;">
                    <asp:Button runat="server" ID="b1" Text="Confirm" Width="69px" /></td>
                <%--<td style="height: 34px">--%>
                <%-- <input id="Button2" style="width: 76px" type="button" value="EXIT" onclick="return homeclick()" /> </td>--%>
                <%-- <td style="width: 133px; text-align: center;">
                    &nbsp;<input id="Button2" style="width: 76px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>--%>
                <td style="width: 100px">
                    <center />
                    <asp:Button ID="Cmd_Exit" runat="server" Text="EXIT" Width="111px" Height="29px" /></td>

            </tr>
        </table>
        <input style="display: none" type="button" id="h1" runat="server" />
        <input style="display: none" type="button" id="h2" runat="server" />
    </div>
</asp:Content>

