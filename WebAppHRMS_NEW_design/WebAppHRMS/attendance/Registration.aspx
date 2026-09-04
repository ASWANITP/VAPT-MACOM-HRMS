<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Registration.aspx.vb" Inherits="WebAppHRMS.Registration_137483614248" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <table border="1">
            <caption style="font: smallcaption; text-transform: uppercase; color: navy; text-decoration: underline">
                <span style="font-size: 10pt; font-weight: bolder;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    Employee Registration</span></caption>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help; background-color: transparent">Employee ID</th>
                <th align="left" style="width: 159px">
                    <asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="False" Mask="999999" MaskType="Number" TargetControlID="txt_id"></cc1:MaskedEditExtender>
                </th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help">Employee Name</th>
                <th align="left" style="width: 159px">
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help; height: 23px">Designation</th>
                <th align="left" style="width: 159px; height: 23px">
                    <asp:DropDownList ID="cmb_desg" runat="server" Style="cursor: hand" Width="155px">
                    </asp:DropDownList></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help; height: 26px;">Department</th>
                <th align="left" style="width: 159px; height: 26px;">
                    <asp:DropDownList ID="cmb_dept" runat="server" Style="cursor: hand" Width="155px">
                    </asp:DropDownList></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help">Branch</th>
                <th align="left" style="width: 159px">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="152px" Style="cursor: hand">
                    </asp:DropDownList></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help">Firm</th>
                <th align="left" style="width: 159px">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="152px" Style="cursor: hand">
                    </asp:DropDownList></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help">Date of joining</th>
                <th align="left" style="width: 159px">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_joindt"></cc1:CalendarExtender>
                    <asp:TextBox ID="txt_joindt" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
                <th align="left" style="font: caption; width: 154px; cursor: help">Shift</th>
                <th align="left" style="width: 159px">
                    <asp:DropDownList ID="cmb_shift" runat="server" Width="154px" Style="cursor: hand">
                    </asp:DropDownList></th>
            </tr>
            <tr>
                <th style="width: 154px">
                    <asp:Button ID="btn_confirm" runat="server" Style="cursor: hand; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove;" Text="Confirm" /></th>
                <th align="center" style="width: 159px">
                    <asp:Button ID="btn_cancel" runat="server" ForeColor="Black" Style="cursor: hand; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove;" Text="Cancel" /></th>
            </tr>
        </table>
    </div>
</asp:Content>

