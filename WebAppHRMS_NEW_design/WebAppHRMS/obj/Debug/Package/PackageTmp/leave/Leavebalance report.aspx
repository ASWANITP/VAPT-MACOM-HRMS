<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leavebalance report.aspx.vb" Inherits="WebAppHRMS.Leave_Leave_report_972c41178803" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
<%--                    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div>
    <div style="text-align: center">
            &nbsp;<table border="1" style="width: 600px; height: 46px;">
                <tr>
                    <td colspan="16" style="height: 5px; text-align: center; width: 201px;">
                        <span style="color: #cc0099; font-weight: bold; font-family: 'Courier New';">
                            <span>
                                <span><span style="font-family: Agency FB"><span>
                                    <span><span><span><span><span><span
                                        style="font-family: Colonna MT"><span style="font-size: 16pt"><span><span style="text-decoration: underline">
                                            <em>&nbsp;</em><span style="color: #003399">LEAVE&nbsp; DETAILS<span><span style="font-family: Agency FB">&nbsp;</span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 1px">
                        <strong>From&nbsp; date:</strong>

                    </td>
                    <td colspan="4" style="height: 1px; width: 479px;">
                        <asp:TextBox ID="TextBox8" runat="server" Width="227px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="TextBox8"></cc1:CalendarExtender>
                    </td>
                    <td colspan="2" style="width: 117px; height: 1px">
                        <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                 Todate:</strong>
                    </td>
                    <td style="width: 209px; height: 1px;">
                        <asp:TextBox ID="TextBox9" runat="server" Width="225px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="TextBox9"></cc1:CalendarExtender>
                    </td>


                </tr>
                <tr>
                    <td colspan="6">


                        <asp:Button ID="Button3" runat="server" Text="CONFIRM" Width="89px" /></td>
                    <td colspan="6">
                        <asp:Button ID="Button2" runat="server" Text="EXIT" Width="55px" /></td>
                </tr>
                <%--  <tr style="color: #000000"> 
                    <td    colspan="2"style="height: 21px">
                        <strong><em>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; LeaveType:</em></strong></td>
                    <td  colspan="6" style="height: 21px; width: 61px;">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="238px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">CASUAL </asp:ListItem>
                        <asp:ListItem Value="2">SICK</asp:ListItem>
                        <asp:ListItem Value="3">EARNED</asp:ListItem>
                        <asp:ListItem Value="4">LOP</asp:ListItem>
                        <asp:ListItem Value="10">MATERNITY</asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                    </tr>--%>
            </table>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
