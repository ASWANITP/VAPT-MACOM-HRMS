Imports System.Data.OracleClient

Public Class dep_head_today_report
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim fdate, tdate As String
        'Dim emp As Integer
        'fdate = Request.QueryString.Get("fdt")
        'tdate = Request.QueryString.Get("tdt")
        'emp = Request.QueryString.Get("emp")

        If Not IsPostBack Then

            '' Execute and bind
            Dim sql As String = "select e.emp_name, e.emp_code, d.dep_name, b.branch_name, ds.designation, m.eff_dt, m.enter_dt, td.shift || ' --> ' || td.in_time || ' -- ' || td.out_time as old_shift, tn.shift || ' --> ' || tn.in_time || ' -- ' || tn.out_time as new_shift, (select e. emp_code||'-->'||e.emp_name from employee_master e where e.emp_code=m.tl_code) as tl_code, (select e. emp_code||'-->'||e.emp_name from employee_master e where e.emp_code=m.approve_code) as approve_code, m.tl_remarks, m.approve_remarks, m.status, case m.status when 0 then 'tl requested' when 1 then 'approved' when 2 then 'request rejected' else '---' end as status_text from macom_today_shift m join employee_master e on m.emp_code = e.emp_code join department_mst d on m.dep_id = d.dep_id join branch_master b on e.branch_id = b.branch_id join designation_master ds on e.designation_id = ds.designation_id join time_tab td on m.old_shift_id = td.shift_id join time_tab tn on m.new_shift_id = tn.shift_id where trunc(m.enter_dt) between :FromDate and :ToDate and m.approve_code  = :Empcode order by m.requ_id"
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
        End If

    End Sub

    Protected Sub BtnLoadReport_Click(sender As Object, e As EventArgs) Handles BtnLoadReport.Click

        '' Retrieve filter values from Session
        'Dim cat As String = Session("Category").ToString()
        'Dim fromDate As Date = Date.Parse(Session("ReportFrom"))
        'Dim toDate As Date = Date.Parse(Session("ReportTo"))

        '' Build parameterized query
        'Dim sql As String =

        'Dim prmFrom As New OracleParameter("fromDate", OracleDbType.Date) With {.Value = fromDate}
        'Dim prmTo As New OracleParameter("toDate", OracleDbType.Date) With {.Value = toDate}
        'Dim prmCat As New OracleParameter("cat", OracleDbType.Varchar2) With {.Value = cat}

        '' Execute and bind
        'Dim dt As DataTable = oh.ExecuteDataSet(sql, prmFrom, prmTo, prmCat).Tables(0)
        'gvReport.DataSource = dt
        'gvReport.DataBind()

    End Sub

    Protected Sub gvReport_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvReport.PageIndex = e.NewPageIndex
        ' Re-bind using the same logic
        BtnLoadReport_Click(Nothing, Nothing)
    End Sub

End Class