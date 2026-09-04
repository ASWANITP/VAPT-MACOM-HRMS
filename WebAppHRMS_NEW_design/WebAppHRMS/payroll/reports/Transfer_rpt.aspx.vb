Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class HRM_Daily_Report_Transfer_rpt_0410f7354170
    Inherits System.Web.UI.Page
    Dim repo As New ReportDocument
    Dim dt As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fdtt As String = Request.QueryString.Get("fdt")
        Dim tdtt As String = Request.QueryString.Get("tdt")
        'dt = oh.ExecuteDataSet("select t.emp_code as EMP_CODE, e.EMP_NAME as EMP_NAME, t.from_dt as Transfer_Date, d.dep_name as Department,b.BRANCH_NAME as Branch,b1.BRANCH_NAME as Transfer_From  from employ_transfer_dtl t,emp_master e,department_mst d,branch b,branch b1,employ_transfer_dtl t1 where e.EMP_CODE = t.emp_code and t.branch_id=b.BRANCH_ID and t1.branch_id=b1.BRANCH_ID and t1.to_dt=to_date(t.from_dt)-1 and t.emp_code=t1.emp_code and t.status_id = 8 and t.department_id=d.dep_id and t.from_dt between to_date('" & fdtt & "') and to_date('" & tdtt & "') and t.branch_id = 0 and t.to_dt is null and e.FIRM_ID=1 and t1.to_dt is not null and t1.branch_id <> 0 order by t.emp_code").Tables(0)

        dt = oh.ExecuteDataSet("select t.emp_code as EMP_CODE, e.EMP_NAME as EMP_NAME, t.from_dt as Transfer_Date, d.dep_name as Department,b.BRANCH_NAME as Branch,b1.BRANCH_NAME as Transfer_From  from employ_transfer_dtl t,emp_master e,department_mst d,branch b,branch b1,employ_transfer_dtl t1,employ_firm ef where e.EMP_CODE = t.emp_code  and e.EMP_CODE = ef.emp_code  and ef.firm_id = " & Session("firm_id") & " and t.branch_id=b.BRANCH_ID and t1.branch_id=b1.BRANCH_ID and t1.to_dt=to_date(t.from_dt)-1 and t.emp_code=t1.emp_code and t.status_id = 8 and t.department_id=d.dep_id and t.from_dt between to_date('" & fdtt & "') and to_date('" & tdtt & "') and t.branch_id = 0 and t.to_dt is null and e.FIRM_ID=1 and t1.to_dt is not null and t1.branch_id <> 0 order by t.emp_code").Tables(0)
        repo.Load(Server.MapPath("Transfer_dtl.rpt"), OpenReportMethod.OpenReportByTempCopy)
        repo.Database.Tables("Transfer").SetDataSource(dt)
        'repo.SetParameterValue("Man", k)
        repo.SetParameterValue("FIRM", Session("firm_name"))
        Me.crys1.DisplayGroupTree = False
        Me.crys1.ReportSource = repo
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        repo.Dispose()
        repo.Close()
        GC.Collect()
    End Sub
End Class
