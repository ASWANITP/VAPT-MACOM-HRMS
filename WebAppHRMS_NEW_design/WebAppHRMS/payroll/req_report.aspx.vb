Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Partial Class req_report_37518d1f3839
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim oh As New Helper.Oracle.OracleHelper
    Dim dt As New DataTable

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'Dim reportName As String = "RESOURCE REQUISITION REPORT"

        'Dim id As Integer = Request.QueryString.Get("IDV")
        'Me.CrystalReportViewer1.RefreshReport()
        'dt = oh.ExecuteDataSet("select t.date_req as DOR,t.date_req as RQBY,upper(t.job_title) as JT,upper(t.division) as DV,t.no_of_req as NOR,t.expected_dt as EXDT,decode(t.tenure,1,'TEMPORARY',2,'PERMENENT')as TENURE,upper(t.Qualif) as QUALIF,t.expirience as EXPRNC,upper(t.loc) as LOCA,t.tot_strength as STRNGTH,t.pay_scale as PAY,t.no_vacancy as VACC,decode(t.gender,0,'MALE',1,'FEMALE') as GEND  ,substr(t.reason_rq,0,length(t.reason_rq)-4) as REASON, upper(t.addi_info) as ADDI from MAN_REQ_DTLS t where t.req_id=" & id & "").Tables(0)
        'report.Load(Server.MapPath("IDrpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        'report.Database.Tables("Resources").SetDataSource(dt)
        'CrystalReportViewer1.DisplayToolbar = False
        'report.SetParameterValue("IDD", id)
        ''report.SetParameterValue("Branchname", Session("branch_name"))
        'Me.CrystalReportViewer1.ReportSource = report
        ''Me.CrystalReportViewer1.RefreshReport()
        'dt.Dispose()


    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim reportName As String = "RESOURCE REQUISITION REPORT"

        Dim id As Integer = Request.QueryString.Get("IDV")
        dt = oh.ExecuteDataSet("select t.date_req as DOR,t.req_by as RQBY,upper(t.job_title) as JT,upper(t.division) as DV,t.no_of_req as NOR,t.expected_dt as EXDT,decode(t.tenure,1,'TEMPORARY',2,'PERMENENT')as TENURE,upper(t.Qualif) as QUALIF,t.expirience as EXPRNC,upper(t.loc) as LOCA,t.tot_strength as STRNGTH,t.pay_scale as PAY,t.no_vacancy as VACC,decode(t.gender,0,'MALE',1,'FEMALE') as GEND  ,substr(t.reason_rq,0,length(t.reason_rq)-4) as REASON, upper(t.addi_info) as ADDI from MAN_REQ_DTLS t where t.req_id=" & id & "").Tables(0)
        report.Load(Server.MapPath("IDrpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("Resource").SetDataSource(dt)
        CrystalReportViewer1.DisplayToolbar = False
        report.SetParameterValue("IDD", id)
        ''report.SetParameterValue("Branchname", Session("branch_name"))
        Me.CrystalReportViewer1.ReportSource = report
        ''Me.CrystalReportViewer1.RefreshReport()
        dt.Dispose()


    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
        dt.Dispose()
    End Sub
End Class
