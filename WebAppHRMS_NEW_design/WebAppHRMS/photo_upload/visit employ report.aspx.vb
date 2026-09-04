Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class vipin_forms_visit_employ_report_08dede1f5123
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt2, dt5 As DataTable
    Dim export As New IO.MemoryStream


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt2 = oh.ExecuteDataSet("select e.emp_code, e.emp_name, p.post_name, d.photo, dp.dep_name  from dms.hrm_emp_ph_certi d,       employee_master      e,       post_mst             p,       department_mst       dp where e.emp_code = d.emp_code   and e.status_id = 1   and e.post_id = p.post_id   and e.department_id = dp.dep_id   and (e.post_id in (309, 199, 244, 136, 197) or e.department_id = 23)   and e.emp_code = " & Me.Request.QueryString("ecde") & "").Tables(0)

        report.Load(Server.MapPath("visitemployCrystalReport.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("visitemploy").SetDataSource(dt2)
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Server.Transfer("visit employee photo.aspx")
        'Response.Redirect("visit employee photo.aspx")

    End Sub
End Class
