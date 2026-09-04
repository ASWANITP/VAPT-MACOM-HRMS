<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="DepatmtHeadApprove.aspx.vb" Inherits="WebAppHRMS.DepatmtHeadApprove_a908a8d93399" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <style>
        /* ── Outer Container ───────────────────────────────────────────────────── */
        #shiftApprovalFormContainer {
            max-width: 600px;
            margin: 20px auto;
            padding: 15px;
            background: linear-gradient(to right, #b3cde0, #f0f8ff); /* soft blue fade */
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            box-sizing: border-box;
        }

        /* ── Table Layout ──────────────────────────────────────────────────────── */
        #tblShiftApproval {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }

            #tblShiftApproval td {
                width: 50%;
                padding: 8px;
                vertical-align: top;
            }

        /* ── Centered First Row & Odd Items ─────────────────────────────────── */
        .scrCenterCell {
            text-align: center;
            padding-bottom: 12px;
        }

            .scrCenterCell label {
                display: block;
                font-weight: bold;
                color: #2F4F6F;
                margin-bottom: 6px;
            }

        /* ── Labels ─────────────────────────────────────────────────────────── */
        #tblShiftApproval label {
            display: block;
            font-weight: bold;
            color: #2F4F6F;
            margin-bottom: 4px;
            text-align: left;
        }

        /* ── Inputs & Selects ───────────────────────────────────────────────── */
        .scrTextBox,
        #tblShiftApproval select {
            width: 100%;
            padding: 6px 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

            .scrTextBox[readonly] {
                background-color: #f5f5f5;
            }

        /* ── Buttons & Messages ─────────────────────────────────────────────── */
        .scrButtonCell {
            text-align: center;
            padding-top: 12px;
        }

        .scrButton {
            padding: 8px 20px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            transition: background-color .3s ease;
            margin: 0 5px;
        }

            .scrButton:hover {
                background-color: #1c5fc0;
            }

        .scrLabel {
            font-size: 14px;
            color: green;
            margin-top: 10px;
            display: block;
        }
    </style>

    <script type="text/javascript">
        function fill_res() {
            var arg;
            arg = 9 + "$" + document.getElementById(cont[0] + "DropDownList1").value;
            sub_call_server(arg, 2);
        }
    </script>

    <div id="shiftApprovalFormContainer">
        <table id="tblShiftApproval">
            <tr>
                <td colspan="2" class="scrCenterCell">
                    <label style="font-size: 16pt; text-align:center;">DepartmentHead Approval</label>
                </td>
            </tr>

            <tr>
                <td>
                    <label for="DropDownList1">Select Department</label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        runat="server" AutoPostBack="True" CssClass="scrTextBox">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <label for="txt_previousdptmt">Current Department Head</label>
                </td>
                <td>
                    <asp:TextBox ID="txt_previousdptmt" CssClass="scrTextBox" runat="server" ReadOnly="true" />
                </td>
            </tr>

            <tr>
                <td>
                    <label for="txt_newdptmthead">New Department Head</label>
                </td>
                <td>
                    <asp:TextBox ID="txt_newdptmthead" CssClass="scrTextBox" runat="server" ReadOnly="true" />
                </td>
            </tr>

            <tr>
                <td colspan="2" class="scrButtonCell">
                    <asp:Button ID="btnapprove" runat="server" Text="APPROVE" CssClass="scrButton" />&nbsp;
                    <asp:Button ID="btnrjct" runat="server" Text="REJECT" CssClass="scrButton" />&nbsp;
                    <asp:Button ID="btnext" runat="server" Text="EXIT" CssClass="scrButton" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
