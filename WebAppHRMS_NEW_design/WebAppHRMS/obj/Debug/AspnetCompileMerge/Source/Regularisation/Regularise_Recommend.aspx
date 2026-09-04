<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Regularise_Recommend.aspx.vb" Inherits="WebAppHRMS.Regularise_Recommend_5a3b40a91770" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[

function btn_exit_onclick() {
window.open('../home.aspx','_self')
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="HiddenField1" runat="server" />
               <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
              
   <%--     <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtDate" runat="server">
                </cc1:CalendarExtender>--%>
                  <table border="1" style="width: 656px; height: 72px">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">
                     REGULARISATION
                        RECOMMENDATION</span></strong></td></tr>
                        </table>
        <table border="1">
            <caption>
            
            </caption>
            <tr>
                <td colspan="2" style="width: 275px; height: 26px">
                    <strong>-----Select Employee-----</strong></td>
                <td style="width: 244px; height: 26px">
                </td>
                <td colspan="2" style="width: 135px; height: 26px; text-align: left">
                    <asp:DropDownList ID="drpdwn_employee" runat="server" Width="342px" OnSelectedIndexChanged="drpdwn_employee_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
              
            <tr>
                <td colspan="2" style="width: 275px; height: 26px">
                    <strong>-----Select Date-----</strong></td>
                <td style="width: 244px; height: 26px">
                </td>
                <td colspan="2" style="width: 90px; height: 26px; text-align: left"><asp:DropDownList ID="Ddldate" runat="server" Width="200px" AutoPostBack="True">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 34px">100
                    <asp:Panel ID="Panel1" runat="server">
                        <div style="text-align: center">
                            <div style="text-align: center">
                                <table border="1" style="width: 450px">
                                    <caption>
                                        <strong><span style="color: maroon">-------Punching Details---------</span></strong></caption>
                                    <tr>
                                        <td style="width: 73px; height: 8px">
                                            <strong><span style="font-size: 11pt; color: black">Employee code</span></strong></td>
                                        <td style="width: 100px; height: 8px">
                                            <strong><span style="color: black">Employee Name</span></strong></td>
                                        <td style="width: 100px; height: 8px">
                                            <strong><span style="color: black">Morning Time</span></strong></td>
                                        <td style="width: 100px; height: 8px">
                                            <strong><span style="color: black">Evening Time</span></strong></td>
                                        <td style="width: 2px; height: 8px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 73px">
                                            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="127px"></asp:TextBox></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" Width="215px"></asp:TextBox></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" Width="145px"></asp:TextBox></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" Width="125px"></asp:TextBox></td>
                                        <td style="width: 2px">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 275px; height: 28px;">
                    <strong><span style="color: black">Recommend/Reject/Sanction Reason</span></strong></td>
                <td style="width: 244px; height: 28px;">
                </td>
                <td colspan="2" style="width: 135px; height: 28px;">
                    <asp:TextBox ID="txt_recom_reason" runat="server" Width="337px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 275px; height: 19px">
                    <strong>-----View Document-----</strong></td>
                <td style="width: 244px; height: 19px">
                  <asp:Button ID="btn_dwnlod" runat="server" BorderStyle="Groove" Text="Download" Width="100px" /></td>
                <td colspan="2" style="width: 135px; height: 19px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 275px; height: 19px">
                </td>
                <td style="width: 244px; height: 19px">
                </td>
                <td colspan="2" style="width: 135px; height: 19px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 275px; height: 19px">
                    <asp:Button ID="btn_recommend" runat="server" BorderStyle="Groove" ForeColor="Black"
                        Text="Recommend" Width="100px" />&nbsp;
                    </td>
                <td style="width: 244px; height: 19px;">
                    <asp:Button ID="btn_reject" runat="server" BorderStyle="Groove" Text="Reject" Width="93px" /></td>
                <td colspan="2" style="height: 19px; width: 135px; text-align: center;">
                    &nbsp;<input id="btn_exit" style="width: 96px" type="button" value="Exit" onclick="return btn_exit_onclick()" /></td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

