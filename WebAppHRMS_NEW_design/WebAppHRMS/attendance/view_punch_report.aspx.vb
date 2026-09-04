Imports System.Data
Imports System.Data.OracleClient
Partial Class new_view_punch_report_2b45d0532897
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim dr As DataRow
    Dim str, str1, sql, sql1 As String

    Dim ttype As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt2 = oh.ExecuteDataSet("select stat from photo_stat where module_id=1 union all select stat from photo_stat where module_id=3").Tables(0)
            If Session("firm_id") = 8 And dt2.Rows(0)(0) = 1 Then
                'Server.Transfer("photo punch report/ajax_punch_report.aspx")
                Response.Redirect("~/attendance/photo punch report/ajax_punch_report.aspx")
            End If
            If Session("firm_id") = 27 And dt2.Rows(1)(0) = 1 Then
                'Server.Transfer("photo punch report/punch_report.aspx")
                Response.Redirect("~/attendance/photo punch report/punch_report.aspx")
            End If
            If Session("firm_id") = 28 And dt2.Rows(1)(0) = 1 Then
                'Server.Transfer("photo punch report/punch_report.aspx")
                Response.Redirect("~/attendance/photo punch report/mfpunch_report.aspx")
            End If
            If Session("firm_id") = 24 And dt2.Rows(1)(0) = 1 Then
                'Server.Transfer("photo punch report/punch_report.aspx")
                Response.Redirect("~/attendance/photo punch report/mfpunch_report.aspx")
            End If
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            ' dt1 = oh.ExecuteDataSet("select count(emp_code) from employee_master t where emp_code=" & sf(0) & " and status_id=1 and t.branch_id=0 and (((department_id in (189)) or (department_id in (183)) or (department_id in (23)) or (department_id in (180)) or (department_id in (304)) or (department_id in (411)) or (department_id in (179))or (department_id in (491))or (department_id in (472))) or emp_code in (11046,45745,42887,13296,21820,14291,65161,11234))").Tables(0)

            dt = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=811 and s.emp_id=" & sf(0) & "").Tables(0)
            If (dt.Rows(0)(0) = 0) Then
                Server.Transfer("../show_err.aspx")

            End If

            Me.Txt_fdt.Text = Format(Date.Today, "dd/MMM/yyyy")
            Me.Txt_tdt.Text = Format(Date.Today, "dd/MMM/yyyy")
            sql = "select state_name,state_id from state_master order by state_name"
            dt = oh.ExecuteDataSet(sql).Tables(0)
            Me.cmb_state.DataSource = dt
            Me.cmb_state.DataTextField = dt.Columns(0).ColumnName
            Me.cmb_state.DataValueField = dt.Columns(1).ColumnName
            Me.cmb_state.DataBind()

            sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id=" & Session("firm_id") & " order by branch_name"
            dt1 = oh.ExecuteDataSet(sql1).Tables(0)
            Me.cmb_branch.DataSource = dt1
            Me.cmb_branch.DataTextField = dt1.Columns(0).ColumnName
            Me.cmb_branch.DataValueField = dt1.Columns(1).ColumnName
            Me.cmb_branch.DataBind()
        End If

    End Sub

    Protected Sub cmd_confirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_confirm.Click
        Dim cl_script9 As New StringBuilder
        If (CDate(Me.Txt_fdt.Text) > CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            cl_script9.Append(" alert('Future date is not allowed in From Date!! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        End If
        If (CDate(Me.Txt_tdt.Text) > CDate(Format(Date.Today, "dd/MMM/yyyy"))) Then

            cl_script9.Append(" alert('Future date is not allowed in TO Date!! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        End If

        If (CDate(Me.Txt_fdt.Text) > CDate(Me.Txt_tdt.Text)) Then

            cl_script9.Append(" alert('check date entered ,From date is greater than To date !! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)

            Exit Sub
        End If

        If (Me.cmb_branch.SelectedValue = "") Then

            cl_script9.Append(" alert('No Branch is selected !! ');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script9.ToString, True)
            Exit Sub
        Else
            Server.Transfer("Display_punch_report.aspx?br=" & Me.cmb_branch.SelectedValue & "&fdt=" & Me.Txt_fdt.Text & "&tdt=" & Me.Txt_tdt.Text & "")

        End If


    End Sub

    Protected Sub cmb_state_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_state.SelectedIndexChanged
        Dim ff As Integer = Session("firm_id")
        'If (ff = 6) Or (ff = 14) Or (ff = 31) Or (ff = 32) Then

        '    sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id in(6,14,31,32) order by branch_name"
        'Else
        '    If ff = 24 Then
        '        If Me.cmb_state.SelectedValue = 18 Then
        '            sql1 = "select 'ADMINISTRATIVE OFFICE',0 from dual union all select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id=" & Session("firm_id") & " order by 1"

        '        Else
        '            sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id=" & Session("firm_id") & " order by branch_name"
        '        End If

        '    End If
        'End If

        If Me.cmb_state.SelectedValue = 18 Then
            If (ff = 6) Or (ff = 14) Or (ff = 31) Or (ff = 32) Then
                sql1 = "select 'ADMINISTRATIVE OFFICE',0 from dual union all select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id in(6,14,31,32)  order by 1"
            Else
                sql1 = "select 'ADMINISTRATIVE OFFICE',0 from dual union all select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id=" & Session("firm_id") & " order by 1"
            End If

        Else
            If (ff = 6) Or (ff = 14) Or (ff = 31) Or (ff = 32) Then
                sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id in(6,14,31,32)  order by branch_name"
            Else
                sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " and firm_id=" & Session("firm_id") & " order by branch_name"
            End If

        End If

        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Me.cmb_branch.DataSource = dt1
        Me.cmb_branch.DataTextField = dt1.Columns(0).ColumnName
        Me.cmb_branch.DataValueField = dt1.Columns(1).ColumnName
        Me.cmb_branch.DataBind()
    End Sub
End Class
