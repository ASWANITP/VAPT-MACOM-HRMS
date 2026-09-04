Imports System.Data.OracleClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Photo_upload_Photo_Upload_Report_New_c8d6a82f4412
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim crSections As Sections
    Dim report As New ReportDocument
    Dim UserAll(), BranchAll() As String
    Dim UserCode, BranchId As Integer
    Dim dt As DataTable
    Dim export As New IO.MemoryStream
    ''krishnadas modified

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim frm As Integer = Me.Session("firm_id")
        Dim BranchId As Integer = Me.Session("branch_id")



        'dt = oh.ExecuteDataSet("select e.emp_code, h.emp_name, d.photo  from dms.hrm_emp_ph_certi d, hrm_emp_upload h,employee_master e  where d.emp_code = h.emp_code  and e.emp_code=h.emp_code  and e.status_id=1  and h.status_id = 1    and e.branch_id = " & Me.Request.QueryString("fdt") & "").Tables(0)
        ' dt = oh.ExecuteDataSet("select e.emp_code,f.firm_id, h.emp_name, d.photo from dms.hrm_emp_ph_certi d, hrm_emp_upload h, employee_master e,employ_firm f where d.emp_code = h.emp_code and e.emp_code = h.emp_code and e.status_id = 1 and h.status_id = 1 and e.branch_id = " & Me.Request.QueryString("fdt") & " and f.firm_id = e.firm_id and e.emp_code = f.emp_code").Tables(0)

        'If dt1.Tables(0).Rows.Count = 0 Then
        ' dt = oh.ExecuteDataSet("select e.emp_code, h.emp_name, d.photo from dms.hrm_emp_ph_certi d, hrm_emp_upload h, employee_master e, employ_firm f where d.emp_code = h.emp_code and e.emp_code = h.emp_code and e.status_id = 1 and h.status_id = 1  and e.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and h.status_id = " & Me.Request.QueryString("fdt") & "").Tables(0)
        dt = oh.ExecuteDataSet("select em.emp_code, h.emp_name, bm.branch_id, bm.branch_name, d.photo, h.upload_dt from employee_master em, employ_firm  ef,  branch_master        bm,  macdms.hrm_emp_ph_certi d,  hrm_emp_upload       h  where d.emp_code = h.emp_code  and em.emp_code = h.emp_code  and em.status_id = 1  and em.emp_code = ef.emp_code  and em.branch_id = bm.branch_id  and h.status_id = " & Me.Request.QueryString("fdt") & "").Tables(0)
        report.Load(Server.MapPath("photoviewCrystalReport1.rpt"), OpenReportMethod.OpenReportByTempCopy)
        report.Database.Tables("Photo_View1").SetDataSource(dt)
        'Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ReportSource = report
        'Else
        'Dim str2 As New System.Text.StringBuilder
        'str2.Append("alert('branch not updated');")

        'Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client", str2.ToString, True)

        'End If

    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        report.Close()
        report.Dispose()
        GC.Collect()

    End Sub
End Class
