Imports system.data
Imports System.Data.OracleClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Partial Class Check_Hrm_Relv_order_09f7a56f8716
    Inherits System.Web.UI.Page
    Dim report As New ReportDocument
    Dim dt, dt1, dt2, dt3, dt4, dt_emp As New DataTable
    Dim oh As New Helper.Oracle.OracleHelper
    Dim export As New IO.MemoryStream

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User1() As String = Session("user_id").ToString.Split("!")
        Dim UserId As Integer = User1(0)
        Dim ID As Integer = 728
        dt1 = oh.ExecuteDataSet("select count(*) from form_accessibility where form_id=" & ID & " and emp_id=" & User1(0) & "").Tables(0)
        If dt1.Rows.Count < 0 Then
            Dim cl_script0 As New System.Text.StringBuilder
            cl_script0.Append("         alert('You are not Authorised to View this Page !!!!');")
            cl_script0.Append("window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "clientscript", cl_script0.ToString, True)
        End If

        Dim user() As String = Session("user_id").ToString.Split("!")
        dt1 = oh.ExecuteDataSet("select count(*) from m_resign_appl r where r.emp_code=" & user(0) & " ").Tables(0)
        If dt1.Rows(0)(0) = 1 Then
            Dim frm = Session("firm_name").ToString
            Dim fid = Session("firm_id").ToString
            Dim ff As DataTable = oh.ExecuteDataSet("select firm_abbr from firm_master where firm_id=" & fid).Tables(0)
            dt1 = oh.ExecuteDataSet("select r.emp_code,e.EMP_NAME,d.dep_name,ds.designation,p.perm_add1, r.resign_dt, s.categ,e.JOIN_DT,p.father_name,pp.pin_code from m_resign_appl r, resign_reason_mst s,emp_master e,department_mst d,designation_master ds,employ_personal_dtl p,post_master pp where r.reason = s.categ_id and p.perm_pin=pp.sr_number and  r.emp_code=e.EMP_CODE and e.DEPARTMENT_ID=d.dep_id and e.DESIGNATION_ID=ds.designation_id and r.emp_code = " & user(0) & " and r.emp_code=p.emp_code ").Tables(0)
            report.Load(Server.MapPath("Reliv_order.rpt"), OpenReportMethod.OpenReportByTempCopy)
            report.SetParameterValue("frm", frm)
            report.SetParameterValue("Design", dt1.Rows(0)(3))
            report.SetParameterValue("Name", dt1.Rows(0)(1))
            report.SetParameterValue("Addr", dt1.Rows(0)(4))
            report.SetParameterValue("Code", dt1.Rows(0)(0))
            report.SetParameterValue("Deprtmt", dt1.Rows(0)(2))
            report.SetParameterValue("Reldt", dt1.Rows(0)(5))
            report.SetParameterValue("joindt", dt1.Rows(0)(7))
            report.SetParameterValue("Resn", dt1.Rows(0)(6))
            report.SetParameterValue("father", dt1.Rows(0)(8))
            report.SetParameterValue("pin", dt1.Rows(0)(9))
            'report.SetParameterValue("fr", ff)
            Dim exportStream As Stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

            ' Copy to MemoryStream to make it usable
            Dim export As New MemoryStream()
            exportStream.CopyTo(export)
            export.Position = 0

            ' Send it to the browser
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "inline; filename=report.pdf")
            Response.BinaryWrite(export.ToArray())
            Response.Flush()
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            Me.Viewer1.ReportSource = export
        Else
            Me.Response.Redirect("../show_err.aspx")
            Exit Sub
        End If
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()
    End Sub
End Class
