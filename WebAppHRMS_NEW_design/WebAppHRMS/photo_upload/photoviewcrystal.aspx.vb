Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class vipin_forms_photoviewcrystal_b43a2daa4317
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dt2 = oh.ExecuteDataSet("select d.emp_code, d.m_photo, p.photo  from employee_master e, dms.attend_photo d, dms.photo_upload p where d.emp_code = e.emp_code   and d.emp_code = p.employee_code   and d.curr_date = to_date(e.join_dt + 2)   and d.emp_code =  " & Me.Request.QueryString("fdt") & "").Tables(0)
        'dt2 = oh.ExecuteDataSet("select d.emp_code, d.m_photo, p.photo  from employee_master e, dms.attend_photo d, dms.hrm_emp_ph_certi p  where d.emp_code = e.emp_code  and d.emp_code = p.emp_code  and d.curr_date = to_date(e.join_dt + 2)  and d.emp_code = " & Me.Request.QueryString("fdt") & "").Tables(0)
        dt2 = oh.ExecuteDataSet("select d.emp_code, d.m_photo, p.photo  from employee_master e, dms.attend_photo d, dms.hrm_emp_ph_certi p  where d.emp_code = e.emp_code  and d.emp_code = p.emp_code  and d.curr_date = (select min(at.CURR_DATE) from attend_his at where at.emp_code=" & Me.Request.QueryString("fdt") & " and at.M_TIME is not null and at.M_TIME <>'JOIN' )  and d.emp_code = " & Me.Request.QueryString("fdt") & "").Tables(0)
        report.Load(Server.MapPath("photoviewCrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("photo_view").SetDataSource(dt2)
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()

    End Sub
End Class
