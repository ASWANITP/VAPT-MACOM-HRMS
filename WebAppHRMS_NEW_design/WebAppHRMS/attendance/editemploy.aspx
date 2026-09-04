<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editemploy.aspx.vb" Inherits="WebAppHRMS.employ_editemploy_778ffe944910" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }

        // ]]>
    </script>

    <table align="center" style="width: 354px" border="1">
        <tr>
            <td style="text-align: center; height: 23px;" colspan="2">
                <span style="color: #3366cc"><strong>EDIT EMPLOYEE<asp:ScriptManager ID="ScriptManager1"
                    runat="server">
                </asp:ScriptManager>
                </strong></span>
            </td>
        </tr>
        <tr>
            <th colspan="2">
                <table align="center" border="1">
                    <caption style="font: smallcaption; text-transform: uppercase; color: navy; text-decoration: underline">
                        <span id="SPAN1" style="font-size: 10pt"></span>
                    </caption>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help; height: 23px">Employee Id</th>
                        <th align="left" style="width: 151px; height: 23px">
                            <asp:DropDownList ID="cmb_id" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_id_SelectedIndexChanged"
                                Width="231px">
                            </asp:DropDownList>
                            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_id">
                            </cc1:ListSearchExtender>
                        </th>
                    </tr>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help; height: 23px">EmployeeName</th>
                        <th align="left" style="width: 151px; height: 23px">
                            <asp:TextBox ID="txt_name" runat="server" Width="224px"></asp:TextBox></th>
                    </tr>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help; height: 23px">Designation</th>
                        <th align="left" style="width: 151px; height: 23px">
                            <asp:DropDownList ID="cmb_desg" runat="server" Style="cursor: hand" Width="231px">
                            </asp:DropDownList></th>
                    </tr>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help; height: 26px">Department</th>
                        <th align="left" style="width: 151px; height: 26px">
                            <asp:DropDownList ID="cmb_dept" runat="server" Style="cursor: hand" Width="230px">
                            </asp:DropDownList></th>
                    </tr>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help">Branch</th>
                        <th align="left" style="width: 151px">
                            <asp:DropDownList ID="cmb_branch" runat="server" Style="cursor: hand" Width="230px">
                            </asp:DropDownList></th>
                    </tr>
                    <tr>
                        <th align="left" style="font: caption; width: 154px; cursor: help">Shift</th>
                        <th align="left" style="width: 151px">
                            <asp:DropDownList ID="cmb_shift" runat="server" Style="cursor: hand" Width="231px">
                            </asp:DropDownList></th>
                    </tr>
                </table>
            </th>
        </tr>
        <tr>
            <th style="width: 154px">
                <asp:Button ID="btn_confirm" runat="server" Style="border-right: thin groove; border-top: thin groove; border-left: thin groove; cursor: hand; border-bottom: thin groove"
                    Text="Confirm" /></th>
            <th align="center" style="width: 148px">
                <input id="Button1" style="width: 68px; height: 25px;" type="button" value="Exit" onclick="return Button1_onclick()" /></th>
        </tr>
    </table>
</asp:Content>

