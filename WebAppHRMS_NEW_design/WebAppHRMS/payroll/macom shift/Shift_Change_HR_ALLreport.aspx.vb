Imports System.Data.OracleClient

Public Class Shift_Change_HR_ALLreport
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            ' 1. Always get the dates
            Dim fromDate As Date = Date.Parse(Request.QueryString("fdt"))
            Dim toDate As Date = Date.Parse(Request.QueryString("tdt"))

            ' 2. Read the mode and optional emp code
            Dim mode As String = Request.QueryString("mode")    ' "all" or "code"
            Dim empCode As String = Request.QueryString("emp")     ' may be Nothing

            ' 3. Now pass to your data‐retrieval logic:
            '    If mode="all", ignore empCode; if mode="code", filter by empCode.
            'GenerateReport(fromDate, toDate, mode, empCode)
            If mode = "code" Then

                ' Dim sql As String = "select hsc.emp_code, em.emp_name, hsc.eff_dt as shift_request_date, hsc.shift_id, tt.shift as shift_name, dm.dep_name, hsc.enter_dt from hrm_shift_change hsc join employee_master em on hsc.emp_code = em.emp_code join department_mst dm on hsc.dep_id = dm.dep_id join time_tab tt on hsc.shift_id = tt.shift_id and em.firm_id = 8 and hsc.enter_dt between :FromDate and :ToDate and hsc.emp_code=:EmpCode where hsc.status = 2 order by hsc.eff_dt desc"
                Dim sql As String = "select hsc.emp_code, em.emp_name, hsc.eff_dt as shift_request_date, (select b.in_time||'-->'||b.out_time from time_tab b where b.shift_id=hsc.shift_id) as shift_id, tt.shift as shift_name, dm.dep_name, hsc.enter_dt from hrm_shift_change hsc join employee_master em on hsc.emp_code = em.emp_code join department_mst dm on hsc.dep_id = dm.dep_id join time_tab tt on hsc.shift_id = tt.shift_id and em.firm_id = 8 and hsc.enter_dt between :FromDate and :ToDate and hsc.emp_code=:EmpCode where hsc.status = 2 order by hsc.eff_dt desc"

                Dim fromDt As DateTime = DateTime.ParseExact(Request.QueryString("fdt"), "yyyy-MM-dd", Nothing).Date
                Dim toDt As DateTime = DateTime.ParseExact(Request.QueryString("tdt"), "yyyy-MM-dd", Nothing).Date
                Dim emp As Integer = Integer.Parse(Request.QueryString("emp"))

                Dim pFromDate As New OracleParameter("FromDate", OracleType.DateTime) With {.Value = fromDt}
                Dim pToDate As New OracleParameter("ToDate", OracleType.DateTime) With {.Value = toDt}
                Dim pEmpCode As New OracleParameter("EmpCode", OracleType.Number) With {.Value = emp}

                Dim ds As DataSet = oh.ExecuteDataSet(sql, New OracleParameter() {pFromDate, pToDate, pEmpCode})
                Dim dt As DataTable = ds.Tables(0)

                gvReport.AllowPaging = False
                gvReport.DataSource = dt
                gvReport.DataBind()

            Else
                Dim sql As String = "select hsc.emp_code, em.emp_name, hsc.eff_dt as shift_request_date, (select b.in_time||'-->'||b.out_time from time_tab b where b.shift_id=hsc.shift_id) as shift_id, tt.shift as shift_name, dm.dep_name, hsc.enter_dt from hrm_shift_change hsc join employee_master em on hsc.emp_code = em.emp_code join department_mst dm on hsc.dep_id = dm.dep_id join time_tab tt on hsc.shift_id = tt.shift_id and em.firm_id = 8 and hsc.enter_dt between :FromDate and :ToDate where hsc.status = 2 order by hsc.eff_dt desc"
                Dim fromDt As DateTime = DateTime.ParseExact(Request.QueryString("fdt"), "yyyy-MM-dd", Nothing).Date
                Dim toDt As DateTime = DateTime.ParseExact(Request.QueryString("tdt"), "yyyy-MM-dd", Nothing).Date

                Dim pFromDate As New OracleParameter("FromDate", OracleType.DateTime) With {.Value = fromDt}
                Dim pToDate As New OracleParameter("ToDate", OracleType.DateTime) With {.Value = toDt}

                Dim ds As DataSet = oh.ExecuteDataSet(sql, New OracleParameter() {pFromDate, pToDate})
                Dim dt As DataTable = ds.Tables(0)

                gvReport.AllowPaging = False
                gvReport.DataSource = dt
                gvReport.DataBind()

            End If
        End If
    End Sub

    Protected Sub gvReport_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvReport.PageIndex = e.NewPageIndex
        ' Re-bind using the same logic
        BtnLoadReport_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnLoadReport_Click(sender As Object, e As EventArgs) Handles BtnLoadReport.Click

    End Sub
End Class