<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employ_employment_details.aspx.vb" Inherits="WebAppHRMS.posting_reports_employ_employment_details_f4a43e3a6037" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
    // <!CDATA[

    function cmd_exit_onclick() {
        window.open('../home.aspx', '_self');
    }

    // ]]>
    </script>
    <div style="text-align: center">
        &nbsp;
    </div>


    <table border="1" style="border-style: dashed; border-color: red; width: 1100px; height: 48px; text-align: center;">
        <tr>
            <td style="height: 48px; text-align: center;">
                <span style="font-size: 14pt; color: #cc3333;">
                    <strong>EMPLOYEE EMPLOYMENT SEARCH</strong>
                </span>
            </td>
        </tr>
    </table>


    <table border="1" style="width: 1000px; height: 100px">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table border="1" style="width: 1000px; height: 100px">
                            <tr>
                                <td colspan="3" style="text-align: right">SELECT ALL</td>
                                <td colspan="3" style="text-align: left">
                                    <asp:CheckBox ID="chk_all" runat="server" AutoPostBack="True" /></td>
                            </tr>
                            <tr>
                                <td style="width: 200px; height: 27px">
                                    <asp:CheckBox ID="chk_emp" runat="server" AutoPostBack="True" Width="110px" Height="32px" /></td>
                                <td style="width: 200px; height: 27px">EMPLOYEE TYPE</td>
                                <td style="width: 200px; height: 27px">
                                    <asp:DropDownList ID="cmb_type" runat="server" AutoPostBack="True" Width="200px">
                                        <asp:ListItem Value="1">REGULAR</asp:ListItem>
                                        <%-- ----------------KRISHNADAS--%>
                                        <asp:ListItem Value="2,3,4">TRAINEE/OUTSOURCE/TEMPORARY</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="width: 200px; height: 27px">
                                    <asp:CheckBox ID="chk_firm" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                <td style="width: 200px; height: 27px">FIRM</td>
                                <td style="width: 200px; height: 27px">
                                    <asp:DropDownList ID="cmb_firm" runat="server" AutoPostBack="True" Width="238px">
                                    </asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td style="width: 200px">
                                    <asp:CheckBox ID="chk_branch" runat="server" AutoPostBack="True" Width="110px" Height="32px" /></td>
                                <td style="width: 200px">BRANCH</td>
                                <td style="width: 200px">
                                    <asp:DropDownList ID="cmb_branch" runat="server" AutoPostBack="True" Width="266px">
                                    </asp:DropDownList></td>
                                <td style="width: 200px">
                                    <asp:CheckBox ID="chk_dep" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                <td style="width: 83px">DEPARTMENT</td>
                                <td style="width: 200px">
                                    <asp:DropDownList ID="cmb_dep" runat="server" AutoPostBack="True" Width="240px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 200px; height: 43px">
                                    <asp:CheckBox ID="chk_des" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                <td style="width: 200px; height: 43px">DESIGNATION</td>
                                <td style="width: 200px; height: 43px">
                                    <asp:DropDownList ID="cmb_des" runat="server" AutoPostBack="True" Width="266px">
                                    </asp:DropDownList></td>
                                <td style="width: 200px; height: 43px">
                                    <asp:CheckBox ID="chk_post" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                <td style="width: 200px; height: 43px">POST</td>
                                <td style="width: 200px; height: 43px">
                                    <asp:DropDownList ID="cmb_post" runat="server" AutoPostBack="True" Width="240px">
                                    </asp:DropDownList></td>
                            </tr>

                        </table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="139px" />
                <input id="cmd_exit" type="button" value="EXIT" onclick="return cmd_exit_onclick()" style="width: 151px" />
            </td>
        </tr>
        <%--<tr>
                        <td>
                        <cc1:listsearchextender id="ListSearchExtender3" runat="server" targetcontrolid="cmb_branch"></cc1:listsearchextender>
                         <cc1:listsearchextender id="ListSearchExtender2" runat="server" targetcontrolid="cmb_firm"></cc1:listsearchextender>
                         <cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="cmb_type"></cc1:listsearchextender>
                         <cc1:listsearchextender id="ListSearchExtender5" runat="server" targetcontrolid="cmb_des"></cc1:listsearchextender>
                        <cc1:listsearchextender id="ListSearchExtender4" runat="server" targetcontrolid="cmb_dep"></cc1:listsearchextender>
                         <cc1:listsearchextender id="ListSearchExtender6" runat="server" targetcontrolid="cmb_post"></cc1:listsearchextender>
                            
                        </td></tr>--%>
    </table>
    <%--<tr>
                            <td colspan="6" style="text-align: left"><asp:ScriptManager id="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: center; height: 24px;">
                                SELECT ALL<asp:CheckBox ID="chk_all" runat="server" AutoPostBack="True" Width="24px" /></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 191px">
                                <div style="text-align: center">
                                    <table>
                                        <tr>
                                        
                                            <td style="width: 100px; height: 164px;">
 
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" > <ContentTemplate>
                                                      
                                                <table border="1" style="display: block; border-left-color: #ffcccc; border-bottom-color: #ffcccc;
                                                    border-top-style: dotted; border-top-color: #ffcccc; border-right-style: dotted;
                                                    border-left-style: dotted; border-right-color: #ffcccc; border-bottom-style: dotted">
                                                    
                                                    <tr>
                                                            <td style="width: 2086px; height: 27px">
                                                           
                                                            <asp:CheckBox ID="chk_emp" runat="server" AutoPostBack="True" Width="110px" Height="32px" /></td>
                                                        <td style="width: 642148px; height: 27px">
                                                            EMPLOYEE TYPE</td>
                                                        <td style="width: 87px; height: 27px">
                                                            <asp:DropDownList ID="cmb_type" runat="server" AutoPostBack="True" Width="266px">
                                                                <asp:ListItem Value="1">REGULAR</asp:ListItem>
                                                                <asp:ListItem Value="2,3,4">TRAINEE/OUTSOURCE/TEMPORARY</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td style="width: 23px; height: 27px">
                                                            <asp:CheckBox ID="chk_firm" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                                        <td style="width: 83px; height: 27px">
                                                            FIRM</td>
                                                        <td style="width: 100px; height: 27px">
                                                            <asp:DropDownList ID="cmb_firm" runat="server" AutoPostBack="True" Width="238px">
                                                            </asp:DropDownList></td>
                                                    
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 2086px">
                                                            <asp:CheckBox ID="chk_branch" runat="server" AutoPostBack="True" Width="110px" Height="32px" /></td>
                                                        <td style="width: 642148px">
                                                            BRANCH</td>
                                                        <td style="width: 87px">
                                                            <asp:DropDownList ID="cmb_branch" runat="server" AutoPostBack="True" Width="266px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 23px">
                                                            <asp:CheckBox ID="chk_dep" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                                        <td style="width: 83px">
                                                            DEPARTMENT</td>
                                                        <td style="width: 100px">
                                                            <asp:DropDownList ID="cmb_dep" runat="server" AutoPostBack="True" Width="240px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 2086px; height: 43px">
                                                            <asp:CheckBox ID="chk_des" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                                        <td style="width: 642148px; height: 43px">
                                                            DESIGNATION</td>
                                                        <td style="width: 87px; height: 43px">
                                                            <asp:DropDownList ID="cmb_des" runat="server" AutoPostBack="True" Width="266px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 23px; height: 43px">
                                                            <asp:CheckBox ID="chk_post" runat="server" AutoPostBack="True" Height="32px" Width="110px" /></td>
                                                        <td style="width: 83px; height: 43px">
                                                            POST</td>
                                                        <td style="width: 100px; height: 43px">
                                                            <asp:DropDownList ID="cmb_post" runat="server" AutoPostBack="True" Width="240px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                        &nbsp;
                                 </ContentTemplate></asp:UpdatePanel>
                                <asp:Button ID="cmd_confirm" runat="server" Font-Bold="True" Text="CONFIRM" Width="139px" />
                                <asp:Button ID="cmd_exit" runat="server" Font-Bold="True" Text="EXIT" Width="151px" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <cc1:listsearchextender id="ListSearchExtender3" runat="server" targetcontrolid="cmb_branch"></cc1:listsearchextender>
                                <cc1:listsearchextender id="ListSearchExtender2" runat="server" targetcontrolid="cmb_firm"></cc1:listsearchextender>
                                <cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="cmb_type"></cc1:listsearchextender>
                                <cc1:listsearchextender id="ListSearchExtender5" runat="server" targetcontrolid="cmb_des"></cc1:listsearchextender>
                                <cc1:listsearchextender id="ListSearchExtender4" runat="server" targetcontrolid="cmb_dep"></cc1:listsearchextender>
                                <cc1:listsearchextender id="ListSearchExtender6" runat="server" targetcontrolid="cmb_post"></cc1:listsearchextender>
                            </td>
                        </tr>--%>
</asp:Content>

