Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class CashBalance_authorised_signatory_akgn_59fc873f5248
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim s As String
    Dim dt As DataTable
    Dim rep As New ReportDocument
    Dim brid As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim brid As String = Request.QueryString.Get("brid")
        Dim keyid As String = Request.QueryString.Get("key")
        If keyid = 1 Then
            s = "select t.brid,s.branch_name,t.akng from mis.authorized_sig_upd t,branch_master s  where t.brid=" & brid & " and t.brid=s.branch_id"
        Else
            s = "select t.brid,s.branch_name,t.akng from temp_authorized_sig_upd t,branch_master s  where t.brid=" & brid & " and t.brid=s.branch_id"
        End If
        's = "select t.brid,s.branch_name,t.akng from temp_authorized_sig_upd t,branch_master s  where t.brid=" & brid & " and t.brid=s.branch_id"
        
        dt = oh.ExecuteDataSet(s).Tables(0)
        rep.Load(Server.MapPath("signing_power_akg.rpt"), OpenReportMethod.OpenReportByTempCopy)
        rep.SetDataSource(dt)
        rep.SetParameterValue("firm_name", Session("firm_name"))
        rep.SetParameterValue("branch_name", Session("branch_name"))
        rep.SetParameterValue("branch_id", Session("branch_id"))
        Me.CrystalReportViewer1.ReportSource = rep
    End Sub

    Protected Sub form1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Unload
        rep.Close()
        rep.Dispose()
        GC.Collect()
    End Sub
End Class
