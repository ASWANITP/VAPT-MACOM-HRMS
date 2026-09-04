<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Comp_Approval.aspx.vb" Inherits="WebAppHRMS.Comp_Approval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script>
        function cmd_ext_onclick() {
            window.open('../../home.aspx', '_self');
        }
        function listadd() {
            debugger;
          
            if (document.getElementById("chk_branch").checked) {
                let branchValue = document.getElementById("cmb_branch").value;
                if (branchValue == -1) {
                    alert("Select Branch");
                    return false;
                }

                //let hiddenField = document.getElementById("Hidden2");
                document.getElementById("Hidden2").value = <%: Session("branch_id") %>;


                // hiddenField.value = hiddenField.value ? hiddenField.value + "#" + branchValue : branchValue;
            }
          
            if (document.getElementById("chk_emp").checked) {
                let empValue = document.getElementById("cmb_emp").value;
                if (empValue == -1) {
                    alert("Select Employee");
                    return false;
                }

                let hiddenField = document.getElementById("Hidden2");
                if (hiddenField.value.includes(empValue)) {
                    alert("Already Added");
                    return false;
                }

                hiddenField.value = hiddenField.value ? hiddenField.value + "#" + empValue : empValue;
            }

        }
        function validateApproval() {
            var branchChecked = document.getElementById("chk_branch").checked;
            var empChecked = document.getElementById("chk_emp").checked;

            if (!branchChecked && !empChecked) {
                alert("Please select either Branch Wise or Employee Wise checkbox before approving.");
                return false; // Prevent postback
            }

            return true; // Allow postback
        }
        function validateBranchCheckbox(cb) {
            var branchDropdown = document.getElementById("cmb_branch");

            if (cb.checked) {
                
                if (!branchDropdown || branchDropdown.options.length <= 1) {
                    alert("No data found");
                    cb.checked = false; // Uncheck the box
                    return false;
                }
            }
            return true;
        }
        
        function toggleBranchDropdown() {
            var branchCheckbox = document.getElementById("chk_branch");
            var branchDropdown = document.getElementById("cmb_branch");

            branchDropdown.disabled = !branchCheckbox.checked;
        }

        
            function toggleSelectAll(source) {
        var grid = document.getElementById('<%= gvEmpComp.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[id*='chkSelect']");

            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = source.checked;
        }
    }
   


    </script>




    <style>
       

        /* ── Outer Container ───────────────────────────────────────────────────── */
        #shiftApprovalFormContainer {
            max-width: 650px;
            margin: 20px auto;
            padding: 15px;
            background: linear-gradient(to right, #b3cde0, #f0f8ff);
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            box-sizing: border-box;
        }

        /* ── Table ───────────────────────────────────────────────────────────── */
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

            #tblShiftApproval label {
                display: block;
                font-weight: bold;
                color: #2F4F6F;
                margin-bottom: 6px;
                text-align: left;
            }

            /* ── Inputs & Dropdowns ──────────────────────────────────────────────── */
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

        /* ── Buttons ─────────────────────────────────────────────────────────── */
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
    </style>

    <div id="shiftApprovalFormContainer">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <table id="tblShiftApproval">
            <!-- Branch Selection Row -->
            <tr>
                <td>
                    <label for="chk_branch">Branch Wise Compensatory Assigned</label>
                    <asp:CheckBox ID="chk_branch" runat="server" CssClass="scrTextBox" Text="" ClientIDMode="Static" onclick="return validateBranchCheckbox(this);" />
                </td>
                <td>
                    <label for="cmb_branch">Branch</label>
                    <asp:DropDownList ID="cmb_branch" runat="server" CssClass="scrTextBox" onchange="listadd()" ClientIDMode="Static" />
                </td>
            </tr>

            <!-- Employee Selection + Grid Update -->
            <tr>
                <td>
                    <label for="chk_emp">Employee Wise Compensatory Assigned</label>
                    <asp:CheckBox ID="chk_emp" runat="server" CssClass="scrTextBox" Text="" AutoPostBack="true" onchange="listadd()" ClientIDMode="Static"   />
                </td>
                <td>
                    <asp:UpdatePanel ID="upEmpGrid" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gvEmpComp"
                                runat="server"
                                DataKeyNames="com_id"
                                AutoGenerateColumns="False"
                                Visible="false"
                                CssClass="scrTextBox"
                                GridLines="None"
                                AllowPaging="true"
                                PageSize="10"
                                Width="100%">
                               <%-- <Columns>
                                   
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                                    <asp:BoundField DataField="CompensatoryDate" HeaderText="Compensatory Date" />
                                    <asp:BoundField DataField="CompensatoryName" HeaderText="Compensatory Name" />
                                </Columns>--%>
                                <Columns>
    

    <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
    <asp:BoundField DataField="CompensatoryDate" HeaderText="Compensatory Date" />
    <asp:BoundField DataField="CompensatoryName" HeaderText="Compensatory Name" />

                                    <asp:TemplateField HeaderText="">
    <HeaderTemplate>
        <div style="text-align: center;">
            <span style="display: block; font-weight: bold; color: black;">Select</span>
            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleSelectAll(this);" />
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox ID="chkSelect" runat="server" />
    </ItemTemplate>
</asp:TemplateField>
</Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="chk_emp" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <!-- Buttons Row -->
            <tr>
                <td colspan="2" class="scrButtonCell">
                    <asp:Button ID="cmd_confirm"
                        runat="server"
                        Text="APPROVE"
                        CssClass="scrButton"
                        Font-Bold="True"
                        OnClientClick="return validateApproval();"
                        />
                    <asp:Button ID="Rej_btn"
    runat="server"
    Text="REJECT"
    CssClass="scrButton"
    Font-Bold="True"
    OnClientClick="return validateApproval();"
    />
                    <input id="cmd_ext"
                        type="button"
                        value="EXIT"
                        onclick="return cmd_ext_onclick()"
                        class="scrButton"
                        />
                </td>
            </tr>
        </table>

        <input id="Hidden2" runat="server" type="hidden" clientidmode="Static" />
        <input id="hid_load" runat="server" type="hidden" />
        <input id="hid_access" runat="server" type="hidden" />
        <input id="HiddenMarkerFlag" runat="server" type="hidden" />
    </div>


    <script type="text/javascript">
       
        window.onload = function () {
            var branch = document.getElementById('<%= chk_branch.ClientID %>');
            var emp = document.getElementById('<%= chk_emp.ClientID %>');
            var branchDropdown = document.getElementById('<%= cmb_branch.ClientID %>');
            var grid = document.getElementById('<%= upEmpGrid.ClientID %>');

            toggleBranchDropdown(); // set initial state

            if (branch && emp) {
                branch.addEventListener('change', function () {
                    if (branch.checked) {
                        emp.checked = false;
                        branchDropdown.disabled = false; // enable dropdown
                    } else {
                        branchDropdown.disabled = true; // disable dropdown
                    }
                    grid.style.display = "none"; // hide grid
                });

                emp.addEventListener('change', function () {
                    if (emp.checked) {
                        branch.checked = false;
                        branchDropdown.disabled = true; // 🔹 DISABLE dropdown here
                        grid.style.display = "block"; // show grid
                    } else {
                        // only enable dropdown if branch is checked
                        branchDropdown.disabled = !branch.checked;
                        grid.style.display = "none";
                    }
                });
            }
        };

    </script>
</asp:Content>
