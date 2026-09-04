<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="department_updation.aspx.vb" Inherits="WebAppHRMS.Payroll_department_structure_department_updation_152b77245816" Title="Untitled Page" %>

<%--<%@ MasterType VirtualPath="~/edp.master"%>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function isNumberKey(ids) {
            var charcode = (event.which) ? event.which : event.keyCode
            if (ids == 1) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32)) {
                    return true;
                }
                else
                    return false;
            }
            if (ids == 2) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32) || (charcode > 46 && charcode < 58)) {
                    return true;
                }
                else
                    return false;
            }
            if (ids == 3) {
                if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                    return false;
                }
                else
                    return true;
            }
        }
    </script>

    <%--
 <form id="form1" runat="server">--%>
    <div style="text-align: center">
        <table border="1" style="width: 49%; height: 50px;">
            <tr>
                <td colspan="4" style="height: 32px">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">ADD NEW EMPLOYEE</span></strong>
                        </span></span></span>
                        <%--   <asp:Label ID="Label1" runat="server" Text="ADD NEW EMPLOYEE"></asp:Label>--%></td>
            </tr>
        </table>
    </div>

    <div style="text-align: center"></div>
    <div style="text-align: center">
        <%--<asp:Panel ID="Panel1" runat="server" Width="471px">
    </asp:Panel> --%>
        <table border="1" style="width: 49%; height: 104px;">
            <tr>
                <td style="text-align: left; width: 277px;" colspan="2">Select&nbsp;Head</td>
                <td style="text-align: left; width: 277px;" colspan="2">
                    <%-- <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddl_tech" AutoPostBack="true" runat="server" Width="272px" Font-Names="Times New Roman" Font-Size="Medium"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align: left; width: 277px;" colspan="2">Enter&nbsp;New&nbsp;Member&nbsp;EmpCode</td>
                <td style="text-align: left; width: 277px;" colspan="2">
                    <asp:TextBox ID="txt_NewHead" AutoPostBack="true" runat="server" Width="272px" MaxLength="6" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left; width: 277px;" colspan="2">New&nbsp;Employee&nbsp;Name</td>
                <td style="text-align: left; width: 277px;" colspan="2">
                    <asp:TextBox ID="txt_Name" runat="server" AutoPostBack="true" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True" Width="272px"></asp:TextBox></td>
            </tr>
            <tr>

                <td colspan="4" style="height: 32px">
                    <asp:Button ID="btn_conemp" runat="server" Text="Add" />
                    <asp:Button ID="btn_exitemp" runat="server" Text="Exit" /></td>

            </tr>
        </table>

        <div style="text-align: center">
            <table border="1" style="width: 49%; height: 50px;">
                <tr>
                    <td colspan="8" style="height: 32px">
                        <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                            <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                                <strong><span style="text-decoration: underline">ADD NEW HEAD</span></strong>
                            </span></span></span>
                            <%-- <asp:Label ID="Label2" runat="server" Text="ADD NEW HEAD"></asp:Label>--%> </td>
                </tr>
            </table>
        </div>
        <div style="text-align: center"></div>
        <table border="1" style="width: 49%; height: 104px;">
            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">Enter&nbsp;New&nbsp;Head&nbsp;Empcode</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="txt_newemp" AutoPostBack="true" runat="server" Width="272px" MaxLength="6" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">Head Name</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="TextBoxname" AutoPostBack="true" runat="server" Width="272px"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">Enter&nbsp;Member&nbsp;EmpCode</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="txt_DepHead" AutoPostBack="true" runat="server" Width="272px" MaxLength="6" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">Employee Name</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="272px"></asp:TextBox></td>
            </tr>

            <tr>
                <%--<td style="text-align: left; width: 277px; height: 28px;" colspan="4">--%>
                <%-- <td colspan="4" style="height: 32px; width: 151px;"> --%>
                <td colspan="8" style="height: 32px">
                    <asp:Button ID="btn_confirm" runat="server" Text="Confirm" />
                    <asp:Button ID="btn_exit" runat="server" Text="Exit" />
                </td>
            </tr>
        </table>
    </div>






    <div style="text-align: center">
        <table border="1" style="width: 49%; height: 50px;">
            <tr>
                <td colspan="8" style="height: 32px">
                    <strong><span style="font-size: 15pt; color: #cc0099; font-weight: bold; font-family: 'Courier New'; text-decoration: underline;">
                        <span style="color: #cc0000"><span style="font-family: Agency FB"><span style="font-size: 16pt">
                            <strong><span style="text-decoration: underline">CHANGE HEAD</span></strong>
                        </span></span></span>
                        <%--  <asp:Label ID="Label4" runat="server" Text="CHANGE HEAD"></asp:Label>--%> </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="1" style="width: 49%; height: 104px;">
            <%-- <tr>
              <td colspan="4" style="height: 32px;width: 277px; "> Current&nbsp;Head&nbsp;Empcode</td>
              <td colspan="4" style="height: 32px"> <asp:TextBox ID="txt_currcode" AutoPostBack="true" runat="server" Width="272px" MaxLength="6"></asp:TextBox></td>
            </tr--%>
            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">Current&nbsp;Head&nbsp;Name</td>
                <td>
                    <asp:DropDownList ID="ddl_currname" AutoPostBack="true" runat="server" Width="272px" Font-Names="Times New Roman" Font-Size="Medium"></asp:DropDownList></td>
                <%--  <td colspan="4" style="height: 32px"> <asp:TextBox ID="txt_currname"  AutoPostBack="true" runat="server" Width="272px" ></asp:TextBox>--%>
            </tr>

            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">New&nbsp;Head&nbsp;EmpCode</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="txt_newh" AutoPostBack="true" runat="server" Width="272px" MaxLength="6" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 32px; width: 277px;">New&nbsp;Head&nbsp;Name</td>
                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="txt_newname" runat="server" Width="272px"></asp:TextBox></td>
            </tr>

            <tr>
                <%--<td style="text-align: left; width: 277px; height: 28px;" colspan="4">--%>
                <%--  <td colspan="8" style="height: 32px; width: 151px;"> --%>
                <td colspan="8" style="height: 32px">
                    <asp:Button ID="Button3" runat="server" Text="Confirm" />
                    <asp:Button ID="Button4" runat="server" Text="Exit" />
                </td>
            </tr>
        </table>
    </div>




    <%--  </form>--%>
</asp:Content>
