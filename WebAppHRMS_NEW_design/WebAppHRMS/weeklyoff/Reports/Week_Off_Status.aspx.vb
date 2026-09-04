Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class HRM_Week_Off_Status_74549ed74074
    Inherits System.Web.UI.Page
    Dim UserAll(), res, sql As String
    Dim UserCode, l As Integer
    Dim oh As New Helper.Oracle.OracleHelper
    Dim repo As New ReportDocument
    Dim dt, dt1, dt2 As DataTable
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Try
            Dim eid As Integer = Request.QueryString.Get("emp_id")
            dt1 = oh.ExecuteDataSet("select e.emp_name from employee_master e where e.emp_code='" & eid & "'").Tables(0)
            s = dt1.Rows(0)(0)
            dt = oh.ExecuteDataSet("select h.from_dt as From_Date,h.to_dt To_Date,decode(h.holiday,'1','SUNDAY','2','MONDAY','3','TUESDAY','4','WEDNESDAY','5','THURSDAY','6','FRIDAY','7','SATURDAY')as HOLIDAY,decode(h.status,'0','closed','1','Live','2','Recommened','3','AM Approved','4','AM Rejected')as STATUS from hrm_7days_off_day h where h.emp_code='" & eid & "' order by h.from_dt").Tables(0)
            repo.Load(Server.MapPath("WeekOff_Status_Rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
            repo.Database.Tables("Week").SetDataSource(dt)
            repo.SetParameterValue("Employee", s)
            repo.SetParameterValue("Firm", Session("firm_name"))
            Me.crys1.DisplayGroupTree = False
            Me.crys1.ReportSource = repo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        repo.Close()
        repo.Dispose()
        GC.Collect()
    End Sub
End Class
