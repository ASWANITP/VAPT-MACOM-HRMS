Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Staff_In_BeforeCompletion_bc_staffrpt_d88e16313963
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim report As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,pm.post_name,dm.designation,bc.branch_name,sm.state_name from employee_master e,before_completion bc,post_mst pm,designation_master dm,state_master sm,employ_firm f where e.branch_id<0 and e.branch_id=bc.old_id and bc.branch_id is null and e.status_id=1 and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and e.post_id=pm.post_id and e.designation_id=dm.designation_id and bc.state_id=sm.state_id order by sm.state_name,bc.branch_name,e.emp_code").Tables(0)
        If dt.Rows.Count > 0 Then
            report.Load(Server.MapPath("Crpt_bcstaff.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(dt)
            ' report.SetParameterValue(0, "NOT PUNCHED IN " & Request.QueryString("fr_dt") & " (EVENING)")
            report.SetParameterValue("Firm", Session("Firm_name"))
            Me.CrystalReportViewer1.ReportSource = report
        Else
            Dim script1 As New System.Text.StringBuilder
            script1.Append("        alert('No Data Found');")
            '    script1.Append("window.open('evening_notpunching.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", script1.ToString, True)

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Dispose()
        GC.Collect()
    End Sub
End Class
