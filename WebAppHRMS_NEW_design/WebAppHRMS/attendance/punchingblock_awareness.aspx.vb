Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class jan2011_punchingblock_awareness_4427353a6398
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    ' Dim dt1 As DataTable
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user() As String = Me.Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select e.emp_name,e.emp_code,b.branch_name as br,ds.designation,p.post_name as post,d.dep_name as department,e.post_id from employee_master e,department_mst d,branch b,designation_master ds,post_mst p where e.emp_code=" & user(0) & " and b.branch_id=e.branch_id and e.designation_id=ds.designation_id and e.department_id=d.dep_id and e.post_id=p.post_id ").Tables(0)
        Dim dt As DataTable = oh.ExecuteDataSet("select t.block_reason as block,t.descp,t.contactno as contno from block_master_1 t where t.block_status=1 and t.post like '%," & dt1.Rows(0)(6) & ",%' union select t.block_reason as block,t.descp,t.contactno as contno from block_master_1 t where t.block_status=1 and t.post like '%,0,%' ").Tables(0)



        report.Load(Server.MapPath("punchingblock_details.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("pba1").SetDataSource(dt1)
        report.Database.Tables("pba2").SetDataSource(dt)
        report.SetParameterValue("FIRM", Session("firm_name"))
        'Me.CrystalReportViewer1.ReportSource = report

        Me.CrystalReportViewer1.ReportSource = report
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Me.report.Dispose()
        Me.report.Close()
        GC.Collect()

    End Sub
End Class
