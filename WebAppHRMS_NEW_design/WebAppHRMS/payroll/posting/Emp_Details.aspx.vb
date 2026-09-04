Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class HRM_Emp_Details_3fcbd70b4273
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim repo As New ReportDocument
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nam As String = Request.QueryString.Get("e_name")
        Dim bir As String = Request.QueryString.Get("dob")
        dt = oh.ExecuteDataSet("select p.emp_code as EMP_CODE,p.emp_name as NAME,b.branch_name as BRANCH,p.birth_date as D_O_B,e.join_dt as D_O_J  from employ_personal_dtl p,employee_master e,branch_dtl_new b where e.branch_id=b.branch_id and p.emp_code=e.emp_code and p.emp_name like ('%" & nam & "%') and p.birth_date = to_date('" & bir & "')").Tables(0)
        repo.Load(Server.MapPath("Emp_Dtls.rpt"), OpenReportMethod.OpenReportByTempCopy)
        repo.Database.Tables("Emp_new").SetDataSource(dt)

        repo.SetParameterValue("FIRM", Session("firm_name"))
        Me.vieww.DisplayGroupTree = False
        Me.vieww.ReportSource = repo
    End Sub
End Class
