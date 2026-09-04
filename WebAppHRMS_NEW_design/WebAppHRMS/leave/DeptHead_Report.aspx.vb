Imports CrystalDecisions.Web
Imports Helper.Oracle
Imports System.Data
Imports System.Data.OracleClient
Imports System.Web.UI
Public Class DeptHead_Report
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim headSql As String
    Dim empSql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            'Dim headSql As String = "SELECT DISTINCT a.dep_id, a.dep_name, b.emp_code AS head_code, b.emp_name AS head_name, c.designation AS head_designation, p.post_name AS head_post, b.department_id AS head_dep_id FROM mactech.department_mst a JOIN mactech.employee_master b ON a.dep_head = b.emp_code JOIN mactech.designation_master c ON b.designation_id = c.designation_id JOIN mactech.employ_firm f ON b.emp_code = f.emp_code JOIN mactech.post_mst p ON b.post_id = p.post_id WHERE b.emp_code > 9999 AND f.firm_id = 8 AND b.status_id = 1 ORDER BY b.emp_code"
            Dim headSql As String = "SELECT d.dep_id, d.dep_name, e.emp_code AS head_code, e.emp_name AS head_name, desig.designation AS head_designation, post.post_name FROM mactech.employee_master e JOIN mactech.department_mst d ON d.dep_head = e.emp_code JOIN mactech.designation_master desig ON e.designation_id = desig.designation_id JOIN mactech.employ_firm f ON e.emp_code = f.emp_code JOIN mactech.post_mst post ON e.post_id = post.post_id WHERE e.emp_code > 9999 AND f.firm_id = 8 AND e.status_id = 1 ORDER BY e.emp_code"

            Dim heads As DataTable = oh.ExecuteDataSet(headSql).Tables(0)

            Dim reportData As New DataTable
            reportData.Columns.Add("dep_id")
            reportData.Columns.Add("dep_name")
            reportData.Columns.Add("emp_code")
            reportData.Columns.Add("emp_name")
            reportData.Columns.Add("designation")
            reportData.Columns.Add("post_name")
            reportData.Columns.Add("is_head", GetType(Boolean))

            For Each row As DataRow In heads.Rows
                ' Add head row
                'reportData.Rows.Add(row("dep_id"), row("dep_name"), row("head_code"), row("head_name"), row("head_designation"), row("head_post"), True)
                reportData.Rows.Add(row("dep_id"), row("dep_name"), row("head_code"), row("head_name"), row("head_designation"), row("post_name"), True)


                ' Fetch employees under this head
                Dim empSql As String = "SELECT b.emp_code, b.emp_name, c.designation, p.post_name, a.dep_id AS emp_dep_id FROM mactech.employee_master b JOIN mactech.designation_master c ON b.designation_id = c.designation_id JOIN mactech.employ_firm f ON b.emp_code = f.emp_code JOIN mactech.post_mst p ON b.post_id = p.post_id LEFT JOIN mactech.department_mst a ON a.dep_id = b.department_id WHERE b.emp_code > 9999 AND f.firm_id = 8 AND b.status_id = 1 AND a.dep_head = " & row("head_code") & " AND b.emp_code <> " & row("head_code") & " AND a.dep_id = " & row("dep_id") & " ORDER BY b.emp_code"

                Dim employees As DataTable = oh.ExecuteDataSet(empSql).Tables(0)

                For Each empRow As DataRow In employees.Rows
                    reportData.Rows.Add(row("dep_id"), row("dep_name"), empRow("emp_code"), empRow("emp_name"), empRow("designation"), empRow("post_name"), False)
                Next
            Next

            gvReport.DataSource = reportData
            gvReport.DataBind()
            'gvReport.AllowPaging = False
            'gvReport.DataSource = dt
            'gvReport.DataBind()
        End If

    End Sub

    Protected Sub BtnLoadReport_Click(sender As Object, e As EventArgs) Handles BtnLoadReport.Click

    End Sub

    Protected Sub gvReport_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvReport.PageIndex = e.NewPageIndex
        ' Re-bind using the same logic
        BtnLoadReport_Click(Nothing, Nothing)
    End Sub



    Protected Sub gvReport_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblSlNo As Label = CType(e.Row.FindControl("lblSlNo"), Label)
            lblSlNo.Text = (e.Row.RowIndex + 1).ToString()

            Dim drv As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim isHead As Boolean = Convert.ToBoolean(drv("is_head"))

            If isHead Then
                e.Row.Font.Bold = True
                e.Row.ForeColor = Drawing.Color.Black

            Else
                e.Row.Font.Bold = False
                e.Row.ForeColor = Drawing.Color.Black
            End If
        End If
    End Sub

End Class