Imports System.Data
Imports system.data.oracleclient
Partial Class salaryreport_wage_slip_5584e1976448
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim UserAll(), UserCode As String
    Dim str_tkn As New StringBuilder
    Dim access As Integer
    Dim frm As Integer


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_date.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frm = Session("firm_id")
        'Dim mt As DataTable = oh.ExecuteDataSet("select pvalue from dev2.wage_slip").Tables(0)
        'If frm = 8 AndAlso mt.Rows(0)(0) = 1 Then
        If (frm = 6 Or frm = 31) Then
            Response.Redirect("~/payroll/wage slip new chitty/wage_slip.aspx")
            Exit Sub
        End If



        If frm = 8 Then
            Response.Redirect("wage_slip_Macom.aspx")
            Exit Sub
        End If



        If frm = 2 Then
            Response.Redirect("wage_slip_maben.aspx")
            Exit Sub
        End If
        If frm = 28 Then
            Response.Redirect("~/payroll/wage slip new mafound/wage_slip.aspx")
            Exit Sub
        End If
        dt = oh.ExecuteDataSet("select count(*) from HRM_REPORT_MASTER t where t.firm_id=601").Tables(0)
        If frm = 24 And dt.Rows(0)(0) > 0 Then
            Response.Redirect("~/payroll/wage slip new majwl/wage_slip.aspx")
            Exit Sub
        End If
        If frm = 27 Then
            Response.Redirect("~/payroll/Posting/Wageslip_Mafarm/wage_slip_Mafarm.aspx")

            Exit Sub
        End If

        If Not IsPostBack Then
            access = Session("access_id")
            If Session("access_id") <> 33 Then
                Me.row1.Visible = False
                Me.row2.Visible = False
                Me.row3.Visible = False

            End If


            dt = oh.ExecuteDataSet("select distinct (to_char(to_date(sal_dt,'dd/mm/yyyy'))) from m_wage ").Tables(0)
            Me.cmb_date.DataSource = dt
            Me.cmb_date.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_date.DataValueField = dt.Columns(0).ColumnName
            Me.cmb_date.DataBind()
            If (Me.chk_firm.Checked = False And Me.chk_emp.Checked = False And Me.chk_bran.Checked = False) Then
                Me.cmb_bran.Visible = False
                Me.cmb_emp.Visible = False
                Me.cmb_firm.Visible = False
            End If
        End If
    End Sub

    Protected Sub chk_bran_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_bran.CheckedChanged
        If (Me.chk_bran.Checked = True) Then
            Me.chk_firm.Checked = False
            Me.chk_emp.Checked = False
            Me.cmb_bran.Visible = True
            Me.chk_branch.Checked = False
            Me.chk_allfirm.Checked = False
            Me.cmb_emp.Visible = False
            Me.cmb_firm.Visible = False
            dt = oh.ExecuteDataSet("select b.branch_name, b.branch_id   from branch_master b where b.firm_id=" & Session("firm_id") & " union select branch_name, old_id  from before_completion where branch_id is null and firm_id=" & Session("firm_id") & " order by branch_name").Tables(0)
            Me.cmb_bran.DataSource = dt
            Me.cmb_bran.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_bran.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_bran.DataBind()
        Else
            Me.cmb_bran.Visible = False

        End If
    End Sub

    Protected Sub chk_firm_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_firm.CheckedChanged
        If (Me.chk_firm.Checked = True) Then
            Me.chk_bran.Checked = False
            Me.chk_emp.Checked = False
            Me.cmb_firm.Visible = True
            Me.cmb_emp.Visible = False
            Me.cmb_bran.Visible = False
            Me.chk_branch.Checked = False
            Me.chk_allfirm.Checked = False
            dt = oh.ExecuteDataSet("select firm_name,firm_id from firm_master where firm_id=" & Session("firm_id") & "  order by firm_name").Tables(0)
            Me.cmb_firm.DataSource = dt
            Me.cmb_firm.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_firm.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_firm.DataBind()
        Else
            Me.cmb_firm.Visible = False
        End If




    End Sub

    Protected Sub chk_emp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_emp.CheckedChanged
        UserAll = Me.Session("user_id").ToString.Split("!")
        UserCode = UserAll(0)
        If (Me.chk_emp.Checked = True) Then
            Me.chk_bran.Checked = False
            Me.chk_firm.Checked = False
            Me.cmb_emp.Visible = True
            Me.cmb_bran.Visible = False
            Me.cmb_firm.Visible = False
            Me.chk_branch.Checked = False
            Me.chk_allfirm.Checked = False


            If Session("access_id") <> 33 Then
                dt = oh.ExecuteDataSet("select '------Select---------',0 from dual union all select e.emp_code ||'--------'||e.emp_name,e.emp_code from employee_master e,employ_firm f  where e.emp_code>9999 and e.emp_code=f.emp_code and f.emp_code=" & UserCode & "").Tables(0)
            Else
                dt = oh.ExecuteDataSet("select e.emp_code ||'--------'||e.emp_name,e.emp_code from employee_master e,employ_firm f  where e.emp_code>9999 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " order by e.emp_code").Tables(0)
            End If
            Me.cmb_emp.DataSource = dt
            Me.cmb_emp.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_emp.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_emp.DataBind()
        Else
            Me.cmb_emp.Visible = False
        End If
    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click


        If (Me.chk_bran.Checked = True) Then
            Server.Transfer("wage_slip_report.aspx?&br=" & Me.cmb_bran.SelectedValue & "&dt='" & Me.cmb_date.SelectedValue & "'&a=" & 1)
        End If
        If (Me.chk_firm.Checked = True) Then
            Server.Transfer("wage_slip_report.aspx?&fr=" & Me.cmb_firm.SelectedValue & "&dt='" & Me.cmb_date.SelectedValue & "'&a=" & 2)
        End If
        If (Me.chk_emp.Checked = True) Then
            If Me.cmb_emp.SelectedValue <> 0 Then
                'New code....
                Dim firm As Integer
                firm = Convert.ToInt32(Me.Session("firm_id"))
                dt = oh.ExecuteDataSet("Select t.block_status from hrm_salary_release t where t.firm_id=" & firm & " ").Tables(0)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)(0) = 0 Then
                        Dim cl_script As New StringBuilder
                        cl_script.Append("   alert('Salary Not Released.') ;")
                        cl_script.Append(" window.open('../Home.aspx','_self');")
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script.ToString, True)
                        Exit Sub
                    End If
                End If
                '................

                Server.Transfer("wage_slip_report.aspx?&em=" & Me.cmb_emp.SelectedValue & "&dt='" & Me.cmb_date.SelectedValue & "'&a=" & 3)
            Else
                str_tkn.Append("         alert('Select employee code...!');")
                str_tkn.Append(" window.open('../Home.aspx','_self');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", str_tkn.ToString, True)

            End If
        End If
        If (Me.chk_branch.Checked = True) Then
            Server.Transfer("wage_slip_report.aspx?&dt='" & Me.cmb_date.SelectedValue & "'&a=" & 4)
        End If
        If (Me.chk_allfirm.Checked = True) Then
            Server.Transfer("wage_slip_report.aspx?&dt='" & Me.cmb_date.SelectedValue & "'&a=" & 5)
        End If
    End Sub

    Protected Sub chk_branch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_branch.CheckedChanged
        If (Me.chk_branch.Checked = True) Then
            Me.chk_bran.Checked = False
            Me.chk_allfirm.Checked = False
            Me.chk_emp.Checked = False
            Me.chk_firm.Checked = False
            Me.cmb_emp.Visible = False
            Me.cmb_bran.Visible = False
            Me.cmb_firm.Visible = False
        End If
    End Sub

    Protected Sub chk_allfirm_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_allfirm.CheckedChanged
        If (Me.chk_allfirm.Checked = True) Then
            Me.chk_bran.Checked = False
            Me.chk_branch.Checked = False
            Me.chk_emp.Checked = False
            Me.chk_firm.Checked = False
            Me.cmb_emp.Visible = False
            Me.cmb_bran.Visible = False
            Me.cmb_firm.Visible = False
        End If
    End Sub

    Protected Sub cmd_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Response.Redirect("../home.aspx")
    End Sub


End Class
