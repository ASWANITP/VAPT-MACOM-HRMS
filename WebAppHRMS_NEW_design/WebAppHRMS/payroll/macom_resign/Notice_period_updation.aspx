<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Notice_period_updation.aspx.vb" Inherits="WebAppHRMS.Shift_Change_hrm_shiftChange_3ddee0529768" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

//<%--<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
//<script language="javascript" type="text/javascript" for="window" event="onload">--%>
        // <!CDATA[



        function Button2_onclick() {
            window.open('../../home.aspx', '_self');
        }



</script>
    <div style="text-align: center">
        <table border="1" style="width: 600px">
            <tr align="left">
                <td align="center"><span style="color: #ff0033"></span>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <cc1:CalendarExtender ID="CalendarExtender1"
                        runat="server" Format="dd/MMM/yyyy" TargetControlID="Txtdate"></cc1:CalendarExtender>

                    <div style="text-align: center">
                        <asp:HiddenField ID="Hidden2" runat="server" />
                        <br />
                        <b>
                            <asp:Label ID="Label1" runat="server" ForeColor="Brown" Height="20px" Text="NOTICE PERIOD UPDATION"></asp:Label>
                        </b>
                        <br />
                        <br />
                        <br />
                        <table border="1" style="width: 70%">
                            <tr>
                                <td colspan="2" style="height: 42px">
                                    <asp:Label ID="Label2" runat="server" Height="34px" Text="Select Employee                                                  "
                                        Visible="true" Width="199px" Style="text-align: left"></asp:Label></td>
                                <td colspan="2" style="text-align: left; height: 42px; width: 196px">
                                    <asp:DropDownList ID="ddlEmpname" runat="server" Width="180px" AutoPostBack="True">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 170%; text-align: left; height: 28px;" colspan="2">Current Exit Date</td>
                                <td style="width: 170px; height: 28px;">
                                    <asp:TextBox ID="txtcurr" runat="server" Width="180px" ReadOnly="True"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td style="width: 170%; text-align: left" colspan="2">Proposed Exit Date</td>
                                <td style="width: 120%">
                                    <asp:TextBox ID="Txtdate" runat="server" Width="180px"></asp:TextBox></td>

                            </tr>



                            <tr>
                                <td style="height: 56px" colspan="4">&nbsp;
                   
                                    <asp:Button ID="Btn_confirm" runat="server" Text="CONFIRM" Height="28px" Width="93px" Style="cursor: hand; text-align: center" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                    
          

                                    <input id="Button2" style="width: 93px; height: 28px" type="button" value="EXIT" onclick="return Button2_onclick()" />



                                </td>
                            </tr>

                        </table>




                    </div>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

