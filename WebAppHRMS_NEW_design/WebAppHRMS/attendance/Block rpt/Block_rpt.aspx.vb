Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class HRM_Block_Report_Block_rpt_8fb258187736
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt, dt1, dt2 As New DataTable
    Dim repo As New ReportDocument
    Dim userAll() As String
    Dim usercode As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User() As String = Session("user_id").ToString.Split("!")
        Dim dtt As String = Request.QueryString.Get("fdt")
        Dim dta As String = Request.QueryString.Get("tdt")
        dt = oh.ExecuteDataSet("select a.EMP_CODE,  e.EMP_NAME,  a.CURR_DATE as Block_DATE,  b.block_reason as BLOCK  from attend_his a, emp_master e, block_master_1 b, employ_firm f  where a.CURR_DATE between '" & dtt & "' and '" & dta & "'  and a.block like '%,' || b.block_id || ',%'  and a.GUN_STATUS > 0  and a.EMP_CODE = e.EMP_CODE  and e.EMP_CODE = " & User(0) & "  and e.EMP_CODE = f.emp_code  and f.firm_id = " & Session("firm_id") & "  and a.BLOCK is not null").Tables(0)
        repo.Load(Server.MapPath("Block_datewise.rpt"), OpenReportMethod.OpenReportByTempCopy)
        repo.Database.Tables("Blck").SetDataSource(dt)
        repo.SetParameterValue("Frdt", dtt)
        repo.SetParameterValue("Todt", dta)
        repo.SetParameterValue("Firm", Session("firm_name"))
        Me.crys1.DisplayGroupTree = False
        Me.crys1.ReportSource = repo
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        repo.Dispose()
        repo.Close()
        GC.Collect()
    End Sub
End Class
