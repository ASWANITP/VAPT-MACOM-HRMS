Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Check_Hrm_Appnt_order_b7aa655b2624
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim dt, dt1, dt2, dt3, dt4, dt_emp As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user = Session("user_id").ToString.Split("!")
        Dim frm = Session("firm_name").ToString
        Dim fid = Session("firm_id").ToString
        'Dim ff As DataTable = oh.ExecuteDataSet("select firm_abbr from firm_master where firm_id=" & fid).Tables(0)
        dt1 = oh.ExecuteDataSet("select e.EMP_NAME, p.perm_add1,to_date(e.JOIN_DT), p.father_name, pp.pin_code,e.JOIN_DT+365,p.sex,p.marital_status from emp_master e, employ_personal_dtl p, post_master  pp where p.perm_pin = pp.sr_number  and e.EMP_CODE=p.emp_code  and e.EMP_CODE= " & user(0) & " ").Tables(0)
        'Dim yr As Integer = dt1.Rows(0)(2) + 365
        ' Dim dt As Integer = Format(dt1.Rows(0)(2), "yyyy") + 1
        'Dim dt As Integer = Format(dt1.Rows(0)(2), "dd")
        report.Load(Server.MapPath("App_order.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.SetParameterValue("firm", frm)
        report.SetParameterValue("Name", dt1.Rows(0)(0))
        report.SetParameterValue("Addr", dt1.Rows(0)(1))
        report.SetParameterValue("jdt", dt1.Rows(0)(2))
        report.SetParameterValue("father", dt1.Rows(0)(3))
        report.SetParameterValue("pin", dt1.Rows(0)(4))
        report.SetParameterValue("yrdt", dt1.Rows(0)(5))
        If dt1.Rows(0)(6) = 1 Then
            report.SetParameterValue("ss", "S/O")
        Else
            report.SetParameterValue("ss", "D/O")
        End If
        'report.SetParameterValue("Yrs", yr)
        'report.SetParameterValue("dat", dt)
        export = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(export.ToArray())

        Response.End()

        Me.Viewer1.ReportSource = export
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
