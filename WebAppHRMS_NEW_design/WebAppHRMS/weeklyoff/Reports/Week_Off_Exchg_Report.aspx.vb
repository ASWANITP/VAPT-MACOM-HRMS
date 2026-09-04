Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class HRM_Week_Off_Exchg_Report_de93d0cc6977
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim repo As New ReportDocument
    Dim dt As DataTable
    Dim s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'hiddn1.Value = Session("Branch_id")
        Dim bran As String = Request.QueryString.Get("bran_name")
        dt = oh.ExecuteDataSet("select e.emp_code as Employ_Code,e.emp_name as Employ_Name,b.branch_name as Branch_Name,c.designation as Designation,p.post_name as post_name,q.dep_name as Department,t.emp_name as Exchang_From,decode(h.holiday,'1','SUNDAY','2','MONDAY','3','TUESDAY','4','WEDNESDAY','5','THURSDAY','6','FRIDAY','7','SATURDAY')as Holiday from employee_master e,designation_master c,branch_master b,department_mst q,hrm_7days_off_day h,post_mst p,employee_master t where q.dep_id = e.department_id and c.designation_id = e.designation_id and p.post_id = e.post_id and e.branch_id = b.branch_id and t.emp_code = h.exchg_code and h.emp_code = e.emp_code and h.status = 2 and b.branch_id =" & bran & "").Tables(0)
        repo.Load(Server.MapPath("Week_Off_Exchg_Rpt.rpt"), OpenReportMethod.OpenReportByTempCopy)
        repo.Database.Tables("Week_Off_Exg").SetDataSource(dt)
        If bran = 0 Then
            repo.SetParameterValue("Branch", Session("branch_name"))
            'repo.SetParameterValue("Branchid", Session("branch_Id"))
        Else
            dt = oh.ExecuteDataSet("select branch_name from branch_master where branch_id='" & bran & "'").Tables(0)
            s = dt.Rows(0)(0).ToString
            repo.SetParameterValue("Branch", s)

        End If

        Me.cryst1.DisplayGroupTree = False
        Me.cryst1.ReportSource = repo
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        repo.Close()
        repo.Dispose()
        GC.Collect()

    End Sub
End Class
