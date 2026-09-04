Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Sd_ta_salary_details_664e3b3a2429
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim oStream As New IO.MemoryStream
    Dim dt, dt1, dt2 As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("status") = 1 Then
            dt1 = oh.ExecuteDataSet("select a.block from attend a where a.emp_code=" & Request.QueryString("emp") & " and to_date(a.curr_date)=to_date(" & Request.QueryString("dtt") & ")").Tables(0)
            If dt1.Rows.Count = 0 Then
                Dim cl_script0 As New System.Text.StringBuilder
                cl_script0.Append("         alert(' No blocks found ! ');")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script0.ToString, True)
                Exit Sub
            Else
                dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.BRANCH_NAME,to_char(a.curr_date) as blk_dt,get_emp_block('" & dt1.Rows(0)(0) & "') as blk_dtl from employee_master e,attend a,branch b where e.emp_code=" & Request.QueryString("emp") & " and e.emp_code=a.emp_code and a.branch_id=b.BRANCH_ID and to_date(a.curr_date)=to_date(" & Request.QueryString("dtt") & ")").Tables(0)
            End If

        Else

            dt = oh.ExecuteDataSet("select e.emp_code,e.emp_name,b.BRANCH_NAME,to_char(a.curr_date) as blk_dt,get_emp_block(a.block) as blk_dtl from employee_master e,attend a,branch b where e.emp_code=a.emp_code and a.block is not null and a.branch_id=b.BRANCH_ID and to_date(a.curr_date)=to_date(" & Request.QueryString("dtt") & ")").Tables(0)

        End If
        




        report.Load(Server.MapPath("block_punch_details.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("block_dtl").SetDataSource(dt)

        oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(oStream.ToArray())
        Response.End()

        Me.CrystalReportViewer1.ReportSource = oStream
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
