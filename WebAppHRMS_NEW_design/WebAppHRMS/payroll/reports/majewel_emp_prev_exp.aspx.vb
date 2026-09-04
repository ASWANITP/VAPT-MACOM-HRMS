Imports System.Data
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class Honey_Edit_Experience_majewel_emp_prev_exp_2b844f928508
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim rep As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("firm_id") = 24) Then
            dt = oh.ExecuteDataSet("select em.emp_name,  t.emp_code,  bm.branch_name,  dm.dep_name,  t.organisation,  t.designation,  to_char(t.exp_frdate) as exp_frdate,  to_char(t.exp_todate) as exp_todate,  t.nature_duty,  to_date(t.exp_todate) - to_date(t.exp_frdate) as exp,  pm.post_name  from employ_experience_dtl t,  employee_master       em,  branch_master         bm,  department_mst        dm,  post_mst              pm,employ_firm f  where em.emp_code = t.emp_code  and em.branch_id = bm.branch_id  and em.department_id = dm.dep_id  and em.emp_code=f.emp_code  and em.post_id = pm.post_id  and f.firm_id in (24)  and em.status_id in (1)  order by pm.post_name").Tables(0)
            rep.Load(Server.MapPath("maj_exp_prev.rpt"), OpenReportMethod.OpenReportByTempCopy)
            rep.Database.Tables("maj_prev_exp").SetDataSource(dt)
            Me.CrystalReportViewer1.DisplayGroupTree = False
            rep.SetParameterValue("FIRM", Session("firm_name"))
            rep.SetParameterValue("FIRM1", "MAJEWEL EMPLOYEES PREVIOUS EXPERIENCE DETAILS")
            Me.CrystalReportViewer1.ReportSource = rep
        Else

            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('You are not authorized');")
            cl_script1.Append("window.open('../../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rep.Dispose()
        rep.Close()
        GC.Collect()
    End Sub
End Class
