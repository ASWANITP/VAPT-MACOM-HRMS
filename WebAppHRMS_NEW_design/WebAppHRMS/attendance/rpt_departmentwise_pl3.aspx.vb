Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class departmentwise_pl3_rpt_departmentwise_pl3_55636d356569
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dep_id As Integer = Request.QueryString("dep_id")
        Dim s As String = Request.QueryString("dep_name")
        Dim dt As DataTable
        Dim str As String
        '   str = "select l.emp_code,e.emp_name,b.branch_name,lm.leave_type,l.leave_date,l.reason from leave_pl3 l, employee_master e,branch_master b,leave_master lm,department_mst d where l.emp_code=e.emp_code and l.branch_id=b.branch_id and l.leave_type=lm.leave_id and e.department_id=d.dep_id and l.branch_id in(select distinct branch_id from employee_master where department_id=" & dep_id & ") and e.department_id=" & dep_id & "and l.leave_date between '" & Request.QueryString("fr_dt") & "' and ' " & Request.QueryString("to_dt") & "'"
        str = "select l.emp_code,e.emp_name,b.branch_name,lm.leave_type,l.leave_date,l.reason from leave_pl3 l, employee_master e,branch_master b,leave_master lm,department_mst d,employ_firm ef where l.emp_code=e.emp_code and e.emp_code = ef.emp_code and ef.firm_id = " & session("firm_id") & "  and l.branch_id=b.branch_id and l.leave_type=lm.leave_id and e.department_id=d.dep_id and l.branch_id in(select distinct branch_id from employee_master where department_id=" & dep_id & ") and e.department_id=" & dep_id & "and l.leave_date between '" & Request.QueryString("fr_dt") & "' and ' " & Request.QueryString("to_dt") & "'"
        dt = oh.ExecuteDataSet(str).Tables(0)
        report.Load(Server.MapPath("crptdepartmentwisepl3.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetDataSource(dt)
        Dim par1 As String = "DEPARTMENT - "
        par1 = par1 + Request.QueryString("dep_name")
        report.SetParameterValue("dpt", par1)

        report.setparametervalue("FIRM", session("firm_name"))
        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
