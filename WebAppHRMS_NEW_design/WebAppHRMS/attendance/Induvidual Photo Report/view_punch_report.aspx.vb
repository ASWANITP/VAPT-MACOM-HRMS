Imports System.Data
Imports System.Data.OracleClient
Partial Class new_view_punch_report_2b45d0533984
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Dim str, str1, sql, sql1 As String

    Dim ttype As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sf() As String
            sf = Session("user_id").ToString.Split("!")
            ' dt1 = oh.ExecuteDataSet("select count(emp_code) from employee_master t where emp_code=" & sf(0) & " and status_id=1 and t.branch_id=0 and (((department_id in (189)) or (department_id in (183)) or (department_id in (23)) or (department_id in (180)) or (department_id in (179))) or emp_code in (11046,45745,42887,13296,21820,14294))").Tables(0)
            dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility s where s.form_id=811 and s.emp_id=" & sf(0) & "").Tables(0)

            If (dt1.Rows(0)(0) = 0) Then
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

            sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " order by branch_name"
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
        sql1 = "select branch_name,branch_id from branch where state_id=" & Me.cmb_state.SelectedValue & " order by branch_name"
        dt1 = oh.ExecuteDataSet(sql1).Tables(0)
        Me.cmb_branch.DataSource = dt1
        Me.cmb_branch.DataTextField = dt1.Columns(0).ColumnName
        Me.cmb_branch.DataValueField = dt1.Columns(1).ColumnName
        Me.cmb_branch.DataBind()
    End Sub
End Class
